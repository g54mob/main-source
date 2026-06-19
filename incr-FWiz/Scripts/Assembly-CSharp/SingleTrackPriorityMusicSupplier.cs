using FMODUnity;

public class SingleTrackPriorityMusicSupplier : PriorityMusicSupplier
{
	public int Priority;

	public EventReference Track;

	public bool PlayOnEnable;

	public override int SupplierPriority => 0;

	private void Start()
	{
	}

	public override EventReference RequestSong()
	{
		return default(EventReference);
	}

	public override void OnSongEnd()
	{
	}
}
