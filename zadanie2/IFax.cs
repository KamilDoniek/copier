using zadanie1;
namespace zadanie2;

public interface IFax : IDevice
{
    void SendFax(in IDocument document);
    void ReceptionFax(in IDocument document);
}