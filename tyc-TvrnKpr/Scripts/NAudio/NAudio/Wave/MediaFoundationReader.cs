using System;
using System.Runtime.CompilerServices;
using NAudio.MediaFoundation;

namespace NAudio.Wave
{
	public class MediaFoundationReader : WaveStream
	{
		public class MediaFoundationReaderSettings
		{
			public bool RequestFloatOutput { get; set; }

			public bool SingleReaderObject { get; set; }

			public bool RepositionInRead { get; set; }
		}

		private WaveFormat waveFormat;

		private long length;

		private MediaFoundationReaderSettings settings;

		private readonly string file;

		private IMFSourceReader pReader;

		private long position;

		private byte[] decoderOutputBuffer;

		private int decoderOutputOffset;

		private int decoderOutputCount;

		private long repositionTo;

		public override WaveFormat WaveFormat => null;

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

		public event EventHandler WaveFormatChanged
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

		protected MediaFoundationReader()
		{
		}

		public MediaFoundationReader(string file)
		{
		}

		public MediaFoundationReader(string file, MediaFoundationReaderSettings settings)
		{
		}

		protected void Init(MediaFoundationReaderSettings initialSettings)
		{
		}

		private WaveFormat GetCurrentWaveFormat(IMFSourceReader reader)
		{
			return null;
		}

		private static MediaType GetCurrentMediaType(IMFSourceReader reader)
		{
			return null;
		}

		protected virtual IMFSourceReader CreateReader(MediaFoundationReaderSettings settings)
		{
			return null;
		}

		private long GetLength(IMFSourceReader reader)
		{
			return 0L;
		}

		private void EnsureBuffer(int bytesRequired)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private int ReadFromDecoderBuffer(byte[] buffer, int offset, int needed)
		{
			return 0;
		}

		private void Reposition(long desiredPosition)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void OnWaveFormatChanged()
		{
		}
	}
}
