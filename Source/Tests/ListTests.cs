using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_AddIf_WhenCoditionMatches()
        {
            //arrange
            List<string> stringList = new List<string>();
            List<ListItem> itemList = new List<ListItem>();
            string stringItem = "Test123";
            ListItem listItem = new ListItem { ItemId = 100, Description = "This is a list item" };

            //act
            stringList.AddIf(stringItem, item => item == stringItem);
            itemList.AddIf(listItem, item => item.ItemId == 100);

            //assert
            Assert.IsTrue(stringList.Count == 1);
            Assert.IsTrue(itemList.Count == 1);
        }

        [TestMethod]
        public void Test_AddIf_WhenCoditionDoNotMatch()
        {
            //arrange
            List<string> stringList = new List<string>();
            List<ListItem> itemList = new List<ListItem>();
            string stringItem = "Test123";
            ListItem listItem = new ListItem { ItemId = 100, Description = "This is a list item" };

            //act
            stringList.AddIf(stringItem, item => item == "testing false");
            itemList.AddIf(listItem, item => item.ItemId == 101);

            //assert
            Assert.IsTrue(stringList.Count == 0);
            Assert.IsTrue(itemList.Count == 0);
        }
    }

    public class ListItem
    {
        public int ItemId { get; set; }

        public string Description { get; set; }
    }
}
