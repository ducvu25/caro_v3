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
    public partial class Form4 : Form
    {
        int timePlayer1;
        int timePlayer2;
        bool pauseGame;
        public Form4()
        {
            InitializeComponent();
            SetLaguage();
            pauseGame = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        void SetLaguage()
        {
            this.btnContinue.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f4BtnContinue, GameManager.Instance.language];
            this.btnQuit.Text = GameManager.Instance.txtTitle[(int)TITLE_FORM.f4BtnQuit, GameManager.Instance.language];
            this.txtNamePlayer1.Text = GameManager.Instance.namePlayer;
            Random random = new Random();
            this.txtNamePlayer2.Text = random.Next(0, 2) < 1 ? "Ducvu25" : "Thuy Linh";
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

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
