using System;

namespace book_seats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int num;
            char[,] allSeats = new char[8 , 20];
            int operationSelection;
            int rowInput;
            int seatInput;

            for (int i = 0; i < allSeats.GetLength(0); i++)
            {
                for (int j = 0; j < allSeats.GetLength(1); j++)
                {
                    num = rand.Next(0,2);
                    if (num == 0)
                    {
                        allSeats[i, j] = 'X';
                    }
                    else
                    {
                        allSeats[i, j] = 'O';
                    }
                }
            }

            while(true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Илюстрация зала. Свободные места помечены символом O, занятые символом X");
                Console.WriteLine("\n   1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20");
                Console.WriteLine("\n1\n\n2\n\n3\n\n4\n\n5\n\n6\n\n7\n\n8");
                for (int i = 0; i < allSeats.GetLength(0); i++)
                {
                    for (int j = 0; j < allSeats.GetLength(1); j++)
                    {
                        Console.SetCursorPosition(3 + j * 3, 4 + i * 2);
                        if (allSeats[i, j] == 'O')
                        {
                            Console.ForegroundColor= ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                            Console.Write(allSeats[i, j] + "  ");
                    }

                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("Введите 1 если хотите забронировать место, и 0 если хотите завершить программу:");

                operationSelection = Convert.ToInt32(Console.ReadLine());

                if(operationSelection == 1)
                {
                    while(true)
                    {
                        Console.WriteLine("Введите ряд, в котором хотели бы сидеть:");
                        rowInput = Convert.ToInt32(Console.ReadLine());
                        if(rowInput == 0 || rowInput > 8)
                        {
                            Console.WriteLine("Вы допустили ошибку при вводе, попробуйте ещё раз:");
                            break;
                        }    

                        Console.WriteLine("Введите место в этом ряду на котором хотели бы сидеть:");
                        seatInput = Convert.ToInt32(Console.ReadLine());
                        if (seatInput == 0 || seatInput > 20)
                        {
                            Console.WriteLine("Вы допустили ошибку при вводе, попробуйте ещё раз:");

                            break;
                        }
                        
                        if (allSeats[rowInput - 1, seatInput - 1] == 'X')
                        {
                            Console.WriteLine("Это место уже занято");
                            break;
                        }
                        else
                        {
                            allSeats[rowInput - 1, seatInput - 1] = 'X';
                            Console.WriteLine($"Вы забронировали место {rowInput}-{seatInput}");
                            break;
                        }
                    }
                }
                else if (operationSelection == 0)
                {
                    Console.WriteLine("До свидания");
                    Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("вы допустили ошибку при вводе, попробуйте ещё раз:");
                }

                Console.WriteLine("Для продолжения нажмите любую клавишу . . .");
                Console.ReadKey();

            }
        }
    }
}
