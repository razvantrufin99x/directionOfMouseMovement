using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace directionOfMouseMovement
{
    public partial class Consola : Form
    {
        public Consola()
        {
            InitializeComponent();
        }

        public int write(string s, string op)
        {
            if (op == "ADD")
            {
                this.textBox1.Text += s + "\r\n";
                return 0;
            }
            else if (op == "w")
            {
                this.textBox1.Text = s + "\r\n";
                return 0;
            }
            return 0;
        }

        private void Consola_Load(object sender, EventArgs e)
        {

        }
    }
}
