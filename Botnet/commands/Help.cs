using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatSharp;
using System.Threading.Tasks;
using BotnetModuleAPI;

namespace Botnet.commands
{
    class Help : Command
    {
        public Help()
            : base("help")
        {
            ;
        }
            
        override public void Execute(IrcUser sender, String[] arguments, IrcChannel channel)
        {
            int helper = 0;
            StringBuilder sb = new StringBuilder("Commands [");
            StringBuilder sb2 = new StringBuilder();
          
            foreach(var Command in Program.getCommandManager().getCommands())
            {
                helper++;
                sb2.Append(Command.GetCatalyst() + " ");
            }
            sb.Append(helper + "] " + sb2);
            channel.SendMessage(sb.ToString());
        }
        //i cant hear u btw
    }
}
