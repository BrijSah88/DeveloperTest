using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;
using System.Configuration;

namespace FileInfo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Reading input from command line argument, if there is no argument then option is avilable to record from user side
            BusinessLogic objResult = new BusinessLogic();
            
            //Reading from command line argument 
            if (args.Length == 2)
            {
                Console.WriteLine(objResult.Get_Version_Size(args[0].Trim() + " " + args[1].Trim()));
                Console.ReadLine();
            }

            //If command line argument not aviable then asking to read from user
            else if (args.Length == 0)
            {
                Console.WriteLine("Input not found in command line argument, Do you want to give input from user side?{Y/N}");
                string strYesNo = Console.ReadLine();
                Console.WriteLine();
                if (strYesNo.ToUpper() == "Y")
                {
                    objResult.Read_Input_User();
                }                
            }

            //Command line argument is not in require format
            else
            {
                Console.WriteLine("Invalid input passing from command line");
                Console.ReadLine();
            }
        }       
    }
}
