using System.ComponentModel;
using Exiled.API.Interfaces;
using Scp035.Features;

namespace Scp035.Configs;

public class Config : IConfig
{
    [Description("Whether or not is the plugin enabled?")]
    public bool IsEnabled { get; set; } = true;

    [Description("Whether or not is the plugin is in debug mode?")]
    public bool Debug { get; set; } = false;

    [Description("Configs for the custom role players")]
    public Scp035Role Scp035RoleConfig { get; set; } = new();
}