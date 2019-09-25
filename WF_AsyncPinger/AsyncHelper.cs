using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WF_AsyncPinger
{
    static class AsyncHelper
    {
        static public bool PingSync(string _ip)
        {
            using (Ping myPing = new Ping())
            {
                PingReply _replied = myPing.Send(_ip);

                return (_replied.Status == IPStatus.Success) ? true : false;
            }
        }

        static async public Task<bool> PingAsync(string _ip)
        {
            using (Ping myPing = new Ping())
            {
                var _replied = await myPing.SendPingAsync(_ip);

                return (_replied.Status == IPStatus.Success) ? true : false;
            }
        }

        static public bool TelnetSync(string _ip, int _port)
        {
            TcpClient tcpClient = null;

            try
            {
                tcpClient = new TcpClient(_ip, _port);
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
            finally
            {
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }
            }
        }
        static async public Task<bool> TelnetAsync(string _ip, int _port) 
        {             

            TcpClient tcpClient = null;

            try
            {
                tcpClient = new TcpClient();

                await tcpClient.ConnectAsync(_ip, _port);

                return true;
            }
            catch (SocketException)
            {
                return false;
            }
            finally
            {
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }
            }
        }
        
    }
}
