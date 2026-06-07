using System;
using NAudio.Dsp;

namespace NAudio.Wave.SampleProviders
{
	public class SmbPitchShiftingSampleProvider : ISampleProvider
	{
		private readonly ISampleProvider sourceStream;

		private readonly WaveFormat waveFormat;

		private float pitch;

		private readonly int fftSize;

		private readonly long osamp;

		private readonly SmbPitchShifter shifterLeft;

		private readonly SmbPitchShifter shifterRight;

		private const float LIM_THRESH = 0.95f;

		private const float LIM_RANGE = 0.050000012f;

		private const float M_PI_2 = (float)Math.PI / 2f;

		public WaveFormat WaveFormat => null;

		public float PitchFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public SmbPitchShiftingSampleProvider(ISampleProvider sourceProvider)
		{
		}

		public SmbPitchShiftingSampleProvider(ISampleProvider sourceProvider, int fftSize, long osamp, float initialPitch)
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}

		private float Limiter(float sample)
		{
			return 0f;
		}
	}
}
