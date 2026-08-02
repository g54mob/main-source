using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearcheableUIItem : MonoBehaviour
{
	[Header("Item Info")]
	[SerializeField]
	private TextMeshProUGUI itemNameText;

	[SerializeField]
	private TextMeshProUGUI itemDescriptionText;

	[SerializeField]
	private Image itemImage;

	[SerializeField]
	private Button learnButton;

	[SerializeField]
	private GameObject learnedPanel;

	[Header("Cost Materials")]
	public List<CraftNeededPartUI> craftNeededPartUIs = new List<CraftNeededPartUI>();

	[HideInInspector]
	public CollectableItemData collectableItemData;

	private List<CostData> neededItemsData = new List<CostData>();

	private PlayerInventory playerInventory;

	private bool isSet;

	private ItemInfoHover itemInfoHover;

	private void Awake()
	{
		if (itemImage != null)
		{
			itemInfoHover = itemImage.GetComponent<ItemInfoHover>();
			if (itemInfoHover == null)
			{
				itemInfoHover = itemImage.gameObject.AddComponent<ItemInfoHover>();
			}
		}
	}

	public void SetPanel()
	{
		if (playerInventory == null && TrainGameManager.Instance != null && TrainGameManager.Instance.mainPlayer != null)
		{
			playerInventory = TrainGameManager.Instance.mainPlayer.GetComponent<PlayerInventory>();
		}
		learnButton.onClick.RemoveAllListeners();
		learnButton.onClick.AddListener(Learn);
		neededItemsData.Clear();
		SetItemInfo();
		int num = 0;
		List<CostData> costData = collectableItemData.costData;
		foreach (CraftNeededPartUI craftNeededPartUI in craftNeededPartUIs)
		{
			if (num >= costData.Count)
			{
				craftNeededPartUI.gameObject.SetActive(value: true);
				craftNeededPartUI.SetNull();
			}
			else
			{
				craftNeededPartUI.gameObject.SetActive(value: true);
				CostData costData2 = costData[num];
				neededItemsData.Add(costData2);
				int inventoryCount = GetInventoryCount(costData2.item);
				craftNeededPartUI.SetPanel(costData2, inventoryCount);
			}
			num++;
		}
		isSet = true;
		CheckResearchStatus();
	}

	private void Update()
	{
		if (isSet)
		{
			CheckResearchStatus();
		}
	}

	private int GetInventoryCount(CollectableItemData item)
	{
		if (playerInventory == null || item == null)
		{
			return 0;
		}
		return playerInventory.inventoryData.Find((PlayerInventoryData x) => x.item == item)?.itemCollectedCount ?? 0;
	}

	public void SetItemInfo()
	{
		if (!(collectableItemData == null))
		{
			itemImage.sprite = collectableItemData.itemImage;
			SetTextWithFontSwitcher(itemNameText, collectableItemData.GetLocalizedDisplayName());
			if (itemDescriptionText != null)
			{
				SetTextWithFontSwitcher(itemDescriptionText, collectableItemData.GetLocalizedDescription());
			}
			if (itemInfoHover != null)
			{
				itemInfoHover.SetItemData(collectableItemData);
			}
		}
	}

	public void CheckResearchStatus()
	{
		if (collectableItemData == null)
		{
			return;
		}
		if (playerInventory == null && TrainGameManager.Instance != null && TrainGameManager.Instance.mainPlayer != null)
		{
			playerInventory = TrainGameManager.Instance.mainPlayer.GetComponent<PlayerInventory>();
		}
		bool interactable = true;
		for (int i = 0; i < neededItemsData.Count && i < craftNeededPartUIs.Count; i++)
		{
			if (craftNeededPartUIs[i].gameObject.activeInHierarchy)
			{
				CostData costData = neededItemsData[i];
				int inventoryCount = GetInventoryCount(costData.item);
				craftNeededPartUIs[i].SetPanel(costData, inventoryCount);
				if (inventoryCount < costData.cost)
				{
					interactable = false;
				}
			}
		}
		if (collectableItemData.isLearned)
		{
			learnedPanel.SetActive(value: true);
			learnButton.gameObject.SetActive(value: false);
		}
		else
		{
			learnedPanel.SetActive(value: false);
			learnButton.gameObject.SetActive(value: true);
			learnButton.interactable = interactable;
		}
	}

	private void Learn()
	{
		if (collectableItemData == null)
		{
			return;
		}
		if (playerInventory == null && TrainGameManager.Instance != null && TrainGameManager.Instance.mainPlayer != null)
		{
			playerInventory = TrainGameManager.Instance.mainPlayer.GetComponent<PlayerInventory>();
		}
		if (playerInventory == null)
		{
			return;
		}
		if (!(TrainGameManager.Instance != null) || TrainGameManager.Instance.currentGameMode != GameMode.Creative)
		{
			foreach (CostData neededItemsDatum in neededItemsData)
			{
				if (GetInventoryCount(neededItemsDatum.item) < neededItemsDatum.cost)
				{
					return;
				}
			}
			foreach (CostData neededItemsDatum2 in neededItemsData)
			{
				playerInventory.AddItemInventory(neededItemsDatum2.item, -neededItemsDatum2.cost);
			}
		}
		collectableItemData.isLearned = true;
		CollectableDataSaver.Instance?.SetItemLearned(collectableItemData.itemName, learned: true);
		if (NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySound2DLocal(GameAudios.GeneralCraftSound);
		}
		CheckResearchStatus();
		if (ResearchUIManager.Instance != null)
		{
			ResearchUIManager.Instance.UpdateReseachStatus();
		}
	}

	private void SetTextWithFontSwitcher(TMP_Text tmpText, string text)
	{
		DynamicFontSwitcher component = tmpText.GetComponent<DynamicFontSwitcher>();
		if (component != null)
		{
			component.SetText(text);
		}
		else
		{
			tmpText.SetText(text);
		}
	}
}
