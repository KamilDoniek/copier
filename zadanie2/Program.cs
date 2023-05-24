using System.Globalization;
using zadanie1;
namespace zadanie2
{
    class Program
    {
        static void Main()
        {
            var xerox = new MultifunctionalDevice();
            xerox.PowerOn();
            IDocument document = new PDFDocument("sdd.pdf");
            xerox.SendFax(document);
        
            
        }
    }
}