using System;
using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class PayloadPad : UnitManager
{
	public GameObject totemPanelPrefab;

	private TotemPane totemPane;

	[NonSerialized]
	public Payload payload;

	[NonSerialized]
	private Payload.PAYLOAD_TYPE _payloadTypeToMake;

	[NonSerialized]
	public bool autoMake;

	[NonSerialized]
	public bool oneTimeMake;

	private int hideCounter;

	public Payload.PAYLOAD_TYPE payloadTypeToMake
	{
		get
		{
			return default(Payload.PAYLOAD_TYPE);
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

	public override void Update()
	{
	}

	public override void OnMouseOver()
	{
	}

	public override void GameUpdate()
	{
	}

	public void CreatePayload()
	{
	}

	private bool NeedsWares()
	{
		return false;
	}

	public bool IsAdjacentToRocketPad(RocketPad rpad)
	{
		return false;
	}

	public List<RocketPad> FindRocketPads()
	{
		return null;
	}

	public static RocketPad FindRocketPad(int cellX, int cellY)
	{
		return null;
	}

	private static RocketPad FindRocketPadAtSpot(int cellX, int cellY)
	{
		return null;
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
