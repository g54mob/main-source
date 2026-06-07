using System;
using NBT.Tags;
using UnityEngine;

public class StraferMissile : UnitManager
{
	private enum STATE
	{
		LAUNCHING = 0,
		FLYING = 1
	}

	private STATE currentState;

	[NonSerialized]
	public float SPEED;

	[NonSerialized]
	public static float SHOT_FORCE;

	[NonSerialized]
	public int DAMAGE_COUNT;

	[NonSerialized]
	public int DAMAGE_MAXDIST;

	[NonSerialized]
	public int DAMAGE_AMT;

	private Vector2 targetCellCoords;

	private Vector3 lastPosition;

	private ParticleTrailManager trail;

	public static StraferMissile GetStraferMissile(Vector3 startPos, Vector2 targetCellCoords, bool enemy)
	{
		return null;
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void Init(Vector2 targetCellCoords)
	{
	}

	private float GetForwardTerrainHeight(Vector3 futureSpot)
	{
		return 0f;
	}

	public override void GameUpdate()
	{
	}

	private void Thrust()
	{
	}

	private void HitTarget()
	{
	}

	private void SetPosition(Vector3 pos)
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
