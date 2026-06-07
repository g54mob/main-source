using System;
using AK.Wwise;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceOptIn]
	[PersistenceIgnoreParent]
	public abstract class WeatherEffectBase : MonoBehaviour, IPersistable, ILevelStaticObject
	{
		[Serializable]
		public class AtmosphereEquilibriumChanges
		{
			public string effectType;

			public sbyte value;
		}

		[Header("level-unique id for persistence")]
		public string id;

		[Header("base effect configuration")]
		public string weatherType;

		public Bank soundBank;

		[Header("randomTriggerConfig")]
		public bool allowTriggeringRandomly;

		[Range(0f, 1f)]
		public float chancePerDay;

		[Range(0f, 23f)]
		[Tooltip("the minimum day.hour this effect can start")]
		public int minStartHour;

		[Range(0f, 23f)]
		[Tooltip("the maximum day.hour this effect can start")]
		public int maxStartHour;

		[Header("intensityConfig")]
		[Range(0f, 1f)]
		public float minIntensity;

		[Range(0f, 1f)]
		public float maxIntensity;

		public float minDurationInHours;

		public float maxDurationInHours;

		public AtmosphereEquilibriumChanges[] atmosphereEffects;

		[Header("other (runtime/effect specific config)")]
		[PersistenceOptIn]
		public float intensity;

		[PersistenceOptIn]
		public string Id
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public double GetChancePerSecond()
		{
			return 0.0;
		}

		public bool IsEffectAllowed(int targetHour)
		{
			return false;
		}

		public virtual float GetTargetDurationInGameHours()
		{
			return 0f;
		}

		public virtual void StartEffect(float intensity)
		{
		}

		public virtual void UpdateEffect(float progress)
		{
		}

		public virtual void StopEffect()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		public virtual string GetAlertType()
		{
			return null;
		}

		public virtual void ResetState()
		{
		}
	}
}
