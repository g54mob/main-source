using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildCategorizer : MonoBehaviour
{
	public Image categoryImage;

	public Button categoryButton;

	public Image selectedBg;

	public List<CollectableItemData> buildingObjects = new List<CollectableItemData>();

	private ObjectBuilderUIManager buildManager;

	private void Start()
	{
		buildManager = Object.FindObjectOfType<ObjectBuilderUIManager>();
		categoryButton.onClick.AddListener(OpenItems);
	}

	private void OpenItems()
	{
		if (buildManager != null)
		{
			BuildCategorizer[] componentsInChildren = buildManager.GetComponentsInChildren<BuildCategorizer>();
			foreach (BuildCategorizer buildCategorizer in componentsInChildren)
			{
				if (buildCategorizer != null)
				{
					buildCategorizer.SetSelected(selected: false);
				}
			}
		}
		buildManager.lastCagegorizer = this;
		buildManager.SetCategoryItems(buildingObjects);
		SetSelected(selected: true);
	}

	public void SetSelected(bool selected)
	{
		if (selectedBg == null)
		{
			return;
		}
		if (selected)
		{
			if (buildManager != null)
			{
				selectedBg.color = buildManager.selectedButtonColor;
			}
		}
		else if (buildManager != null)
		{
			selectedBg.color = buildManager.buttonNormalColor;
		}
	}
}
