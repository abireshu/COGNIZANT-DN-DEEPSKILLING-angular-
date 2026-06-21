class Program
{

    static void Main(string[] args)
    {


        Logger log1 = Logger.GetInstance();


        Logger log2 = Logger.GetInstance();



        Console.WriteLine(log1);


        Console.WriteLine(log2);



        if(log1 == log2)
        {

            Console.WriteLine("Same Logger Object");

        }

        else
        {

            Console.WriteLine("Different Objects");

        }


    }

}