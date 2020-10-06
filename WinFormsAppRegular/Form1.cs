using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsAppRegular
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            Regex regex = new Regex(@"^([А-Я][а-я]+)\s+([А-Я])\.\s*([А-Я])\.\s+(\d+)\s+(\d+)$");
            using (StreamReader reader = new StreamReader(file.FileName))
            {
                while (!reader.EndOfStream)
                {
                    Match match = regex.Match(reader.ReadLine() ?? "");
                    if (match.Success && int.Parse(match.Groups[4].Value) > 190) {
                        wordout.Text += (match.Groups[1].Value) + Environment.NewLine;
                    }
                }
            }
        }
    }
}