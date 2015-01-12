using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botnet.commands
{
    class Help : Command
    {
        public Help()
            : base("Help")
        {
            ;
        }
            
        override public void execute(String sender, String[] arguments)
        {
            Console.WriteLine("Received Command: HelpV2");
        }

    }
}
