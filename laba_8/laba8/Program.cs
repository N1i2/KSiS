using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPWork;

/*
172.16.193.1
255.255.128.0
*/

namespace laba8
{
    class Program
    {
        static void Main(string[] args)
        {
            string startIP;
            string startMask;
            string endNetID;
            string endHostID =string.Empty;

            try
            {
                Console.WriteLine("Введите IP:");
                startIP = Console.ReadLine();
                endHostID += startIP;
                startIP = WorkWithIP.CreatBinaryIP(startIP);

                Console.WriteLine("Введите маску:");
                startMask = Console.ReadLine();
                startMask = WorkWithIP.CreatBinaryMask(startMask);

                Console.WriteLine("\n\nбинарный IP   == {0}",startIP);
                Console.WriteLine("бинарный Mask == {0}", startMask);

                endNetID = CountID.CreatNetworkID(endHostID, startIP, startMask);
                endHostID = CountID.CreatHostID(endHostID, startIP, startMask);

                Console.WriteLine("\n\nID сети  == {0}", endNetID);
                Console.WriteLine("ID хоcта == {0}", endHostID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}