

using static zadanie1.IDevice;

namespace zadanie1;

public class Copier : IDevice , IPrinter
{
    private int _PrintCounter;
    private int _ScanCounter;
    private int _Counter;

    public int PrintCounter
    {
        get => _PrintCounter;
        init =>_PrintCounter = value;
        
    }

    public int ScanCounter
    {
        get => _ScanCounter;
        init => _ScanCounter = value;
    }

    public int Counter
    {
        get => _Counter;
        init => _Counter = value;

    }

    public void Print(in IDocument document)
    {
        DateTime thisDay = DateTime.Today;
        string data = $"{thisDay.ToString("d")}";
        string time = $"{thisDay.ToString("T")}";
        
        Console.WriteLine($"{data} {time} Print: {document.GetFileName()}.{document.GetFormatType()}");
    }

    public void PowerOn()
    {

    }

   

    public void PowerOff()
    {
        
    }

    public State GetState()
    {
        throw new NotImplementedException();
    }

    
}