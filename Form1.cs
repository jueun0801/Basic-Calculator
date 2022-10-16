using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Assignment_5._1_Calculator
{
    public partial class Form1 : Form
    {
        decimal result= 0;
        String operation = "";
        bool isOperationPerformed = false;
        ICalculator calculator;
        
        public Form1()
        {
            InitializeComponent();
            //ICalculator calculator = new MathCls(); 
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            calculator = new MathCls();
            decimal result = 0;
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, btnClearEntry.Width, btnClearEntry.Height);
            gp.AddEllipse(0, 0, btnClear.Width, btnClear.Height);
            gp.AddEllipse(0, 0, btnBackSpace.Width, btnBackSpace.Height);
            gp.AddEllipse(0, 0, btnPlusMinus.Width, btnPlusMinus.Height);
            gp.AddEllipse(0, 0, btnDecimal.Width, btnDecimal.Height);
            btnClearEntry.Region = new Region(gp);
            btnClear.Region = new Region(gp);
            btnBackSpace.Region = new Region(gp);
            btnPlusMinus.Region = new Region(gp);
            btnDecimal.Region = new Region(gp);
            gp.Dispose();

        }

        /*private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
*/
        private void btnOne_Click(object sender, EventArgs e)
        {
            
            if (txtBoxResult.Text == "0" || isOperationPerformed)
                txtBoxResult.Clear();
           
            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")     //limiting decimal point
            {
                if (!txtBoxResult.Text.Contains("."))
                    txtBoxResult.Text = txtBoxResult.Text + button.Text;
            }
            else
            txtBoxResult.Text = txtBoxResult.Text + button.Text;
            
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (result != 0)
            {
                btnEquals.PerformClick();
                operation = button.Text;
                lblDisplay.Text = result + " " + operation;
                isOperationPerformed = true;
            }
            else
            {
                operation = button.Text;
                result = decimal.Parse(txtBoxResult.Text);
                lblDisplay.Text = result + " " + operation;
                isOperationPerformed = true;
            }
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtBoxResult.Text = "0";
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxResult.Text = "0";
            result = 0;
            lblDisplay.Text = "";
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "";
            //result = decimal.Parse(txtBoxResult.Text);
            switch (operation)
            {
                case "+":
                    txtBoxResult.Text= calculator.Add(decimal.Parse(txtBoxResult.Text), result).ToString();
                   // txtBoxResult.Text = (result + decimal.Parse(txtBoxResult.Text)).ToString();

                    break;
                case "-":
                    txtBoxResult.Text = calculator.Subtract(result, decimal.Parse(txtBoxResult.Text)).ToString(); 
                    break;
                case "*":
                    txtBoxResult.Text = calculator.Multiply(result, decimal.Parse(txtBoxResult.Text)).ToString(); 
                    break;
                case "÷":
                    /*try
                    {
                        decimal i;
                        decimal j;
                        decimal num3;
                        i= decimal.Parse(txtBoxResult.Text);
                        j= decimal.Parse(txtBoxResult.Text);
                        num3 = i / j;
                        txtBoxResult.Text = num3.ToString();
                    }
                    catch(DivideByZeroException ex)
                    {
                        lblDisplay.Text = "Error!";
                        MessageBox.Show("Divide by zero exception", ex.Message);
                    }*/
                    if (decimal.Parse(txtBoxResult.Text) != 0)
                    {
                        txtBoxResult.Text = calculator.Divide(result, decimal.Parse(txtBoxResult.Text)).ToString();
                        //lblDisplay.Text = "Error!";
                    }
                    else
                    {
                        txtBoxResult.Text = calculator.Divide(result, decimal.Parse(txtBoxResult.Text)).ToString();
                        
                        lblDisplay.Text = "Error!";
                        

                    }
                    break;
                default:
                    break;
                    txtBoxResult.Text = "";
                    result = decimal.Parse(txtBoxResult.Text);
            }

            result = decimal.Parse(txtBoxResult.Text);
            operation = "";
           
            isOperationPerformed = false;
            
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if(txtBoxResult.Text.Length > 0)
            {
                txtBoxResult.Text = txtBoxResult.Text.Remove(txtBoxResult.Text.Length - 1, 1);
            }
            if (txtBoxResult.Text == "")
            {
                txtBoxResult.Text = "0";
            }

        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            decimal p = decimal.Parse(txtBoxResult.Text);
            if (p < 0)
            txtBoxResult.Text = Convert.ToString(-1*p);
            else
                txtBoxResult.Text = Convert.ToString("-");

        }
    }
}
