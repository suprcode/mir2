﻿namespace Server.Account
{
    partial class Namelists
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
            NamelistsGroupBox = new GroupBox();
            NamelistView = new ListView();
            columnHeader1 = new ColumnHeader();
            PlayersGroupBox = new GroupBox();
            NamelistViewBox = new ListView();
            columnHeader2 = new ColumnHeader();
            groupBox1 = new GroupBox();
            FindPlayerBox = new TextBox();
            RefreshButton = new Button();
            NamelistCountLabel = new Label();
            label1 = new Label();
            PlayerActionsGroupBox = new GroupBox();
            NukePlayerButton = new Button();
            AddPlayerButton = new Button();
            DeletePlayerButton = new Button();
            NamelistActionsGroupBox = new GroupBox();
            OpenNameListButton = new Button();
            DeleteNamelistButton = new Button();
            CreateNamelistButton = new Button();
            StatisticsGroupBox = new GroupBox();
            TotalUniquePlayerLabel = new Label();
            TotalPlayerLabel = new Label();
            NamelistCount = new Label();
            NamelistResetGroupBox = new GroupBox();
            ViewResetScript = new Button();
            label2 = new Label();
            NamelistResetCheckBox = new CheckedListBox();
            NamelistsGroupBox.SuspendLayout();
            PlayersGroupBox.SuspendLayout();
            groupBox1.SuspendLayout();
            PlayerActionsGroupBox.SuspendLayout();
            NamelistActionsGroupBox.SuspendLayout();
            StatisticsGroupBox.SuspendLayout();
            NamelistResetGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // NamelistsGroupBox
            // 
            NamelistsGroupBox.Controls.Add(NamelistView);
            NamelistsGroupBox.Location = new Point(12, 12);
            NamelistsGroupBox.Name = "NamelistsGroupBox";
            NamelistsGroupBox.Size = new Size(230, 556);
            NamelistsGroupBox.TabIndex = 0;
            NamelistsGroupBox.TabStop = false;
            NamelistsGroupBox.Text = "Namelists";
            // 
            // NamelistView
            // 
            NamelistView.BorderStyle = BorderStyle.None;
            NamelistView.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            NamelistView.FullRowSelect = true;
            NamelistView.GridLines = true;
            NamelistView.HeaderStyle = ColumnHeaderStyle.None;
            NamelistView.Location = new Point(6, 22);
            NamelistView.MultiSelect = false;
            NamelistView.Name = "NamelistView";
            NamelistView.Size = new Size(215, 526);
            NamelistView.TabIndex = 0;
            NamelistView.UseCompatibleStateImageBehavior = false;
            NamelistView.View = View.Details;
            NamelistView.SelectedIndexChanged += NamelistView_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 215;
            // 
            // PlayersGroupBox
            // 
            PlayersGroupBox.Controls.Add(NamelistViewBox);
            PlayersGroupBox.Location = new Point(248, 12);
            PlayersGroupBox.Name = "PlayersGroupBox";
            PlayersGroupBox.Size = new Size(230, 556);
            PlayersGroupBox.TabIndex = 1;
            PlayersGroupBox.TabStop = false;
            PlayersGroupBox.Text = "Players";
            // 
            // NamelistViewBox
            // 
            NamelistViewBox.BorderStyle = BorderStyle.None;
            NamelistViewBox.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            NamelistViewBox.FullRowSelect = true;
            NamelistViewBox.GridLines = true;
            NamelistViewBox.HeaderStyle = ColumnHeaderStyle.None;
            NamelistViewBox.Location = new Point(6, 22);
            NamelistViewBox.MultiSelect = false;
            NamelistViewBox.Name = "NamelistViewBox";
            NamelistViewBox.Size = new Size(215, 526);
            NamelistViewBox.TabIndex = 1;
            NamelistViewBox.UseCompatibleStateImageBehavior = false;
            NamelistViewBox.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Width = 215;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(FindPlayerBox);
            groupBox1.Controls.Add(RefreshButton);
            groupBox1.Controls.Add(NamelistCountLabel);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(484, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(280, 79);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search";
            // 
            // FindPlayerBox
            // 
            FindPlayerBox.Location = new Point(51, 22);
            FindPlayerBox.Name = "FindPlayerBox";
            FindPlayerBox.Size = new Size(129, 23);
            FindPlayerBox.TabIndex = 9;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(199, 22);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(75, 23);
            RefreshButton.TabIndex = 8;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // NamelistCountLabel
            // 
            NamelistCountLabel.AutoSize = true;
            NamelistCountLabel.Location = new Point(6, 56);
            NamelistCountLabel.Name = "NamelistCountLabel";
            NamelistCountLabel.Size = new Size(121, 15);
            NamelistCountLabel.TabIndex = 7;
            NamelistCountLabel.Text = "Found in: x Namelists";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 6;
            label1.Text = "Player";
            // 
            // PlayerActionsGroupBox
            // 
            PlayerActionsGroupBox.Controls.Add(NukePlayerButton);
            PlayerActionsGroupBox.Controls.Add(AddPlayerButton);
            PlayerActionsGroupBox.Controls.Add(DeletePlayerButton);
            PlayerActionsGroupBox.Location = new Point(484, 92);
            PlayerActionsGroupBox.Name = "PlayerActionsGroupBox";
            PlayerActionsGroupBox.Size = new Size(280, 81);
            PlayerActionsGroupBox.TabIndex = 3;
            PlayerActionsGroupBox.TabStop = false;
            PlayerActionsGroupBox.Text = "Actions - Player";
            // 
            // NukePlayerButton
            // 
            NukePlayerButton.Location = new Point(47, 50);
            NukePlayerButton.Name = "NukePlayerButton";
            NukePlayerButton.Size = new Size(183, 23);
            NukePlayerButton.TabIndex = 8;
            NukePlayerButton.Text = "Delete Player from all Namelists";
            NukePlayerButton.UseVisualStyleBackColor = true;
            NukePlayerButton.Click += NukePlayerButton_Click;
            // 
            // AddPlayerButton
            // 
            AddPlayerButton.Location = new Point(147, 22);
            AddPlayerButton.Name = "AddPlayerButton";
            AddPlayerButton.Size = new Size(100, 23);
            AddPlayerButton.TabIndex = 7;
            AddPlayerButton.Text = "Add Player";
            AddPlayerButton.UseVisualStyleBackColor = true;
            AddPlayerButton.Click += AddPlayerButton_Click;
            // 
            // DeletePlayerButton
            // 
            DeletePlayerButton.Location = new Point(27, 22);
            DeletePlayerButton.Name = "DeletePlayerButton";
            DeletePlayerButton.Size = new Size(100, 23);
            DeletePlayerButton.TabIndex = 6;
            DeletePlayerButton.Text = "Delete Player";
            DeletePlayerButton.UseVisualStyleBackColor = true;
            DeletePlayerButton.Click += DeletePlayerButton_Click;
            // 
            // NamelistActionsGroupBox
            // 
            NamelistActionsGroupBox.Controls.Add(OpenNameListButton);
            NamelistActionsGroupBox.Controls.Add(DeleteNamelistButton);
            NamelistActionsGroupBox.Controls.Add(CreateNamelistButton);
            NamelistActionsGroupBox.Location = new Point(484, 173);
            NamelistActionsGroupBox.Name = "NamelistActionsGroupBox";
            NamelistActionsGroupBox.Size = new Size(280, 83);
            NamelistActionsGroupBox.TabIndex = 4;
            NamelistActionsGroupBox.TabStop = false;
            NamelistActionsGroupBox.Text = "Actions - Namelist";
            // 
            // OpenNameListButton
            // 
            OpenNameListButton.Location = new Point(91, 51);
            OpenNameListButton.Name = "OpenNameListButton";
            OpenNameListButton.Size = new Size(100, 23);
            OpenNameListButton.TabIndex = 10;
            OpenNameListButton.Text = "Open Namelist";
            OpenNameListButton.UseVisualStyleBackColor = true;
            OpenNameListButton.Click += OpenNameListButton_Click;
            // 
            // DeleteNamelistButton
            // 
            DeleteNamelistButton.Location = new Point(147, 22);
            DeleteNamelistButton.Name = "DeleteNamelistButton";
            DeleteNamelistButton.Size = new Size(100, 23);
            DeleteNamelistButton.TabIndex = 9;
            DeleteNamelistButton.Text = "Delete Namelist";
            DeleteNamelistButton.UseVisualStyleBackColor = true;
            DeleteNamelistButton.Click += DeleteNamelistButton_Click;
            // 
            // CreateNamelistButton
            // 
            CreateNamelistButton.Location = new Point(27, 22);
            CreateNamelistButton.Name = "CreateNamelistButton";
            CreateNamelistButton.Size = new Size(100, 23);
            CreateNamelistButton.TabIndex = 8;
            CreateNamelistButton.Text = "Create Namelist";
            CreateNamelistButton.UseVisualStyleBackColor = true;
            CreateNamelistButton.Click += CreateNamelistButton_Click;
            // 
            // StatisticsGroupBox
            // 
            StatisticsGroupBox.Controls.Add(TotalUniquePlayerLabel);
            StatisticsGroupBox.Controls.Add(TotalPlayerLabel);
            StatisticsGroupBox.Controls.Add(NamelistCount);
            StatisticsGroupBox.Location = new Point(484, 258);
            StatisticsGroupBox.Name = "StatisticsGroupBox";
            StatisticsGroupBox.Size = new Size(278, 100);
            StatisticsGroupBox.TabIndex = 5;
            StatisticsGroupBox.TabStop = false;
            StatisticsGroupBox.Text = "Statistics";
            // 
            // TotalUniquePlayerLabel
            // 
            TotalUniquePlayerLabel.AutoSize = true;
            TotalUniquePlayerLabel.Location = new Point(7, 75);
            TotalUniquePlayerLabel.Name = "TotalUniquePlayerLabel";
            TotalUniquePlayerLabel.Size = new Size(216, 15);
            TotalUniquePlayerLabel.TabIndex = 10;
            TotalUniquePlayerLabel.Text = "Total Unique Players: x (In all Namelists)";
            // 
            // TotalPlayerLabel
            // 
            TotalPlayerLabel.AutoSize = true;
            TotalPlayerLabel.Location = new Point(7, 53);
            TotalPlayerLabel.Name = "TotalPlayerLabel";
            TotalPlayerLabel.Size = new Size(175, 15);
            TotalPlayerLabel.TabIndex = 9;
            TotalPlayerLabel.Text = "Total Players: x (In all Namelists)";
            // 
            // NamelistCount
            // 
            NamelistCount.AutoSize = true;
            NamelistCount.Location = new Point(7, 29);
            NamelistCount.Name = "NamelistCount";
            NamelistCount.Size = new Size(102, 15);
            NamelistCount.TabIndex = 8;
            NamelistCount.Text = "Namelist Count: x";
            // 
            // NamelistResetGroupBox
            // 
            NamelistResetGroupBox.Controls.Add(ViewResetScript);
            NamelistResetGroupBox.Controls.Add(label2);
            NamelistResetGroupBox.Controls.Add(NamelistResetCheckBox);
            NamelistResetGroupBox.Location = new Point(484, 359);
            NamelistResetGroupBox.Name = "NamelistResetGroupBox";
            NamelistResetGroupBox.Size = new Size(280, 209);
            NamelistResetGroupBox.TabIndex = 6;
            NamelistResetGroupBox.TabStop = false;
            NamelistResetGroupBox.Text = "Reset";
            // 
            // ViewResetScript
            // 
            ViewResetScript.Location = new Point(82, 183);
            ViewResetScript.Name = "ViewResetScript";
            ViewResetScript.Size = new Size(109, 23);
            ViewResetScript.TabIndex = 2;
            ViewResetScript.Text = "View Reset Script";
            ViewResetScript.UseVisualStyleBackColor = true;
            ViewResetScript.Click += ViewResetScript_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 19);
            label2.Name = "label2";
            label2.Size = new Size(171, 15);
            label2.TabIndex = 1;
            label2.Text = "Choose day/s to reset Namelist";
            // 
            // NamelistResetCheckBox
            // 
            NamelistResetCheckBox.FormattingEnabled = true;
            NamelistResetCheckBox.Items.AddRange(new object[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" });
            NamelistResetCheckBox.Location = new Point(95, 47);
            NamelistResetCheckBox.Name = "NamelistResetCheckBox";
            NamelistResetCheckBox.Size = new Size(87, 130);
            NamelistResetCheckBox.TabIndex = 0;
            NamelistResetCheckBox.ItemCheck += NamelistResetCheckBox_ItemCheck;
            // 
            // Namelists
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 574);
            Controls.Add(NamelistResetGroupBox);
            Controls.Add(StatisticsGroupBox);
            Controls.Add(NamelistActionsGroupBox);
            Controls.Add(PlayerActionsGroupBox);
            Controls.Add(groupBox1);
            Controls.Add(PlayersGroupBox);
            Controls.Add(NamelistsGroupBox);
            Name = "Namelists";
            Text = "Namelists";
            NamelistsGroupBox.ResumeLayout(false);
            PlayersGroupBox.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            PlayerActionsGroupBox.ResumeLayout(false);
            NamelistActionsGroupBox.ResumeLayout(false);
            StatisticsGroupBox.ResumeLayout(false);
            StatisticsGroupBox.PerformLayout();
            NamelistResetGroupBox.ResumeLayout(false);
            NamelistResetGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox NamelistsGroupBox;
        private GroupBox PlayersGroupBox;
        private GroupBox groupBox1;
        private GroupBox PlayerActionsGroupBox;
        private GroupBox NamelistActionsGroupBox;
        private ListView NamelistView;
        private ListView NamelistViewBox;
        private Label NamelistCountLabel;
        private Label label1;
        private GroupBox StatisticsGroupBox;
        private Label TotalUniquePlayerLabel;
        private Label TotalPlayerLabel;
        private Label NamelistCount;
        private Button DeletePlayerButton;
        private TextBox FindPlayerBox;
        private Button RefreshButton;
        private Button AddPlayerButton;
        private Button DeleteNamelistButton;
        private Button CreateNamelistButton;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private GroupBox NamelistResetGroupBox;
        private CheckedListBox NamelistResetCheckBox;
        private Label label2;
        private Button ViewResetScript;
        private Button OpenNameListButton;
        private Button NukePlayerButton;
    }
}