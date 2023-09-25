using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Latihan_8b
{
    class Hapus
    {
        public static void Do()
        {
            string ulangi = "Y";
            while (ulangi.ToUpper() == "Y")
            {
                 Media.bersih(27,6,118,8,ConsoleColor.DarkRed);
                 Media.Tulis("..:: HAPUS JADWAL",30,7,ConsoleColor.Yellow,ConsoleColor.DarkRed);

                Media.Tulis("Masukan ID Jadwal   :",28,10,ConsoleColor.Cyan);
                Console.SetCursorPosition(50,10);
                int id = int.Parse(Console.ReadLine());

                Database db = new Database();
                DataTable rsJadwal = db.GetData("SELECT * FROM tb_Jadwal WHERE id_jadwal=" + id);

                if (rsJadwal.Rows.Count > 0)
                {
                    Media.Tulis("Hari       :"+rsJadwal.Rows[0]["hari"].ToString(),28,12);
                    Media.Tulis("Jam        :"+Convert.ToDateTime(rsJadwal.Rows[0]["jam"].ToString()).ToLongTimeString(),28,13);
                    Media.Tulis("Keterangan :"+rsJadwal.Rows[0]["keterangan"].ToString(),28,14);
                    Media.Tulis("File       :"+rsJadwal.Rows[0]["file"].ToString(),28,15);

                    Media.Tulis("Apakah data ingin dihapus ? (Y/N)",28,17,ConsoleColor.Magenta);
                    Console.SetCursorPosition(63,17);
                    string jawab = Console.ReadLine();

                    if (jawab.ToUpper() == "Y")
                    {
                        try
                        {
                            Database dbhapus = new Database();
                            dbhapus.Exe("DELETE FROM tb_Jadwal WHERE id_jadwal =" + id);

                            Media.Tulis("Data Terhapus !!!",28,18,ConsoleColor.Green);
                        }
                        catch (Exception err)
                        {
                            Media.Tulis("Data Gagal Terhapus !!!",28,18,ConsoleColor.Red);
                            Media.Tulis(err.Message.ToString(),28,19,ConsoleColor.White);
                        }
                    }
                    else
                    {
                        Media.Tulis("Data Batal di Hapus !!!",28,18,ConsoleColor.Yellow);
                    }
                }
                else
                {
                    Media.Tulis("Maaf Data tidak Ditemukan !!!",28,18,ConsoleColor.Yellow);
                }

                Media.Tulis("Apakah ingin menghapus data kembali ? (Y/N)",28,21,ConsoleColor.Cyan);
                Console.SetCursorPosition(7,21);
                ulangi = Console.ReadLine();

                Media.bersih(27,6,118,23,ConsoleColor.Black);
            }
        }

    }
}
