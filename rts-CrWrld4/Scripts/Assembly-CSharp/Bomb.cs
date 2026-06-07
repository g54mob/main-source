using System;
using ClockStone;
using NBT.Tags;
using UnityEngine;

public class Bomb : UnitManager
{
	[NonSerialized]
	public static float SHOT_FORCE;

	[NonSerialized]
	public int DAMAGE_COUNT;

	public int DAMAGE_MAXDIST;

	[NonSerialized]
	public int DAMAGE_AMT;

	private int DAMAGE_DIGITALIS_AMT;

	private Vector2 targetCellCoords;

	private float ACCELERATION;

	private float MAX_SPEED;

	private Vector3 lastPosition;

	private float currentSpeed;

	private ParticleTrailManager trail;

	private AudioObject droppingSound;

	public static Bomb GetBomb(Vector3 startPos, Vector2 targetCellCoords, bool enemy)
	{
		return null;
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void Update()
	{
	}

	public void Init(Vector2 targetCellCoords)
	{
	}

	public override void GameUpdate()
	{
	}

	private void HandleSound()
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
