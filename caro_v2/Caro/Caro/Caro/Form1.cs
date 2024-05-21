﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetLaguage();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GameManager.Instance.LoadAudio();
            GameManager.Instance.PlayBackgroundMusic();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            GameManager.Instance.PlaySoundEffect(1);
            if (this.itxtName.Text == null || this.itxtName.Text.Length == 0) return;
            GameManager.Instance.namePlayer = this.itxtName.Text.ToString();
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }
        void SetLaguage()
        {
            this.label1.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f1Title, GameManager.Instance.language];
            this.btnStart.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f1Start, GameManager.Instance.language];
        }

    }
}
