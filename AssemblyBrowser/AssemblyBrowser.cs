using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Assembly_Browser.model;

namespace Assembly_Browser
{
    public class AssemblyBrowser
    {
        private Assembly _assembly;
        private List<Namespace> _namespaces;
        private string _url;

        public AssemblyBrowser(string url)
        {
            _namespaces = new List<Namespace>();
            _assembly = null;
            _url = url;
            SetAssembly();
        }
        
        public void SetAssembly()
        {
            _assembly = Assembly.LoadFile(new FileInfo(_url).FullName);
        }
        
        public List<Namespace> GetAllNamespaces() {
            
            string name = _assembly.FullName;
            
            List<Type> typeList = new List<Type>(_assembly.GetTypes());

            foreach(Type type in typeList) {
                bool isNamespaceExist = false;
                string namespaceName = type.Namespace;
                foreach (Namespace nmspace in _namespaces)
                {
                    if (namespaceName.Equals(nmspace.GetName()))
                    {
                        isNamespaceExist = true;
                        nmspace.AddDataType(type);
                    }
                }
                if (!isNamespaceExist)
                {
                    _namespaces.Add(new Namespace(type.Namespace));
                }
            }
            
            return _namespaces;
        }
       
    }
}