using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp096;
using Exiled.Events.EventArgs.Scp330;
using Scp035.Features;

namespace Scp035;
public class EventHandler
{
    private Scp035Role _role;
    public EventHandler()
    {
        Exiled.Events.Handlers.Server.RoundStarted += this.OnRoundStarted;
        Exiled.Events.Handlers.Scp096.AddingTarget += this.OnAddingTarget;
        Exiled.Events.Handlers.Player.EnteringPocketDimension += this.OnEnteringPocketDimension;
        Exiled.Events.Handlers.Scp330.InteractingScp330 += this.OnInteractingScp330;
    }
    
    private void OnRoundStarted()
    {
        _role = CustomRole.Get(typeof(Scp035Role)) as Scp035Role;
        if (_role is null)
        {
            Log.Error("Custom role not found or not registered");
        }
    }
    
    /// <summary>
    /// Does not add SCP-066 for SCP-096 to targets
    /// </summary>
    private void OnAddingTarget(AddingTargetEventArgs ev)
    {
        if (_role != null && _role.Check(ev.Player))
        {
            ev.IsAllowed = false;
        }
    }
    
    /// <summary>
    /// Does not allow SCP-106 to teleport SCP-066 to a pocket dimension
    /// </summary>
    private void OnEnteringPocketDimension(EnteringPocketDimensionEventArgs ev)
    {
        if (_role != null && _role.Check(ev.Player))
        {
            ev.IsAllowed = false;
        }
    }

    /// <summary>
    /// Does not allow SCP-066 to take candies
    /// </summary>
    private void OnInteractingScp330(InteractingScp330EventArgs ev)
    {
        if (_role != null && _role.Check(ev.Player))
        {
            ev.IsAllowed = false;
        }
    }
}