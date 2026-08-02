using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameDesignCraftItem : MonoBehaviour
{
	public bool isOnReceipt;

	public TextMeshProUGUI itemName;

	public TextMeshProUGUI countText;

	public CollectableItemData collectableItemData;

	public GameObject itemCountBG;

	public Image bg;

	public Image itemIcon;

	public Button button;

	public Color selectedColor;

	public string itemDescription;

	private void Start()
	{
		button.onClick.AddListener(SetInfoPanel);
	}

	public void Initialize(CollectableItemData data)
	{
		isOnReceipt = false;
		collectableItemData = data;
		itemName.text = data.name;
		itemIcon.sprite = collectableItemData.itemImage;
		itemDescription = collectableItemData.itemDescription;
	}

	public void InitializeCost(CostData cost)
	{
		isOnReceipt = true;
		collectableItemData = cost.item;
		itemName.text = cost.item.name;
		itemCountBG.SetActive(value: true);
		countText.SetText(cost.cost.ToString());
		itemIcon.sprite = collectableItemData.itemImage;
		itemDescription = collectableItemData.itemDescription;
	}

	public void SetInfoPanel()
	{
		Object.FindObjectOfType<CanvasReceiptPanel>().Initialize(this);
		GameDesignCraftItem[] array = Object.FindObjectsOfType<GameDesignCraftItem>();
		foreach (GameDesignCraftItem gameDesignCraftItem in array)
		{
			if (gameDesignCraftItem.isOnReceipt == isOnReceipt)
			{
				gameDesignCraftItem.bg.color = Color.white;
			}
		}
		bg.color = selectedColor;
	}
}
