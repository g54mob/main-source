public class WareProducerUnit : UnitManager
{
	private int WARE_PRODUCTION_INTERVAL;

	private int wareProductionCounter;

	protected bool _wareAvailable;

	private bool _connectable;

	protected bool wareAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool connectable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override void Awake()
	{
	}

	public override void GameUpdate()
	{
	}

	public override bool DispatchPacketWare(UnitManager u, int wareNum)
	{
		return false;
	}
}
