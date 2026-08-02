using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInfoHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private CollectableItemData itemData;

	[SerializeField]
	private bool useImagePanel;

	private bool isHovering;

	private static ItemInfoPanel cachedInfoPanel;

	private static bool hasSearchedForPanel;

	public CollectableItemData ItemData
	{
		get
		{
			return itemData;
		}
		set
		{
			itemData = value;
		}
	}

	public bool UseImagePanel
	{
		get
		{
			return useImagePanel;
		}
		set
		{
			useImagePanel = value;
		}
	}

	private static ItemInfoPanel GetInfoPanel()
	{
		if (!hasSearchedForPanel)
		{
			cachedInfoPanel = Object.FindObjectOfType<ItemInfoPanel>(includeInactive: true);
			hasSearchedForPanel = true;
		}
		return cachedInfoPanel;
	}

	public static void ClearCache()
	{
		cachedInfoPanel = null;
		hasSearchedForPanel = false;
	}

	private void Update()
	{
		if (!isHovering || !(itemData != null))
		{
			return;
		}
		if (!Cursor.visible)
		{
			isHovering = false;
			ItemInfoPanel infoPanel = GetInfoPanel();
			if (infoPanel != null)
			{
				infoPanel.HidePanel();
			}
		}
		else
		{
			ItemInfoPanel infoPanel2 = GetInfoPanel();
			if (infoPanel2 != null && infoPanel2.infoParent != null)
			{
				infoPanel2.infoParent.position = GetAdjustedPosition(infoPanel2.infoParent as RectTransform);
			}
		}
	}

	private Vector2 GetAdjustedPosition(RectTransform panelRect)
	{
		Vector2 vector = Input.mousePosition;
		if (panelRect == null)
		{
			return vector;
		}
		float num = panelRect.rect.width * panelRect.lossyScale.x;
		float num2 = panelRect.rect.height * panelRect.lossyScale.y;
		float num3 = 10f;
		float num4 = 10f;
		Vector2 result = vector;
		if (vector.x + num + num3 > (float)Screen.width)
		{
			result.x = vector.x - num - num3;
		}
		else
		{
			result.x = vector.x + num3;
		}
		if (vector.y + num2 + num4 > (float)Screen.height)
		{
			result.y = vector.y - num4;
		}
		else
		{
			result.y = vector.y + num4;
		}
		if (result.y - num2 < 0f)
		{
			result.y = num2;
		}
		if (result.x < 0f)
		{
			result.x = num3;
		}
		return result;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (itemData == null || !Cursor.visible)
		{
			return;
		}
		isHovering = true;
		ItemInfoPanel infoPanel = GetInfoPanel();
		if (infoPanel != null)
		{
			if (useImagePanel && itemData.itemImage != null)
			{
				infoPanel.SetPanel(itemData.GetLocalizedDisplayName(), itemData.GetLocalizedDescription(), itemData.itemImage);
			}
			else
			{
				infoPanel.SetPanel(itemData.GetLocalizedDisplayName(), itemData.GetLocalizedDescription());
			}
			infoPanel.ShowPanel();
			if (infoPanel.infoParent != null)
			{
				infoPanel.infoParent.position = GetAdjustedPosition(infoPanel.infoParent as RectTransform);
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isHovering = false;
		ItemInfoPanel infoPanel = GetInfoPanel();
		if (infoPanel != null)
		{
			infoPanel.HidePanel();
		}
	}

	public void SetItemData(CollectableItemData data)
	{
		itemData = data;
	}

	private void OnDisable()
	{
		if (isHovering)
		{
			ItemInfoPanel infoPanel = GetInfoPanel();
			if (infoPanel != null)
			{
				infoPanel.HidePanel();
			}
			isHovering = false;
		}
	}
}
