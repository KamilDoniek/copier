using zadanie1;

namespace zadanie2;

public class MultifunctionalDevice : Copier
{
  
    private int _faxCounter = 0;
    

    public int FaxCounter
    {
        get=>_faxCounter;
        private set => _faxCounter = value;
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