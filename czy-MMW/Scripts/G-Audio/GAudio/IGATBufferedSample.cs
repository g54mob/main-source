namespace GAudio
{
	public interface IGATBufferedSample
	{
		bool IsFirstChunk { get; }

		bool IsLastChunk { get; set; }

		AGATPanInfo PanInfo { get; }

		GATData AudioData { get; }

		int NextIndex { get; set; }

		int OffsetInBuffer { get; }

		GATData ProcessingBuffer { get; }

		GATTrack Track { get; }

		float PlayingGain { get; }

		void CacheToProcessingBuffer(int length);
	}
}
