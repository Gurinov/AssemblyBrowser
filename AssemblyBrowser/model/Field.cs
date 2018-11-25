using System.Reflection;

namespace Assembly_Browser.model
{
    public class Field
    {
        private string _name;
        private FieldInfo _fieldInfo;

        public Field(FieldInfo fieldInfo)
        {
            _fieldInfo = fieldInfo;
            SetName();
        }

        private void SetName()
        {
            if (_fieldInfo.IsPrivate)
            {
                _name += "private";
            }
            if (_fieldInfo.IsPublic)
            {
                _name += "public";
            }
            if (_fieldInfo.IsStatic)
            {
                _name += " static";
            }
            _name += " " + _fieldInfo.FieldType.Name;
            _name += " " + _fieldInfo.Name;
        }

        public string GetName()
        {
            return _name;
        }
        
        public override string ToString()
        {
            return "Field: " + _name + ";\n";
        }
    }
}