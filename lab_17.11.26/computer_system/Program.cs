namespace computer_system;


public class CPU
{
    public string Model{get;set;}
    public int coreCount{get;set;}

    public CPU(string model, int coreCount)
    {
        if(string.IsNullOrWhiteSpace(model)) { throw new ArgumentNullException("model");}
        Model = model;
        this.coreCount = coreCount;
    }

    public void Run()
    {
        Console.WriteLine($"{Model} is running.");
    }
}

public class Computer
{
    public string compModel{get;set;}
    private CPU _CPU;
    public Computer(string model, string cpuModel,int coreCount)
    {
        compModel = model;
        this._CPU = new CPU(cpuModel, coreCount);
        // Composition relation example
    }
    public void Open()
    {
        Console.WriteLine($"{compModel} is opening.");
        _CPU.Run();
    }

    public string  getInfos()
    {
        return $"\nModel: {compModel}\nCPU Model: {_CPU.Model}\nCore Count: {_CPU.coreCount}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Computer comp = new Computer("HD", "AMD", 8);
        comp.Open();
        Console.WriteLine(comp.getInfos());
    }
}