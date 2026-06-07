using NBT.Tags;
using UnityEngine;

public class MissileLauncher : UnitManager
{
	public enum STATE
	{
		ACQUIRING = 0,
		FIRING = 1
	}

	public GameObject barrel;

	private int coolDown;

	private float angularVelocity;

	private int starvation;

	private STATE currentState;

	private Vector3 targetPos;

	public MissileLauncherRangeIndicator rangeIndicator;

	public GameObject missile0;

	public GameObject missile1;

	private bool _missile0Available;

	private bool _missile1Available;

	private bool missile0Available
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool missile1Available
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

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

	public int MYRANGE => 0;

	private float MISSILE_COST => 0f;

	private int COOL_DOWN => 0;

	private float ROT_SPEED => 0f;

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

	private void SetVisibleMissiles()
	{
	}

	public static UnitManager GetNearestTarget(float RNG, Vector3 startPos, bool targetSpecials, bool targetSpores, bool targetAirSacs)
	{
		return null;
	}

	public void FireGameUpdate()
	{
	}

	private bool IsMissileAvailable()
	{
		return false;
	}

	private bool Rotate(bool baseState)
	{
		return false;
	}

	private void Fire(UnitManager unit)
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
