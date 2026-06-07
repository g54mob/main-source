using System;
using NBT.Tags;
using UnityEngine;

public class Sniper : UnitManager
{
	public enum STATE
	{
		ACQUIRING = 0,
		FIRING = 1
	}

	private class ClonePack : IClonePack
	{
		private bool targetSpecials;

		private bool targetBlobs;

		private bool targetSkimmers;

		private bool targetForbs;

		private bool targetGlops;

		private bool targetEggs;

		public ClonePack(bool targetSpecials, bool targetBlobs, bool targetSkimmers, bool targetForbs, bool targetGlops, bool targetEggs)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	[NonSerialized]
	public bool targetSpecials;

	[NonSerialized]
	public bool targetBlobs;

	[NonSerialized]
	public bool targetSkimmers;

	[NonSerialized]
	public bool targetForbs;

	[NonSerialized]
	public bool targetGlops;

	[NonSerialized]
	public bool targetEggs;

	public GameObject barrel;

	private int coolDown;

	private int recoil;

	private float angularVelocity;

	private int starvation;

	private STATE currentState;

	private Vector3 targetPos;

	public Transform sniperSlide;

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

	private int MYRANGE => 0;

	private float FIRE_COST => 0f;

	private int COOL_DOWN => 0;

	private float ROT_SPEED => 0f;

	public override IClonePack GetClonePack()
	{
		return null;
	}

	public static SniperShot CreateSniperShot()
	{
		return null;
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
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

	public void FireGameUpdate()
	{
	}

	private static bool HasLOS(UnitManager um, Vector3 startPos)
	{
		return false;
	}

	public static UnitManager GetNearestTarget(float RNG, Vector3 startPos, bool targetSpecials, bool targetBlobs, bool targetSkimmers, bool targetForbs, bool targetGlops, bool targetEggs)
	{
		return null;
	}

	private bool Rotate(bool baseState)
	{
		return false;
	}

	private void Fire(UnitManager target)
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
