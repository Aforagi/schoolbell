using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Latihan_8b
{
    class Tambah
    {
        public static void Do()
        {
            string ulang = "Y";
            while (ulang.ToUpper() == "Y")
            {
                Media.bersih(27, 6, 118, 8, ConsoleColor.DarkRed);
                Media.Tulis(".:: TAMBAH JADWAL", 28, 7, ConsoleColor.Yellow, ConsoleColor.DarkRed);

                Media.Tulis("HARI               :", 28, 10, ConsoleColor.Yellow);
                Media.Tulis("JAM                :", 28, 12, ConsoleColor.Yellow);
                Media.Tulis("KETERANG           :", 28, 14, ConsoleColor.Yellow);
                Media.Tulis("FILE               :", 28, 16, ConsoleColor.Yellow);

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(49, 10);
                string hari = Console.ReadLine();
                Console.SetCursorPosition(49, 12);
                string jam = Console.ReadLine();
                Console.SetCursorPosition(49, 14);
                string ket = Console.ReadLine();
                Console.SetCursorPosition(49, 16);
                string file = Console.ReadLine();

                Media.Tulis("Apakah data ingin disimpan ? (Y/N) ", 28, 18, ConsoleColor.Magenta);
                Console.SetCursorPosition(63, 18);
                string jawab = Console.ReadLine();

                if (jawab.ToUpper() == "Y")
                {
                    try
                    {
                        Database db = new Database();
                        string sql = string.Format("INSERT INTO tb_Jadwal(hari,jam,keterangan,file) VALUES('{0}','{1}','{2}','{3}')", hari.ToUpper(), jam, ket, file.Replace("\"",""));
                        db.Exe(sql);

                        Media.Tulis("Data Disimpan!!!", 28, 19, ConsoleColor.Green);
                    }
                    catch (Exception err)
                    {
                        Media.Tulis("Data Gagal Disimpan!!!", 28, 19, ConsoleColor.Red);
                        Media.Tulis(err.Message.ToString(), 28, 20, ConsoleColor.White);
                    }
                }
                else
                {
                    Media.Tulis("Data Batal Disimpan!!!", 28, 19, ConsoleColor.Red);
                }

                Media.Tulis("Apakah ingin mengisi data kembali ? (Y/N) ", 28, 22, ConsoleColor.Cyan);
                Console.SetCursorPosition(70, 22);
                ulang = Console.ReadLine();

                Media.bersih(27, 6, 118, 23, ConsoleColor.Black);
            }
        }
    }
}
