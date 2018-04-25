using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CategoryProducts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                categoriesTableAdapter1.Fill(
                    northwindDataSet1.Categories);
                productsTableAdapter1.Fill(
                    northwindDataSet1.Products);
                //Linq query
                var categoryRows =
                    from category in northwindDataSet1.Categories
                    select category;
                foreach (var item in categoryRows)
                {
                    lstCategories.Items.Add(item.CategoryID + " " +
                        item.CategoryName);
                }
                
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some errors occured during connection to the database" + ex);
            }
        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lstProducts.Items.Clear();
                string cat = (string)lstCategories.SelectedItem;
                int id = int.Parse(cat.Substring(0, 1));
                lblProducts.Text = cat.Substring(1) + " 's products:";
                //LINQ 
                var productsResult =
                    from productLine in northwindDataSet1.Products
                    where productLine.CategoryID == id
                    select productLine;
                foreach (var item in productsResult)
                {
                    lstProducts.Items.Add(item.ProductID.ToString().PadLeft(3) +
                        " " + item.ProductName);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some errors occured" + ex.Message, "Error: ");
            }
        }
    }
}
