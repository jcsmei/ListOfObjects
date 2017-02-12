using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListOfObjects
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<CellPhone> phoneList = new List<CellPhone>();
        //declaring a class level List WITHOUT initialization

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CellPhone somePhone = new CellPhone(); //instantiate CellPhone class
            //code to verify user inputs
            double p;
            if (double.TryParse(txtPrice.Text, out p) &&
                txtBrand.Text.Trim().Length>1 &&
                txtModel.Text.Trim().Length>0)
            {
                somePhone.Brand = txtBrand.Text; //inoput will work
                somePhone.Model = txtModel.Text;
                somePhone.Price = p;
                phoneList.Add(somePhone); //add to the List, PROCEDURAL level
                //phoneList[] class level
                lstPhones.Items.Add(somePhone.Brand + " " + somePhone.Model); //add to listbox
            }
            else
            {
                MessageBox.Show("Information incomplete or wrong. Phone not added");
                txtBrand.Focus();
                txtBrand.SelectAll();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int x = lstPhones.SelectedIndex;
            if (x != -1)
            {
                lstPhones.Items.RemoveAt(x); //remove the selected item
                phoneList.RemoveAt(x); //also remove from phone list
            }
        }

        private void lstPhones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = lstPhones.SelectedIndex; //check if item is selected
            if (x != -1)
            {
                rtbDisplay.Text = phoneList[x].PhoneInfo(); 
                //display price of selected item
            }
        }

        private void btnPractice_Click(object sender, EventArgs e)
        {
            List<CellPhone> myList = new List<CellPhone>();
            CellPhone phoneOne = new CellPhone(); //create an object and set its properties
            phoneOne.Brand = "iPhone";
            phoneOne.Model = "S6";
            phoneOne.Price = 699;
            myList.Add(phoneOne); //add to the list

            CellPhone phoneTwo = new CellPhone(); //add phone then set properties
            myList.Add(phoneTwo); //setting a list item's properties
            myList[1].Brand = "LG"; //assigne item to index 1 = 2nd item
            myList[1].Model = "G4"; //class level
            myList[1].Price = 600;
            rtbDisplay.Text = @"Either setting an object's properties before or after it is added to a lst is fine:
Phone1: " + phoneOne.PhoneInfo() + Environment.NewLine +
            "Phone2: " + phoneTwo.PhoneInfo();

            rtbDisplay.AppendText(Environment.NewLine + @"Inserting an item in a list: ");
            CellPhone phoneThree = new CellPhone();
            phoneThree.Brand = "Nokia";
            phoneThree.Model = "Lumia 3000";
            phoneThree.Price = 249;
            myList.Insert(1, phoneThree); //insert between first and second
            foreach (CellPhone x in myList)
            {
                rtbDisplay.AppendText(x.PhoneInfo() + Environment.NewLine);
            }
            rtbDisplay.AppendText(@"Removing an item from a list: ");
            myList.RemoveAt(0); //remove the FIRST item
            foreach (CellPhone x in myList)
            {
                rtbDisplay.AppendText(x.PhoneInfo() + Environment.NewLine);
            }
        }
    }
}
