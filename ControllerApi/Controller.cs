using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControllerApi
{
    public class Controller
    {
        Thread m_thread;
        public delegate void CallbackMsg(int code, string msg);//async programming delegation purposes.
        bool m_running = false;
        CallbackMsg pCallback;
        int Temperature = 20;

        public Controller(CallbackMsg p) 
        {
            pCallback = p;
        }
        public void Start()
        {
            if (m_thread==null|| m_thread.IsAlive==false)
            {
                m_thread = new Thread(Process);
                m_thread.Start();//it starts the thread and has nothing to do with the defined start function in this class
            }
            
            //pCallback(1, "Started");
        }

        void Process()
        {
            m_running = true;
            while (m_running)//when it is called by the start method,it'll update temp with checksensor method by checking the m_running value,if stop is pressed
                             //m_running will be false and the process function will stop and will wait for a new start call.
            {
                Thread.Sleep(1000);
                int temp=CheckSensor();
                pCallback(10, temp.ToString());//m_running==false ,gets it out from while loop 
            }
            pCallback(0, "Stopped");//and do the things below the concearning cases in the form  class using the pCallBack delegation.
        }
        int CheckSensor() 
        {
            Temperature++;
            return Temperature;
        }
        public void Stop()
        {
            //pCallback(0, "Stopped");
            m_running = false;
            while (m_thread.IsAlive==true)
            {
                Thread.Sleep(10);//waits a little
            }
        }
    }
}
