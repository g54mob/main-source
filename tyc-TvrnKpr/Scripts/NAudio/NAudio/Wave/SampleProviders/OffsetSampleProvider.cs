using System;

namespace NAudio.Wave.SampleProviders
{
	public class OffsetSampleProvider : ISampleProvider
	{
		private readonly ISampleProvider sourceProvider;

		private int phase;

		private int phasePos;

		private int delayBySamples;

		private int skipOverSamples;

		private int takeSamples;

		private int leadOutSamples;

		public int DelayBySamples
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public TimeSpan DelayBy
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public int SkipOverSamples
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public TimeSpan SkipOver
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public int TakeSamples
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public TimeSpan Take
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public int LeadOutSamples
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public TimeSpan LeadOut
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public WaveFormat WaveFormat => null;

		private int TimeSpanToSamples(TimeSpan time)
		{
			return 0;
		}

		private TimeSpan SamplesToTimeSpan(int samples)
		{
			return default(TimeSpan);
		}

		public OffsetSampleProvider(ISampleProvider sourceProvider)
		{
		}

		public int Read(float[] buffer, int offset, int count)
		{
			return 0;
		}
	}
}
