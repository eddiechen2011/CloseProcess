using ctMonitor;
using eProject;
using System.Diagnostics;
using System.Timers;
using System.Windows.Forms;

namespace 定时关闭进程
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer? closeProcessTimer;
        private TxtFiles txtFiles = new TxtFiles("Log.txt");

        public Form1()
        {
            InitializeComponent();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            refreshProcess();
        }

        private void textBox_searchStr_TextChanged(object sender, EventArgs e)
        {
            refreshProcess();
        }

        private void refreshProcess()
        {
            // 获取所有名为 "mstsc" 的进程
            Process[] processes = Process.GetProcesses();
            listBox_process.Items.Clear();
            processes.Where(e => e.ProcessName.Contains(textBox_searchStr.Text)).OrderBy(e => e.ProcessName).ToList().ForEach(p =>
            {
                listBox_process.Items.Add(p.ProcessName);
            });

        }

        private void textBox_searchStr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Escape)
            {
                textBox_searchStr.Text = "";
                textBox_searchStr.Focus();
            }
        }

        private void button_toRight_Click(object sender, EventArgs e)
        {
            listBox_closeProcess.Items.Add(listBox_process.SelectedItem!);
            saveCloseProcessList();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            listBox_closeProcess.Items.Remove(listBox_closeProcess.SelectedItem!);
            saveCloseProcessList();
        }

        private void button_closeProcess_Click(object sender, EventArgs e)
        {
            if (listBox_process.SelectedItem != null)
            {
                string processName = listBox_process.SelectedItem.ToString()!;
                // 获取所有名为 "mstsc" 的进程
                Process[] processes = Process.GetProcessesByName(processName);

                foreach (var process in processes)
                {
                    try
                    {
                        process.Kill(); // 强制结束进程
                        process.WaitForExit(); // 等待进程退出
                        //MessageBox.Show($"已成功关闭 \"{process.ProcessName}\" 进程（PID：{process.Id}）");
                        txtFiles.Write([$"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}\t已成功关闭 \"{process.ProcessName}\" 进程（PID：{process.Id}）"]);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show($"无法关闭远程桌面连接进程（PID：{process.Id}）：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFiles.Write([$"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}\t无法关闭 \"{process.ProcessName}\" 进程（PID：{process.Id}）：{ex.Message}"]);
                    }
                }

                refreshProcess();

            }
        }

        private void checkBox_autoCloseProcess_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_autoCloseProcess.Checked)
            {
                dateTimePicker1.Enabled = true; // 启用时间选择器
                // 如果选中，则启动定时器
                closeProcessTimerInit();
            }
            else
            {
                dateTimePicker1.Enabled = false; // 禁用时间选择器
                // 如果未选中，则停止定时器
                closeProcessTimerStop();
            }
        }
        private void closeProcessTimerInit()
        {
            string[] time = dateTimePicker1.Text.Split(":");
            int hour = int.Parse(time[0]);
            int minute = int.Parse(time[1]);
            int second = int.Parse(time[2]);

            // 设置定时任务，例如每天早上8点唤醒计算机
            DateTime now = DateTime.Now;
            DateTime closeProcessTime = new DateTime(now.Year, now.Month, now.Day, hour, minute, second, 0); // 每天8点
            if (closeProcessTime < now)
            {
                closeProcessTime = closeProcessTime.AddDays(1); // 如果当前时间已过8点，则设置为明天8点
            }

            TimeSpan interval = closeProcessTime - now;
            closeProcessTimer = new System.Timers.Timer(interval.TotalMilliseconds);
            closeProcessTimer.Elapsed += CloseProcessTimer_Elapsed;
            closeProcessTimer.AutoReset = true; // 设置为自动重复
            closeProcessTimer.Start();
        }
        private void closeProcessTimerStop()
        {
            if (closeProcessTimer != null)
            {
                closeProcessTimer.Stop();
                closeProcessTimer.Dispose();
                closeProcessTimer = null;
            }
        }
        private void closeProcessTimerReset()
        {
            closeProcessTimerStop();
            closeProcessTimerInit();
        }
        private void CloseProcessTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            // 获取 ListBox 中的所有项目
            for (int i = 0; i < listBox_closeProcess.Items.Count; i++)
            {
                string processName = listBox_closeProcess.Items[i].ToString()!;
                // 获取所有名为 "mstsc" 的进程
                Process[] processes = Process.GetProcessesByName(processName);

                foreach (var process in processes)
                {
                    try
                    {
                        process.Kill(); // 强制结束进程
                        process.WaitForExit(); // 等待进程退出
                        //MessageBox.Show($"已成功关闭 \"{process.ProcessName}\" 进程（PID：{process.Id}）");
                        txtFiles.Write([$"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}\t已成功关闭 \"{process.ProcessName}\" 进程（PID：{process.Id}）"]);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show($"无法关闭远程桌面连接进程（PID：{process.Id}）：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtFiles.Write([$"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}\t无法关闭 \"{process.ProcessName}\" 进程（PID：{process.Id}）：{ex.Message}"]);
                    }
                }
            }



            closeProcessTimerReset();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            closeProcessTimerReset();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigRW.appSettings_Read("closeProcessList")?.Split("|").ToList().ForEach(e =>
            {
                if (!string.IsNullOrEmpty(e))
                    listBox_closeProcess.Items.Add(e);
            });
            checkBox_autoCloseProcess.Checked = true;
        }

        private void saveCloseProcessList()
        {
            // 获取 ListBox 中的所有项目
            string[] processNames = new string[listBox_closeProcess.Items.Count];
            for (int i = 0; i < listBox_closeProcess.Items.Count; i++)
            {
                processNames[i] = listBox_closeProcess.Items[i].ToString()!;
            }
            // 将项目保存到文件中
            ConfigRW.appSettings_Write("closeProcessList", string.Join("|", processNames));
        }
    }
}
