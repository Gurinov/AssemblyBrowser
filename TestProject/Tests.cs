using System;
using System.Net.Mime;
using Assembly_Browser;
using Assembly_Browser.model;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class Tests
    {
        
        private AssemblyBrowser _assemblyBrowser = new AssemblyBrowser(AppDomain.CurrentDomain.BaseDirectory + "TestProject.dll");
        //private AssemblyBrowser _assemblyBrowser = new AssemblyBrowser(AppDomain.CurrentDomain.BaseDirectory + "../../Plugins/1.dll");

        private const int namespaceCount = 2;
        private const int DataTypeCount = 4;
        private const int fieldCount = 6;
        private const int methodCount = 7;
        private const int propertyCount = 6;

        [Test]
        public void NamespaceCountTest()
        {
            Assert.AreEqual(_assemblyBrowser.GetAllNamespaces().Count, namespaceCount);
        }

        [Test]
        public void DataTypeCountTest()
        {
            Assert.AreEqual(_assemblyBrowser.GetAllNamespaces()[0].GetDataTypes().Count, DataTypeCount);
        }

        [Test]
        public void FieldCountTest()
        {
            Assert.AreEqual(_assemblyBrowser.GetAllNamespaces()[0].GetDataTypes()[0].GetFields().Count, fieldCount);
        }

        [Test]
        public void MethodCountTest()
        {
            Assert.AreEqual(_assemblyBrowser.GetAllNamespaces()[0].GetDataTypes()[0].GetMethods().Count, methodCount);
        }

        [Test]
        public void PropertyCountTest()
        {
            Assert.AreEqual(_assemblyBrowser.GetAllNamespaces()[0].GetDataTypes()[0].GetFields().Count, propertyCount);
        }
    }
}