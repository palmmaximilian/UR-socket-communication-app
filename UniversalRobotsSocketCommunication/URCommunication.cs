using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace UniversalRobotsSocketCommunication
{


    public partial class URCommunication : Form
    {

        byte[] socketMessage = new byte[1024];

        // Establish the remote endpoint for the socket.  
        private static IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        private static IPAddress ipAddress = ipHostInfo.AddressList[0];
        private static IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

        // Create a TCP/IP  socket.  
        private static Socket dashboardSender = null;





        public URCommunication()
        {
            InitializeComponent();
            foreach (var ipAddress in ipHostInfo.AddressList)
            {
                comboBox1.Items.Add(ipAddress);
            }
            comboBox1.SelectedIndex = 0;
            InitDashboardTimer();
            InitPrimaryTab();
        }


        //Dashboard Tab
        private Timer dashboardTimer;
        private bool dashboardConnected = false;
        private void InitDashboardTimer()
        {
            dashboardTimer = new Timer();
            dashboardTimer.Tick += new EventHandler(DashboardTimer_Tick);
            dashboardTimer.Interval = 100; // in miliseconds
        }

        private void DashboardTimer_Tick(object sender, EventArgs e)
        {
            if (dashboardConnected)
            {
                int bytesRec = 0;
                // Receive the response from the remote device.  
                try
                {

                    bytesRec = dashboardSender.Receive(socketMessage);
                    if (bytesRec > 0)
                    {
                        dashboardOutput.AppendText($"Response: {Encoding.ASCII.GetString(socketMessage, 0, bytesRec)}\r\n");
                    }
                }
                catch (Exception ex)
                {

                }

                try
                {
                    byte[] msg = Encoding.ASCII.GetBytes($"get operational mode\r\n");
                    int bytesSent = dashboardSender.Send(msg);
                    bytesRec = dashboardSender.Receive(socketMessage);
                    textBox1.Text = Encoding.ASCII.GetString(socketMessage, 0, bytesRec);

                    msg = Encoding.ASCII.GetBytes($"programState\r\n");
                    bytesSent = dashboardSender.Send(msg);
                    bytesRec = dashboardSender.Receive(socketMessage);
                    textBox2.Text = Encoding.ASCII.GetString(socketMessage, 0, bytesRec);

                    msg = Encoding.ASCII.GetBytes($"robotmode\r\n");
                    bytesSent = dashboardSender.Send(msg);
                    bytesRec = dashboardSender.Receive(socketMessage);
                    textBox3.Text = Encoding.ASCII.GetString(socketMessage, 0, bytesRec);

                    msg = Encoding.ASCII.GetBytes($"safetystatus\r\n");
                    bytesSent = dashboardSender.Send(msg);
                    bytesRec = dashboardSender.Receive(socketMessage);
                    textBox4.Text = Encoding.ASCII.GetString(socketMessage, 0, bytesRec);
                }
                catch (Exception ex)
                { }

            }
        }

        private void sendDashboardCommand(string command)
        {
            if (dashboardConnected)
            {
                dashboardOutput.AppendText($"Sending Command: {command} \r\n");

                byte[] msg = Encoding.ASCII.GetBytes($"{command}\r\n");

                // Send the data through the socket.  
                int bytesSent = dashboardSender.Send(msg);
            }
            else
            {
                dashboardOutput.AppendText("Dashboard Server not connected!\r\n");
            }
        }

        private void DashboardConnect_Click(object sender, EventArgs e)
        {
            if (!dashboardConnected)
            {

                dashboardTimer.Start();
                dashboardOutput.AppendText($"Trying to connect to {dashboardIpInput.Text}\r\n");
                try
                {
                    Console.WriteLine(ipAddress);
                    dashboardSender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    dashboardSender.ReceiveTimeout = 200;
                    dashboardSender.Connect(dashboardIpInput.Text, 29999);
                    dashboardServerConnected.Checked = true;
                    dashboardConnected = true;
                    dashboardOutput.AppendText($"Succesfully connected!\r\n");


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    dashboardOutput.AppendText($"Connection Failed!\r\n");
                }



            }
            else
            {
                dashboardOutput.AppendText("Already connected! \r\n");
            }
        }

        private void DashboardPowerOn_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("power on");
        }

        private void DashboardPowerOff_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("power off");
        }

        private void DashboardBrakeRelease_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("brake release");
        }

        private void DashboardPopup_Click(object sender, EventArgs e)
        {
            sendDashboardCommand($"popup {DashboardPopopMessage.Text}");
        }

        private void DashboardClosePopup_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("close popup");
        }

        private void DashboardDisconnect_Click(object sender, EventArgs e)
        {
            if (dashboardConnected)
            {

                dashboardConnected = false;
                dashboardSender.Close();
                dashboardTimer.Stop();
                dashboardOutput.AppendText("Dashboard Server Disconnected!\r\n");
                dashboardServerConnected.Checked = false;
            }
            else { dashboardOutput.AppendText("Not connected\r\n"); }
        }

        private void DashboardClear_Click(object sender, EventArgs e)
        {
            dashboardOutput.Clear();
        }

        private void DashboardSetOperational_Click(object sender, EventArgs e)
        {
            sendDashboardCommand($"set operational mode {DashboardOperationalSelection.Text}");
        }

        private void DashboardClearOperational_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("clear operational mode");
        }

        private void DashboardPlay_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("play");
        }

        private void DashboardPause_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("pause");
        }

        private void DashboardStop_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("stop");
        }

        private void DashboardShutdown_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("shutdown");
        }

        private void DashboardUnlockProtective_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("unlock protective stop");
        }

        private void DashboardCloseSafety_Click(object sender, EventArgs e)
        {
            sendDashboardCommand("close safety popup");
        }

        private void DashboardCustom_Click(object sender, EventArgs e)
        {
            sendDashboardCommand(DashboardCustomMessage.Text);
        }

        //Primary Tab

        // Create a TCP/IP  socket.  
        private static Socket primarySender = null;

        private bool primaryConnected = false;
        private Timer primaryTimer;

        bool updating = false;
        bool setting = false;


        IEnumerable digitalInput = new BitArray(8);
        IEnumerable digitalOutput = new BitArray(8);
        IEnumerable ConfigOutput = new BitArray(8);
        IEnumerable ConfigInput = new BitArray(8);
        // 0=Voltage, 1=Current
        int analogInRange0 = 1;
        int analogInRange1 = 1;
        int analogOutRange0 = 1;
        int analogOutRange1 = 1;

        double analogIn0 = 0;
        double analogIn1 = 0;
        double analogOut0 = 0;
        double analogOut1 = 0;

        private void InitPrimaryTab()
        {
            analogIn0Mode.Text = "0V-10V";
            analogIn1Mode.Text = "0V-10V";
            analogOut0Mode.Text = "0V-10V";
            analogOut1Mode.Text = "0V-10V";
            analogIn0Label.Text = analogIn0.ToString() + "V";
            analogIn1Label.Text = analogIn1.ToString() + "V";
            analogOut0Label.Text = analogOut0.ToString() + "V";
            analogOut1Label.Text = analogOut1.ToString() + "V";

            analogOut0Combobox.SelectedIndex = analogOutRange0-1;
            analogOut1Combobox.SelectedIndex = analogOutRange1-1;
            InitPrimaryTimer();
        }


        
        private void InitPrimaryTimer()
        {
            primaryTimer = new Timer();
            primaryTimer.Tick += new EventHandler(PrimaryTimer_Tick);
            primaryTimer.Interval = 10; // in miliseconds
            
        }

        private void DecodeMasterboardData(byte[] msg)
        {


            digitalInput = new BitArray(new[] { msg[3] });
            ConfigInput = new BitArray(new[] { msg[2] });
            digitalOutput = new BitArray(new[] { msg[7] });
            ConfigOutput = new BitArray(new[] { msg[6] });
            analogInRange0 = (int)msg[8];
            analogInRange1 = (int)msg[9];
            analogOutRange0 = (int)msg[26];
            analogOutRange1 = (int)msg[27];

            byte[] data = msg.Skip(10).Take(8).ToArray();
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            analogIn0 = System.BitConverter.ToDouble(data, 0);

            data = msg.Skip(18).Take(8).ToArray();
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            analogIn1 = System.BitConverter.ToDouble(data, 0);

            data = msg.Skip(28).Take(8).ToArray();
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            analogOut0 = System.BitConverter.ToDouble(data, 0);

            data = msg.Skip(36).Take(8).ToArray();
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data);
            analogOut1 = System.BitConverter.ToDouble(data, 0);

        }

        private void UpdateLabels()
        {
            //Updating IO
            int j = 0;
            foreach (var i in digitalOutput)
            {
                primeryDigitalOut.SetItemChecked(j, (bool)i);
                j++;
            }
            j = 0;
            foreach (var i in digitalInput)
            {
                primeryDI.SetItemChecked(j, (bool)i);
                j++;
            }
            j = 0;
            foreach (var i in ConfigInput)
            {
                primaryConfigInput.SetItemChecked(j, (bool)i);
                j++;
            }
            j = 0;
            foreach (var i in ConfigOutput)
            {
                primaryConfigOutput.SetItemChecked(j, (bool)i);
                j++;
            }


            //Updating Analog Values
            analogOut0Combobox.SelectedIndex = analogOutRange0 ;
            analogOut1Combobox.SelectedIndex = analogOutRange1 ;

            if (analogOutRange0 == 0)
            {
                analogOut0Mode.Text = "4mA - 20mA";
                analogOut0Label.Text = string.Format("{0:N2}", analogOut0 * 1000) + "mA";
                sliderAnalogOut0.Value = (int)ScaleValues(analogOut0, 0.004f, 0.02f, 0f, 100f);
            }
            else
            {
                analogOut0Mode.Text = "0V - 10V";
                analogOut0Label.Text = string.Format("{0:N2}", analogOut0) + "V";
                sliderAnalogOut0.Value = (int)(analogOut0*10f);


            }
            if (analogOutRange1 == 0)
            {
                analogOut1Mode.Text = "4mA - 20mA";
                analogOut1Label.Text = string.Format("{0:N2}", analogOut1 * 1000) + "mA";
                sliderAnalogOut1.Value = (int)ScaleValues(analogOut1, 0.004f, 0.02f, 0f, 100f);
            }
            else
            {
                analogOut1Mode.Text = "0V - 10V";
                analogOut1Label.Text = string.Format("{0:N2}", analogOut1) + "V";
                sliderAnalogOut1.Value = (int)(analogOut1 * 10f);

            }
            
            
            if (analogInRange0 == 0)
            {
                analogIn0Mode.Text = "4mA - 20mA";
                analogIn0Label.Text = string.Format("{0:N2}", analogIn0 * 1000) + "mA";
                sliderAnalogIn0.Value = (int)ScaleValues(analogIn0, 0.004f, 0.02f, 0f, 100f);
            }
            else
            {
                analogIn0Mode.Text = "0V - 10V";
                analogIn0Label.Text = string.Format("{0:N2}", analogIn0) + "V";
                sliderAnalogIn0.Value = (int)(analogIn0 * 10f);

            }

            if (analogInRange1 == 0)
            {
                analogIn1Mode.Text = "4mA - 20mA";
                analogIn1Label.Text = string.Format("{0:N2}", analogIn1 * 1000) + "mA";
                sliderAnalogIn1.Value = (int)ScaleValues(analogIn1, 0.004f, 0.02f, 0f, 100f);
            }
            else
            {
                analogIn1Mode.Text = "0V - 10V";
                analogIn1Label.Text = string.Format("{0:N2}", analogIn1) + "V";
                sliderAnalogIn1.Value = (int)(analogIn1 * 10f);

            }
           

        }

        private void DecodePrimaryResponse(byte[] socketMessage)
        {
            byte[] size = { socketMessage[0], socketMessage[1], socketMessage[2], socketMessage[3] };
            if (BitConverter.IsLittleEndian)
                Array.Reverse(size);
            int msgSize = BitConverter.ToInt32(size, 0);
            //Console.WriteLine(msgSize);

            int msgType = (int)socketMessage[4];

            //Message Types
            {/* Message Type
             * 0= Robot mode data
             * 1= Joint data (Sub Package of Robot State Message)
             * 2= Tool data (Sub Package of Robot State Message)
             * 3= Masterboard data (Sub Package of Robot State Message)
             * 4= Cartesian info (Sub Package of Robot State Message)
             * 5= Kinematics info (Sub Package of Robot State Message)
             * 6= Configuration data (Sub Package of Robot State Message)
             * 7= Force mode data (Sub Package of Robot State Message)
             * 8= Additional info (Sub Package of Robot State Message)
             * 9= Calibration data (Sub Package of Robot State Message,Internally used only)
             * 10= Safety Data (Sub Package of Robot State Message)
             * 11= Tool Communication Info (Sub Package of Robot State Message)
             * 12= Tool Mode Info (Sub Package of Robot State Message)
             * 13= Singularity Info (Sub Package of Robot State Message)
             * 14= 
             * 15=
             * 16= Robot State Message
             * 20= Version Message (sent only once) | Robot Message Type =3
             * 25= Global Variables Setup Message | Robot Message Type = 0
             * 25= Global Variables Update Message | Robot Message Type = 1
             * ---Primary Only
             * 
             * 
             * 
             * 
             * All Robot Messages (Type 20)
             * Robot Message Type
             * 0= Robot Message - Text Message
             * 2= Robot Message - Popup Message
             * 5= Robot Message - Safety Mode Message
             * 6= Robot Message - Robot Comm Message
             * 7= Robot Message - Key Message
             * 9= Robot Message - Request Value Message
             * 10=Robot Message - Runtime Exception Message
             * 14= Robot Message - Program Threads Message
             * 
             * 
             * 
             */
            }


            int remaining_bytes = msgSize - 5;
            int pointer = 5;
            if (msgType == 16)
            {
                while (remaining_bytes > 0)
                {
                    size = new[] { socketMessage[pointer], socketMessage[pointer + 1], socketMessage[pointer + 2], socketMessage[pointer + 3] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(size);
                    int submsgSize = BitConverter.ToInt32(size, 0);


                    int subMsgType = (int)socketMessage[pointer + 4];
                    byte[] data = socketMessage.Skip(pointer + 5).Take(pointer + submsgSize - 1).ToArray();

                    if (subMsgType == 3)
                    {
                        DecodeMasterboardData(data);
                    }

                    pointer += submsgSize;
                    remaining_bytes -= submsgSize;

                }
            }




        }
        private void PrimaryTimer_Tick(object sender, EventArgs e)
        {
            if (primaryConnected)
            {
                int bytesRec = 0;
                // Receive the response from the remote device.  
                try
                {
                    socketMessage = new byte[1024];
                    bytesRec = primarySender.Receive(socketMessage);

                    if (!setting)
                    {
                        DecodePrimaryResponse(socketMessage);
                        updating = true;
                        UpdateLabels();
                        updating = false;
                    }
                }
                catch
                {

                }

            }
        }

        private void sendPrimaryCommand(string command)
        {
            if (primaryConnected)
            {
                primaryOutput.AppendText($"Sending Command: {command} \r\n");
                byte[] msg = Encoding.ASCII.GetBytes($"{command}\r\n");

                // Send the data through the socket.  
                int bytesSent = primarySender.Send(msg);
            }
        }
        private void PrimaryConnect_Click(object sender, EventArgs e)
        {

            if (!primaryConnected)
            {
                primaryTimer.Start();
                primaryOutput.AppendText($"Trying to connect to {dashboardIpInput.Text}\r\n");
                try
                {
                    Console.WriteLine(ipAddress);
                    primarySender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    primarySender.ReceiveTimeout = 200;
                    primarySender.Connect(dashboardIpInput.Text, 30001);
                    PrimaryConnectedBox.Checked = true;
                    primaryConnected = true;
                    primaryOutput.AppendText($"Succesfully connected!\r\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    primaryOutput.AppendText($"Connection Failed!\r\n");
                }

            }
            else
            {
                primaryOutput.AppendText("Already connected! \r\n");
            }
        }

        private void PrimaryDisconnect(object sender, EventArgs e)
        {
            if (primaryConnected)
            {
                primaryConnected = false;
                primarySender.Close();
                primaryTimer.Stop();
                primaryOutput.AppendText("Dashboard Server Disconnected!\r\n");
                PrimaryConnectedBox.Checked = false;
            }
            else { primaryOutput.AppendText("Not connected\r\n"); }
        }

        private void PrimaryConfigOut_Checked(object sender, ItemCheckEventArgs e)
        {

            if (!updating)
            {
                setting = true;
                if (e.NewValue == CheckState.Checked)
                {
                    sendPrimaryCommand($"set_configurable_digital_out({e.Index},True)");
                }
                else
                {
                    sendPrimaryCommand($"set_configurable_digital_out({e.Index},False)");
                }
                setting = false;
            }
        }

        private void AdapterChanged(object sender, EventArgs e)
        {
            ipAddress = ipHostInfo.AddressList[comboBox1.SelectedIndex];
        }

        private void PrimaryDigitalOutput_Checked(object sender, ItemCheckEventArgs e)
        {
            if (!updating)
            {
                setting = true;
                if (e.NewValue == CheckState.Checked)
                {
                    sendPrimaryCommand($"set_digital_out({e.Index},True)");
                }
                else
                {
                    sendPrimaryCommand($"set_digital_out({e.Index},False)");
                }
                setting = false;
            }
        }

        private void AnalogOut0_Changed(object sender, EventArgs e)
        {
            if (!updating)
            {
                setting = true;
                int percent = sliderAnalogOut0.Value;




                if (analogOutRange0 == 0)
                {
                    //Analog 4-20
                    float currVal = (16f / 100f * (float)percent) + 4f;
                    analogOut0Label.Text = string.Format("{0:N2}", currVal) + "mA";
                }
                else
                {

                    float voltageVal = 10f / 100f * (float)percent;
                    analogOut0Label.Text = string.Format("{0:N2}", voltageVal) + "V";

                }

                if (primaryConnected)
                { 
                    sendPrimaryCommand($"set_standard_analog_out(0, {((float)percent / 100f).ToString().Replace(',', '.')})");

                }
            }
        }

        private void AnalogOut1_Changed(object sender, EventArgs e)
        {
            if (!updating)
            {
                setting = true;
                int percent = sliderAnalogOut1.Value;


                if (analogOutRange1 == 0)
                {
                    //Analog 4-20
                    float currVal = (16f / 100f * (float)percent) + 4f;
                    analogOut1Label.Text = string.Format("{0:N2}", currVal) + "mA";
                }
                else
                {
                    float voltageVal = 10f / 100f * (float)percent;
                    analogOut1Label.Text = string.Format("{0:N2}", voltageVal) + "V";

                }
                
                if (primaryConnected)
                {
                    sendPrimaryCommand($"set_standard_analog_out(1, {((float)percent / 100f).ToString().Replace(',', '.')})");

                }

            }
        }

        private int ScaleValues(double input, double fromMin,double fromMax, double toMin, double toMax)
        {
            if (input < fromMin)
                return (int)fromMin;

            if (input > fromMax)
                return (int)fromMax;

             double inPerc=(input- fromMin)/(fromMax-fromMin);
            int result = (int)((toMax - toMin) * inPerc + toMin);
            return result;
        }

        private void AnalogOut0_Clicked(object sender, EventArgs e)
        {
            setting = false;
        }

        private void AnalogOut1_Clicked(object sender, EventArgs e)
        {
            setting = false;
        }
    }
}
