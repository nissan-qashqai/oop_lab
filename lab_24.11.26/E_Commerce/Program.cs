namespace E_Commerce;

public interface IBildirimServisi
{
    public void Gonder(string mesaj);

}
public interface ILoglanabilir
{
    public void LogYaz(string mesaj);
}

// E-Mail Servisi

public class EmailServisi : IBildirimServisi, ILoglanabilir
{
    public void Gonder(string mesaj)
    {
        Console.WriteLine($"Email gönderildi : + {mesaj}");
        LogYaz(mesaj);
    }

    public void LogYaz(string mesaj)
    {
        Console.WriteLine($"Email logu : + {mesaj}");
    }
}

public class SMSServisi : IBildirimServisi
{
    public void Gonder(string mesaj)
    {
        Console.WriteLine($"SMS gönderildi : + {mesaj}");
    }
}

public class MobilBildirimServisi : IBildirimServisi
{
    public void Gonder(string mesaj)
    {
        Console.WriteLine($"Mobil bildirim gönderildi : + {mesaj}");
    }
}

public class SiparisServisi
{
    private IBildirimServisi bildirimServisi;
    public SiparisServisi(IBildirimServisi bildirimServisi)
    {
        this.bildirimServisi = bildirimServisi;
    }

    public void SiparisOlustur(string urunAdi)
    {
        Console.WriteLine($"{urunAdi} : Siparişiniz Oluşturuldu");
        bildirimServisi.Gonder("Siparişiniz oluşturuldu");
    }
}


class Program
{
    static void Main(string[] args)
    {
        // E-Mail
        IBildirimServisi email = new EmailServisi();
        SiparisServisi siparis1 = new SiparisServisi(email);
        siparis1.SiparisOlustur("Laptop");
        Console.WriteLine();

        // SMS
        IBildirimServisi sms = new SMSServisi();
        SiparisServisi siparis2 = new SiparisServisi(sms);
        siparis2.SiparisOlustur("Telefon");
        Console.WriteLine();

        // Mobil Bildirim
        IBildirimServisi mobil = new MobilBildirimServisi();
        SiparisServisi siparis3 = new SiparisServisi(mobil);
        siparis3.SiparisOlustur("Tablet");
        Console.WriteLine();
    }
}
