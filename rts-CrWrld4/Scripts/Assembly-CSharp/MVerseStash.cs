public class MVerseStash
{
	public bool isRecv;

	public float energy;

	public float ac;

	public float arg;

	public float liftic;

	private const float MAX_ENERGY = 100f;

	private const float MAX_AC = 100f;

	private const float MAX_ARG = 100f;

	private const float MAX_LIFTIC = 100f;

	private float lastSendTime;

	private const float SEND_TIME = 1f;

	public MVerseStash(bool isRecv)
	{
	}

	public void AddStashEvent(MVersePlayerPrefab.StashEvent frameEvent)
	{
	}

	public void Clear()
	{
	}

	private MVersePlayerPrefab.StashEvent GetEvent()
	{
		return default(MVersePlayerPrefab.StashEvent);
	}

	public void Update()
	{
	}

	public void AddEnergy(float val)
	{
	}

	public void AddAC(float val)
	{
	}

	public void AddArg(float val)
	{
	}

	public void AddLiftic(float val)
	{
	}
}
