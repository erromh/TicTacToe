using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form5 : Form
    {
        private Button[,] buttons = new Button[5, 5];
        public Form5()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(100, 100);
                }
            }
            setButton();
        }

        private void setButton()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons[i, j].Location = new Point(5 + 100 * i, 100 + 100 * j);
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 50);
                    buttons[i, j].TextAlign = ContentAlignment.TopCenter;

                    this.Controls.Add(buttons[i, j]);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sender.GetType().GetProperty("Text").SetValue(sender, "x");
        }
    }
}
