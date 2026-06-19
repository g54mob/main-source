using Unity.Entities;
using UnityEngine;

public class RecipesUI : ItemSlotsUIContainer
{
	public bool showEmptySlots;

	public override int MAX_ROWS => 2;

	public override int MAX_COLUMNS => 3;

	public virtual bool centerLayout => false;

	public override void ShowContainerUI()
	{
		categoryWindowStartSlotIndex = Manager.ui.GetCategoryWindowInfoStartIndex();
		base.ShowContainerUI();
		int recipesLength = GetRecipesLength();
		base.visibleColumns = Mathf.Min(recipesLength, MAX_COLUMNS);
		base.visibleRows = Mathf.CeilToInt((float)recipesLength / (float)base.visibleColumns);
		float sideStartPosition = GetSideStartPosition(centerLayout ? base.visibleColumns : MAX_COLUMNS);
		float num = 0f - GetSideStartPosition(centerLayout ? base.visibleRows : MAX_ROWS);
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < MAX_ROWS; i++)
		{
			for (int j = 0; j < MAX_COLUMNS; j++)
			{
				if (num2 >= itemSlots.Count)
				{
					break;
				}
				CraftingHandler.RecipeInfo recipeInfo = Manager.main.player.activeCraftingHandler.GetRecipeInfo(startSlotIndex + num3);
				if (i < base.visibleRows && j < base.visibleColumns && num3 < recipesLength)
				{
					if (showEmptySlots || (recipeInfo.isValid && recipeInfo.objectID != ObjectID.None))
					{
						itemSlots[num2].visibleSlotIndex = num3;
						if (autoPositionSlots)
						{
							itemSlots[num2].transform.localPosition = new Vector3(sideStartPosition + (float)j * spread, num - (float)i * spread, 0f);
						}
						itemSlots[num2].gameObject.SetActive(value: true);
						itemSlots[num2].UpdateSlot();
					}
					else
					{
						itemSlots[num2].gameObject.SetActive(value: false);
					}
					num3++;
				}
				else
				{
					itemSlots[num2].gameObject.SetActive(value: false);
				}
				num2++;
			}
		}
	}

	public virtual void HighlightRecipe(ObjectID recipe)
	{
		int recipesLength = GetRecipesLength();
		int num = 0;
		for (int i = 0; i < MAX_ROWS; i++)
		{
			for (int j = 0; j < MAX_COLUMNS; j++)
			{
				int index = i * MAX_COLUMNS + j;
				CraftingHandler.RecipeInfo recipeInfo = Manager.main.player.activeCraftingHandler.GetRecipeInfo(startSlotIndex + num);
				if (i < base.visibleRows && j < base.visibleColumns && num < recipesLength && recipeInfo.isValid)
				{
					if (recipeInfo.objectID == recipe)
					{
						itemSlots[index].Highlight();
					}
					num++;
				}
			}
		}
	}

	public virtual void ClearRecipeHighlights()
	{
		foreach (SlotUIBase itemSlot in itemSlots)
		{
			itemSlot.ClearHighlight();
		}
	}

	private int GetRecipesLength()
	{
		int length = GetCraftingRecipes().Length;
		CraftingBuilding.CraftingCategoryWindowInfo craftingCategoryWindowInfo = Manager.ui.GetCraftingCategoryWindowInfo();
		if (craftingCategoryWindowInfo != null)
		{
			return Mathf.Min(craftingCategoryWindowInfo.endSlotIndex + 1 - startSlotIndex, base.MAX_SLOTS);
		}
		return Mathf.Min(length - startSlotIndex, base.MAX_SLOTS);
	}

	private float GetSideStartPosition(int size)
	{
		return (0f - (float)(size - 1) / 2f) * spread;
	}

	private DynamicBuffer<CanCraftObjectsBuffer> GetCraftingRecipes()
	{
		return Manager.main.player.activeCraftingHandler.GetRecipes();
	}
}
