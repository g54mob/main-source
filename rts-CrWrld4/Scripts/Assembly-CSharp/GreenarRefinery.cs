using System;
using ClockStone;
using NBT.Tags;
using UnityEngine;

public class GreenarRefinery : UnitManager
{
	private enum STATE
	{
		WAITING = 0,
		BUILDING_DRONE = 1
	}

	private GameObject greenarDronePrefab;

	private STATE state;

	private GreenarDrone greenarDrone;

	private float droneBuiltAmt;

	private float DRONE_COST;

	private float BUILD_DRONE_RATE;

	private Vector3 DOCK_OFFSET;

	private int PROCESS_INTERVAL;

	public const int MIN_DESIRED_CRYSTAL = 30;

	public const int GREENAR_WORTH = 12;

	public GameObject rangeIndicator;

	public GameObject greenarCube;

	public ParticleSystem exhaust;

	private int greenarCrystal;

	private int processCount;

	[NonSerialized]
	public AudioObject sound;

	private int _greenar;

	protected bool _wareAvailable;

	public int greenar
	{
		get
		{
			return 0;
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

	public override string officialName => null;

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

	private void HandleSound()
	{
	}

	public override void GameUpdate()
	{
	}

	public override bool DispatchPacketWare(UnitManager u, int wareNum)
	{
		return false;
	}

	public bool WantsGreenar()
	{
		return false;
	}

	public Vector3 GetDockPos()
	{
		return default(Vector3);
	}

	private void SetState(STATE state)
	{
	}

	private void BuildDrone()
	{
	}

	public void AddGreenar()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void ReadData(Tag data)
	{
	}

	public override void ReadDataLate()
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
