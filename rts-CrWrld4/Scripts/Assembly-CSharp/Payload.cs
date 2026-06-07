using System;
using NBT.Tags;
using UnityEngine;

public class Payload : UnitManager
{
	public enum PAYLOAD_TYPE
	{
		NONE = 0,
		DAMPER = 1,
		SINGULARITY = 2,
		RAIN = 3
	}

	public enum State
	{
		BUILDING = 0,
		DESCENDING = 1,
		ASCENDING = 2,
		MOVING0 = 3,
		MOVING1 = 4,
		MOVING2 = 5,
		MOVING3 = 6
	}

	[NonSerialized]
	public float baseHeight;

	private float MOVESPEED;

	private int UPDOWN_TICKS;

	private float UPDOWN_DIST;

	private int updownCounter;

	private State currentState;

	[NonSerialized]
	public PayloadPad payloadPadUnitManager;

	private RocketPad rocketPad;

	public static int[][] REQUIREMENTS;

	private PAYLOAD_TYPE _payloadType;

	private Vector3 moving0End;

	private Vector3 moving1End;

	private Vector3 moving2End;

	private Vector3 moving3End;

	public PAYLOAD_TYPE payloadType
	{
		get
		{
			return default(PAYLOAD_TYPE);
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

	private void SetMesh()
	{
	}

	public static Mesh GetMesh(PAYLOAD_TYPE payloadType)
	{
		return null;
	}

	public static string GetPayloadName(PAYLOAD_TYPE payloadType)
	{
		return null;
	}

	public override void GameUpdate()
	{
	}

	private void SetState(State state)
	{
	}

	private void Install()
	{
	}

	public bool IsAssigned()
	{
		return false;
	}

	public void AssignToRocketPad(RocketPad rocketPad)
	{
	}

	private void AssignRequirements()
	{
	}

	private float GetPercentComplete()
	{
		return 0f;
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
