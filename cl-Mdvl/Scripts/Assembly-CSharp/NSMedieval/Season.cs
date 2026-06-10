using System;
using System.Collections.Generic;
using NSEipix.Model;
using NSMedieval.Serialization;
using NSMedieval.Weather;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	[FVSerializableKey("Season", "")]
	public class Season : IFVSerializable
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private FloatRange dayTemperatureRange;

		[SerializeField]
		private FloatRange nightTemperatureRange;

		[SerializeField]
		private List<WeatherEventSetting> weatherEvents;

		[SerializeField]
		private string unlockAchievementOnEnd;

		[SerializeField]
		private float caravanTravelDurationMultiplier;

		[SerializeField]
		private float sunriseHour;

		[SerializeField]
		private float sunsetHour;

		[SerializeField]
		private float sunAngle;

		[SerializeField]
		private int index;

		[SerializeField]
		private float soilTemperature;

		[SerializeField]
		private float waterTemperature;

		[SerializeField]
		private float moonAngle;

		[SerializeField]
		private float grassGrowSpeed;

		[SerializeField]
		private float grassFlammability;

		[SerializeField]
		private List<string> birds;

		public List<string> Birds => birds;

		public string Name => name;

		public FloatRange DayTemperatureRange => dayTemperatureRange;

		public FloatRange NightTemperatureRange => nightTemperatureRange;

		public List<WeatherEventSetting> WeatherEvents => weatherEvents;

		public string UnlockAchievementOnEnd => unlockAchievementOnEnd;

		public float SunriseHour => sunriseHour;

		public float SunsetHour => sunsetHour;

		public float SunAngle => sunAngle;

		public int Index => index;

		public float CaravanTravelDurationMultiplier
		{
			get
			{
				if (caravanTravelDurationMultiplier <= 0f)
				{
					caravanTravelDurationMultiplier = 1f;
				}
				return caravanTravelDurationMultiplier;
			}
		}

		public float SoilTemperature => soilTemperature;

		public float WaterTemperature => waterTemperature;

		public float MoonAngle => moonAngle;

		public float GrassGrowSpeed => grassGrowSpeed;

		public float GrassFlammability => grassFlammability;

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("name", name);
			serializer.Write("dayTemperatureRange", dayTemperatureRange);
			serializer.Write("nightTemperatureRange", nightTemperatureRange);
			serializer.Write("weatherEvents", weatherEvents);
			serializer.Write("unlockAchievementOnEnd", unlockAchievementOnEnd);
			serializer.Write("caravanTravelDurationMultiplier", caravanTravelDurationMultiplier);
			serializer.Write("sunriseHour", sunriseHour);
			serializer.Write("sunsetHour", sunsetHour);
			serializer.Write("sunAngle", sunAngle);
			serializer.Write("index", index);
			serializer.Write("soilTemperature", soilTemperature);
			serializer.Write("moonAngle", moonAngle);
			serializer.Write("grassGrowSpeed", grassGrowSpeed);
			serializer.Write("grassFlammability", grassFlammability);
		}

		public Season(FVDeserializer deserializer)
		{
			name = deserializer.ReadString("name");
			dayTemperatureRange = deserializer.ReadObject<FloatRange>("dayTemperatureRange");
			nightTemperatureRange = deserializer.ReadObject<FloatRange>("nightTemperatureRange");
			weatherEvents = deserializer.ReadObjectList<WeatherEventSetting>("weatherEvents");
			unlockAchievementOnEnd = deserializer.ReadString("unlockAchievementOnEnd");
			caravanTravelDurationMultiplier = deserializer.ReadFloat("caravanTravelDurationMultiplier");
			sunriseHour = deserializer.ReadFloat("sunriseHour");
			sunsetHour = deserializer.ReadFloat("sunsetHour");
			sunAngle = deserializer.ReadFloat("sunAngle");
			index = deserializer.ReadInt("index");
			soilTemperature = deserializer.ReadFloat("soilTemperature");
			moonAngle = deserializer.ReadFloat("moonAngle");
			grassGrowSpeed = deserializer.ReadFloat("grassGrowSpeed");
			grassFlammability = deserializer.ReadFloat("grassFlammability");
		}
	}
}
