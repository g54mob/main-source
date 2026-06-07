using System;
using NBT.Tags;
using UnityEngine;

public class Runway : UnitManager
{
	[NonSerialized]
	public FlyingUnitManager occupyingUnit;

	public Vector3 padPos => default(Vector3);

	public Vector3 takeoffLandingPos => default(Vector3);

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
