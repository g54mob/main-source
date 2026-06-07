using System.Collections.Generic;
using UnityEngine;

public class Shockwave_upg_01_quakeParticles : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem quakePSPrefab;

	[SerializeField]
	private float timeBetweenQuakes = 0.1f;

	[SerializeField]
	private float firstQuakeDistance = 1.5f;

	[SerializeField]
	private float distanceBetweenQuakes = 0.75f;

	[SerializeField]
	private float particlesPerMeter = 8f;

	private StatsComponent statsComponent;

	private List<ParticleSystem> quakeParticles;

	private void Awake()
	{
		statsComponent = GetComponentInParent<StatsComponent>();
		quakeParticles = new List<ParticleSystem>();
	}

	private void Start()
	{
		statsComponent.onStatChanged += OnStatChanged;
		OnStatChanged(EStats.Range, statsComponent.GetStat(EStats.Range), 0f);
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.Range)
		{
			UpdateQuakeParticles(newValue);
		}
	}

	private void UpdateQuakeParticles(float range)
	{
		for (int num = quakeParticles.Count - 1; num >= 0; num--)
		{
			Object.Destroy(quakeParticles[num].gameObject);
			quakeParticles.RemoveAt(num);
		}
		int num2 = 1 + Mathf.FloorToInt((range - firstQuakeDistance) / distanceBetweenQuakes);
		for (int i = 0; i < num2; i++)
		{
			ParticleSystem particleSystem = Object.Instantiate(quakePSPrefab, base.transform.position, base.transform.rotation);
			particleSystem.transform.SetParent(base.transform, worldPositionStays: true);
			quakeParticles.Add(particleSystem);
			ParticleSystem.MainModule main = particleSystem.main;
			main.startDelay = (float)i * timeBetweenQuakes;
			ParticleSystem.ShapeModule shape = particleSystem.shape;
			shape.radius = firstQuakeDistance + (float)i * distanceBetweenQuakes;
			ParticleSystem.Burst burst = particleSystem.emission.GetBurst(0);
			burst.count = shape.radius * particlesPerMeter;
			particleSystem.emission.SetBurst(0, burst);
		}
	}
}
