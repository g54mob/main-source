using Aggro.Core;
using UnityEngine;

public class PlayerEffectsVisual : EntityBehaviourBase
{
	public PlayerEffects playerEffects;

	public ParticleSystem fire;

	public ParticleSystem ooze;

	public ParticleSystem lockedIn;

	public ParticleSystem battery;

	public GameObject[] ghostDisableObjects;

	protected override void OnUpdatePresentation()
	{
		GameObject[] array = ghostDisableObjects;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(!playerEffects.syncInvisible);
		}
		ParticleSystem.EmissionModule emission = fire.emission;
		ParticleSystem.EmissionModule emission2 = ooze.emission;
		ParticleSystem.EmissionModule emission3 = lockedIn.emission;
		ParticleSystem.EmissionModule emission4 = battery.emission;
		emission.enabled = playerEffects.context.HasFlag(PlayerEffectContext.Fire);
		emission2.enabled = playerEffects.context.HasFlag(PlayerEffectContext.Ooze);
		emission3.enabled = playerEffects.context.HasFlag(PlayerEffectContext.Shield);
		emission4.enabled = playerEffects.context.HasFlag(PlayerEffectContext.Battery);
	}
}
