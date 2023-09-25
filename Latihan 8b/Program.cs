using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latihan_8b
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Aplikasi Bel Sekolah V 1.0 -IK1";

            //splash & login
            Login.splash();
            Login.form();

            //animasi buka tutup
            Media.tutup(ConsoleColor.DarkBlue);
            Media.buka();

            //Judul 
            string judul = "╬ APLIKASI BEL SEKOLAH ╬";
            string vendor = "Wearness Education Center";
            string alamat = "Jalan Thamrin 35 A Madiun";
            Media.kotak(0, 0, 119, 4, ConsoleColor.Cyan);
            Media.Tulis(judul, ((120 - judul.Length) / 2), 1, ConsoleColor.Magenta);
            Media.Tulis(vendor, ((120 - vendor.Length) / 2), 2, ConsoleColor.Yellow);
            Media.Tulis(alamat, ((120 - alamat.Length) / 2), 3, ConsoleColor.Yellow);

            //Menu
            Media.kotak(0, 5, 25, 25, ConsoleColor.Cyan);
            Media.kotak(1, 6, 24, 8, ConsoleColor.Cyan);
            Media.Tulis("        M E N U       ", 2, 7, ConsoleColor.Black, ConsoleColor.DarkGray);

            //content, 
            Media.kotak(26, 5, 119, 25, ConsoleColor.Cyan);
            Media.bersih(27, 6, 118, 24, ConsoleColor.Cyan);
            Media.logo(146, 11, ConsoleColor.Black, ConsoleColor.Cyan);

            //footer
            string dev = "INFORMATIKA 1 - 2020 /2021";
            Media.kotak(0, 26, 119, 28, ConsoleColor.Cyan);
            Media.Tulis(dev, ((120-dev.Length)/2),27,ConsoleColor.Green);

            //Menu sorot
            int pil = 0;
            string[] menu = new string[6];

            menu[0] = "       TAMBAH      ";
            menu[1] = "        EDIT       ";
            menu[2] = "       HAPUS       ";
            menu[3] = "       TAMPIL      ";
            menu[4] = "      JALANKAN     ";
            menu[5] = "       KELUAR      ";

            //Cetak menu
            for (int i = 0; i < menu.Length; i++)
            {
                Media.Tulis(menu[1], 3, 10 + i, ConsoleColor.Yellow);
            }
            
            //Set menu aktif
            Media.Tulis("»" + menu[pil].Substring(1, menu[pil].Length - 2) + "«", 3, 10 + pil, ConsoleColor.White, ConsoleColor.DarkBlue);
            
            //Set sorot
            bool keluar = false;
            while(keluar == false)
            {
                Console.CursorVisible = false;

                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyb = Console.ReadKey(true);
                    switch(keyb.Key)
                    {
                        case ConsoleKey.DownArrow:
                            Media.Tulis(menu[pil],3,10 + pil,ConsoleColor.Yellow);
                            pil++;
                            if (pil == 6) {pil = 5;}
                            Media.Tulis("»" + menu[pil].Substring(1, menu[pil].Length - 2) + "«", 3, 10 + pil, ConsoleColor.White, ConsoleColor.DarkBlue);
                            break;
                        case ConsoleKey.UpArrow:
                            Media.Tulis(menu[pil],3,10 + pil,ConsoleColor.Yellow);
                            pil--;
                            if (pil == -1) { pil = 0;}
                            Media.Tulis("»" + menu[pil].Substring(1, menu[pil].Length - 2) + "«", 3, 10 + pil, ConsoleColor.White, ConsoleColor.DarkBlue);
                            break;
                        case ConsoleKey.Enter:

                            Media.bersih(27,6,118,24,ConsoleColor.Black);

                            switch (pil)
                            {
                                case 0:
                                    Console.CursorVisible = true;
                                    Tambah.Do();
                                    break;
                                case 1:
                                    Console.CursorVisible = true;
                                    Edit.Do();
                                    break;
                                case 2:
                                    Console.CursorVisible = true;
                                    Hapus.Do();
                                    break;
                                case 3:
                                    Console.CursorVisible = true;
                                    Tampil.Do();
                                    break;
                                case 4:
                                    Console.CursorVisible = true;
                                    Jalankan.Do();
                                    break;
                                case 5:
                                    keluar = true;
                                    break;
                            }

                            Media.bersih(27, 6, 118, 24, ConsoleColor.Cyan);
                            Media.logo(146, 11, ConsoleColor.DarkBlue, ConsoleColor.Cyan);
                                    
                            break;
                    }
                }
            }
          
        }
    }
}
