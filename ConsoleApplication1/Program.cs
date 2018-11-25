using System;
using System.IO;
using System.Reflection;
using Assembly_Browser;
using Assembly_Browser.model;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string path = @"D:\Labs\MPP_3\AssemblyBrowser\ConsoleApplication1\Plugins\1.dll";
            AssemblyBrowser assemblyBrowser = new AssemblyBrowser();
            assemblyBrowser.SetAssembly(Assembly.LoadFile(new FileInfo(path).FullName));

            foreach (Namespace ns in assemblyBrowser.GetAllNamespaces())
            {
                Console.Out.WriteLine(ns.ToString());
            }
        }
    }
}