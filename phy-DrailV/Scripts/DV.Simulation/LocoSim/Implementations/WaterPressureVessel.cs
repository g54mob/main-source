using UnityEngine;

namespace LocoSim.Implementations
{
	public class WaterPressureVessel
	{
		private const int ITERATION_LIMIT = 10;

		private const float SLOPE_EPSILON = 0.1f;

		private const float THRESHOLD = 0.001f;

		private readonly float volume;

		public float enthalpy;

		public float mass;

		public float pressure;

		private float steamMassFraction;

		public float waterTemp;

		public float waterVolume;

		public WaterPressureVessel(float volume, float pressure, float mass)
		{
			this.volume = volume;
			this.pressure = pressure;
			this.mass = mass;
			steamMassFraction = SteamMassFraction(pressure, volume / mass);
			float num = SpecificEnthalpy(pressure, steamMassFraction);
			enthalpy = num * mass;
			Update();
		}

		public static WaterPressureVessel FromSaveData(float volume, float pressure, float waterLevelNormalized)
		{
			float num = waterLevelNormalized * volume;
			if (num < 1f)
			{
				return new WaterPressureVessel(volume, 1f, 0f);
			}
			float num2 = volume - num;
			float num3 = num / SteamTables.WaterSpecificVolume(pressure);
			float num4 = num2 / SteamTables.SteamSpecificVolume(pressure);
			float num5 = num3 + num4;
			return new WaterPressureVessel(volume, pressure, num5);
		}

		private static float SteamMassFraction(float pressure, float specificVolume)
		{
			float num = SteamTables.SteamSpecificVolume(pressure);
			float num2 = SteamTables.WaterSpecificVolume(pressure);
			return (specificVolume - num2) / (num - num2);
		}

		private static float SpecificEnthalpy(float pressure, float steamMassFraction)
		{
			float num = SteamTables.SteamSpecificEnthalpy(pressure);
			float num2 = SteamTables.WaterSpecificEnthalpy(pressure);
			return steamMassFraction * num + (1f - steamMassFraction) * num2;
		}

		private bool NewtonStep(float targetSpecificVolume, float targetSpecificEnthalpy)
		{
			float num = SteamMassFraction(pressure, targetSpecificVolume);
			float num2 = SpecificEnthalpy(pressure, num);
			float num3 = targetSpecificEnthalpy - num2;
			if (Mathf.Abs(num3) < 0.001f)
			{
				return true;
			}
			float num4 = SteamMassFraction(pressure + 0.1f, targetSpecificVolume);
			float num5 = (SpecificEnthalpy(pressure + 0.1f, num4) - num2) / 0.1f;
			float num6 = num3 / num5;
			pressure = Mathf.Max(1f, pressure + num6);
			steamMassFraction = num;
			return false;
		}

		public void AddEnergy(float joules)
		{
			enthalpy += joules / 1000f;
		}

		public void RemoveSteam(float massToRemove)
		{
			enthalpy -= SteamTables.SteamSpecificEnthalpy(pressure) * massToRemove;
			mass -= massToRemove;
		}

		public void AddWater(float massToAdd, float waterTemp)
		{
			enthalpy += SteamTables.WaterSpecificEnthalpyByTemp(waterTemp) * massToAdd;
			mass += massToAdd;
		}

		public void RemoveWater(float massToRemove)
		{
			enthalpy -= SteamTables.WaterSpecificEnthalpyByTemp(waterTemp) * massToRemove;
			mass -= massToRemove;
		}

		public void Update()
		{
			if (mass <= 0f)
			{
				enthalpy = 0f;
				mass = 0f;
				pressure = 1f;
				steamMassFraction = 0f;
				waterTemp = 25f;
				waterVolume = 0f;
				return;
			}
			float targetSpecificVolume = volume / mass;
			float num = enthalpy / mass;
			for (int i = 0; i < 10; i++)
			{
				if (NewtonStep(targetSpecificVolume, num))
				{
					break;
				}
			}
			float num2 = mass * (1f - steamMassFraction);
			waterTemp = SteamTables.WaterTempBySpecificEnthalpy(num);
			waterVolume = num2 * SteamTables.WaterSpecificVolume(pressure);
		}
	}
}
