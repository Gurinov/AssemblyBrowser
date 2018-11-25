using System.Reflection;

namespace Assembly_Browser.model
{
    public class Property
    {
        private string _name;
        private PropertyInfo _propertyInfo;

        public Property(PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;
            SetName();
        }

        private void SetName()
        {
            _name += _propertyInfo.PropertyType.Name;
            _name += " " + _propertyInfo.Name;
            _name += "{";
            if (_propertyInfo.CanRead)
            {
                _name += " get; ";
            }
            if (_propertyInfo.CanWrite)
            {
                _name += " set; ";
            }
            _name += "}";
        }

        public string GetName()
        {
            return _name;
        }

        public override string ToString()
        {
            return "Property: " + _name + ";\n";
        }
    }
}