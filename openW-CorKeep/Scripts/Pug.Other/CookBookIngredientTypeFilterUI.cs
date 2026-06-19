using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CookBookIngredientTypeFilterUI : ItemSlotsUIContainer, IScrollable
{
	[Serializable]
	public class IngredientTypeInfo
	{
		public IngredientType ingredientType;

		public Sprite icon;
	}

	public CookBookUI cookBookUI;

	public CookBookIngredientFilterUI cookBookIngredientFilterUI;

	private List<IngredientType> allIngredientTypes = new List<IngredientType>
	{
		IngredientType.Plant,
		IngredientType.Fish,
		IngredientType.Meat
	};

	private List<UIelement> activeIngredientTypeSlots = new List<UIelement>();

	public IngredientType currentIngredientTypeFilter;

	public List<IngredientTypeInfo> ingredientTypeInfos;

	public override int MAX_ROWS => 5;

	public override int MAX_COLUMNS => 1;

	public IngredientTypeInfo GetIngredientTypeInfo(IngredientType ingredientType)
	{
		foreach (IngredientTypeInfo ingredientTypeInfo in ingredientTypeInfos)
		{
			if (ingredientTypeInfo.ingredientType == ingredientType)
			{
				return ingredientTypeInfo;
			}
		}
		return null;
	}

	public void UpdateIngredientTypes()
	{
		if (activeIngredientTypeSlots.Count == 0)
		{
			for (int i = 0; i < allIngredientTypes.Count; i++)
			{
				CookBookIngredientTypeFilterSlot cookBookIngredientTypeFilterSlot = itemSlots[i] as CookBookIngredientTypeFilterSlot;
				cookBookIngredientTypeFilterSlot.SetType(GetIngredientTypeInfo(allIngredientTypes[i]), this);
				cookBookIngredientTypeFilterSlot.gameObject.SetActive(value: true);
				activeIngredientTypeSlots.Add(cookBookIngredientTypeFilterSlot);
			}
		}
		UpdateSlotsPositioning();
	}

	public override void ShowContainerUI()
	{
		UpdateIngredientTypes();
		base.ShowContainerUI();
	}

	private void UpdateSlotsPositioning()
	{
		int num = Mathf.Min(activeIngredientTypeSlots.Count - startSlotIndex, base.MAX_SLOTS);
		float sideStartPosition = GetSideStartPosition(MAX_COLUMNS);
		float num2 = 0f;
		for (int i = 0; i < num; i++)
		{
			int num3 = i % MAX_COLUMNS;
			int num4 = i / MAX_COLUMNS;
			CookBookIngredientTypeFilterSlot obj = activeIngredientTypeSlots[i] as CookBookIngredientTypeFilterSlot;
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
		int num = math.max(0, activeIngredientTypeSlots.Count - 1) / MAX_COLUMNS * MAX_COLUMNS;
		for (int i = num; i < activeIngredientTypeSlots.Count; i++)
		{
			if (i >= num && activeIngredientTypeSlots[i] == Manager.ui.currentSelectedUIElement)
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
		int num = math.min(MAX_COLUMNS, activeIngredientTypeSlots.Count);
		for (int i = 0; i < num; i++)
		{
			if (activeIngredientTypeSlots[i] == Manager.ui.currentSelectedUIElement)
			{
				return true;
			}
		}
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		if (activeIngredientTypeSlots.Count > 0)
		{
			return activeIngredientTypeSlots[0].transform.localPosition.y - activeIngredientTypeSlots[activeIngredientTypeSlots.Count - 1].transform.localPosition.y + 1.375f;
		}
		return 0f;
	}

	public UIScrollWindow GetScrollWindow()
	{
		return scrollWindow;
	}

	public void ActivateIngredientFilter(IngredientType filterOnIngredientType)
	{
		currentIngredientTypeFilter = filterOnIngredientType;
		cookBookIngredientFilterUI.TurnOffIngredientFilterIfActiveFilterIsNotShowingType();
		cookBookUI.UpdateFilter();
	}

	public void TurnOffIngredientFilter()
	{
		currentIngredientTypeFilter = IngredientType.None;
		cookBookIngredientFilterUI.UpdateFilter();
		cookBookUI.UpdateFilter();
	}
}
