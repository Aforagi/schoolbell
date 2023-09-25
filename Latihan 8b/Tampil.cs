using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Latihan_8b
{
    class Tampil
    {
        public static void Do()
        {
            Media.bersih(27,6,118,8,ConsoleColor.DarkRed);
            Media.Tulis("..:: DATA JADWAL",30,7,ConsoleColor.Yellow,ConsoleColor.DarkRed);

            Database db = new Database();
            DataTable rsjadwal = db.GetData("SELECT * FROM tb_Jadwal");

            Media.Tulis("┌────┬────────┬──────────┬──────────────────────┐", 27, 9, ConsoleColor.Yellow);
            Media.Tulis("│ ID │  HARI  │   JAM    │       KETERANGAN     │", 27, 10, ConsoleColor.Yellow);
            Media.Tulis("├────┼────────┼──────────┼──────────────────────┤", 27, 11, ConsoleColor.Yellow);

            int jumlahdata = 10;
            int hal = 1;
            int pages = (rsjadwal.Rows.Count/jumlahdata)+(rsjadwal.Rows.Count % jumlahdata > 0 ? 1 : 0);

            ConsoleKeyInfo k;

            do
            {
                Media.bersih(27,12,118,22,ConsoleColor.Black);

                int row = 0;
                for(int i = (hal - 1) * jumlahdata;i < (hal*jumlahdata);i++)
                {
                    if(i < rsjadwal.Rows.Count)
                    {
                        Media.Tulis(string.Format("│ {0,-2} │ {1,6} │ {2,7} │ {3,-20} │",rsjadwal.Rows[i]["id_jadwal"].ToString(),rsjadwal.Rows[i]["hari"].ToString(),
                            Convert.ToDateTime(rsjadwal.Rows[i]["jam"].ToString()).ToLongTimeString(),rsjadwal.Rows[i]["keterangan"].ToString()),
                            27,12+row,ConsoleColor.Yellow);
                        row++;
                    }
                }

                Media.Tulis("┴────┴────────┴──────────┴──────────────────────┴", 27, 12 + row, ConsoleColor.Yellow);

                Media.Tulis(string.Format("<< BACK ( Press Left Arrow ) | Halaman ke {0} dari {1} | ( Press Right Arrow ) NEXT >>",hal,pages),28,23,ConsoleColor.White);

                k = Console.ReadKey(true);
                switch(k.Key)
                {
                    case ConsoleKey.RightArrow:
                        hal = hal == pages ? pages : hal + 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        hal = hal == 1 ? 1 : hal - 1;
                        break;
                    case ConsoleKey.Backspace: 

                        Media.bersih(27,6,118,23,ConsoleColor.Black);
                        break;
                }
            } while (k.Key !=ConsoleKey.Backspace);
           
        }

    }
}
