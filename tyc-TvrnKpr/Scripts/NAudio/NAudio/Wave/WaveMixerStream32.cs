using System.Collections.Generic;

namespace NAudio.Wave
{
	public class WaveMixerStream32 : WaveStream
	{
		private readonly List<WaveStream> inputStreams;

		private readonly object inputsLock;

		private WaveFormat waveFormat;

		private long length;

		private long position;

		private readonly int bytesPerSample;

		public int InputCount => 0;

		public bool AutoStop { get; set; }

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

		public override WaveFormat WaveFormat => null;

		public WaveMixerStream32()
		{
		}

		public WaveMixerStream32(IEnumerable<WaveStream> inputStreams, bool autoStop)
		{
		}

		public void AddInputStream(WaveStream waveStream)
		{
		}

		public void RemoveInputStream(WaveStream waveStream)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private static void Sum32BitAudio(byte[] destBuffer, int offset, byte[] sourceBuffer, int bytesRead)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
