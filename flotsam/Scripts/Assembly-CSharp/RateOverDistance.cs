using PajamaLlama.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class RateOverDistance : MonoBehaviour
{
	[SerializeField]
	[MinMaxRangeFloat(0f, 100f)]
	private RangedFloat _rateOverTime;

	private ParticleSystem _particleSystem;

	private ParticleSystem.EmissionModule _emissionModule;

	private ParticleSystem.MinMaxCurve _particleSystemParameters;

	private void Awake()
	{
		_particleSystem = GetComponent<ParticleSystem>();
		_emissionModule = _particleSystem.emission;
	}

	public void SetParticleSpeed(float speedModifier)
	{
		if ((bool)_particleSystem)
		{
			_particleSystemParameters.constantMin = _rateOverTime.Minimum * speedModifier;
			_particleSystemParameters.constantMax = _rateOverTime.Maximum * speedModifier;
			_emissionModule.rateOverDistance = _particleSystemParameters;
		}
	}
}
