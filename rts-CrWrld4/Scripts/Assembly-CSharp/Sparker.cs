using System;
using NBT.Tags;
using UnityEngine;

public class Sparker : UnitManager
{
	public GameObject shaft;

	public GameObject piston0;

	public GameObject piston1;

	public GameObject rod0;

	public GameObject rod1;

	[NonSerialized]
	public int PRODUCTION_INTERVAL;

	private int MAX_ROTATE_SPEED;

	private int MAX_WORK_SPEED;

	private int workSpeed;

	private bool consumedAmmo;

	protected int productionCounter;

	protected bool _wareAvailable;

	private float _shaftRotation;

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

	private float shaftRotation
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

	public override void GameUpdate()
	{
	}

	public override bool DispatchPacketWare(UnitManager u, int wareNum)
	{
		return false;
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
