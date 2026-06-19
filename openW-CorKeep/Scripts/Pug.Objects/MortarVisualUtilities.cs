using System.Collections.Generic;
using UnityEngine;

public static class MortarVisualUtilities
{
	public static void PlayAllEffects(List<ParticleSystem> effects)
	{
		foreach (ParticleSystem effect in effects)
		{
			effect.Play();
		}
	}

	public static void PlayAllEffects(List<ParticleEffectSpawner> effects)
	{
		foreach (ParticleEffectSpawner effect in effects)
		{
			effect.enabled = true;
		}
	}

	public static void StopAllEffects(List<ParticleSystem> effects)
	{
		foreach (ParticleSystem effect in effects)
		{
			effect.Stop();
		}
	}

	public static void StopAllEffects(List<ParticleEffectSpawner> effects)
	{
		foreach (ParticleEffectSpawner effect in effects)
		{
			effect.enabled = false;
		}
	}

	public static void PlayAllPuffs(List<PuffID> puffIds, Vector3 position)
	{
		foreach (PuffID puffId in puffIds)
		{
			Manager.effects.PlayPuff(puffId, position, 1);
		}
	}

	public static void EnableTransforms(List<Transform> transform, bool enable)
	{
		foreach (Transform item in transform)
		{
			item.gameObject.SetActive(enable);
		}
	}

	public static void EnableTransforms(List<BasicMortarProjectile.EnabledInAnimationTransform> enabledInAnimationTransforms, BasicMortarProjectile.MovementState movementStateMask)
	{
		foreach (BasicMortarProjectile.EnabledInAnimationTransform enabledInAnimationTransform in enabledInAnimationTransforms)
		{
			bool active = (enabledInAnimationTransform.enabledInState & movementStateMask) != 0;
			enabledInAnimationTransform.targetTransform.gameObject.SetActive(active);
		}
	}
}
