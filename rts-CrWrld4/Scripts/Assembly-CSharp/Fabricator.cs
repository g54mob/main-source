using System;
using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class Fabricator : UnitManager
{
	public class SectionWareType
	{
		public int sectionNum;

		public int wareNum;

		public int lastProducedTime;

		public bool sorted;

		public SectionWareType()
		{
		}

		public SectionWareType(int sectionNum, int wareNum, int lastProducedTime)
		{
		}

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	private int _wareNum;

	public int fabLevel;

	public FabricatorImage[] sectionImages;

	[NonSerialized]
	public HashSet<FabricatorWare> fabricatorWares;

	[NonSerialized]
	public List<FabricatorWare> producedWares;

	[NonSerialized]
	public int[] planWareTotals;

	[NonSerialized]
	public int[] storageWareTotals;

	private int MAX_STORAGE_COUNT;

	private const int sectionCount = 6;

	[NonSerialized]
	public SectionWareType[] sectionWareTypes;

	[NonSerialized]
	public int[] outputWares;

	private int[] inputWares;

	[NonSerialized]
	public int[] sectionWareCounts;

	private bool refreshWares;

	private const int PILE_WIDTH = 3;

	private const int PILE_LENGTH = 2;

	private const int PILE_HEIGHT = 5;

	private Vector3 producedWareStartPos;

	private float producedWareDist;

	private Vector3 sectionStartPos;

	private float sectionHorizontalDist;

	private float sectionVerticalDist;

	private Vector3 wareStartPos;

	private float wareDist;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public override void BuildComplete()
	{
	}

	public override void GameUpdate()
	{
	}

	public List<FabricatorWare> GetProducedWares()
	{
		return null;
	}

	public override bool DispatchPacketWare(UnitManager u, int wareNum)
	{
		return false;
	}

	public override void ApplyPacket(Packet pm)
	{
	}

	private FabricatorWare GetUnusedFabricatorWare(int wareType)
	{
		return null;
	}

	private void SyncFabricatorWaresToWaresHeld()
	{
	}

	public void SetSectionWareNum(int section, int wareNum)
	{
	}

	private void UpdateWares(bool canFab = true)
	{
	}

	private SectionWareType GetNextSectionToFab()
	{
		return null;
	}

	private bool RequirementsAreMet(SectionWareType swt)
	{
		return false;
	}

	private void Fabricate()
	{
	}

	public void DestroyProducedWares(int wareType, int amt)
	{
	}

	private int GetNewPadPos(int sectionNumber)
	{
		return 0;
	}

	private void PositionProducedWares()
	{
	}

	private void PositionWares()
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
