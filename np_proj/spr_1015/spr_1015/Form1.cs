using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spr_1015
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient client = new TcpClient();
        NetworkStream ns;
        byte[] arr;
        public void read(IAsyncResult obj)
        {
            try
            {
                NetworkStream ns = (NetworkStream)obj.AsyncState;
                int count = ns.EndRead(obj);
                listBox1.Items.Add(Encoding.ASCII.GetString(arr, 0, arr.Length));
                ns.BeginRead(arr, 0, arr.Length, new AsyncCallback(read), ns);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            IPEndPoint ep = new IPEndPoint(IPAddress.Loopback, 1105);
            client.Connect(ep);
            ns = client.GetStream();
            arr = new byte[1024];
            ns.BeginRead(arr, 0, arr.Length, new AsyncCallback(read), ns);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NetworkStream nss = client.GetStream();
            StreamWriter sw = new StreamWriter(nss);
            sw.WriteLine(textBox1.Text);
            sw.Flush();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NetworkStream nss = client.GetStream();
            StreamWriter sw = new StreamWriter(nss);
            sw.WriteLine(textBox1.Text);
            sw.Flush();

        }
    }
}
