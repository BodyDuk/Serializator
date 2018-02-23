using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        private string fileLocation;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label5.Text = "Erorrs: ";
                if (textBox2.Text == "")
                {
                    label4.Text = "fill in the field";
                }
                else
                {
                    BinarySerialization.Deserialize(fileLocation, textBox2.Text);
                }
            }catch(Exception ex)
            {
                label5.Text = ex.Message;
            }
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label5.Text = "Erorrs: ";
                if (textBox1.Text == "")
                {
                    label3.Text = "fill in the field";
                }
                else
                {
                    fileLocation = textBox1.Text;
                    BinarySerialization.SerializeTXT(textBox1.Text);
                }
            }
            catch (Exception ex)
            {
                label5.Text = ex.Message;
            }
}

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
