using System;
using NBT.Tags;
using UnityEngine;

public class MortarShot : UnitManager
{
	[NonSerialized]
	public float SHOT_MOVE_SPEED;

	[NonSerialized]
	public int DAMAGE_COUNT;

	[NonSerialized]
	public int DAMAGE_MAXDIST;

	[NonSerialized]
	public int DAMAGE_AMT;

	[NonSerialized]
	private int DAMAGE_DIGITALIS_AMT;

	[NonSerialized]
	public static float SHOT_FORCE;

	[NonSerialized]
	public static float ENTRY_FORCE;

	private Vector3 targetPosition;

	private bool damageMapSet;

	private Vector3 velocity;

	private float gravity;

	private Vector3 startPosition;

	private int startUpdateCount;

	private float travelTime;

	private Vector3 lastPos;

	[NonSerialized]
	public bool mverseSimulated;

	private ParticleTrailManager trail;

	public static MortarShot GetShot(Vector3 startPos, bool enemy)
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

	public void SetTarget(Vector3 targetPosition, float LOS_INDIRECT_HEIGHT_OFFSET)
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
