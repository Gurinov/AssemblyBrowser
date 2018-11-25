using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assembly_Browser.model
{
    public class DataType
    {
        private string _name;
        private Type _type;
        private List<Field> _fields = new List<Field>();
        private List<Method> _methods = new List<Method>();
        private List<Property> _properties = new List<Property>();
	
        public List<Field> GetFields()
        {
            return _fields;
        }
        public List<Property> GetProperties()
        {
            return _properties;
        }
        public List<Method> GetMethods()
        {
            return _methods;
        }

        public DataType(Type type)
        {
            _type = type;
            SetFields();
            SetMethods();
            SetProperties();
            SetName();
        }

        private void SetName()
        {
            if (_type.IsPublic)
            {
                _name = "public";
            }
            if (_type.IsAbstract)
            {
                _name += " abstract";
            }
            if (_type.IsClass)
            {
                _name += " class";
            }
            if (_type.IsInterface)
            {
                _name += " interface";
            }
            _name += " " + _type.Name;
        }

        public string GetName()
        {
            return _name;
        }
        
        private void  SetFields()
        {
            foreach (var fieldInfo in _type.GetFields(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Field field = new Field(fieldInfo);
                _fields.Add(field);
            }
        }

        private void SetProperties()
        {
            foreach (var propertyInfo in _type.GetProperties(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Property property = new Property(propertyInfo);
                _properties.Add(property);
            }
        }

        private void SetMethods()
        {
            foreach (var methodInfo in _type.GetMethods())
            {
                Method method = new Method(methodInfo);
                _methods.Add(method);
            }
        }

        public override string ToString()
        {
            string result = "Data types: " + _name + " { \n";
            
            foreach (Method method in _methods)
            {
                result += "        " + method.ToString();
            }

            result += "\n";
            
            foreach (Field field in _fields)
            {
                result += "        " + field.ToString();
            }
            
            result += "\n";
            
            foreach (Property property in _properties)
            {
                result += "        " + property.ToString();
            }
            
            result += "    }\n";
            return result;
        }
    }
}