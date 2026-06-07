using System;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class AirSacCauldron : UnitManager
{
	private class ClonePack : IClonePack
	{
		private int startTime;

		private int finishTime;

		private int productionInterval;

		private AirSac.TARGET_BEHAVIOR targetBehavior;

		private int payload;

		private int count;

		private Vector2 targetBehaviorLocation;

		private bool disableMinimapWarning;

		public ClonePack(int startTime, int finishTime, int productionInterval, AirSac.TARGET_BEHAVIOR targetBehavior, int payload, int count, Vector2 targetBehaviorLocation, bool disableMinimapWarning)
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
	public AirSac.TARGET_BEHAVIOR targetBehavior;

	[NonSerialized]
	public Vector2 targetBehaviorLocation;

	[NonSerialized]
	public int payload;

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

	private AirSac CreateAirSac(AirSac.TARGET_BEHAVIOR targetBehavior, Vector2 targetBehaviorLocation, int payload, Vector3 pos)
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
