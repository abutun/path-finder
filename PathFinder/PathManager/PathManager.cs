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
using System.Text;
using System.Windows.Forms;

namespace PathFinder
{
    public class PathManager : IComparable<PathManager>
    {
        private SquareBoard innerBoard_;

        private Square startPointSquare_, endPointSquare_;

        private Square sourceSquare_, targetSquare_;

        private SquareCollection innerPathSquares_;

        private PathManager parentPathManager_;

        private PathManagerCollection subPathManagers_;

        private PathManagerCollection innerSolutions_;

        private bool isRoot_;

        private int totalCost_;

        private int totalSolutions_;

        private SquarePathStatus pathStatus_;

        private bool endManagePath_ = false;

        private bool solutionFound_ = false;

        private string managerName_ = "";

        public PathManager(PathManager parentPathManager, int subIndex, Square startPoint, Square sourceSquare, Square targetSquare, SquareBoard board, bool isRoot)
        {
            // assign square board
            this.innerBoard_ = board;

            // which square this manager starts?
            this.startPointSquare_ = startPoint;

            // is this a root manager?
            this.isRoot_ = isRoot;

            // parent manager of this manager
            this.parentPathManager_ = parentPathManager;

            // total cost of this manager if we decide to take it
            this.totalCost_ = 0;

            this.totalSolutions_ = 0;

            this.innerPathSquares_ = new SquareCollection();

            // sub mangers collections
            this.subPathManagers_ = new PathManagerCollection();

            this.innerSolutions_ = new PathManagerCollection();

            // which path are we looking for a solution?
            this.sourceSquare_ = sourceSquare;
            this.targetSquare_ = targetSquare;

            this.endPointSquare_ = null;

            this.pathStatus_ = SquarePathStatus.PATH;

            // assign a unique name to the manager
            if (isRoot)
                this.managerName_ = "0";
            else
                this.managerName_ = parentPathManager.Name + subIndex.ToString();
        }

        public string Name
        {
            get
            {
                return this.managerName_;
            }
        }

        public bool SolutionFound
        {
            get
            {
                return this.solutionFound_;
            }
            set
            {
                this.solutionFound_ = value;

                if(value)
                    this.totalSolutions_++;
            }
        }

        public SquarePathStatus PathStatus
        {
            get
            {
                return this.pathStatus_;
            }
        }

        public bool IsRoot
        {
            get
            {
                return this.isRoot_;
            }
        }

        public bool HasSubManagers
        {
            get
            {
                return this.subPathManagers_.Count > 0;
            }
        }

        public int TotalCost
        {
            get
            {
                int cost = this.totalCost_;

                if (this.ParentPathManager != null)
                    cost += this.ParentPathManager.TotalCost;

                return cost;
            }
        }

        public int TotalSolutions
        {
            get
            {
                return this.totalSolutions_;
            }
        }

        public PathManager ParentPathManager
        {
            get
            {
                return this.parentPathManager_;
            }
        }

        public Square SourceSquare
        {
            get
            {
                return this.sourceSquare_;
            }
        }

        public Square TargetSquare
        {
            get
            {
                return this.targetSquare_;
            }
        }

        public Square StartSquare
        {
            get
            {
                return this.startPointSquare_;
            }
        }

        public Square EndSquare
        {
            get
            {
                if (this.endPointSquare_ != null)
                    return this.endPointSquare_;
                else
                    throw new Exception("This manager has not got a finishing point!");
            }
        }

        public PathManagerCollection SubPathManagers
        {
            get
            {
                return this.subPathManagers_;
            }
        }

        public PathManagerCollection Solutions
        {
            get
            {
                return this.innerSolutions_;
            }
        }

        public void BeginManagePath()
        {
            if (this != null)
                this.FindSolution(this.StartSquare.X, this.StartSquare.Y);
            else
                throw new Exception("Object not implemented yet!");
        }

        public SquareCollection Path
        {
            get
            {
                return this.innerPathSquares_;
            }
        }

        private bool IsOnTheCurrentPath(Square currentSquare)
        {
            bool result = false;

            if (currentSquare.Owners.Count > 0)
            {
                string cname = "";

                cname = this.Name;

                for(int i=0;i<currentSquare.Owners.Count;i++)
                {
                    PathManager tmpPathManager = currentSquare.Owners[i];

                    int k = -1;

                    string tname = "";

                    tname = tmpPathManager.Name;

                    if (cname.Length >= tname.Length)
                    {
                        k = cname.IndexOf(tname);

                        if (k == 0)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        private bool IsSquareAvailable(Square currentSquare)
        {
            bool result = false;

            if(currentSquare.Type == SquareType.SQUARE)
            {
                if (currentSquare.Status == SquareStatus.EMPTY)
                    result = true;
                else
                    result = !IsOnTheCurrentPath(currentSquare);
            }

            return result;
        }

        private SquareCollection FindNeighBourSquares(int row, int column)
        {
            SquareCollection neighBourSquares = new SquareCollection();

            // Check neighbourhood
            try
            {
                if (IsSquareAvailable(this.innerBoard_[row, column - 1])) // left
                    neighBourSquares.Add(this.innerBoard_[row, column - 1]);

                if (IsSquareAvailable(this.innerBoard_[row, column + 1])) // right
                    neighBourSquares.Add(this.innerBoard_[row, column + 1]);

                if (IsSquareAvailable(this.innerBoard_[row - 1, column])) // up
                    neighBourSquares.Add(this.innerBoard_[row - 1, column]);

                if (IsSquareAvailable(this.innerBoard_[row + 1, column])) // down
                    neighBourSquares.Add(this.innerBoard_[row + 1, column]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + row.ToString() + column.ToString());
            }

            return neighBourSquares;
        }

        private void FindSolution(int row, int column)
        {
            SquareCollection neighBours = new SquareCollection();

            SelectSquare(new Square(row, column));

            // increment the cost for this path manager
            this.totalCost_++;

            // look for the neighbour squares
            neighBours = FindNeighBourSquares(row, column);

            // determine what to do about the neighbours
            if (!endManagePath_)
            {
                if (row == this.TargetSquare.X && column == this.TargetSquare.Y)
                {
                    // first check if we have found the solution
                    EndManagePath(new Square(row, column), true);
                }
                else if (neighBours.Count == 0)
                {
                    // no more solution
                    EndManagePath(new Square(row, column), true);
                }
                else if (neighBours.Count == 1)
                {
                    // continue managing the path
                    FindSolution(neighBours[0].X, neighBours[0].Y);
                }
                else if (neighBours.Count > 1)
                {
                    // more than one neighbours found, so end managing process with the current square
                    // then assing new pathmanagers for the rest of the neighbours
                    EndManagePath(new Square(row, column), false);

                    // assign new path managers
                    for (int i = 0; i < neighBours.Count; i++)
                    {
                        // assign this object as parent path for the sub path manager and indicate that sub manager is not root
                        PathManager subPathManager = new PathManager(this, i, new Square(neighBours[i].X, neighBours[i].Y),
                                                                     this.SourceSquare, this.TargetSquare, this.innerBoard_, false);

                        subPathManager.BeginManagePath();

                        // add sub path managers to current manager collections
                        this.subPathManagers_.Add(subPathManager);
                    }
                }
            }
            else
            {
                // this situation is not normal, not expected to happen; even if it happens assume no more solution
                EndManagePath(new Square(row, column), true);
            }
        }

        private void EndManagePath(Square endPointSquare, bool noMoreNeighBour)
        {
            SelectSquare(endPointSquare);

            // if no more solution found then indicate that this is a wrong path
            if (noMoreNeighBour)
            {
                this.endPointSquare_ = endPointSquare;

                if (this.endPointSquare_.X == this.TargetSquare.X && this.endPointSquare_.Y == this.TargetSquare.Y)
                {
                    // we have found the solution
                    this.pathStatus_ = SquarePathStatus.CORRECT;

                    // found the solution
                    this.SolutionFound = true;

                    // also indicate that we have found the solution for parent managers and add it to the solution list
                    PathManager tmpManager = this;

                    while (tmpManager != null)
                    {
                        tmpManager.SolutionFound = true;

                        tmpManager.Solutions.Add(this);

                        tmpManager = tmpManager.ParentPathManager;
                    }
                }
                else
                {
                    // we have not found the solution
                    this.pathStatus_ = SquarePathStatus.WRONG;

                    // found the solution
                    this.SolutionFound = false;
                }
            }

            this.endManagePath_ = true;
        }

        private void SelectSquare(Square currentSquare)
        {
            // indicate that this square is now belongs to this path manager, that is FULL
            this.innerBoard_[currentSquare.X, currentSquare.Y].Status = SquareStatus.FULL;

            // add to current path
            this.innerPathSquares_.Add(currentSquare);

            // indicate that this square is also owned by this manager too
            if (!this.innerBoard_[currentSquare.X, currentSquare.Y].Owners.Contains(this))
                this.innerBoard_[currentSquare.X, currentSquare.Y].Owners.Add(this);
        }

        public int CompareTo(PathManager other)
        {
            return this.TotalCost - other.TotalCost;
        }
    }
}
