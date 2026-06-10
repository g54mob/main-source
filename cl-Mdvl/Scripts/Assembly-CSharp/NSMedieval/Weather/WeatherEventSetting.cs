using System;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Weather
{
	[Serializable]
	[FVSerializableKey("WeatherEventSetting", "")]
	public struct WeatherEventSetting : IFVSerializable
	{
		[SerializeField]
		private string weatherEvent;

		[SerializeField]
		private float chance;

		public string WeatherEvent => weatherEvent;

		public float Chance => chance;

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("weatherEvent", weatherEvent);
			serializer.Write("chance", chance);
		}

		public WeatherEventSetting(FVDeserializer deserializer)
		{
			weatherEvent = deserializer.ReadString("weatherEvent");
			chance = deserializer.ReadFloat("chance");
		}
	}
}
