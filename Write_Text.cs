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
        bool timer_is_running = true;
        
        public void User_Writes(char[] content)
        {
            Thread timer = new Thread(new ThreadStart(Timer));
            timer.Start();
            int x = 0;
            int y = 0;
            int symbols_written = 0;

            foreach (char c in content)
            {
                if (timer_is_running == false)
                {
                    break;
                }
                else
                {
                    char name_of_button = Console.ReadKey().KeyChar;
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
            Main.chr_p_min = symbols_written;
            Main.chr_p_sec = symbols_written / 60;
            add_user_to_the_list();

        }
        public void Timer()
        {
            int time_sec = 60;
            timer_is_running = true;
            while (time_sec > 0) 
            {
                
                Console.SetCursorPosition(15, 6);
                Console.WriteLine("  ");
                Console.SetCursorPosition(0, 6);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Seconds left - " + time_sec);
                Thread.Sleep(1000);
                time_sec--;   
            }
            timer_is_running = false;
            Console.SetCursorPosition(15, 6);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Stop!");
            Thread.Sleep(2000);
            // open table of records
        }
        private void add_user_to_the_list()
        {
            Data user = new Data(Main.name, Main.chr_p_min, Main.chr_p_sec);
            Main.users.Add(user);
        }

    }
}
