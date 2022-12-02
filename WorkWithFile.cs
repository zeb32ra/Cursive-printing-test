using Newtonsoft.Json;

namespace SpeedText
{
    public static class WorkWithFile
    {
        public static void open_file()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            string text = File.ReadAllText("C:\\Users\\Настя\\Desktop\\users.json");
            Main.users = JsonConvert.DeserializeObject<List<Data>>(text);
            Console.WriteLine("Table of records");
            Console.WriteLine("-----------------------------");
            int i = 2;
            foreach (Data data in Main.users)
            {
                Console.SetCursorPosition(0, i);
                string b = data.name + "  " + data.simbols_per_minute + " Symbols per minute  " + data.simbols_per_second + " Symbols per second";
                Console.WriteLine(b);
                i++;
            }
            Console.SetCursorPosition(0, i);
            Console.WriteLine("Press Enter to Escape");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    System.Environment.Exit(0);
                }
            }
        }
        public static void save_to_file()
        {
            update_list();
            string json = JsonConvert.SerializeObject(Main.users);
            File.WriteAllText("C:\\Users\\Настя\\Desktop\\users.json", json);
        }
        private static void update_list()
        {
            string text = File.ReadAllText("C:\\Users\\Настя\\Desktop\\users.json");
            List <Data> in_file = JsonConvert.DeserializeObject<List<Data>>(text);
            if (in_file != null)
            {
                foreach (Data data in in_file)
                {
                    Main.users.Add(data);
                }
            }
        }
    }
}
