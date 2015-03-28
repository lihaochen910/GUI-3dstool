using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.IO;
using System.Diagnostics;
using System.Reflection;
namespace 测试命令行软件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog OpenFileDialog1 = new OpenFileDialog();

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            OpenFileDialog1.Filter = "游戏ROM文件(*.3ds)|*.3ds";
            OpenFileDialog1.RestoreDirectory = true;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = OpenFileDialog1.FileName;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.InitialDirectory = OpenFileDialog1.FileName;
            OpenFileDialog1.Filter = "xorpad文件(*.xorpad)|*.xorpad";
            OpenFileDialog1.RestoreDirectory = true;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = OpenFileDialog1.FileName;
            }
        }

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("需要与3dstool.exe在同一目录下;\n\n特别感谢dnasdw前辈开发出的3dstool工具；\n以及SarvSarv前辈编写的解包教程\n\n\nMai.Yi", "目前只支持解包操作哦！");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.InitialDirectory = OpenFileDialog1.FileName;
            OpenFileDialog1.Filter = "xorpad文件(*.xorpad)|*.xorpad";
            OpenFileDialog1.RestoreDirectory = true;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = OpenFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.InitialDirectory = OpenFileDialog1.FileName;
            OpenFileDialog1.Filter = "xorpad文件(*.xorpad)|*.xorpad";
            OpenFileDialog1.RestoreDirectory = true;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = OpenFileDialog1.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.InitialDirectory = OpenFileDialog1.FileName;
            OpenFileDialog1.Filter = "xorpad文件(*.xorpad)|*.xorpad";
            OpenFileDialog1.RestoreDirectory = true;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = OpenFileDialog1.FileName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.InitialDirectory = OpenFileDialog1.FileName;
            OpenFileDialog1.Filter = "xorpad文件(*.xorpad)|*.xorpad";
            OpenFileDialog1.RestoreDirectory = true;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox6.Text = OpenFileDialog1.FileName;
            }
        }

        private void 重置ROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("./cci");
            Directory.CreateDirectory("./cci/cxi0");
            Directory.CreateDirectory("./cci/cfa1");
            Directory.CreateDirectory("./cci/cfa7");
            Directory.CreateDirectory("./cci/cxi0/romfs");
            Directory.CreateDirectory("./cci/cfa1/romfs");
            Directory.CreateDirectory("./cci/cfa7/romfs");
            string t1=textBox1.Text;
            string t2 = textBox2.Text;
            string t3 = textBox3.Text;
            string t4 = textBox4.Text;
            string t5 = textBox5.Text;
            string t6 = textBox6.Text;
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.RedirectStandardError = false;
                p.Start();
                //p.StandardInput.WriteLine("@echo off");
                p.StandardInput.WriteLine("cls");
                //p.StandardInput.WriteLine("从3ds中提取cci文件");
                p.StandardInput.WriteLine("3dstool -xvt017f cci cci/0.cxi cci/1.cfa cci/7.cfa " + t1 + " --header cci/nccheader.bin");


                //p.StandardInput.WriteLine("执行cxi0解包,取得.bin");
                p.StandardInput.WriteLine("3dstool -xvtf cxi cci/0.cxi --header cci/cxi0/ncchheader.bin --exh cci/cxi0/exh.bin --plain cci/cxi0/plain.bin --exefs cci/cxi0/exefs.bin --romfs cci/cxi0/romfs.bin --exh-xor " + t4 + " --exefs-xor " + t3 + " --romfs-xor " + t2);



                //p.StandardInput.WriteLine("执行cfa1解包,取得.bin");
                p.StandardInput.WriteLine("3dstool -xvtf cfa cci/1.cfa --header cci/cfa1/ncchheader.bin --romfs cci/cfa1/romfs.bin --romfs-xor " + t5);
                //p.StandardInput.WriteLine("执行cfa7解包,取得.bin");
                p.StandardInput.WriteLine("3dstool -xvtf cfa cci/7.cfa --header cci/cfa7/ncchheader.bin --romfs cci/cfa7/romfs.bin --romfs-xor " + t6);
                //p.StandardInput.WriteLine("执行0.cxi\romfs.bin和exefs.bin文件的提取");
                p.StandardInput.WriteLine("3dstool -xvtf romfs cci/cxi0/romfs.bin --romfs-dir cci/cxi0/romfs");
                p.StandardInput.WriteLine("3dstool -xvtfu exefs cci/cxi0/exefs.bin --exefs-dir cci/cxi/exefs --header cci/cxi0/exefs/ncchheader.bin");
                //p.StandardInput.WriteLine("执行0.cxi\romfs.bin和exefs.bin文件的提取");
                p.StandardInput.WriteLine("3dstool -xvtf romfs cci/cfa1/romfs.bin --romfs-dir cci/cfa1/romfs");
                p.StandardInput.WriteLine("3dstool -xvtf romfs cci/cfa7/romfs.bin --romfs-dir cci/cfa7/romfs");
                p.StandardInput.WriteLine("echo 提取完成，请按X退出命令行");
                p.StandardInput.WriteLine("pause");
                //p.WaitForExit();
            }
            catch { MessageBox.Show("貌似3dstool出问题了", "遇到一个错误"); }
        }
    }
}
