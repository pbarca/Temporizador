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

            LoadFont();
            label1.Font = new Font(private_fonts.Families[0], 72);
            label1.UseCompatibleTextRendering = true;
            LCD(Start, 22); LCD(Stop, 22); LCD(Reset, 22);
            LCD(horas, 16); LCD(minutos, 16); LCD(segundos, 16);
        }

        private void LCD(Button objeto, int tamanho)
        {
            objeto.Font = new Font(private_fonts.Families[0], tamanho);
            objeto.UseCompatibleTextRendering = true;
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

        private void mostrar()
        {
            if (contador < 0) contador = 0;
            label1.Text = TimeSpan.FromSeconds(contador).ToString();
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            contador = 0;
            mostrar();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contador++;
            mostrar();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void horas_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) contador -= 60 * 60; else contador += 60 * 60;
            mostrar();
        }

        private void minutos_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) contador -= 60; else contador += 60;
            mostrar();
        }


        private void segundos_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) contador--; else contador++;
            mostrar();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

    }
}
