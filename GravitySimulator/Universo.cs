using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace GravitySimulator
{
    internal class Universo
    {
        public int qntCorpos;
        public float tIteracao;
        public Corpo[] CorposCelestes;
        public int CorposOcupados = 0; // Variavel para auxiliar no método AddCorpo que contará quantos corpos já foram introduzidos
        public Universo(int c, float t) // Construtor default
        {
            CorposCelestes = new Corpo[c];
            tIteracao = t;
            qntCorpos = c;
        }

        // Métodos de adicionar um corpo ao universo, podendo ser passado como parametro os atibutos ou o objeto pronto
        public void AddCorpo(Corpo k)
        {
            CorposCelestes[CorposOcupados] = k;
            CorposCelestes[CorposOcupados].Interações(qntCorpos - 1);
            CorposOcupados++;
        }

        public void AddCorpo(string n, double m, double r, float x, float y, float vx, float vy)
        {
            CorposCelestes[CorposOcupados] = new Corpo(n, m, r, x, y, vx, vy);
            CorposCelestes[CorposOcupados].Interações(qntCorpos - 1);
            CorposOcupados++;
        }
        //

        //Método que definitivamente fará os calculos
        public void Simulacao()
        {
            double f;
            double G = 6.674184 * Math.Pow(10, -11); // Constante de gravitação universal

            // Calculando a força de cada corpo em relação a todos os outros corpos
            for (int i = 0; i < qntCorpos; i++)
            {
                if (CorposCelestes[i] != null)
                { 
                    if (CorposCelestes[i].getNome() != "Morto")
                    {
                        for (int j = i + 1; j < qntCorpos; j++)
                        {
                            if (CorposCelestes[j] != null) 
                            {
                                if (CorposCelestes[j].getNome() != "Morto")
                                {
                                    // Formula de distancia entre dois pontos no plano cartesiano
                                    double Distancia = Math.Sqrt(Math.Pow(CorposCelestes[i].getPosX() - CorposCelestes[j].getPosX(), 2.0) + Math.Pow(CorposCelestes[i].getPosY() - CorposCelestes[j].getPosY(), 2.0)); // Formula de distancia entre dois pontos no plano cartesiano
                                    if (Distancia < (CorposCelestes[i].getRaio() + CorposCelestes[j].getRaio()))
                                    {  // Verificando se a distancia entre os dois corpos não é menor que a soma do raio deles, caso seja ocorreu uma colisão
                                       // Inicializando o Corpo destruido.
                                        Corpo Destruido = new Corpo("Morto");
                                        Destruido.Interações(0);
                                        //
                                        // Fazendo os calculos para o corpo sobrevivente
                                        // 

                                        if (CorposCelestes[i].getMassa() < CorposCelestes[j].getMassa())
                                        {

                                            double propMassa = CorposCelestes[j].getMassa() / CorposCelestes[i].getMassa();
                                            propMassa -= 1;

                                            if ((propMassa > -0.05) && (propMassa < 0.05))
                                            {
                                                CorposCelestes[i] = Destruido;
                                                CorposCelestes[j] = Destruido;
                                                CorposOcupados -= 2;
                                            }
                                            else
                                            {
                                                CorposCelestes[j].setMassa(CorposCelestes[i].getMassa() + CorposCelestes[j].getMassa());
                                                CorposCelestes[j].setRaio(Math.Sqrt((Math.Pow(CorposCelestes[i].getRaio(), 2.0) + (Math.Pow(CorposCelestes[j].getRaio(), 2.0)))));
                                                CorposCelestes[j].setForçaResultante((CorposCelestes[j].getForçaResultanteX() + CorposCelestes[i].getForçaResultanteX()), (CorposCelestes[j].getForçaResultanteY() + CorposCelestes[i].getForçaResultanteY()), (CorposCelestes[j].getForçaResultanteR() + CorposCelestes[i].getForçaResultanteR()));
                                                CorposCelestes[j].setVelX((float)((CorposCelestes[j].getVelX() * CorposCelestes[j].getMassa() + CorposCelestes[i].getVelX() * CorposCelestes[i].getMassa()) / (CorposCelestes[j].getMassa() + CorposCelestes[i].getMassa())));
                                                CorposCelestes[j].setVelY((float)((CorposCelestes[j].getVelY() * CorposCelestes[j].getMassa() + CorposCelestes[i].getVelY() * CorposCelestes[i].getMassa()) / (CorposCelestes[j].getMassa() + CorposCelestes[i].getMassa())));
                                                CorposCelestes[j].setAceleraçãoX(CorposCelestes[j].getAceleraçãoX() + CorposCelestes[i].getAceleraçãoX());
                                                CorposCelestes[j].setAceleraçãoY(CorposCelestes[j].getAceleraçãoY() + CorposCelestes[i].getAceleraçãoY());
                                                CorposCelestes[i] = Destruido;
                                                CorposOcupados--;
                                            }

                                            
                                        }
                                        else if (CorposCelestes[i].getMassa() >= CorposCelestes[j].getMassa())
                                        {

                                            double propMassa = CorposCelestes[i].getMassa() / CorposCelestes[j].getMassa();
                                            propMassa -= 1;

                                            if ((propMassa > -0.05) && (propMassa < 0.05))
                                            {
                                                CorposCelestes[i] = Destruido;
                                                CorposCelestes[j] = Destruido;
                                                CorposOcupados-=2;
                                            }
                                            else
                                            {
                                                CorposCelestes[i].setMassa(CorposCelestes[i].getMassa() + CorposCelestes[j].getMassa());
                                                CorposCelestes[i].setRaio(Math.Sqrt((Math.Pow(CorposCelestes[i].getRaio(), 2.0) + (Math.Pow(CorposCelestes[j].getRaio(), 2.0)))));
                                                CorposCelestes[i].setForçaResultante((CorposCelestes[j].getForçaResultanteX() + CorposCelestes[i].getForçaResultanteX()), (CorposCelestes[j].getForçaResultanteY() + CorposCelestes[i].getForçaResultanteY()), (CorposCelestes[j].getForçaResultanteR() + CorposCelestes[i].getForçaResultanteR()));
                                                CorposCelestes[i].setVelX((float)((CorposCelestes[j].getVelX() * CorposCelestes[j].getMassa() + CorposCelestes[i].getVelX() * CorposCelestes[i].getMassa()) / (CorposCelestes[j].getMassa() + CorposCelestes[i].getMassa())));
                                                CorposCelestes[i].setVelY((float)((CorposCelestes[j].getVelY() * CorposCelestes[j].getMassa() + CorposCelestes[i].getVelY() * CorposCelestes[i].getMassa()) / (CorposCelestes[j].getMassa() + CorposCelestes[i].getMassa())));
                                                CorposCelestes[i].setAceleraçãoX(CorposCelestes[j].getAceleraçãoX() + CorposCelestes[i].getAceleraçãoX());
                                                CorposCelestes[i].setAceleraçãoY(CorposCelestes[j].getAceleraçãoY() + CorposCelestes[i].getAceleraçãoY());
                                                CorposCelestes[j] = Destruido;
                                                CorposOcupados--;
                                            }         
                                        }
                                    }
                                    f = G * (CorposCelestes[i].getMassa() * CorposCelestes[j].getMassa()) / Math.Pow(Distancia, 2); // Lei da Gravitação Universal 
                                    CorposCelestes[i].setForçaDir(f, CorposCelestes[j].getPosX(), CorposCelestes[j].getPosY()); // Apontando para o ponto (x,y) em que está o outro corpo
                                    CorposCelestes[j].setForçaDir(f, CorposCelestes[i].getPosX(), CorposCelestes[i].getPosY()); // Apontando para o ponto (x,y) em que está o outro corpo
                                }
                            }

                        }
                    }
                }
            }
            for (int i = 0; i < qntCorpos; i++)
            {
                if (CorposCelestes[i] != null) { 
                if (CorposCelestes[i].getNome() != "Morto")
                {
                        for (int j = 0; j < qntCorpos - 1; j++)
                        {
                            if (CorposCelestes[j] != null)
                            { 
                            if (CorposCelestes[j].getNome() != "Morto") 
                            {
                                // Angulo de cada Força para poder decompor em X e Y
                                double AjustaAngulo = 0;

                                // Análisando em qual quadrante está o vetor da força resultante

                                // Primeiro Quadrante
                                if ((CorposCelestes[i].getDirY(j) > CorposCelestes[i].getPosY()) & (CorposCelestes[i].getDirX(j) > CorposCelestes[i].getPosX()))
                                {
                                    AjustaAngulo = (Math.Atan2((CorposCelestes[i].getDirY(j) - CorposCelestes[i].getPosY()), (CorposCelestes[i].getDirX(j) - CorposCelestes[i].getPosX())));
                                    AjustaAngulo = AjustaAngulo * 180 / (Math.PI);
                                    CorposCelestes[i].setAngulo(j, AjustaAngulo);
                                }
                                // Segundo Quadrante
                                else if ((CorposCelestes[i].getDirY(j) > CorposCelestes[i].getPosY()) & (CorposCelestes[i].getDirX(j) < CorposCelestes[i].getPosX()))
                                {
                                    AjustaAngulo = Math.Atan2((CorposCelestes[i].getDirY(j) - CorposCelestes[i].getPosY()), (CorposCelestes[i].getPosX() - CorposCelestes[i].getDirX(j)));
                                    AjustaAngulo = AjustaAngulo * 180 / (Math.PI);
                                    AjustaAngulo = 180 - AjustaAngulo;
                                    CorposCelestes[i].setAngulo(j, AjustaAngulo);
                                }
                                // Terceiro Quadrante
                                else if ((CorposCelestes[i].getDirY(j) < CorposCelestes[i].getPosY()) & (CorposCelestes[i].getDirX(j) < CorposCelestes[i].getPosX()))
                                {
                                    AjustaAngulo = Math.Atan2((CorposCelestes[i].getPosY() - CorposCelestes[i].getDirY(j)), (CorposCelestes[i].getPosX() - CorposCelestes[i].getDirX(j)));
                                    AjustaAngulo = AjustaAngulo * 180 / (Math.PI);
                                    AjustaAngulo = 180 + AjustaAngulo;
                                    CorposCelestes[i].setAngulo(j, AjustaAngulo);
                                }
                                // Quarto Quadrante
                                else if ((CorposCelestes[i].getDirY(j) < CorposCelestes[i].getPosY()) & (CorposCelestes[i].getDirX(j) > CorposCelestes[i].getPosX()))
                                {
                                    AjustaAngulo = Math.Atan2((CorposCelestes[i].getPosY() - CorposCelestes[i].getDirY(j)), (CorposCelestes[i].getDirX(j) - CorposCelestes[i].getPosX()));
                                    AjustaAngulo = AjustaAngulo * 180 / (Math.PI);
                                    AjustaAngulo = 360 - AjustaAngulo;
                                    CorposCelestes[i].setAngulo(j, AjustaAngulo);
                                }
                                //Sob algum eixo igual
                                else
                                {   // 1800 = Sob o eixo x  e 1801 = Sob o eixo y
                                    if (((CorposCelestes[i].getDirY(j) == CorposCelestes[i].getPosY()) & CorposCelestes[i].getDirX(j) != CorposCelestes[i].getPosX()))
                                    {
                                        CorposCelestes[i].setAngulo(j, 1800);
                                    }
                                    else if ((CorposCelestes[i].getDirY(j) != CorposCelestes[i].getPosY()) & CorposCelestes[i].getDirX(j) == CorposCelestes[i].getPosX())
                                    {
                                        CorposCelestes[i].setAngulo(j, 1801);
                                    }

                                }
                                //
                            }
                        }
                    }
                }
            }
            }

            // Decompondo a força em XY
            for (int i = 0; i < qntCorpos; i++)
            {
                if (CorposCelestes[i] != null)
                { 
                if (CorposCelestes[i].getNome() != "Morto")
                {
                        for (int j = 0; j < qntCorpos - 1; j++)
                        {
                            if (CorposCelestes[j] != null) { 
                                if (CorposCelestes[j].getNome() != "Morto")
                            {
                                if (CorposCelestes[i].getAngulo(j, false) == 1800) // Sob o eixo X
                                {
                                    CorposCelestes[i].setForçaX(j, CorposCelestes[i].getForça(j)); // Se estão sob o eixo X a força em x é igual a força resultante
                                    if (CorposCelestes[i].getDirX(j) < CorposCelestes[i].getPosX())
                                    {
                                        CorposCelestes[i].setForçaX(j, CorposCelestes[i].getForçaX(j) * -1); // Colocando os devidos sinais adotanto X para esquerda como negativo
                                    }
                                    CorposCelestes[i].setForçaY(j, 0);
                                }
                                else if (CorposCelestes[i].getAngulo(j, false) == 1801) // Sob o eixo Y
                                {
                                    CorposCelestes[i].setForçaY(j, CorposCelestes[i].getForça(j)); // Se estão sob o eixo Y a força em y é igual a força resultante
                                    if (CorposCelestes[i].getDirY(j) < CorposCelestes[i].getPosY())
                                    {
                                        CorposCelestes[i].setForçaY(j, CorposCelestes[i].getForçaY(j) * -1); // Colocando os devidos sinais adotanto Y para baixo como negativo
                                    }
                                    CorposCelestes[i].setForçaX(j, 0);
                                }
                                else
                                {
                                    // Decompondo a força em xy multiplicando a força resultante pelo angulo com o eixo x
                                    CorposCelestes[i].setForçaX(j, CorposCelestes[i].getForça(j) * Math.Cos(CorposCelestes[i].getAngulo(j, true)));
                                    CorposCelestes[i].setForçaY(j, CorposCelestes[i].getForça(j) * Math.Sin(CorposCelestes[i].getAngulo(j, true)));
                                    //
                                }
                            }
                        }
                    }
                }
            }
            }
            //Soma das forças X,Y,calculo da força resultante entre elas e das acelerações consequentes
            for (int i = 0; i < qntCorpos; i++)
            {
                if (CorposCelestes[i] != null) { 
                    if (CorposCelestes[i].getNome() != "Morto")
                    {
                        double fx = 0;
                        double fy = 0;
                        double fr = 0;
                        for (int j = 0; j < qntCorpos - 1; j++) // Soma das forças XY
                        {
                            fx += CorposCelestes[i].getForçaX(j);
                            fy += CorposCelestes[i].getForçaY(j);
                        }
                        fr = Math.Sqrt(Math.Pow(fx, 2) + Math.Pow(fy, 2)); // Pitagoras sendo a força resultante a hipotenusa
                        CorposCelestes[i].setForçaResultante(fx, fy, fr);
                        // Descobrindo a aceleração em XY usando f=ma
                        CorposCelestes[i].setAceleraçãoX(fx / CorposCelestes[i].getMassa());
                        CorposCelestes[i].setAceleraçãoY(fy / CorposCelestes[i].getMassa());
                        //
                    }
            }
            }
            // Formula de posição e velocidade 
            for (int i = 0; i < qntCorpos; i++)
            {
                if (CorposCelestes[i] != null) { 
                    if (CorposCelestes[i].getNome() != "Morto")
                {
                    CorposCelestes[i].setPosX((float)(CorposCelestes[i].getPosX() + CorposCelestes[i].getVelX() * tIteracao + (CorposCelestes[i].getAceleraçãoX() * Math.Pow(tIteracao, 2)) / 2));
                    CorposCelestes[i].setPosY((float)(CorposCelestes[i].getPosY() + CorposCelestes[i].getVelY() * tIteracao + (CorposCelestes[i].getAceleraçãoY() * Math.Pow(tIteracao, 2)) / 2));
                    CorposCelestes[i].setVelX((float)(CorposCelestes[i].getVelX() + CorposCelestes[i].getAceleraçãoX() * tIteracao));
                    CorposCelestes[i].setVelY((float)(CorposCelestes[i].getVelY() + CorposCelestes[i].getAceleraçãoY() * tIteracao));
                }
            }
            }
        }

        public string AllElements()
        {
            string text="";
            for (int i = 0; i < qntCorpos; i++)
            {
                if (CorposCelestes[i]!= null)
                {
                    if (CorposCelestes[i].getNome() != "Morto")
                    {
                        text += "\n";
                        text += CorposCelestes[i].log();
                    }
                }            
            }
            return text;
        }

    }
}
