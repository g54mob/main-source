using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasReceiptPanel : MonoBehaviour
{
	public GameObject receiptTablePanel;

	public GameObject neededCraftTablePanel;

	public GameObject itemObject;

	public TextMeshProUGUI gameDesignDescription;

	public Button openDetailedCanvasButton;

	public GameDesignCraftItem currentCraftItem;

	private void Start()
	{
		openDetailedCanvasButton.onClick.AddListener(OpenDetailedPanel);
	}

	public void Initialize(GameDesignCraftItem gameDesignCraftItem)
	{
		currentCraftItem = gameDesignCraftItem;
		CollectableItemData collectableItemData = gameDesignCraftItem.collectableItemData;
		foreach (Transform item in receiptTablePanel.transform)
		{
			Object.Destroy(item.gameObject);
		}
		foreach (CostData costDatum in collectableItemData.costData)
		{
			GameDesignCraftItem component = Object.Instantiate(itemObject, receiptTablePanel.transform).GetComponent<GameDesignCraftItem>();
			if (component != null)
			{
				component.InitializeCost(costDatum);
			}
		}
		foreach (Transform item2 in neededCraftTablePanel.transform)
		{
			Object.Destroy(item2.gameObject);
		}
		foreach (CollectableItemData item3 in collectableItemData.neededCraftingTable)
		{
			GameDesignCraftItem component2 = Object.Instantiate(itemObject, neededCraftTablePanel.transform).GetComponent<GameDesignCraftItem>();
			if (component2 != null)
			{
				component2.Initialize(item3);
			}
		}
		if (collectableItemData.costData.Count > 0)
		{
			openDetailedCanvasButton.gameObject.SetActive(value: true);
		}
		else
		{
			openDetailedCanvasButton.gameObject.SetActive(value: false);
		}
		gameDesignDescription.text = collectableItemData.itemDescription;
	}

	public void OpenDetailedPanel()
	{
		Object.FindObjectOfType<DetailedReceiptPanel>(includeInactive: true).InitializePanel(currentCraftItem);
	}
}
