using System;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class Pod : UnitManager, IPacketDispatcher
{
	private class ClonePack : IClonePack
	{
		private OrderedDictionary2<string, RplCore.Data> settings;

		public ClonePack(OrderedDictionary2<string, RplCore.Data> settings)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	private int hideCounter;

	public GameObject amt;

	private int _resourceType;

	[NonSerialized]
	public DeliveryPad ownerPad;

	private static int DESTROY_DELAY;

	[NonSerialized]
	public int destroyTimer;

	private Mesh amtMesh;

	public override float ammo
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public int resourceType
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override IClonePack GetClonePack()
	{
		return null;
	}

	public override float GetWaresAvailableToDispatch(int wareNum)
	{
		return 0f;
	}

	public override void Awake()
	{
	}

	private int GetWareForSettings(int settingsWare)
	{
		return 0;
	}

	private int GetSettingsForWare(int wareType)
	{
		return 0;
	}

	public override void SetUnitSettings(OrderedDictionary2<string, RplCore.Data> initParams)
	{
	}

	public override OrderedDictionary2<string, RplCore.Data> GetUnitSettings()
	{
		return null;
	}

	public void SetCapacity(int amt)
	{
	}

	public override void Start()
	{
	}

	public override void OnMouseOver()
	{
	}

	public override void Update()
	{
	}

	public void CreateMVerseUnit()
	{
	}

	public override void GameUpdate()
	{
	}

	public bool DispatchPacket(UnitManager u, Packet.PACKET_TYPE type)
	{
		return false;
	}

	public override bool DispatchPacketWare(UnitManager u, int wareNum)
	{
		return false;
	}

	private void OnDestroy()
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
