using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Botnet.commands;
using System.Threading.Tasks;

namespace Botnet
{
    class CommandManager
    {

        public static List<Command> commands = new List<Command>();

        public List<Command> getCommands()
        {
            return commands;
        }

        public void loadDLLs()
        {
            Directory.CreateDirectory(System.Environment.CurrentDirectory + "\\modules");
            string[] filePaths = Directory.GetFiles(@""+System.Environment.CurrentDirectory+"\\modules", "*.dll");
            foreach (string STR in filePaths)
            {
               commands.Add((Command) Activator.CreateInstance(Type.GetType(STR+"."+STR+", "+STR, true)));
            }
        }

        public void setup()
        {
            commands.Add(new Help());
            commands.Add(new ListUsers());
            foreach (var command in commands)
            {
                Console.WriteLine("Loaded command -- " + command.getCatalyst());
            }
        }

    }
}
