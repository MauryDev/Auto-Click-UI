using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace AutoClickAPP
{
    public static class AutoClickEmbed
    {
        [DllImport("AutoClick.dll")]
        public static extern void Click(int enablekey, int disablekey);
        public static Keys[] keys = new Keys[2] { Keys.None, Keys.None};
        public static bool enable = false;
        public static int delay = 100;

        public static void Init()
        {
            var thread = new System.Threading.Thread(() => {
                while (true)
                {
                    if (enable)
                    {
                        Click((int)keys[0], (int)keys[1]);

                    }
                    System.Threading.Thread.Sleep(delay);
                }
                
            });
            thread.Start();
        }

    }
}
