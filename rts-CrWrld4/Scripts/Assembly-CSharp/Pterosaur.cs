using System;
using NBT.Tags;
using UnityEngine;

public class Pterosaur : UnitManager
{
	public enum State
	{
		Landed = 0,
		TakingOff = 1,
		Landing = 2,
		LandingFinal = 3,
		Flying = 4,
		FlyToLand = 5
	}

	protected float ROT_SPEED;

	protected float FLY_SPEED;

	private int OVERRIDE_STRAIGHT_TIME;

	private Vector3 MIN_FLY_HEIGHT;

	private int MYRANGE;

	private int LANDINGRANGE;

	private Animator animator;

	private static int takeoffAnimationState;

	private static int landingAnimationState;

	private static int flyingAnimationState;

	private static int idleAnimationState;

	[NonSerialized]
	public PterosaurNest pterosaurNest;

	[NonSerialized]
	public State currentState;

	private float targetX;

	private float targetY;

	private int turnQuell;

	private int safetyStraightOverrideCounter;

	private float safetyCounterTurn;

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

	public override void Awake()
	{
	}

	public void Init(PterosaurNest nest)
	{
	}

	public override void Start()
	{
	}

	public override void GameUpdate()
	{
	}

	private void SetState(State state)
	{
	}

	private bool GetLandingSpot(out float chosenX, out float chosenY)
	{
		chosenX = default(float);
		chosenY = default(float);
		return false;
	}

	private bool CheckForDanger(int x, int y, int R1, int R2)
	{
		return false;
	}

	private bool CheckForOthers(int x, int y)
	{
		return false;
	}

	private void GetNewTarget()
	{
	}

	private void GetRandomTarget()
	{
	}

	private bool GetTargetTree(out float chosenX, out float chosenY)
	{
		chosenX = default(float);
		chosenY = default(float);
		return false;
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

	private bool PitchToAvoidTerrain()
	{
		return false;
	}

	private bool WillHitTerrain(Vector3 start, Vector3 finish)
	{
		return false;
	}

	private float GetTerrainSquareHeight()
	{
		return 0f;
	}

	private void Boom()
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
