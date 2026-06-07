using UnityEngine;

namespace Assets.Scripts.Flight.Simulation
{
	public class Atmosphere
	{
		private const float AdiabaticIndex = 1.4f;

		private const float AtmosphereHeight = 30000f;

		private const float GasConstant = 287.05f;

		private const float ScaleHeight = 7640f;

		private const float SurfaceAirDensity = 1.225f;

		private const float SurfacePressurePascals = 100000f;

		private const float SurfaceTemperature = 290f;

		private const float TemperatureLapseRate = 0.0065f;

		private const float TropopauseAltitude = 11000f;

		public static AtmosphereSample SampleAltitude(float altitude)
		{
			altitude = Mathf.Max(altitude, 0f);
			AtmosphereSample result = new AtmosphereSample
			{
				SampleAltitude = altitude,
				SurfaceAirDensity = 1.225000023841858,
				Temperature = CalculateTemperatureISA(altitude, 290f)
			};
			Mathf.Clamp01(altitude / 30000f);
			if (altitude < 30000f)
			{
				float num = Mathf.Pow(2.71828f, (0f - altitude) / 7640f);
				result.AirDensity = 1.225f * num;
				result.AirPressure = 100000f * num;
			}
			else
			{
				result.AirDensity = 0f;
				result.AirPressure = 0f;
			}
			result.SpeedOfSound = CalculateSpeedOfSound(result.Temperature);
			result.AirDensityRatio = result.AirPressure / 100000f;
			return result;
		}

		private static float CalculateAirDensityRatio(float altitude)
		{
			return CalculateAtmosphericPressure(altitude) / 100000f;
		}

		private static float CalculateAtmosphericPressure(float altitude)
		{
			float num = 100000f * Mathf.Pow(2.71828f, (0f - altitude) / 7640f);
			if (num < 0.1f)
			{
				num = 0f;
			}
			return num;
		}

		private static float CalculateSpeedOfSound(float temperatureKelvin)
		{
			return Mathf.Sqrt(401.86996f * temperatureKelvin);
		}

		private static float CalculateTemperatureISA(float altitude, float surfaceTempKelvin)
		{
			if (altitude <= 11000f)
			{
				return surfaceTempKelvin - 0.0065f * altitude;
			}
			return surfaceTempKelvin - 71.5f;
		}

		private static float GetAirDensity(float elevationAboveSeaLevel)
		{
			float num = CalculateAirDensityRatio(elevationAboveSeaLevel);
			if (num < 0f)
			{
				num = 0f;
			}
			return num;
		}
	}
}
