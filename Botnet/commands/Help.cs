using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatSharp;
using System.Threading.Tasks;
<<<<<<< HEAD
using BotnetModuleAPI;
=======
>>>>>>> a4e158ca0325073cf5a52165e917018a251b3acf

namespace Botnet.commands
{
    class Help : Command
    {
        public Help()
            : base("help")
        {
            ;
        }
            
<<<<<<< HEAD
        override public void Execute(IrcUser sender, String[] arguments, IrcChannel channel)
=======
        override public void execute(IrcUser sender, String[] arguments, IrcChannel channel)
>>>>>>> a4e158ca0325073cf5a52165e917018a251b3acf
        {
            int helper = 0;
            StringBuilder sb = new StringBuilder("Commands [");
            StringBuilder sb2 = new StringBuilder();
          
            foreach(var Command in Program.getCommandManager().getCommands())
            {
                helper++;
<<<<<<< HEAD
                sb2.Append(Command.GetCatalyst() + " ");
=======
                sb2.Append(Command.getCatalyst() + " ");
>>>>>>> a4e158ca0325073cf5a52165e917018a251b3acf
            }
            sb.Append(helper + "] " + sb2);
            channel.SendMessage(sb.ToString());
        }
        //i cant hear u btw
    }
}
