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
        int timePlayer = 360;
        int timePlayer1;
        int timePlayer2;
        Timer timerPlayer1;
        Timer timerPlayer2;
        int CellSize = 20;
        int LineThickness = 2;
        int Margin2 = 15;


        public Form3()
        {
            InitializeComponent();
            SetLaguage();
            InitializeBoard();
            timePlayer1 = timePlayer;
            timePlayer2 = timePlayer;
            txtTimePlayer1.Text = TimeSpan.FromSeconds(timePlayer1).ToString(@"mm\:ss");
            txtTimePlayer2.Text = TimeSpan.FromSeconds(timePlayer2).ToString(@"mm\:ss");
            // Khởi tạo và cấu hình Timer cho người chơi 1
            timerPlayer1 = new Timer();
            timerPlayer1.Interval = 1000; // Đặt khoảng thời gian là 1 giây
            timerPlayer1.Tick += TimerPlayer1_Tick;

            // Khởi tạo và cấu hình Timer cho người chơi 2
            timerPlayer2 = new Timer();
            timerPlayer2.Interval = 1000; // Đặt khoảng thời gian là 1 giây
            timerPlayer2.Tick += TimerPlayer2_Tick;

            if (GameManager.Instance.isPlayer1)
            {
                timerPlayer1.Start();
                this.txtMess.Text = this.txtNamePlayer1.Text;
            }
            else
            {
                timerPlayer2.Start();
                this.txtMess.Text = this.txtNamePlayer2.Text;
            }
        }
        private void TimerPlayer1_Tick(object sender, EventArgs e)
        {
            timePlayer1--;
            txtTimePlayer1.Text = TimeSpan.FromSeconds(timePlayer1).ToString(@"mm\:ss");

            if (timePlayer1 <= 0)
            {
                timerPlayer1.Stop();
                MessageBox.Show("Player 1 has run out of time!");
                InitializeBoard();
                Invalidate();
            }
        }

        private void TimerPlayer2_Tick(object sender, EventArgs e)
        {
            timePlayer2--;
            txtTimePlayer2.Text = TimeSpan.FromSeconds(timePlayer2).ToString(@"mm\:ss");

            if (timePlayer2 <= 0)
            {
                timerPlayer2.Stop();
                MessageBox.Show("Player 2 has run out of time!");
                InitializeBoard();
                Invalidate();
            }
        }
        private void InitializeBoard()
        {
            GameManager.Instance.NewGame();
            using (Graphics g = panel2.CreateGraphics())
            {
                DrawBoard(g);
            }
            GameManager.Instance.isPlayer1 = true;
        }
        private void DrawBoard(Graphics g)
        {
            g.Clear(Color.White);

            // Vẽ các đường ngang và đứng trên bàn cờ
            for (int i = 0; i <= GameManager.Instance.BoardSizeM; i++)
            {
                g.DrawLine(new Pen(Color.Black, LineThickness), Margin2, Margin2 + i * CellSize, Margin2 + GameManager.Instance.BoardSizeN * CellSize, Margin2 + i * CellSize);
            }
            for (int i = 0; i <= GameManager.Instance.BoardSizeN; i++)
            {
                g.DrawLine(new Pen(Color.Black, LineThickness), Margin2 + i * CellSize, Margin2, Margin2 + i * CellSize, Margin2 + GameManager.Instance.BoardSizeM * CellSize);
            }
        }
        private void DrawPiece(Graphics g, int row, int col, Color color)
        {
            int x = Margin2 + col * CellSize;
            int y = Margin2 + row * CellSize;
            g.FillEllipse(new SolidBrush(color), x + LineThickness, y + LineThickness, CellSize - 2 * LineThickness, CellSize - 2 * LineThickness);
        }
        private void Form3_MouseClick(object sender, MouseEventArgs e)
        {
            GameManager.Instance.PlaySoundEffect(0);
            int col = (e.X - Margin2) / CellSize;
            int row = (e.Y - Margin2) / CellSize;
            if (col >= 0 && col < GameManager.Instance.BoardSizeN && row >= 0 && row < GameManager.Instance.BoardSizeM && GameManager.Instance.board[row, col] == 0)
            {
                GameManager.Instance.board[row, col] = GameManager.Instance.isPlayer1 ? 1 : 2;
                GameManager.Instance.isPlayer1 = !GameManager.Instance.isPlayer1;
                using (Graphics g = panel2.CreateGraphics())
                {
                    if (GameManager.Instance.isPlayer1)
                    {
                        DrawPiece(g, row, col, Color.Red);
                        timerPlayer2.Stop();
                        timerPlayer1.Start();
                        this.txtMess.Text = this.txtNamePlayer1.Text;
                    }
                    else
                    {
                        DrawPiece(g, row, col, Color.Blue);
                        timerPlayer1.Stop();
                        timerPlayer2.Start();
                        this.txtMess.Text = this.txtNamePlayer2.Text;
                    }
                }
                // Kiểm tra kết thúc trò chơi
                if (GameManager.Instance.CheckWin() == 1)
                {
                    string winner = GameManager.Instance.isPlayer1 ? "Player 2" : "Player 1";
                    MessageBox.Show(winner + " has won the game!");
                    InitializeBoard();
                    Invalidate();
                }
            }
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
            GameManager.Instance.PlaySoundEffect(1);
            if (GameManager.Instance.isPlayer1)
                timerPlayer1.Stop();
            else
                timerPlayer2.Stop();
        }
        void continueClick(object sender, EventArgs e)
        {
            GameManager.Instance.PlaySoundEffect(1);
            if (GameManager.Instance.isPlayer1)
                timerPlayer1.Start();
            else
                timerPlayer2.Start();
        }
        void quitClick(object sender, EventArgs e)
        {
            GameManager.Instance.PlaySoundEffect(1);
            this.Close();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
        }
    }
}
