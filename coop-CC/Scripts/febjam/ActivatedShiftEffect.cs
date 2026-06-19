using Aggro.Core;
using Aggro.Core.Networking;

public class ActivatedShiftEffect : EntityBehaviourBase, IBoxActivated
{
	public bool pauseShift = true;

	public float pauseDuration = 10f;

	public void ServerBoxActivated(ActivationContext context)
	{
		if (pauseShift)
		{
			NetworkAggroManagerBase<ShiftManager>.instance.ServerPauseTimers(pauseDuration, setShiftPaused: false);
		}
	}
}
