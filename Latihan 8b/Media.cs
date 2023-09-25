using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Latihan_8b
{
    class Media
    {
        public static void Tulis(string Text, int col, int row, ConsoleColor warna = ConsoleColor.White,ConsoleColor bg = ConsoleColor.Black)
        {
            Console.ForegroundColor = warna;
            Console.BackgroundColor = bg;
            Console.SetCursorPosition(col, row);
            Console.WriteLine(Text);
        }
        public static void kotak(int col1, int row1, int col2, int row2, ConsoleColor warna = ConsoleColor.White)
        {
            //cetak garis horizontal
            for (int c = col1; c <= col2; c++)
            {
                Tulis("─", c, row1, warna);
                Tulis("─", c, row2, warna);
            }
            //cetak garis vertikal
            for (int r = row1; r <= row2; r++)
            {
                Tulis("│", col1, r, warna);
                Tulis("│", col2, r, warna);
            }
          
            //cetak siku
            Tulis("┌", col1, row1, warna);      
            Tulis("└", col1, row2, warna);
            Tulis("┐", col2, row1, warna);
            Tulis("┘", col2, row2, warna);

        }
        public static void bersih(int col1, int row1, int col2, int row2, ConsoleColor warna = ConsoleColor.Black)
        {
            for (int c = col1; c <= col2; c++)
            {
                for (int r = row1; r <= row2; r++)
                {
                    Console.BackgroundColor = warna;
                    Console.ForegroundColor = warna;
                    Console.SetCursorPosition(c, r);
                    Console.WriteLine(" ");
                }

            }
        }
        public static void buka(ConsoleColor warna = ConsoleColor.Black)
        {
            for (int b = 0; b <= 59; b++)
            {
                for (int r = 0; r < 29; r++)
                {
                    Media.Tulis("╬", 59 + b, r, warna);
                    Media.Tulis("╬", 60 - b, r, warna);
                }
                Thread.Sleep(10);
            }
        }
        public static void tutup(ConsoleColor warna = ConsoleColor.Black)
        {
            for (int b = 0; b <= 59; b++)
            {
                for (int r = 0; r < 29; r++)
                {
                    Media.Tulis("╬", b, r, warna);
                    Media.Tulis("╬", 119 - b, r, warna);
                }
                Thread.Sleep(10);
            }
        }
        public static void logo(int col, int row, ConsoleColor warna = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
        {
            string[] logo = new string[8];


            logo[0] = "       ░▐█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█▄☆";
            logo[1] = "       ░███████████████████████";
            logo[2] = "       ░▓▓▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓◤";
            logo[3] = "        ╬▀░▐▓▓▓▓▓▓▌▀█░░░█▀░";
            logo[4] = "       ▒░░▓▓▓▓▓▓█▄▄▄▄▄█▀╬░";
            logo[5] = "        ░░█▓▓▓▓▓▌░▒▒▒▒▒▒▒▒▒";
            logo[6] = "        ░▐█▓▓▓▓▓░░▒▒▒▒▒▒▒▒▒";
            logo[7] = "        ░▐██████▌╬░▒▒▒▒▒▒▒▒";

            for (int i = 0; i < logo.Length; i++)
            {
                Tulis(logo[i], (col - logo[i].Length) / 2, row + i, warna, bg);
            }

        }
    }
}
