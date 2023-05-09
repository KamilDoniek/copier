// See https://aka.ms/new-console-template for more information

IDocument doc1;
copier.Scan(out doc1, formatType: IDocument.FormatType.JPG);
Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
Assert.IsTrue(consoleOutput.GetOutput().Contains(".jpg"));

copier.Scan(out doc1, formatType: IDocument.FormatType.TXT);
Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
Assert.IsTrue(consoleOutput.GetOutput().Contains(".txt"));

copier.Scan(out doc1, formatType: IDocument.FormatType.PDF);
Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
Assert.IsTrue(consoleOutput.GetOutput().Contains(".pdf"));