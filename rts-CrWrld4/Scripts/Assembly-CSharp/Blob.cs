using System;
using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class Blob : UnitManager
{
	public enum TARGET_BEHAVIOR
	{
		RANDOM = 0,
		STRUCTURE = 1,
		LOCATION = 2
	}

	[NonSerialized]
	public MVerseBlob mverseController;

	[NonSerialized]
	public TARGET_BEHAVIOR targetBehavior;

	[NonSerialized]
	public Vector2 targetBehaviorLocation;

	private float MAX_MOVE_SPEED;

	private Vector2 finalMoveTarget;

	private Mesh mesh;

	private Vector3 lastPosition;

	[NonSerialized]
	public int payload;

	[NonSerialized]
	public int lifetime;

	[NonSerialized]
	public bool builder;

	[NonSerialized]
	public AirSacBubble egg;

	[NonSerialized]
	public bool carryEgg;

	private bool initted;

	protected Vector2 deployedFlowPosition;

	private Vector2 moveTarget;

	private List<int> moveTargetCache;

	public override void Awake()
	{
	}

	public void InitClient(TARGET_BEHAVIOR targetBehavior, Vector2 targetBehaviorLocation, int payload)
	{
	}

	public void Init(TARGET_BEHAVIOR targetBehavior, Vector2 targetBehaviorLocation, int payload, bool carryEgg)
	{
	}

	public override void SetUnitSettings(OrderedDictionary2<string, RplCore.Data> initParams)
	{
	}

	public override OrderedDictionary2<string, RplCore.Data> GetUnitSettings()
	{
		return null;
	}

	private void Setup()
	{
	}

	public Vector3 GetVelocity()
	{
		return default(Vector3);
	}

	public override void GameUpdate()
	{
	}

	private void AcquireEgg()
	{
	}

	private void FindNewTarget()
	{
	}

	public void SetTarget(Vector2 target)
	{
	}

	public void DeployFlow(bool deploy)
	{
	}

	private void DeployFlow(bool deploy, int gsx, int gsy)
	{
	}

	private void MoveTowards()
	{
	}

	private void CalculateMoveTarget()
	{
	}

	private Vector2 GetCellInActionCell(int actionCell)
	{
		return default(Vector2);
	}

	private void Arrived()
	{
	}

	private void DepositCreeper()
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
