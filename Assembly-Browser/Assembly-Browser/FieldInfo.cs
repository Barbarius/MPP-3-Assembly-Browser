﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Browser
{
    class FieldInfo
    {
        public string name;
        public string type;
        public string modificators;

        public FieldInfo(System.Reflection.FieldInfo fi)
        {
            name = fi.Name;

            modificators = GetTypeModificators(fi.GetType());

            // check for generic types
            if (fi.FieldType.IsGenericType)
                type += fi.FieldType.Name + "<" + GetGeneric(fi.FieldType.GenericTypeArguments) + ">";
            else
                type += fi.FieldType.Name;
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

        public string GetGeneric(Type[] type)
        {
            string resultStr = String.Empty;

            foreach (Type generic in type)
            {
                if (type.GetType().IsGenericType)
                    resultStr += "<" + GetGeneric(generic.GetType().GenericTypeArguments) + ">";
                else
                    resultStr += generic.Name + " ";
            }

            return resultStr;
        }
    }
}
