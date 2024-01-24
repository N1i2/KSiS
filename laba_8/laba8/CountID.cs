using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPWork
{
    static class CountID
    {
        static public string CreatNetworkID(string startIP, string ip, string mask)
        {
            string result = string.Empty;
            string[] IpOctet = ip.Split('.');
            string[] MaskOctet = mask.Split('.');
            string[] startOctet = startIP.Split('.');
            int changeOctet = 0;

            for (int i = 0; i < 4; i++)
            {
                if (MaskOctet[i] == WorkWithIP.FullNumb)
                    result += startOctet[i];
                else if (MaskOctet[i] == WorkWithIP.EmptyNumb)
                    result += 0;
                else
                {
                    for (int j = 0; j < 8; j++)
                        if (MaskOctet[i][j] == '1' && IpOctet[i][j] == '1')
                            changeOctet += WorkWithIP.sqwer[(j - 7) * (-1)];

                    result += changeOctet.ToString();
                }

                if (i != 3)
                    result += ".";
            }

            return result;
        }
        static public string CreatHostID(string startIP, string ip, string mask)
        {
            string result = string.Empty;
            string[] IpOctet = ip.Split('.');
            string[] MaskOctet = mask.Split('.');
            string[] startOctet = startIP.Split('.');
            int changeOctet = 0;

            for (int i = 0; i < 4; i++)
            {
                if (MaskOctet[i] == WorkWithIP.FullNumb)
                    result += 0;
                else if (MaskOctet[i] == WorkWithIP.EmptyNumb)
                    result += startOctet[i];
                else
                {
                    for (int j = 0; j < 8; j++)
                        if (MaskOctet[i][j] == '0' && IpOctet[i][j] == '1')
                            changeOctet += WorkWithIP.sqwer[(j - 7) * (-1)];

                    result += changeOctet.ToString();
                }

                if (i != 3)
                    result += ".";
            }

            return result;
        }
    }
}
