using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;

namespace Test_csharp;

public class Main : AsyncResource
{
    public override void OnStart()
    {
        Console.WriteLine("Started");
    }

    public override void OnStop()
    {
        Console.WriteLine("Stopped");
    }

    public override IEntityFactory<IPlayer> GetPlayerFactory()
    {
        return new GamePlayerFactory();
    }

}