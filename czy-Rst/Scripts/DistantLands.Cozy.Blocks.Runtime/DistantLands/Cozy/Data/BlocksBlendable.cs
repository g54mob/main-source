using System;
using UnityEngine;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	public abstract class BlocksBlendable : CozyProfile
	{
		public delegate Color ColorAdjustment(Color color, float adjustment);

		public WeightedRandomChance chance;

		public abstract void AdjustColors(ColorAdjustment colorMethod, float adjustment);

		public abstract void PullFromAtmosphere();

		public abstract void SingleBlockBlend(BlocksModule module);

		public abstract ColorBlock GetValues(BlocksModule module);

		public static Color HueShift(Color color, float shift)
		{
			float a = color.a;
			Color.RGBToHSV(color, out var H, out var S, out var V);
			H += shift;
			Color result = Color.HSVToRGB(H, S, V, hdr: true);
			result.a = a;
			return result;
		}

		public static Color ValueShift(Color color, float shift)
		{
			float a = color.a;
			Color.RGBToHSV(color, out var H, out var S, out var V);
			V += shift;
			Color result = Color.HSVToRGB(H, S, V, hdr: true);
			result.a = a;
			return result;
		}

		public static Color SaturationShift(Color color, float shift)
		{
			float a = color.a;
			Color.RGBToHSV(color, out var H, out var S, out var V);
			S += shift;
			Color result = Color.HSVToRGB(H, S, V, hdr: true);
			result.a = a;
			return result;
		}
	}
}
