using UnityEngine;

public class Shockwave_upg_02_quakeParticles : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem[] fireParticles;

	private StatsComponent statsComponent;

	private void Awake()
	{
		statsComponent = GetComponentInParent<StatsComponent>();
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
			UpdateFireParticles(newValue);
		}
	}

	private void UpdateFireParticles(float range)
	{
		ParticleSystem[] array = fireParticles;
		foreach (ParticleSystem obj in array)
		{
			ParticleSystem.MainModule main = obj.main;
			float zMultiplier = obj.velocityOverLifetime.zMultiplier;
			float num = range / zMultiplier;
			main.startLifetime = new ParticleSystem.MinMaxCurve(num * 0.8f, num);
		}
	}
}
