using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
public class LandmarkActionSalvagePersistentData : LandmarkActionPersistentData
{
	public int AgentLimit;

	[OptionalField(VersionAdded = 3)]
	public List<int> UnlockedCategories;

	[OptionalField(VersionAdded = 5)]
	public List<int> ToggledCategories;

	[OptionalField(VersionAdded = 4)]
	public List<ItemFilterPersistentData> CategoryItemFilters;

	[OptionalField(VersionAdded = 2)]
	public ItemFilterPersistentData ItemFilter;

	public LandmarkActionSalvagePersistentData(LandmarkAction action)
		: base(action)
	{
		LandmarkActionSalvage landmarkActionSalvage = action as LandmarkActionSalvage;
		AgentLimit = landmarkActionSalvage.AssignmentLimit;
		ItemFilter = ((landmarkActionSalvage.ItemFilter == null) ? null : new ItemFilterPersistentData(landmarkActionSalvage.ItemFilter));
		CategoryItemFilters = new List<ItemFilterPersistentData>();
		for (int i = 0; i < landmarkActionSalvage.Categories.Count; i++)
		{
			LandmarkActionSalvage.Category category = landmarkActionSalvage.Categories[i];
			int num = GameManager.PersistenceManager.ReturnPropertiesIndex(category.CategoryAsset);
			if (category.RequiresItem && category.Unlocked)
			{
				if (UnlockedCategories == null)
				{
					UnlockedCategories = new List<int>();
				}
				UnlockedCategories.Add(num);
			}
			if (category.IsToggled)
			{
				if (ToggledCategories == null)
				{
					ToggledCategories = new List<int>();
				}
				ToggledCategories.Add(num);
			}
			CategoryItemFilters.Add(new ItemFilterPersistentData(category.ItemFilter, num));
		}
	}

	public void RestoreCategoryItemFilter(LandmarkSalvageableCategory category, Dictionary<ItemProperties, bool> itemFilter)
	{
		if (CategoryItemFilters.IsNullOrEmpty())
		{
			return;
		}
		int num = GameManager.PersistenceManager.ReturnPropertiesIndex(category);
		foreach (ItemFilterPersistentData categoryItemFilter in CategoryItemFilters)
		{
			if (categoryItemFilter.CategoryIndex == num)
			{
				categoryItemFilter.Restore(itemFilter);
				break;
			}
		}
	}

	public bool IsCategoryUnlocked(LandmarkSalvageableCategory category)
	{
		if (!UnlockedCategories.IsNullOrEmpty())
		{
			return UnlockedCategories.Contains(GameManager.PersistenceManager.ReturnPropertiesIndex(category));
		}
		return false;
	}

	public bool IsCategoryToggled(LandmarkSalvageableCategory category)
	{
		if (!ToggledCategories.IsNullOrEmpty())
		{
			return ToggledCategories.Contains(GameManager.PersistenceManager.ReturnPropertiesIndex(category));
		}
		return false;
	}
}
