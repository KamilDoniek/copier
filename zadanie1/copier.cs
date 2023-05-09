

using System.Reflection.Metadata;
using static zadanie1.IDevice;

namespace zadanie1;

public class Copier : BaseDevice, IPrinter , IScanner
{
    private int _printCounter=0;
    private int _scanCounter=0;
    private int _counter=0;

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

    public new int Counter
    {
        get => _counter;
        private set => _counter = value;

    }



    private IDevice.State state = State.off;
    public new void PowerOn()
    {
        
        if (state == IDevice.State.off)
        {
            state = IDevice.State.on;
            Counter++;
        }
      
    }

   

    public new void PowerOff()
    {
        if (state== IDevice.State.on)
        {
            state = IDevice.State.off;
        }

    }

    public new State GetState()
    {
       return  state;
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

       
    

  
}

