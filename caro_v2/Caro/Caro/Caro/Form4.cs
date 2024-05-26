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
        int timePlayer = 360;
        int timePlayer1;
        int timePlayer2;
        Timer timerPlayer1;
        Timer timerPlayer2;
        
        int CellSize = 20;
        int LineThickness = 2;
        int Margin2 = 15;

        int xBot, yBot;
        
        

        public Form4()
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

            xBot = GameManager.Instance.BoardSizeM / 2;
            yBot = GameManager.Instance.BoardSizeN / 2;

            if (GameManager.Instance.isPlayer1)
            {
                PlayerAttack();
            }
            else
            {
                BotAttack();
            }
        }
        void PlayerAttack()
        {
            GameManager.Instance.isPlayer1 = true;
            timerPlayer1.Start();
            timerPlayer2.Stop();
            this.txtMess.Text = this.txtNamePlayer1.Text;
        }
        void BotAttack()
        {
            GameManager.Instance.isPlayer1 = false;
            timerPlayer1.Stop();
            timerPlayer2.Start();
            this.txtMess.Text = this.txtNamePlayer2.Text;
            if (GameManager.Instance.level == 0)
                GameManager.Instance.Bot(GameManager.Instance.board, ref xBot, ref yBot, GameManager.Instance.TC1, GameManager.Instance.PN1, 1);
            else
                GameManager.Instance.Bot(GameManager.Instance.board, ref xBot, ref yBot, GameManager.Instance.TC2, GameManager.Instance.PN2, 1);
            GameManager.Instance.board[xBot, yBot] = 2;
            using (Graphics g = panel2.CreateGraphics())
            {
                DrawPiece(g, xBot, yBot, Color.Blue);
            }
            timerPlayer2.Stop();
            if (GameManager.Instance.CheckWin() == 2)
            {
                string winner = "YOU LOSS";
                MessageBox.Show(winner);
                InitializeBoard();
                Invalidate();
            }else
                PlayerAttack();
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
            
            using (Graphics g = panel2.CreateGraphics())
            {
                DrawBoard(g);
            }
            GameManager.Instance.isPlayer1 = true;
            GameManager.Instance.NewGame();
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
            if (!GameManager.Instance.isPlayer1) return;
            int col = (e.X - Margin2) / CellSize;
            int row = (e.Y - Margin2) / CellSize;
            if (col >= 0 && col < GameManager.Instance.BoardSizeN && row >= 0 && row < GameManager.Instance.BoardSizeM && GameManager.Instance.board[row, col] == 0)
            {
                GameManager.Instance.board[row, col] = 1;
                using (Graphics g = panel2.CreateGraphics())
                {
                    DrawPiece(g, row, col, Color.Red);
                }
                // Kiểm tra kết thúc trò chơi
                if (GameManager.Instance.CheckWin() == 1)
                {
                    MessageBox.Show("YOU WIN!");
                    InitializeBoard();
                    Invalidate();
                }
                BotAttack();
            }
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
