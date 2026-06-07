using System;
using NBT.Tags;
using UnityEngine;

public class GreenarDrone : UnitManager
{
	public enum STATE
	{
		DOCKED = 0,
		FLYING_TO_TARGET = 1,
		COLLECTING = 2,
		PULLING_IN = 3,
		FLYING_HOME = 4,
		LANDING = 5,
		CRASHING = 6
	}

	public LineRenderer[] beams;

	public GameObject pullObjectPrefab;

	private float FIRE_COST;

	private float FIRE_TIME;

	private float FLY_HEIGHT;

	private float FLY_SPEED;

	private float PULL_SPEED;

	[NonSerialized]
	public bool closestFirst;

	[NonSerialized]
	public GreenarRefinery greenarRefinery;

	private STATE state;

	private int firingTargetX;

	private int firingTargetY;

	private GameObject pullObject;

	[NonSerialized]
	public bool hasGreenar;

	public float ACTUAL_FLY_SPEED => 0f;

	public override bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override void Awake()
	{
	}

	private bool AcquireNewTarget()
	{
		return false;
	}

	public bool AreBeamsActive()
	{
		return false;
	}

	public void SetBeamsActive(bool val)
	{
	}

	public void SetBeamsWidthMultiplier(float val)
	{
	}

	public void SetBeamsTargetPos(Vector3 pos)
	{
	}

	private Vector3 GetBeamStart(int beam)
	{
		return default(Vector3);
	}

	public void CreateMVerseUnit()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	private void ResetTowers(int gsx, int gsy)
	{
	}

	private float GetCreeperHeight()
	{
		return 0f;
	}

	private void SetState(STATE state)
	{
	}

	private void AddFireTarget(int gsx, int gsy)
	{
	}

	private void RemoveFireTarget()
	{
	}

	private ERN FindBuriedERN(int gameSpaceX, int gameSpaceY)
	{
		return null;
	}

	private void FindDigSite(int gameSpaceX, int gameSpaceY, out int chosenX, out int chosenY)
	{
		chosenX = default(int);
		chosenY = default(int);
	}

	public override void DestroyUnit(bool suppressEffects)
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
