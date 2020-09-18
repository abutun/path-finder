namespace PathFinder
{
    partial class PathFinder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resetButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.findSolutionRadio = new System.Windows.Forms.RadioButton();
            this.drawWallRadio = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.boardSizeDropDown = new System.Windows.Forms.NumericUpDown();
            this.setBoardSizeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.board = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.webSiteLink = new System.Windows.Forms.LinkLabel();
            this.pathListView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.solutionListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.totalTime = new System.Windows.Forms.Label();
            this.grpAction.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boardSizeDropDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            this.SuspendLayout();
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(848, 32);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(60, 23);
            this.resetButton.TabIndex = 14;
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(642, 120);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(190, 23);
            this.statusLabel.TabIndex = 13;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.findSolutionRadio);
            this.grpAction.Controls.Add(this.drawWallRadio);
            this.grpAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpAction.Location = new System.Drawing.Point(737, 28);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(95, 89);
            this.grpAction.TabIndex = 12;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Actions";
            // 
            // findSolutionRadio
            // 
            this.findSolutionRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.findSolutionRadio.Location = new System.Drawing.Point(6, 54);
            this.findSolutionRadio.Name = "findSolutionRadio";
            this.findSolutionRadio.Size = new System.Drawing.Size(83, 24);
            this.findSolutionRadio.TabIndex = 1;
            this.findSolutionRadio.Text = "Find Path";
            this.findSolutionRadio.CheckedChanged += new System.EventHandler(this.findSolutionButton_CheckedChanged);
            // 
            // drawWallRadio
            // 
            this.drawWallRadio.Checked = true;
            this.drawWallRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.drawWallRadio.Location = new System.Drawing.Point(6, 24);
            this.drawWallRadio.Name = "drawWallRadio";
            this.drawWallRadio.Size = new System.Drawing.Size(83, 24);
            this.drawWallRadio.TabIndex = 0;
            this.drawWallRadio.TabStop = true;
            this.drawWallRadio.Text = "Draw Wall";
            this.drawWallRadio.CheckedChanged += new System.EventHandler(this.drawWallButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.boardSizeDropDown);
            this.groupBox2.Controls.Add(this.setBoardSizeButton);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(639, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 88);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dimension";
            // 
            // boardSizeDropDown
            // 
            this.boardSizeDropDown.Location = new System.Drawing.Point(6, 23);
            this.boardSizeDropDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.boardSizeDropDown.Name = "boardSizeDropDown";
            this.boardSizeDropDown.Size = new System.Drawing.Size(72, 20);
            this.boardSizeDropDown.TabIndex = 3;
            this.boardSizeDropDown.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // setBoardSizeButton
            // 
            this.setBoardSizeButton.Location = new System.Drawing.Point(6, 54);
            this.setBoardSizeButton.Name = "setBoardSizeButton";
            this.setBoardSizeButton.Size = new System.Drawing.Size(75, 23);
            this.setBoardSizeButton.TabIndex = 2;
            this.setBoardSizeButton.Text = "Set Size";
            this.setBoardSizeButton.Click += new System.EventHandler(this.setBoardSizeButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.board);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(24, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 600);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maze";
            // 
            // board
            // 
            this.board.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.board.Location = new System.Drawing.Point(8, 16);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(576, 576);
            this.board.TabIndex = 0;
            this.board.TabStop = false;
            this.board.MouseDown += new System.Windows.Forms.MouseEventHandler(this.board_MouseDown);
            this.board.MouseMove += new System.Windows.Forms.MouseEventHandler(this.board_MouseMove);
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.board_Paint);
            this.board.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.board_MouseDoubleClick);
            this.board.MouseUp += new System.Windows.Forms.MouseEventHandler(this.board_MouseUp);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(848, 93);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(60, 23);
            this.exitButton.TabIndex = 11;
            this.exitButton.Text = "Exit";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // webSiteLink
            // 
            this.webSiteLink.AutoSize = true;
            this.webSiteLink.Location = new System.Drawing.Point(245, 631);
            this.webSiteLink.Name = "webSiteLink";
            this.webSiteLink.Size = new System.Drawing.Size(108, 13);
            this.webSiteLink.TabIndex = 15;
            this.webSiteLink.TabStop = true;
            this.webSiteLink.Text = "www.ahmetbutun.net";
            this.webSiteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.webSiteLink_LinkClicked);
            // 
            // pathListView
            // 
            this.pathListView.Location = new System.Drawing.Point(639, 171);
            this.pathListView.Name = "pathListView";
            this.pathListView.Size = new System.Drawing.Size(293, 345);
            this.pathListView.TabIndex = 16;
            this.pathListView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.pathListView_NodeMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(636, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Path Analysis";
            // 
            // solutionListBox
            // 
            this.solutionListBox.DisplayMember = "TotalCost";
            this.solutionListBox.FormattingEnabled = true;
            this.solutionListBox.Location = new System.Drawing.Point(639, 543);
            this.solutionListBox.Name = "solutionListBox";
            this.solutionListBox.Size = new System.Drawing.Size(193, 82);
            this.solutionListBox.TabIndex = 18;
            this.solutionListBox.SelectedIndexChanged += new System.EventHandler(this.solutionListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(636, 527);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Solutions";
            // 
            // totalTime
            // 
            this.totalTime.AutoSize = true;
            this.totalTime.Location = new System.Drawing.Point(847, 543);
            this.totalTime.Name = "totalTime";
            this.totalTime.Size = new System.Drawing.Size(0, 13);
            this.totalTime.TabIndex = 21;
            // 
            // PathFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 653);
            this.Controls.Add(this.totalTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.solutionListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathListView);
            this.Controls.Add(this.webSiteLink);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exitButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PathFinder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shortest Path Finder - www.ahmetbutun.net";
            this.Load += new System.EventHandler(this.MazeSolver_Load);
            this.grpAction.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.boardSizeDropDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.RadioButton findSolutionRadio;
        private System.Windows.Forms.RadioButton drawWallRadio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown boardSizeDropDown;
        private System.Windows.Forms.Button setBoardSizeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox board;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.LinkLabel webSiteLink;
        private System.Windows.Forms.TreeView pathListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox solutionListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalTime;
    }
}

