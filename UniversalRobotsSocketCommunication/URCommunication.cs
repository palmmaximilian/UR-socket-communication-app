using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Net;
using System.Net.Sockets;

namespace UniversalRobotsSocketCommunication
{
    
    public partial class URCommunication : Form
    {
        private bool dashboardConnected = false;

        byte[] socketMessage = new byte[1024];

        // Establish the remote endpoint for the socket.  
        private static IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        private static IPAddress ipAddress = ipHostInfo.AddressList[0];
        private static IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

        // Create a TCP/IP  socket.  
        private static Socket dashBoardsender = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);



        public URCommunication()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!dashboardConnected)
            {
                dashboardOutput.AppendText($"Trying to connect to {dashboardIpInput.Text}\r\n");
                try
                {
                    dashBoardsender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    dashBoardsender.ReceiveTimeout = 200;
                    dashBoardsender.Connect(dashboardIpInput.Text, 29999);
                    dashboardConnected = true;
                    dashboardServerConnected.Checked = true;
                    dashboardOutput.AppendText($"Succesfully connected!\r\n");

                }
                catch
                { 
                    dashboardOutput.AppendText($"Connection Failed!\r\n");
                }

            }
            else
            {
                dashboardOutput.AppendText("Already connected! \r\n");
            }


        }

        private void sendDashboardCommand(string command)
        {
            if (dashboardConnected)
            {
                dashboardOutput.AppendText($"Sending Command: {command} \r\n");
                
                byte[] msg = Encoding.ASCII.GetBytes($"{command}\r\n");

                // Send the data through the socket.  
                int bytesSent = dashBoardsender.Send(msg);

                // Receive the response from the remote device.  
                try
                {
                    int bytesRec = dashBoardsender.Receive(socketMessage);
                    dashboardOutput.AppendText($"Response: {Encoding.ASCII.GetString(socketMessage, 0, bytesRec)}\r\n");

                }
                catch
                {
                    dashboardOutput.AppendText("No message received!\r\n");
                }
  
                
            }
            else
            {
                dashboardOutput.AppendText("Dashboard Server not connected!\r\n");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            sendDashboardCommand("play");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("pause");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dashboardConnected)
            {
                dashboardConnected = false;
                dashBoardsender.Close(); 
                dashboardOutput.AppendText("Dashboard Server Disconnected!\r\n");
                dashboardServerConnected.Checked = false;
            }
            else { dashboardOutput.AppendText("Not connected\r\n"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("clear operational mode");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("shutdown");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("stop");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("power on");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("power off");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("break release");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            dashboardOutput.Clear();
        }

        private void popup_Click(object sender, EventArgs e)
        {
            sendDashboardCommand($"popup \"{popopMessage.Text}\"");
        }

        private void custom_Click(object sender, EventArgs e)
        {
            sendDashboardCommand(customMessage.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("close safety popup");
        }

        private void unlockProtectiveStop_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("unlock protective stop");
        }

        private void dashboardIpInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
