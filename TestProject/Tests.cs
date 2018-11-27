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
        
        //private AssemblyBrowser _assemblyBrowser = new AssemblyBrowser(AppDomain.CurrentDomain.BaseDirectory + "TestProject.dll");
        private AssemblyBrowser _assemblyBrowser;

        private const int namespaceCount = 2;
        private const int DataTypeCount = 4;
        private const int fieldCount = 6;
        private const int methodCount = 7;
        private const int propertyCount = 0;
        
        private const string namespaceName = "Tracer";
        private const string DataTypeName = "public class Node";
        private const string fieldName = "public String _className";
        private const string methodName = "public Node getParent ()";

        [SetUp]
        public void Initialization()
        {
            _assemblyBrowser = new AssemblyBrowser(AppDomain.CurrentDomain.BaseDirectory + "../../Plugins/1.dll");
        }

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
            Assert.AreEqual(_assemblyBrowser.GetAllNamespaces()[0].GetDataTypes()[0].GetProperties().Count, propertyCount);
        }
        
        [Test]
        public void NamespaceConsistTest()
        {
            Assert.AreEqual(_assemblyBrowser.GetAllNamespaces()[0].GetName(), namespaceName);
        }
        
        [Test]
        public void DataTypeConsistTest()
        {
            Assert.AreEqual(_assemblyBrowser.GetAllNamespaces()[0].GetDataTypes()[0].GetName(), DataTypeName);
        }

        [Test]
        public void FieldConsistTest()
        {
            Assert.AreEqual(_assemblyBrowser.GetAllNamespaces()[0].GetDataTypes()[0].GetFields()[0].GetName(), fieldName);
        }

        [Test]
        public void MethodConsistTest()
        {
            Assert.AreEqual(_assemblyBrowser.GetAllNamespaces()[0].GetDataTypes()[0].GetMethods()[0].GetName(), methodName);
        }
    }
}