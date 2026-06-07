using System;
using NBT.Tags;
using UnityEngine;

public class ACShot : UnitManager
{
	[NonSerialized]
	public new float MOVE_SPEED;

	public static int PAYLOAD;

	[NonSerialized]
	public static float SHOT_FORCE;

	[NonSerialized]
	public Vector3 targetPosition;

	public ParticleTrailManager trail;

	[NonSerialized]
	public bool mverseSimulated;

	public static ACShot GetShot(Vector3 startPos, bool enemy)
	{
		return null;
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void Init()
	{
	}

	public override void GameUpdate()
	{
	}

	private void HitTarget()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override string GetDataName()
	{
		return null;
	}

	public override void ReadData(Tag data)
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
