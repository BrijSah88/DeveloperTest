using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileInfo;

namespace FileInfoTest
{
    [TestClass]
    public class ResultTest
    {
        [TestMethod]
        public void TestCase_More_Inputs()
        {
            BusinessLogic obj = new BusinessLogic();

            string strResult = obj.Get_Version_Size("version c:/test.txt test");

            Assert.AreEqual(strResult, "Invalid Input");
        }

        [TestMethod]
        public void TestCase_Less_Inputs()
        {
            BusinessLogic obj = new BusinessLogic();

            string strResult = obj.Get_Version_Size("-v");

            Assert.AreEqual(strResult, "Invalid Input");
        }

        [TestMethod]
        public void TestCase_Null_Input()
        {
            BusinessLogic obj = new BusinessLogic();

            string strResult = obj.Get_Version_Size(null);

            Assert.IsTrue(strResult.Contains("Exception"));
        }

        [TestMethod]
        public void TestCase_Blank_Input()
        {
            BusinessLogic obj = new BusinessLogic();

            string strResult = obj.Get_Version_Size("  ");

            Assert.AreEqual(strResult, "Invalid Input");
        }

        [TestMethod]
        public void TestCase_Invalid_Blank_Input()
        {
            BusinessLogic obj = new BusinessLogic();

            string strResult = obj.Get_Version_Size("  c:/test.txt");

            Assert.AreEqual(strResult, "Invalid Input");
        }

        [TestMethod]
        public void TestCase_Invalid_Option()
        {
            BusinessLogic obj = new BusinessLogic();

            string strResult = obj.Get_Version_Size("version c:/test.txt");

            Assert.AreEqual(strResult, "Invalid Option");
        }

        [TestMethod]
        public void TestCase_All_Valid_Version()
        {
            BusinessLogic obj = new BusinessLogic();

            string strResult1 = obj.Get_Version_Size("-v c:/test.txt");
            string strResult2 = obj.Get_Version_Size("--v c:/test.txt");
            string strResult3 = obj.Get_Version_Size("/v c:/test.txt");
            string strResult4 = obj.Get_Version_Size("--version c:/test.txt");

            Assert.IsTrue(strResult1.StartsWith("File Version is"));
            Assert.IsTrue(strResult2.StartsWith("File Version is"));
            Assert.IsTrue(strResult3.StartsWith("File Version is"));
            Assert.IsTrue(strResult4.StartsWith("File Version is"));
        }

        [TestMethod]
        public void TestCase_All_Valid_Size()
        {
            BusinessLogic objResult = new BusinessLogic();

            string strResult1 = objResult.Get_Version_Size("-s c:/test.txt");
            string strResult2 = objResult.Get_Version_Size("--s c:/test.txt");
            string strResult3 = objResult.Get_Version_Size("/s c:/test.txt");
            string strResult4 = objResult.Get_Version_Size("--size c:/test.txt");

            Assert.IsTrue(strResult1.StartsWith("File Size is"));
            Assert.IsTrue(strResult2.StartsWith("File Size is"));
            Assert.IsTrue(strResult3.StartsWith("File Size is"));
            Assert.IsTrue(strResult4.StartsWith("File Size is"));
        }
    }
}
