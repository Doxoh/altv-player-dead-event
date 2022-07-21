using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace Test_csharp;

public class Script : IScript
{
    [ScriptEvent(ScriptEventType.PlayerConnect)]
    public void PlayerConnect(IPlayer player, string reason)
    {
        player.SetDateTime(DateTime.UtcNow);
        player.Model = (uint) PedModel.FreemodeMale01;
        player.Spawn(new Position(0, 0, 250));
        player.Dimension = 0;
    }
    
    [ScriptEvent(ScriptEventType.PlayerDead)]
    public void OnPlayerDamage(IPlayer player, IEntity killer, uint weapon)
    {
        Console.WriteLine("PlayerDead");
        player.Health = 200;
        player.Spawn(new Position(0, 0, 250));
    }
}