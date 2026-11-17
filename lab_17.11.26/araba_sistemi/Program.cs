namespace araba_sistemi;

public class Motor
{
    public string Model { get; set; }
    public double BeygirGucu { get; set; }

    public Motor(string model, double beygirGucu)
    {
        Model = model;
        BeygirGucu = beygirGucu;
    }

    public void Calistir()
    {
        Console.WriteLine($"{Model} Motor - {BeygirGucu} PS çalışıyor.");
    }
}
public class Araba
{
    public string MarkaBilgisi { get; set; }
    private Motor _motor;

    public Araba(string markaBilgisi, string motorModel, double motorBeygirGucu)
    {
        MarkaBilgisi = markaBilgisi;
        _motor = new Motor(motorModel, motorBeygirGucu);
        // Composition ilişkisi
    }

    public void Calistir()
    {
        Console.WriteLine($"{MarkaBilgisi} çalıştırılıyor...");
        _motor.Calistir();
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        Araba araba = new Araba("Nissan Qashqai", "1.5 e-POWER (Hibrit)", 158);
        araba.Calistir();
    }
}