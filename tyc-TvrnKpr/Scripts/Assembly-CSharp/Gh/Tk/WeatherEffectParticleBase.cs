using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public abstract class WeatherEffectParticleBase : WeatherEffectBase, ICustomSaveState
	{
		public ParticleSystem[] particles;

		public float lerpTimeMultiplier;

		public AnimationCurve lerpCurve;

		[PersistenceOptIn]
		private float lerpTime;

		private float lerpTimeCurveAdjusted;

		[PersistenceOptIn]
		private bool _isRunning;

		private readonly List<float> particleRates;

		private void Start()
		{
		}

		private void UpdateLerpTime()
		{
		}

		private void Update()
		{
		}

		private void TurnOn()
		{
		}

		public override void ResetState()
		{
		}

		private void TurnOff(bool immediate)
		{
		}

		public void SaveState(IDataStore data)
		{
		}

		public void RestoreState(IDataStore data)
		{
		}
	}
}
