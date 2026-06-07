using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceOptIn]
	[PersistenceIgnoreParent]
	public class WeatherController : MonoBehaviour, IPersistable
	{
		[PersistenceOptIn]
		private float _targetDuration;

		[PersistenceOptIn]
		private float _durationElapsed;

		[PersistenceOptIn]
		private bool _effectActive;

		[PersistenceOptIn]
		private IRng _rng;

		private WeatherEffectBase[] _weatherEffects;

		public WeatherEffectBase ActiveEffect => null;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void ActivateWeatherEffect(WeatherEffectBase effect, float? intensityOverride = null, float? durationInHoursOverride = null)
		{
		}

		private void StopWeatherEffect()
		{
		}

		public IEnumerable<WeatherEffectBase> GetWeatherEffects()
		{
			return null;
		}

		public void Reset()
		{
		}
	}
}
