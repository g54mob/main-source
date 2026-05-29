using System;
using FishNet.Documenting;

namespace FishNet.Managing.Timing
{
	[APIExclude]
	public class MovingAverage : IDisposable
	{
		private int _writeIndex;

		private float[] _samples;

		private int _writtenSamples;

		private float _sampleAccumulator;

		public float Average { get; private set; }

		public int SampleSize { get; private set; }

		public MovingAverage(int sampleSize)
		{
		}

		public void ComputeAverage(float newSample)
		{
		}

		public void Reset()
		{
		}

		public void Dispose()
		{
		}
	}
}
