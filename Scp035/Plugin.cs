using System;
using Exiled.API.Features;
using Exiled.CustomRoles.API;
using Scp035.Configs;

namespace Scp035;
public class Plugin : Plugin<Config>
{
    public override string Name => "Scp035";
    public override string Author => "RisottoMan && Konoara";
    public override Version Version => new(1, 0, 0);
    public override Version RequiredExiledVersion => new(9, 6, 0);
    
    public static Plugin Singleton;
    public override void OnEnabled()
    {
        Singleton = this;
        
        // Setup the RoleAPI
        if (!RoleAPI.Startup.SetupAPI(this.Name))
            return;
        
        // Register the custom role
        Config.Scp035RoleConfig.Register();
        
        new EventHandler();
        
        base.OnEnabled();
    }
}