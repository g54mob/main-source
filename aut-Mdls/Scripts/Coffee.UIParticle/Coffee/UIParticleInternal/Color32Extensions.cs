using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	internal static class Color32Extensions
	{
		private static readonly List<Color32> s_Colors = new List<Color32>();

		private static byte[] s_LinearToGammaLut;

		private static byte[] s_GammaToLinearLut;

		public static byte LinearToGamma(this byte self)
		{
			if (s_LinearToGammaLut == null)
			{
				s_LinearToGammaLut = new byte[256];
				for (int i = 0; i < 256; i++)
				{
					s_LinearToGammaLut[i] = (byte)(Mathf.LinearToGammaSpace((float)i / 255f) * 255f);
				}
			}
			return s_LinearToGammaLut[self];
		}

		public static byte GammaToLinear(this byte self)
		{
			if (s_GammaToLinearLut == null)
			{
				s_GammaToLinearLut = new byte[256];
				for (int i = 0; i < 256; i++)
				{
					s_GammaToLinearLut[i] = (byte)(Mathf.GammaToLinearSpace((float)i / 255f) * 255f);
				}
			}
			return s_GammaToLinearLut[self];
		}

		public static void LinearToGamma(this Mesh self)
		{
			self.GetColors(s_Colors);
			int count = s_Colors.Count;
			for (int i = 0; i < count; i++)
			{
				Color32 value = s_Colors[i];
				value.r = value.r.LinearToGamma();
				value.g = value.g.LinearToGamma();
				value.b = value.b.LinearToGamma();
				s_Colors[i] = value;
			}
			self.SetColors(s_Colors);
		}

		public static void GammaToLinear(this Mesh self)
		{
			self.GetColors(s_Colors);
			int count = s_Colors.Count;
			for (int i = 0; i < count; i++)
			{
				Color32 value = s_Colors[i];
				value.r = value.r.GammaToLinear();
				value.g = value.g.GammaToLinear();
				value.b = value.b.GammaToLinear();
				s_Colors[i] = value;
			}
			self.SetColors(s_Colors);
		}
	}
}
