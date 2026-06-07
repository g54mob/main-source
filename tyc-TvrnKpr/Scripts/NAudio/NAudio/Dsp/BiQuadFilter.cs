namespace NAudio.Dsp
{
	public class BiQuadFilter
	{
		private double a0;

		private double a1;

		private double a2;

		private double a3;

		private double a4;

		private float x1;

		private float x2;

		private float y1;

		private float y2;

		public float Transform(float inSample)
		{
			return 0f;
		}

		private void SetCoefficients(double aa0, double aa1, double aa2, double b0, double b1, double b2)
		{
		}

		public void SetLowPassFilter(float sampleRate, float cutoffFrequency, float q)
		{
		}

		public void SetPeakingEq(float sampleRate, float centreFrequency, float q, float dbGain)
		{
		}

		public void SetHighPassFilter(float sampleRate, float cutoffFrequency, float q)
		{
		}

		public static BiQuadFilter LowPassFilter(float sampleRate, float cutoffFrequency, float q)
		{
			return null;
		}

		public static BiQuadFilter HighPassFilter(float sampleRate, float cutoffFrequency, float q)
		{
			return null;
		}

		public static BiQuadFilter BandPassFilterConstantSkirtGain(float sampleRate, float centreFrequency, float q)
		{
			return null;
		}

		public static BiQuadFilter BandPassFilterConstantPeakGain(float sampleRate, float centreFrequency, float q)
		{
			return null;
		}

		public static BiQuadFilter NotchFilter(float sampleRate, float centreFrequency, float q)
		{
			return null;
		}

		public static BiQuadFilter AllPassFilter(float sampleRate, float centreFrequency, float q)
		{
			return null;
		}

		public static BiQuadFilter PeakingEQ(float sampleRate, float centreFrequency, float q, float dbGain)
		{
			return null;
		}

		public static BiQuadFilter LowShelf(float sampleRate, float cutoffFrequency, float shelfSlope, float dbGain)
		{
			return null;
		}

		public static BiQuadFilter HighShelf(float sampleRate, float cutoffFrequency, float shelfSlope, float dbGain)
		{
			return null;
		}

		private BiQuadFilter()
		{
		}

		private BiQuadFilter(double a0, double a1, double a2, double b0, double b1, double b2)
		{
		}
	}
}
