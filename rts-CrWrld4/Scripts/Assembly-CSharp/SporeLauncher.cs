using System;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class SporeLauncher : UnitManager
{
	private class ClonePack : IClonePack
	{
		private int startTime;

		private int finishTime;

		private int sporeProductionInterval;

		private Spore.TARGET_BEHAVIOR targetBehavior;

		private int payload;

		private int count;

		private int eggStartTime;

		private int eggProductionInterval;

		private bool eggOnlyDuringCutoff;

		private int eggCount;

		private float eggOffensiveRatio;

		private float eggDefensiveRatio;

		private Vector2 targetBehaviorLocation;

		private bool disableMinimapWarning;

		public ClonePack(int startTime, int finishTime, int sporeProductionInterval, Spore.TARGET_BEHAVIOR targetBehavior, int payload, int count, int eggStartTime, int eggProductionInterval, bool eggOnlyDuringCutoff, int eggCount, float eggOffensiveRatio, float eggDefensiveRatio, Vector2 targetBehaviorLocation, bool disableMinimapWarning)
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
	public int sporeProductionInterval;

	[NonSerialized]
	public Spore.TARGET_BEHAVIOR targetBehavior;

	[NonSerialized]
	public Vector2 targetBehaviorLocation;

	[NonSerialized]
	public int payload;

	[NonSerialized]
	public int count;

	[NonSerialized]
	public int eggStartTime;

	[NonSerialized]
	public int eggProductionInterval;

	[NonSerialized]
	public bool eggOnlyDuringCutoff;

	[NonSerialized]
	public int eggCount;

	[NonSerialized]
	public float eggOffensiveRatio;

	[NonSerialized]
	public float eggDefensiveRatio;

	public GameObject bulb;

	private int _materialType;

	[NonSerialized]
	public bool disableMinimapWarning;

	private int upcoming;

	public int materialType
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

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

	private void UpdateMaterial()
	{
	}

	public override void Update()
	{
	}

	public int GetTimeForNext()
	{
		return 0;
	}

	public override void GameUpdate()
	{
	}

	public static Spore CreateSpore(Spore.TARGET_BEHAVIOR targetBehavior, Vector2 targetBehaviorLocation, int payload, Vector3 pos)
	{
		return null;
	}

	public static AirSacBubble CreateEgg(Vector3 position, Vector3 lastPosition, int payload)
	{
		return null;
	}

	private AirSacBubble CreateMyEgg(bool suppressMoveTo)
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
