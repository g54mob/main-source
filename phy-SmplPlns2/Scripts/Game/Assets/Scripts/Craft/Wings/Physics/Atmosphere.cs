using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public static class Atmosphere
	{
		public enum Layer
		{
			Underwater = 0,
			Troposphere = 1,
			Stratosphere = 2,
			Mesosphere = 3,
			Thermosphere = 4
		}

		public struct Properties
		{
			public float density;

			public float dynamicViscosity;

			public float inverseKinematicViscosity;

			public Layer layer;

			public float pressure;

			public float speedOfSound;

			public float temperature;

			public readonly float Re(float speed, float length)
			{
				return speed * length * inverseKinematicViscosity;
			}

			public override readonly string ToString()
			{
				return $"{pressure} Pa, {temperature} K, {density} kg/m^3\nmach = {speedOfSound}, dv = {dynamicViscosity}, ikv = {inverseKinematicViscosity}";
			}
		}

		public static Properties ISA(float altitude)
		{
			Properties result = default(Properties);
			float num = 6371009f * altitude / (6371009f + altitude);
			float num2;
			float num4;
			float num5;
			float num6;
			float num3;
			if (num < 11000f)
			{
				result.layer = Layer.Troposphere;
				num2 = -610f;
				num3 = 6.5f;
				num4 = 292.15f;
				num5 = 108900f;
				num6 = 1.2985f;
			}
			else if (num < 20000f)
			{
				result.layer = Layer.Stratosphere;
				num2 = 11000f;
				num3 = 0f;
				num4 = 216.65f;
				num5 = 22632f;
				num6 = 0.3639f;
			}
			else if (num < 32000f)
			{
				result.layer = Layer.Stratosphere;
				num2 = 20000f;
				num3 = -1f;
				num4 = 216.65f;
				num5 = 5474.9f;
				num6 = 0.088f;
			}
			else if (num < 47000f)
			{
				result.layer = Layer.Stratosphere;
				num2 = 32000f;
				num3 = -2.8f;
				num4 = 228.65f;
				num5 = 868.02f;
				num6 = 0.0132f;
			}
			else if (num < 51000f)
			{
				result.layer = Layer.Mesosphere;
				num2 = 47000f;
				num3 = 0f;
				num4 = 270.65f;
				num5 = 110.91f;
				num6 = 0.002f;
			}
			else if (num < 71000f)
			{
				result.layer = Layer.Mesosphere;
				num2 = 51000f;
				num3 = 2.8f;
				num4 = 270.65f;
				num5 = 66.939f;
				num6 = 0f;
			}
			else
			{
				if (!(num < 84852f))
				{
					return new Properties
					{
						layer = Layer.Thermosphere,
						density = 0f,
						pressure = 0f,
						speedOfSound = 0f,
						temperature = 0f,
						dynamicViscosity = 0f,
						inverseKinematicViscosity = float.PositiveInfinity
					};
				}
				result.layer = Layer.Mesosphere;
				num2 = 71000f;
				num3 = 2f;
				num4 = 214.65f;
				num5 = 3.9564f;
				num6 = 0f;
			}
			num3 *= 0.001f;
			result.temperature = num4 - num3 * (num - num2);
			if (num3 == 0f)
			{
				float num7 = math.exp(-0.28404373f * (num - num2) / (8.31446f * num4));
				result.pressure = num5 * num7;
				result.density = num6 * num7;
			}
			else
			{
				float x = (num4 - (num - num2) * num3) / num4;
				float num8 = 0.28404373f / (8.31446f * num3);
				result.pressure = num5 * math.pow(x, num8);
				result.density = num6 * math.pow(x, num8 - 1f);
			}
			float num9 = result.temperature / 291.15f;
			num9 *= math.sqrt(num9);
			result.dynamicViscosity = 1.827E-05f * num9 * 401.55f / (110.4f + result.temperature);
			result.inverseKinematicViscosity = result.density / result.dynamicViscosity;
			result.speedOfSound = math.sqrt(result.pressure * 1.4f / result.density);
			return result;
		}
	}
}
