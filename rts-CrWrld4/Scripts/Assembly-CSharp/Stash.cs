using System;
using NBT.Tags;
using mattmc3.dotmore.Collections.Generic;

public class Stash : UnitManager
{
	private class ClonePack : IClonePack
	{
		private float collectRatio;

		private long releaseAmtPerCell;

		private long stashedAmt;

		private bool releasing;

		private int coolDownCounter;

		private int unsupportedCounter;

		private bool consumeCreeper;

		private float releaseThreshold;

		private int COOL_DOWN_TIME;

		private int UNSUPPORTED_RELEASE_TIME;

		public ClonePack(float collectRatio, long releaseAmtPerCell, long stashedAmt, bool releasing, int coolDownCounter, int unsupportedCounter, bool consumeCreeper, float releaseThreshold, int COOL_DOWN_TIME, int UNSUPPORTED_RELEASE_TIME)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	[NonSerialized]
	public bool consumeCreeper;

	[NonSerialized]
	public float releaseThreshold;

	[NonSerialized]
	public float collectRatio;

	[NonSerialized]
	public long releaseAmtPerCell;

	[NonSerialized]
	public long stashedAmt;

	private bool releasing;

	private int coolDownCounter;

	private int unsupportedCounter;

	[NonSerialized]
	public int COOL_DOWN_TIME;

	[NonSerialized]
	public int UNSUPPORTED_RELEASE_TIME;

	private int hideCounter;

	private float time;

	private long lastStashedAmt;

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

	public override void Start()
	{
	}

	public override void GameUpdate()
	{
	}

	public void Reset()
	{
	}

	private void SetScale(bool forceMVerse = false)
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
