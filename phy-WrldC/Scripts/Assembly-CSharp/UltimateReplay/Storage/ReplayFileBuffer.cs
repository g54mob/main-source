using System.Collections.Generic;

namespace UltimateReplay.Storage
{
	public class ReplayFileBuffer
	{
		private HashSet<ReplayFileChunk> loadedChunks = new HashSet<ReplayFileChunk>();

		private Queue<ReplayFileChunk> removeQueue = new Queue<ReplayFileChunk>();

		public void StoreChunk(ReplayFileChunk chunk)
		{
			if (!loadedChunks.Contains(chunk))
			{
				loadedChunks.Add(chunk);
			}
		}

		public bool HasLoadedChunk(int chunkID)
		{
			foreach (ReplayFileChunk loadedChunk in loadedChunks)
			{
				if (loadedChunk.chunkID == chunkID)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasLoadedChunk(float timeStamp)
		{
			foreach (ReplayFileChunk loadedChunk in loadedChunks)
			{
				if (timeStamp >= loadedChunk.ChunkStartTime && timeStamp <= loadedChunk.ChunkEndTime)
				{
					return true;
				}
			}
			return false;
		}

		public ReplayFileChunk GetLoadedChunk(float timeStamp)
		{
			foreach (ReplayFileChunk loadedChunk in loadedChunks)
			{
				if (loadedChunk.Restore(timeStamp) != null)
				{
					return loadedChunk;
				}
			}
			return null;
		}

		public void ReleaseAllChunks()
		{
			loadedChunks.Clear();
			removeQueue.Clear();
		}

		public void ReleaseOldChunks(float currentTimeStamp, ReplayFileEnumReleaseMode mode)
		{
			switch (mode)
			{
			case ReplayFileEnumReleaseMode.ChunksBefore:
				foreach (ReplayFileChunk loadedChunk in loadedChunks)
				{
					if (loadedChunk.ChunkEndTime < currentTimeStamp)
					{
						removeQueue.Enqueue(loadedChunk);
					}
				}
				break;
			case ReplayFileEnumReleaseMode.ChunksAfter:
				foreach (ReplayFileChunk loadedChunk2 in loadedChunks)
				{
					if (loadedChunk2.ChunkStartTime > currentTimeStamp)
					{
						removeQueue.Enqueue(loadedChunk2);
					}
				}
				break;
			}
			while (removeQueue.Count > 0)
			{
				ReplayFileChunk item = removeQueue.Dequeue();
				if (loadedChunks.Contains(item))
				{
					loadedChunks.Remove(item);
				}
			}
		}
	}
}
