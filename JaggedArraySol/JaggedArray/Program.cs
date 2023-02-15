class Question2
{
    static void Main(string[] args)
    {
        int[][] jaggedarray = new int[12][];
        int[] sales = new int[12];
        int annualSales = 0;
        String[] months = {"January", "February", "March", "April",
            "May", "June", "July", "August", "September",
            "October", "November", "December"};

        for (int i = 0; i < 12; i++)
        {
            Console.Write("Enter no of sales for {0}: ", months[i]);
            int l = Convert.ToInt32(Console.ReadLine());
            jaggedarray[i] = new int[l];
            int s = 0;
            for (int j = 0; j < l; j++)
            {
                jaggedarray[i][j] = Convert.ToInt32(Console.ReadLine());
                s += jaggedarray[i][j];
            }
            sales[i] = s;
            annualSales += s;
        }
        for (int i = 0; i < 12; i++)
        {
            Console.WriteLine("{0} month sale :{1}", months[i], sales[i]);
        }
        Console.WriteLine("Total annual sale is : {0}", annualSales);

    }
}