using System;
using NBT.Tags;
using UnityEngine;

public class Crystal : UnitManager
{
	private class ClonePack : IClonePack
	{
		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	[NonSerialized]
	private int amt;

	public GameObject top0;

	public GameObject top1;

	private Vector2 deployedPZPosition;

	private const float MAX_CHARGE = 1f;

	private float CHARGE_RATE;

	private float _charge;

	public float charge
	{
		get
		{
			return 0f;
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

	public override void GameUpdate()
	{
	}

	public void DeployPZ(bool deploy)
	{
	}

	private void DeployPZ(bool deploy, int gsx, int gsy)
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
