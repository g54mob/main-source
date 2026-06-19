using System.Collections.Generic;
using UnityEngine;

public class FilteringUI : UIelement
{
	public GameObject root;

	public ItemSlotsUIContainer inventoryUI;

	public ButtonUIElement addNewFilterButton;

	public ButtonUIElement removeFilterButton;

	public SmallTitleUIBackground title;

	public SpriteRenderer electricityIcon;

	public Color electricityColorOn;

	public Color electricityColorOff;

	public Vector3 arrowDefaultPos;

	public float electricityColorOffPulseSpeed = 3.5f;

	public float electricityColorOffPulseIntensity = 0.9f;

	public override bool isShowing => root.activeInHierarchy;

	private void Awake()
	{
		inventoryUI.Init();
		root.SetActive(value: false);
	}

	protected override void LateUpdate()
	{
		root.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		base.LateUpdate();
	}

	public virtual void ShowUI()
	{
		root.SetActive(value: true);
		inventoryUI.ShowContainerUI();
		UpdateAllCraftingUI();
	}

	public virtual void HideUI()
	{
		root.SetActive(value: false);
	}

	private void Update()
	{
		if (root.activeInHierarchy)
		{
			UpdateAllCraftingUI();
		}
	}

	public void UpdateAllCraftingUI(bool autoFillMaterials = false)
	{
		for (int i = 0; i < inventoryUI.totalVisibleSlots; i++)
		{
			inventoryUI.OnSlotUpdated(i);
		}
		IFilteringBuilding activeFilteringBuilding = Manager.main.player.GetActiveFilteringBuilding();
		if (activeFilteringBuilding != null && activeFilteringBuilding.RequiresElectricity())
		{
			electricityIcon.gameObject.SetActive(value: true);
			if (activeFilteringBuilding.HasElectricity())
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
		}
	}

	public override UIelement GetClosestUIElement(Vector3 worldPosition)
	{
		List<UIelement> list = new List<UIelement>();
		UIelement closestUIElement = inventoryUI.GetClosestUIElement(worldPosition);
		list.Add(closestUIElement);
		if (addNewFilterButton.gameObject.activeSelf)
		{
			list.Add(addNewFilterButton);
		}
		if (removeFilterButton.gameObject.activeSelf)
		{
			list.Add(removeFilterButton);
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
}
