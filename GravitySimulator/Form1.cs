using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GravitySimulator
{

    public partial class Form1 : Form
    {
        private Universo Vialactea = new Universo(100,500);
        private Timer timer;
        OpenFileDialog ofd = new OpenFileDialog();
        float clock=0;
        int ModBody=-1;
        Point posClick;

        public Form1()
        {
            InitializeComponent();
            BackColor = Color.Black;
            Text = "Gravity Simulation";
            WindowState = FormWindowState.Maximized;
            DoubleBuffered = true;

            // Set up the timer
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            //
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            for (int i = 0; i < Vialactea.qntCorpos; i++)
            {
                if (Vialactea.CorposCelestes[i] != null)
                {

                    string nome = Vialactea.CorposCelestes[i].getNome();
                    float posx = Vialactea.CorposCelestes[i].getPosX();
                    float posy = Vialactea.CorposCelestes[i].getPosY();
                    float raio = (float)Vialactea.CorposCelestes[i].getRaio();
                    if (nome != "Morto")
                    {
                        Color foreColor = (Color)new ColorConverter().ConvertFrom(nome);
                        SolidBrush br = new SolidBrush(foreColor);
                        g.FillCircle(br, posx, posy, raio);
                    }
                }
            }

            Font Arial = new Font("Arial", 20, FontStyle.Regular, GraphicsUnit.Pixel);

            if (Vialactea.CorposOcupados != 0)
            {
                g.DrawString("Alive bodies: " + Vialactea.CorposOcupados, Arial, Brushes.White, new Point(0, 30));
                g.DrawString("Actual speed: " + (21-timer.Interval), Arial, Brushes.White, new Point(0, 60));
                g.DrawString("Time: " + clock, Arial, Brushes.White, new Point(0, 90));
                if ((Vialactea.CorposOcupados == 1)&&(timer.Enabled))
                {
                    timer.Stop();
                    for (int i = 0; i < Vialactea.qntCorpos; i++)
                    {
                        if (Vialactea.CorposCelestes[i] != null)
                        {
                            string nome = Vialactea.CorposCelestes[i].getNome();
                            if (nome != "Morto")
                            {   
                                g.DrawString("Winner: " + Vialactea.CorposCelestes[i].getNome(), Arial, Brushes.White, new Point(0, 120));
                            }
                        }
                    }
                }
            }
            if (ModBody != -1)
            {
                Pen p = new Pen(Color.White, 5);
                if (Vialactea.CorposCelestes[ModBody].getNome() == "White")
                {
                    p.Color = Color.Red;
                    g.DrawCircle(p, Vialactea.CorposCelestes[ModBody].getPosX(), Vialactea.CorposCelestes[ModBody].getPosY(), (float)Vialactea.CorposCelestes[ModBody].getRaio());
                }
                else
                {
                    g.DrawCircle(p, Vialactea.CorposCelestes[ModBody].getPosX(), Vialactea.CorposCelestes[ModBody].getPosY(), (float)Vialactea.CorposCelestes[ModBody].getRaio());
                }
            }
            else
            {
                g.DrawCircle(Pens.White, posClick.X, posClick.Y, 5);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            clock += Vialactea.tIteracao;
            Vialactea.Simulacao();
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta > 0)
            {
                float zoom = 1.1f;
                int a, b;
                a = this.Width;
                b = (int)(a * zoom);
                Width = b;
                this.Height = (int)(this.Height * zoom);
                this.Invalidate();
            }
            else
            {
                float zoom = 0.9f;
                this.Width = (int)(this.Width * zoom);
                this.Height = (int)(this.Height * zoom);
                this.Invalidate();
            }
        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                case '+':
                    if (timer.Interval != 1)
                    {
                        timer.Interval -= 1;
                    }
                    break;

                case '-':
                    if (timer.Interval != 20)
                    {
                        timer.Interval += 1;
                    }
                    break;

                case '\r':
                    if (timer.Enabled)
                    {
                        timer.Stop();
                    }
                    else
                    {
                        timer.Start();
                    }
                    break;
                case 'r':
                    clock = 0;
                    timer.Interval = 11;
                    timer.Stop();
                    bigBang();
                    break;

                case '\b':
                    if (ColorMod.Text != "")
                    {
                        Corpo Destruido = new Corpo("Morto");
                        Destruido.Interações(0);
                        Vialactea.CorposCelestes[ModBody] = Destruido;
                    }
                    break;
            }
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            posClick = e.Location;
            for (int i = 0; i < Vialactea.qntCorpos; i++)
            {
                if (Vialactea.CorposCelestes[i] != null)
                {
                    double Distancia = Math.Sqrt(Math.Pow(Vialactea.CorposCelestes[i].getPosX() - e.X, 2.0) + Math.Pow(Vialactea.CorposCelestes[i].getPosY() - e.Y, 2.0));
                    if (Distancia <= Vialactea.CorposCelestes[i].getRaio())
                    {
                        ModBody = i;
                        ColorMod.Text = Vialactea.CorposCelestes[i].getNome();
                        RadiusMod.Text = Vialactea.CorposCelestes[i].getRaio().ToString();
                        MassMod.Text = Vialactea.CorposCelestes[i].getMassa().ToString();
                        SpeedxMod.Text = Vialactea.CorposCelestes[i].getVelX().ToString();
                        SpeedyMod.Text = Vialactea.CorposCelestes[i].getVelY().ToString();
                        i = Vialactea.qntCorpos;
                    }
                    else
                    {
                        ModBody = -1;
                        ColorMod.Text = " ";
                        RadiusMod.Text = " ";
                        MassMod.Text = " ";
                        SpeedxMod.Text = " ";
                        SpeedyMod.Text = " ";
                    }
                }
            }
            Invalidate();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
            clock = 0;
            timer.Interval = 11;
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bigBang();
            }
            
        }

        private void bigBang()
        {
            char[] delimitadores = { ';', '\n', '<', '>', '\r' };
            if (ofd.FileName != null)
            {
                StreamReader leitura = new StreamReader(ofd.FileName);
                string leitor = leitura.ReadToEnd(); // Lendo o arquivo inteiro
                string[] LeituraCompleta = leitor.Split(delimitadores, StringSplitOptions.RemoveEmptyEntries); // Quebrando ele de acordo com os delimitadores
                leitura.Close();
                Vialactea = new Universo((LeituraCompleta.Length) / 7, 500); // Criando o universo com os dados da primeira linha
                int aux = 0;
                for (int i = 0; i < (LeituraCompleta.Length) / 7; i++)
                {
                    Vialactea.AddCorpo(LeituraCompleta[aux], double.Parse(LeituraCompleta[aux + 1]), double.Parse(LeituraCompleta[aux + 2]), float.Parse(LeituraCompleta[aux + 3]), float.Parse(LeituraCompleta[aux + 4]), float.Parse(LeituraCompleta[aux + 5]), float.Parse(LeituraCompleta[aux + 6])); // Adicionando o corpo presente em cada linha ao universo criado
                    aux += 7;
                }
            }
            else
            {
                Vialactea = new Universo(100, 500);
            }
            Invalidate();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            Invalidate();
        }

        private void massaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //inutil
        }

        private void speedXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //inutil
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.FileName = null;
            Vialactea = new Universo(100, 500);
            clock = 0;
            timer.Stop();
            Invalidate();

        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            //sfd.RestoreDirectory = true;
            Stream mS;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if ((mS = sfd.OpenFile()) != null)
                {
                    mS.Close();
                }
                File.WriteAllText(sfd.FileName, Vialactea.AllElements());
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            //inutil
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //inutil
        }

        private void ConfirmMod_Click(object sender, EventArgs e)
        {
            Vialactea.CorposCelestes[ModBody].setNome(ColorMod.Text);
            Vialactea.CorposCelestes[ModBody].setRaio(float.Parse(RadiusMod.Text));
            Vialactea.CorposCelestes[ModBody].setMassa(double.Parse(MassMod.Text));
            Vialactea.CorposCelestes[ModBody].setVelX(float.Parse(SpeedxMod.Text));
            Vialactea.CorposCelestes[ModBody].setVelY(float.Parse(SpeedyMod.Text));
            Invalidate();
        }



        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           Vialactea.AddCorpo(ColorTB.Text, double.Parse(MassTB.Text), double.Parse(RadiusTB.Text), posClick.X, posClick.Y, float.Parse(SpeedxTB.Text), float.Parse(SpeedyTB.Text));
            Invalidate();
        }

        private void criarNovoCorpoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //inutil
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    } // Final form

}
