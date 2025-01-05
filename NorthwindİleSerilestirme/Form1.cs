using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace NorthwindİleSerilestirme
{
    public partial class Form1 : Form
    {
        DataModel dm = new DataModel();
        List<Product> ProductList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProductList = dm.GetProducts();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Ürün Adı");
            dt.Columns.Add("Kategori");
            dt.Columns.Add("Tedarikçi Firma");
            dt.Columns.Add("Tedarikçi Firma Yetkilisi");
            dt.Columns.Add("Fiyat");
            dt.Columns.Add("Stok");
            dt.Columns.Add("GüvenlikStok");
            dt.Columns.Add("Satışta mı");

            foreach (Product item in ProductList)
            {
                dt.Rows.Add(item.ID, item.Name, item.Category, item.CompanyName, item.ContactName, item.UnitPrice, item.UnitsInStock, item.ReorderLevel, item.IsContinued ? "Satışta Değil" : "Satışta");
            }

            dataGridView1.DataSource = dt;
        }

        private void btn_yayinla_Click(object sender, EventArgs e)
        {
            try 
            {
                using (StreamWriter sw = new StreamWriter("urunler.xml"))
                {
                    XmlSerializer serilestirici = new XmlSerializer(typeof(List<Product>));
                    serilestirici.Serialize(sw, ProductList);
                }
                MessageBox.Show("Serileştirildi");
            }
            catch
            {
                MessageBox.Show("Hata Oluştu");
            }
        }
    }
}
