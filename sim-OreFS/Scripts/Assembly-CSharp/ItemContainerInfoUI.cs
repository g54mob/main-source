using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemContainerInfoUI : MonoBehaviour
{
	public enum ContainerType
	{
		Unknown = 0,
		Truck = 1,
		Sack = 2
	}

	[Header("Header References")]
	[SerializeField]
	private Image headerIcon;

	[SerializeField]
	private TextMeshProUGUI headerTitleText;

	[Header("Header Icons")]
	[SerializeField]
	private Sprite truckIcon;

	[SerializeField]
	private Sprite sackIcon;

	[SerializeField]
	private Sprite defaultIcon;

	[Header("References")]
	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private TextMeshProUGUI capacityText;

	[SerializeField]
	private TextMeshProUGUI sackText;

	[SerializeField]
	private Transform itemListParent;

	[SerializeField]
	private GameObject itemRowPrefab;

	[SerializeField]
	private GameObject extraRow;

	private const int MaxVisibleRows = 6;

	[Header("Runtime")]
	private IItemContainer currentContainer;

	private MonoBehaviour currentContainerMono;

	private int lastKnownItemCount = -1;

	private int lastKnownUniqueCount = -1;

	private List<ItemContainerRowUI> itemRows = new List<ItemContainerRowUI>();

	private ContainerType currentContainerType;

	private void Start()
	{
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 0f;
		}
	}

	private void Update()
	{
		if (currentContainerMono == null)
		{
			if (canvasGroup != null && canvasGroup.alpha > 0f)
			{
				Hide();
			}
		}
		else if (currentContainer != null)
		{
			int itemCount = currentContainer.ItemCount;
			if (itemCount > 0 && canvasGroup != null && canvasGroup.alpha < 1f)
			{
				canvasGroup.alpha = 1f;
			}
			int uniqueItemCount = currentContainer.UniqueItemCount;
			if (uniqueItemCount != lastKnownUniqueCount)
			{
				lastKnownUniqueCount = uniqueItemCount;
				lastKnownItemCount = itemCount;
				UpdateItemList();
				UpdateCapacityDisplay();
			}
			else if (itemCount != lastKnownItemCount)
			{
				lastKnownItemCount = itemCount;
				UpdateItemDisplays();
				UpdateCapacityDisplay();
			}
		}
	}

	public void SetTarget(IItemContainer container)
	{
		if (container == null)
		{
			Hide();
			return;
		}
		if (container.ItemCount <= 0)
		{
			Hide();
			return;
		}
		MonoBehaviour containerMono = container as MonoBehaviour;
		if (currentContainer == container)
		{
			if (canvasGroup != null && canvasGroup.alpha < 1f)
			{
				canvasGroup.alpha = 1f;
			}
			int itemCount = container.ItemCount;
			int uniqueItemCount = container.UniqueItemCount;
			if (uniqueItemCount != lastKnownUniqueCount)
			{
				lastKnownUniqueCount = uniqueItemCount;
				lastKnownItemCount = itemCount;
				UpdateItemList();
				UpdateCapacityDisplay();
			}
			else if (itemCount != lastKnownItemCount)
			{
				lastKnownItemCount = itemCount;
				UpdateItemDisplays();
				UpdateCapacityDisplay();
			}
		}
		else
		{
			currentContainer = container;
			currentContainerMono = containerMono;
			lastKnownItemCount = container.ItemCount;
			lastKnownUniqueCount = container.UniqueItemCount;
			DetermineContainerType(containerMono);
			UpdateHeader();
			UpdateCapacityDisplay();
			UpdateItemList();
			if (canvasGroup != null)
			{
				canvasGroup.alpha = 1f;
			}
		}
	}

	public void SetTarget(T_Truck truck)
	{
		currentContainerType = ContainerType.Truck;
		SetTarget((IItemContainer)truck);
	}

	public void SetTarget(T_Sack sack)
	{
		currentContainerType = ContainerType.Sack;
		SetTarget((IItemContainer)sack);
	}

	private void DetermineContainerType(MonoBehaviour containerMono)
	{
		if (containerMono == null)
		{
			currentContainerType = ContainerType.Unknown;
		}
		else if (containerMono is T_Truck)
		{
			currentContainerType = ContainerType.Truck;
		}
		else if (containerMono is T_Sack)
		{
			currentContainerType = ContainerType.Sack;
		}
		else
		{
			currentContainerType = ContainerType.Unknown;
		}
	}

	private void UpdateHeader()
	{
		if (headerIcon != null)
		{
			switch (currentContainerType)
			{
			case ContainerType.Truck:
				headerIcon.sprite = ((truckIcon != null) ? truckIcon : defaultIcon);
				break;
			case ContainerType.Sack:
				headerIcon.sprite = ((sackIcon != null) ? sackIcon : defaultIcon);
				break;
			default:
				headerIcon.sprite = defaultIcon;
				break;
			}
			headerIcon.enabled = headerIcon.sprite != null;
		}
		if (headerTitleText != null)
		{
			string translation = LocalizationManager.GetTranslation(currentContainerType switch
			{
				ContainerType.Truck => "Flatbed Truck", 
				ContainerType.Sack => "Sack", 
				_ => "Item_ContainerName", 
			});
			headerTitleText.text = (string.IsNullOrEmpty(translation) ? currentContainerType.ToString() : translation);
		}
	}

	private void UpdateCapacityDisplay()
	{
		if (currentContainer == null)
		{
			return;
		}
		if (sackText != null)
		{
			if (currentContainerType == ContainerType.Truck && currentContainerMono is T_Truck t_Truck)
			{
				sackText.gameObject.SetActive(value: true);
				sackText.text = $"{t_Truck.SackCount}/{t_Truck.fillVisualObjects.Count}";
			}
			else
			{
				sackText.gameObject.SetActive(value: false);
			}
		}
		if (capacityText != null)
		{
			if (currentContainer.SupportsCapacity)
			{
				capacityText.gameObject.SetActive(value: true);
				capacityText.text = $"{currentContainer.CurrentItemCount}/{currentContainer.TotalCapacity}";
			}
			else
			{
				capacityText.gameObject.SetActive(value: false);
			}
		}
	}

	private void UpdateItemList()
	{
		if (itemListParent == null || itemRowPrefab == null || currentContainer == null)
		{
			return;
		}
		foreach (ItemContainerRowUI itemRow in itemRows)
		{
			if (itemRow != null && itemRow.gameObject != null)
			{
				Object.Destroy(itemRow.gameObject);
			}
		}
		itemRows.Clear();
		Dictionary<string, int> storedItemCounts = currentContainer.GetStoredItemCounts();
		if (ItemSOManager.Instance == null)
		{
			return;
		}
		int num = 0;
		foreach (KeyValuePair<string, int> item in storedItemCounts)
		{
			if (string.IsNullOrEmpty(item.Key) || item.Value <= 0)
			{
				continue;
			}
			T_ItemSO itemSOById = ItemSOManager.Instance.GetItemSOById(item.Key);
			if (itemSOById == null)
			{
				continue;
			}
			if (num < 6)
			{
				ItemContainerRowUI component = Object.Instantiate(itemRowPrefab, itemListParent).GetComponent<ItemContainerRowUI>();
				if (component != null)
				{
					component.Initialize(itemSOById, item.Value);
					itemRows.Add(component);
				}
			}
			num++;
		}
		if (extraRow != null)
		{
			extraRow.SetActive(num > 6);
		}
	}

	private void UpdateItemDisplays()
	{
		if (currentContainer == null)
		{
			return;
		}
		Dictionary<string, int> storedItemCounts = currentContainer.GetStoredItemCounts();
		foreach (ItemContainerRowUI itemRow in itemRows)
		{
			if (!(itemRow == null) && storedItemCounts.TryGetValue(itemRow.ItemId, out var value))
			{
				itemRow.UpdateCount(value);
			}
		}
	}

	public void Hide()
	{
		currentContainer = null;
		currentContainerMono = null;
		lastKnownItemCount = -1;
		lastKnownUniqueCount = -1;
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 0f;
		}
	}

	public bool IsVisible()
	{
		if (canvasGroup != null)
		{
			return canvasGroup.alpha > 0f;
		}
		return false;
	}
}
