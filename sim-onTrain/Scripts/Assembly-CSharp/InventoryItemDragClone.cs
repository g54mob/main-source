using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDragClone : MonoBehaviour
{
	[SerializeField]
	private Image itemImage;

	[SerializeField]
	private TextMeshProUGUI itemCountText;

	[SerializeField]
	private GameObject countRect;

	private CollectableItemData currentItem;

	private int currentCount;

	public void Initialize(CollectableItemData item, int count)
	{
		currentItem = item;
		currentCount = count;
		if (itemImage != null && item != null)
		{
			itemImage.sprite = item.itemImage;
			itemImage.enabled = true;
		}
		else if (itemImage != null)
		{
			itemImage.enabled = false;
		}
		UpdateItemCount(count);
		if (countRect != null)
		{
			countRect.SetActive(count > 1);
		}
	}

	public void SetSizeFromSource(RectTransform sourceRect)
	{
		RectTransform component = GetComponent<RectTransform>();
		if (component != null && sourceRect != null)
		{
			component.sizeDelta = sourceRect.sizeDelta;
			component.anchorMin = sourceRect.anchorMin;
			component.anchorMax = sourceRect.anchorMax;
			component.pivot = sourceRect.pivot;
			component.localScale = sourceRect.localScale;
		}
	}

	public void UpdateItemCount(int newCount)
	{
		currentCount = newCount;
		if (itemCountText != null)
		{
			itemCountText.text = newCount.ToString();
		}
		if (countRect != null)
		{
			countRect.SetActive(newCount > 1);
		}
	}

	public void UpdatePosition(Vector3 position)
	{
		base.transform.position = position;
	}

	public void DestroyClone()
	{
		if (base.gameObject != null)
		{
			Object.Destroy(base.gameObject);
		}
	}

	public CollectableItemData GetCurrentItem()
	{
		return currentItem;
	}

	public int GetCurrentCount()
	{
		return currentCount;
	}

	public void SetAlpha(float alpha)
	{
		CanvasGroup component = GetComponent<CanvasGroup>();
		if (component != null)
		{
			component.alpha = alpha;
		}
	}

	public void SetRaycastBlocking(bool blocksRaycasts)
	{
		CanvasGroup component = GetComponent<CanvasGroup>();
		if (component != null)
		{
			component.blocksRaycasts = blocksRaycasts;
		}
	}
}
