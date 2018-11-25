using System;
using System.Collections.Generic;
using System.Reflection;
using Assembly_Browser.model;

namespace Assembly_Browser
{
    public class AssemblyBrowser
    {
        private Assembly _assembly;
        private List<Namespace> _namespaces;

        public AssemblyBrowser()
        {
            _namespaces = new List<Namespace>();
            _assembly = null;
        }
        
        public void SetAssembly(Assembly assembly)
        {
            _assembly = assembly;
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