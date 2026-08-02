using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailedReceiptPanel : MonoBehaviour
{
	public Button closeButton;

	public CanvasGroup cg;

	public bool isShowing;

	public GameObject itemContainerObject;

	public GameObject itemObject;

	public Transform itemParents;

	private GameDesignCraftItem lastSelectedCraftItem;

	public VerticalLayoutGroup verticalLayout;

	private float verticalSpacing;

	private void Start()
	{
		closeButton.onClick.AddListener(ShowHidePanel);
		verticalSpacing = verticalLayout.spacing;
	}

	public void InitializePanel(GameDesignCraftItem craftItem)
	{
		foreach (Transform itemParent in itemParents)
		{
			Object.Destroy(itemParent.gameObject);
		}
		lastSelectedCraftItem = craftItem;
		Dictionary<CollectableItemData, int> coreItems = new Dictionary<CollectableItemData, int>();
		CreateTierRecursively(craftItem.collectableItemData, 1, 1, coreItems);
		CreateCoreItemsList(coreItems);
		List<Transform> list = new List<Transform>();
		foreach (Transform itemParent2 in itemParents)
		{
			list.Add(itemParent2);
		}
		for (int num = list.Count - 1; num >= 0; num--)
		{
			list[num].SetAsLastSibling();
		}
		ShowHidePanel();
	}

	private void CreateCoreItemsList(Dictionary<CollectableItemData, int> coreItems)
	{
		if (coreItems.Count == 0)
		{
			return;
		}
		GameObject gameObject = Object.Instantiate(itemContainerObject, itemParents);
		gameObject.GetComponentInChildren<TextMeshProUGUI>().SetText("Total Needed Core Items");
		foreach (KeyValuePair<CollectableItemData, int> coreItem in coreItems)
		{
			GameDesignCraftItem component = Object.Instantiate(itemObject, gameObject.transform).GetComponent<GameDesignCraftItem>();
			CostData cost = new CostData
			{
				item = coreItem.Key,
				cost = coreItem.Value
			};
			component.InitializeCost(cost);
		}
	}

	private void CreateTierRecursively(CollectableItemData data, int currentTier, int multiplier, Dictionary<CollectableItemData, int> coreItems)
	{
		if (data.costData == null || data.costData.Count == 0)
		{
			return;
		}
		GameObject gameObject = Object.Instantiate(itemContainerObject, itemParents);
		gameObject.GetComponentInChildren<TextMeshProUGUI>().SetText("Tier " + currentTier);
		foreach (CostData costDatum in data.costData)
		{
			int num = costDatum.cost * multiplier;
			if (costDatum.item.costData == null || costDatum.item.costData.Count == 0)
			{
				if (coreItems.ContainsKey(costDatum.item))
				{
					coreItems[costDatum.item] += num;
				}
				else
				{
					coreItems[costDatum.item] = num;
				}
			}
			GameDesignCraftItem component = Object.Instantiate(itemObject, gameObject.transform).GetComponent<GameDesignCraftItem>();
			CostData cost = new CostData
			{
				item = costDatum.item,
				cost = num
			};
			component.InitializeCost(cost);
			if (costDatum.item.costData != null && costDatum.item.costData.Count > 0)
			{
				CreateTierRecursively(costDatum.item, currentTier + 1, num, coreItems);
			}
		}
	}

	private void ShowHidePanel()
	{
		isShowing = !isShowing;
		base.gameObject.SetActive(isShowing);
		Canvas.ForceUpdateCanvases();
		verticalLayout.spacing = 0f;
		if (isShowing)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
			cg.DOFade(1f, 0.2f);
			cg.interactable = true;
			cg.blocksRaycasts = true;
		}
		else
		{
			lastSelectedCraftItem.SetInfoPanel();
			cg.alpha = 0f;
			cg.interactable = false;
			cg.blocksRaycasts = false;
		}
		if (isShowing)
		{
			base.gameObject.SetActive(value: true);
		}
		StartCoroutine(DuubyUtilities.WaitForEndOfTheFrame(delegate
		{
			verticalLayout.spacing = verticalSpacing;
		}));
	}
}
