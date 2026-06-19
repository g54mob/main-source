using Aggro.Core;
using UnityEngine;

public class PlayerLiquidTrailEffectsVisual : EntityBehaviourBase
{
	public ParticleSystem[] trailParticles;

	public PlayerEffects playerEffects;

	public float trailAmount;

	public float trailDecaySpeed = 1f;

	private Color color = Color.black;

	protected override void OnUpdatePresentation()
	{
		AoEEffects.LiquidTrailEffect activeLiquidTrailEffect = playerEffects.activeLiquidTrailEffect;
		trailAmount -= trailDecaySpeed * Time.deltaTime;
		trailAmount = Mathf.Clamp(trailAmount, 0f, 1f);
		switch (activeLiquidTrailEffect)
		{
		case AoEEffects.LiquidTrailEffect.Oil:
			color = Color.green;
			trailAmount = 1f;
			break;
		case AoEEffects.LiquidTrailEffect.Water:
			color = Color.red;
			trailAmount = 1f;
			break;
		case AoEEffects.LiquidTrailEffect.Ooze:
			color = Color.blue;
			trailAmount = 1f;
			break;
		}
		ParticleSystem[] array = trailParticles;
		foreach (ParticleSystem obj in array)
		{
			ParticleSystem.MainModule main = obj.main;
			ParticleSystem.EmissionModule emission = obj.emission;
			main.startColor = color;
			emission.enabled = trailAmount > 0f;
		}
	}
}
