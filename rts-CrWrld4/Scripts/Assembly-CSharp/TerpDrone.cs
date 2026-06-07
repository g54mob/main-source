using System;
using NBT.Tags;
using UnityEngine;

public class TerpDrone : UnitManager
{
	public enum STATE
	{
		DOCKED = 0,
		FLYING_TO_TARGET = 1,
		TERRAFORMING = 2,
		FLYING_HOME = 3,
		LANDING = 4,
		CRASHING = 5,
		EXCAVATING = 6
	}

	public LineRenderer beam;

	public LineRenderer excavateBeam;

	private Vector3 DOCK_OFFSET;

	private float FIRE_COST;

	private float FLY_HEIGHT;

	private float FLY_SPEED;

	private float _FIRE_TIME;

	private float _EXCAVATE_SPEED;

	[NonSerialized]
	public Terp terp;

	private STATE state;

	private int firingTargetX;

	private int firingTargetY;

	private ERN ernToExcavate;

	private float FIRE_TIME => 0f;

	private float EXCAVATE_SPEED => 0f;

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

	private bool AcquireAmmo()
	{
		return false;
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

	private void StopExcavating()
	{
	}

	private void ModTerrain(int gsx, int gsy)
	{
	}

	public static void ModTerrain(int gsx, int gsy, byte currentLevel, int targetLevel, bool ignoreMVerse)
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

	public static void FindDigSite(int gameSpaceX, int gameSpaceY, int RANGE, bool closest, bool checkFireTargets, bool checkCreeper, bool checkAC, bool checkFog, out int chosenX, out int chosenY)
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
