using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Browser
{
    class MethodInfo
    {
        public string name;
        public string modificators;

        public MethodInfo(System.Reflection.MethodInfo mi)
        {
            name = mi.Name;
            modificators = GetTypeModificators(mi.GetType());
        }

        private string GetTypeModificators(Type t)
        {
            if (t.IsNestedPrivate)
                return "private ";
            if (t.IsNotPublic)
                return "private ";

            if (t.IsNestedFamily)
                return "protected ";
            if (t.IsNestedFamANDAssem)
                return "protected private ";
            if (t.IsNestedAssembly)
                return "internal ";
            if (t.IsNestedFamORAssem)
                return "protected internal ";
            
            if (t.IsNestedPublic || t.IsPublic)
                return "public "; 
            else
                return "public ";
        }
    }
}
