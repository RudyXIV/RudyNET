using System;
using System.Collections.Generic;
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

        public void setup()
        {
            commands.Add(new Help());
            commands.Add(new ListUsers());
            foreach (var Command in commands)
            {
                Console.WriteLine("Loaded command -- " + Command.getCatalyst());
            }
        }

    }
}
