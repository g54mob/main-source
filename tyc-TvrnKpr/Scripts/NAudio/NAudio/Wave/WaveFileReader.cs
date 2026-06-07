using System;
using System.Collections.Generic;
using System.IO;

namespace NAudio.Wave
{
	public class WaveFileReader : WaveStream
	{
		private readonly WaveFormat waveFormat;

		private readonly bool ownInput;

		private readonly long dataPosition;

		private readonly long dataChunkLength;

		private readonly object lockObject;

		private Stream waveStream;

		public List<RiffChunk> ExtraChunks { get; }

		public override WaveFormat WaveFormat => null;

		public override long Length => 0L;

		public long SampleCount => 0L;

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

		public WaveFileReader(string waveFile)
		{
		}

		public WaveFileReader(Stream inputStream)
		{
		}

		private WaveFileReader(Stream inputStream, bool ownInput)
		{
		}

		public byte[] GetChunkData(RiffChunk chunk)
		{
			return null;
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override int Read(byte[] array, int offset, int count)
		{
			return 0;
		}

		public float[] ReadNextSampleFrame()
		{
			return null;
		}

		[Obsolete("Use ReadNextSampleFrame instead (this version does not support stereo properly)")]
		public bool TryReadFloat(out float sampleValue)
		{
			sampleValue = default(float);
			return false;
		}
	}
}
