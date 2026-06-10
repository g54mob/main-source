using UnityEngine;

namespace BrainFailProductions.PolyFew.AsImpL
{
	public class ModelUtil
	{
		public enum MtlBlendMode
		{
			OPAQUE = 0,
			CUTOUT = 1,
			FADE = 2,
			TRANSPARENT = 3
		}

		public static void SetupMaterialWithBlendMode(Material mtl, MtlBlendMode mode)
		{
		}

		public static bool ScanTransparentPixels(Texture2D texture, ref MtlBlendMode mode)
		{
			return false;
		}

		public static void DetectMtlBlendFadeOrCutout(float alpha, ref MtlBlendMode mode, ref bool noDoubt)
		{
		}

		public static Texture2D HeightToNormalMap(Texture2D bumpMap, float amount = 1f)
		{
			return null;
		}

		private static int WrapInt(int pos, int boundary)
		{
			return 0;
		}
	}
}
