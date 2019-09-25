using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_AsyncPinger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btPingSync_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            foreach (string ip in tbInputIP.Lines)
            {
                if (!(string.IsNullOrWhiteSpace(ip))&&(ip.Contains(".")))
                {
                    try
                    {
                        tbResults.AppendText($"{ip} Sync Ping responded :{AsyncHelper.PingSync(ip).ToString()} at {stopwatch.Elapsed}{Environment.NewLine}");
                    }
                    catch (Exception exc)
                    {
                        tbResults.AppendText($"{exc.ToString()}");
                    }
                }
            }
        }

        private async void btPingAsync_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Task<bool>> _tasks = new List<Task<bool>>();

            foreach (string ip in tbInputIP.Lines)
            {
                if (!(string.IsNullOrWhiteSpace(ip)) && (ip.Contains(".")))
                {
                    try
                    {
                        _tasks.Add(Task<bool>.Run(() =>
                        {
                            return AsyncHelper.PingAsync(ip);
                        }));
                    }
                    catch (Exception exc)
                    {
                        tbResults.AppendText($"{exc.ToString()}");
                    }
                }
            }

            await Task.WhenAll(_tasks);

            for (int i = 0; i < _tasks.Count; i++)
            {
                tbResults.AppendText(text: $"{tbInputIP.Lines[i]} Async Ping responded : {_tasks[i].Result.ToString()} at {stopwatch.Elapsed}{Environment.NewLine}");                    
            }

            
        }

        private void btTelnetSync_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < tbInputIP.Lines.Length; i++)
            {
                string ip = tbInputIP.Lines[i];
                
                if (!(string.IsNullOrWhiteSpace(ip)) && (ip.Contains(".")))
                {
                    try
                    {
                        if (!(string.IsNullOrWhiteSpace(tbInputPorts.Lines[i])))
                        {
                            int port = Convert.ToInt16(tbInputPorts.Lines[i]);
                            tbResults.AppendText($"{ip} on {port} Sync Telnet responded :{AsyncHelper.TelnetSync(ip, port).ToString()} at {stopwatch.Elapsed}{Environment.NewLine}");
                        }
                    }
                    catch (Exception)
                    {                        
                    }
                }
            }
        }

        private async void btTelnetAsync_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            List<Task<bool>> _tasks = new List<Task<bool>>();

            for (int i = 0; i < tbInputIP.Lines.Length; i++)
            {
                string ip = tbInputIP.Lines[i];
                if (!(string.IsNullOrWhiteSpace(ip)) && (ip.Contains(".")))
                {
                    try
                    {
                        if (!(string.IsNullOrWhiteSpace(tbInputPorts.Lines[i])))
                        {
                            int port = Convert.ToInt16(tbInputPorts.Lines[i]);
                            _tasks.Add(Task<bool>.Run(() =>
                            {
                                return AsyncHelper.TelnetAsync(ip, port);
                            }));
                        }
                    }
                    catch (Exception exc)
                    {
                        tbResults.AppendText($"{exc.ToString()}");
                    }
                }
            }

            await Task.WhenAll(_tasks);

            for (int i = 0; i < _tasks.Count; i++)
            {
                int port = Convert.ToInt16(tbInputPorts.Lines[i]);
                tbResults.AppendText(text: $"{tbInputIP.Lines[i]} on {port} Async Telnet responded : {_tasks[i].Result.ToString()} at {stopwatch.Elapsed}{Environment.NewLine}");
            }

        }

        private void btTracerouteSync_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Task<bool>> _tasks = new List<Task<bool>>();

            for (int i = 0; i < tbInputIP.Lines.Length; i++)
            {
                string ip = tbInputIP.Lines[i];
                if (!(string.IsNullOrWhiteSpace(ip)) && (ip.Contains(".")))
                {                   
                    IEnumerable<TracertEntry> res = AsyncHelper.Tracert(ip, 30, 5000);
                    foreach (TracertEntry tracertEntry in res)
                    {
                        tbResults.AppendText($"traceroute to {tracertEntry.Address} : {tracertEntry.ToString()}{Environment.NewLine}");
                    }
                    
                }
            }            
            
        }

        private async void btTracerouteAsync_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<Task<dynamic[]>> _tasks = new List<Task<dynamic[]>>();

            for (int i = 0; i < tbInputIP.Lines.Length; i++)
            {
                string ip = tbInputIP.Lines[i];
                if (!(string.IsNullOrWhiteSpace(ip)) && (ip.Contains(".")))
                {
                    _tasks.Add(Task<dynamic[]>.Run(() =>
                    {
                        return AsyncHelper.TracertAsync(ip, 30, 5000);
                    }));
                }
            }
            await Task.WhenAll(_tasks);
            for (int i = 0; i < _tasks.Count; i++)
            {

                tbResults.AppendText($"traceroute to :{ (_tasks[i]).Result[0]}{Environment.NewLine}");
                tbResults.AppendText($"traceroute to :{ (_tasks[i]).Result[1]}{Environment.NewLine}");
                tbResults.AppendText($"traceroute to :{ (_tasks[i]).Result[2]}{Environment.NewLine}");
                tbResults.AppendText($"traceroute to :{ (_tasks[i]).Result[3]}{Environment.NewLine}");
                tbResults.AppendText($"traceroute to :{ (_tasks[i]).Result[4]}{Environment.NewLine}");
                //tbResults.AppendText($"traceroute to {tracertEntry.Address} : {tracertEntry.ToString()}{Environment.NewLine}");
            }
        }
    }
}
