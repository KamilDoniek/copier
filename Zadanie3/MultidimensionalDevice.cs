namespace zadanie3;

public class MultidimensionalDevice : Copier, IFax
{
    public int FaxCounter { get ; private set ; }=0;
    private Fax fax = new Fax();

    public override void PowerOn()
    {
        if (printer.GetState()==IPrinter.State.off && scanner.GetState()==IScanner.State.off && fax.GetState()==IFax.State.off)
        {
            printer.PowerOn();
            scanner.PowerOn();
            fax.PowerOn();
            Counter++;
        }
    }

    public override void PowerOff()
    {
        if (printer.GetState() == IPrinter.State.on && scanner.GetState() == IScanner.State.on &&
            fax.GetState() == IFax.State.on)
        {
            printer.PowerOff();
            scanner.PowerOff();
            fax.PowerOff();
        }

    }

    public void SendFax(in IDocument document)
    {
        if (fax.GetState()==IFax.State.on)
        {
            fax.SendFax(document);
            FaxCounter++;
        }
    }

    public void ReceptionFax(in IDocument document)
    {
        if (fax.GetState()==IFax.State.on)
        {
            fax.ReceptionFax(document);
            FaxCounter++;
        }
    }
}

public class Fax : BaseDevice, IFax
{
    public override void PowerOn()
    {
        if (GetState()==IFax.State.off)
        {
            state = IFax.State.on;
            Console.WriteLine("Fax on");
        }
    }

    public override void PowerOff()
    {
        if (GetState()==IFax.State.on)
        {
            state = IFax.State.off;
            Console.WriteLine("Fax off");
        }
    }

    public void SendFax(in IDocument document)
    {
        Console.WriteLine($"Send Fax Name: {document.GetFileName()}");

    }

    public void ReceptionFax(in IDocument document)
    {
        Console.WriteLine($"Reception Fax {document.GetFileName()}");

    }
}