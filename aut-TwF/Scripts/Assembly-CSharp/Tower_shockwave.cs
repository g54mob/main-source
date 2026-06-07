using System;
using UnityEngine;

public class Tower_shockwave : MonoBehaviour
{
	[SerializeField]
	private GameObject particlesCotainer;

	[SerializeField]
	private ParticleSystem smokeParticles;

	[SerializeField]
	private float smokeParticlesPerM2 = 0.4f;

	[SerializeField]
	private DecalAnimation decalAnimation;

	private void Start()
	{
		StatsComponent component = GetComponent<StatsComponent>();
		component.onStatChanged += OnStatChanged;
		OnStatChanged(EStats.Range, component.GetStat(EStats.Range), 0f);
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.Range)
		{
			particlesCotainer.transform.localScale = Vector3.one * (newValue - 0.5f);
			ParticleSystem.EmissionModule emission = smokeParticles.emission;
			ParticleSystem.Burst burst = emission.GetBurst(0);
			burst.count = (int)(MathF.PI * Mathf.Pow(newValue - 0.5f, 2f) * smokeParticlesPerM2);
			emission.SetBurst(0, burst);
		}
	}

	public void PlayDecalAnimation()
	{
		decalAnimation.PlayDecalAnimation();
	}
}
