namespace GAudio
{
	public class GATMemDebugInfo
	{
		public readonly int ChunkNb;

		public readonly int AllocatedSize;

		public readonly int MaxSize;

		public GATMemDebugInfo(int nb, int allocated, int max)
		{
			ChunkNb = nb;
			AllocatedSize = allocated;
			MaxSize = max;
		}

		public string Description()
		{
			return $"Chunk {ChunkNb}, allocated: {AllocatedSize}, max: {MaxSize}";
		}
	}
}
