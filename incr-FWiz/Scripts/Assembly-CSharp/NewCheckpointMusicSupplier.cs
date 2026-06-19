using FMODUnity;

public class NewCheckpointMusicSupplier : PriorityMusicSupplier
{
	public int Priority;

	public EventReference Track;

	public Checkpoint Checkpoint;

	public DefaultPriorityMusicSupplier DefaultMusicSupplier;

	public override int SupplierPriority => 0;

	public void Start()
	{
	}

	public void Initiate()
	{
	}

	public void OnFreshUnlock()
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
