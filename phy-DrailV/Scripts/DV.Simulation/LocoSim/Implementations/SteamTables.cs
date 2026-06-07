using UnityEngine;

namespace LocoSim.Implementations
{
	public static class SteamTables
	{
		public static float SteamSpecificEnthalpy(float p)
		{
			return 2658f + p * (26.9f + p * (-2.16f + p * (0.0792f + p * -0.00106f)));
		}

		public static float SteamSpecificVolume(float p)
		{
			return 1720f * Mathf.Pow(p, -0.951f);
		}

		public static float SteamSpecificVolumeToPressure(float v)
		{
			return Mathf.Pow(v / 1720f, -1.0515248f);
		}

		public static float WaterSpecificEnthalpy(float p)
		{
			return 422f * Mathf.Pow(p, 0.256f);
		}

		public static float WaterSpecificEnthalpyByTemp(float temp)
		{
			return 4.39f * temp - 24f;
		}

		public static float WaterTempBySpecificEnthalpy(float h)
		{
			return (h + 24f) / 4.39f;
		}

		public static float WaterSpecificVolume(float p)
		{
			return 1.04f + p * (0.00943f + p * -0.000129f);
		}
	}
}
