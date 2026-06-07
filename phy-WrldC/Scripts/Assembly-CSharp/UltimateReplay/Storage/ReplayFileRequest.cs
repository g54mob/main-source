namespace UltimateReplay.Storage
{
	internal enum ReplayFileRequest
	{
		Idle = 0,
		FetchChunk = 1,
		FetchChunkBuffered = 2,
		WriteChunk = 3,
		Commit = 4,
		Discard = 5,
		FetchHeader = 6,
		WriteHeader = 7,
		FetchTable = 8,
		FetchStateBuffer = 9
	}
}
