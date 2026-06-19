using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class BossStatueUI : SimpleCraftingUI
{
	public List<SpriteRenderer> emissiveLines;

	private float emissiveAlpha;

	private bool isActivated => (inventoryUI.firstSlot as BossStatueSlotUI).HasObject();

	protected override void Awake()
	{
		recipeUI.Init();
		inventoryUI.Init();
		root.SetActive(value: false);
	}

	public override void ShowCraftingUI()
	{
		base.ShowCraftingUI();
		inventoryUI.ShowContainerUI();
		emissiveAlpha = (isActivated ? 1f : 0f);
		UpdateLinesEmissiveness();
	}

	private void Update()
	{
		if (root.activeInHierarchy)
		{
			emissiveAlpha = Mathf.Clamp01(isActivated ? (emissiveAlpha + Time.deltaTime) : 0f);
			UpdateLinesEmissiveness();
		}
	}

	public override void UpdateAllCraftingUI(bool autoFillMaterials = false)
	{
		for (int i = 0; i < recipeUI.totalVisibleSlots; i++)
		{
			recipeUI.OnSlotUpdated(i);
		}
		for (int j = 0; j < inventoryUI.totalVisibleSlots; j++)
		{
			inventoryUI.OnSlotUpdated(j);
		}
	}

	private void UpdateLinesEmissiveness()
	{
		foreach (SpriteRenderer emissiveLine in emissiveLines)
		{
			emissiveLine.SetAlpha(emissiveAlpha);
		}
	}
}
