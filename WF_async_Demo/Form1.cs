using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_async_Demo
{

    public partial class Form1 : Form
    {
        public static string outp = "";

        public Form1()
        {     

            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (textBox1.Text == "")
            {
                if (outp != "") { textBox1.Text = outp; break; }
                if (backgroundWorker1.IsBusy != true)
                    backgroundWorker1.RunWorkerAsync(2000);
            }         
        }

        private void  backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Pinger pinger = new Pinger();
            pinger.PingOnet().Wait();
            MessageBox.Show(pinger.Output);
            outp = pinger.Output;
           
        }
    }
}
