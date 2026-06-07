using System;
using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class Emitter : UnitManager
{
	public enum SECONDARY_LIST_PROCESS
	{
		SERIES = 0,
		RANDOM = 1
	}

	public class SecondaryEnemyRow
	{
		public enum SECONDARY_TYPE
		{
			NONE = 0,
			RANDOM = 1,
			SPORE = 2,
			STRIDER = 3,
			AIRSAC = 4
		}

		public enum TARGET_BEHAVIOR
		{
			RANDOM = 0,
			STRUCTURE = 1,
			PACK = 2
		}

		public SECONDARY_TYPE secondaryType;

		public TARGET_BEHAVIOR targetBehavior;

		public int totalCost;

		public int delay;

		public int count;

		public int payload;

		public SecondaryEnemyRow()
		{
		}

		public SecondaryEnemyRow(SECONDARY_TYPE secondaryType, TARGET_BEHAVIOR targetBehavior, int totalCost, int delay, int count, int payload)
		{
		}

		public SecondaryEnemyRow Copy()
		{
			return null;
		}

		public static SecondaryEnemyRow Copy(SecondaryEnemyRow row)
		{
			return null;
		}

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	private class ClonePack : IClonePack
	{
		private long emitAmt;

		private int emitDelay;

		private int emitStartDelay;

		public ClonePack(long emitAmt, int emitDelay, int emitStartDelay)
		{
		}

		public void CloneData(UnitManager targetUnit)
		{
		}
	}

	public GameObject eggIndicator;

	[NonSerialized]
	public int startTime;

	[NonSerialized]
	public int finishTime;

	[NonSerialized]
	public int productionInterval;

	private long _productionBaseAmt;

	[NonSerialized]
	public int productionInterval2;

	[NonSerialized]
	public long productionBaseAmt2;

	[NonSerialized]
	public int pulseInterval;

	[NonSerialized]
	public int sporeProductionInterval;

	[NonSerialized]
	public long storedCreeper;

	[NonSerialized]
	public long storedCreeperEmitAmt;

	[NonSerialized]
	public bool hasBeenUnfrozen;

	[NonSerialized]
	public int emitCount;

	private const int maxEmit = 2000000000;

	[NonSerialized]
	public int blobCount;

	[NonSerialized]
	public int secondaryInitialDelay;

	[NonSerialized]
	public SECONDARY_LIST_PROCESS secondaryListProcess;

	private List<SecondaryEnemyRow> secondaryList;

	private int secondaryListPos;

	[NonSerialized]
	public int lastSpawnTime;

	private List<Vine> vineList;

	[NonSerialized]
	public bool wantBlob;

	[NonSerialized]
	public int BLOB_PRODUCTION_INTERVAL;

	[NonSerialized]
	public int BLOB_START_DELAY;

	protected int blobProductionCounter;

	public long productionBaseAmt
	{
		get
		{
			return 0L;
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

	public List<SecondaryEnemyRow> GetSecondaryList()
	{
		return null;
	}

	public void SetSecondaryList(List<SecondaryEnemyRow> list)
	{
	}

	public override IClonePack GetClonePack()
	{
		return null;
	}

	public override void Awake()
	{
	}

	public void AddBlob()
	{
	}

	private void CreateStrider(SecondaryEnemyRow.TARGET_BEHAVIOR targetBehavior, int payload)
	{
	}

	private void CreateSpore(SecondaryEnemyRow.TARGET_BEHAVIOR targetBehavior, int payload)
	{
	}

	private void CreateAirSac(SecondaryEnemyRow.TARGET_BEHAVIOR targetBehavior, int payload)
	{
	}

	private void GetBoundListPos()
	{
	}

	public SecondaryEnemyRow GetCurrentSecondaryEnemyRow()
	{
		return null;
	}

	private void ProcessSecondaryList()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
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
