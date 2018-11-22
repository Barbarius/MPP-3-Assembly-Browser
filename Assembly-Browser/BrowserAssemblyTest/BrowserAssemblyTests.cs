using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assembly_Browser;

namespace BrowserAssemblyTest
{
    [TestClass]
    public class BrowserAssemblyTests
    {
        AssemblyReader AssemblyTree;

        [TestInitialize]
        public void Initialize()
        {
            AssemblyTree = new AssemblyReader(".\\TestProject.dll");
        }

        [TestMethod]
        public void NamespacesTest()
        {
            Assert.IsNotNull(AssemblyTree.Namespaces);
            Assert.AreEqual(AssemblyTree.Namespaces[0].Name, "TestProject");
        }

        [TestMethod]
        public void DataTypesTest()
        {
            foreach (DatatypeInfo datatype in AssemblyTree.Namespaces[0].DataTypes)
            {
                Assert.IsNotNull(datatype);
                Assert.AreNotEqual(datatype.Name, String.Empty);
            }
        }

        [TestMethod]
        public void EmptyClassTest()
        {
            foreach (DatatypeInfo datatype in AssemblyTree.Namespaces[0].DataTypes)
            {
                if (datatype.Name == "EmptyClasscs")
                {
                    Assert.AreEqual(datatype.fields.Count, 0);
                    Assert.AreEqual(datatype.properties.Count, 0);
                    Assert.AreEqual(datatype.methods.Count, 0);
                }
            }
        }
    }
}
