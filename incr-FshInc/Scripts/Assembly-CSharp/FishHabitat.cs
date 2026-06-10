using System;
using System.Collections.Generic;
using UnityEngine;

public class FishHabitat : MonoBehaviour
{
	public enum BoostStrength
	{
		VeryStrong = 0,
		Strong = 1,
		Moderate = 2,
		Weak = 3,
		VeryWeak = 4
	}

	public enum FalloffType
	{
		VeryStrong = 0,
		Strong = 1,
		Linear = 2,
		Weak = 3,
		VeryWeak = 4
	}

	[Serializable]
	public struct FishBoost
	{
		public Fish fishSpecies;

		[Tooltip("How strong is the boost for this fish species?")]
		public BoostStrength boostStrength;
	}

	[Header("Habitat Settings")]
	[Tooltip("How far this habitat's influence extends.")]
	public float radius = 5f;

	[Tooltip("Controls how the boost fades over distance.")]
	public FalloffType falloff = FalloffType.Linear;

	[Header("Boost Data")]
	public List<FishBoost> fishBoosts;

	public float GetBoostFloat(BoostStrength strength)
	{
		return strength switch
		{
			BoostStrength.VeryStrong => 3f, 
			BoostStrength.Strong => 1.75f, 
			BoostStrength.Moderate => 0.85f, 
			BoostStrength.Weak => 0.4f, 
			BoostStrength.VeryWeak => 0.2f, 
			_ => 1f, 
		};
	}

	public float GetFalloffFloat(FalloffType type)
	{
		return type switch
		{
			FalloffType.VeryStrong => 0.2f, 
			FalloffType.Strong => 0.5f, 
			FalloffType.Linear => 1f, 
			FalloffType.Weak => 2f, 
			FalloffType.VeryWeak => 4f, 
			_ => 1f, 
		};
	}

	private void OnEnable()
	{
		FishingManager.RegisterHabitat(this);
	}

	private void OnDisable()
	{
		FishingManager.UnregisterHabitat(this);
	}

	public float GetBoostPercentage(Fish species, Vector3 castPosition)
	{
		float num = Vector3.Distance(base.transform.position, castPosition);
		if (num > radius)
		{
			return 0f;
		}
		float num2 = 0f;
		bool flag = false;
		foreach (FishBoost fishBoost in fishBoosts)
		{
			if (fishBoost.fishSpecies == species)
			{
				num2 = GetBoostFloat(fishBoost.boostStrength);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return 0f;
		}
		float num3 = Mathf.Clamp01(num / radius);
		float f = 1f - num3;
		float falloffFloat = GetFalloffFloat(falloff);
		f = Mathf.Pow(f, falloffFloat);
		return num2 * f;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(0f, 0.7f, 1f, 0.2f);
		Gizmos.DrawWireSphere(base.transform.position, radius);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0f, 0.5f, 1f, 0.15f);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(base.transform.position, radius);
		float falloffFloat = GetFalloffFloat(falloff);
		if (falloffFloat > 0f)
		{
			float num = radius * (1f - Mathf.Pow(0.5f, 1f / falloffFloat));
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(base.transform.position, num);
		}
	}
}
