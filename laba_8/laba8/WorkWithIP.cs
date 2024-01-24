using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPWork
{
    static class WorkWithIP
    {
        static WorkWithIP()
        {
            sqwer = new int[8];

            FullNumb = "11111111";
            EmptyNumb = "00000000";

            Need = '1';
            NotNeed = '0';
        }
        static private void CreatSqer()
        {
            for (int i = 7; i >= 0; i--)
                sqwer[i] = Convert.ToInt32(Math.Pow(2, i));
        }

        static public int[] sqwer { get; private set; }
        static public string FullNumb { get; }
        static public string EmptyNumb { get; }
        static private char Need;
        static private char NotNeed;

        static private int[] CheckStartIP(string startIP)
        {
            string[] helpStr = startIP.Split('.');

            if (helpStr.Length != 4)
                throw new Exception("IP введеон не правильно");

            int[] result = new int[4];

            for (int i = 0; i < helpStr.Length; i++)
                if (!int.TryParse(helpStr[i], out result[i]) || result[i] < 0 || result[i] > 255)
                    throw new Exception("IP введеон не правильно");

            return result;
        }
        static private int[] CheckStartMask(string startMask)
        {
            string[] helpStr = startMask.Split('.');

            if (helpStr.Length != 4)
                throw new Exception("Маска введена не коректно");

            int[] result = new int[4];

            for (int i = 0; i < helpStr.Length; i++)
                if (!int.TryParse(helpStr[i], out result[i]) || result[i] < 0 || result[i] > 255)
                    throw new Exception("Маска введена не коректно");

            if (result[0] < 128)
                throw new Exception("Маска введена не коректно");

            bool endChek = false;

            for (int i = 0; i < result.Length; i++)
            {
                if (endChek && result[i] != 0)
                    throw new Exception("Маска введена не коректно");
                if (endChek)
                    continue;

                if (result[i] == 255)
                    continue;

                endChek = true;
            }

            if (!endChek)
                throw new Exception("Маска введена не коректно");

            return result;
        }
        static public string CreatBinaryIP(string startIP)
        {
            string result = string.Empty;
            int[] checkIP = CheckStartIP(startIP);

            CreatSqer();

            for (int i = 0; i < 4; i++)
            {
                if (checkIP[i] == 255)
                    result += FullNumb;
                else if (checkIP[i] == 0)
                    result += EmptyNumb;
                else
                    for (int j = 7; j >= 0; j--)
                    {
                        if (checkIP[i] == 0)
                            result += NotNeed;
                        else if (checkIP[i] >= sqwer[j])
                        {
                            result += Need;
                            checkIP[i] -= sqwer[j];
                        }
                        else
                        result += NotNeed;
                    }

                if (i != 3)
                    result += ".";
            }

            return result;
        }
        static public string CreatBinaryMask(string startMask)
        {
            string result = string.Empty;
            int[] checkMask = CheckStartMask(startMask);
            bool checking = false;

            for (int i = 0; i < 4; i++)
            {
                if (checking)
                {
                    if (checkMask[i] != 0)
                        throw new Exception("Маска введена не коректно");
                    else
                        result += EmptyNumb;
                }
                else if (checkMask[i] == 255)
                    result += FullNumb;
                else
                {
                    checking = true;

                    for (int j = 7; j >= 0; j--)
                    {
                        if (checkMask[i] == 0)
                            result += NotNeed;
                        else if (checkMask[i] < sqwer[j])
                            throw new Exception("Маска введена не коректно");
                        else
                        {
                            result += Need;
                            checkMask[i] -= sqwer[j];
                        }
                    }
                }

                if(i!=3)
                    result += ".";
            }

            return result;
        }
    }
}