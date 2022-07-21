using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace Test_csharp;

public class Main : AsyncResource
{
    public Main() : base(true)
    {
        
    }
    
    public override void OnStart()
    {
        Console.WriteLine("Started");
    }

    public override void OnStop()
    {
        Console.WriteLine("Stopped");
    }
}