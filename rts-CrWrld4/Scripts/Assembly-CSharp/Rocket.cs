using System;
using ClockStone;
using NBT.Tags;
using UnityEngine;

public class Rocket : UnitManager
{
	private float ACCELERATION;

	private float MAX_SPEED;

	private float MAX_ALTITUDE;

	public GameObject gas;

	public GameObject exhaust;

	[NonSerialized]
	public Payload.PAYLOAD_TYPE[] payloads;

	private bool launched;

	private float speed;

	private int launchDelayCount;

	[NonSerialized]
	public AudioObject sound;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void CreateMVerseUnit()
	{
	}

	public override void Update()
	{
	}

	protected override void SetUnitMaterial()
	{
	}

	public override void GameUpdate()
	{
	}

	private void InsertPayloadsIntoOrbit()
	{
	}

	public void Launch()
	{
	}

	private void HandleSound()
	{
	}

	public override void DestroyUnit(bool suppressEffects, bool userInitiated, bool doNotLog)
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
