using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace ComputerToArduino
{
    public partial class Form1 : Form

    {
        bool isConnected = false;
        String[] ports;
        SerialPort port;

        public Form1()
        {
            InitializeComponent();
            disableControls();
            getAvailableComPorts();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }
            else
            {
                disconnectFromArduino();
            }
        }

        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        private void connectToArduino()
        {
            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            //port.Write("#STAR\n");
            button1.Text = "Disconnect";
            enableControls();
        }

        private void Led1CheckboxClicked(object sender, EventArgs e)

        {
            if (isConnected)
            {
                if (checkBox1.Checked)
                {
                    port.Write("1\n");
                }
                else
                {
                    port.Write("0\n");
                }
            }
        }

        private void Led2CheckboxClicked(object sender, EventArgs e)

        {
            if (isConnected)
            {
                if (checkBox2.Checked)
                {
                    port.Write("2\n");
                }
                else
                {
                    port.Write("6\n");
                }
            }
        }

        private void Led3CheckboxClicked(object sender, EventArgs e)

        {
            if (isConnected)
            {
                if (checkBox3.Checked)
                {
                    port.Write("3\n");
                }
                else
                {
                    port.Write("7\n");
                }
            }
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Write("/\n");
            port.Close();
            button1.Text = "Connect";
            disableControls();
            resetDefaults();
        }



        private void enableControls()
        {
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;


            groupBox1.Enabled = true;


        }

        private void disableControls()
        {
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;

            groupBox1.Enabled = false;

        }

        private void resetDefaults()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (checkBox6.Checked)
                {
                    port.Write("/\n");
                    resetDefaults();
                }
                else
                {

                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (checkBox5.Checked)
                {
                    port.Write("5\n");
                }
                else
                {
                    port.Write("9\n");
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (isConnected)
            {
                if (checkBox4.Checked)
                {
                    port.Write("4\n");
                }
                else
                {
                    port.Write("8\n");
                }
            }
        }
    }
}
