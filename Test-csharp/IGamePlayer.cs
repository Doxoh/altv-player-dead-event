using AltV.Net.Elements.Entities;

namespace Test_csharp;

public partial interface IGamePlayer : IPlayer
{
    void SetModel(uint model);
}