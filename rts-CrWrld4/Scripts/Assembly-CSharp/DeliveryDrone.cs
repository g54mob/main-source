using System;
using NBT.Tags;
using UnityEngine;

public class DeliveryDrone : UnitManager
{
	public enum STATE
	{
		DOCKED = 0,
		TAKINGOFF = 1,
		DELIVERING = 2,
		DROPPING = 3,
		RETURNING = 4,
		LANDING = 5
	}

	[NonSerialized]
	public DeliveryPad pad;

	private Pod pod;

	private Vector3 podCarryOffset;

	public static Vector3 dockOffset;

	[NonSerialized]
	public STATE state;

	private float altitude;

	private float verticalSpeed;

	private float flightSpeed;

	private Vector2 rememberedDeliveryTarget;

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

	public override void OnMouseOver()
	{
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

	private void SetState(STATE s)
	{
	}

	public void CancelRoute()
	{
	}

	public void RouteSet()
	{
	}

	public void Pickup(Pod pod)
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
