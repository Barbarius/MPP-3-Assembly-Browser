using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Browser
{
    class NamespaceInfo
    {
        public string Name { set; get; }

        public List<DatatypeInfo> DataTypes { set; get; }

        public NamespaceInfo(string name)
        {
            this.Name = name;
            DataTypes = new List<DatatypeInfo>();
        }
    }
}
