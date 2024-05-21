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
        int BoardSizeM = 15;
        int BoardSizeN = 34;
        int CellSize = 20;
        int LineThickness = 2;
        int Margin2 = 15;

        long[] TC1 = { 0, 2, 3, 8, 100, 12288, 98304 };
        long[] PN1 = { 0, 1, 9, 12, 210, 600, 59999 };
        long[] TC2 = { 0, 3, 5, 81, 2810, 12200, 90304 };
        long[] PN2 = { 0, 1, 9, 200, 729, 6561, 59999 };
        int xBot, yBot;
        int[,] board;
        bool luotPlayer = true;

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

            xBot = BoardSizeM / 2;
            yBot = BoardSizeN / 2;

            if (luotPlayer)
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
            luotPlayer = true;
            timerPlayer1.Start();
            timerPlayer2.Stop();
            this.txtMess.Text = this.txtNamePlayer1.Text;
        }
        void BotAttack()
        {
            luotPlayer = false;
            timerPlayer1.Stop();
            timerPlayer2.Start();
            this.txtMess.Text = this.txtNamePlayer2.Text;
            if (GameManager.Instance.level == 0)
                Bot(board, ref xBot, ref yBot, TC1, PN1, 1);
            else
                Bot(board, ref xBot, ref yBot, TC2, PN2, 1);
            board[xBot, yBot] = 2;
            using (Graphics g = panel2.CreateGraphics())
            {
                DrawPiece(g, xBot, yBot, Color.Blue);
            }
            timerPlayer2.Stop();
            if (CheckWin() == 2)
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
            luotPlayer = true;
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
            if (!luotPlayer) return;
            int col = (e.X - Margin2) / CellSize;
            int row = (e.Y - Margin2) / CellSize;
            if (col >= 0 && col < BoardSizeN && row >= 0 && row < BoardSizeM && board[row, col] == 0)
            {
                board[row, col] = 1;
                using (Graphics g = panel2.CreateGraphics())
                {
                    DrawPiece(g, row, col, Color.Red);
                }
                // Kiểm tra kết thúc trò chơi
                if (CheckWin() == 1)
                {
                    MessageBox.Show("YOU WIN!");
                    InitializeBoard();
                    Invalidate();
                }
                BotAttack();
            }
        }
        private int CheckWin()
        {
            char c;
            int d;
            for (int i = 0; i < BoardSizeM; i++)
                for (int j = 0; j < BoardSizeN; j++)
                    if (board[i, j] != 0)
                    {
                        if (i + 5 < BoardSizeM
                                       && board[i, j] == board[i + 1, j]
                                       && board[i, j] == board[i + 2, j]
                                       && board[i, j] == board[i + 3, j]
                                       && board[i, j] == board[i + 4, j]
                            && i - 1 >= 0)
                        {
                            return board[i, j];
                        }
                        if (j + 5 < BoardSizeN
                                && board[i, j] == board[i, j + 1]
                                && board[i, j] == board[i, j + 2]
                                && board[i, j] == board[i, j + 3]
                                && board[i, j] == board[i, j + 4]
                            && j - 1 >= 0)
                        {
                            return board[i, j];
                        }
                        if (i + 5 < BoardSizeM && j + 5 < BoardSizeN
                            && board[i, j] == board[i + 1, j + 1]
                            && board[i, j] == board[i + 2, j + 2]
                            && board[i, j] == board[i + 3, j + 3]
                            && board[i, j] == board[i + 4, j + 4]
                            && i - 1 >= 0 && j - 1 >= 0)
                        {
                            return board[i, j];
                        }
                        if (i + 5 < BoardSizeM && j - 4 >= 0
                            && board[i, j] == board[i + 1, j - 1]
                            && board[i, j] == board[i + 2, j - 2]
                            && board[i, j] == board[i + 3, j - 3]
                            && board[i, j] == board[i + 4, j - 4]
                            && i > 0 && j < BoardSizeN)
                        {
                            return board[i, j];
                        }
                    }
            return 0;
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
            if (luotPlayer)
                timerPlayer1.Stop();
            else
                timerPlayer2.Stop();
        }
        void continueClick(object sender, EventArgs e)
        {
            GameManager.Instance.PlaySoundEffect(1);
            if (luotPlayer)
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

        
        long DiemTC(int x, int y, int[,] a, long[] TC, long[] PN, int u, int v, int player)
        {
            long diemTong = 0;
            int ta = 0, dich = 0;
            if (u == -1 && v == 1)
            {
                for (int i = 1; i < 6 && y + i < BoardSizeN && x - i >= 0; i++)
                    if (a[x - i, y + i] == player)
                    {
                        ta++;
                    }
                    else if (a[x - i, y + i] == -player)
                    {
                        dich++;
                        break;
                    }
                    else break;

                for (int i = 1; i < 6 && x + i < BoardSizeM && y - i >= 0; i++)
                    if (a[x + i, y - i] == player)
                    {
                        ta++;
                    }
                    else if (a[x + i, y - i] == -player)
                    {
                        dich++;
                        break;
                    }
                    else break;
            }
            else
            {
                for (int i = 1; i < 6 && y + v * i < BoardSizeN && x + u * i < BoardSizeM; i++)
                    if (a[x + u * i, y + v * i] == player)
                    {
                        ta++;
                    }
                    else if (a[x + u * i, y + v * i] == -player)
                    {
                        dich++;
                        break;
                    }
                    else break;

                for (int i = 1; i < 6 && y - v * i >= 0 && x - u * i >= 0; i++)
                    if (a[x - u * i, y - v * i] == 1)
                    {
                        ta++;
                    }
                    else if (a[x - u * i, y - v * i] == -1)
                    {
                        dich++;
                        break;
                    }
                    else break;
            }
            if (dich == 2) return 0;
            diemTong -= PN[dich + 1];
            diemTong += TC[ta];
            return diemTong;
        }
        long DiemPN(int x, int y, int[,] a, long[] TC, long[] PN, int u, int v, int player)
        {
            long diemTong = 0;
            int ta = 0, dich = 0;
            if (u == -1 && v == 1)
            {
                for (int i = 1; i < 6 && y + i < BoardSizeN && x - i >= 0; i++)
                    if (a[x - i, y + i] == player)
                    {
                        ta++;
                        break;
                    }
                    else if (a[x - i, y + i] == -player)
                    {
                        dich++;
                    }
                    else break;

                for (int i = 1; i < 6 && y - i >= 0 && x + i < BoardSizeM; i++)
                    if (a[x + i, y - i] == player)
                    {
                        ta++;
                        break;
                    }
                    else if (a[x + i, y - i] == -player)
                    {
                        dich++;
                    }
                    else break;
            }
            else
            {
                for (int i = 1; i < 6 && y + v * i < BoardSizeN && x + u * i < BoardSizeM; i++)
                    if (a[x + u * i, y + v * i] == player)
                    {
                        ta++;
                        break;
                    }
                    else if (a[x + u * i, y + v * i] == -player)
                    {
                        dich++;
                    }
                    else break;

                for (int i = 1; i < 6 && y - v * i >= 0 && x - u * i >= 0; i++)
                    if (a[x - u * i, y - v * i] == player)
                    {
                        ta++;
                        break;
                    }
                    else if (a[x - u * i, y - v * i] == -player)
                    {
                        dich++;
                    }
                    else break;
            }
            if (ta == 2) return 0;
            diemTong += PN[dich];
            return diemTong;
        }

        void Bot(int[,] a, ref int x, ref int y, long[] TC, long[] PN, int player)
        {
            long max = 0;
            for (int i = 0; i < BoardSizeM; i++)
                for (int j = 0; j < BoardSizeN; j++)
                    if (a[i,j] == 0)
                    {
                        long AT = DiemTC(i, j, a, TC, PN, 0, 1, player) + DiemTC(i, j, a, TC, PN, 1, 0, player) + DiemTC(i, j, a, TC, PN, 1, 1, player) + DiemTC(i, j, a, TC, PN, -1, 1, player);
                        long DF = DiemPN(i, j, a, TC, PN, 0, 1, player) + DiemPN(i, j, a, TC, PN, 1, 0, player) + DiemPN(i, j, a, TC, PN, 1, 1, player) + DiemPN(i, j, a, TC, PN, -1, 1, player);
                        long diem = AT > DF ? AT : DF;
                        if (max < diem)
                        {
                            max = diem;
                            x = i;
                            y = j;
                        }
                    }
        }
    }
}
