namespace GAudio
{
	public class GATFixedMemDebugInfo
	{
		public readonly int ChunkNb;

		public readonly int AllocatedSize;

		public readonly string Description;

		public GATFixedMemDebugInfo(int nb, int allocated, string description)
		{
			ChunkNb = nb;
			AllocatedSize = allocated;
			Description = description;
		}
	}
}
