using System;

namespace NAudio.Wave.SampleProviders
{
	public class SignalGenerator : ISampleProvider
	{
		private readonly WaveFormat waveFormat;

		private readonly Random random;

		private readonly double[] pinkNoiseBuffer;

		private const double TwoPi = Math.PI * 2.0;

		private int nSample;

		private double phi;

		public WaveFormat WaveFormat => null;

		public double Frequency { get; set; }

		public double FrequencyLog => 0.0;

		public double FrequencyEnd { get; set; }

		public double FrequencyEndLog => 0.0;

		public double Gain { get; set; }

		public bool[] PhaseReverse { get; }

		public SignalGeneratorType Type { get; set; }

		public double SweepLengthSecs { get; set; }

		public SignalGenerator()
		{
		}

		public SignalGenerator(int sampleRate, int channel)
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}

		private double NextRandomTwo()
		{
			return 0.0;
		}
	}
}
