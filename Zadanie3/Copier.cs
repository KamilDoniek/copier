
namespace zadanie3;


public class Copier : BaseDevice,IScanner,IPrinter
{

    public int PrintCounter { get; private set; } = 0;

    public int ScanCounter { get; private set; } = 0;

    public new int Counter { get; protected set; } = 0;
    
    protected Printer printer = new Printer();
    protected Scanner scanner = new Scanner();
    IPrinter.State PrinterState =  IPrinter.State.off;
    IScanner.State ScanState =  IScanner.State.off;
    public override void PowerOn()
    {
        
       

        
        if (printer.GetState() == IPrinter.State.off && scanner.GetState() == IScanner.State.off)
        {
            Console.WriteLine("device is on");
            state = IDevice.State.on;
            printer.PowerOn();
            scanner.PowerOn();
            Counter++;
        }
        
    }

    public override void PowerOff()
    {
        if (printer.GetState() == IPrinter.State.on && scanner.GetState() == IScanner.State.on)
        {
            Console.WriteLine("device is off");
            state = IDevice.State.off;
            printer.PowerOff();
            scanner.PowerOff();
            
        }
        
    }

    public void Print(in IDocument document)
    {
        if (printer.GetState()==IPrinter.State.on)
        {
            printer.Print(document);
            PrintCounter++;
        }
    }

    public void Scan(out IDocument document, IDocument.FormatType formatType=IDocument.FormatType.JPG)
    {
        if (scanner.GetState()==IScanner.State.on)
        {
            scanner.Scan(out document,formatType);
            ScanCounter++;
        }
        else
        {
            document = null;
        }
    }

    public void ScanAndPrint()
    {
        IDocument document;
        
        if (scanner.GetState()==IScanner.State.on && printer.GetState()==IPrinter.State.on )
        {
            Scan(out document);
            Print(document);
            PrintCounter++;
            ScanCounter++;
        }
    }
    

}

public class Printer : BaseDevice, IPrinter
{

    public override void PowerOn()
    {
        if (GetState()==IPrinter.State.off)
        {
            state = IPrinter.State.on;

            Console.WriteLine("Printer on");
        }
    }

    public override void PowerOff()
    {
        if (GetState()==IPrinter.State.on)
        {
            state = IPrinter.State.off;
            Console.WriteLine("Printer off");
        
        } 
    }
    public void Print(in IDocument document)
    {
        
        DateTime thisDay = DateTime.Today;
        string data = $"{thisDay.ToString("d")}";
        string time = $"{thisDay.ToString("T")}";
        
        Console.WriteLine($"{data} {time} Print: {document.GetFileName()}");
    }

   
}

public class Scanner : BaseDevice, IScanner
{
    public int ScanCounter { get; private set; } = 0;

    public override void PowerOn()
    {
        if (GetState() == IScanner.State.off)
        {
            state = IScanner.State.on;
        }
    }

    public override void PowerOff()
    {
        if (GetState() == IScanner.State.on)
        {
            state = IScanner.State.off;
        }
    }

    public void Scan(out IDocument document, IDocument.FormatType formatType)
    {
        DateTime thisDay = DateTime.Now;
        string data = $"{thisDay.ToString("d")}";
        string time = $"{thisDay.ToString("T")}";
        string name = "";



        if (formatType == IDocument.FormatType.PDF)
        {
            name = $"PDFScan{ScanCounter}.pdf";
            document = new PDFDocument(name);

        }
        else if (formatType == IDocument.FormatType.TXT)
        {
            name = $"TextScan{ScanCounter}.txt";
            document = new TextDocument(name);
        }
        else
        {
            name = $"ImageScan{ScanCounter}.jpg";
            document = new ImageDocument(name);
        }




        Console.WriteLine($"{data} {time} Scan: {name}");
    }
}


