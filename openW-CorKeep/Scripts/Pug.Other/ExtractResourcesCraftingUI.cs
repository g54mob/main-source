using System.Collections.Generic;
using UnityEngine;

public class ExtractResourcesCraftingUI : CraftingUIBase
{
	public SpriteRenderer electricityIcon;

	public Color electricityColorOn;

	public Color electricityColorOff;

	public Vector3 arrowDefaultPos;

	public GameObject container;

	public float electricityColorOffPulseSpeed = 3.5f;

	public float electricityColorOffPulseIntensity = 0.9f;

	private void Awake()
	{
		inventoryUI.Init();
		outputUI.Init();
		recipeUI.Init();
		root.SetActive(value: false);
		arrowDefaultPos = arrow.transform.localPosition;
	}

	public override void ShowCraftingUI()
	{
		base.ShowCraftingUI();
		inventoryUI.ShowContainerUI();
		outputUI.ShowContainerUI();
		CraftingBuilding craftingBuilding = CraftingUIBase.GetCraftingBuilding();
		if (craftingBuilding != null && craftingBuilding.hideRecipes)
		{
			recipeUI.HideContainerUI();
			container.transform.localPosition = new Vector3(0f, 0.625f, 0f);
		}
		else
		{
			recipeUI.ShowContainerUI();
			container.transform.localPosition = Vector3.zero;
		}
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
		for (int j = 0; j < outputUI.totalVisibleSlots; j++)
		{
			outputUI.OnSlotUpdated(j);
		}
		if (base.activeCraftingHandler != null && base.activeCraftingHandler.RequiresElectricity())
		{
			electricityIcon.gameObject.SetActive(value: true);
			arrow.transform.localPosition = arrowDefaultPos - new Vector3(0f, 0.3125f, 0f);
			if (base.activeCraftingHandler.HasElectricity())
			{
				electricityIcon.color = electricityColorOn;
				return;
			}
			float t = (Mathf.Sin(Time.time * electricityColorOffPulseSpeed) * 0.5f + 0.5f) * electricityColorOffPulseIntensity;
			Color color = Color.Lerp(electricityColorOff, electricityColorOn, t);
			electricityIcon.color = color;
		}
		else
		{
			electricityIcon.gameObject.SetActive(value: false);
			arrow.transform.localPosition = arrowDefaultPos;
		}
	}

	public override UIelement GetClosestUIElement(Vector3 worldPosition)
	{
		List<UIelement> list = new List<UIelement>();
		UIelement closestUIElement = inventoryUI.GetClosestUIElement(worldPosition);
		list.Add(closestUIElement);
		list.Add(outputUI.GetClosestUIElement(worldPosition));
		CraftingBuilding craftingBuilding = CraftingUIBase.GetCraftingBuilding();
		if (!(craftingBuilding != null) || !craftingBuilding.hideRecipes)
		{
			list.Add(recipeUI.GetClosestUIElement(worldPosition));
		}
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
		list.Add(outputUI);
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
