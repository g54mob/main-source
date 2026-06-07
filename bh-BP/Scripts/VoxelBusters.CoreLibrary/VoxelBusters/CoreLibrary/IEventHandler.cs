namespace VoxelBusters.CoreLibrary
{
	[IncludeInDocs]
	public interface IEventHandler
	{
		int CallbackOrder { get; }
	}
}
