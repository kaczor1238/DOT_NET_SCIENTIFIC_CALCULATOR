using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_NET
{
    public partial class Form1 : Form
    {

        Double result = 0;
        String no1,operation = "";
        bool enter_value = false;
     
        

        public Form1()
        {
            InitializeComponent();
            txtDisplay.ReadOnly = true;
            txtWynikMasa.ReadOnly = true;
            txtWynik.ReadOnly = true;
            txtDisplay.MaxLength = 33;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(420, 635);
            this.Width = 420;
            txtDisplay.Width = 378;
            this.lblShow.Location = new Point(280,72);
        }

        private void txtDispaly_TextChanged(object sender, EventArgs e)
        {

        }

        private void numbers_Only(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if ((txtDisplay.Text == "0") || (enter_value))
                txtDisplay.Text = "";
            enter_value = false;

            if (b.Text == ",")
            {
                if (!txtDisplay.Text.Contains(","))
                    txtDisplay.Text = txtDisplay.Text + b.Text;
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + b.Text;
            }

        }

        private void operators_Click(object sender, EventArgs e)
        {
            // dodawanie mnozenie dzielenie odejmowanie 
            Button b = (Button)sender;

            if (result != 0)
            {               
                enter_value = true;
                operation = b.Text;
                lblShow.Text = result + "  " + operation;
            }
            else
            {
                operation = b.Text;
                result = Double.Parse(txtDisplay.Text);
                txtDisplay.Text = "";
                lblShow.Text = Convert.ToString(result) + "  " + operation;
            }
        }

        private void ClearAll(object sender, EventArgs e)
        {
            // wyczysc wszystko
            txtDisplay.Text = "0";
            lblShow.Text = "";
            result = 0;

        }

        private void ClearOne(object sender, EventArgs e)
        {
            //zerowanie tego co wpisalismy
            txtDisplay.Text = "0";
            
        }

        private void Equals(object sender, EventArgs e)
        {
            lblShow.Text = "";
            switch (operation)
            {

                case "+":                    
                    txtDisplay.Text = (result + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (result - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "x":
                    txtDisplay.Text = (result * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    if (txtDisplay.Text == "0")
                    {
                        lblShow.Text = "Nie wolno dzielić przez 0 !";
                    }
                    else
                    {
                        txtDisplay.Text = (result / Double.Parse(txtDisplay.Text)).ToString();
                    }
                    break;
                case "Mod":
                    txtDisplay.Text = (result % Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case ("x^y"):
                    txtDisplay.Text = Convert.ToString(Math.Pow(Convert.ToDouble(no1)
                                  , Convert.ToDouble(txtDisplay.Text)));
                    break;
                default:
                    break;
            }
            result = Double.Parse(txtDisplay.Text);
            operation = "";
        }

        private void CalculatePowerOf2(object sender, EventArgs e)
        {
            //  do potegi 2 
            lblShow.Text = Convert.ToString((txtDisplay.Text) + "^2");
            txtDisplay.Text = Convert.ToString((Convert.ToDecimal(txtDisplay.Text) * Convert.ToDecimal(txtDisplay.Text)));
        }

        private void CalculateSqrt(object sender, EventArgs e)
        {
            // pierwiastkowanie kwadratowe
            lblShow.Text = Convert.ToString("Sqrt" + "(" + (txtDisplay.Text) + ")");
            txtDisplay.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(txtDisplay.Text)));            
        }

        private void ChangeOfSign(object sender, EventArgs e)
        {
            // zmiana znaku +/- 
            if (txtDisplay.Text.Contains("-"))
            {
                txtDisplay.Text = txtDisplay.Text.Remove(0, 1);
            }
            else
            {
                txtDisplay.Text = "-" + txtDisplay.Text;
            }

        }

        private void CalculatePercent(object sender, EventArgs e)
        {
            // obliczanie procentow
            Double a;

            a = Convert.ToDouble(txtDisplay.Text) / Convert.ToDouble(100);
            txtDisplay.Text = Convert.ToString(a);
        }

        private void CalculateFraction(object sender, EventArgs e)
        {
            //liczenie ulamkow
            if (txtDisplay.Text == "0")
            {
                lblShow.Text = "Wprowadź pierw liczbę";
            }
            else 
            txtDisplay.Text = Convert.ToString((Convert.ToDecimal(1) / Convert.ToDecimal(txtDisplay.Text)));
        }

        private void wybierzRodzajToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CalculateOct(object sender, EventArgs e)
        {
            int a = int.Parse(txtDisplay.Text);
            lblShow.Text = Convert.ToString("Oct" + "(" + (txtDisplay.Text) + ")");
            txtDisplay.Text = Convert.ToString(a, 8);
        }

        private void CalculatePi(object sender, EventArgs e)
        {
            txtDisplay.Text = Convert.ToString(3.1415926535899763);
        }
        // sinus
        private void CalculateSinus(object sender, EventArgs e)
        {
            double Sin = Double.Parse(txtDisplay.Text);
            lblShow.Text = Convert.ToString("Sin" + "(" + (txtDisplay.Text) + ")");
            Sin = Math.Sin(Sin);
            txtDisplay.Text = Convert.ToString(Sin);
        }

        private void standardowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(420, 635);
            this.Width = 420;
            txtDisplay.Width = 378;
            this.lblShow.Location = new Point(280, 72);
        }
        // cosinus
        private void CalculateCosinus(object sender, EventArgs e)
        {
            double cos = Double.Parse(txtDisplay.Text);
            lblShow.Text = Convert.ToString("Cos" + "(" + (txtDisplay.Text) + ")");
            cos = Math.Cos(cos);
            txtDisplay.Text = Convert.ToString(cos);
        }
        // tangens
        private void CalculateTangens(object sender, EventArgs e)
        {
            double tg = Double.Parse(txtDisplay.Text);
            lblShow.Text = Convert.ToString("Tg" + "(" + (txtDisplay.Text) + ")");
            tg = Math.Tan(tg);
            txtDisplay.Text = Convert.ToString(tg);
        }
        // logarytm10
        private void CalculateLog10(object sender, EventArgs e)
        {
            double ilog = Double.Parse(txtDisplay.Text);
            lblShow.Text = Convert.ToString("log" + "(" + (txtDisplay.Text) + ")");
            ilog = Math.Log10(ilog);
            txtDisplay.Text = Convert.ToString(ilog);
        }
        // dzielenie mod
        private void CalculateMod(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            operation = num.Text;
            result = Double.Parse(txtDisplay.Text);
            txtDisplay.Text = "";
            lblShow.Text = Convert.ToString(result) + " " + operation;
        }

        private void naukowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(750, 635);
            this.MinimumSize = new Size(750, 635);
            this.Width = 750;
            txtDisplay.Width = 709;
            this.lblShow.Location = new Point(610, 72);
        }

        private void CalculateDecimal(object sender, EventArgs e)
        {
            int a = int.Parse(txtDisplay.Text);
            lblShow.Text = Convert.ToString("Dec" + "(" + (txtDisplay.Text) + ")");
            txtDisplay.Text = Convert.ToString(a);
        }

        private void CalculateBinar(object sender, EventArgs e)
        {
            int a = int.Parse(txtDisplay.Text);
            lblShow.Text = Convert.ToString("Bin" + "(" + (txtDisplay.Text) + ")");
            txtDisplay.Text = Convert.ToString(a, 2);
        }

        private void CalculateHex(object sender, EventArgs e)
        {
            int a = int.Parse(txtDisplay.Text);
            lblShow.Text = Convert.ToString("Hex" + "(" + (txtDisplay.Text) + ")");
            txtDisplay.Text = Convert.ToString(a, 16);
        }
        // logarytm naturalny z x
        private void CalculateLogNaturalFromX(object sender, EventArgs e)
        {
            double ilog = Double.Parse(txtDisplay.Text);
            lblShow.Text = Convert.ToString("ln" + "(" + (txtDisplay.Text) + ")");
            ilog = Math.Log(ilog);
            txtDisplay.Text = Convert.ToString(ilog);
        }
        // x do potegi 3
        private void CalculatePowerOf3(object sender, EventArgs e)
        {
            Double a;

            a = Convert.ToDouble(txtDisplay.Text) * Convert.ToDouble(txtDisplay.Text) * Convert.ToDouble(txtDisplay.Text);
            lblShow.Text = Convert.ToString(txtDisplay.Text + "^3");
            txtDisplay.Text = Convert.ToString(a);
        }
        // przesuniecie bitowe
        private void button37_Click(object sender, EventArgs e)
        {
            enter_value = true;
            if (txtDisplay.Text == "")
            {
                return;
            }
            else
            {
                no1 = txtDisplay.Text;
                txtDisplay.Text = "";
            }
        }

        private void CalculateConstEulera(object sender, EventArgs e)
        {
            txtDisplay.Text = Convert.ToString(2.7182818284590452);
        }

        // silnia
        private void CalculateSilnia(object sender, EventArgs e)
        {
            BigInteger big = new BigInteger();
            big = 1;
            for (int i = 1; i <= Convert.ToInt16(txtDisplay.Text); i++)
            {
                big = big * i;
            }
            lblShow.Text = Convert.ToString((txtDisplay.Text) + "!");
            txtDisplay.Text = Convert.ToString(big);
            enter_value = false;
        }
        // wartośc bezwzgledna
        private void CalculateAbsoluteValue(object sender, EventArgs e)
        {
            double abs = Double.Parse(txtDisplay.Text);
            lblShow.Text = Convert.ToString("abs" + "(" + (txtDisplay.Text) + ")");
            abs = Math.Abs(abs);
            txtDisplay.Text = Convert.ToString(abs);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate =
                    (DateTime)dateTimePicker1.Value;

                DateTime endDate =
                    (DateTime)dateTimePicker2.Value;

                TimeSpan ts = endDate.Subtract(startDate);

                resultDays.Text = ts.Days.ToString();               

            }
            catch
            {

            }
        }
       
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate =
                    (DateTime)dateTimePicker1.Value;

                DateTime endDate =
                    (DateTime)dateTimePicker2.Value;

                TimeSpan ts = endDate.Subtract(startDate);

                resultDays.Text = ts.Days.ToString();               

            }
            catch
            {

            }
        }
        
        private void obliczanieDatyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(1000, 635);
            this.MinimumSize = new Size(1000, 635);
            this.Width = 1000;
            txtDisplay.Width = 709;
            this.lblShow.Location = new Point(610, 72);
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            lblTBConvert.Visible = false;
            txtDoZmiany.Visible = false;
            lbllb1.Visible = false;
            lbllb2.Visible = false;
            cmbFrom.Visible = false;
            cmbTo.Visible = false;
            lblTBWynik.Visible = false;
            txtWynik.Visible = false;
            btnConvert.Visible = false;
            txtDoZmianyMasa.Visible = false;
            txtWynikMasa.Visible = false;
            cmbFromMasa.Visible = false;
            cmbToMasa.Visible = false;
            btnConvertMasa.Visible = false;
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void obliczanieDługościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtDoZmiany.Text = "";
            txtWynik.Text = "";
            this.MaximumSize = new Size(1000, 635);
            this.MinimumSize = new Size(1000, 635);
            this.Width = 1000;
            txtDisplay.Width = 709;
            this.lblShow.Location = new Point(610, 72);
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            lblTBConvert.Visible = true;
            txtDoZmiany.Visible = true;
            lbllb1.Visible = true;
            lbllb2.Visible = true;
            cmbFrom.Visible = true;
            cmbTo.Visible = true;
            lblTBWynik.Visible = true;
            txtWynik.Visible = true;
            btnConvert.Visible = true;
            txtDoZmianyMasa.Visible = false;
            txtWynikMasa.Visible = false;
            cmbFromMasa.Visible = false;
            cmbToMasa.Visible = false;
            btnConvertMasa.Visible = false;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (cmbFrom.Text == "Wybierz jednostkę" || cmbTo.Text == "Wybierz jednostkę")
            {
                MessageBox.Show("Wybierz jednostkę do zamiany");
            }
            else
            {
                if (cmbFrom.SelectedItem == "Milimetry" && cmbTo.Text == "Milimetry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 1);
                }
                if (cmbFrom.SelectedItem == "Milimetry" && cmbTo.Text == "Centymetry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) / 10);
                }
                if (cmbFrom.SelectedItem == "Milimetry" && cmbTo.Text == "Metry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) / 1000);
                }
                if (cmbFrom.SelectedItem == "Milimetry" && cmbTo.Text == "Kilometry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) / 1000000);
                }
                if (cmbFrom.SelectedItem == "Milimetry" && cmbTo.Text == "Cale")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 0.03937008);
                }
                if (cmbFrom.SelectedItem == "Milimetry" && cmbTo.Text == "Jardy")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 0.00109361);
                }

                if (cmbFrom.SelectedItem == "Centymetry" && cmbTo.Text == "Milimetry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 10);
                }
                if (cmbFrom.SelectedItem == "Centymetry" && cmbTo.Text == "Centymetry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 1);
                }
                if (cmbFrom.SelectedItem == "Centymetry" && cmbTo.Text == "Metry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) / 100);
                }
                if (cmbFrom.SelectedItem == "Centymetry" && cmbTo.Text == "Kilometry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) / 100000);
                }
                if (cmbFrom.SelectedItem == "Centymetry" && cmbTo.Text == "Cale")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 0.3937008);
                }
                if (cmbFrom.SelectedItem == "Centymetry" && cmbTo.Text == "Jardy")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 0.0109361);
                }

                if (cmbFrom.SelectedItem == "Metry" && cmbTo.Text == "Milimetry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 1000);
                }
                if (cmbFrom.SelectedItem == "Metry" && cmbTo.Text == "Centymetry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 100);
                }
                if (cmbFrom.SelectedItem == "Metry" && cmbTo.Text == "Metry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 1);
                }
                if (cmbFrom.SelectedItem == "Metry" && cmbTo.Text == "Kilometry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) / 1000);
                }
                if (cmbFrom.SelectedItem == "Metry" && cmbTo.Text == "Cale")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 39.37008);
                }
                if (cmbFrom.SelectedItem == "Metry" && cmbTo.Text == "Jardy")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 1.09361);
                }

                if (cmbFrom.SelectedItem == "Kilometry" && cmbTo.Text == "Milimetry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 1000000);
                }
                if (cmbFrom.SelectedItem == "Kilometry" && cmbTo.Text == "Centymetry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 100000);
                }
                if (cmbFrom.SelectedItem == "Kilometry" && cmbTo.Text == "Metry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 1000);
                }
                if (cmbFrom.SelectedItem == "Kilometry" && cmbTo.Text == "Kilometry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 1);
                }
                if (cmbFrom.SelectedItem == "Kilometry" && cmbTo.Text == "Cale")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 39370.08);
                }
                if (cmbFrom.SelectedItem == "Kilometry" && cmbTo.Text == "Jardy")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 1093.61);
                }

                if (cmbFrom.SelectedItem == "Cale" && cmbTo.Text == "Milimetry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 25.4);
                }
                if (cmbFrom.SelectedItem == "Cale" && cmbTo.Text == "Centymetry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 2.54);
                }
                if (cmbFrom.SelectedItem == "Cale" && cmbTo.Text == "Metry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 0.0254);
                }
                if (cmbFrom.SelectedItem == "Cale" && cmbTo.Text == "Kilometry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) / 10000000);
                }
                if (cmbFrom.SelectedItem == "Cale" && cmbTo.Text == "Cale")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 1);
                }
                if (cmbFrom.SelectedItem == "Cale" && cmbTo.Text == "Jardy")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 0.0277778);
                }

                if (cmbFrom.SelectedItem == "Jardy" && cmbTo.Text == "Milimetry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 914.4);
                }
                if (cmbFrom.SelectedItem == "Jardy" && cmbTo.Text == "Centymetry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 91.44);
                }
                if (cmbFrom.SelectedItem == "Jardy" && cmbTo.Text == "Metry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 0.9144);
                }
                if (cmbFrom.SelectedItem == "Jardy" && cmbTo.Text == "Kilometry")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 0.0009144);
                }
                if (cmbFrom.SelectedItem == "Jardy" && cmbTo.Text == "Cale")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 36);
                }
                if (cmbFrom.SelectedItem == "Jardy" && cmbTo.Text == "Jardy")
                {
                    txtWynik.Text = Convert.ToString(Convert.ToDouble(txtDoZmiany.Text) * 1);
                }

            }
        }

        private void CalculateEPowerX(object sender, EventArgs e)
        {
            double iexp = Double.Parse(txtDisplay.Text);
            lblShow.Text = Convert.ToString("e^" + (txtDisplay.Text));
            iexp = Math.Exp(iexp);
            txtDisplay.Text = Convert.ToString(iexp);
        }

        private void obliczanieMasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtDoZmiany.Text = "";
            txtWynik.Text = "";
            this.MaximumSize = new Size(1000, 635);
            this.MinimumSize = new Size(1000, 635);
            this.Width = 1000;
            txtDisplay.Width = 709;
            this.lblShow.Location = new Point(610, 72);
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            lblTBConvert.Visible = true;
            txtDoZmiany.Visible = false;
            lbllb1.Visible = true;
            lbllb2.Visible = true;
            cmbFrom.Visible = false;
            cmbTo.Visible = false;
            lblTBWynik.Visible = true;
            txtWynik.Visible = false;
            btnConvert.Visible = false;
            txtDoZmianyMasa.Visible = true;
            txtWynikMasa.Visible = true;
            cmbFromMasa.Visible = true;
            cmbToMasa.Visible = true;
            btnConvertMasa.Visible = true;
        }

        private void btnConvertMasa_Click(object sender, EventArgs e)
        {
            if (cmbFromMasa.Text == "Wybierz jednostkę" || cmbToMasa.Text == "Wybierz jednostkę")
            {
                MessageBox.Show("Wybierz jednostkę do zamiany");
            } else
            {
                if (cmbFromMasa.SelectedItem == "Gramy" && cmbToMasa.SelectedItem =="Gramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 1);
                }
                if (cmbFromMasa.SelectedItem == "Gramy" && cmbToMasa.SelectedItem == "Dekagramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) / 10);
                }
                if (cmbFromMasa.SelectedItem == "Gramy" && cmbToMasa.SelectedItem == "Kilogramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) / 1000);
                }
                if (cmbFromMasa.SelectedItem == "Gramy" && cmbToMasa.SelectedItem == "Tony")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 0.000001);
                }
                if (cmbFromMasa.SelectedItem == "Gramy" && cmbToMasa.SelectedItem == "Uncje")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 0.035274);
                }
                if (cmbFromMasa.SelectedItem == "Gramy" && cmbToMasa.SelectedItem == "Funty")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 0.00220462);
                }

                if (cmbFromMasa.SelectedItem == "Dekagramy" && cmbToMasa.SelectedItem == "Gramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 10);
                }
                if (cmbFromMasa.SelectedItem == "Dekagramy" && cmbToMasa.SelectedItem == "Dekagramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 1);
                }
                if (cmbFromMasa.SelectedItem == "Dekagramy" && cmbToMasa.SelectedItem == "Kilogramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) / 100);
                }
                if (cmbFromMasa.SelectedItem == "Dekagramy" && cmbToMasa.SelectedItem == "Tony")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) / 100000);
                }
                if (cmbFromMasa.SelectedItem == "Dekagramy" && cmbToMasa.SelectedItem == "Uncje")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 0.35274);
                }
                if (cmbFromMasa.SelectedItem == "Dekagramy" && cmbToMasa.SelectedItem == "Funty")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 0.0220462);
                }

                if (cmbFromMasa.SelectedItem == "Kilogramy" && cmbToMasa.SelectedItem == "Gramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 1000);
                }
                if (cmbFromMasa.SelectedItem == "Kilogramy" && cmbToMasa.SelectedItem == "Dekagramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 100);
                }
                if (cmbFromMasa.SelectedItem == "Kilogramy" && cmbToMasa.SelectedItem == "Kilogramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 1);
                }
                if (cmbFromMasa.SelectedItem == "Kilogramy" && cmbToMasa.SelectedItem == "Tony")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) / 1000);
                }
                if (cmbFromMasa.SelectedItem == "Kilogramy" && cmbToMasa.SelectedItem == "Uncje")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 35.274);
                }
                if (cmbFromMasa.SelectedItem == "Kilogramy" && cmbToMasa.SelectedItem == "Funty")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 2.20462);
                }

                if (cmbFromMasa.SelectedItem == "Tony" && cmbToMasa.SelectedItem == "Gramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 1000);
                }
                if (cmbFromMasa.SelectedItem == "Tony" && cmbToMasa.SelectedItem == "Dekagramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 100);
                }
                if (cmbFromMasa.SelectedItem == "Tony" && cmbToMasa.SelectedItem == "Kilogramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 1000);
                }
                if (cmbFromMasa.SelectedItem == "Tony" && cmbToMasa.SelectedItem == "Tony")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 1);
                }
                if (cmbFromMasa.SelectedItem == "Tony" && cmbToMasa.SelectedItem == "Uncje")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 35.274);
                }
                if (cmbFromMasa.SelectedItem == "Tony" && cmbToMasa.SelectedItem == "Funty")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 2.20462);
                }

                if (cmbFromMasa.SelectedItem == "Uncje" && cmbToMasa.SelectedItem == "Gramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 28.3495);
                }
                if (cmbFromMasa.SelectedItem == "Uncje" && cmbToMasa.SelectedItem == "Dekagramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 2.83495);
                }
                if (cmbFromMasa.SelectedItem == "Uncje" && cmbToMasa.SelectedItem == "Kilogramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 0.0283495);
                }
                if (cmbFromMasa.SelectedItem == "Uncje" && cmbToMasa.SelectedItem == "Tony")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 0.0000283);
                }
                if (cmbFromMasa.SelectedItem == "Uncje" && cmbToMasa.SelectedItem == "Uncje")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 35.274);
                }
                if (cmbFromMasa.SelectedItem == "Uncje" && cmbToMasa.SelectedItem == "Funty")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 0.0625);
                }


                if (cmbFromMasa.SelectedItem == "Funty" && cmbToMasa.SelectedItem == "Gramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 453.5924);
                }
                if (cmbFromMasa.SelectedItem == "Funty" && cmbToMasa.SelectedItem == "Dekagramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 45.35924);
                }
                if (cmbFromMasa.SelectedItem == "Funty" && cmbToMasa.SelectedItem == "Kilogramy")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 0.453592);
                }
                if (cmbFromMasa.SelectedItem == "Funty" && cmbToMasa.SelectedItem == "Tony")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 0.0004536);
                }
                if (cmbFromMasa.SelectedItem == "Funty" && cmbToMasa.SelectedItem == "Uncje")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 16);
                }
                if (cmbFromMasa.SelectedItem == "Funty" && cmbToMasa.SelectedItem == "Funty")
                {
                    txtWynikMasa.Text = Convert.ToString(Convert.ToDouble(txtDoZmianyMasa.Text) * 1);
                }
            }
        }

        // potega dziesiatki
        private void CalculatePow10(object sender, EventArgs e)
        {
            double dych = Double.Parse(txtDisplay.Text);
            lblShow.Text = Convert.ToString("10^" + txtDisplay.Text);
            dych = Math.Pow(10,dych);
            txtDisplay.Text = Convert.ToString(dych);
        }

        private void Backspace(object sender, EventArgs e)
        {
            // bakspace
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }

            if (txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }
        }
    }
}
