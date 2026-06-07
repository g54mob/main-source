using System;
using NBT.Tags;
using UnityEngine;

public class Missile : UnitManager
{
	private enum STATE
	{
		LAUNCHING = 0,
		FLYING = 1,
		CLIMBING = 2,
		FALLING = 3
	}

	private STATE currentState;

	[NonSerialized]
	public float SPEED;

	[NonSerialized]
	public float TURN_SPEED;

	[NonSerialized]
	public float HIT_DISTANCE;

	[NonSerialized]
	public static float SHOT_FORCE;

	public const float DAMAGE_AMT = 0.6f;

	private Vector3 lastPosition;

	private ParticleTrailManager trail;

	[NonSerialized]
	public bool mverseSimulated;

	private UnitManager _targetUnit;

	private bool climbing;

	private bool falling;

	private Vector3 fallDelta;

	private float FALL_ACCELERATION;

	public UnitManager targetUnit
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public static Missile GetMissile(Vector3 startPos, bool enemy)
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

	private void Climb()
	{
	}

	private void Fall()
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

	public override void ReadDataLate()
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
