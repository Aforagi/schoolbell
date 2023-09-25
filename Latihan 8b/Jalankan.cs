using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Data;
using System.Threading;

namespace Latihan_8b
{
    class Jalankan
    {
        public static void Do()
        {
            string hari ="";
            do
            {
                Media.Tulis("Masukan Hari :", 28, 7, ConsoleColor.Cyan);
                Console.SetCursorPosition(43, 7);
                hari = Console.ReadLine();
            } while (hari == "");


            Media.bersih(28, 7, 118, 7, ConsoleColor.Black);
            Media.Tulis("Hari       :" + hari.ToUpper(), 28, 7, ConsoleColor.Cyan);
            Media.Tulis("Tanggal    :" + DateTime.Now.ToLongDateString(), 28, 8, ConsoleColor.Cyan);
            Media.Tulis("=================================================================", 28, 10, ConsoleColor.Cyan);

            Database db = new Database();
            bool berhenti = false;
            while (berhenti == false)
            {
                Console.CursorVisible = false;

                Media.Tulis("Jam        :" + DateTime.Now.ToLongTimeString(), 28, 9, ConsoleColor.Cyan);

                string sql = string.Format("SELECT * FROM tb_Jadwal WHERE hari = '{0}' AND jam = #{1}#", hari.ToUpper(), DateTime.Now.ToLongTimeString());
                DataTable rsJadwal = db.GetData(sql);

                if (rsJadwal.Rows.Count > 0)
                {
                    Media.Tulis("Jadwal     :" + rsJadwal.Rows[0]["keterangan"].ToString(), 28, 12, ConsoleColor.Yellow);

                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = rsJadwal.Rows[0]["file"].ToString();
                    player.Play();
                }

                Media.Tulis("BEL SEKOLAH SEDANG DIJALANKAN", 28, 14, ConsoleColor.White);
                for (int kanan = 0; kanan < 89; kanan++)
                {
                    Media.Tulis("▓", 28 + kanan, 16, ConsoleColor.Green);
                    Thread.Sleep(10);
                }
                for (int kiri = 0; kiri < 89; kiri++)
                {
                    Media.Tulis("▓", 117 - kiri, 16, ConsoleColor.Yellow);
                    Thread.Sleep(10);
                }

                if (Console.KeyAvailable == true)
                {
                    ConsoleKeyInfo kb = Console.ReadKey(true);
                    if (kb.Key == ConsoleKey.Backspace)
                    {
                        berhenti = true;
                        Media.bersih(27, 6, 118, 23, ConsoleColor.Black);
                    }
                }
            }
        }        
    }
}
