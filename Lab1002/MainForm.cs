using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1002
{
    public partial class MainForm : Form
    {
        private static readonly int _BUFFER_SIZE_ = 10;
        CircleBufferHandler buffer = new CircleBufferHandler(_BUFFER_SIZE_);
        
        
        public MainForm()
        {
            InitializeComponent();
            Consumer consumer1, consumer2, consumer3;
            consumer1 = new Consumer(ref buffer, "1");
            consumer2 = new Consumer(ref buffer, "2");
            consumer3 = new Consumer(ref buffer, "3");

            consumer1.Run();
            consumer2.Run();
            consumer3.Run();
        }


        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ///Producer
            Task.Run(() =>
            {
                buffer.Add(e.KeyChar);
            });
            inputTextBox.Clear();
        }
        
    }
}
