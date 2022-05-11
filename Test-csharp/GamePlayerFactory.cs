using AltV.Net;
using AltV.Net.Elements.Entities;

namespace Test_csharp;

public class GamePlayerFactory : IEntityFactory<IPlayer>
{
    public IPlayer Create(ICore core, IntPtr entityPointer, ushort id)
    {
        return new GamePlayer(core, entityPointer, id);
    }
}