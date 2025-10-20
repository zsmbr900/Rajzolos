using System.Drawing;

namespace ConsoleApp1
{
    internal class Program
    {
        public static bool colorChangeMode = false;
        public static bool helpMode = false;

        public static int width = Console.WindowWidth;
        public static int height = Console.WindowHeight;
        static void Keret()
        {
            colorChangeMode = false;
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('═');
                Console.SetCursorPosition(i, height - 1);
                Console.Write('═');
            }

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                if (i == 0)
                {
                    Console.Write("╔");
                }
                else if (i == height - 1)
                {
                    Console.Write("╚");
                }
                else
                {
                    Console.Write('║');
                }

                Console.SetCursorPosition(width - 1, i);
                if (i == 0)
                {
                    Console.Write("╗");
                }
                else if (i == height - 1)
                {
                    Console.Write("╝");
                }
                else
                {
                    Console.Write('║');
                }
            }
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
        }

        static void szinvalto()
        {
            Console.ForegroundColor = (ConsoleColor)(((int)Console.ForegroundColor + 1) % 16);
            if (Console.ForegroundColor == 0) { Console.ForegroundColor = Console.ForegroundColor + 1; }
        }

        static void Helpablak()
        {
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < width / 2; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('═');
                Console.SetCursorPosition(i, height / 2);
                Console.Write('═');
            }

            for (int i = 0; i < height / 2 + 1 ; i++)
            {
                Console.SetCursorPosition(0, i);
                if (i == 0)
                {
                    Console.Write("╔");
                }
                else if (i == height / 2)
                {
                    Console.Write("╠");
                }
                else
                {
                    Console.Write('║');
                }

                Console.SetCursorPosition(width / 2, i);
                if (i == 0)
                {
                    Console.Write("╦");
                }
                else if (i == height / 2)
                {
                    Console.Write("╝");
                }
                else
                {
                    Console.Write('║');
                }
            }
        }
            static void Main(string[] args)
            {
                Keret();
                do
                {
                    var key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.DownArrow:
                            if (colorChangeMode) szinvalto();
                            if (Console.CursorTop < Console.WindowHeight - 2)
                            {
                                Console.Write('▓');
                                Console.CursorTop++;
                                Console.CursorLeft--;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (colorChangeMode) szinvalto();
                            if (Console.CursorTop > 1)
                            {
                                Console.Write('▓');
                                Console.CursorTop--;
                                Console.CursorLeft--;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (colorChangeMode) szinvalto();
                            if (Console.CursorLeft > 1)
                            {
                                Console.Write('▓');
                                Console.CursorLeft = Console.CursorLeft - 2;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (colorChangeMode) szinvalto();
                            if (Console.CursorLeft < Console.WindowWidth - 2)
                            {
                                Console.Write('▓');
                            }
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        case ConsoleKey.Delete:
                            Console.Clear();
                            Keret();
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case ConsoleKey.Spacebar:
                            Console.Write(' ');
                            break;
                        case ConsoleKey.PageUp:
                            colorChangeMode = !colorChangeMode;
                            break;
                        case ConsoleKey.PageDown:
                            colorChangeMode = !colorChangeMode;
                            break;
                        case ConsoleKey.F1:
                        helpMode = !helpMode;
                        if (helpMode)
                        {
                            Helpablak();
                        }
                        else
                        {
                            Console.Clear();
                            Keret();
                        }
                        break;
                    }

                }
                while (true);
            }
    }
}
