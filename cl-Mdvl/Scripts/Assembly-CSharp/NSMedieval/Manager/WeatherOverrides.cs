using System;
using FoxyVoxel.Logging;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.Manager
{
	[Serializable]
	[FVSerializableKey("WeatherOverrides", "")]
	public class WeatherOverrides : IFVSerializable
	{
		[SerializeField]
		private bool isActive;

		[SerializeField]
		private float temperature;

		[SerializeField]
		private float sunStrengthMultiplier = 1f;

		[SerializeField]
		private float rainEffectWeight;

		private const string fvs_isActive = "isActive";

		private const string fvs_temperature = "temperature";

		private const string fvs_sunStrengthMultiplier = "sunStrengthMultiplier";

		private const string fvs_rainEffectWeight = "rainEffectWeight";

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			set
			{
				if (value)
				{
					Log.Debug("Activating override", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WeatherManager.cs");
				}
				else
				{
					Log.Debug("Deactivating override", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WeatherManager.cs");
				}
				isActive = value;
			}
		}

		public WeatherOverrides()
		{
		}

		public void SetTemperature(float value)
		{
			temperature = value;
		}

		public void SetSunStrengthMultiplier(float value)
		{
			sunStrengthMultiplier = value;
		}

		public void SetRainEffectWeight(float value)
		{
			rainEffectWeight = value;
		}

		public float GetTemperature(float baseValue)
		{
			if (isActive)
			{
				return temperature;
			}
			return baseValue;
		}

		public float GetSunStrengthMultiplier()
		{
			if (isActive)
			{
				return sunStrengthMultiplier;
			}
			return 1f;
		}

		public float GetRainEffectWeight(float baseWeight)
		{
			if (isActive)
			{
				return rainEffectWeight;
			}
			return baseWeight;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("isActive", isActive);
			serializer.Write("temperature", temperature);
			serializer.Write("sunStrengthMultiplier", sunStrengthMultiplier);
			serializer.Write("rainEffectWeight", rainEffectWeight);
		}

		public WeatherOverrides(FVDeserializer deserializer)
		{
			isActive = deserializer.ReadBool("isActive");
			temperature = deserializer.ReadFloat("temperature");
			sunStrengthMultiplier = deserializer.ReadFloat("sunStrengthMultiplier");
			rainEffectWeight = deserializer.ReadFloat("rainEffectWeight");
		}
	}
}
