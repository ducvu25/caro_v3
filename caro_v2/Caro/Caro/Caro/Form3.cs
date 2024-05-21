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
        int BoardSizeM = 15;
        int BoardSizeN = 34;
        int CellSize = 20;
        int LineThickness = 2;
        int Margin2 = 15;

        int[,] board;
        bool isPlayer1Turn;

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

            if (isPlayer1Turn)
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
            board = new int[BoardSizeM, BoardSizeN];
            for (int i = 0; i < BoardSizeM; i++)
            {
                for (int j = 0; j < BoardSizeN; j++)
                {
                    board[i, j] = 0;
                }
            }
            using (Graphics g = panel2.CreateGraphics())
            {
                DrawBoard(g);
            }
            isPlayer1Turn = true;
        }
        private void DrawBoard(Graphics g)
        {
            g.Clear(Color.White);

            // Vẽ các đường ngang và đứng trên bàn cờ
            for (int i = 0; i <= BoardSizeM; i++)
            {
                g.DrawLine(new Pen(Color.Black, LineThickness), Margin2, Margin2 + i * CellSize, Margin2 + BoardSizeN * CellSize, Margin2 + i * CellSize);
            }
            for (int i = 0; i <= BoardSizeN; i++)
            {
                g.DrawLine(new Pen(Color.Black, LineThickness), Margin2 + i * CellSize, Margin2, Margin2 + i * CellSize, Margin2 + BoardSizeM * CellSize);
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
            if (col >= 0 && col < BoardSizeN && row >= 0 && row < BoardSizeM && board[row, col] == 0)
            {
                board[row, col] = isPlayer1Turn ? 1 : 2;
                isPlayer1Turn = !isPlayer1Turn;
                using (Graphics g = panel2.CreateGraphics())
                {
                    if (isPlayer1Turn)
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
                if (CheckWin(row, col))
                {
                    string winner = isPlayer1Turn ? "Player 2" : "Player 1";
                    MessageBox.Show(winner + " has won the game!");
                    InitializeBoard();
                    Invalidate();
                }
            }
        }
        private bool CheckWin(int row, int col)
        {
            int player = isPlayer1Turn ? 1 : 2;

            // Kiểm tra hàng ngang
            int count = 1;
            int i = row;
            int j = col - 1;
            while (j >= 0 && board[i, j] == player)
            {
                count++;
                j--;
            }
            i = row;
            j = col + 1;
            while (j < BoardSizeN && board[i, j] == player)
            {
                count++;
                j++;
            }
            if (count >= 5)
                return true;

            // Kiểm tra hàng dọc
            count = 1;
            i = row - 1;
            j = col;
            while (i >= 0 && board[i, j] == player)
            {
                count++;
                i--;
            }
            i = row + 1;
            j = col;
            while (i < BoardSizeM && board[i, j] == player)
            {
                count++;
                i++;
            }
            if (count >= 5)
                return true;

            // Kiểm tra đường chéo chính (\)
            count = 1;
            i = row - 1;
            j = col - 1;
            while (i >= 0 && j >= 0 && board[i, j] == player)
            {
                count++;
                i--;
                j--;
            }
            i = row + 1;
            j = col + 1;
            while (i < BoardSizeM && j < BoardSizeN && board[i, j] == player)
            {
                count++;
                i++;
                j++;
            }
            if (count >= 5)
                return true;

            // Kiểm tra đường chéo phụ (/)
            count = 1;
            i = row - 1;
            j = col + 1;
            while (i >= 0 && j < BoardSizeN && board[i, j] == player)
            {
                count++;
                i--;
                j++;
            }
            i = row + 1;
            j = col - 1;
            while (i < BoardSizeM && j >= 0 && board[i, j] == player)
            {
                count++;
                i++;
                j--;
            }
            if (count >= 5)
                return true;

            return false;
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
            if (isPlayer1Turn)
                timerPlayer1.Stop();
            else
                timerPlayer2.Stop();
        }
        void continueClick(object sender, EventArgs e)
        {
            GameManager.Instance.PlaySoundEffect(1);
            if (isPlayer1Turn)
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
