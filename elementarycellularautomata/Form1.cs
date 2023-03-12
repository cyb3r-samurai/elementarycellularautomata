using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elementarycellularautomata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

  

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
        }
        int count = 0;
        private void panel2_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                Panel clickedPanel = sender as Panel;

                if (clickedPanel != null)
                {
                    if (clickedPanel.BackColor == Color.Red)
                        clickedPanel.BackColor = Color.White;
                    else
                        clickedPanel.BackColor = Color.Red;
                }
            }
        }


        const int n = 15;
        BitArray current = new BitArray(15,false);
        BitArray next = new BitArray(15, false);
        BitArray rule;
        private void button1_Click(object sender, EventArgs e)
        {
            rule = new BitArray(new int[] {(int)numericUpDown1.Value});
            if (count == 0)
                for (int i = 0; i < n; i++)
                {
                    if (tableLayoutPanel1.GetControlFromPosition(i,0).BackColor == Color.Red)
                        current[i] = true;
                }
            if (!timer1.Enabled && count < 11) timer1.Start();
            else timer1.Stop();
        }
        private int getInt(BitArray bitArray)
        {
            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                BitArray mask = new BitArray(3);
                for (int i = 0; i < n; i++)
                {
                    if (i - 1 < 0) mask[2] = false;
                    else mask[2] = current[i - 1];
                    mask[1] = current[i];
                    if (i + 1 < n)
                        mask[0] = current[i + 1];
                    else mask[0] = false;
                    int key = getInt(mask);
                    next[i] = rule[key];
                if (next[i])
                    tableLayoutPanel1.GetControlFromPosition(i, count+1).BackColor = Color.Red;
                }
            for(int i =0; i< n;i++)
            {
                current[i] = next[i];
            }
            next.SetAll(false);
            count++;
            if (count == 11) timer1.Stop();
        }
    }
}
