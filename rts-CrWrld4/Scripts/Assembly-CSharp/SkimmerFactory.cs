using System;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class SkimmerFactory : UnitManager
{
	private class ClonePack : IClonePack
	{
		private int startTime;

		private int finishTime;

		private int productionInterval;

		private Strider.TARGET_BEHAVIOR targetBehavior;

		private int payload;

		private int count;

		private int lifeTime;

		private Vector2 targetBehaviorLocation;

		private bool disableMinimapWarning;

		private int forbStartTime;

		private int forbFinishTime;

		private int forbProductionInterval;

		private int forbPayload;

		private int forbCount;

		public ClonePack(int startTime, int finishTime, int productionInterval, Strider.TARGET_BEHAVIOR targetBehavior, int payload, int count, int lifeTime, Vector2 targetBehaviorLocation, bool disableMinimapWarning, int forbStartTime, int forbFinishTime, int forbProductionInterval, int forbPayload, int forbCount)
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
	public Strider.TARGET_BEHAVIOR targetBehavior;

	[NonSerialized]
	public Vector2 targetBehaviorLocation;

	[NonSerialized]
	public int payload;

	[NonSerialized]
	public int lifeTime;

	[NonSerialized]
	public int forbStartTime;

	[NonSerialized]
	public int forbFinishTime;

	[NonSerialized]
	public int forbProductionInterval;

	[NonSerialized]
	public int forbPayload;

	[NonSerialized]
	public int forbCount;

	private int currentForbCount;

	[NonSerialized]
	public int count;

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

	private Strider CreateSkimmer(Strider.TARGET_BEHAVIOR targetBehavior, Vector2 targetBehaviorLocation, int payload, Vector3 pos)
	{
		return null;
	}

	private Forb CreateForb(int payload, Vector3 pos)
	{
		return null;
	}

	public void OnForbCreated()
	{
	}

	public void OnForbDestroyed()
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
