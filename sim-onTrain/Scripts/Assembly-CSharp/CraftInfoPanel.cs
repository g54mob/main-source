using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class CraftInfoPanel : UIPanelBase
{
	public List<CraftNeededPartUI> craftNeededITems = new List<CraftNeededPartUI>();

	public Button craftButton;

	private PlayerInventory inventory;

	private CollectableItemData lastCollectableItemData;

	private void Start()
	{
		craftNeededITems = GetComponentsInChildren<CraftNeededPartUI>(includeInactive: true).ToList();
		craftButton.onClick.AddListener(Craft);
	}

	private void OnEnable()
	{
		inventory = TrainGameManager.Instance.mainPlayer.GetComponent<PlayerInventory>();
		inventory.OnCollectableCollected.AddListener(delegate
		{
			SetPanel();
		});
	}

	private void OnDisable()
	{
		inventory.OnCollectableCollected.RemoveListener(delegate
		{
			SetPanel();
		});
	}

	public new void ShowPanel()
	{
		base.ShowPanel();
	}

	public new void HidePanel()
	{
		base.HidePanel();
	}

	public void SetPanel(CollectableItemData buildObjectData = null)
	{
		if (buildObjectData == null && lastCollectableItemData == null)
		{
			return;
		}
		if (buildObjectData == null)
		{
			buildObjectData = lastCollectableItemData;
		}
		lastCollectableItemData = buildObjectData;
		craftButton.interactable = false;
		bool interactable = true;
		int i;
		for (i = 0; i < buildObjectData.costData.Count; i++)
		{
			CraftNeededPartUI craftNeededPartUI = craftNeededITems[i];
			craftNeededPartUI.gameObject.SetActive(value: true);
			PlayerInventoryData playerInventoryData = inventory.inventoryData.Find((PlayerInventoryData x) => buildObjectData.costData[i].item == x.item);
			craftNeededPartUI.SetPanel(buildObjectData.costData[i], playerInventoryData.itemCollectedCount);
			if (buildObjectData.costData[i].cost > playerInventoryData.itemCollectedCount)
			{
				interactable = false;
			}
		}
		craftButton.interactable = interactable;
		for (int num = buildObjectData.costData.Count; num < craftNeededITems.Count; num++)
		{
			craftNeededITems[num].gameObject.SetActive(value: false);
		}
	}

	private void Craft()
	{
		CollectableItemData collectableItemData = lastCollectableItemData;
		for (int i = 0; i < collectableItemData.costData.Count; i++)
		{
			inventory.AddItemInventory(collectableItemData.costData[i].item, -collectableItemData.costData[i].cost);
		}
		inventory.AddItemInventory(lastCollectableItemData, lastCollectableItemData.craftingCount, lastCollectableItemData.startDurability);
		SetPanel(collectableItemData);
	}
}
