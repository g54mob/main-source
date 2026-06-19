using Aggro.Core;
using FMODUnity;
using UnityEngine;

public class LavaVisual : EntityBehaviourBase
{
	public ModifierLavaVisualManager modifierLavaVisualManager;

	public StudioEventEmitter lavaActiveLoopSFX;

	public StudioEventEmitter lavaBuildLoopSFX;

	public ParticleSystem lavaActiveParticle;

	protected override void OnEntityDestroyed()
	{
		lavaActiveLoopSFX.gameObject.SetActive(value: false);
	}

	protected override void OnUpdatePresentation()
	{
		ParticleSystem.EmissionModule emission = lavaActiveParticle.emission;
		switch (modifierLavaVisualManager.state)
		{
		case ModifierLava.State.Waiting:
			lavaActiveLoopSFX.gameObject.SetActive(value: false);
			lavaBuildLoopSFX.gameObject.SetActive(value: false);
			emission.enabled = false;
			break;
		case ModifierLava.State.Warning:
			lavaActiveLoopSFX.gameObject.SetActive(value: false);
			lavaBuildLoopSFX.gameObject.SetActive(value: true);
			lavaBuildLoopSFX.SetParameter("build", modifierLavaVisualManager.normalizedWarningTime);
			emission.enabled = false;
			break;
		case ModifierLava.State.Lava:
			lavaActiveLoopSFX.gameObject.SetActive(value: true);
			lavaBuildLoopSFX.gameObject.SetActive(value: false);
			emission.enabled = true;
			break;
		case ModifierLava.State.CoolingDown:
			lavaActiveLoopSFX.gameObject.SetActive(value: false);
			lavaBuildLoopSFX.gameObject.SetActive(value: false);
			emission.enabled = false;
			break;
		}
	}
}
