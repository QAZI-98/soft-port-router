using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;


namespace SPF_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpListener server1101;
        TcpListener server1102;
        TcpListener server1103;
        TcpListener server1104;
        TcpListener server1105;
        TcpListener server1106;
        TcpListener server1107;
        TcpListener server1108;

        TcpClient client1_instance;
        TcpClient client2_instance;
        TcpClient client3_instance;
        TcpClient client4_instance;
        TcpClient client5_instance;
        TcpClient client6_instance;
        TcpClient client7_instance;
        TcpClient client8_instance;

        bool c1_connected;
        bool c2_connected;
        bool c3_connected;
        bool c4_connected;
        bool c5_connected;
        bool c6_connected;
        bool c7_connected;
        bool c8_connected;

        byte[] arr;
        byte[] brr;
        byte[] crr;
        byte[] drr;
        byte[] err;
        byte[] frr;
        byte[] grr;
        byte[] hrr;


        NetworkStream nw1;
        NetworkStream nw2;
        NetworkStream nw3;
        NetworkStream nw4;
        NetworkStream nw5;
        NetworkStream nw6;
        NetworkStream nw7;
        NetworkStream nw8;



        public void set(Panel p1,Panel p2,Panel p3,Color c2)
        {
            p1.BackColor = Color.Green;
            p2.BackColor = c2;
            p3.BackColor = c2;
        }
        public void set(Panel p1, Panel p2, Color c2)
        {
            p1.BackColor = Color.Green;
            p2.BackColor = c2;
         }




        public void con(IAsyncResult ia)
        {
            TcpListener l = (TcpListener)ia.AsyncState;
            
            if (l.LocalEndpoint.ToString()=="127.0.0.1:1101")
            {
                arr = new byte[1024];
                client1_instance = l.EndAcceptTcpClient(ia);
                nw1 = client1_instance.GetStream();
                c1_connected = true;
                set(panel14, panel2, panel3,Color.FromArgb(102, 0, 102));
                nw1.BeginRead(arr, 0, arr.Length, new AsyncCallback(read1), nw1);
            }
            else if (l.LocalEndpoint.ToString() == "127.0.0.1:1102")
            {
                brr = new byte[1024];
                client2_instance = l.EndAcceptTcpClient(ia);
                nw2 = client2_instance.GetStream();
                c2_connected = true;
                set(panel17, panel5, panel4,Color.FromArgb(102, 0, 102));
                nw2.BeginRead(brr, 0, brr.Length, new AsyncCallback(read2), nw2);
            }
            else if (l.LocalEndpoint.ToString() == "127.0.0.1:1103")
            {
                crr = new byte[1024];
                client3_instance = l.EndAcceptTcpClient(ia);
                nw3 = client3_instance.GetStream();
                c3_connected = true;
                set(panel15, panel8,Color.Aqua);
                nw3.BeginRead(crr, 0, crr.Length, new AsyncCallback(read3), nw3);
            }
            else if (l.LocalEndpoint.ToString() == "127.0.0.1:1104")
            {
                drr = new byte[1024];
                client4_instance = l.EndAcceptTcpClient(ia);
                nw4 = client4_instance.GetStream();
                c4_connected = true;
                set(panel18, panel6, Color.Aqua);
                nw4.BeginRead(drr, 0, drr.Length, new AsyncCallback(read4), nw4);
            }
            else if (l.LocalEndpoint.ToString() == "127.0.0.1:1105")
            {
                err = new byte[1024];
                client5_instance = l.EndAcceptTcpClient(ia);
                nw5 = client5_instance.GetStream();
                c5_connected = true;
                set(panel21, panel7,Color.FromArgb(0, 179, 0));
                nw5.BeginRead(err, 0, err.Length, new AsyncCallback(read5), nw5);
            }
            else if (l.LocalEndpoint.ToString() == "127.0.0.1:1106")
            {
                frr = new byte[1024];
                client6_instance = l.EndAcceptTcpClient(ia);
                nw6 = client6_instance.GetStream();
                c6_connected = true;
                set(panel20,panel11, panel13,Color.FromArgb(0, 179, 0));
                nw6.BeginRead(frr, 0, frr.Length, new AsyncCallback(read6), nw6);
            }
            else if (l.LocalEndpoint.ToString() == "127.0.0.1:1107")
            {
                grr = new byte[1024];
                client7_instance = l.EndAcceptTcpClient(ia);
                nw7 = client7_instance.GetStream();
                c7_connected = true;
                set(panel16, panel10, panel9, Color.FromArgb(82, 122, 122));
                nw7.BeginRead(grr, 0, grr.Length, new AsyncCallback(read7), nw7);
            }
            else if (l.LocalEndpoint.ToString() == "127.0.0.1:1108")
            {
                hrr = new byte[1024];
                client8_instance = l.EndAcceptTcpClient(ia);
                nw8 = client8_instance.GetStream();
                c8_connected = true;
                set(panel19, panel12, Color.FromArgb(82, 122, 122));
                nw8.BeginRead(hrr, 0, hrr.Length, new AsyncCallback(read8), nw8);
            }
            
            else
            {
                MessageBox.Show("no con");
            }
        }

      

        public void read1(IAsyncResult obj)
        {
            try
            {
                
                NetworkStream ns = (NetworkStream)obj.AsyncState;
               
                int count = ns.EndRead(obj);
                textBox1.Text = Encoding.ASCII.GetString(arr, 0, arr.Length);
                if (c2_connected == true)
                {
                    NetworkStream ns2 =client2_instance.GetStream();
                    ns2.Write(arr, 0, arr.Length);
                    ns.Flush();

                }
                else
                {
                    MessageBox.Show("client not avilable");
                }
               
                ns.BeginRead(arr, 0, arr.Length, new AsyncCallback(read1), ns);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void read2(IAsyncResult obj)
        {
            try
            {

                NetworkStream ns = (NetworkStream)obj.AsyncState;
                int count = ns.EndRead(obj);
                textBox2.Text = Encoding.ASCII.GetString(brr, 0, brr.Length);

                if (c1_connected == true)
                {
                    NetworkStream ns2 = client1_instance.GetStream();
                     ns2.Write(brr, 0, brr.Length);
                    ns.Flush();
                }
                else
                {
                    MessageBox.Show("client not avilable");
                }
                
                ns.BeginRead(brr, 0, brr.Length, new AsyncCallback(read2), ns);
            }
            catch (Exception)
            {
                MessageBox.Show("client disconected");
            }
        }
        public void read3(IAsyncResult obj)
        {
            try
            {
                NetworkStream ns = (NetworkStream)obj.AsyncState;
                int count = ns.EndRead(obj);
                textBox3.Text = Encoding.ASCII.GetString(crr, 0, crr.Length);
                if (c4_connected == true)
                {
                    NetworkStream ns2 = client4_instance.GetStream();
                    ns2.Write(crr, 0, crr.Length);
                    ns.Flush();
                }
                else
                {
                    MessageBox.Show("client not avilable");
                }
                ns.BeginRead(crr, 0, crr.Length, new AsyncCallback(read3), ns);

            }
            catch (Exception)
            {
                MessageBox.Show("client disconected");
            }
        }
        public void read4(IAsyncResult obj)
        {
            try
            {
                NetworkStream ns = (NetworkStream)obj.AsyncState;
                int count = ns.EndRead(obj);
                textBox4.Text = Encoding.ASCII.GetString(drr, 0, drr.Length);
                if (c3_connected == true)
                {
                    NetworkStream ns2 = client3_instance.GetStream();
                    ns2.Write(drr, 0, drr.Length);
                    ns.Flush();
                }
                else
                {
                    MessageBox.Show("client not avilable");
                }
                ns.BeginRead(drr, 0, drr.Length, new AsyncCallback(read4), ns);


            }
            catch (Exception)
            {

                MessageBox.Show("client disconected");
            }


        }
        public void read5(IAsyncResult obj)
        {
            try
            {
                NetworkStream ns = (NetworkStream)obj.AsyncState;
                int count = ns.EndRead(obj);
                textBox5.Text = Encoding.ASCII.GetString(err, 0, err.Length);
                if (c6_connected == true)
                {
                    NetworkStream ns2 = client6_instance.GetStream();
                    ns2.Write(err, 0, err.Length);
                    ns.Flush();
                }
                else
                {
                    MessageBox.Show("client not avilable");
                }
                ns.BeginRead(err, 0, err.Length, new AsyncCallback(read5), ns);


            }
            catch (Exception)
            {

                MessageBox.Show("client disconected");
            }
        }
        public void read6(IAsyncResult obj)
        {
            try
            {
                NetworkStream ns = (NetworkStream)obj.AsyncState;
                int count = ns.EndRead(obj);
                textBox6.Text = Encoding.ASCII.GetString(frr, 0, frr.Length);
                if (c5_connected == true)
                {
                    NetworkStream ns2 = client5_instance.GetStream();
                    ns2.Write(frr, 0, frr.Length);
                    ns.Flush();
                }
                else
                {
                    MessageBox.Show("client not avilable");
                }
                ns.BeginRead(frr, 0, frr.Length, new AsyncCallback(read6), ns);


            }
            catch (Exception)
            {

                MessageBox.Show("client disconected");
            }
        }
        public void read7(IAsyncResult obj)
        {
            try
            {
                NetworkStream ns = (NetworkStream)obj.AsyncState;
                int count = ns.EndRead(obj);
                textBox7.Text = Encoding.ASCII.GetString(grr, 0, grr.Length);
                if (c8_connected == true)
                {
                    NetworkStream ns2 = client8_instance.GetStream();
                    ns2.Write(grr, 0, grr.Length);
                    ns.Flush();
                }
                else
                {
                    MessageBox.Show("client not avilable");
                }
                ns.BeginRead(grr, 0, grr.Length, new AsyncCallback(read7), ns);


            }
            catch (Exception)
            {

                MessageBox.Show("client disconected");
            }
        }
        public void read8(IAsyncResult obj)
        {
            try
            {
                NetworkStream ns = (NetworkStream)obj.AsyncState;
                int count = ns.EndRead(obj);
                textBox8.Text = Encoding.ASCII.GetString(hrr, 0, hrr.Length);
                if (c7_connected == true)
                {
                    NetworkStream ns2 = client7_instance.GetStream();
                    ns2.Write(hrr, 0, hrr.Length);
                    ns.Flush();
                }
                else
                {
                    MessageBox.Show("client not avilable");
                }
                ns.BeginRead(hrr, 0, hrr.Length, new AsyncCallback(read8), ns);


            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }




        public void send(TcpClient client,string s)
        {

            NetworkStream ns = client.GetStream();
            StreamWriter sw= new StreamWriter(ns);
            sw.WriteLine(s);
            sw.Flush();
        }





        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            server1101 = new TcpListener(IPAddress.Loopback, 1101);
            server1102 = new TcpListener(IPAddress.Loopback, 1102);
            server1103 = new TcpListener(IPAddress.Loopback, 1103);
            server1104 = new TcpListener(IPAddress.Loopback, 1104);
            server1105 = new TcpListener(IPAddress.Loopback, 1105);
            server1106 = new TcpListener(IPAddress.Loopback, 1106);
            server1107 = new TcpListener(IPAddress.Loopback, 1107);
            server1108 = new TcpListener(IPAddress.Loopback, 1108);
            server1101.Start(2);
            server1102.Start(2);
            server1103.Start(2);
            server1104.Start(2);
            server1105.Start(2);
            server1106.Start(2);
            server1107.Start(2);
            server1108.Start(2);

            server1101.BeginAcceptTcpClient(new AsyncCallback(con), server1101);
            server1102.BeginAcceptTcpClient(new AsyncCallback(con), server1102);
            server1103.BeginAcceptTcpClient(new AsyncCallback(con), server1103);
            server1104.BeginAcceptTcpClient(new AsyncCallback(con), server1104);
            server1105.BeginAcceptTcpClient(new AsyncCallback(con), server1105);
            server1106.BeginAcceptTcpClient(new AsyncCallback(con), server1106);
            server1107.BeginAcceptTcpClient(new AsyncCallback(con), server1107);
            server1108.BeginAcceptTcpClient(new AsyncCallback(con), server1108);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
