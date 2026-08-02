using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchSystemCategorizer : MonoBehaviour
{
	public Image categoryImage;

	public Button categoryButton;

	public Image selectedBg;

	public List<CollectableItemData> researchObjects = new List<CollectableItemData>();

	[Header("Category Unlock")]
	public string categoryName;

	public bool isUnlockedByDefault;

	public List<CostData> unlockCostData = new List<CostData>();

	[HideInInspector]
	public bool isUnlocked;

	private ResearchUIManager researchManager;

	private void Start()
	{
		researchManager = Object.FindObjectOfType<ResearchUIManager>();
		categoryButton.onClick.AddListener(OpenItems);
		if (isUnlockedByDefault)
		{
			isUnlocked = true;
		}
	}

	private void OpenItems()
	{
		if (researchManager != null)
		{
			ResearchSystemCategorizer[] componentsInChildren = researchManager.GetComponentsInChildren<ResearchSystemCategorizer>();
			foreach (ResearchSystemCategorizer researchSystemCategorizer in componentsInChildren)
			{
				if (researchSystemCategorizer != null)
				{
					researchSystemCategorizer.SetSelected(selected: false);
				}
			}
		}
		researchManager.lastCategorizer = this;
		SetSelected(selected: true);
		if (!isUnlocked)
		{
			researchManager.ShowUnlockPanel(this);
			return;
		}
		researchManager.HideUnlockPanel();
		researchManager.SetCategoryItems(researchObjects);
	}

	public void SetSelected(bool selected)
	{
		if (selectedBg == null)
		{
			return;
		}
		if (selected)
		{
			if (researchManager != null)
			{
				selectedBg.color = researchManager.selectedButtonColor;
			}
		}
		else if (researchManager != null)
		{
			selectedBg.color = researchManager.buttonNormalColor;
		}
	}

	private void SetCategoryItemInfo(CollectableItemData collectableData, GameObject uiItem)
	{
		uiItem.GetComponent<ResearcheableUIItem>().collectableItemData = collectableData;
	}
}
