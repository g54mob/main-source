using System;
using NAudio.Utils;

namespace NAudio.Wave
{
	public class BufferedWaveProvider : IWaveProvider
	{
		private CircularBuffer circularBuffer;

		private readonly WaveFormat waveFormat;

		public bool ReadFully { get; set; }

		public int BufferLength { get; set; }

		public TimeSpan BufferDuration
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public bool DiscardOnBufferOverflow { get; set; }

		public int BufferedBytes => 0;

		public TimeSpan BufferedDuration => default(TimeSpan);

		public WaveFormat WaveFormat => null;

		public BufferedWaveProvider(WaveFormat waveFormat)
		{
		}

		public void AddSamples(byte[] buffer, int offset, int count)
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public void ClearBuffer()
		{
		}
	}
}
