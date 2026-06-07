using NBT.Tags;
using UnityEngine;

public class Cannon : UnitManager
{
	public enum FIRE_PRIORITY
	{
		CREEPER = 0,
		DIGITALIS = 1
	}

	private class ClonePack : IClonePack
	{
		private FIRE_PRIORITY firePriority;

		public ClonePack(FIRE_PRIORITY firePriority)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	private LOSIndicator losIndicator;

	public MeshColorSetter ammoIndicatorCube;

	public GameObject barrel;

	public GameObject smallBarrel;

	public GameObject foot0;

	public GameObject foot1;

	public GameObject foot2;

	public GameObject foot3;

	private float targetX;

	private float targetY;

	private int coolDown;

	private int recoil;

	private float gunHeat;

	private float angularVelocity;

	private int starvation;

	private int nearest_creeperX;

	private int nearest_creeperY;

	private float nearest_creeperDist;

	private int nearest_vineX;

	private int nearest_vineY;

	private float nearest_vineDist;

	private float val;

	private int lastMyRange;

	private FIRE_PRIORITY _firePriority;

	private int MYRANGE => 0;

	private float FIRE_COST => 0f;

	private int COOL_DOWN => 0;

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

	protected override void SetBodyShadow(bool state)
	{
	}

	public override void OnLanded()
	{
	}

	public void FireGameUpdate()
	{
	}

	private bool ChooseClosest(float d1, int dx1, int dy1, float d2, int dx2, int dy2, ref float tx, ref float ty)
	{
		return false;
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
