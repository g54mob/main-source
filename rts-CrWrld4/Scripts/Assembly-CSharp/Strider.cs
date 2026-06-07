using System;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class Strider : UnitManager
{
	public enum TARGET_BEHAVIOR
	{
		RANDOM = 0,
		STRUCTURE = 1,
		LOCATION = 2
	}

	[NonSerialized]
	public MVerseStrider mverseController;

	[NonSerialized]
	public TARGET_BEHAVIOR targetBehavior;

	[NonSerialized]
	public Vector2 targetBehaviorLocation;

	private float yVelocity;

	private Vector3 angleVelocity;

	private float DAMP_UP;

	private float DAMP_DOWN;

	private float MAX_UP_VEL;

	private float MAX_DOWN_VEL;

	private float UP_FORCE;

	private float DOWN_FORCE;

	private float ANGLE_FORCE;

	private float LEVEL_ANGLE_FORCE;

	private float velocityMod;

	[NonSerialized]
	public int payload;

	[NonSerialized]
	public int lifetime;

	private bool initted;

	private Vector3 lastPosition;

	private Vector2 target;

	private float MAX_MOVE_SPEED;

	private float MAX_ROTATE_SPEED;

	private float currentAngle;

	private int turnCount;

	private int LAUNCH_TIME;

	public override void Awake()
	{
	}

	public void InitClient(TARGET_BEHAVIOR targetBehavior, Vector2 targetBehaviorLocation, int payload)
	{
	}

	public void Init(TARGET_BEHAVIOR targetBehavior, Vector2 targetBehaviorLocation, int payload)
	{
	}

	public override void SetUnitSettings(OrderedDictionary2<string, RplCore.Data> initParams)
	{
	}

	public override OrderedDictionary2<string, RplCore.Data> GetUnitSettings()
	{
		return null;
	}

	public override void Start()
	{
	}

	public override void GameUpdate()
	{
	}

	private void MoveTowards()
	{
	}

	private void FindNewTarget()
	{
	}

	public float GetCreeperHeight(out Vector3 normal)
	{
		normal = default(Vector3);
		return 0f;
	}

	public override void Damage(float damage)
	{
	}

	private Shrapnel CreateShard()
	{
		return null;
	}

	private void Boom()
	{
	}

	private void OnDestroy()
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
