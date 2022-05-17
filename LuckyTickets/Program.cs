using System;

namespace LuckyTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i = 2; i <= 20; i += 2)
            {
                var lacky = new LuckyTicket(i);
                lacky.Start();
            }
             
        }
    }
}
