using System;
using NBT.Tags;
using UnityEngine;

public class Tower : UnitManager
{
	public const int PLACEMENT_RANGE = 11;

	public const float MIN_EFFICIENCY = 0.8f;

	public const float GRACE_DISTANCE = 16f;

	public const float HALF_DISTANCE = 50f;

	private const float PRODUCTION_RATE = 0.333334f;

	public CollectorZone collectorZone;

	public CollectorZoneIndicator collectorZoneIndicator;

	public GameObject towerIndicator;

	private int showRangeTime;

	private bool collects;

	[NonSerialized]
	public float efficiency;

	private bool lastEnabled;

	private int treeCount;

	private float treeBoost;

	private int lcellx;

	private int lcelly;

	public override string helpText => null;

	public void ShowRange()
	{
	}

	public void Refresh()
	{
	}

	public void RefreshLite()
	{
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	private void UpdateIndicator()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	public void NotifyOfScape(int cx, int cy, bool add)
	{
	}

	public void AllScapeRemoved()
	{
	}

	public void LateUpdate()
	{
	}

	public override void OnMouseOver()
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
