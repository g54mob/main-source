using Aggro.Core;
using FMODUnity;
using UnityEngine;

public class BoxVacuum : EntityBehaviourBase, IBoxUsable
{
	public ParticleSystem system;

	public StudioEventEmitter sfx;

	private bool _effectsOnPrevious;

	protected override void OnUpdatePresentation()
	{
		Grabbable grabbable = base.entity.GetObject<Grabbable>();
		ParticleSystem.EmissionModule emission = system.emission;
		PlayerVacuum obj;
		bool flag = (emission.enabled = grabbable.syncHeldByPlayer.TryGetObject<PlayerVacuum>(out obj) && obj.isCurrentlyVacuuming);
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
}
