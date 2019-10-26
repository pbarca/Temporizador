using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// Bibliotecas para adicionar fontes :

using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing.Text;


namespace Temporizador
{
    public partial class Form1 : Form
    {
        int contador;

        public Form1()
        {
            InitializeComponent();

            // Carregar fonte
            LoadFont();
            label1.Font = new Font(private_fonts.Families[0], 72);
            button1.Font = new Font(private_fonts.Families[0], 22);
            button2.Font = new Font(private_fonts.Families[0], 22);
            button3.Font = new Font(private_fonts.Families[0], 22);
            label1.UseCompatibleTextRendering = true;
            button1.UseCompatibleTextRendering = true;
            button2.UseCompatibleTextRendering = true;
            button3.UseCompatibleTextRendering = true;

        }

        // Função para adicionar fonte LCD :
        PrivateFontCollection private_fonts = new PrivateFontCollection();
        private void LoadFont()
        {
            string resource = "Temporizador.digital-7-mono.ttf";
            Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
            System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
            byte[] fontdata = new byte[fontStream.Length];
            fontStream.Read(fontdata, 0, (int)fontStream.Length);
            Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
            private_fonts.AddMemoryFont(data, (int)fontStream.Length);
            fontStream.Close();
            Marshal.FreeCoTaskMem(data);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contador = 0;
            timer1.Interval = 1000;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            contador = 0;
            label1.Text = "00:00:00";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = TimeSpan.FromSeconds(++contador).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

    }
}
