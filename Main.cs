using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SpeedText
{
    internal class Main
    {
        public static string name;
        public static int chr_p_min;
        public static int chr_p_sec;
        Write_Text txt = new Write_Text();
        public static List<Data> users = new List<Data> ();
        public string text = "Текст делится на разные части: предложения, абзацы, параграфы, главы и т. д. Дальше, когда мы будем рассказывать о его отличительных чертах, мы будем говорить именно «части», но при этом иметь в виду их все.";
        public bool we_are_in_menu = true;
        public void programm()
        {
            if (we_are_in_menu) // I can remove if and flag
            {
                Menu();
            }

        }
        private void Menu()
        {
            Console.WriteLine("Input your name for table of records:");
            name = Console.ReadLine();
            Test();
        }
        private void Test()
        {
            Console.Clear();
            Console.WriteLine(text);
            Console.WriteLine("------------------------------");
            Console.WriteLine("Press Enter when you are ready");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                char[] content = text.ToArray();
                txt.User_Writes(content);
            }
        }
    }
}
