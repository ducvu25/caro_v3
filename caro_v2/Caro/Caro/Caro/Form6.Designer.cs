namespace Caro
{
    partial class Form6
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.continute_lose = new System.Windows.Forms.Button();
            this.exit_lose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Caro.Properties.Resources.lose;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.exit_lose);
            this.panel1.Controls.Add(this.continute_lose);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 518);
            this.panel1.TabIndex = 0;
            // 
            // continute_lose
            // 
            this.continute_lose.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continute_lose.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.continute_lose.Location = new System.Drawing.Point(55, 349);
            this.continute_lose.Name = "continute_lose";
            this.continute_lose.Size = new System.Drawing.Size(207, 50);
            this.continute_lose.TabIndex = 0;
            this.continute_lose.Text = "Chơi lại";
            this.continute_lose.UseVisualStyleBackColor = true;
            // 
            // exit_lose
            // 
            this.exit_lose.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_lose.ForeColor = System.Drawing.Color.Gold;
            this.exit_lose.Location = new System.Drawing.Point(292, 349);
            this.exit_lose.Name = "exit_lose";
            this.exit_lose.Size = new System.Drawing.Size(207, 50);
            this.exit_lose.TabIndex = 1;
            this.exit_lose.Text = "Thoát";
            this.exit_lose.UseVisualStyleBackColor = true;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 523);
            this.Controls.Add(this.panel1);
            this.Name = "Form6";
            this.Text = "Form6";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exit_lose;
        private System.Windows.Forms.Button continute_lose;
    }
}