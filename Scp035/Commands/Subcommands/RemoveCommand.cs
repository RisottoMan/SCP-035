using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using Scp035.Features;

namespace Scp035.Commands.Subcommands;

public class RemoveCommand : ICommand
{
    public string Command => "remove";
    public string Description => "Remove a custom role SCP-035 for player";
    public string[] Aliases => [];
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (arguments.Count != 1)
        {
            response = $"Specify the player id to the command: scp035 remove [id]";
            return false;
        }
        
        Player player = Player.Get(arguments.At(0));
        if (player == null)
        {
            response = $"Player not found: {arguments.At(0)}";
            return false;
        }
        
        var scp066Role = CustomRole.Get(typeof(Scp035Role));
        if (scp066Role == null)
        {
            response = "Custom role SCP-035 not found or not registered";
            return false;
        }
        
        if (!scp066Role.Check(player))
        {
            response = "The player does not have the custom role SCP-035";
            return false;
        }
        
        scp066Role.RemoveRole(player);
        response = $"<color=green>Custom role SCP-035 removed for {player.Nickname}</color>";
        return true;
    }
}