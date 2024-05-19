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
    public partial class Form3 : Form
    {
        int timePlayer1;
        int timePlayer2;
        bool pauseGame;
        public Form3()
        {
            InitializeComponent();
            SetLaguage();
            pauseGame = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        void SetLaguage()
        {
            this.btnContinue.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f3BtnContinue, GameManager.Instance.language];
            this.btnQuit.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f3BtnQuit, GameManager.Instance.language];
            this.txtNamePlayer1.Text = GameManager.Instance.namePlayer;
            this.txtNamePlayer2.Text = "Name player 2";
            this.txtMess.Text = "";
            this.txtTimePlayer1.Text = "";
            this.txtTimePlayer2.Text = "";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            pauseGame = true;
        }
        void continueClick(object sender, EventArgs e)
        {
            pauseGame = false;
        }
        void quitClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
