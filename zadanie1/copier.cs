

using System.Reflection.Metadata;
using static zadanie1.IDevice;

namespace zadanie1;

public class Copier : IDevice , IPrinter , IScanner
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
    public void Print(in IDocument document)
    {
        DateTime thisDay = DateTime.Today;
        string data = $"{thisDay.ToString("d")}";
        string time = $"{thisDay.ToString("T")}";
        
        Console.WriteLine($"{data} {time} Print: {document.GetFileName()}.{document.GetFormatType()}");
    }
    public void Scan(out IDocument document,IDocument.FormatType formatType)
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
       
    }

    public void ScanAndPrint()
    {
        IDocument document;
        Scan(out document, IDocument.FormatType.JPG);

        if (document != null) Print(document);

        else throw new ArgumentException("Scanning failed");
    }

}

