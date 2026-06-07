using System.Collections.Generic;
using UnityEngine;

public class StoragePad : UnitManager
{
	private const int PILE_WIDTH = 6;

	private const int PILE_LENGTH = 6;

	private const int PILE_HEIGHT = 5;

	private List<FabricatorWare> heldWares;

	private int lastHeldCount;

	private Vector3 heldWareStartPos;

	private float heldWareDist;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void GameUpdate()
	{
	}

	public override bool DispatchPacketWare(UnitManager u, int wareNum)
	{
		return false;
	}

	public override void ApplyPacket(Packet pm)
	{
	}

	private void UpdateWares()
	{
	}

	private int GetNewPadPos()
	{
		return 0;
	}

	private void PositionHeldWares()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}
}
