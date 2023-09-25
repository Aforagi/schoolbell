using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Latihan_8b
{
    class Edit
    {
        public static void Do()
        {
            string ulangi = "Y";
            while (ulangi.ToUpper() == "Y")
            {
                Media.bersih(27, 6, 118, 8, ConsoleColor.DarkRed);
                Media.Tulis("..:: EDIT JADWAL", 30, 7, ConsoleColor.Yellow, ConsoleColor.DarkRed);

                Media.Tulis("Masukan ID Jadwal   :", 28, 10, ConsoleColor.Cyan);
                Console.SetCursorPosition(50, 10);
                int id = int.Parse(Console.ReadLine());

                Database db = new Database();
                DataTable rsJadwal = db.GetData("SELECT * FROM tb_Jadwal WHERE id_jadwal=" + id);

                if (rsJadwal.Rows.Count > 0)
                {
                    Media.Tulis("Hari       :" + rsJadwal.Rows[0]["hari"].ToString(), 28, 12);
                    Media.Tulis("Jam        :" + Convert.ToDateTime(rsJadwal.Rows[0]["jam"].ToString()).ToLongTimeString(), 28, 13);
                    Media.Tulis("Keterangan :" + rsJadwal.Rows[0]["keterangan"].ToString(), 28, 14);
                    Media.Tulis("File       :" + rsJadwal.Rows[0]["file"].ToString(), 28, 15);

                    Media.Tulis(".:: DATA BARU ::.", 28, 17, ConsoleColor.Green);
                    Media.Tulis("Hari       ( Baru ) :", 28, 18, ConsoleColor.DarkGreen);
                    Media.Tulis("Jam        ( Baru ) :", 28, 19, ConsoleColor.DarkGreen);
                    Media.Tulis("Keterangan ( Baru ) :", 28, 20, ConsoleColor.DarkGreen);
                    Media.Tulis("File       ( Baru ) :", 28, 21, ConsoleColor.DarkGreen);

                    Console.SetCursorPosition(51, 18);
                    string Nhari = Console.ReadLine();
                    Console.SetCursorPosition(51, 19);
                    string NJam = Console.ReadLine();
                    Console.SetCursorPosition(51, 20);
                    string Nket = Console.ReadLine();
                    Console.SetCursorPosition(51, 21);
                    string Nfile = Console.ReadLine();

                    Media.Tulis("Apakah data ingin disimpan ? (Y/N)", 28, 22, ConsoleColor.Magenta);
                    Console.SetCursorPosition(64, 22);
                    string jawab = Console.ReadLine();

                    if (jawab.ToUpper() == "Y")
                    {
                        try
                        {
                            string hari = Nhari == "" ? rsJadwal.Rows[0]["hari"].ToString() : Nhari;
                            string jam = NJam == "" ? rsJadwal.Rows[0]["jam"].ToString() : NJam;
                            string ket = Nket == "" ? rsJadwal.Rows[0]["keterangan"].ToString() : Nket;
                            string file = Nfile == "" ? rsJadwal.Rows[0]["file"].ToString() : Nfile;

                            Database dbedit = new Database();
                            string sql = string.Format("UPDATE tb_Jadwal SET hari = '{0}',jam='{1}',keterangan='{2}',file='{3}' WHERE id_jadwal = {4}", hari.ToUpper(), jam, ket, file.Replace("\"",""), id);
                            dbedit.Exe(sql);

                            Media.Tulis("Data Terupdate !!!", 28, 23, ConsoleColor.Green);
                        }
                        catch (Exception err)
                        {
                            Media.Tulis("Data Gagal di Hapus !!! , Error : " + err.Message.ToString(), 28, 23, ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        Media.Tulis("Data Batal di Hapus !!!", 28, 23, ConsoleColor.Red);
                    }
                }
                else
                {
                    Media.Tulis("Maaf data tidak ditemukan !!!", 28, 23, ConsoleColor.Red);
                }

                Media.Tulis("Apakah ingin mengedit data kembali ? (Y/N) ", 28, 24, ConsoleColor.Cyan);
                Console.SetCursorPosition(71, 24);
                ulangi = Console.ReadLine();

                Media.bersih(27, 6, 118, 23, ConsoleColor.Black);

            }
        }       

    }
}
