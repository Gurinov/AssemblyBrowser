using System;
using System.Collections.Generic;

namespace Assembly_Browser.model
{
    public class Namespace
    {
        private string _name;
        private List<DataType> _dataTypes = new List<DataType>();

        public List<DataType> GetDataTypes()
        {
            return _dataTypes;
        }

        public Namespace(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void AddDataType(Type type)
        {
            DataType dataType = new DataType(type);
            _dataTypes.Add(dataType);
        }

        public override string ToString()
        {
            string result = "Namespace: " + _name + " { \n";
            foreach (DataType dataType in _dataTypes)
            {
                result += "    " + dataType.ToString();
            }
            result += "}\n";
            return result;
        }
    }
}