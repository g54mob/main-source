using System.Collections.Generic;
using UnityEngine;

public class CookingCraftingUI : CraftingUIBase
{
	public CookBookUI cookBookUI;

	protected virtual void Awake()
	{
		inventoryUI.Init();
		cookBookUI.Init();
		cookBookUI.HideContainerUI();
		root.SetActive(value: false);
	}

	public override void ShowCraftingUI()
	{
		base.ShowCraftingUI();
		UpdateAllCraftingUI();
		inventoryUI.ShowContainerUI();
		outputUI.ShowContainerUI();
	}

	public override void UpdateAllCraftingUI(bool autoFillMaterials = false)
	{
		for (int i = 0; i < inventoryUI.totalVisibleSlots; i++)
		{
			inventoryUI.OnSlotUpdated(i);
		}
		for (int j = 0; j < outputUI.totalVisibleSlots; j++)
		{
			outputUI.OnSlotUpdated(j);
		}
	}

	public override UIelement GetClosestUIElement(Vector3 worldPosition)
	{
		List<UIelement> list = new List<UIelement>();
		UIelement closestUIElement = inventoryUI.GetClosestUIElement(worldPosition);
		list.Add(closestUIElement);
		list.Add(outputUI.GetClosestUIElement(worldPosition));
		UIelement result = null;
		float num = 2.1474836E+09f;
		foreach (UIelement item in list)
		{
			float sqrMagnitude = (worldPosition - item.transform.position).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				num = sqrMagnitude;
				result = item;
			}
		}
		return result;
	}

	public override void ActivateRecipeSlot(int visibleSlotIndex, bool mod1, bool mod2)
	{
	}

	public void ToggleCookBook()
	{
		if (cookBookUI.isShowing)
		{
			cookBookUI.HideContainerUI();
		}
		else
		{
			cookBookUI.ShowContainerUI();
		}
	}
}
