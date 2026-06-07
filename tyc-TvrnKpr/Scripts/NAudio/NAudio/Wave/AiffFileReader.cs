using System.Collections.Generic;
using System.IO;

namespace NAudio.Wave
{
	public class AiffFileReader : WaveStream
	{
		public struct AiffChunk
		{
			public string ChunkName;

			public uint ChunkLength;

			public uint ChunkStart;

			public AiffChunk(uint start, string name, uint length)
			{
				ChunkName = null;
				ChunkLength = 0u;
				ChunkStart = 0u;
			}
		}

		private readonly WaveFormat waveFormat;

		private readonly bool ownInput;

		private readonly long dataPosition;

		private readonly int dataChunkLength;

		private readonly List<AiffChunk> chunks;

		private Stream waveStream;

		private readonly object lockObject;

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

		public AiffFileReader(string aiffFile)
		{
		}

		public AiffFileReader(Stream inputStream)
		{
		}

		public static void ReadAiffHeader(Stream stream, out WaveFormat format, out long dataChunkPosition, out int dataChunkLength, List<AiffChunk> chunks)
		{
			format = null;
			dataChunkPosition = default(long);
			dataChunkLength = default(int);
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override int Read(byte[] array, int offset, int count)
		{
			return 0;
		}

		private static uint ConvertInt(byte[] buffer)
		{
			return 0u;
		}

		private static short ConvertShort(byte[] buffer)
		{
			return 0;
		}

		private static AiffChunk ReadChunkHeader(BinaryReader br)
		{
			return default(AiffChunk);
		}

		private static string ReadChunkName(BinaryReader br)
		{
			return null;
		}
	}
}
