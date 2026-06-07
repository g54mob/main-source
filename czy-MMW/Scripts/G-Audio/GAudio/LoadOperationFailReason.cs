namespace GAudio
{
	public enum LoadOperationFailReason
	{
		Unknown = 0,
		CannotOpenFile = 1,
		NoLargeEnoughChunkInAllocator = 2,
		OutOfPreAllocatedMemory = 3
	}
}
