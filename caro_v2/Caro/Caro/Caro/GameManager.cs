using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
