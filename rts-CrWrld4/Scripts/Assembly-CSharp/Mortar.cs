using NBT.Tags;
using UnityEngine;

public class Mortar : UnitManager
{
	public enum FIRE_PRIORITY
	{
		BOTH = 0,
		CREEPER = 1,
		DIGITALIS = 2
	}

	public MeshColorSetter ammoIndicatorCube;

	public GameObject aimContainer;

	public GameObject barrel;

	public GameObject foot0;

	public GameObject foot1;

	public GameObject foot2;

	public GameObject foot3;

	private float targetX;

	private float targetY;

	private int coolDown;

	private float gunHeat;

	private float angularVelocity;

	private int starvation;

	private int lastMyRange;

	private FIRE_PRIORITY _firePriority;

	private int MYRANGE => 0;

	private float FIRE_COST => 0f;

	private int COOL_DOWN => 0;

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

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void CreateMVerseUnit()
	{
	}

	public override void OnLanded()
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

	public void FireGameUpdate()
	{
	}

	private void Fire(float targetX, float targetY)
	{
	}

	private void FindDeepestCreeper(int gameSpaceX, int gameSpaceY, out int chosenX, out int chosenY)
	{
		chosenX = default(int);
		chosenY = default(int);
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
