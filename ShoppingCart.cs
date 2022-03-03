using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_Cart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addNewProduct_Click(object sender, EventArgs e)
        {
            addProductForm newForm = new addProductForm();
            if (newForm.ShowDialog() == DialogResult.OK)
            productList.Items.Add(newForm.newProduct);
        }

        private void productList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productList.SelectedIndex != -1)
            {
                Product p = productList.SelectedItem as Product;
                nameTB.Text = p.Name;
                categoryTB.Text = p.Category;
                priceTB.Text = Convert.ToString(p.Price);
            }
        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            Product p = productList.SelectedItem as Product;
            cartList.Items.Add((Product)p);
            calculateTotal(p.Price);
        }
        public void calculateTotal(int priceToADD)
        {
            int totalPrice = int.Parse(totalTB.Text);
            totalTB.Text = Convert.ToString(priceToADD+totalPrice);
        }


        private void removeFromCart_Click(object sender, EventArgs e)
        {
            Product itemToRemove = cartList.SelectedItem as Product;
            cartList.Items.Remove(itemToRemove);
            deducePrice(itemToRemove.Price);
        }
        public void deducePrice(int priceToDeduce)
        {
            int totalPrice = int.Parse(totalTB.Text);
            totalTB.Text = Convert.ToString(totalPrice-priceToDeduce);
        }

        private void removeProduct_Click(object sender, EventArgs e)
        {
            Product itemToRemove = productList.SelectedItem as Product;
            productList.Items.Remove(itemToRemove);
            clearTextBoxes();
        }
        public void clearTextBoxes()
        {
            nameTB.Clear();
            categoryTB.Clear();
            priceTB.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дали сте сигурни?", "Испразни ја листата", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) cartList.Items.Clear();
            else;
        }

        private void removeProducts_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дали сте сигурни?", "Испразни ја листата", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) productList.Items.Clear();
            else;


        }
    }
}
