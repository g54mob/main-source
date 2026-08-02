using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildItemUI : MonoBehaviour
{
	public CollectableItemData buildObjectData;

	public int craftingCount = 1;

	public Button craftButton;

	public List<CraftNeededPartUI> craftNeededPartUIs = new List<CraftNeededPartUI>();

	private PlayerInventory inventory;

	public Image itemSprite;

	public TextMeshProUGUI itemNameText;

	public TextMeshProUGUI itemDescriptionText;

	public List<CostData> neededItemsData = new List<CostData>();

	private bool isSet;

	private ObjectBuilderUIManager builderManager;

	private ItemInfoHover itemInfoHover;

	private void Awake()
	{
		if (itemSprite != null)
		{
			itemInfoHover = itemSprite.GetComponent<ItemInfoHover>();
			if (itemInfoHover == null)
			{
				itemInfoHover = itemSprite.gameObject.AddComponent<ItemInfoHover>();
			}
			itemInfoHover.UseImagePanel = true;
		}
	}

	private void Start()
	{
		builderManager = GetComponentInParent<ObjectBuilderUIManager>();
		craftButton.onClick.AddListener(Build);
	}

	public void SetNeededsPart(CollectableItemData collectableItem)
	{
		inventory = TrainGameManager.Instance.mainPlayer.GetComponent<PlayerInventory>();
		neededItemsData.Clear();
		int num = 0;
		List<CostData> costData = collectableItem.costData;
		itemSprite.sprite = collectableItem.itemImage;
		SetTextWithFontSwitcher(itemNameText, collectableItem.GetLocalizedDisplayName());
		SetTextWithFontSwitcher(itemDescriptionText, collectableItem.GetLocalizedDescription());
		craftingCount = collectableItem.craftingCount;
		if (itemInfoHover != null)
		{
			itemInfoHover.SetItemData(collectableItem);
		}
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
				CostData currentData = costData[num];
				neededItemsData.Add(currentData);
				int inventoryCount = inventory.inventoryData.Find((PlayerInventoryData x) => currentData.item == x.item)?.itemCollectedCount ?? 0;
				craftNeededPartUI.SetPanel(currentData, inventoryCount);
			}
			num++;
		}
		isSet = true;
		CheckCraft();
	}

	private void Update()
	{
		if (isSet)
		{
			CheckCraft();
		}
	}

	public void CheckCraft()
	{
		if (inventory == null || neededItemsData.Count == 0)
		{
			craftButton.interactable = false;
			return;
		}
		if (TrainGameManager.Instance != null && TrainGameManager.Instance.currentGameMode == GameMode.Creative)
		{
			craftButton.interactable = true;
			for (int i = 0; i < neededItemsData.Count && i < craftNeededPartUIs.Count; i++)
			{
				if (craftNeededPartUIs[i].gameObject.activeInHierarchy)
				{
					CostData currentData = neededItemsData[i];
					int inventoryCount = inventory.inventoryData.Find((PlayerInventoryData x) => currentData.item == x.item)?.itemCollectedCount ?? 0;
					craftNeededPartUIs[i].SetPanel(currentData, inventoryCount);
				}
			}
			return;
		}
		bool interactable = true;
		for (int num = 0; num < neededItemsData.Count && num < craftNeededPartUIs.Count; num++)
		{
			if (craftNeededPartUIs[num].gameObject.activeInHierarchy)
			{
				CostData currentData2 = neededItemsData[num];
				int inventoryCount2 = inventory.inventoryData.Find((PlayerInventoryData x) => currentData2.item == x.item)?.itemCollectedCount ?? 0;
				craftNeededPartUIs[num].SetPanel(currentData2, inventoryCount2);
			}
		}
		foreach (CostData neededItem in neededItemsData)
		{
			if ((inventory.inventoryData.Find((PlayerInventoryData x) => neededItem.item == x.item)?.itemCollectedCount ?? 0) < neededItem.cost)
			{
				interactable = false;
				break;
			}
		}
		craftButton.interactable = interactable;
	}

	private void Build()
	{
		Debug.Log(string.Format("[Wagon] Build called. buildObjectData: {0}, wagonItemData: {1}, same: {2}", (buildObjectData != null) ? buildObjectData.itemName : "NULL", (builderManager.wagonItemData != null) ? builderManager.wagonItemData.itemName : "NULL", buildObjectData == builderManager.wagonItemData));
		if (builderManager.wagonItemData != null && buildObjectData == builderManager.wagonItemData)
		{
			if (TrainGameManager.Instance == null || TrainGameManager.Instance.currentGameMode != GameMode.Creative)
			{
				foreach (CostData neededItemsDatum in neededItemsData)
				{
					inventory.AddItemInventory(neededItemsDatum.item, -neededItemsDatum.cost);
				}
			}
			Debug.Log("[Wagon] Wagon item matched! Adding wagon to train...");
			if (TrainBuildManager.Instance != null)
			{
				Debug.Log("[Wagon] Calling CmdRequestAddWagon with data: " + buildObjectData.itemName);
				TrainBuildManager.Instance.CmdRequestAddWagon(buildObjectData.itemName);
			}
			else
			{
				Debug.LogError("[Wagon] TrainBuildManager is NULL! Cannot add wagon.");
			}
			builderManager.ChangePanelActive();
			Singleton<MainUIManager>.Instance.OnInGamePanelClosed.Invoke(builderManager);
			return;
		}
		builderManager.ChangePanelActive();
		Singleton<MainUIManager>.Instance.OnInGamePanelClosed.Invoke(builderManager);
		PipePlacementController pipePlacementController = Object.FindObjectOfType<PipePlacementController>();
		if (pipePlacementController != null && pipePlacementController.IsActive)
		{
			pipePlacementController.Deactivate();
		}
		if (buildObjectData.itemType == ItemType.Pipe)
		{
			if (pipePlacementController != null)
			{
				pipePlacementController.ActivateFromBuildUI(buildObjectData);
			}
			return;
		}
		GrabbableObject component = Object.Instantiate(buildObjectData.itemPrefab).GetComponent<GrabbableObject>();
		component.buildObjectData = buildObjectData;
		Grabber component2 = TrainGameManager.Instance.mainPlayer.GetComponent<Grabber>();
		component.transform.position = component2.transform.position + Camera.main.transform.forward * 5f;
		component2.GrabObject(component, isRemoved: false, skipBuildModeChangeEvent: false, fromBuildMenu: true);
		TrainGameManager.Instance.mainPlayer.GetComponent<TSPlayerController>().ActivateBuildSystem(active: true);
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
