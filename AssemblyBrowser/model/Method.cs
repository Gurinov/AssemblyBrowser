using System.Reflection;

namespace Assembly_Browser.model
{
    public class Method
    {
        private string _name;
        private MethodInfo _methodInfo;

        public Method(MethodInfo methodInfo)
        {
            _methodInfo = methodInfo;
            SetName();
        }

        private void SetName()
        {
            if (_methodInfo.IsPrivate)
            {
                _name += "private";
            }
            if (_methodInfo.IsPublic)
            {
                _name += "public";
            }
            if (_methodInfo.IsStatic)
            {
                _name += " static";
            }
            _name += " " + _methodInfo.ReturnType.Name;
            _name += " " + _methodInfo.Name;
            _name += " " + GetParams();
        }

        public string GetName()
        {
            return _name;
        }

        private string GetParams()
        {
            string str = "(";
            foreach (var param in _methodInfo.GetParameters())
            {
                str += param.ParameterType.Name + " " + param.Name + ", ";
            }
            str += ")";
            return str;
        }
        
        public override string ToString()
        {
            return "Method: " + _name + ";\n";
        }
    }
}