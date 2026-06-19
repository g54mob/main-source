using FMODUnity;

public class EmptyMusicSupplier : PriorityMusicSupplier
{
	public int Priority;

	public override int SupplierPriority => 0;

	public override EventReference RequestSong()
	{
		return default(EventReference);
	}
}
