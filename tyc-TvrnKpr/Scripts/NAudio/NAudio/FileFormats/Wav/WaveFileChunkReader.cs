using System.Collections.Generic;
using System.IO;
using NAudio.Wave;

namespace NAudio.FileFormats.Wav
{
	internal class WaveFileChunkReader
	{
		private WaveFormat waveFormat;

		private long dataChunkPosition;

		private long dataChunkLength;

		private List<RiffChunk> riffChunks;

		private readonly bool strictMode;

		private bool isRf64;

		private readonly bool storeAllChunks;

		private long riffSize;

		public WaveFormat WaveFormat => null;

		public long DataChunkPosition => 0L;

		public long DataChunkLength => 0L;

		public List<RiffChunk> RiffChunks => null;

		public void ReadWaveHeader(Stream stream)
		{
		}

		private void ReadDs64Chunk(BinaryReader reader)
		{
		}

		private static RiffChunk GetRiffChunk(Stream stream, int chunkIdentifier, int chunkLength)
		{
			return null;
		}

		private void ReadRiffHeader(BinaryReader br)
		{
		}
	}
}
