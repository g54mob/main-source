using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	public static class Ambisonic
	{
		internal struct PolarCoord
		{
			public float azimuth;

			public float elevation;

			public void FromCart(Vector3 position)
			{
			}
		}

		public const int MaxCoeffs = 16;

		private static float[] _weightsFuMa;

		private static float[] _weightsSN3D;

		public static float[] GetNormalisationWeights(AmbisonicNormalisation normalisation)
		{
			return null;
		}

		public static int GetCoeffCount(AmbisonicOrder order)
		{
			return 0;
		}

		public static AmbisonicChannelOrder GetChannelOrder(AmbisonicFormat format)
		{
			return default(AmbisonicChannelOrder);
		}

		public static AmbisonicNormalisation GetNormalisation(AmbisonicFormat format)
		{
			return default(AmbisonicNormalisation);
		}

		static Ambisonic()
		{
		}

		private static float[] BuildWeightsFuMa()
		{
			return null;
		}

		private static int GetN(int acn)
		{
			return 0;
		}

		private static int GetM(int acn)
		{
			return 0;
		}

		private static int Factorial(int x)
		{
			return 0;
		}

		private static float GetNormalisationSN3D(int acn)
		{
			return 0f;
		}

		private static float GetNormalisationSN3D(int n, int m)
		{
			return 0f;
		}

		private static float GetNormalisationN3D(int n, int m)
		{
			return 0f;
		}

		private static float[] BuildWeightsSN3D()
		{
			return null;
		}
	}
}
