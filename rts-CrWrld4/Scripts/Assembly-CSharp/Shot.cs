using System;
using NBT.Tags;
using UnityEngine;

public class Shot : UnitManager
{
	[NonSerialized]
	public new static float MOVE_SPEED;

	[NonSerialized]
	public int DAMAGE_COUNT;

	[NonSerialized]
	public int DAMAGE_MAXDIST;

	[NonSerialized]
	public int DAMAGE_AMT;

	[NonSerialized]
	public int DAMAGE_DIGITALIS_AMT;

	[NonSerialized]
	public float BLOB_DAMAGE;

	[NonSerialized]
	public static float SHOT_FORCE;

	[NonSerialized]
	public Vector3 targetPosition;

	private ParticleTrailManager trail;

	[NonSerialized]
	public bool mverseSimulated;

	public static Shot GetShot(Vector3 startPos, bool enemy)
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

	private UnitManager GetNearestBlob(int cx, int cy)
	{
		return null;
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
