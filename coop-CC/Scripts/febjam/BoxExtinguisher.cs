using Aggro.Core.Networking;
using FMODUnity;
using UnityEngine;

public class BoxExtinguisher : NetworkEntityBehaviourBase, IBoxUsable
{
	public ParticleSystem system;

	public StudioEventEmitter sfx;

	private bool _effectsOnPrevious;

	protected override void OnUpdatePresentation()
	{
		Grabbable grabbable = base.entity.GetObject<Grabbable>();
		ParticleSystem.EmissionModule emission = system.emission;
		PlayerExtinguisher obj;
		bool flag = (emission.enabled = grabbable.syncHeldByPlayer.TryGetObject<PlayerExtinguisher>(out obj) && obj.isCurrentlyExtinguishing);
		if (flag && !_effectsOnPrevious)
		{
			sfx.Play();
		}
		if (!flag && _effectsOnPrevious)
		{
			sfx.Stop();
		}
		_effectsOnPrevious = flag;
	}

	public override bool Weaved()
	{
		return true;
	}
}
