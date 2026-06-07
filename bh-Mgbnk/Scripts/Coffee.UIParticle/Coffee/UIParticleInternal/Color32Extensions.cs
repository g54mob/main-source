using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	internal static class Color32Extensions
	{
		private static readonly List<Color32> s_Colors;

		private static byte[] s_LinearToGammaLut;

		private static byte[] s_GammaToLinearLut;

		public static byte LinearToGamma(this byte self)
		{
			return 0;
		}

		public static byte GammaToLinear(this byte self)
		{
			return 0;
		}

		public static void LinearToGamma(this Mesh self)
		{
		}

		public static void GammaToLinear(this Mesh self)
		{
		}
	}
}
