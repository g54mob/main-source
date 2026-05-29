using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	[SerializeField]
	private ScrollRect _scroll;

	[SerializeField]
	private RectTransform _inventoryContent;

	[SerializeField]
	private UIInventoryItem _itemPrefab;

	private void OnEnable()
	{
		_inventoryContent.DestroyChildren();
		List<ItemType> list = new List<ItemType>(ItemType.All);
		list.Sort((ItemType a, ItemType b) => (a.Tier == b.Tier) ? (a.Ordinal - b.Ordinal) : (a.Tier - b.Tier));
		float num = 0f;
		float num2 = 0f;
		RectTransform rectTransform = null;
		bool flag = false;
		foreach (ItemType item in list)
		{
			if (GamePlayer.Current.IsItemVisible(item))
			{
				flag = true;
				UIInventoryItem uIInventoryItem = Object.Instantiate(_itemPrefab, _inventoryContent);
				uIInventoryItem.SetItem(item);
				RectTransform rectTransform2 = (RectTransform)uIInventoryItem.transform;
				rectTransform = rectTransform2;
				rectTransform2.anchoredPosition = new Vector2(num, 0f - num2);
				num += rectTransform2.sizeDelta.x + 12f;
				if (num > 1200f)
				{
					num = 0f;
					num2 += rectTransform2.sizeDelta.y + 12f;
					flag = false;
				}
			}
		}
		_inventoryContent.sizeDelta = new Vector2(_inventoryContent.sizeDelta.x, num2 + (flag ? (rectTransform.sizeDelta.y + 22f) : 22f));
	}

	private void Update()
	{
		float y = PlayerControls.TraversalDelta.y;
		if (y != 0f)
		{
			_scroll.verticalNormalizedPosition += y * Time.deltaTime * 2000f / _inventoryContent.sizeDelta.y;
		}
	}

	public void Toggle()
	{
		UISounds.TurnPage();
		base.gameObject.SetActive(!base.gameObject.activeSelf);
		if (base.gameObject.activeSelf)
		{
			GameUI.Construction.gameObject.SetActive(value: false);
			if (OverviewUI.Instance.FullScreenActive)
			{
				OverviewUI.Instance.ToggleBuildMenu(show: false);
			}
		}
	}

	public bool Hide()
	{
		if (base.gameObject.activeSelf)
		{
			Toggle();
			return true;
		}
		return false;
	}
}
