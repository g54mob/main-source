using System;
using System.Runtime.CompilerServices;
using NAudio.Wave.SampleProviders;

namespace NAudio.Wave
{
	public class WaveChannel32 : WaveStream, ISampleNotifier
	{
		private WaveStream sourceStream;

		private readonly WaveFormat waveFormat;

		private readonly long length;

		private readonly int destBytesPerSample;

		private readonly int sourceBytesPerSample;

		private float volume;

		private float pan;

		private long position;

		private readonly ISampleChunkConverter sampleProvider;

		private readonly object lockObject;

		private SampleEventArgs sampleEventArgs;

		public override int BlockAlign => 0;

		public override long Length => 0L;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public bool PadWithZeroes { get; set; }

		public override WaveFormat WaveFormat => null;

		public float Volume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Pan
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public event EventHandler<SampleEventArgs> Sample
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public WaveChannel32(WaveStream sourceStream, float volume, float pan)
		{
		}

		private long SourceToDest(long sourceBytes)
		{
			return 0L;
		}

		private long DestToSource(long destBytes)
		{
			return 0L;
		}

		public WaveChannel32(WaveStream sourceStream)
		{
		}

		public override int Read(byte[] destBuffer, int offset, int numBytes)
		{
			return 0;
		}

		public override bool HasData(int count)
		{
			return false;
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void RaiseSample(float left, float right)
		{
		}
	}
}
