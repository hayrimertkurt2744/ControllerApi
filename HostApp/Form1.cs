using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControllerApi;

namespace HostApp
{
    public partial class Form1 : Form
    {
        Controller m_api;
        public Form1()
        {
            Controller.CallbackMsg p = new Controller.CallbackMsg(MyCallBack);//makes it do something after receiving it.
            m_api = new Controller(p);

            InitializeComponent();
        }
        void MyCallBack(int code, string msg) 
        {
            switch (code)
            {   case 0:
                case 1:
                    if (label1.InvokeRequired)//in order to update the lable in every change of it.
                    {
                        label1.BeginInvoke((MethodInvoker)delegate(){
                            this.label1.Text = msg;
                        });
                    }
                    else
                    {
                        label1.Text = msg;
                    }
                    //MessageBox.Show(msg);
                    break;
                case 10:
                    if (label3.InvokeRequired)//in order to update the lable in every change of it.
                    {
                        label3.BeginInvoke((MethodInvoker)delegate () {
                            this.label3.Text = msg;
                        });
                    }
                    else
                    {
                        label3.Text = msg;
                    }

                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_api.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_api.Stop();
        }
    }
}
