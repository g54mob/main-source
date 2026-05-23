using UnityEngine;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	public static class PSXColor
	{
		public static float RGBFromSRGBScalar(float x)
		{
			float result = x / 12.92f;
			float result2 = Mathf.Pow((x + 0.055f) / 1.055f, 2.4f);
			if (!(x <= 0.04045f))
			{
				return result2;
			}
			return result;
		}

		public static Vector3 RGBFromSRGB(Vector3 rgb)
		{
			return new Vector3(RGBFromSRGBScalar(rgb.x), RGBFromSRGBScalar(rgb.y), RGBFromSRGBScalar(rgb.z));
		}

		public static float SRGBFromRGBScalar(float x)
		{
			float result = x * 12.92f;
			float result2 = Mathf.Pow(x, 5f / 12f) * 1.055f - 0.055f;
			if (!(x <= 0.0031308f))
			{
				return result2;
			}
			return result;
		}

		public static Vector3 SRGBFromRGB(Vector3 rgb)
		{
			return new Vector3(SRGBFromRGBScalar(rgb.x), SRGBFromRGBScalar(rgb.y), SRGBFromRGBScalar(rgb.z));
		}

		public static float TonemapperGenericScalar(float x, float contrast, float shoulder, Vector2 graypointCoefficients)
		{
			return Mathf.Clamp01(Mathf.Pow(x, contrast) / (Mathf.Pow(x, contrast * shoulder) * graypointCoefficients.x + graypointCoefficients.y));
		}

		public static Vector3 TonemapperGeneric(Vector3 rgb, float contrast, float shoulder, Vector2 graypointCoefficients, float crossTalk, float saturation, float crossTalkSaturation)
		{
			float num = Mathf.Max(Mathf.Max(rgb.x, Mathf.Max(rgb.y, rgb.z)), 5.9604645E-08f);
			Vector3 vector = rgb / num;
			num = TonemapperGenericScalar(num, contrast, shoulder, graypointCoefficients);
			vector = new Vector3(Mathf.Max(0f, vector.x), Mathf.Max(0f, vector.y), Mathf.Max(0f, vector.z));
			float p = (saturation + contrast) / crossTalkSaturation;
			vector = new Vector3(Mathf.Pow(vector.x, p), Mathf.Pow(vector.y, p), Mathf.Pow(vector.z, p));
			float t = Mathf.Clamp01(Mathf.Pow(num, crossTalk));
			vector = new Vector3(Mathf.Lerp(vector.x, 1f, t), Mathf.Lerp(vector.y, 1f, t), Mathf.Lerp(vector.z, 1f, t));
			vector = new Vector3(Mathf.Pow(vector.x, crossTalkSaturation), Mathf.Pow(vector.y, crossTalkSaturation), Mathf.Pow(vector.z, crossTalkSaturation));
			return vector * num;
		}
	}
}
