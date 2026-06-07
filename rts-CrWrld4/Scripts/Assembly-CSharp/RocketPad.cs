using System;
using NBT.Tags;
using UnityEngine;

public class RocketPad : UnitManager
{
	private float RAMP_ROTATE_RATE;

	private int QUELL_TIME;

	[NonSerialized]
	public Rocket rocket;

	public GameObject lights;

	public GameObject ramp;

	[NonSerialized]
	public bool[] payloadsHeld;

	private int rocketBuildQuell;

	private int payloadRequestQuell;

	private bool lowerRamp;

	private bool raiseRamp;

	[NonSerialized]
	public bool autoLaunch;

	[NonSerialized]
	public bool launchASAP;

	public ParticleSystem exhaust;

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

	public override void GameUpdate()
	{
	}

	public bool IsRocketFulfilled()
	{
		return false;
	}

	public void Launch()
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
