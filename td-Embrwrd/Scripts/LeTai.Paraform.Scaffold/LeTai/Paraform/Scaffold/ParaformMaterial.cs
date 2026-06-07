using UnityEngine;

namespace LeTai.Paraform.Scaffold
{
	public static class ParaformMaterial
	{
		public static class ShaderID
		{
			public static readonly int G_CANVAS_SCALE_FACTOR;

			public const string REFRACTION_MODE_OFF = "_REFRACTION_MODE_OFF";

			public const string REFRACTION_MODE_ON = "_REFRACTION_MODE_ON";

			public const string REFRACTION_MODE_CHROMATIC = "_REFRACTION_MODE_CHROMATIC";

			public static readonly int REFRACTIVE_INDEX_DUMMY;

			public static readonly int CHROMATIC_DISPERSION_DUMMY;

			public static readonly int REFRACTIVE_INDEX_RATIOS;

			public const string USE_EDGE_GLINT = "_USE_EDGE_GLINT";

			public static readonly int EDGE_GLINT_DIRECTIONS;

			public static readonly int EDGE_GLINT1_STRENGTH;

			public static readonly int EDGE_GLINT2_STRENGTH;

			public static readonly int EDGE_GLINT_WRAP_RAW;

			public static readonly int EDGE_GLINT_SHARPNESS_RAW;
		}

		private const float NA_D_LINE_UM = 0.5893f;

		private const float HED_LINE_UM = 0.58756f;

		private const float F_LINE_UM = 0.48613f;

		private const float C_LINE_UM = 0.65627f;

		private static readonly Vector3 PRIMARIES_UM;

		private static readonly float REF_COEFF;

		private static readonly Vector3 PRIMARIES_COEFF;

		private static readonly float DISPERSION_FC;

		private static readonly float DISPERSION_HED_NA_D;

		private const float EDGE_GLINT_WRAP_SCALE = 20f;

		private const float EDGE_GLINT_WRAP_POWER = 0.25f;

		public static Vector3 GetRefractiveIndexRatios(float iorAtNaDLine, float abbeRcp)
		{
			return default(Vector3);
		}

		private static float InvSq(float x)
		{
			return 0f;
		}

		public static void SetDispersion(Material material, float dispersion)
		{
		}

		public static void SetRefractiveIndex(Material material, float refractiveIndex)
		{
		}

		public static void SetRefractiveIndexRatios(Material material, float refractiveIndex, float chromaticDispersion)
		{
		}

		public static float EdgeGlintWrapToRaw(float edgeGlintWrap)
		{
			return 0f;
		}

		public static float EdgeGlintWrapFromRaw(float edgeGlintWrapRaw)
		{
			return 0f;
		}

		public static float GetEdgeGlintWrap(Material material)
		{
			return 0f;
		}

		public static void SetEdgeGlintWrap(Material material, float edgeGlintWrap)
		{
		}

		public static float EdgeGlintSharpnessToRaw(float edgeGlintSharpness)
		{
			return 0f;
		}

		public static float EdgeGlintSharpnessFromRaw(float edgeGlintSharpnessRaw)
		{
			return 0f;
		}

		public static float GetEdgeGlintSharpness(Material material)
		{
			return 0f;
		}

		public static void SetEdgeGlintSharpness(Material material, float edgeGlintSharpness)
		{
		}
	}
}
