using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSystemCategorizer : MonoBehaviour
{
	public Button categoryButton;

	public Image selectedBg;

	public List<CollectableItemData> itemDatas = new List<CollectableItemData>();

	public CraftPanelType panelType;

	private GunPanelUIManager gunPanelUIManager;

	private CraftPanelUIManager craftingManager;

	private ChemistryTableUIManager chemistryManager;

	private void Start()
	{
		craftingManager = Object.FindObjectOfType<CraftPanelUIManager>();
		gunPanelUIManager = Object.FindObjectOfType<GunPanelUIManager>();
		chemistryManager = Object.FindObjectOfType<ChemistryTableUIManager>();
		categoryButton.onClick.AddListener(OpenItems);
	}

	private void OpenItems()
	{
		switch (panelType)
		{
		case CraftPanelType.Craft:
			DeselectAllCategories(craftingManager.mainCraftCategories);
			DeselectAllCategories(craftingManager.simpleCraftCategories);
			DeselectAllCategories(craftingManager.gunCraftCategories);
			craftingManager.lastCagegorizer = this;
			craftingManager.SetCategoryItems(itemDatas);
			SetSelected(selected: true);
			break;
		case CraftPanelType.Weapon:
			if (gunPanelUIManager != null && gunPanelUIManager.mainCraftCategories != null)
			{
				DeselectAllCategories(gunPanelUIManager.mainCraftCategories);
			}
			gunPanelUIManager.lastCagegorizer = this;
			gunPanelUIManager.SetCategoryItems(itemDatas);
			SetSelected(selected: true);
			break;
		case CraftPanelType.Chemistry:
			if (chemistryManager != null && chemistryManager.receiptCategories != null)
			{
				DeselectAllCategories(chemistryManager.receiptCategories);
			}
			chemistryManager.lastCategorizer = this;
			chemistryManager.SetCategoryItems(itemDatas);
			SetSelected(selected: true);
			break;
		}
	}

	private void DeselectAllCategories(List<CraftSystemCategorizer> categories)
	{
		if (categories == null)
		{
			return;
		}
		foreach (CraftSystemCategorizer category in categories)
		{
			if (category != null)
			{
				category.SetSelected(selected: false);
			}
		}
	}

	public void SetSelected(bool selected)
	{
		if (selectedBg == null)
		{
			return;
		}
		if (selected)
		{
			if (craftingManager != null)
			{
				selectedBg.color = craftingManager.selectedButtonColor;
			}
			else if (gunPanelUIManager != null)
			{
				selectedBg.color = gunPanelUIManager.selectedButtonColor;
			}
			else if (chemistryManager != null)
			{
				selectedBg.color = chemistryManager.selectedButtonColor;
			}
		}
		else if (craftingManager != null)
		{
			selectedBg.color = craftingManager.buttonNormalColor;
		}
		else if (gunPanelUIManager != null)
		{
			selectedBg.color = gunPanelUIManager.buttonNormalColor;
		}
		else if (chemistryManager != null)
		{
			selectedBg.color = chemistryManager.buttonNormalColor;
		}
	}
}
