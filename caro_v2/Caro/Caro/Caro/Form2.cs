using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SetLaguage();
            SetColorLV();
            SetColorAudio();
            SetColorLanguage();
        }

        private void btnPlayer_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Show();
        }

        private void btnBoot_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.ShowDialog();
            this.Show();
        }
        private void btnBasic_Click(object sender, EventArgs e)
        {
            GameManager.Instance.level = 0;
            SetColorLV();
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            GameManager.Instance.level = 1;
            SetColorLV();
        }
        

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameManager.Instance.audio = 0;
            SetColorAudio();
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameManager.Instance.audio = 1;
            SetColorAudio();
        }

        private void btnTV_Click(object sender, EventArgs e)
        {
            GameManager.Instance.language = 0;
            SetLaguage();
            SetColorLanguage();
        }

        private void btnTA_Click(object sender, EventArgs e)
        {
            GameManager.Instance.language = 1;
            SetLaguage();
            SetColorLanguage();
        }
        void SetLaguage()
        {
            this.btnPlayer.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f2BtnPlayer, GameManager.Instance.language];
            this.btnBoot.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f2BtnBot, GameManager.Instance.language];
            this.btnMenuLevel.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f2Btnlv, GameManager.Instance.language];
            this.btnBasic.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f2BtnBasic, GameManager.Instance.language];
            this.btnAdvanced.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f2BtnAdvanced, GameManager.Instance.language];
            this.btnAudio.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f2BtnAudio, GameManager.Instance.language];
            this.onToolStripMenuItem.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f2BtnOn, GameManager.Instance.language];
            this.offToolStripMenuItem.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f2BtnOff, GameManager.Instance.language];
            this.btnLanguage.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f2BtnLanguage, GameManager.Instance.language];
            this.btnTV.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f2BtnVN, GameManager.Instance.language];
            this.btnTA.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f2BtnE, GameManager.Instance.language];
        }
        private void SetColorLV()
        {
            if (GameManager.Instance.level == 0)
            {
                this.btnBasic.ForeColor = GameManager.Instance.colorLight;
                this.btnAdvanced.ForeColor = GameManager.Instance.colorDefault;
            }
            else if (GameManager.Instance.level == 1)
            {
                this.btnAdvanced.ForeColor = GameManager.Instance.colorLight;
                this.btnBasic.ForeColor = GameManager.Instance.colorDefault;
            }
        }
        private void SetColorAudio()
        {
            if (GameManager.Instance.audio == 0)
            {
                this.onToolStripMenuItem.ForeColor = GameManager.Instance.colorLight;
                this.offToolStripMenuItem.ForeColor = GameManager.Instance.colorDefault;
            }
            else if (GameManager.Instance.audio == 1)
            {
                this.offToolStripMenuItem.ForeColor = GameManager.Instance.colorLight;
                this.onToolStripMenuItem.ForeColor = GameManager.Instance.colorDefault;
            }
        }
        private void SetColorLanguage()
        {
            if (GameManager.Instance.language == 0)
            {
                this.btnTV.ForeColor = GameManager.Instance.colorLight;
                this.btnTA.ForeColor = GameManager.Instance.colorDefault;
            }
            else if (GameManager.Instance.language == 1)
            {
                this.btnTA.ForeColor = GameManager.Instance.colorLight;
                this.btnTV.ForeColor = GameManager.Instance.colorDefault;
            }
        }
    }
}
