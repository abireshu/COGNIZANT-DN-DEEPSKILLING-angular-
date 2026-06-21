class Program
{

    static void Main(string[] args)
    {

        DocumentFactory factory;


        factory = new WordFactory();

        IDocument word = factory.CreateDocument();

        word.Open();



        factory = new PdfFactory();

        IDocument pdf = factory.CreateDocument();

        pdf.Open();



        factory = new ExcelFactory();

        IDocument excel = factory.CreateDocument();

        excel.Open();

    }

}