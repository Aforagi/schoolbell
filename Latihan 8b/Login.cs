using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Latihan_8b
{
    class Login
    {
        public static void splash()
        {
            

            //splash screen
            string nmapp = "APLIKASI BEL SEKOLAH";
            string dev = "INFORMATIKA 1";
            string ver = " V 1.0 ";

            Media.Tulis(nmapp, (120 - nmapp.Length) / 2, 15);
            Media.Tulis(dev, (120 - dev.Length) / 2, 16);
            Media.Tulis(ver, (120 - ver.Length) / 2, 17);

            //Loading
            for (int ld = 0; ld <= 30; ld++)
            {
                Media.Tulis("▓", 45 + ld, 19, ConsoleColor.Yellow);
                Thread.Sleep(50);
            }
            Console.ResetColor();
            Console.Clear();
        }
        public static void form()
        {
            bool islogin = false;

            while (islogin == false)
            {
                string jdi_login="-=           L O G I N           =-";
                Media.Tulis(jdi_login,(120 - jdi_login.Length)/2,11);

                string lb1="USERNAME";
                string lb2="PASSWORD";
                string textbox = "                              ";

                Media.Tulis(lb1,(120-lb1.Length)/2,14);
                Media.Tulis(lb2,(120-lb2.Length)/2,17);

                Media.Tulis(textbox,(120-textbox.Length)/2,15,ConsoleColor.White,ConsoleColor.White);
                Media.Tulis(textbox,(120-textbox.Length)/2,18,ConsoleColor.White,ConsoleColor.White);

                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(46,15);
                string username = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Black;
                string password = Input_Password(46,18);

                if(username =="vader" && password == "darkside")
                {
                    islogin = true;
                }
                else
                {
                    string error = "Maaf username atau password salah !!!";
                    Media.Tulis(error,(120-error.Length)/2,20,ConsoleColor.Red);

                    string konfirm ="Press Any Key to Loagin Again !!!";
                    Media.Tulis(konfirm,(120-konfirm.Length)/2,22,ConsoleColor.Green);
                    Console.ReadKey();
                }

                Console.ResetColor();
            }
            
        }
        public static string Input_Password(int col = 0, int row = 0)
        {
            var pass = string.Empty;

            ConsoleKey key;
            do
            {
                Console.SetCursorPosition(col, row);
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    col--;
                    Console.SetCursorPosition(col + 1, 15);
                    Console.Write("\b \b");
                    pass = pass.Substring(0, pass.Length - 1);
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    col++;
                    Console.SetCursorPosition(col - 1, row);
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            return pass;
        }
    }
}
