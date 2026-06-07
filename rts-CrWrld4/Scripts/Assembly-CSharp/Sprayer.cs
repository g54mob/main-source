using System;
using NBT.Tags;
using UnityEngine;

public class Sprayer : UnitManager
{
	public enum FIRE_PRIORITY
	{
		CREEPER = 0
	}

	private class ClonePack : IClonePack
	{
		private bool alwaysOn;

		private bool collectionFieldEnabled;

		private bool dispatchOre;

		public ClonePack(bool alwaysOn, bool collectionFieldEnabled, bool dispatchOre)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	private LOSIndicator losIndicator;

	public GameObject barrel;

	public GameObject smallBarrel;

	private float targetX;

	private float targetY;

	private int coolDown;

	private int recoil;

	private int dispatchPacketCoolDown;

	private float gunHeat;

	private float angularVelocity;

	private int starvation;

	[NonSerialized]
	public bool alwaysOn;

	[NonSerialized]
	public bool collectionFieldEnabled;

	[NonSerialized]
	public bool dispatchOre;

	protected bool _wareAvailable;

	private float tank;

	private float MAX_TANK;

	private int lastMyRange;

	private FIRE_PRIORITY _firePriority;

	private int nearest_creeperX;

	private int nearest_creeperY;

	private float nearest_creeperDist;

	public int STRENGTH;

	private bool deployed;

	private int FIELD_RANGE;

	protected bool wareAvailable
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

	private int DISPATCH_PACKET_COOL_DOWN => 0;

	private float ROT_SPEED => 0f;

	public FIRE_PRIORITY firePriority
	{
		get
		{
			return default(FIRE_PRIORITY);
		}
		set
		{
		}
	}

	public override IClonePack GetClonePack()
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

	public override bool DispatchPacketWare(UnitManager u, int wareNum)
	{
		return false;
	}

	protected override void SetBodyShadow(bool state)
	{
	}

	public override void OnLanded()
	{
	}

	public void FireGameUpdate()
	{
	}

	private bool Rotate(bool baseState)
	{
		return false;
	}

	private void Fire(float targetX, float targetY)
	{
	}

	private void FindEnemiesOnLine(int x0, int y0, float angle, int maxRange, int hardTargetX, int hardTargetY, out int gsx, out int gsy)
	{
		gsx = default(int);
		gsy = default(int);
	}

	private void FindNearestEnemies(int gameSpaceX, int gameSpaceY)
	{
	}

	public override void RefreshLOSCache()
	{
	}

	private void DeployField(bool deploy)
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
