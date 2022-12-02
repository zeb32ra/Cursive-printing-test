using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpeedText
{
    internal class Write_Text
    {
        public static bool timer_is_running = true;
        int symbols_written;
        
        public void User_Writes(char[] content)
        {
            Thread timer = new Thread(new ThreadStart(Timer));
            timer.Start();
            int x = 0;
            int y = 0;
            

            foreach (char c in content)
            {
                if (timer_is_running == false)
                {
                    break;
                }
                else
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    char name_of_button = key.KeyChar;
                    if (key.Key == ConsoleKey.Enter)
                    {
                        timer_is_running = false;
                        add_user_to_the_list(symbols_written);
                        WorkWithFile.save_to_file();
                        WorkWithFile.open_file();
                        break;

                    }
                    if (name_of_button == c)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(x, y);
                        Console.Write(c);
                        symbols_written++;
                        x++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(x, y);
                        Console.Write(name_of_button);
                        symbols_written++;
                        x++;
                    }
                    

                }
                

            }

        }
        public void Timer()
        {
            int time_sec = 60;
            timer_is_running = true;
            while (time_sec > 0) 
            {
                if (timer_is_running)
                {
                    Console.SetCursorPosition(15, 6);
                    Console.WriteLine("           ");
                    Console.SetCursorPosition(0, 6);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Seconds left - " + time_sec);
                    Thread.Sleep(1000);
                    time_sec--;
                }  
            }
            timer_is_running = false;
            Console.SetCursorPosition(15, 6);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Stop!");
            Thread.Sleep(2000);
            add_user_to_the_list(symbols_written);
            WorkWithFile.save_to_file();
            WorkWithFile.open_file();
        }
        private void add_user_to_the_list(int symbols_written)
        {
            int chr_p_min = symbols_written;
            float chr_p_sec = symbols_written / 60;
            string name = Main.name;
            Data user = new Data(name, chr_p_min, chr_p_sec);
            Main.users.Add(user);
        }

    }
}
