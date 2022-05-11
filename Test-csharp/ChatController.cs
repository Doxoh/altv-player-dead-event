using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Enums;
using AltV.Net.FunctionParser;

namespace Test_csharp;

public class ChatController : IScript
{
    private delegate Task CommandDelegate(IGamePlayer sender, string[] args);
    
    private readonly IDictionary<string, CommandDelegate> _commands;

    public ChatController()
    {
        _commands = new Dictionary<string, CommandDelegate>();

        ModuleScriptMethodIndexer.Index(this, new[] { typeof(CommandAttribute) }, (baseEvent, eventMethod, eventMethodDelegate) =>
        {
            var commandAttribute = (CommandAttribute)baseEvent;
            string commandName = commandAttribute.Name ?? eventMethod.Name;
            var function = Alt.CreateFunction(eventMethodDelegate);

            if (function == null)
            {
                throw new Exception($"Unsupported command method: {eventMethod}");
            }

            _commands.Add(commandName, (player, args) =>
            {
                return Task.Run(() =>
                {
                    function.Call(player, args);
                    return Task.CompletedTask;
                });
            });
        });

    }
        
        [AsyncClientEvent("chatmessage")]
        public async Task OnChatMessageAsync(IGamePlayer sender, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            if (message.StartsWith('/'))
            {
                var splittedMessage = message.Substring(1).Split(' ');
                string commandName = splittedMessage[0];
                var commandArgs = splittedMessage.Skip(1).ToArray();

                if (!_commands.TryGetValue(commandName.ToLowerInvariant(), out var command))
                {
                    return;
                }

                await command(sender, commandArgs);
            }
        }
    
        [Command("male1")]
        public Task OnMale1Async(IGamePlayer sender)
        {
            Console.WriteLine("Test Command");
            sender.ToAsync().Model = (uint) PedModel.FreemodeMale01;
        
            return Task.CompletedTask;
        }
    
        [Command("male2")]
        public Task OnMale2Async(IGamePlayer sender)
        {
            Console.WriteLine("Test Command");
            sender.ToAsync().SetModel((uint) PedModel.FreemodeMale01);
        
            return Task.CompletedTask;
        }

}