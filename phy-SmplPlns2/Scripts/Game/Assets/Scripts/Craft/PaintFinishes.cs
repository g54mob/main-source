namespace Assets.Scripts.Craft
{
	public static class PaintFinishes
	{
		public const string FinishNameFlat = "Flat";

		public const string FinishNameGloss = "Gloss";

		public const string FinishNameSemiGloss = "Semi-Gloss";

		public const float FlatLegacyReflectivity = 0f;

		public const float FlatMetallic = 0.65f;

		public const float FlatSmoothness = 0.08f;

		public const float GlossLegacyReflectivity = 0.3f;

		public const float GlossLegacySmoothness = 0.93f;

		public const float GlossMetallic = 0.5f;

		public const float GlossSmoothness = 0.83f;

		public const float SemiGlossLegacyReflectivity = 0.15f;

		public const float SemiGlossLegacySmoothness = 0.65f;

		public const float SemiGlossMetallic = 0.5f;

		public const float SemiGlossSmoothness = 0.7f;

		public static string GetFinishName(float reflectiveness)
		{
			if (reflectiveness < 0.15f)
			{
				return "Flat";
			}
			if (reflectiveness < 0.3f)
			{
				return "Semi-Gloss";
			}
			return "Gloss";
		}

		public static string GetFinishName(float metallic, float smoothness)
		{
			if (smoothness >= 0.83f)
			{
				return "Gloss";
			}
			if (smoothness >= 0.7f)
			{
				return "Semi-Gloss";
			}
			return "Flat";
		}

		public static float GetLegacyReflectivity(float metallic, float smoothness)
		{
			return GetLegacyReflectivity(GetFinishName(metallic, smoothness));
		}

		public static float GetLegacyReflectivity(string finishName)
		{
			if (finishName == "Semi-Gloss")
			{
				return 0.15f;
			}
			if (finishName == "Gloss")
			{
				return 0.3f;
			}
			return 0f;
		}

		public static float GetMetallicValue(string finishName)
		{
			if (finishName == "Gloss")
			{
				return 0.5f;
			}
			if (finishName == "Semi-Gloss")
			{
				return 0.5f;
			}
			return 0.65f;
		}

		public static float GetSmoothnessValue(string finishName)
		{
			if (finishName == "Gloss")
			{
				return 0.83f;
			}
			if (finishName == "Semi-Gloss")
			{
				return 0.7f;
			}
			return 0.08f;
		}
	}
}
