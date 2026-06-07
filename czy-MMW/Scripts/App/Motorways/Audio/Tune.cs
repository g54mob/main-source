using UnityEngine;

namespace Motorways.Audio
{
	public static class Tune
	{
		public static readonly float[] JUST = new float[12]
		{
			1f, 1.066667f, 1.125f, 1.2f, 1.25f, 1.333333f, 1.4f, 1.5f, 1.6f, 1.666667f,
			1.777778f, 1.875f
		};

		public static int freqRatioToCents(float freqRatio)
		{
			return (int)Mathf.Round(1200f * Mathf.Log(freqRatio, 2f));
		}

		public static float centsToFreqRatio(int cents)
		{
			return Mathf.Pow(2f, (float)cents / 1200f);
		}
	}
}
