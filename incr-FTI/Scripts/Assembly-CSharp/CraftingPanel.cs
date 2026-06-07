using System.Collections.Generic;
using UnityEngine;

public class CraftingPanel : ProductionListPanel
{
	public GameObject craftListItemPrefab;

	protected override bool ShouldItemBeValid(object obj)
	{
		if (obj is RecipeState recipeState)
		{
			return !recipeState.isLocked;
		}
		return false;
	}

	protected override MonoBehaviour CreateListItemForPool()
	{
		return CreateCommonListItemForPool(craftListItemPrefab);
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		foreach (KeyValuePair<BuildingType, CraftingSectionHeader> buildingHeader in buildingHeaders)
		{
			foreach (RecipeType item in Crafting.PotentialRecipeTypesForBuilding(buildingHeader.Key))
			{
				if (MenuPanel.gm.activeTown.recipes.TryGetValue(item, out var value))
				{
					CraftingSectionHeader craftingSectionHeader = HeaderForBuilding(buildingHeader.Key);
					if (null != craftingSectionHeader)
					{
						craftingSectionHeader.layoutManager.AddItemWithHeight(value, itemHeight);
					}
				}
			}
		}
	}

	public override void CreateItems()
	{
		base.CreateItems();
		foreach (KeyValuePair<BuildingType, BuildingDef> item in Crafting.buildingCache)
		{
			List<RecipeType> list = Crafting.PotentialRecipeTypesForBuilding(item.Key);
			bool flag = false;
			foreach (RecipeType item2 in list)
			{
				if (Crafting.GetRecipe(item2).category == RecipeCategory.DefaultItem)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				AddBuildingHeader(item.Key, primaryLayoutManager);
			}
		}
	}

	protected override void AssignKeyToItem(object key, MonoBehaviour item)
	{
		if (key is RecipeState r && item is CraftListItem craftListItem)
		{
			craftListItem.LoadState(r);
			craftListItem.OnStateAssignmentChanged();
		}
	}

	public override bool ShouldBeAvailable()
	{
		return false;
	}

	public override void JumpToState(StateManager sm)
	{
		if (sm.isLocked && sm is RecipeState recipeState)
		{
			MenuManager.Instance.NavigateToRequirementRecursively(recipeState.derivedRequirements);
		}
		else
		{
			QueueJumpToItemWithLinkedObject(sm);
		}
	}

	public bool TryJumpToOutputItem(ItemType t)
	{
		List<Requirement> list = null;
		foreach (RecipeState value in MenuPanel.gm.activeTown.recipes.Values)
		{
			foreach (ItemRateData item in value.output)
			{
				if (!item.state.AsEntity().TryAsItem(out var i) || i != t)
				{
					continue;
				}
				if (value.producingBuilding != null && value.producingBuilding.availability != BuildObjectAvailability.Available)
				{
					list = value.producingBuilding.unlockRequirements.requirements;
					continue;
				}
				if (value.isLocked)
				{
					list = value.derivedRequirements;
					continue;
				}
				QueueJumpToItemWithLinkedObject(value);
				return true;
			}
		}
		if (list != null)
		{
			return MenuManager.Instance.NavigateToRequirementRecursively(list);
		}
		return false;
	}
}
