namespace Caro
{
    partial class Form4
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContinue = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTimePlayer2 = new System.Windows.Forms.TextBox();
            this.txtTimePlayer1 = new System.Windows.Forms.TextBox();
            this.txtMess = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNamePlayer2 = new System.Windows.Forms.TextBox();
            this.txtNamePlayer1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(-5, 143);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 320);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.txtTimePlayer2);
            this.panel1.Controls.Add(this.txtTimePlayer1);
            this.panel1.Controls.Add(this.txtMess);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txtNamePlayer2);
            this.panel1.Controls.Add(this.txtNamePlayer1);
            this.panel1.Location = new System.Drawing.Point(-5, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 127);
            this.panel1.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.menuStrip1);
            this.panel7.Location = new System.Drawing.Point(676, 6);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(28, 25);
            this.panel7.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(28, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.BackgroundImage = global::Caro.Properties.Resources.menu;
            this.dToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnContinue,
            this.btnQuit});
            this.dToolStripMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10);
            this.dToolStripMenuItem.Size = new System.Drawing.Size(24, 24);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnContinue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.SystemColors.Window;
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(139, 24);
            this.btnContinue.Text = "Tiếp tục";
            this.btnContinue.Click += new System.EventHandler(this.continueClick);
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnQuit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.SystemColors.Window;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(139, 24);
            this.btnQuit.Text = "Thoát";
            this.btnQuit.Click += new System.EventHandler(this.quitClick);
            // 
            // txtTimePlayer2
            // 
            this.txtTimePlayer2.Location = new System.Drawing.Point(528, 89);
            this.txtTimePlayer2.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimePlayer2.Name = "txtTimePlayer2";
            this.txtTimePlayer2.Size = new System.Drawing.Size(76, 20);
            this.txtTimePlayer2.TabIndex = 8;
            this.txtTimePlayer2.Text = "Time";
            this.txtTimePlayer2.ReadOnly = true;
            this.txtTimePlayer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTimePlayer1
            // 
            this.txtTimePlayer1.Location = new System.Drawing.Point(108, 89);
            this.txtTimePlayer1.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimePlayer1.Name = "txtTimePlayer1";
            this.txtTimePlayer1.Size = new System.Drawing.Size(76, 20);
            this.txtTimePlayer1.TabIndex = 7;
            this.txtTimePlayer1.Text = "time";
            this.txtTimePlayer1.ReadOnly = true;
            // 
            // txtMess
            // 
            this.txtMess.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMess.ForeColor = System.Drawing.Color.Red;
            this.txtMess.Location = new System.Drawing.Point(246, 89);
            this.txtMess.Margin = new System.Windows.Forms.Padding(2);
            this.txtMess.Name = "txtMess";
            this.txtMess.Size = new System.Drawing.Size(210, 26);
            this.txtMess.TabIndex = 6;
            this.txtMess.Text = "Good !";
            this.txtMess.ReadOnly = true;
            this.txtMess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = global::Caro.Properties.Resources.avt3;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Location = new System.Drawing.Point(43, 35);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(45, 51);
            this.panel6.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::Caro.Properties.Resources.avt4;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(608, 35);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(50, 51);
            this.panel5.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::Caro.Properties.Resources.o;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(363, 47);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(26, 28);
            this.panel4.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Caro.Properties.Resources.x;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(318, 47);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(24, 27);
            this.panel3.TabIndex = 2;
            // 
            // txtNamePlayer2
            // 
            this.txtNamePlayer2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtNamePlayer2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamePlayer2.ForeColor = System.Drawing.SystemColors.Window;
            this.txtNamePlayer2.Location = new System.Drawing.Point(406, 47);
            this.txtNamePlayer2.Margin = new System.Windows.Forms.Padding(2);
            this.txtNamePlayer2.Name = "txtNamePlayer2";
            this.txtNamePlayer2.Size = new System.Drawing.Size(198, 29);
            this.txtNamePlayer2.TabIndex = 1;
            this.txtNamePlayer2.ReadOnly = true;
            // 
            // txtNamePlayer1
            // 
            this.txtNamePlayer1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.txtNamePlayer1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamePlayer1.ForeColor = System.Drawing.SystemColors.Window;
            this.txtNamePlayer1.Location = new System.Drawing.Point(108, 46);
            this.txtNamePlayer1.Margin = new System.Windows.Forms.Padding(2);
            this.txtNamePlayer1.Name = "txtNamePlayer1";
            this.txtNamePlayer1.Size = new System.Drawing.Size(199, 29);
            this.txtNamePlayer1.TabIndex = 0;
            this.txtNamePlayer2.ReadOnly = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 472);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnContinue;
        private System.Windows.Forms.ToolStripMenuItem btnQuit;
        private System.Windows.Forms.TextBox txtTimePlayer2;
        private System.Windows.Forms.TextBox txtTimePlayer1;
        private System.Windows.Forms.TextBox txtMess;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNamePlayer2;
        private System.Windows.Forms.TextBox txtNamePlayer1;
    }
}