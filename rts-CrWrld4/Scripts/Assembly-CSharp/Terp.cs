using System;
using NBT.Tags;
using UnityEngine;

public class Terp : UnitManager
{
	private enum STATE
	{
		WAITING = 0,
		BUILDING_DRONE = 1
	}

	private GameObject terpDronePrefab;

	private STATE state;

	private TerpDrone terpDrone;

	private float droneBuiltAmt;

	private float DRONE_COST;

	private float BUILD_DRONE_RATE;

	private Vector3 DOCK_OFFSET;

	[NonSerialized]
	public bool closestFirst;

	public int MYRANGE => 0;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void BuildComplete()
	{
	}

	public void CreateMVerseUnit()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	private void SetState(STATE state)
	{
	}

	private void BuildDrone()
	{
	}

	public float GetDroneAmmo()
	{
		return 0f;
	}

	public float GetDroneMaxAmmo()
	{
		return 0f;
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
