using System;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class AirSac : UnitManager
{
	public enum TARGET_BEHAVIOR
	{
		RANDOM = 0,
		STRUCTURE = 1,
		LOCATION = 2
	}

	private enum STATE
	{
		RISING = 0,
		MOVING = 1,
		DROPPING = 2,
		TOSSING = 3
	}

	[NonSerialized]
	public MVerseAirSac mverseController;

	public GameObject arm0;

	public GameObject arm1;

	[NonSerialized]
	public TARGET_BEHAVIOR targetBehavior;

	[NonSerialized]
	public Vector2 targetBehaviorLocation;

	[NonSerialized]
	public int payload;

	private STATE state;

	private int spawnInterval;

	private AirSacBubble bubble0;

	private AirSacBubble bubble1;

	private int riseCounter;

	private int tossCounter;

	private float currentSpeed;

	private float ACCELERATION;

	private float SPEED;

	private float ROTATE_SPEED;

	private float verticalSpeed;

	private float VERTICAL_ACCELERATION;

	private Vector3 targetPosition;

	private float baseTargetHeight;

	private float targetHeight;

	private bool initted;

	private Vector3 spawnOffset;

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

	private void FindNewTarget()
	{
	}

	public void SetTarget(Vector2 target)
	{
	}

	private bool CollisionDetection(float distance)
	{
		return false;
	}

	private int GetChainLength(AirSacBubble b)
	{
		return 0;
	}

	public override void Update()
	{
	}

	public int GetBubbleCount()
	{
		return 0;
	}

	public override void GameUpdate()
	{
	}

	private void TossChain(AirSacBubble root)
	{
	}

	private void PositionArms()
	{
	}

	private void MakeBubbles()
	{
	}

	private void MoveTowards()
	{
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

	public override void Damage(float damage)
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
