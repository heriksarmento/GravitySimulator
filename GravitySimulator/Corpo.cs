using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravitySimulator
{
    internal class Corpo
    {
        // Atributos básicos
        private string Nome;
        private double Massa;
        private double Raio;
        private float PosX;
        private float PosY;
        private float VelX;
        private float VelY;
        // 

        // Atributos adicionais
        private double[,] Força;
        private float[,] Direção;
        private double[,] ForçaXY;
        private double[,] ForçaResultante;
        private double[,] Aceleração;
        //

        public Corpo(string k)  // Construtor de colisão 
        {
            Nome = "Morto";
            Massa = 0.0f;
            Raio = 0.0f;
            PosX = 0;
            PosY = 0;
            VelX = 0;
            VelY = 0;
        }
        public Corpo() // Construtor default 
        {
            Nome = " ";
            Massa = 0.0f;
            Raio = 0.0f;
            PosX = 0;
            PosY = 0;
            VelX = 0;
            VelY = 0;
        }
        public Corpo(string n, double m, double r, float x, float y, float vx, float vy) // Construtor completo
        {
            Nome = n;
            Massa = m;
            Raio = r;
            PosX = x;
            PosY = y;
            VelX = vx;
            VelY = vy;
        }

        //Métodos get/set necessários
        public string getNome()
        {
            return Nome;
        }
        public void setNome(string n)
        {
            Nome = n;
        }
        public double getMassa()
        {
            return Massa;
        }
        public void setMassa(double m)
        {
            Massa = m;
        }
        public void setRaio(double rr)
        {
            Raio = rr;
        }
        public double getRaio()
        {
            return Raio;
        }

        public float getPosX()
        {
            return PosX;
        }
        public float getPosY()
        {
            return PosY;
        }
        public void setPosX(float x)
        {
            PosX = x;
        }
        public void setPosY(float y)
        {
            PosY = y;
        }
        public float getVelX()
        {
            return VelX;
        }
        public float getVelY()
        {
            return VelY;
        }
        public void setVelX(float x)
        {
            VelX = x;
        }
        public void setVelY(float y)
        {
            VelY = y;
        }
        //

        // Inicializador dos atributos adicionais que farão as interações entre os corpos, recebendo a quantidade de corpos para isso
        public void Interações(int l)
        {
            Força = new double[l, 2];
            ForçaXY = new double[l, 2];
            Direção = new float[l, 2];
            ForçaResultante = new double[1, 3];
            Aceleração = new double[1, 2];


            for (int i = 0; i < l; i++)
            {
                Força[i, 0] = 0;
            }
        }
        // Metodos get/set dos atributos adicionais
        public void setForçaDir(double f, float x, float y)
        {
            for (int i = 0; i < (Força.Length) / 2; i++)
            {
                if (Força[i, 0] == 0)
                {
                    Força[i, 0] = f;
                    Direção[i, 0] = x;
                    Direção[i, 1] = y;
                    i = Força.Length;
                }
            }
        }
        public double getForça(int i)
        {
            return Força[i, 0];
        }
        public float getDirX(int i)
        {
            return Direção[i, 0];
        }
        public float getDirY(int i)
        {
            return Direção[i, 1];
        }
        public void setAngulo(int i, double a)
        {
            Força[i, 1] = a;
        }
        public double getAngulo(int i, bool t)
        {
            if (t == true)
            {
                return Força[i, 1] * Math.PI / 180; // Retorna em Radiano 
            }
            else
            {
                return Força[i, 1]; // Retorna em Grau
            }

        }
        public void setForçaX(int i, double fx)
        {
            ForçaXY[i, 0] = fx;
        }
        public void setForçaY(int i, double fy)
        {
            ForçaXY[i, 1] = fy;
        }
        public double getForçaX(int i)
        {
            return ForçaXY[i, 0];
        }
        public double getForçaY(int i)
        {
            return ForçaXY[i, 1];
        }
        public void setForçaResultante(double fx, double fy, double fr)
        {
            ForçaResultante[0, 0] = fx;
            ForçaResultante[0, 1] = fy;
            ForçaResultante[0, 2] = fr;
        }
        public double getForçaResultanteX()
        {
            return ForçaResultante[0, 0];
        }
        public double getForçaResultanteY()
        {
            return ForçaResultante[0, 1];
        }
        public double getForçaResultanteR()
        {
            return ForçaResultante[0, 2];
        }
        public void setAceleraçãoX(double x)
        {
            Aceleração[0, 0] = x;
        }
        public double getAceleraçãoX()
        {
            return Aceleração[0, 0];
        }
        public void setAceleraçãoY(double y)
        {
            Aceleração[0, 1] = y;
        }
        public double getAceleraçãoY()
        {
            return Aceleração[0, 1];
        }
        //

        //Retorno dos valores das variaveis para mandar para o arquivo de saida
        public string log()
        {
            return string.Format("{0};{1};{2};{3};{4};{5};{6}", Nome, Massa, Raio, PosX, PosY, VelX, VelY);
        }
    }
}
