using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tests
{
    [TestClass]
    public class DirTests
    {
        [TestMethod]
        public void Test_Create_New_Success()
        {
            //arrange
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test1");

            if(Directory.Exists(path))
            {
                Directory.Delete(path);
            }

            //act
            Dir.Create(path);

            //assert
            Assert.IsTrue(Directory.Exists(path));

            Directory.Delete(path);
        }

        [TestMethod]
        public void Test_Create_If_Dir_Existed_Success()
        {
            //arrange
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test2");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //act
            Dir.Create(path);

            //assert
            Assert.IsTrue(Directory.Exists(path));

            Directory.Delete(path);
        }

        [TestMethod]
        public void Test_CreateIf_When_Conditon_Satisfies()
        {
            //arrange
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test3");

            //act
            Dir.CreateIf(path, () => true);

            //assert
            Assert.IsTrue(Directory.Exists(path));

            Directory.Delete(path);
        }

        [TestMethod]
        public void Test_CreateIf_When_Conditon_Fails()
        {
            //arrange
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test4");

            //act
            Dir.CreateIf(path, () => false);

            //assert
            Assert.IsTrue(!Directory.Exists(path));
        }

        [TestMethod]
        public void Test_DeleteIf_When_Condition_Satifies()
        {
            //arrange
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test5");
            Directory.CreateDirectory(path);

            //act
            Dir.DeleteIf(path, () => true);

            //assert
            Assert.IsTrue(!Directory.Exists(path));
        }

        [TestMethod]
        public void Test_DeleteIf_When_Condition_Fails()
        {
            //arrange
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test6");
            Directory.CreateDirectory(path);

            //act
            Dir.DeleteIf(path, () => false);

            //assert
            Assert.IsTrue(Directory.Exists(path));

            Directory.Delete(path);
        }

        [TestMethod]
        public void Test_Rename_Success()
        {
            //arrange
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test7");
            Directory.CreateDirectory(path);
            string newName = "Test7_Renamed";
            string newPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, newName);

            //act
            Dir.Rename(path, newName);

            //assert
            Assert.IsTrue(!Directory.Exists(path));
            Assert.IsTrue(Directory.Exists(newPath));

            Directory.Delete(newPath);
        }
    }
}
