using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;

public class WarehouseSprinklerRainEffect : EntityBehaviourBase
{
	private ParticleSystem.EmissionModule _emission;

	protected override void OnEntityCreated()
	{
		ParticleSystem component = GetComponent<ParticleSystem>();
		_emission = component.emission;
	}

	protected override void OnUpdatePresentation()
	{
		bool flag = NetworkAggroManagerBase<SprinklerManager>.instance.state != SprinklerManager.State.Inert;
		_emission.enabled = flag;
	}
}
