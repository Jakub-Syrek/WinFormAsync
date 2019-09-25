using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

        public static IEnumerable<TracertEntry> Tracert(string ipAddress, int maxHops, int timeout)
        {
            IPAddress address;

            // Ensure that the argument address is valid.
            if (!IPAddress.TryParse(ipAddress, out address))
                throw new ArgumentException(string.Format("{0} is not a valid IP address.", ipAddress));

            // Max hops should be at least one or else there won't be any data to return.
            if (maxHops < 1)
                throw new ArgumentException("Max hops can't be lower than 1.");

            // Ensure that the timeout is not set to 0 or a negative number.
            if (timeout < 1)
                throw new ArgumentException("Timeout value must be higher than 0.");


            Ping ping = new Ping();
            PingOptions pingOptions = new PingOptions(1, true);
            Stopwatch pingReplyTime = new Stopwatch();
            PingReply reply;

            do
            {
                pingReplyTime.Start();
                reply = ping.Send(address, timeout, new byte[] { 0 }, pingOptions);
                pingReplyTime.Stop();

                string hostname = string.Empty;
                if (reply.Address != null)
                {
                    try
                    {
                        hostname = Dns.GetHostByAddress(reply.Address).HostName;    // Retrieve the hostname for the replied address.
                    }
                    catch (SocketException) { /* No host available for that address. */ }
                }

                // Return out TracertEntry object with all the information about the hop.
                yield return new TracertEntry()
                {
                    HopID = pingOptions.Ttl,
                    Address = reply.Address == null ? "N/A" : reply.Address.ToString(),
                    Hostname = hostname,
                    ReplyTime = pingReplyTime.ElapsedMilliseconds,
                    ReplyStatus = reply.Status
                };

                pingOptions.Ttl++;
                pingReplyTime.Reset();
            }
            while (reply.Status != IPStatus.Success && pingOptions.Ttl <= maxHops);
        }

        public static async Task<dynamic[]> TracertAsync(string ipAddress, int maxHops, int timeout)
        {
            IPAddress address;

            // Ensure that the argument address is valid.
            if (!IPAddress.TryParse(ipAddress, out address))
                throw new ArgumentException(string.Format("{0} is not a valid IP address.", ipAddress));

            // Max hops should be at least one or else there won't be any data to return.
            if (maxHops < 1)
                throw new ArgumentException("Max hops can't be lower than 1.");

            // Ensure that the timeout is not set to 0 or a negative number.
            if (timeout < 1)
                throw new ArgumentException("Timeout value must be higher than 0.");


            Ping ping = new Ping();
            PingOptions pingOptions = new PingOptions(1, true);
            Stopwatch pingReplyTime = new Stopwatch();
            PingReply reply;
            //dynamic dynamicHolder = new dynamic[]
            dynamic[] sa = new dynamic[5];
            do
            {
                pingReplyTime.Start();
                reply = await  ping.SendPingAsync(address, timeout, new byte[] { 0 }, pingOptions);
                pingReplyTime.Stop();

                string hostname = string.Empty;
                if (reply.Address != null)
                {
                    try
                    {
                        hostname = Dns.GetHostByAddress(reply.Address).HostName;    // Retrieve the hostname for the replied address.
                    }
                    catch (SocketException) { /* No host available for that address. */ }
                }

                // Return out TracertEntry object with all the information about the hop.
                //yield return sa;  //TracertEntry()                
                {
                    sa[0] = pingOptions.Ttl;
                    sa[1] = reply.Address == null ? "N/A" : reply.Address.ToString();
                    sa[2] = hostname;
                    sa[3] = pingReplyTime.ElapsedMilliseconds;
                    sa[4] = reply.Status;


                    //HopID = pingOptions.Ttl,
                    //Address = reply.Address == null ? "N/A" : reply.Address.ToString(),
                    //Hostname = hostname,
                    //ReplyTime = pingReplyTime.ElapsedMilliseconds,
                    //ReplyStatus = reply.Status
                };

                pingOptions.Ttl++;
                pingReplyTime.Reset();
            }
            while (reply.Status != IPStatus.Success && pingOptions.Ttl <= maxHops);
            return sa;
        }

    }
}
