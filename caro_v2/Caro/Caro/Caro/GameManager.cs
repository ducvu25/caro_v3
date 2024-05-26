
using System;
using System.Drawing;
using System.Media;
using WMPLib;
public enum TITLE_FORM
{
    // f1
    f1Title,
    f1Start,
    // f2
    f2BtnPlayer,
    f2BtnBot,
    f2Btnlv,
    f2BtnBasic,
    f2BtnAdvanced,
    f2BtnAudio,
    f2BtnOn,
    f2BtnOff,
    f2BtnLanguage,
    f2BtnVN,
    f2BtnE,
    // f3
    f3BtnContinue,
    f3BtnQuit,
    // f4
    f4BtnContinue,
    f4BtnQuit
}
namespace Caro
{
    internal class GameManager
    {
        public GameManager() { }
        #region SETTING VALUE
        // value static
        public static GameManager Instance = new GameManager();
        public string namePlayer;
        public int level = 0;
        public int audio = 0;
        public int language = 0;
        // value 
        public Color colorDefault = Color.White;
        public Color colorLight = Color.Yellow;
        #endregion
        // Form1
        public string[,] txtTitle = { 
            // F1
            { "Nhập tên của bạn?", "Enter your name?" },
            { "Bắt đầu", "Start" },
            // F2
            {"Đấu với bạn", "Fight with you"},
            {"Đấu với máy", "Fight against the machine"},
            {"Cấp độ", "Level" },
                {"Dễ", "Basic" },
                {"Khó", "Advanced" },
            {"Âm thanh", "Audio" },
                {"Bật", "On" },
                {"Tắt", "Off" },
            {"Ngôn ngữ", "Language" },
                {"Tiếng Việt", "VietNamese" },
                {"Tiếng Anh", "English" },
            // F3
            {"Tiếp tục", "Contiune" },
            {"Màn hình chính", "Menu" },
            // F4
            {"Tiếp tục", "Contiune" },
            {"Màn hình chính", "Menu" },
        };
        private SoundPlayer backgroundMusic;
        private WindowsMediaPlayer[] soundEffectPlayers = new WindowsMediaPlayer[2];

        public void LoadAudio()
        {
            string path = "C:\\Learn\\caro_v3\\caro_v2\\Caro\\Caro\\Caro\\Resources\\Audio\\";

            // Nạp nhạc nền
            backgroundMusic = new SoundPlayer(path + "a_BG.wav");

            // Nạp hiệu ứng âm thanh
            soundEffectPlayers[0] = new WindowsMediaPlayer();
            soundEffectPlayers[0].URL = path + "a_pop.wav";

            soundEffectPlayers[1] = new WindowsMediaPlayer();
            soundEffectPlayers[1].URL = path + "a_click.wav";
        }
        public void PlayBackgroundMusic()
        {
            backgroundMusic.PlayLooping();
        }
        public void PlaySoundEffect(int index)
        {
            if (audio == 1) return;
            soundEffectPlayers[index].controls.stop();  // Ensure it starts from the beginning
            soundEffectPlayers[index].controls.play();
        }
        public void StopBackgroundMusic()
        {
            backgroundMusic.Stop();
        }


        public long[] TC1 = { 0, 2, 3, 8, 100, 12288, 98304 };
        public long[] PN1 = { 0, 1, 9, 12, 210, 600, 59999 };
        public long[] TC2 = { 0, 3, 5, 81, 2810, 12200, 90304 };
        public long[] PN2 = { 0, 1, 9, 200, 729, 6561, 59999 };

        public int BoardSizeM = 15;
        public int BoardSizeN = 34;
        public int[,] board;
        public bool isPlayer1 = true;
        //List<[,]> stack;

        public void NewGame()
        {
            board = new int[BoardSizeM, BoardSizeN];
            for (int i = 0; i < BoardSizeM; i++)
            {
                for (int j = 0; j < BoardSizeN; j++)
                {
                    board[i, j] = 0;
                }
            }
        }
        public int CheckWin()
        {
            for (int i = 0; i < BoardSizeM; i++)
                for (int j = 0; j < BoardSizeN; j++)
                    if (board[i, j] != 0)
                    {
                        if (i + 4 < BoardSizeM
                                       && board[i, j] == board[i + 1, j]
                                       && board[i, j] == board[i + 2, j]
                                       && board[i, j] == board[i + 3, j]
                                       && board[i, j] == board[i + 4, j]
                            && i >= 0)
                        {
                            return board[i, j];
                        }
                        if (j + 4 < BoardSizeN
                                && board[i, j] == board[i, j + 1]
                                && board[i, j] == board[i, j + 2]
                                && board[i, j] == board[i, j + 3]
                                && board[i, j] == board[i, j + 4]
                            && j >= 0)
                        {
                            return board[i, j];
                        }
                        if (i + 4 < BoardSizeM && j + 4 < BoardSizeN
                            && board[i, j] == board[i + 1, j + 1]
                            && board[i, j] == board[i + 2, j + 2]
                            && board[i, j] == board[i + 3, j + 3]
                            && board[i, j] == board[i + 4, j + 4]
                            && i >= 0 && j >= 0)
                        {
                            return board[i, j];
                        }
                        if (i + 4 < BoardSizeM && j - 4 >= 0
                            && board[i, j] == board[i + 1, j - 1]
                            && board[i, j] == board[i + 2, j - 2]
                            && board[i, j] == board[i + 3, j - 3]
                            && board[i, j] == board[i + 4, j - 4]
                            && i >= 0 && j < BoardSizeN)
                        {
                            return board[i, j];
                        }
                    }
            return 0;
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

        public void Bot(int[,] a, ref int x, ref int y, long[] TC, long[] PN, int player)
        {
            long max = 0;
            for (int i = 0; i < BoardSizeM; i++)
                for (int j = 0; j < BoardSizeN; j++)
                    if (a[i, j] == 0)
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
