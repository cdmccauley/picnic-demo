namespace PicnicDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Cashier johnnyCash = new Cashier();
            johnnyCash.SellItems();
            johnnyCash.ReportEarnings();
        }
    }
}
