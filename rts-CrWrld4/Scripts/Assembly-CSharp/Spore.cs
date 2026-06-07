using System;
using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class Spore : UnitManager
{
	public enum TARGET_BEHAVIOR
	{
		RANDOM = 0,
		STRUCTURE = 1,
		LOCATION = 2
	}

	[NonSerialized]
	public MVerseSpore mverseController;

	[NonSerialized]
	public TARGET_BEHAVIOR targetBehavior;

	[NonSerialized]
	public Vector2 targetBehaviorLocation;

	private const float MAX_HEIGHT = 60f;

	[NonSerialized]
	public Vector3 targetPosition;

	private Vector3 velocity;

	private float gravity;

	[NonSerialized]
	public Vector3 startPosition;

	[NonSerialized]
	public int startUpdateCount;

	private float travelTime;

	private Vector3 lastPos;

	private float velocityMod;

	private bool initted;

	[NonSerialized]
	public int payload;

	public GameObject sporeTrail;

	public LineRenderer pathLine;

	private List<Vector3> pathPoints;

	private int pathLineCurrentPos;

	private bool drawingPath;

	private float SPEED;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void InitClient(TARGET_BEHAVIOR targetBehavior, Vector2 targetBehaviorLocation, int payload, Vector2 targetLocation, Vector3 startPosition, int updateCount, int startUpdateCount)
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

	public override void Update()
	{
	}

	private void DrawPath()
	{
	}

	private void CreatePathLine()
	{
	}

	public void SetSporeHidden()
	{
	}

	private void FindNewTarget()
	{
	}

	public void SetTarget(Vector2 target)
	{
	}

	public void SetTarget(Vector2 target, Vector3 startPosition, int startUpdateCount)
	{
	}

	public override void GameUpdate()
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

	public override TagCompound WriteData()
	{
		return null;
	}
}
