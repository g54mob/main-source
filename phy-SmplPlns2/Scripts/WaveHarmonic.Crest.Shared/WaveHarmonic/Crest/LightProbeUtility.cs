using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal static class LightProbeUtility
	{
		private static readonly int[] s_SHA = new int[3]
		{
			Shader.PropertyToID("unity_SHAr"),
			Shader.PropertyToID("unity_SHAg"),
			Shader.PropertyToID("unity_SHAb")
		};

		private static readonly int[] s_SHB = new int[3]
		{
			Shader.PropertyToID("unity_SHBr"),
			Shader.PropertyToID("unity_SHBg"),
			Shader.PropertyToID("unity_SHBb")
		};

		private static readonly int s_SHC = Shader.PropertyToID("unity_SHC");

		public static void SetSHCoefficients<T>(this T properties, Vector3 position) where T : IPropertyWrapper
		{
			LightProbes.GetInterpolatedProbe(position, null, out var probe);
			for (int i = 0; i < 3; i++)
			{
				int param = s_SHA[i];
				Vector4 value = new Vector4(probe[i, 3], probe[i, 1], probe[i, 2], probe[i, 0] - probe[i, 6]);
				properties.SetVector(param, value);
			}
			for (int j = 0; j < 3; j++)
			{
				int param2 = s_SHB[j];
				Vector4 value2 = new Vector4(probe[j, 4], probe[j, 5], probe[j, 6] * 3f, probe[j, 7]);
				properties.SetVector(param2, value2);
			}
			int param3 = s_SHC;
			Vector4 value3 = new Vector4(probe[0, 8], probe[1, 8], probe[2, 8], 1f);
			properties.SetVector(param3, value3);
		}
	}
}
