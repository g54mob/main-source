using System;
using System.Collections.Generic;
using PajamaLlama.Utilities;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Achievements/Daily Production Achievement")]
public class DailyProductionAchievement : DayEndedAchievementBase
{
	[Serializable]
	public class ItemPropertiesArray : InspectorHidableArrayBase<ItemProperties>
	{
		[SerializeField]
		private ItemProperties[] _items;

		public override ItemProperties[] Array => _items;
	}

	public enum Comparison
	{
		Equal = 0,
		LargerThanOrEqual = 1
	}

	[Header("Production Achievement")]
	[SerializeField]
	private ItemType _itemType;

	[SerializeField]
	[ConditionalHide("_itemType", true)]
	[Tooltip("Minimum required ItemQuality. When no ItemQuality is set ItemQuality will be ignored")]
	private ItemQuality _minimumItemQuality;

	[SerializeField]
	[ConditionalHide("_itemType", true, true)]
	private ItemPropertiesArray _items;

	[SerializeField]
	private Comparison _comparison;

	[SerializeField]
	[Tooltip("The amount that is required to be produced")]
	private int _requirement;

	[SerializeField]
	[Min(1f)]
	[Tooltip("The amount of days the requirement should be met.")]
	private int _days = 1;

	protected override void OnDayEnded(GameEvent gameEvent)
	{
		if (!(gameEvent is DayEvent dayEvent) || dayEvent.Days.Count < _days)
		{
			return;
		}
		for (int i = dayEvent.Days.Count - _days; i < dayEvent.Days.Count; i++)
		{
			if (!IsRequirementMet(dayEvent.Days[i].Report))
			{
				return;
			}
		}
		if (UnlockAchievement())
		{
			Uninitialize();
		}
	}

	private bool IsRequirementMet(DailyReport report)
	{
		int producedAmount = GetProducedAmount(report);
		switch (_comparison)
		{
		case Comparison.Equal:
			if (producedAmount == _requirement)
			{
				return true;
			}
			break;
		case Comparison.LargerThanOrEqual:
			if (producedAmount >= _requirement)
			{
				return true;
			}
			break;
		default:
			Debug.LogException(new NotImplementedException());
			break;
		}
		return false;
	}

	private int GetProducedAmount(DailyReport report)
	{
		if ((bool)_itemType)
		{
			if ((bool)_minimumItemQuality)
			{
				return GetProducedAmount(report, _itemType, _minimumItemQuality);
			}
			return GetProducedAmount(report, _itemType);
		}
		return GetProducedAmount(report, _items.Array);
	}

	private int GetProducedAmount(DailyReport report, ItemType itemType)
	{
		int num = 0;
		foreach (KeyValuePair<ItemProperties, int> craftedResource in report.CraftedResources)
		{
			if (craftedResource.Key.ItemType == itemType)
			{
				num += craftedResource.Value;
			}
		}
		return num;
	}

	private int GetProducedAmount(DailyReport report, ItemType itemType, ItemQuality minimumItemQuality)
	{
		int num = 0;
		foreach (KeyValuePair<ItemProperties, int> craftedResource in report.CraftedResources)
		{
			if (craftedResource.Key.ItemType == itemType && craftedResource.Key.Quality != null && craftedResource.Key.Quality.Value >= minimumItemQuality.Value)
			{
				num += craftedResource.Value;
			}
		}
		return num;
	}

	private int GetProducedAmount(DailyReport report, ItemProperties[] items)
	{
		int num = 0;
		foreach (ItemProperties item in _items)
		{
			if (report.CraftedResources.TryGetValue(item, out var value))
			{
				num += value;
			}
		}
		return num;
	}
}
