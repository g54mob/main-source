namespace UltimateReplay.Storage
{
	public struct ReplayFileChunkFetchData
	{
		public bool isIDBased;

		public int chunkID;

		public float chunkTimeStamp;

		public ReplayFileChunkFetchData(int chunkID)
		{
			isIDBased = true;
			this.chunkID = chunkID;
			chunkTimeStamp = -1f;
		}

		public ReplayFileChunkFetchData(float chunkTimeStamp)
		{
			isIDBased = false;
			this.chunkTimeStamp = chunkTimeStamp;
			chunkID = -1;
		}
	}
}
