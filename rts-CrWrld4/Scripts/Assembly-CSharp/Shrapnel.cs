using System;
using NBT.Tags;
using UnityEngine;

public class Shrapnel : UnitManager
{
	public enum PAYLOAD_TYPE
	{
		CREEPER = 0,
		STUN = 1
	}

	[NonSerialized]
	public MVerseShrapnel mverseController;

	private Vector3 lastPosition;

	private static Vector3 GRAVITY;

	private float MAX_SPEED;

	[NonSerialized]
	public PAYLOAD_TYPE payloadType;

	[NonSerialized]
	public int payloadAmt;

	private Vector3 rotateRate;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void InitPositionAndVelocity(Vector3 pos, Vector3 vel)
	{
	}

	public override void GameUpdate()
	{
	}

	private void Boom()
	{
	}

	private void OnDestroy()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void Damage(float damage)
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
