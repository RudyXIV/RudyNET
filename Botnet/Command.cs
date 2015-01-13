using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSharp;

namespace Botnet
{
    abstract class Command
    {

        public String catalyst;

        public Command(String catalyst)
        {
            this.catalyst = catalyst;
        }

        public String getCatalyst()
        {
            return catalyst;
        }

        public abstract void execute(IrcUser sender, String[] arguments, IrcChannel channel);


    }
}
