using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Weather
{
	[Serializable]
	public class WeatherEvent : NSEipix.Base.Model
	{
		[Serializable]
		public enum Type
		{
			Uninitialized = 0,
			None = 1,
			Rain = 2,
			Snow = 3,
			Fog = 4,
			Cloud = 5
		}

		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private string animationName = string.Empty;

		[SerializeField]
		private string textKey = string.Empty;

		[SerializeField]
		private List<string> skipIfExists;

		[SerializeField]
		private float fadeInHours = -1f;

		[SerializeField]
		private float fadeOutHours = -1f;

		[SerializeField]
		private FloatRange temperature;

		[SerializeField]
		private float temperatureAdd;

		[SerializeField]
		private List<string> effectors = new List<string>();

		[SerializeField]
		private List<string> enableKeywordOnStart = new List<string>();

		[SerializeField]
		private int minDurationMinutes = 30;

		[SerializeField]
		private int skipFirstHours = 72;

		[SerializeField]
		private List<string> ignoredWhenGameEventsRunning;

		[SerializeField]
		private string eventType;

		[NonSerialized]
		private Type eventTypeCache;

		public string AnimationName => animationName;

		public string TextKey => textKey;

		public List<string> SkipIfExists => skipIfExists;

		public float FadeInHours => fadeInHours;

		public float FadeOutHours => fadeOutHours;

		public FloatRange Temperature => temperature;

		public float TemperatureAdd => temperatureAdd;

		public List<string> Effectors => effectors;

		public List<string> EnableKeywordOnStart => enableKeywordOnStart;

		public Type EventType
		{
			get
			{
				if (eventTypeCache == Type.Uninitialized && !Enum.TryParse<Type>(eventType, ignoreCase: true, out eventTypeCache))
				{
					eventTypeCache = Type.None;
				}
				return eventTypeCache;
			}
		}

		public List<string> IgnoredWhenGameEventsRunning => ignoredWhenGameEventsRunning;

		public int SkipFirstHours => skipFirstHours;

		public int MinDurationMinutes => minDurationMinutes;

		public bool ShouldSkipIfExists(WeatherEvent otherEvent)
		{
			if (!skipIfExists.Contains(otherEvent.GetID()))
			{
				return otherEvent.skipIfExists.Contains(id);
			}
			return true;
		}

		public override string GetID()
		{
			return id;
		}
	}
}
