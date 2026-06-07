using System;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class BlobNest : UnitManager
{
	private class ClonePack : IClonePack
	{
		private int startTime;

		private int finishTime;

		private int productionInterval;

		private Blob.TARGET_BEHAVIOR targetBehavior;

		private int payload;

		private int count;

		private int lifeTime;

		private Vector2 targetBehaviorLocation;

		private bool disableMinimapWarning;

		private int emitCount;

		private bool carryEggsOnFirst;

		private float carryEggProb;

		public ClonePack(int startTime, int finishTime, int productionInterval, Blob.TARGET_BEHAVIOR targetBehavior, int payload, int count, int lifeTime, Vector2 targetBehaviorLocation, bool disableMinimapWarning, int emitCount, bool carryEggsOnFirst, float carryEggProb)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	[NonSerialized]
	public int startTime;

	[NonSerialized]
	public int finishTime;

	[NonSerialized]
	public int productionInterval;

	[NonSerialized]
	public Blob.TARGET_BEHAVIOR targetBehavior;

	[NonSerialized]
	public Vector2 targetBehaviorLocation;

	[NonSerialized]
	public int payload;

	[NonSerialized]
	public int lifeTime;

	[NonSerialized]
	public float carryEggProb;

	[NonSerialized]
	public bool carryEggsOnFirst;

	[NonSerialized]
	public int count;

	private int emitCount;

	[NonSerialized]
	public bool disableMinimapWarning;

	private int upcoming;

	public override void SetUnitSettings(OrderedDictionary2<string, RplCore.Data> initParams)
	{
	}

	public override OrderedDictionary2<string, RplCore.Data> GetUnitSettings()
	{
		return null;
	}

	public override IClonePack GetClonePack()
	{
		return null;
	}

	public override void Awake()
	{
	}

	public int GetTimeForNext()
	{
		return 0;
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	public Blob CreateBlob(Blob.TARGET_BEHAVIOR targetBehavior, Vector2 targetBehaviorLocation, int payload, Vector3 pos)
	{
		return null;
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
