using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha_Atualizado
{
    class Program
    {
        static void Main(string[] args)
        {
            string jogador1 = "", jogador2 = "";
            string[,] matriz = new string[3, 3];
            int vencedor = 0;
            for (int i = 0, valor = 1; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matriz[i, j] = Convert.ToString(valor);
                    valor++;
                }
            }
            imprimir_jogo(matriz);
            do
            {
                Console.Write("\n    Digite o nome do/a jogador(a) 1: ");
                jogador1 = Console.ReadLine();
            } while (jogador1 == "");
           //Controle para não deixar o espaço de nome vazio.
            do
            {
                Console.Write("\n    Digite o nome do/a jogador(a) 2: ");
                jogador2 = Console.ReadLine();
                Console.WriteLine();
            } while (jogador2 == "");
            
            jogada(matriz, jogador1, jogador2, ref vencedor);
            vencedor = verificaStatus(matriz);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (vencedor == 1) Console.WriteLine("    Jogador(a) 1: " + jogador1 + " é o/a Vencedor(a)");
            else if (vencedor == 2) Console.WriteLine("    Jogador(a) 2: " + jogador2 + " é o/a Vencedor(a)");
            else Console.WriteLine("    Deu velha...nenhum vencedor");
            Console.ReadKey();
        }
        static void imprimir_jogo(string[,] matriz) //Apenas para a parte gráfica do jogo.
        {
            Console.Clear();//limpa a tela para dar um efeito de atualização.
            Console.ForegroundColor = ConsoleColor.Cyan; //responsável pela cor
            Console.WriteLine("\n     <<<--Super Jogo da Velha-->>>\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;//responsável pela cor
            Console.WriteLine("           Fernando e Eric\n\n");
            Console.ResetColor();
            Console.WriteLine("    Escolha um numero para sua jogada\n");
            for (int i = 2; i >= 0; i--)
            {
                Console.WriteLine("\t#-------------------#");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("\t| ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(matriz[i, j]);
                    Console.ResetColor();
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\t#-------------------#");
        }
        static void jogada(string[,] matriz, string jogador1, string jogador2, ref int vencedor)
        {
            bool verifica = false;
            string label;
            int jogada = 0;
            for (int i = 1; i <= 9; i++)
            {
                verifica = false;
                if (i % 2 == 1) //O primeiro jogador sempre fara as jogadas impares e o segundo as pares.
                {
                    do //Loop para as jogadas do player 1
                    {
                        try //metodo anti - bug caso o usuário digite algo que não seja um número inteiro, evitando exceptions.
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\n    Digite apenas numeros inteiros de 1 até 9. Para confirmar a jogada aperte a tecla Enter.\n");
                            Console.ResetColor();
                            Console.Write("    " + jogador1 + ", faça sua jogada (" + i + "º round): " );
                            jogada = int.Parse(Console.ReadLine());
                            label = "X";
                            verificaPosicao(matriz, jogada, label, ref verifica);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Por favor, digite um valor inteiro de 1 até 9 para a sua jogada!");
                        }
                    }
                    while ((jogada < 1) || (jogada > 9) || (verifica == false));
                    imprimir_jogo(matriz);
                }
                else
                {
                    do //Loop para as jogadas do player 2
                    {
                        try //metodo anti-bug caso o usuário digite algo que não seja um número inteiro, evitando exceptions.
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\n    Digite apenas numeros inteiros de 1 até 9. Para confirmar a jogada aperte a tecla Enter.\n");
                            Console.ResetColor();
                            Console.Write("    "+ jogador2 + ", faça sua jogada (" + i + "º round): ");
                            jogada = int.Parse(Console.ReadLine());
                            label = "O";
                            verificaPosicao(matriz, jogada, label, ref verifica);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Por favor, digite um valor inteiro de 1 até 9 para sua jogada!");
                        }
                    }
                    while ((jogada < 1) || (jogada > 9) || (verifica == false));
                    imprimir_jogo(matriz);
                }
                vencedor = verificaStatus(matriz);
                if ((vencedor == 1) || (vencedor == 2)) i = 10; //IF e variavel usada para controle. Ao alterar valor de variavel de verificação o jogo encerra o jogo
            }

        }
        static void verificaPosicao(string[,] matriz, int jogada, string label, ref Boolean verifica)
        {
            if ((jogada <= 3) && (jogada >= 1))//bloco verificando se a posição de 1 a 3 está vazia
            {
                if ((jogada == 1) && (matriz[0, 0] != "X") && (matriz[0, 0] != "O"))
                {
                    verifica = true;
                    matriz[0, 0] = label;
                }
                if ((jogada == 2) && (matriz[0, 1] != "X") && (matriz[0, 1] != "O"))
                {
                    verifica = true;
                    matriz[0, 1] = label;
                }
                if ((jogada == 3) && (matriz[0, 2] != "X") && (matriz[0, 2] != "O"))
                {
                    verifica = true;
                    matriz[0, 2] = label;
                }
            }
            if ((jogada <= 6) && (jogada >= 4))//bloco verificando se a posição de 4 a 6 está vazia
            {
                if ((jogada == 4) && (matriz[1, 0] != "X") && (matriz[1, 0] != "O"))
                {
                    verifica = true;
                    matriz[1, 0] = label;
                }
                if ((jogada == 5) && (matriz[1, 1] != "X") && (matriz[1, 1] != "O"))
                {
                    verifica = true;
                    matriz[1, 1] = label;
                }
                if ((jogada == 6) && (matriz[1, 2] != "X") && (matriz[1, 2] != "O"))
                {
                    verifica = true;
                    matriz[1, 2] = label;
                }
            }
            if ((jogada <= 9) && (jogada >= 7))//bloco verificando se a posição de 7 a 9 está vazia
            {
                if ((jogada == 7) && (matriz[2, 0] != "X") && (matriz[2, 0] != "O"))
                {
                    verifica = true;
                    matriz[2, 0] = label;
                }
                if ((jogada == 8) && (matriz[2, 1] != "X") && (matriz[2, 1] != "O"))
                {
                    verifica = true;
                    matriz[2, 1] = label;
                }
                if ((jogada == 9) && (matriz[2, 2] != "X") && (matriz[2, 2] != "O"))
                {
                    verifica = true;
                    matriz[2, 2] = label;
                }
            }
        }
        static int verificaStatus(string[,] matriz)//verificação de status de vitoria ou empate.
        {
            int vencedor = 0;

            if ((matriz[0, 0] == matriz[0, 1]) && (matriz[0, 1] == matriz[0, 2]))
            {
                if (matriz[0, 0] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[1, 0] == matriz[1, 1]) && (matriz[1, 1] == matriz[1, 2]))
            {
                if (matriz[1, 0] == "X") vencedor = 1;//se condição for verdadeira então é X, se for a outra condição então é O. A mesma lógica se aplica aos outros Ifs.
                else vencedor = 2;
            }

            if ((matriz[2, 0] == matriz[2, 1]) && (matriz[2, 1] == matriz[2, 2]))
            {
                if (matriz[2, 0] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[0, 0] == matriz[1, 0]) && (matriz[1, 0] == matriz[2, 0]))
            {
                if (matriz[0, 0] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[0, 1] == matriz[1, 1]) && (matriz[1, 1] == matriz[2, 1]))
            {
                if (matriz[0, 1] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[0, 2] == matriz[1, 2]) && (matriz[1, 2] == matriz[2, 2]))
            {
                if (matriz[0, 2] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[0, 0] == matriz[1, 1]) && (matriz[1, 1] == matriz[2, 2]))
            {
                if (matriz[0, 0] == "X") vencedor = 1;
                else vencedor = 2;
            }

            if ((matriz[0, 2] == matriz[1, 1]) && (matriz[1, 1] == matriz[2, 0]))
            {
                if (matriz[0, 2] == "X") vencedor = 1;
                else vencedor = 2;
            }
            return vencedor;
        }
    }
}
