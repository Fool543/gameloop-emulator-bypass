using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;
using static Memory.Imps;

namespace SlowX
{
    public partial class MainForm : Form
    {
        // Define the process access rights you need
        public Mem MemLib = new Mem();
        public bool ProcOpen = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private bool Patch(long aob_base, long offset, string patch) {
            string address = "0x" + (aob_base + offset).ToString("X").ToString();
            if (MemLib.WriteMemory(address, "bytes", patch))
                return true;
            else return false;
        }

        private async void strbutton_Click(object sender, EventArgs e)
        {

            try
            {
                string processName = "aow_exe";
                long memoryThreshold = 500 * 1024 * 1024; // 400 MB in bytes

                Process[] processes = Process.GetProcessesByName(processName);
                Process targetProcess = processes.FirstOrDefault(p => p.WorkingSet64 > memoryThreshold);

                if (targetProcess != null)
                {
                    ProcOpen = MemLib.OpenProcess(targetProcess.Id);
                    if (ProcOpen)
                    {
                        log.Text = $"LOG : Opened process {processName} with ID {targetProcess.Id}";
                    }
                    else
                    {
                        log.Text = $"LOG : Failed to open the process.";
                    }
                }
                else
                {
                    log.Text = $"LOG : No instance of {processName} found.";
                }

                string libanogsAOB = "7F 45 4C 46 01 01 01 00 00 00 00 00 00 00 00 00 03 00 28 00 01 00 00 00 00 00 00 00 34 00 00 00 94 EC 3D 00 00 02 00 05 34 00 20 00 08 00 28 00 1B 00 1A 00";

                IEnumerable<long> AnogsAobR  = await MemLib.AoBScan(libanogsAOB, true, false, true, "");
                long anogs = AnogsAobR.FirstOrDefault();

                string libUE4AOB = "7F 45 4C 46 01 01 01 00 00 00 00 00 00 00 00 00 03 00 28 00 01 00 00 00 00 50 E1 01 34 00 00 00 78 3E 8A 08 00 02 00 05 34 00 20 00 0D 00 28 00 19 00 18 00";

                IEnumerable<long> Ue4AobR = await MemLib.AoBScan(libUE4AOB, true, false, true, "");
                long ue4 = Ue4AobR.FirstOrDefault();

                //
                //Patch ANOGS OR OTHER LIBRARIES
                //

                //For Example Patch(anogs, 0x8A42A, "0x00 0x20 0x70 0x47"); 
            }
            catch (Exception ex)
            {
                log.Text = $"LOG : Error accessing process memory: {ex.Message}";
            }



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://t.me/ProsnailYT");
        }

    }
}
