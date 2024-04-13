using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log;

namespace TicTacToe
{
    internal class Game
    {
        private readonly Random random = new Random(DateTime.Now.Millisecond);
        private int step = 0;
        private readonly string[] msg = new string[] { "Победил игрок играющий крестиком!\n", "Победил игрок играющий ноликом!\n"};
        private readonly char cross = 'X', zero = 'O';
        private char[] Endaged = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        // 1 = 16, 2 = 20, 3 = 24, 4 = 44, 5 = 48, 6 = 52, 7 = 72, 8 = 76, 9 = 80
        string screen = "-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n";

        /// <summary>
        /// Метод проверяет свободные поля.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cr"></param>
        /// <returns></returns>
        private bool Is_Endaged(int value, char cr)
        {
            if (Endaged[value] != cross && Endaged[value] != zero)
            {
                Endaged[value] = cr;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Метод проверяет на ничью.
        /// </summary>
        /// <returns></returns>
        private bool Is_Draw()
        {
            for (int i = 0; i < Endaged.Length; i++)
            {
                if (Is_Endaged(i, Convert.ToChar(i + 49)))
                    return true;
            }
            Console.WriteLine("Ничья\nДля выход нажмите любую кнопку.");
            Console.ReadKey(true);
            return false;
        }

        /// <summary>
        /// Метод проверяет выигрышные ситуации.
        /// </summary>
        /// <returns></returns>
        private bool Is_Winner()
        {
            // 1 == 2 == 3
            if (Endaged[0] == Endaged[1] && Endaged[1] == Endaged[2])
            {
                Console.WriteLine(msg[step]);
                Console.ReadKey(true);
                return false;
            }

            // 4 == 5 == 6
            if (Endaged[3] == Endaged[4] && Endaged[4] == Endaged[5])
            {
                Console.WriteLine(msg[step]);
                Console.ReadKey(true);
                return false;
            }

            // 7 == 8 == 9
            if (Endaged[6] == Endaged[7] && Endaged[7] == Endaged[8])
            {
                Console.WriteLine(msg[step]);
                Console.ReadKey(true);
                return false;
            }

            // 1 == 5 == 9
            if (Endaged[0] == Endaged[4] && Endaged[4] == Endaged[8])
            {
                Console.WriteLine(msg[step]);
                Console.ReadKey(true);
                return false;
            }

            // 3 == 5 == 7
            if (Endaged[2] == Endaged[4] && Endaged[4] == Endaged[6])
            {
                Console.WriteLine(msg[step]);
                Console.ReadKey(true);
                return false;
            }

            // 1 == 4 == 7
            if (Endaged[0] == Endaged[3] && Endaged[3] == Endaged[6])
            {
                Console.WriteLine(msg[step]);
                Console.ReadKey(true);
                return false;
            }

            // 2 == 5 == 8
            if (Endaged[1] == Endaged[4] && Endaged[4] == Endaged[7])
            {
                Console.WriteLine(msg[step]);
                Console.ReadKey(true);
                return false;
            }

            // 3 == 6 == 9
            if (Endaged[2] == Endaged[5] && Endaged[5] == Endaged[8])
            {
                Console.WriteLine(msg[step]);
                Console.ReadKey(true);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Ход компьютера.
        /// </summary>
        /// <param name="cr"></param>
        private void ComLogic(char cr)
        {
            bool cycle = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ход компьютера");
            Console.WriteLine($"Вы играете {cr}\n");
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                if (Is_Endaged(random.Next(9), cr))
                    cycle = false;
            } while (cycle);
            System.Threading.Thread.Sleep(1000);
        }

        /// <summary>
        /// Ход игрока.
        /// </summary>
        /// <param name="cr"></param>
        private void Player(char cr)
        {
            bool cycle = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ход игрока");
            Console.WriteLine($"Вы играете {cr}\n");
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                while (cycle)
                {
                    Console.SetCursorPosition(0, 12);
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("                                                                                                    ");
                    }
                    Console.SetCursorPosition(0, 12);
                    Console.Write("Введите номер свободной ячейки: ");
                    if (!Is_Endaged(Convert.ToInt32(Console.ReadLine()) - 1, cr))
                    {
                        Console.WriteLine("Такой ход уже был!\n");
                        Console.ReadKey(true);
                    }
                    else
                        cycle = false;
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex.TargetSite + ex.Message);
            }
        }

        /// <summary>
        /// Метод переключает ходы.
        /// </summary>
        private void Step()
        {
            if (step == 0)
            {
                ComLogic(zero);
                //Player(zero);
                step = 1;              
            }
            else
            {
                Player(cross);
                step = 0;
            }
        }

        /// <summary>
        /// Метод очищает игровое поле.
        /// </summary>
        private void Clear()
        {
            string empty = "                                                                    ";
            Console.SetCursorPosition(0, 0);
            try
            {
                for (int y = 0; y < 10; y++)
                    Console.WriteLine(empty);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.TargetSite + ex.Message);
            }
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Метод рисует игровую сцену.
        /// </summary>
        void Screen()
        {
            for (int i = 0, m = 0, j = 16; i < 9; i++)
            {
                StringBuilder sb = new StringBuilder(screen);
                sb[j] = Endaged[i];
                screen = sb.ToString();
                if (m >= 0 && m <= 1)
                {
                    j += 4;
                    m++;
                }
                else
                {
                    j += 20;
                    m = 0;
                }
            }
            Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Игра крестики - нолики\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(screen);
        }

        /// <summary>
        /// Метод 
        /// </summary>
        public void Play()
        {
            step = random.Next(2);
            do
            {
                Screen();
                Step();
                Screen();
            }
            while (Is_Winner() && Is_Draw());
        }
    }
}
