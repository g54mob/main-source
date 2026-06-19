using Aggro.Core;
using FMODUnity;
using UnityEngine;

public class BoxBlower : EntityBehaviourBase, IBoxUsable
{
	public ParticleSystem system;

	public StudioEventEmitter sfx;

	private bool _effectsOnPrevious;

	protected override void OnUpdatePresentation()
	{
		Grabbable grabbable = base.entity.GetObject<Grabbable>();
		ParticleSystem.EmissionModule emission = system.emission;
		PlayerBlower obj;
		bool flag = (emission.enabled = grabbable.syncHeldByPlayer.TryGetObject<PlayerBlower>(out obj) && obj.isCurrentlyBlowing);
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
