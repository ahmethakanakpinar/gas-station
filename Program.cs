using System;
namespace ConsoleApp1
{
    class Program
    {
        public static int[] fiyatlar = { 10, 20, 30 };
        public static int[] depolar = { 50, 60, 40 };
        public static string[] yakit = { "Benzin", "Dizel", "LPG" };
        const int depokac = 100;
        static void Main(string[] args)
        {
            switchkullan();
        }
        static void depodurum()
        {
            string[] pipe = { "", "", "" };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    if (depolar[i] > ((j - 1) * 10) && depolar[i] <= (j * 10))
                    {
                        for (int m = 0; m < j; m++)
                        {
                            pipe[i] = pipe[i] + "|";
                        }
                    }
                    else if (depolar[i] <= (j * 10))
                    {
                        pipe[i] = pipe[i] + " ";
                    }
                }
                Console.Write(yakit[i] + "\t %0 \t" + pipe[i] + "%" + depolar[i] + "\n");
            }
            tekrarlama();
        }
        static void switchkullan()
        {
            Console.Clear();
            Console.WriteLine("1 Satış");
            Console.WriteLine("2 Alış");
            Console.WriteLine("3 Depo Durum");
            Console.WriteLine("4 Çıkış");
            string secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    {
                        yakitlar(0);
                        break;
                    }
                case "2":
                    {
                        yakitlar(1);
                        
                        break;
                    }
                case "3":
                    {
                        depodurum();
                        break;
                    }
                case "4":
                    {
                        Environment.Exit(-1);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Hatalı Giriş Tekrar dene");
                        switchkullan();
                        break;
                    }
            }
        }
        static void yakitlar(int a)
        {

            Console.WriteLine("Benzin");
            Console.WriteLine("Dizel");
            Console.WriteLine("LPG");
            Console.WriteLine("Geri Dönmek için \"0\" a basın");
        comeback:
            string yakit = Console.ReadLine();
            switch (yakit)
            {
                case "0":
                    {
                        switchkullan();
                        break;
                    }
                case "1":
                    {
                        if (a == 1)
                            alis(fiyatlar[0], depolar[0], 0);
                        else if (a == 0)
                            satis(fiyatlar[0], depolar[0], 0);
                        break;
                    }
                case "2":
                    {
                        if (a == 1)
                            alis(fiyatlar[0], depolar[0], 0);
                        else if (a == 0)
                            satis(fiyatlar[0], depolar[0], 0);
                        break;
                    }
                case "3":
                    {
                        if (a == 0)
                            alis(fiyatlar[0], depolar[0], 0);
                        else if (a == 1)
                            satis(fiyatlar[0], depolar[0], 0);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Hatalı Giriş Tekrar dene...:");
                        goto comeback;
                        break;
                    }
            }


        }
        static void alis(int a, int b, int c)
        {
        geri:
            Console.WriteLine("1-Litre Bazında");
            Console.WriteLine("2-Tutar Bazında");
            Console.WriteLine("Geri Dönmek için \"0\" a basın");
            string baz = Console.ReadLine();
            switch (baz)
            {
                case "0":
                    {
                        switchkullan();
                        break;
                    }
                case "1":
                    {
                    dene:
                        Console.WriteLine("Kaç Litre alacaksınız ? Geri Dönmek için \"0\" a basın ");
                        int litre = Convert.ToInt32(Console.ReadLine());
                        if (litre == 0)
                        {
                            goto geri;
                        }
                        else if ((b == 0))
                        {
                            Console.WriteLine("Satın Alamazsınız, Depo Miktari {0} Depo Boş", b);
                            switchkullan();
                        }
                        if (litre <= b)
                        {
                            int satiss = litre * a;
                            b = b - litre;
                            Console.WriteLine("{0} TL tuttu ", satiss);
                            Console.WriteLine("{0} depo kaldı", b);
                            depolar[c] = b;
                            tekrarlama();


                        }
                        else
                        {
                            Console.WriteLine(b + " Litre'den fazla alım yapamazsınız. Almaya çalıştığınız Litre {0}", litre);
                            goto dene;
                        }
                        break;
                    }
                case "2":
                    {
                    dene:
                        Console.WriteLine("Kaç TL'lik alacaksınız ? Geri Dönmek için \"0\" a basın ");
                        int tl = Convert.ToInt32(Console.ReadLine());
                        if (tl <= (b * a))
                        {
                            int satiss = tl / a;
                            b = b - satiss;
                            Console.WriteLine("{0} Litre Satın aldınız", satiss);
                            Console.WriteLine("{0} depo kaldı", b);
                            depolar[c] = b;
                            tekrarlama();


                        }
                        else
                        {
                            Console.WriteLine(b + " Litre'den fazla alım yapamazsınız. Almaya çalıştığınız Litre {0}", b);
                            goto dene;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        static void satis(int a, int b, int c)
        {
        geri:
            Console.WriteLine("1-Litre Bazında");
            Console.WriteLine("2-Tutar Bazında");
            Console.WriteLine("Geri Dönmek için \"0\" a basın");
            string baz = Console.ReadLine();
            switch (baz)
            {
                case "0":
                    {
                        switchkullan();
                        break;
                    }
                case "1":
                    {
                    dene:
                        Console.WriteLine("Kaç Litre Alacaksınız? Geri Dönmek için \"0\" a basın ");
                        int litre = Convert.ToInt32(Console.ReadLine());
                        if (litre == 0)
                        {
                            goto geri;
                        }
                        else if ((b == depokac))
                        {
                            Console.WriteLine("Depo Sınırı {0} Depo Dolu", depokac);
                            switchkullan();
                        }
                        else if ((b + litre) <= 100 && litre <= depokac)
                        {
                            int satiss = litre * a;
                            b = b + litre;
                            Console.WriteLine("{0} TL Ödeme Yapılacaktır. Depoya {1} Litre benzin eklendi", satiss, litre);
                            Console.WriteLine("Depo Durumu {0}", b);
                            depolar[c] = b;
                            tekrarlama();
                        }
                        else
                        {
                            Console.WriteLine(" Depo Sınırı {0} Satmaya çalıştığınız Litre {1}", depokac, litre);
                            goto dene;
                        }
                        break;
                    }
                case "2":
                    {
                    dene:
                        Console.WriteLine("Kaç TL'lik satacaksınız ? Geri Dönmek için \"0\" a basın ");
                        int tl = Convert.ToInt32(Console.ReadLine());
                        if (tl == 0)
                        {
                            goto geri;
                        }
                        else if ((b == depokac))
                        {
                            Console.WriteLine("Depo Sınırı {0} Depo Dolu", depokac);
                            switchkullan();
                        }
                        else if (tl <= (b * a))
                        {
                            int satiss = tl / a;
                            b = b + satiss;
                            Console.WriteLine("{0} TL Ödeme Yapılacaktır. Depoya {1} Litre benzin eklendi", tl, satiss);
                            Console.WriteLine("Depo Durumu {0}", b);
                            depolar[c] = b;
                            tekrarlama();
                        }
                        else
                        {
                            Console.WriteLine("Depo Sınırı {0} Eklemeye çalıştığınız Litre {1}", depokac, (tl / a));
                            Console.WriteLine("Depo Durumu {0}", b);
                            goto dene;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        static void tekrarlama()
        {
            Console.WriteLine("Tekrar İşlem Yapmak istermisiniz = (E,H)");
        tryagain:
            string secim = Console.ReadLine();
            if (secim.ToLower() == "e")
                switchkullan();
            else if (secim.ToLower() == "h")
                Environment.Exit(0);
            else
            {
                Console.WriteLine("E veya H harflerini girin");
                goto tryagain;
            }
        }
    }
}
