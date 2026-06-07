using System;
using NBT.Tags;
using UnityEngine;

public class AircraftPadUnitManager : UnitManager
{
	protected class ClonePack : IClonePack
	{
		private bool autoLaunch;

		public ClonePack(bool autoLaunch)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	public GameObject indicator;

	public GameObject arrow;

	[NonSerialized]
	public AircraftMoveTarget tempAircraftMoveTarget;

	[NonSerialized]
	public AircraftMoveTarget aircraftMoveTarget;

	[NonSerialized]
	public FlyingUnitManager flyingUnit;

	[NonSerialized]
	public Runway runway;

	[NonSerialized]
	public GameObject aircraftPrefab;

	[NonSerialized]
	public bool autoLaunch;

	private int arrowTimer;

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

	public override void Awake()
	{
	}

	public override IClonePack GetClonePack()
	{
		return null;
	}

	public override void Start()
	{
	}

	private void ConnectToRunway()
	{
	}

	private void CreateAircraft()
	{
	}

	public override void Update()
	{
	}

	public override void OnMouseOver()
	{
	}

	public void ShowArrow()
	{
	}

	public override void GameUpdate()
	{
	}

	public static Runway FindRunway(int cellX, int cellY)
	{
		return null;
	}

	private static Runway FindRunwayAtSpot(int cellX, int cellY)
	{
		return null;
	}

	public void DeployNewTarget()
	{
	}

	public void Relaunch(bool suppressLaunchSound = true)
	{
	}

	public void ReturnImmediately()
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
