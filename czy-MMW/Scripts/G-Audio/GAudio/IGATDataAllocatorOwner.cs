namespace GAudio
{
	public interface IGATDataAllocatorOwner
	{
		GATDataAllocator DataAllocator { get; }

		GATDataAllocator.InitializationSettings AllocatorInitSettings { get; }
	}
}
