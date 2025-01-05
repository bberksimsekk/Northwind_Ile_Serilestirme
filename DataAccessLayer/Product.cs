using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccessLayer
{
    [Serializable]
    public class Product
    {
        public int ID;
        public string Name;
        [XmlIgnore]
        public int CategoryID;
        public string Category;
        [XmlIgnore]
        public int SupplierID;
        [XmlIgnore]
        public string CompanyName;
        [XmlIgnore]
        public string ContactName;
        public decimal UnitPrice;
        public short UnitsInStock;
        public short ReorderLevel;
        public bool IsContinued;
    }
}
