﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weight_on_Mars
{
    public partial class Form1 : Form
    {
        public Form1 ()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!ValidateName(txtObject.Text, out string objectName, out string nameErrorMessage))
            {

                MessageBox.Show(nameErrorMessage, "Object Name Error");
                txtObject.Focus(); // Move focus to this TextBox for user to correct error
                return;  // stop processing this event
            }

            if (!ValidatePositiveDouble(txtWeightEarth.Text, out double earthWeight, out string weightErrorMessage))
            {
                MessageBox.Show(weightErrorMessage, "Earth Weight Error");
                txtWeightEarth.Focus();  // Move focus to this TextBox for user to correct error
                return;  // stop processing this event

            }
            double conversionFactor = 0.377;
            double marsWeight = earthWeight * conversionFactor;
            txtWeightMars.Text = String.Format("{0} weighs {1} on Mars", objectName, marsWeight);
        }

        private bool ValidateName(string text, out string name, out string errorMessage)
        {
            errorMessage = null;
            name = text;

            if (String.IsNullOrEmpty(text))
            {
                errorMessage = "Cant be empty";
                return false;
            }

            if (text.Length < 2)
            {
                errorMessage = "Enter at least 2 letter";
                return false;
            }
            return true;
        }


        private bool ValidatePositiveDouble(string text, out double number, out string errorMessage)
        {

            errorMessage = null;
            number = 0;

            try
            {
                number = double.Parse(text);

                if (number >= 0)
                {
                    return true;
                }
                else
                {
                    errorMessage = "Enter a positive number";
                    return false;
                }
            }
            catch (FormatException)
            {
                errorMessage = "Enter a number";
                return false;
            }
            catch (OverflowException)
            {
                errorMessage = "Enter a smaller number";
            }
            return false;
        }
    }
}

        

   



