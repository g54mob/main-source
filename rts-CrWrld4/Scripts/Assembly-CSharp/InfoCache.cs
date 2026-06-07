using System;
using NBT.Tags;
using mattmc3.dotmore.Collections.Generic;

public class InfoCache : UnitManager
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

	[NonSerialized]
	public string message;

	[NonSerialized]
	public int messageType;

	[NonSerialized]
	public string messageChannel;

	[NonSerialized]
	public string gameMessageButton0Text;

	[NonSerialized]
	public string gameMessageButton1Text;

	[NonSerialized]
	public bool pause;

	[NonSerialized]
	public bool autoClose;

	private bool retrieved;

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

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	private bool IsNullOrEmpty(string s)
	{
		return false;
	}

	private void Retrieved()
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
