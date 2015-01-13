using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSharp;

namespace Botnet.commands
{
    class ListUsers : Command
    {
        public ListUsers()
            : base("list")
        {
            ;
        }

        override public void execute(IrcUser sender, String[] arguments, IrcChannel channel)
        {
            if (arguments.Length > 1)
            {
                try
                {
                    int helper = 0;
                    StringBuilder sb = new StringBuilder("Users [");
                    StringBuilder sb2 = new StringBuilder();
                    foreach (var User in Program.getInstance().getClient().Channels[arguments[1]].Users)
                    {
                        helper++;
                        sb2.Append(User.Nick + " ");
                    }
                    sb.Append(helper + "] " + sb2);
                    channel.SendMessage(sb.ToString());
                }
                catch (KeyNotFoundException e)
                {
                    channel.SendMessage("Channel " + arguments[1] + " was not found. (null)");
                }
            }
            else
            {
                channel.SendMessage("Please put a channel to list users for.");
            }
        }

    }
}
