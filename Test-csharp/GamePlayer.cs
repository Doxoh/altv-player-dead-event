using AltV.Net;
using AltV.Net.Async.CodeGen;
using AltV.Net.Elements.Entities;

namespace Test_csharp;

[AsyncEntity(typeof(IGamePlayer))]
public partial class GamePlayer : Player, IGamePlayer
{
    public GamePlayer(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
    {
    }

    public void SetModel(uint model)
    {
        this.Model = model;
    }
}