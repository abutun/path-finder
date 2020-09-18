/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*																		*
*	Copyright (C) 2007  Ahmet BUTUN (butun180@hotmail.com)				*
*	http://www.ahmetbutun.net									        *
*																		*
*	This program is free software; you can redistribute it and/or		*
*	modify it under the terms of the GNU General Public License as		*
*	published by the Free Software Foundation; either version 2 of		*
*	the License, or (at your option) any later version.					*
*																		*
*	This program is distributed in the hope that it will be useful,		*
*	but WITHOUT ANY WARRANTY; without even the implied warranty of		*
*	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU	*
*	General Public License for more details.							*
*																		*
*	You should have received a copy of the GNU General Public License	*
*	along with this program; if not, write to the Free Software			*
*	Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.			*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace PathFinder
{
    public partial class PathFinder : Form
    {
        SquareBoard currentSquareBoard = new SquareBoard(17);

        Square startPoint = null;

        Square endPoint = null;

        PathManager rootPathManager = null;

        PathManager prevPathManager = null;

        private int gridSize = 36;

        int dimensions;

        int prevX = -1, prevY = -1;

        bool freeDraw = false;

        public PathFinder()
        {
            InitializeComponent();
        }

        private void ClickOnSquare(MouseEventArgs e)
        {
            int x = e.X / gridSize;
            int y = e.Y / gridSize;

            bool changeColor = true;

            if (x < dimensions && x >= 0 && y < dimensions && y >= 0)
            {
                if (this.drawWallRadio.Checked)
                {
                    if (this.freeDraw)
                    {
                        if (x == prevY && y == prevX)
                            changeColor = false;
                    }

                    if (changeColor)
                    {
                        if (currentSquareBoard[y, x].Type != SquareType.BORDER)
                        {
                            if (currentSquareBoard[y, x].Type == SquareType.SQUARE)
                                currentSquareBoard[y, x].Type = SquareType.WALL;
                            else
                                currentSquareBoard[y, x].Type = SquareType.SQUARE;
                        }
                    }
                }

                this.Refresh();
            }

            prevX = y;

            prevY = x;
        }

        private void board_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.freeDraw = true;

            ClickOnSquare(e);
        }

        private void board_Paint(object sender, PaintEventArgs e)
        {
            Graphics myGraphics = e.Graphics;

            for (int i = 0; i < dimensions; i++)
            {
                for (int j = 0; j < dimensions; j++)
                {
                    Square currentSquare = currentSquareBoard[i, j];

                    myGraphics.DrawRectangle(new Pen(Color.DarkGoldenrod), j * gridSize, i * gridSize, gridSize, gridSize);

                    if (this.findSolutionRadio.Checked)
                        myGraphics.FillRectangle(new SolidBrush(currentSquare.PathStatusColor), j * gridSize + 1, i * gridSize + 1, gridSize - 1, gridSize - 1);
                    else
                        myGraphics.FillRectangle(new SolidBrush(currentSquare.TypeColor), j * gridSize + 1, i * gridSize + 1, gridSize - 1, gridSize - 1);
                }
            }

            if (this.startPoint!=null)
                myGraphics.FillEllipse(new SolidBrush(Color.DarkCyan), this.startPoint.Y * gridSize + 5, this.startPoint.X * gridSize + 5, gridSize - 10, gridSize - 10);

            if (this.endPoint != null)
                myGraphics.FillEllipse(new SolidBrush(Color.DarkCyan), this.endPoint.Y * gridSize + 5, this.endPoint.X * gridSize + 5, gridSize - 10, gridSize - 10);
        }

        private void setBoardSizeButton_Click(object sender, EventArgs e)
        {
            SetBoardSize();
        }

        private void SetBoardSize()
        {
            this.dimensions = Convert.ToInt32(this.boardSizeDropDown.Value);

            this.Init(true);

            this.Refresh();
        }

        private void drawWallButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.drawWallRadio.Checked)
            {
                this.statusLabel.Text = "";

                this.Init(false);

                this.pathListView.Nodes.Clear();

                this.solutionListBox.Items.Clear();

                this.solutionListBox.Enabled = false;

                this.Refresh();
            }
        }

        private void findSolutionButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.findSolutionRadio.Checked)
            {
                if (this.startPoint != null && this.endPoint != null)
                {
                    DateTime dbegin = DateTime.Now;

                    // assign the problem to a root path manager
                    rootPathManager = new PathManager(null, 0, this.startPoint, this.startPoint, this.endPoint, this.currentSquareBoard, true);

                    // try to solve the path
                    rootPathManager.BeginManagePath();

                    // show the path analyzes in the listview
                    BindManagersToPathView(null, rootPathManager);

                    if (rootPathManager.SolutionFound)
                    {
                        this.statusLabel.Text = rootPathManager.TotalSolutions.ToString() + " solution(s) found.";

                        this.solutionListBox.Enabled = true;

                        rootPathManager.Solutions.SortByTotalCost();

                        for (int i = 0; i < rootPathManager.Solutions.Count; i++)
                            this.solutionListBox.Items.Add(rootPathManager.Solutions[i]);
                    }
                    else
                        this.statusLabel.Text = "Not found!";

                    TimeSpan dend = DateTime.Now.Subtract(dbegin);

                    this.totalTime.Text = dend.Seconds.ToString() + "," + dend.Milliseconds.ToString() + " sec.";

                    this.Refresh();
                }
                else
                    MessageBox.Show("Please select starting and the ending point!");
            }
        }

        private void Init(bool redraw)
        {
            int i,j;

            // draw borders
            if (redraw)
            {
                for (i = 0; i < dimensions; i++)
                {
                    currentSquareBoard[0, i].Type = SquareType.BORDER;
                    currentSquareBoard[i, 0].Type = SquareType.BORDER;
                    currentSquareBoard[dimensions - 1, i].Type = SquareType.BORDER;
                    currentSquareBoard[i, dimensions - 1].Type = SquareType.BORDER;
                }
            }

            // draw empty content
            for (i = 1; i < dimensions - 1; i++)
            {
                for (j = 1; j < dimensions - 1; j++)
                {
                    if (redraw)
                    {
                        currentSquareBoard[i, j].Type = SquareType.SQUARE;
                        currentSquareBoard[i, j].PathStatus = SquarePathStatus.NONE;
                    }
                    else
                    {
                        if (currentSquareBoard[i, j].Type == SquareType.SQUARE)
                            currentSquareBoard[i, j].ResetSquare();
                    }
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.Init(true);

            this.Refresh();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void webSiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "iexplore";
            proc.StartInfo.Arguments = "http://www.ahmetbutun.net/";
            proc.Start();
        }

        private void board_MouseUp(object sender, MouseEventArgs e)
        {
            this.freeDraw = false;
        }

        private void board_MouseMove(object sender, MouseEventArgs e)
        {
            if (freeDraw)
                ClickOnSquare(e);
        }

        private void BindManagersToPathView(TreeNode rootNode, PathManager rootPathManager)
        {
            int index;

            string text = "";

            switch(rootPathManager.PathStatus)
            {
                case SquarePathStatus.PATH:
                    text = rootPathManager.Name + " (cost=" + rootPathManager.TotalCost.ToString() + ") ?";
                    break;
                case SquarePathStatus.CORRECT:
                    text = rootPathManager.Name + " (cost=" + rootPathManager.TotalCost.ToString() + ") *";
                    break;
                case SquarePathStatus.WRONG:
                    text = rootPathManager.Name + " (cost=" + rootPathManager.TotalCost.ToString() + ") !";
                    break;
                default:
                    text = rootPathManager.Name + " (cost=" + rootPathManager.TotalCost.ToString() + ")";
                    break;
            }

            TreeNode newNode = new TreeNode(text);
            newNode.Tag = rootPathManager.Name;

            if (rootNode != null)
                index = rootNode.Nodes.Add(newNode);
            else
                index = this.pathListView.Nodes.Add(newNode);

            if (rootPathManager.HasSubManagers)
            {
                for (int i = 0; i < rootPathManager.SubPathManagers.Count; i++)
                    if (rootNode != null)
                        BindManagersToPathView(rootNode.Nodes[index], rootPathManager.SubPathManagers[i]);
                    else
                        BindManagersToPathView(this.pathListView.Nodes[index], rootPathManager.SubPathManagers[i]);
            }
        }

        private void pathListView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            PathManager selectedManager = GetManager(e.Node.Tag.ToString());

            SelectTreeNode(selectedManager);
        }

        private void SelectTreeNode(PathManager selectedManager)
        {
            SquarePathStatus status = SquarePathStatus.PATH;

            if (selectedManager.PathStatus == SquarePathStatus.CORRECT)
                status = SquarePathStatus.CORRECT;
            else if (selectedManager.PathStatus == SquarePathStatus.WRONG)
                status = SquarePathStatus.WRONG;

            PathManager tmpPathManager = selectedManager;

            while (prevPathManager != null)
            {
                SetBoardStatus(prevPathManager, SquarePathStatus.NONE);

                prevPathManager = prevPathManager.ParentPathManager;
            }

            while (selectedManager != null)
            {
                SetBoardStatus(selectedManager, status);

                selectedManager = selectedManager.ParentPathManager;
            }

            prevPathManager = tmpPathManager;

            this.Refresh();
        }

        private void SetBoardStatus(PathManager manager, SquarePathStatus status)
        {
            for (int i = 0; i < manager.Path.Count; i++)
                this.currentSquareBoard[manager.Path[i].X, manager.Path[i].Y].PathStatus = status;
        }

        private PathManager GetManager(string name)
        {
            PathManager result = rootPathManager;

            for (int i = 1; i < name.Length; i++)
            {
                int currentIndex = int.Parse(name[i].ToString());

                result = result.SubPathManagers[currentIndex];
            }

            return result;
        }

        private TreeNode GetNode(string name)
        {
            TreeNode result = this.pathListView.Nodes[0];

            for (int i = 1; i < name.Length; i++)
            {
                int currentIndex = int.Parse(name[i].ToString());

                result = result.Nodes[currentIndex];
            }

            return result;
        }

        private void board_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X / gridSize;
                int y = e.Y / gridSize;

                if (this.startPoint == null)
                {
                    if (currentSquareBoard[y, x].Type != SquareType.BORDER && currentSquareBoard[y, x].Type != SquareType.WALL)
                        this.startPoint = new Square(y, x);
                }
                else if (this.startPoint.X == y && this.startPoint.Y == x)
                    this.startPoint = null;

                else if (this.endPoint == null)
                {
                    if (currentSquareBoard[y, x].Type != SquareType.BORDER && currentSquareBoard[y, x].Type != SquareType.WALL)
                        this.endPoint = new Square(y, x);
                }
                else if (this.endPoint.X == y && this.endPoint.Y == x)
                    this.endPoint = null;
            }

            this.Refresh();
        }

        private void MazeSolver_Load(object sender, EventArgs e)
        {
            SetBoardSize();
        }

        private void solutionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PathManager selectedPathManager = (PathManager)this.solutionListBox.SelectedItem;

            TreeNode currentNode = GetNode(selectedPathManager.Name);

            currentNode.EnsureVisible();

            SelectTreeNode(selectedPathManager);
        }
    }
}