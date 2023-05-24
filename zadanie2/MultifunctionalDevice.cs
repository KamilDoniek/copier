using zadanie1;

namespace zadanie2;

public class MultifunctionalDevice :BaseDevice, IPrinter, IScanner, IFax
{
    private int _printCounter=0;
    private int _scanCounter=0;
    private int _counter=0;
    private int _faxCounter = 0;
    

    public int PrintCounter
    {
        get => _printCounter;
        private set =>_printCounter = value;
        
    }

    public int ScanCounter
    {
        get => _scanCounter;
        private set => _scanCounter = value;
    }

    public int FaxCounter
    {
        get=>_faxCounter;
        private set => _faxCounter = value;
    }

    public new int Counter
    {
        get => _counter;
        private set => _counter = value;

    }
    public void Print(in IDocument document)
    {
        DateTime thisDay = DateTime.Today;
        string data = $"{thisDay.ToString("d")}";
        string time = $"{thisDay.ToString("T")}";

        if (GetState() == IDevice.State.on)
        {
            Console.WriteLine($"{data} {time} Print: {document.GetFileName()}");
            PrintCounter++;
        }
    }
    public void Scan(out IDocument document,IDocument.FormatType formatType= IDocument.FormatType.JPG)
    {
        DateTime thisDay = DateTime.Now;
        string data = $"{thisDay.ToString("d")}";
        string time = $"{thisDay.ToString("T")}";
        string name = "";

        document = null;
        if (GetState()==IDevice.State.off){ 
            document = null;
            return;
            
        }
     
        if (formatType == IDocument.FormatType.PDF)
        {
            name = $"PDFScan{ScanCounter}.pdf";
            document = new PDFDocument(name);

        }
        else if (formatType == IDocument.FormatType.JPG)
        {
            name = $"ImageScan{ScanCounter}.jpg";
            document = new ImageDocument(name);
        }
        else if (formatType == IDocument.FormatType.TXT)
        {
            name = $"TextScan{ScanCounter}.txt";
            document = new TextDocument(name);
        }
  
        Console.WriteLine($"{data} {time} Scan: {name}");
        ScanCounter++;

    }
    public void ScanAndPrint()
    {
        IDocument document;
        IDocument.FormatType formatType = IDocument.FormatType.JPG;
        
        if (GetState()==IDevice.State.off){ 
            Console.WriteLine("The device is powered off");
            return;
            
        }
        Scan(out document, formatType);
        
        Print(document);
        
            
    }

    public void SendFax(in IDocument document)
    {
        if (GetState()==IDevice.State.off){ 
            Console.WriteLine("The device is powered off");
            return;
        }
        else
        {
            Console.WriteLine($"Send Fax Name: {document.GetFileName()}");
            FaxCounter++;
        }
    }

    public void ReceptionFax(in IDocument document)
    {
        if (GetState()==IDevice.State.off){ 
            Console.WriteLine("The device is powered off");
            return;
        }
        else
        {
            Console.WriteLine($"Reception Fax {document.GetFileName()}");
            FaxCounter++;
        }
    }

}