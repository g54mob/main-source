using System;
using DistantLands.Cozy.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyClimateModule : CozyBiomeModuleBase<CozyClimateModule>
	{
		[CozySearchable(true, new string[] { "wet", "precipitation", "hot", "cold", "humidity", "temperature" })]
		public ClimateProfile climateProfile;

		public CozyWeather.ControlMethod controlMethod = CozyWeather.ControlMethod.profile;

		[CozySearchable(new string[] { })]
		[Tooltip("Adds an offset to the local temperature. Useful for adding biomes or climate change by location or elevation")]
		public float localTemperatureFilter;

		[CozySearchable(new string[] { })]
		[Tooltip("Adds an offset to the local precipitation. Useful for adding biomes or climate change by location or elevation")]
		public float localPrecipitationFilter;

		internal float temperatureOffset;

		internal float precipitationOffset;

		[CozySearchable(new string[] { })]
		public float currentTemperature;

		[CozySearchable(new string[] { })]
		public float currentPrecipitation;

		[Range(0f, 1f)]
		[CozySearchable(new string[] { })]
		public float snowAmount;

		[FormerlySerializedAs("m_SnowMeltSpeed")]
		[CozySearchable(new string[] { })]
		public float snowMeltSpeed = 0.35f;

		[Range(0f, 1f)]
		[CozySearchable(new string[] { })]
		[FormerlySerializedAs("wetness")]
		public float groundwaterAmount;

		[CozySearchable(new string[] { })]
		[FormerlySerializedAs("m_DryingSpeed")]
		public float dryingSpeed = 0.5f;

		public float snowSpeed;

		public float rainSpeed;

		public override void InitializeModule()
		{
			base.isBiomeModule = GetComponent<CozyBiome>();
			base.InitializeModule();
			if (!base.isBiomeModule)
			{
				base.weatherSphere.climateModule = this;
				AddBiome();
			}
		}

		public override void CozyUpdateLoop()
		{
			ComputeBiomeWeights();
			snowAmount += Time.deltaTime * snowSpeed;
			if (snowSpeed <= 0f && currentTemperature > 32f)
			{
				snowAmount -= Time.deltaTime * snowMeltSpeed * 0.03f;
			}
			groundwaterAmount += Time.deltaTime * rainSpeed + -1f * dryingSpeed * 0.001f;
			snowAmount = Mathf.Clamp01(snowAmount);
			groundwaterAmount = Mathf.Clamp01(groundwaterAmount);
			if (controlMethod == CozyWeather.ControlMethod.profile)
			{
				if (!climateProfile)
				{
					return;
				}
				currentTemperature = climateProfile.GetTemperature(base.weatherSphere) + localTemperatureFilter + temperatureOffset;
				currentPrecipitation = Mathf.Clamp(climateProfile.GetHumidity(base.weatherSphere) + localPrecipitationFilter + precipitationOffset, 0f, 100f);
			}
			foreach (CozyClimateModule biome in biomes)
			{
				currentTemperature = Mathf.Lerp(currentTemperature, biome.currentTemperature, biome.weight);
				currentPrecipitation = Mathf.Lerp(currentPrecipitation, biome.currentPrecipitation, biome.weight);
			}
			Shader.SetGlobalFloat("CZY_SnowAmount", snowAmount);
			Shader.SetGlobalFloat("CZY_WetnessAmount", groundwaterAmount);
		}

		public override void FrameReset()
		{
			temperatureOffset = 0f;
			precipitationOffset = 0f;
			snowSpeed = 0f;
			rainSpeed = 0f;
		}

		public float GetTemperature()
		{
			if (controlMethod == CozyWeather.ControlMethod.native)
			{
				return currentTemperature;
			}
			return climateProfile.GetTemperature(base.weatherSphere) + localTemperatureFilter;
		}

		public float GetTemperature(float time)
		{
			return climateProfile.GetTemperature(base.weatherSphere, time) + localTemperatureFilter;
		}

		[Obsolete("Please use GetHumidity instead.")]
		public float GetPrecipitation()
		{
			return climateProfile.GetHumidity(base.weatherSphere) + localPrecipitationFilter;
		}

		public float GetHumidity()
		{
			return climateProfile.GetHumidity(base.weatherSphere) + localPrecipitationFilter;
		}

		[Obsolete("Please use GetHumidity instead.")]
		public float GetPrecipitation(float time)
		{
			return climateProfile.GetHumidity(base.weatherSphere, time) + localPrecipitationFilter;
		}

		public float GetHumidity(float time)
		{
			return climateProfile.GetHumidity(base.weatherSphere, time) + localPrecipitationFilter;
		}

		public override void DeinitializeModule()
		{
			base.DeinitializeModule();
			Shader.SetGlobalFloat("CZY_WindTime", 0f);
			Shader.SetGlobalVector("CZY_WindDirection", Vector3.zero);
		}

		public override void UpdateBiomeModule()
		{
			if (controlMethod == CozyWeather.ControlMethod.profile && (bool)climateProfile)
			{
				currentTemperature = climateProfile.GetTemperature(base.weatherSphere) + localTemperatureFilter + temperatureOffset;
				currentPrecipitation = Mathf.Clamp(climateProfile.GetHumidity(base.weatherSphere) + localPrecipitationFilter + precipitationOffset, 0f, 100f);
			}
		}
	}
}
