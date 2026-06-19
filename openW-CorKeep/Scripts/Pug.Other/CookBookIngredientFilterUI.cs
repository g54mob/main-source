using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class CookBookIngredientFilterUI : ItemSlotsUIContainer, IScrollable
{
	public CookBookUI cookBookUI;

	public CookBookIngredientTypeFilterUI cookBookIngredientTypeFilterUI;

	private List<ObjectID> allDiscoveredIngredients = new List<ObjectID>();

	private List<UIelement> activeIngredientSlots = new List<UIelement>();

	public ObjectID currentIngredientFilter;

	protected const string rare = "Rare";

	protected const string epic = "Epic";

	private int prevDiscoveredCookedFoods;

	public override int MAX_ROWS => 120;

	public override int MAX_COLUMNS => 1;

	protected override void LateUpdate()
	{
		if (isShowing)
		{
			int count = Manager.saves.GetDiscoveredCookedFoods().Count;
			if (prevDiscoveredCookedFoods != count)
			{
				UpdateDiscoveredIngredients();
				prevDiscoveredCookedFoods = count;
			}
		}
		base.LateUpdate();
	}

	public void UpdateDiscoveredIngredients()
	{
		List<DiscoveredObjectData> discoveredCookedFoods = Manager.saves.GetDiscoveredCookedFoods();
		allDiscoveredIngredients.Clear();
		for (int i = 0; i < discoveredCookedFoods.Count; i++)
		{
			string text = discoveredCookedFoods[i].objectID.ToString();
			if (text.EndsWith("Epic"))
			{
				continue;
			}
			ObjectID primaryIngredientFromVariation = CookedFoodCD.GetPrimaryIngredientFromVariation(discoveredCookedFoods[i].variation);
			ObjectID secondaryIngredientFromVariation = CookedFoodCD.GetSecondaryIngredientFromVariation(discoveredCookedFoods[i].variation);
			if (CookedFoodCD.IsIngredientObsolete(primaryIngredientFromVariation) || CookedFoodCD.IsIngredientObsolete(secondaryIngredientFromVariation))
			{
				continue;
			}
			string text2 = primaryIngredientFromVariation.ToString();
			string text3 = secondaryIngredientFromVariation.ToString();
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(primaryIngredientFromVariation);
			ObjectInfo objectInfo2 = PugDatabase.GetObjectInfo(secondaryIngredientFromVariation);
			if (objectInfo != null && objectInfo2 != null && ((!text2.EndsWith("Rare") && !text3.EndsWith("Rare")) || text.EndsWith("Rare")) && (text2.EndsWith("Rare") || text3.EndsWith("Rare") || objectInfo.rarity == Rarity.Legendary || objectInfo2.rarity == Rarity.Legendary || !text.EndsWith("Rare")))
			{
				if (!allDiscoveredIngredients.Contains(primaryIngredientFromVariation) && Manager.saves.HasDiscoveredObject(primaryIngredientFromVariation))
				{
					allDiscoveredIngredients.Add(primaryIngredientFromVariation);
				}
				if (!allDiscoveredIngredients.Contains(secondaryIngredientFromVariation) && Manager.saves.HasDiscoveredObject(secondaryIngredientFromVariation))
				{
					allDiscoveredIngredients.Add(secondaryIngredientFromVariation);
				}
			}
		}
		List<ObjectID> list = new List<ObjectID>();
		for (int num = allDiscoveredIngredients.Count - 1; num >= 0; num--)
		{
			if (PugDatabase.HasComponent<FlowerCD>(allDiscoveredIngredients[num]))
			{
				list.Add(allDiscoveredIngredients[num]);
				allDiscoveredIngredients.RemoveAtSwapBack(num);
			}
		}
		allDiscoveredIngredients.Sort((ObjectID a, ObjectID b) => a.CompareTo(b));
		list.Sort((ObjectID a, ObjectID b) => string.Compare(a.ToString(), b.ToString()));
		allDiscoveredIngredients.InsertRange(0, list);
		UpdateFilter();
	}

	public void UpdateFilter()
	{
		activeIngredientSlots.Clear();
		List<ObjectID> list = new List<ObjectID>();
		if (cookBookIngredientTypeFilterUI.currentIngredientTypeFilter == IngredientType.None)
		{
			list = allDiscoveredIngredients;
		}
		else
		{
			foreach (ObjectID allDiscoveredIngredient in allDiscoveredIngredients)
			{
				if (PugDatabase.HasComponent<CookingIngredientCD>(allDiscoveredIngredient) && PugDatabase.GetComponent<CookingIngredientCD>(allDiscoveredIngredient).ingredientType == cookBookIngredientTypeFilterUI.currentIngredientTypeFilter)
				{
					list.Add(allDiscoveredIngredient);
				}
			}
		}
		int num = math.min(list.Count, itemSlots.Count);
		int i;
		for (i = 0; i < num; i++)
		{
			CookBookIngredientFilterSlot cookBookIngredientFilterSlot = itemSlots[i] as CookBookIngredientFilterSlot;
			cookBookIngredientFilterSlot.SetObjectData(new ObjectDataCD
			{
				objectID = list[i]
			}, this);
			cookBookIngredientFilterSlot.gameObject.SetActive(value: true);
			activeIngredientSlots.Add(cookBookIngredientFilterSlot);
		}
		for (; i < itemSlots.Count; i++)
		{
			itemSlots[i].gameObject.SetActive(value: false);
		}
		UpdateSlotsPositioning();
	}

	public override void ShowContainerUI()
	{
		currentIngredientFilter = ObjectID.None;
		base.ShowContainerUI();
	}

	private void UpdateSlotsPositioning()
	{
		int num = Mathf.Min(activeIngredientSlots.Count - startSlotIndex, base.MAX_SLOTS);
		float sideStartPosition = GetSideStartPosition(MAX_COLUMNS);
		float num2 = 0f;
		for (int i = 0; i < num; i++)
		{
			int num3 = i % MAX_COLUMNS;
			int num4 = i / MAX_COLUMNS;
			CookBookIngredientFilterSlot obj = activeIngredientSlots[i] as CookBookIngredientFilterSlot;
			obj.visibleSlotIndex = i;
			obj.transform.localPosition = new Vector3(sideStartPosition + (float)num3 * spread, num2 - (float)num4 * spread, 0f);
		}
	}

	private float GetSideStartPosition(int size)
	{
		return (0f - (float)(size - 1) / 2f) * spread;
	}

	public void UpdateContainingElements(float scroll)
	{
	}

	public bool IsBottomElementSelected()
	{
		if (Manager.ui.currentSelectedUIElement == null)
		{
			return false;
		}
		int num = math.max(0, activeIngredientSlots.Count - 1) / MAX_COLUMNS * MAX_COLUMNS;
		for (int i = num; i < activeIngredientSlots.Count; i++)
		{
			if (i >= num && activeIngredientSlots[i] == Manager.ui.currentSelectedUIElement)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsTopElementSelected()
	{
		if (Manager.ui.currentSelectedUIElement == null)
		{
			return false;
		}
		int num = math.min(MAX_COLUMNS, activeIngredientSlots.Count);
		for (int i = 0; i < num; i++)
		{
			if (activeIngredientSlots[i] == Manager.ui.currentSelectedUIElement)
			{
				return true;
			}
		}
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		if (activeIngredientSlots.Count > 0)
		{
			return activeIngredientSlots[0].transform.localPosition.y - activeIngredientSlots[activeIngredientSlots.Count - 1].transform.localPosition.y + 1.375f;
		}
		return 0f;
	}

	public UIScrollWindow GetScrollWindow()
	{
		return scrollWindow;
	}

	public void ActivateIngredientFilter(ObjectID filterOnIngredient)
	{
		currentIngredientFilter = filterOnIngredient;
		cookBookUI.UpdateFilter();
	}

	public void TurnOffIngredientFilter()
	{
		currentIngredientFilter = ObjectID.None;
		cookBookUI.UpdateFilter();
	}

	public void TurnOffIngredientFilterIfActiveFilterIsNotShowingType()
	{
		if (!ActiveFilterTypeShowsActiveIngredient())
		{
			TurnOffIngredientFilter();
		}
		UpdateFilter();
	}

	private bool ActiveFilterTypeShowsActiveIngredient()
	{
		if (cookBookIngredientTypeFilterUI.currentIngredientTypeFilter != IngredientType.None && currentIngredientFilter != ObjectID.None && PugDatabase.HasComponent<CookingIngredientCD>(currentIngredientFilter))
		{
			return PugDatabase.GetComponent<CookingIngredientCD>(currentIngredientFilter).ingredientType == cookBookIngredientTypeFilterUI.currentIngredientTypeFilter;
		}
		return false;
	}
}
