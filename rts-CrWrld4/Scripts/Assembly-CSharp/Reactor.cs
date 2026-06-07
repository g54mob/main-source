using NBT.Tags;
using UnityEngine;

public class Reactor : UnitManager
{
	private class ClonePack : IClonePack
	{
		private bool resourceMode;

		public ClonePack(bool resourceMode)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	private const float ENERGY_PRODUCTION_RATE = 1f;

	private int BASE_WARE_PRODUCTION_INTERVAL;

	public Transform barrel;

	public GameObject energyPlate;

	public GameObject orePlate;

	public ReactorCoverage reactorCoverage;

	public ParticleSystem exhaust;

	private int hideCounter;

	private bool skipDuringLoad;

	private bool _resourceMode;

	protected int wareProductionCounter;

	protected bool _wareAvailable;

	private int barrelPos;

	private int lastBarrelPos;

	public override string officialName => null;

	public bool resourceMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

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

	public override bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override IClonePack GetClonePack()
	{
		return null;
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void BuildComplete()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	public void CanProduce(int interval)
	{
	}

	public int GetWareType()
	{
		return 0;
	}

	public override bool DispatchPacketWare(UnitManager u, int wareNum)
	{
		return false;
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void ReadData(Tag data)
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
