using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatSharp;

namespace Botnet
{
    class Program

    {

        public static CommandManager cs;

        static void Main(string[] args)
        {
            cs = new CommandManager();
            cs.setup();
            var client = new IrcClient("irc.freenode.net", new IrcUser(System.Environment.MachineName, "RudyBOT"));
            client.ConnectionComplete += (s, e) => client.JoinChannel("#Faurax");
            client.ChannelMessageRecieved += (s, e) =>
            {
                Console.WriteLine("Received message \"" + e.PrivateMessage.Message + "\" from " + e.PrivateMessage.User.Nick);
                String[] arguments = e.PrivateMessage.Message.Substring(1).Split(' ');
                foreach(var Command in cs.getCommands()){
                    Console.WriteLine("Trying to execute command : " + Command.getCatalyst());
                    if (Command.getCatalyst().ToLower() == arguments[0]);
                    {
                        Console.WriteLine("Successfull evaluation of command " + Command.ToString());
                        Command.execute(e.PrivateMessage.User.Nick,arguments);
                    }
                }
            };

            client.ConnectAsync();
            while (true) ;
        }   
    }
}
