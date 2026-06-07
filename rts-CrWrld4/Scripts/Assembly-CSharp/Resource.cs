using System;
using NBT.Tags;
using mattmc3.dotmore.Collections.Generic;

public class Resource : UnitManager
{
	private class ClonePack : IClonePack
	{
		private int productionInterval;

		public ClonePack(int productionInterval)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	[NonSerialized]
	public int PRODUCTION_INTERVAL;

	[NonSerialized]
	public int BLOB_PRODUCTION_INTERVAL;

	protected int ampCount;

	protected int productionCounter;

	protected int blobProductionCounter;

	protected bool _wareAvailable;

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

	public override float GetWaresAvailableToDispatch(int wareNum)
	{
		return 0f;
	}

	public override IClonePack GetClonePack()
	{
		return null;
	}

	public override void Awake()
	{
	}

	public override void SetUnitSettings(OrderedDictionary2<string, RplCore.Data> initParams)
	{
	}

	public override OrderedDictionary2<string, RplCore.Data> GetUnitSettings()
	{
		return null;
	}

	public void Amp()
	{
	}

	public virtual int GetWareType()
	{
		return 0;
	}

	public int GetModifiedProductionInterval()
	{
		return 0;
	}

	public override void GameUpdate()
	{
	}

	protected virtual void CanProduce()
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
