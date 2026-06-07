using UnityEngine;

namespace ModApi.Craft
{
	public class ColorStyles
	{
		public const float FlatMetallic = 0.1f;

		public const float FlatSmoothness = 0.08f;

		public const float GlossMetallic = 0.4f;

		public const float GlossSmoothness = 0.83f;

		public const float SemiGlossMetallic = 0.3f;

		public const float SemiGlossSmoothness = 0.6f;

		public const string StyleNameCustom = "Custom";

		public const string StyleNameFlat = "Flat";

		public const string StyleNameGloss = "Gloss";

		public const string StyleNameSemiGloss = "Semi-Gloss";

		public static float GetMetallicValue(string styleName)
		{
			if (styleName == "Gloss")
			{
				return 0.4f;
			}
			if (styleName == "Semi-Gloss")
			{
				return 0.3f;
			}
			return 0.1f;
		}

		public static float GetSmoothnessValue(string styleName)
		{
			if (styleName == "Gloss")
			{
				return 0.83f;
			}
			if (styleName == "Semi-Gloss")
			{
				return 0.6f;
			}
			return 0.08f;
		}

		public static string GetStyleName(float metallic, float smoothness, float detailStrength, float emissionStrength, float transparencyStrength)
		{
			if (!Mathf.Approximately(detailStrength, 1f) || !Mathf.Approximately(emissionStrength, 0f) || !Mathf.Approximately(transparencyStrength, 0f))
			{
				return "Custom";
			}
			if (Mathf.Approximately(metallic, 0.4f) && Mathf.Approximately(smoothness, 0.83f))
			{
				return "Gloss";
			}
			if (Mathf.Approximately(metallic, 0.3f) && Mathf.Approximately(smoothness, 0.6f))
			{
				return "Semi-Gloss";
			}
			if (Mathf.Approximately(metallic, 0.1f) && Mathf.Approximately(smoothness, 0.08f))
			{
				return "Flat";
			}
			return "Custom";
		}
	}
}
