using System;
using NBT.Tags;
using UnityEngine;

public class FlyingUnitManager : UnitManager
{
	public enum State
	{
		Landed = 0,
		Pad_Descend = 1,
		Runway_Ascend = 2,
		Runway_Takeoff = 3,
		Attack = 4,
		Align = 5,
		Return = 6,
		Runway_Hold = 7,
		Runway_Land = 8,
		Runway_Taxi = 9,
		Runway_Descend = 10,
		Pad_Ascend = 11,
		Pad_Land = 12
	}

	public enum FlightMode
	{
		Single = 0,
		Dual = 1
	}

	private int targetGameSpaceX;

	private int targetGameSpaceY;

	private int targetGameSpaceX1;

	private int targetGameSpaceY1;

	private float targetX;

	private float targetY;

	private int safetyStraightOverrideCounter;

	[NonSerialized]
	public float safetyCounterTurn;

	[NonSerialized]
	public FlightMode flightMode;

	private int currentTarget;

	private int attackTarget;

	private bool returnImmediately;

	private int updownCounter;

	private float takeoffSpeed;

	private int turnQuell;

	[NonSerialized]
	public State currentState;

	[NonSerialized]
	public AircraftPadUnitManager aircraftPadUnitManager;

	[NonSerialized]
	public bool playTakeoffSound;

	protected float trailDisplacementAngle;

	protected float trailDisplacementDistance;

	protected float maxAltitudeMultiple;

	protected float dualAlignmentMultiple;

	[NonSerialized]
	private int OVERRIDE_STRAIGHT_TIME;

	[NonSerialized]
	protected float ATTACK_RADIUS;

	[NonSerialized]
	protected float ROT_SPEED;

	[NonSerialized]
	public float FLY_SPEED;

	[NonSerialized]
	public float VERTICAL_SPEED;

	[NonSerialized]
	public float MAX_ALTITUDE;

	[NonSerialized]
	public static float baseHeight;

	[NonSerialized]
	public static float runwayHeight;

	private int UPDOWN_TICKS;

	private float UPDOWN_DIST;

	private Vector3 MIN_FLY_HEIGHT;

	private Vector3 ONE_FLY_HEIGHT;

	private float RETURN_ALIGN_DIST;

	private GameObject indicationIndicator;

	public GameObject arrow;

	private bool playedTakeoffSound;

	private bool _indicated;

	private Runway occupiedRunway;

	private int arrowTimer;

	protected int wareToConsume;

	private float roll;

	private float coordZ
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool indicated
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override bool isBuilding
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

	public override UnitManager proxySelectObject => null;

	public bool occupyRunway
	{
		set
		{
		}
	}

	public virtual float ACTUAL_FLY_SPEED => 0f;

	public override void OnMouseOver()
	{
	}

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void ShowArrow()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	public void SetState(State state)
	{
	}

	public void ReturnImmediately()
	{
	}

	private bool AcquireAmmo()
	{
		return false;
	}

	protected virtual void CreateTrail(bool displace)
	{
	}

	protected virtual bool CanFireWeapons()
	{
		return false;
	}

	protected virtual void EnableWeapons(bool enabled)
	{
	}

	protected virtual bool AreWeaponsEnabled()
	{
		return false;
	}

	public float GetDualModeDistance()
	{
		return 0f;
	}

	protected float GetDistanceToTarget(int target)
	{
		return 0f;
	}

	private Vector2 GetExtendedSpot(int target, float distance)
	{
		return default(Vector2);
	}

	private void ChooseAlignSpot()
	{
	}

	private void ChooseHoldSpot()
	{
	}

	private bool PitchToAvoidTerrain()
	{
		return false;
	}

	private void LogPitch(string prefix)
	{
	}

	private bool WillHitTerrain(Vector3 start, Vector3 finish)
	{
		return false;
	}

	private float GetTerrainSquareHeight()
	{
		return 0f;
	}

	private bool Move()
	{
		return false;
	}

	private void UnRoll()
	{
	}

	private bool Rotate(bool baseState)
	{
		return false;
	}

	public virtual void Fly(int gameSpaceX, int gameSpaceY, int gameSpaceX1, int gameSpaceY1)
	{
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
