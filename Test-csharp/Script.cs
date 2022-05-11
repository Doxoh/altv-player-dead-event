using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace Test_csharp;

public class Script : IScript
{
    [ScriptEvent(ScriptEventType.PlayerConnect)]
    public void PlayerConnect(IGamePlayer player, string reason)
    {
        player.SetDateTime(DateTime.UtcNow);
        player.Model = (uint) PedModel.FreemodeMale01;
        player.Position = new Position(0, 0, 75);
    }
}