using System;
using System.Collections.Generic;
using ClockStone;
using NBT.Tags;
using UnityEngine;

public class Nullifier : UnitManager
{
	private enum STATE
	{
		CHARGING = 0,
		FIRING = 1,
		FINISHED = 2
	}

	public class Beam
	{
		public GameObject beam;

		public GameObject beamStart;

		public GameObject beamEnd;

		public bool fired;

		public bool destroyed;

		public void Destroy()
		{
		}
	}

	public GameObject post;

	private float minPostY;

	private float maxPostY;

	private AudioObject armingSound;

	private AudioObject firingSound;

	private STATE state;

	public Dictionary<UnitManager, Beam> beams;

	[NonSerialized]
	public float overloadTank;

	private bool _overloaded;

	public static int overloadDestroyAmt;

	public bool Overloaded
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private int MYRANGE => 0;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void BuildComplete()
	{
	}

	public void CreateMVerseUnit()
	{
	}

	public override void GameUpdate()
	{
	}

	public static List<UnitManager> GetNullifierTargets(int gsx, int gsy, int range)
	{
		return null;
	}

	private static void CheckNullifierTarget(UnitManager em, int gsx, int gsy, int range, ref List<UnitManager> unitsToDestroy, UnitData.UnitConstants uc)
	{
	}

	private static bool InRange(UnitManager em, int gsx, int gsy, int range)
	{
		return false;
	}

	private bool InRange(UnitManager em)
	{
		return false;
	}

	private void Fire()
	{
	}

	private void FireAtUnit(UnitManager unit)
	{
	}

	public static void FireAtUnit(Dictionary<UnitManager, Beam> beams, Vector3 sp, bool overloaded, float ammo, UnitManager unit)
	{
	}

	private void OverloadDetonate()
	{
	}

	public override void Update()
	{
	}

	private void HandleSound()
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
