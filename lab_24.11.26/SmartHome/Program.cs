namespace SmartHome;

public enum CihazTuru
{
    Lamba,
    Klima,
    GuvenlikSistemi
}

public class Cihaz
{
    public string kimlik {get; private set;}
    public string ad {get; private set;}
    public CihazTuru cihazTuru {get; private set;}
    public bool AcikMi {get; private set;}

    public Cihaz(string kimlik, string ad, CihazTuru cihazTuru)
    {
        this.kimlik = kimlik;
        this.ad = ad;
        this.cihazTuru = cihazTuru;
        this.AcikMi = false;
    }
    public void Ac()
    {
        if(this.AcikMi == false)
        {
            AcikMi = true;
            Console.WriteLine("Cihaz açıldı");
        }
        else
        {
            Console.WriteLine("Açık olan bir cihazı açamazsınız");
        }
    }

    public void Kapat()
    {
        
        if(this.AcikMi == true)
        {
            AcikMi = true;
            Console.WriteLine("Cihaz kapatıldı");
        }
        else
        {
            Console.WriteLine("kapalı olan bir cihazı kapatamazsınız");
        }
    }

    public void BilgileriGoster()
    {
        Console.WriteLine("Cihaz Bilgileri :\n\n");
        Console.WriteLine($"Kmlik : {kimlik}");
        Console.WriteLine($"Ad : {ad}");
        Console.WriteLine($"Tür : {cihazTuru}");
        string durum = this.AcikMi ? "Açık": "Kapalı";
        Console.WriteLine($"Durum : {durum}");

    }
}


class Program
{
    static List<Cihaz> cihaz_listesi = new List<Cihaz>();
    static void MenuDisplay()
    {
        Console.WriteLine("");
        Console.WriteLine("1 - Cihazları listele");
        Console.WriteLine("2 - Cihaz ekle");
        Console.WriteLine("3 - Cihaz aç");
        Console.WriteLine("4 - Cihaz kapat");
        Console.WriteLine("5 - Menüden çık");
        Console.WriteLine("");
    }


    static void CihazEkle(string kimlik, string ad, CihazTuru cihazTuru)
    {
        if(CihazListedeMi(kimlik))throw new ArgumentException("Farklı bir kimlik numarası girilmeli");

        if(string.IsNullOrWhiteSpace(kimlik) || string.IsNullOrWhiteSpace(ad))
        {
            throw new ArgumentException("Geçerli bilgi girmelisiniz");
        }
        
        Program.cihaz_listesi.Add(new Cihaz(kimlik,ad,cihazTuru));
        Console.WriteLine("Cihaz eklendi");
    }

    static void CihazListesiGoster()
    {
        if(Program.cihaz_listesi.Count == 0)
        {
            Console.WriteLine("Liste boş");
            return;
        }
        foreach(Cihaz c in Program.cihaz_listesi) { c.BilgileriGoster();}
    }

    static bool CihazListedeMi(string kimlik)
    {
        foreach(Cihaz C in Program.cihaz_listesi)
        {
            if(kimlik == C.kimlik) return true;
        }
        return false;
    }

    static Cihaz cihazBul(string kimlik)
    {
        foreach(Cihaz C in Program.cihaz_listesi)
        {
            if(kimlik == C.kimlik) return C;
        }
        // Bir cihaz nesneni göndermek zorunda kaldığı için tanımladım
        return new Cihaz("","",CihazTuru.Lamba);

    }

    static void CihazDurumuAyarla(bool durum, string kimlik)
    {
        if(CihazListedeMi(kimlik) == false) throw new ArgumentException("Cihaz listede değil");
        Cihaz eklenecekCihaz = cihazBul(kimlik);
        if (durum)eklenecekCihaz.Ac();
        else eklenecekCihaz.Kapat();
        
    }
    static void Main(string[] args)
    {        
        while (true)
            {
                try
                {
                    Program.MenuDisplay();
                    int num;
                    int.TryParse(Console.ReadLine(),out num);
                    if(num >= 1 && num <=  5)
                    {
                        if(num == 1) CihazListesiGoster();
                        else if(num == 2)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Tür giriniz");
                            Console.WriteLine("1- Lamba");
                            Console.WriteLine("2- Klima");
                            Console.WriteLine("3- Güvenlik Sistemi");
                            Console.WriteLine("");

                            int typeNum;
                            int.TryParse(Console.ReadLine(),out typeNum);
                            if(typeNum >0 && typeNum < 4)
                            {
                                CihazTuru tur = CihazTuru.Lamba;
                                
                                if(typeNum == 2) tur = CihazTuru.Klima;
                                else if(typeNum == 3) tur = CihazTuru.GuvenlikSistemi;
                                Console.WriteLine("Kimlik: ");
                                string? kimlik = Console.ReadLine();
                                Console.WriteLine("Ad: ");
                                string? ad = Console.ReadLine();

                                
                                // Cihaz ekleme fonksiyonu çağrılıyor
                                CihazEkle(kimlik,ad,tur);
                            }
                            else throw new ArgumentException("Geçerli tür numarası girmelisiniz");
                            
                        }
                        else if(num == 3 || num == 4)
                        {
                            Console.WriteLine("Kimlik: ");
                            string? kimlik = Console.ReadLine();

                            if(string.IsNullOrWhiteSpace(kimlik)) throw new ArgumentException("Geçerli kimlik giriniz");

                            if(num == 3) CihazDurumuAyarla(true,kimlik);
                            else CihazDurumuAyarla(false,kimlik);
                        }

                        else if(num== 5)
                        {
                            Console.WriteLine("Programdan çıkılıyor....");
                            break;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Geçerli bir değer giriniz"); 
                    }
                                       
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
    }
}
