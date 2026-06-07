using System;
using NBT.Tags;
using UnityEngine;

public class CytocreepLauncher : UnitManager
{
	public enum TARGET_BEHAVIOR
	{
		RANDOM = 0,
		STRUCTURE = 1
	}

	[NonSerialized]
	public int startTime;

	[NonSerialized]
	public int finishTime;

	[NonSerialized]
	public int productionInterval;

	[NonSerialized]
	public TARGET_BEHAVIOR targetBehavior;

	[NonSerialized]
	public int payload;

	[NonSerialized]
	public int count;

	private Vector3 spawnOffset;

	public override void Awake()
	{
	}

	public override void GameUpdate()
	{
	}

	private void CreateCytocreeps(TARGET_BEHAVIOR targetBehavior, int payload, int count)
	{
	}

	private Vector2 FindNewTarget(TARGET_BEHAVIOR targetBehavior)
	{
		return default(Vector2);
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
