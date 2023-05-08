

using System.Reflection.Metadata;
using static zadanie1.IDevice;

namespace zadanie1;

public class Copier :  IPrinter , IScanner
{
    private int _PrintCounter;
    private int _ScanCounter;
    private int _Counter;

    public int PrintCounter
    {
        get => _PrintCounter;
        set =>_PrintCounter = value;
        
    }

    public int ScanCounter
    {
        get => _ScanCounter;
        set => _ScanCounter = value;
    }

    public int Counter
    {
        get => _Counter;
        set => _Counter = value;

    }

    

    private    IDevice.State state;
    public void PowerOn()
    {
        if (state == IDevice.State.off)
        {
            state = IDevice.State.on;
            Counter++;
        }
      
    }

   

    public void PowerOff()
    {
        state = IDevice.State.off;   
    }

    public State GetState()
    {
       return  state;
    }
    

    public void Print(in IDocument document)
    {
        DateTime thisDay = DateTime.Today;
        string data = $"{thisDay.ToString("d")}";
        string time = $"{thisDay.ToString("T")}";

        if (GetState()==IDevice.State.off){ Console.WriteLine("The device is powered off"); return;}
        
        Console.WriteLine($"{data} {time} Print: {document.GetFileName()}.{document.GetFormatType()}");
        PrintCounter++;
    }
    public void Scan(out IDocument document,IDocument.FormatType formatType= IDocument.FormatType.JPG)
    {
        DateTime thisDay = DateTime.Today;
        string data = $"{thisDay.ToString("d")}";
        string time = $"{thisDay.ToString("T")}";
        string name = "";


       
        if (formatType == IDocument.FormatType.PDF)
        {
            name = $"PDFScan{Counter}.{formatType}";
            document = new PDFDocument(name);
            
        }
        else if (formatType == IDocument.FormatType.JPG)
        {
            name = $"ImageScan{Counter}.{formatType}";
            document = new ImageDocument(name);
        }
        else if (formatType == IDocument.FormatType.TXT)
        {
            name = $"TextScan{Counter}.{formatType}";
            document = new TextDocument(name);
        }
        else
        {
            throw new ArgumentException("Unsupported document format type.");
        }

        Console.WriteLine($"{data} {time} Scan: {name}" );
        ScanCounter++;
    }
    // public void Scan(out IDocument document)
    // {
    //     DateTime thisDay = DateTime.Today;
    //     string data = thisDay.ToString("d");
    //     string time = thisDay.ToString("T");
    //     string name = $"ImageScan{Counter}.JPG";
    //
    //     document = new ImageDocument(name);
    //
    //     Console.WriteLine($"{data} {time} Scan: {name}");
    //     ScanCounter++;
    // }

    public void ScanAndPrint()
    {
        IDocument document;
        IDocument.FormatType formatType = IDocument.FormatType.JPG;

        Scan(out document, formatType);

        if (document != null) {Print(document); ScanCounter++;
            PrintCounter++;}

        else throw new ArgumentException("Scanning failed");
       
    }

  
}

