using System.Collections.Generic;
using Michsky.MUIP;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameDesignCanvas : MonoBehaviour
{
	public List<GameDesignCategory> itemLists = new List<GameDesignCategory>();

	public GameObject itemContainerObject;

	public GameObject itemObject;

	public Transform itemParents;

	public Button detailsButton;

	public PieChart pieChart;

	private CollectableItemData lastSelectedCollectable;

	private void Start()
	{
		SetupCanvas();
		SetupPieChart();
	}

	public void SetupCanvas()
	{
		foreach (GameDesignCategory itemList in itemLists)
		{
			GameObject gameObject = Object.Instantiate(itemContainerObject, itemParents);
			gameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(itemList.categoryName);
			foreach (CollectableItemData item in itemList.items)
			{
				Object.Instantiate(itemObject, gameObject.transform).GetComponent<GameDesignCraftItem>().Initialize(item);
			}
		}
	}

	public void SetupPieChart()
	{
		if (pieChart == null)
		{
			return;
		}
		pieChart.chartData.Clear();
		Dictionary<CollectableItemData, int> dictionary = new Dictionary<CollectableItemData, int>();
		foreach (GameDesignCategory itemList in itemLists)
		{
			foreach (CollectableItemData item in itemList.items)
			{
				HashSet<CollectableItemData> visited = new HashSet<CollectableItemData>();
				CollectCoreItemsRecursively(item, 1, dictionary, visited);
			}
		}
		int num = 0;
		foreach (KeyValuePair<CollectableItemData, int> item2 in dictionary)
		{
			pieChart.AddNewItem();
			int index = pieChart.chartData.Count - 1;
			pieChart.chartData[index].name = item2.Key.itemDisplayName;
			pieChart.chartData[index].value = item2.Value;
			pieChart.chartData[index].color = GetColorByIndex(num);
			num++;
		}
		if (pieChart.indicatorParent != null && pieChart.indicatorParent.childCount >= 2)
		{
			Object.DestroyImmediate(pieChart.indicatorParent.GetChild(0).gameObject);
			Object.DestroyImmediate(pieChart.indicatorParent.GetChild(0).gameObject);
		}
		pieChart.UpdateIndicators();
		pieChart.enabled = false;
		pieChart.enabled = true;
	}

	private void CollectCoreItemsRecursively(CollectableItemData data, int multiplier, Dictionary<CollectableItemData, int> coreItems, HashSet<CollectableItemData> visited)
	{
		if (visited.Contains(data))
		{
			return;
		}
		visited.Add(data);
		if (data.costData == null || data.costData.Count == 0)
		{
			visited.Remove(data);
			return;
		}
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
			else
			{
				CollectCoreItemsRecursively(costDatum.item, num, coreItems, visited);
			}
		}
		visited.Remove(data);
	}

	private Color32 GetColorByIndex(int index)
	{
		Color32[] array = new Color32[10]
		{
			new Color32(byte.MaxValue, 0, 0, byte.MaxValue),
			new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue),
			new Color32(byte.MaxValue, 165, 0, byte.MaxValue),
			new Color32(0, 0, byte.MaxValue, byte.MaxValue),
			new Color32(128, 0, 128, byte.MaxValue),
			new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue),
			new Color32(0, byte.MaxValue, 0, byte.MaxValue),
			new Color32(byte.MaxValue, 20, 147, byte.MaxValue),
			new Color32(139, 69, 19, byte.MaxValue),
			new Color32(105, 105, 105, byte.MaxValue)
		};
		return array[index % array.Length];
	}
}
