using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;

public class LockedInVisual : EntityBehaviourBase
{
	private static readonly int LockedIn = Shader.PropertyToID("_lockedIn");

	protected override void OnUpdatePresentation()
	{
		if (GameUtil.isRun)
		{
			Shader.SetGlobalFloat(LockedIn, NetworkAggroManagerBase<ShiftManager>.instance.playersLockedIn ? 1f : 0f);
		}
		else
		{
			Shader.SetGlobalFloat(LockedIn, 0f);
		}
	}

	protected override void OnEntityDestroyed()
	{
		Shader.SetGlobalFloat(LockedIn, 0f);
	}
}
