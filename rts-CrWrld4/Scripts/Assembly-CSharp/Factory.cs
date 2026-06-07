using System;
using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class Factory : UnitManager
{
	public class WareToMake
	{
		public bool shouldProduce;

		public WaresManager.WareDef wareDef;

		private int _wareToMake;

		public int progress;

		public int priority;

		public int currentPriorityCount;

		public int cost;

		public int wareToMake
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public WareToMake()
		{
		}

		public WareToMake(int wareNum)
		{
		}

		public bool ApplyResource()
		{
			return false;
		}

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public GameObject[] shaft;

	public GameObject[] piston0;

	public GameObject[] piston1;

	public GameObject[] rod0;

	public GameObject[] rod1;

	[NonSerialized]
	public List<WareToMake>[] waresToMake;

	[NonSerialized]
	private List<FabricatorWare>[] producedWares;

	private int[] channelCurrentRow;

	private int MAX_ROTATE_SPEED;

	private int MAX_WORK_SPEED;

	private int[] workSpeed;

	private float[] shaftRotation;

	private float producedWareDist;

	private const int MAX_WARES = 360;

	private Vector3[] producedWareStartPos;

	[NonSerialized]
	public int[] producedWareCounts;

	public override void BuildComplete()
	{
	}

	public override void Awake()
	{
	}

	public WareToMake GetWareToMake(int wareToMakeID)
	{
		return null;
	}

	public List<WareToMake>[] GetWaresToMake()
	{
		return null;
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

	private void SetShaftRotation(int s, float value)
	{
	}

	public List<FabricatorWare>[] GetProducedWares()
	{
		return null;
	}

	public override float GetWaresAvailableToDispatch(int wareNum)
	{
		return 0f;
	}

	private void Fabricate()
	{
	}

	private void SetNeededWares(int channel)
	{
	}

	private int GetNextChannelRow(int channel)
	{
		return 0;
	}

	private int GetWareForChannel(int channel)
	{
		return 0;
	}

	private int GetChannelForWare(int wareNum)
	{
		return 0;
	}

	private void FabricateChannel(int channel)
	{
	}

	public override bool DispatchPacketWare(UnitManager u, int wareNum)
	{
		return false;
	}

	public void DestroyProducedWares(int wareType, int amt)
	{
	}

	public void CreateProducedWares(int wareType, int amt)
	{
	}

	public int GetProducedWares(int wareType)
	{
		return 0;
	}

	public void SetProducedWares(int wareType, int amt)
	{
	}

	private void PositionProducedWare(int ware)
	{
	}

	public override void ApplyPacket(Packet pm)
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
