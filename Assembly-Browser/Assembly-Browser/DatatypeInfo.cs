using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Browser
{
    class DatatypeInfo
    {
        public string Name { set; get; }
        public string DataTypeInfo { set; get; }
        public List<FieldInfo> fields;
        public List<PropertyInfo> properties;
        public List<MethodInfo> methods;

        public DatatypeInfo(TypeInfo t)
        {
            fields = new List<FieldInfo>();
            properties = new List<PropertyInfo>();
            methods = new List<MethodInfo>();

            GetFields(t);
            GetProperties(t);
            GetMethods(t);
        }

        private void GetFields(Type t)
        {
            var fields = t.GetFields();

            foreach (var field in fields)
            {
                this.fields.Add(new FieldInfo(field));
            }
        }

        private void GetProperties(Type t)
        {
            var properties = t.GetProperties();

            foreach (var property in properties)
            {
                this.properties.Add(new PropertyInfo(property));
            }
        }

        private void GetMethods(Type t)
        {
            var methods = t.GetMethods();

            foreach (var method in methods)
            {
                if (!method.IsSpecialName)
                {
                    this.methods.Add(new MethodInfo(method));
                }
            }
        }
    }
}
