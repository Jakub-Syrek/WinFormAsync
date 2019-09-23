using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_async_Demo
{
   

    public class Pinger
    {
        private string _output1;

        public string Output            
        { 
            get { return _output1; }
            set { _output1 = value; }
        }

        
        public async Task<string> PingOnet()
        {
            Ping myPing = new Ping();           
            
            var _replied = await myPing.SendPingAsync("213.180.141.140", 1000);           
             _output1 = $"{ _replied.Address}/{_replied.RoundtripTime}";
            //MessageBox.Show(_output);
            return _output1;
        }

      
    }
}
