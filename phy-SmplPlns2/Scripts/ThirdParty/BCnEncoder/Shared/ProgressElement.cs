namespace BCnEncoder.Shared
{
	public struct ProgressElement
	{
		public int CurrentBlock { get; }

		public int TotalBlocks { get; }

		public float Percentage => (float)CurrentBlock / (float)TotalBlocks;

		public ProgressElement(int currentBlock, int totalBlocks)
		{
			CurrentBlock = currentBlock;
			TotalBlocks = totalBlocks;
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}, {2}: {3}, {4}: {5}", "CurrentBlock", CurrentBlock, "TotalBlocks", TotalBlocks, "Percentage", Percentage);
		}
	}
}
