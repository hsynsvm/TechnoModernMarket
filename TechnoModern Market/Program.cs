using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoModernMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] urunler = { "Domates ","Biber ","Badılcan ","Yumurta ","Ekmek ","Doritos "," Kola " };
            double[] fiyatlar = { 29.90, 33.40, 24.10, 3.20, 7, 40, 45 };
            double[] kdv = {1,2,3,4,0.25,2,3 };
            string[] ölcüBirimleri = { " KG ", " KG ", " KG ","ADET","ADET","ADET","ADET"};
            string[] kartlar = { "1", "2", "3", "4", "5" };
            string[] urunisim = new string[urunler.Length];
            double[] urunkdvsiz = new double[urunler.Length];
            double[] urunkdvli = new double[urunler.Length];
            int kalemadedi = 0;
            double kdvlitoplam = 0;
            double kdvsiztoplam = 0;
            double toplam = 0;
            

            Console.WriteLine("*******TechnoModern'e Hoşgeldiniz*******");
            Console.WriteLine("\nLütfen Kullanıcı Adınızı ve Şifrenizi Giriniz");
            int hak = 3;
            
            while (true)
            {
                
                string kullaniciAdi = Console.ReadLine();
                Console.WriteLine("\nKullanıcı Adı: " + kullaniciAdi);
                Console.WriteLine("\nLütfen Şifrenizi Giriniz");
                string sifre = Console.ReadLine();

                if (kullaniciAdi == "admin" && sifre =="1234")
                {
                    Console.WriteLine("\nTebrikler başarılı bir şekilde giriş yaptınız");
                    Console.WriteLine("\n Hoşgeldiniz Sayın " + kullaniciAdi);
                    break;
                }
                else
                {
                    Console.WriteLine("Kullanıcı adınız veya şifreniz yanlış");
                    Console.Beep(1000, 500);
                    Console.WriteLine("\nKalan hakkınız: " + hak);

                    if (hak >0)
                    {
                        hak -= 1; // 1 azaltma yapacağız hakkı
                    }
                    if(hak ==0)
                    {
                        Console.WriteLine("Hakkınız dolmuştur giriş yapamazsınız");
                        Console.Beep(1000,600);
                    }
                }
            }

            Console.WriteLine("\n*******ÜRÜNLERİMİZ*******");
            for (int i = 0;i < urunler.Length; i++)
            {
                Console.WriteLine($"\n{(i +1)} {urunler[i]} \t{fiyatlar[i]} TL");
            }


            string secenek = "e";
            while (secenek == "e")
            {
                double aratoplam = 0;
                Console.WriteLine("\nLütfen Ürün Numarasını Seçiniz: \t");
                int secim = Convert.ToInt32(Console.ReadLine());

                Console.Write($"{urunler[secim - 1]} ürününden kaç {ölcüBirimleri[secim - 1]} almak istiyorsunuz? = \t");
                double miktar = Convert.ToDouble(Console.ReadLine());

                toplam = fiyatlar[secim - 1] * miktar;


                for (int i = 0; i < miktar; i++)
                {
                    aratoplam += fiyatlar[secim - 1];
                }
                urunisim[kalemadedi] = urunler[secim - 1];
                urunkdvsiz[kalemadedi] += aratoplam;
                urunkdvli[kalemadedi] = aratoplam + (aratoplam * ((kdv[secim - 1]))) / 100;

                Console.WriteLine($"Bu ürüne % {kdv[secim - 1]} KDV uygulanmıştır");
                Console.WriteLine($"{urunisim[kalemadedi]} için KDV'siz ödemeniz =       \t {urunkdvsiz[kalemadedi]} TL");
                Console.WriteLine($"{urunisim[kalemadedi]} için KDV'li toplam ödemeniz = \t {urunkdvli[kalemadedi]} TL\n");
                kalemadedi++;

                Console.WriteLine("Alışverişe devam edilsin mi? : e/h");
                secenek = Console.ReadLine();
            }
            for (int i = 0; i < kalemadedi; i++)
            {
                kdvlitoplam += urunkdvli[i];
                kdvsiztoplam += urunkdvsiz[i];
            }

            Console.WriteLine("\n******Ödeme Adımına Hoşgeldiniz******");
            
            Console.WriteLine("\n TechnoModern Karta Sahipseniz Lütfen Kart Numaranızı Giriniz Yoksa 0'a basınız");

            string kartNo = Console.ReadLine();
            double indirim = kdvlitoplam - 0.5;
            
            for (int i = 0; i < kartNo.Length; i++)
            {
                if (kartlar[i] == kartNo)
                {
                    Console.WriteLine("Toplam tutar: " + toplam + "TL" +"\tKdv'li toplam tutar: " + kdvlitoplam + " TL "+ "\tTechnoModern kart indirimi %5 = " + indirim + " Genel Toplam: " + indirim+ " TL ");
                }
                else
                {
                    Console.WriteLine("Toplam tutar: " + kdvsiztoplam + "TL" + "\tKdv'li toplam tutar: " + kdvlitoplam + "TL");
                }
            }
            Console.WriteLine("******Tekrar Görüşmek Dileklerimizle İyi Günler Dileriz********");
        }
        
    }
}
