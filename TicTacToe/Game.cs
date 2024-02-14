using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Game
    {
        Random random = new Random();
        int num = 0, step = 0;
        string msg1 = "Победил игрок играющий крестиком!\n";
        //string msg1 = "Победил игрок!\n";
        //string msg2 = "Победил компьютер!\n";
        string msg2 = "Победил игрок играющий ноликом!\n";
        char cross = 'X', zero = 'O';
        char[] Endaged = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        string screen = "-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n|   |   |   |\n-------------\n";
        // 1 = 16, 2 = 20, 3 = 24, 4 = 44, 5 = 48, 6 = 52, 7 = 72, 8 = 76, 9 = 80

        // Проверяем занято поле.
        bool Is_Endaged(int num, char sim)
        {
            switch (num)
            {
                case 1:
                    {
                        if (Endaged[0] == '1')
                        {
                            Endaged[0] = sim;
                            return true;
                        }
                        else
                            return false;
                    }

                case 2:
                    {
                        if (Endaged[1] == '2')
                        {
                            Endaged[1] = sim;
                            return true;
                        }
                        else
                            return false;
                    }

                case 3:
                    {
                        if (Endaged[2] == '3')
                        {
                            Endaged[2] = sim;
                            return true;
                        }
                        else
                            return false;
                    }

                case 4:
                    {
                        if (Endaged[3] == '4')
                        {
                            Endaged[3] = sim;
                            return true;
                        }
                        else
                            return false;
                    }

                case 5:
                    {
                        if (Endaged[4] == '5')
                        {
                            Endaged[4] = sim;
                            return true;
                        }
                        else
                            return false;
                    }

                case 6:
                    {
                        if (Endaged[5] == '6')
                        {
                            Endaged[5] = sim;
                            return true;
                        }
                        else
                            return false;
                    }

                case 7:
                    {
                        if (Endaged[6] == '7')
                        {
                            Endaged[6] = sim;
                            return true;
                        }
                        else
                            return false;
                    }

                case 8:
                    {
                        if (Endaged[7] == '8')
                        {
                            Endaged[7] = sim;
                            return true;
                        }
                        else
                            return false;
                    }

                case 9:
                    {
                        if (Endaged[8] == '9')
                        {
                            Endaged[8] = sim;
                            return true;
                        }
                        else
                            return false;
                    }

                default:
                    {
                        Console.WriteLine("\x1b[31mВведены некорректные данные!\x1b[0m");
                        Console.ReadKey(true);
                        return false;
                    }
            }
        }

        // Ничья
        bool Is_Draw()
        {
            for (int i = 1; i <= Endaged.Length; i++)
            {
                if (Is_Endaged(i, Convert.ToChar(i + 48)))
                    return true;
            }
            Console.WriteLine("Ничья\nДля выход нажмите любую кнопку");
            Console.ReadKey(true);
            return false;
        }

        // Метод проверяет выигрышные ситуации.
        bool Is_Winner()
        {
            // cross == 1 == 2 == 3
            if (cross == Endaged[0] && Endaged[0] == Endaged[1] && Endaged[1] == Endaged[2])
            {
                Console.WriteLine(msg1);
                Console.ReadKey(true);
                return false;
            }

            // cross == 4 == 5 == 6
            if (cross == Endaged[3] && Endaged[3] == Endaged[4] && Endaged[4] == Endaged[5])
            {
                Console.WriteLine(msg1);
                Console.ReadKey(true);
                return false;
            }

            // cross == 7 == 8 == 9
            if (cross == Endaged[6] && Endaged[6] == Endaged[7] && Endaged[7] == Endaged[8])
            {
                Console.WriteLine(msg1);
                Console.ReadKey(true);
                return false;
            }

            // cross == 1 == 5 == 9
            if (cross == Endaged[0] && Endaged[0] == Endaged[4] && Endaged[4] == Endaged[8])
            {
                Console.WriteLine(msg1);
                Console.ReadKey(true);
                return false;
            }

            // cross == 3 == 5 == 7
            if (cross == Endaged[2] && Endaged[2] == Endaged[4] && Endaged[4] == Endaged[6])
            {
                Console.WriteLine(msg1);
                Console.ReadKey(true);
                return false;
            }

            // cross == 1 == 4 == 7
            if (cross == Endaged[0] && Endaged[0] == Endaged[3] && Endaged[3] == Endaged[6])
            {
                Console.WriteLine(msg1);
                Console.ReadKey(true);
                return false;
            }

            // cross == 2 == 5 == 8
            if (cross == Endaged[1] && Endaged[1] == Endaged[4] && Endaged[4] == Endaged[7])
            {
                Console.WriteLine(msg1);
                Console.ReadKey(true);
                return false;
            }

            // cross == 3 == 6 == 9
            if (cross == Endaged[2] && Endaged[2] == Endaged[5] && Endaged[5] == Endaged[8])
            {
                Console.WriteLine(msg1);
                Console.ReadKey(true);
                return false;
            }

            // zero == 1 == 2 == 3
            if (zero == Endaged[0] && Endaged[0] == Endaged[1] && Endaged[1] == Endaged[2])
            {
                Console.WriteLine(msg2);
                Console.ReadKey(true);
                return false;
            }

            // zero == 4 == 5 == 6
            if (zero == Endaged[3] && Endaged[3] == Endaged[4] && Endaged[4] == Endaged[5])
            {
                Console.WriteLine(msg2);
                Console.ReadKey(true);
                return false;
            }

            // zero == 7 == 8 == 9
            if (zero == Endaged[6] && Endaged[6] == Endaged[7] && Endaged[7] == Endaged[8])
            {
                Console.WriteLine(msg2);
                Console.ReadKey(true);
                return false;
            }

            // zero == 1 == 5 == 9
            if (zero == Endaged[0] && Endaged[0] == Endaged[4] && Endaged[4] == Endaged[8])
            {
                Console.WriteLine(msg2);
                Console.ReadKey(true);
                return false;
            }

            // zero == 3 == 5 == 7
            if (zero == Endaged[2] && Endaged[2] == Endaged[4] && Endaged[4] == Endaged[6])
            {
                Console.WriteLine(msg2);
                Console.ReadKey(true);
                return false;
            }

            // zero == 1 == 4 == 7
            if (zero == Endaged[0] && Endaged[0] == Endaged[3] && Endaged[3] == Endaged[6])
            {
                Console.WriteLine(msg2);
                Console.ReadKey(true);
                return false;
            }

            // zero == 2 == 5 == 8
            if (zero == Endaged[1] && Endaged[1] == Endaged[4] && Endaged[4] == Endaged[7])
            {
                Console.WriteLine(msg2);
                Console.ReadKey(true);
                return false;
            }

            // zero == 3 == 6 == 9
            if (zero == Endaged[2] && Endaged[2] == Endaged[5] && Endaged[5] == Endaged[8])
            {
                Console.WriteLine(msg2);
                Console.ReadKey(true);
                return false;
            }

            return true;
        }

        // Ход компьютера
        void ComLogic(char sim)
        {
            bool cycle = true;
            Console.WriteLine("Ход компьютера");
            Console.WriteLine($"Вы играете {sim}\n");
            do
            {
                num = random.Next(8 + 1);
                if (Is_Endaged(num, sim))
                    cycle = false;
            } while (cycle);
            System.Threading.Thread.Sleep(2000);
        }

        // Ход игрока
        void Player(char sim)
        {
            bool cycle = true;
            Console.WriteLine("Ход игрока");
            Console.WriteLine($"Вы играете {sim}\n");
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
                    num = Convert.ToInt32(Console.ReadLine());
                    if (!Is_Endaged(num, sim))
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
                Console.WriteLine(ex.Message);
                Console.WriteLine("Для продолжения нажмите любую клавишу!");
                Console.ReadKey();

            }
        }

        // Кто ходит?
        void Step()
        {
            if (step == 0)
            {
                Player(cross);
                step++;
            }
            else
            {
                //ComLogic(zero);
                Player(zero);
                step = 0;
            }
        }

        // 
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
            Console.Clear();
            Console.WriteLine("Игра крестики - нолики\n");
            Console.Write(screen);
        }

        //
        public void Play()
        {
            step = random.Next(2 + 0);
            do
            {
                Screen();
                Step();
                Screen();
            } while (Is_Winner() && Is_Draw());
        }
    }
}
