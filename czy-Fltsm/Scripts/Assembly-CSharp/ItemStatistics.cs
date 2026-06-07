using System;
using System.Collections.Generic;
using M4.Session;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ItemStatistics : IStatistic
{
	[Serializable]
	public class ItemStatistic
	{
		public ItemType itemType;

		public int runPickupCount;

		public int runUseCount;

		public int runSpiritConsumed;

		public int lifeTimePickupCount;

		public int lifeTimeUseCount;

		public int lifeTimeSpriteConsumed;

		public void ResetRunStats()
		{
			runPickupCount = 0;
			runUseCount = 0;
			runSpiritConsumed = 0;
		}
	}

	private IUser player;

	[SerializeField]
	private List<ItemStatistic> itemStatisticTable;

	public bool IsInitialized { get; private set; }

	public ItemStatistics()
	{
		IsInitialized = false;
	}

	public void Initialize(IUser player, UnityAction initialize_callback)
	{
		this.player = player;
		itemStatisticTable = new List<ItemStatistic>();
	}

	public void BeginRun()
	{
		foreach (ItemStatistic item in itemStatisticTable)
		{
			item.ResetRunStats();
		}
	}

	public void ProcessItemEvent(ItemEvent evt)
	{
		throw new NotImplementedException();
	}

	public void Load()
	{
	}

	public void Save()
	{
	}

	private bool TryGetItemStatistic(ItemType item_type, out ItemStatistic result)
	{
		if (itemStatisticTable != null)
		{
			foreach (ItemStatistic item in itemStatisticTable)
			{
				if (item.itemType == item_type)
				{
					result = item;
					return true;
				}
			}
		}
		result = null;
		return false;
	}
}
