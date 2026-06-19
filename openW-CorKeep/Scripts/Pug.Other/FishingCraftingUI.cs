using System.Collections.Generic;
using UnityEngine;

public class FishingCraftingUI : CraftingUIBase
{
	public GameObject container;

	private void Awake()
	{
		inventoryUI.Init();
		root.SetActive(value: false);
	}

	public override void ShowCraftingUI()
	{
		base.ShowCraftingUI();
		inventoryUI.ShowContainerUI();
		container.transform.localPosition = new Vector3(0f, 0.625f, 0f);
		UpdateAllCraftingUI();
	}

	private void Update()
	{
		if (root.activeInHierarchy)
		{
			UpdateAllCraftingUI();
		}
	}

	public override void UpdateAllCraftingUI(bool autoFillMaterials = false)
	{
		for (int i = 0; i < inventoryUI.totalVisibleSlots; i++)
		{
			inventoryUI.OnSlotUpdated(i);
		}
	}

	public override UIelement GetClosestUIElement(Vector3 worldPosition)
	{
		List<UIelement> list = new List<UIelement>();
		UIelement closestUIElement = inventoryUI.GetClosestUIElement(worldPosition);
		list.Add(closestUIElement);
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

	public override UIelement GetClosestUIElementExceptRecipes(Vector3 worldPosition)
	{
		List<UIelement> list = new List<UIelement>();
		UIelement closestUIElement = inventoryUI.GetClosestUIElement(worldPosition);
		list.Add(closestUIElement);
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
}
