using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;
using System.Configuration;

namespace FileInfo
{
    public class BusinessLogic
    {
        /// <summary>
        /// Reading input from user
        /// </summary>                 
        public void Read_Input_User()
        {
            try
            {                
                Console.WriteLine("Please Enter Input (<functionality> <filename>)");
                string strUserInput = Console.ReadLine();                
                Console.WriteLine(Get_Version_Size(strUserInput));
                Console.WriteLine();
                Ask_Get_Input_Again();
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine("OutOfMemoryException from method CalculateVersionSize : " + ex.Message);
                Ask_Get_Input_Again();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("ArgumentOutOfRangeException from method CalculateVersionSize : " + ex.Message);
                Ask_Get_Input_Again();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception from method CalculateVersionSize : " + ex.Message);
                Ask_Get_Input_Again();
            }
        }

        /// <summary>
        /// Ask to get user input again
        /// </summary>
        public void Ask_Get_Input_Again()
        {
            try
            {
                Console.WriteLine("Do you want Get Version Size again?{Y/N}");
                string strYesNo = Console.ReadLine();
                
                if (strYesNo.ToUpper() == "Y")
                    Read_Input_User();
                else
                    Environment.Exit(0);                
            }
            catch (OutOfMemoryException ex)
            {
                throw new Exception("OutOfMemoryException from method AsktoPerformAgain : " + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new Exception("ArgumentOutOfRangeException from method AsktoPerformAgain : " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception from method AsktoPerformAgain : " + ex.Message);
            }
        }

        /// <summary>
        /// Based on type of inputs function return version or size.
        /// </summary>
        public string Get_Version_Size(string strInputData)
        {
            try
            {
                //Applied Refactoring based on Failed and Pass cases
                strInputData = strInputData.Trim();

                string[] arrData = strInputData.Split(' ');
                
                if (arrData.Length == 2)
                {
                    string[] arrVersionList = ConfigurationManager.AppSettings["WhiteVersionList"].Trim().Split(',');
                    string[] arrSizeList = ConfigurationManager.AppSettings["WhiteSizeList"].Trim().Split(',');                    

                    if (arrVersionList.Contains(arrData[0].Trim()))
                    {
                        return "File Version is : " + GetVersion(arrData[1].Trim());
                    }
                    else if (arrSizeList.Contains(arrData[0].Trim()))
                    {
                        return "File Size is : " + GetSize(arrData[1].Trim());
                    }
                    else
                    {
                        return "Invalid Option";
                    }
                }
                else
                {
                    return "Invalid Input";
                }                                                
            }
            catch (ArithmeticException ex)
            {
                return "ArithmeticException from method PerformAction : " + ex.Message;
            }
            catch (OutOfMemoryException ex)
            {
                return "OutOfMemoryException from method PerformAction : " + ex.Message;
            }
            catch (IndexOutOfRangeException ex)
            {
                return "IndexOutOfRangeException from method PerformAction : " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Exception from method PerformAction: " + ex.Message;
            }
        }

        /// <summary>
        /// Calling Thirdparty for getting file version
        /// </summary>
        /// <param name="strFilename">filename as input</param>
        /// <returns>returning file version</returns>
        private string GetVersion(string strFilename)
        {
            FileDetails objFileDetails = new FileDetails();
            return objFileDetails.Version(strFilename);
        }

        /// <summary>
        /// Calling Thirdparty for getting file size
        /// </summary>
        /// <param name="strFilename">filename as input</param>
        /// <returns>returning file size</returns>
        private string GetSize(string strFilename)
        {
            FileDetails objFileDetails = new FileDetails();
            return Convert.ToString(objFileDetails.Size(strFilename));
        }
    }
}
