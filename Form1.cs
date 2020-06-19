﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveDeviceDector2
{
    public partial class Form1 : Form
    {

        private const int WM_DEVICECHANGE = 0x219;
        private const int DBT_DEVICEARRIVAL = 0X8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0X8004;
        private const int DBT_CONFIGCHANGED = 0X0018;
        private const int DBT_DEVICEQUERYREMOVEFAILED = 0X8002;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
 
            if (m.Msg == DeviceNotification.WmDevicechange)
            {
                Console.WriteLine(m.Msg);
                Console.WriteLine(DeviceNotification.WmDevicechange);

                switch ((int)m.WParam)
                {
                    case DeviceNotification.DbtDeviceRemoveComplete:
                        messageListBox.Items.Add("Device Removed"); // this is where you do your magic
                        break;
                    case DeviceNotification.DbtDeviceArrival:
                        messageListBox.Items.Add("Device added"); // this is where you do your magic
                        break;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            DeviceNotification.RegisterDeviceNotification(this.Handle);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void clearListBoxButton_Click_1(object sender, EventArgs e)
        {
            messageListBox.Items.Clear();
        }
    }
}
