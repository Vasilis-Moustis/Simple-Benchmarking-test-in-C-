using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secondChallenge
{
	public partial class Form1 : Form
	{

		Random r = new Random();

		Stopwatch watch = new Stopwatch();

		int n;

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			richTextBox1.Text = "";
			if (!int.TryParse(richTextBox2.Text, out n))
			{
				MessageBox.Show("Please insert an number!");
				return;
			}
			else
			{
				n = Int32.Parse(richTextBox2.Text);
				shuffleArray(n);
			}			
		}

		void shuffleArray(int n)
		{
			watch.Start();
			int[] myNumberAray = new int[n];
			int k;
			for (int i = 0; i < n; i++)
			{
				myNumberAray[i] = i;
				if (i / 10 == 0)
				{
					k = i;
				}
			}
			for (int t = 0; t < myNumberAray.Length; t++)
			{
				int tmp = myNumberAray[t];
				int pos = r.Next(t, myNumberAray.Length);
				myNumberAray[t] = myNumberAray[pos];
				myNumberAray[pos] = tmp;
			}
			if (checkBox1.Checked)
			{
				Thread.Sleep(n / 300);
				watch.Stop();
				long result = watch.ElapsedMilliseconds;
				label3.Text = result.ToString();
				watch.Reset();
			}
			for (int i = 0; i < n; i++)
			{
				richTextBox1.AppendText(myNumberAray[i].ToString() + Environment.NewLine);
			}
			if (!checkBox1.Checked)
			{
				watch.Stop();
				long result = watch.ElapsedMilliseconds;
				label3.Text = result.ToString();
				watch.Reset();
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
