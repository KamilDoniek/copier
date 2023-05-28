namespace zadanie3;

public interface IFax : IDevice
{
    void SendFax(in IDocument document);
    void ReceptionFax(in IDocument document);
}