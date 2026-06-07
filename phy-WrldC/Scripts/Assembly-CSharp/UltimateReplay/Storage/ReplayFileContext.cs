namespace UltimateReplay.Storage
{
	internal class ReplayFileContext
	{
		public ReplayFileHeader header;

		public ReplayFileChunkTable chunkTable = new ReplayFileChunkTable();

		public ReplayFileChunk chunk = new ReplayFileChunk();

		public ReplayFileBuffer buffer = new ReplayFileBuffer();

		public ReplayInitialDataBuffer initialStateBuffer = new ReplayInitialDataBuffer();

		public ReplayFileStream fileStream;
	}
}
