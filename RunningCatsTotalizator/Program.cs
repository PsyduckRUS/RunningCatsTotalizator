using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningCatsTotalizator
{
    class Program
    {
        public static int version = 1;
        public const int distance = 1000;
        public static int winNumber;
        public static double bestTime = 0;
        public static int playerPrediction;
        static void Main(string[] args)
        {
            Console.WriteLine($"Добро пожаловать в \"Симулятор кошачьих бегов версии\" {version}");
            Console.WriteLine($"Правила очень просты: у нас есть {Cat.totalCatsInTheGame} котов, участвующих в забеге!");
            Console.WriteLine($"Каждый из котов имеет свой уникальный номер. Вам нужно угадать кто прибежит к финишу первым.");
            Console.WriteLine($"Для этого достаточно просто ввести его номер с клавиатуры и узнать угадали или нет!");
            Console.WriteLine($"Хотите сыграть? (введите \"да\" чтобы сыграть или \"нет\", чтобы завершить игру)");
            while (true)
            {
                string firstInput = Console.ReadLine();

                if (firstInput.Equals("да"))
                {
                    Random rnd = new Random();
                    Console.Clear();
                    Console.WriteLine($"Отлично!!! Забег вот вот начнется, какой номер по вашему мнению выиграет ? Укажите пожалуйста число от 1 до {Cat.totalCatsInTheGame}");
                    playerPrediction = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Спортсмены готовы! Нажмите любую клавишу чтобы начать забег!");
                    Console.ReadKey();
                    for (int i = 1; i < (Cat.totalCatsInTheGame + 1); i++)
                    {
                        Cat contestant = new Cat();
                        contestant.catNumber = i;
                        int r = rnd.Next(1, 11);
                        contestant.catSpeed = 10 * r;
                        double result = contestant.CatTime(distance, contestant.catSpeed);


                        if (bestTime == 0)
                        {
                            bestTime = result;
                            winNumber = contestant.catNumber;
                        }
                        else
                        {
                            if (result <= bestTime)
                            {
                                bestTime = result;
                                winNumber = contestant.catNumber;
                            }
                        }
                    }

                    Console.WriteLine($"Победил кот под номером: {winNumber}, пробежав дистанцию за = {bestTime} секунд!");


                    if (playerPrediction == winNumber)
                    {
                        Console.WriteLine("ПОЗДРАВЛЯЕМ!!! Вы угадали!");
                        Console.WriteLine("Спасибо за игру! До встречи");
                    }
                    else
                    {
                        Console.WriteLine("Очень жаль, но вы проиграли!");
                        Console.WriteLine("В следующий раз непременно повезет! До встречи!");
                    }


                    break;
                }
                else
                {
                    if (firstInput.Equals("нет"))
                    {
                        Console.Clear();
                        Console.WriteLine("Очень жаль! До встречи!");
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Вы ввели что - то не то! Давайте еще раз...");
                    }
                }
         
            }
            Console.ReadKey();
        }
    }
    public class Cat
    {
        public static int totalCatsInTheGame = 10;
        public int catNumber;
        public int catSpeed;

        public double CatTime(int distance, int catSpeed)
        {
            return (distance / catSpeed);
        }
    }
}

