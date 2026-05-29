using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

public class UIInventoryHotbar : MonoBehaviour
{
	public const float UpdateFrequency = 0.5f;

	[SerializeField]
	private UIHotbarItem _itemPrefab;

	private List<UIHotbarItem> _visibleItems = new List<UIHotbarItem>();

	private float _updateTimer;

	public static int MaxItemCount
	{
		get
		{
			if (Screen.width <= 1500)
			{
				return 3;
			}
			return 4;
		}
	}

	public static UIInventoryHotbar Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		List<ItemType> list = new List<ItemType>(GamePlayer.Current.RecentItems);
		list.Reverse();
		foreach (ItemType item in list)
		{
			ItemHandCrafted(item, 0);
		}
	}

	private void Update()
	{
		_updateTimer += Time.deltaTime;
		if (_updateTimer >= 0.5f)
		{
			UpdateRecentItems();
			_updateTimer = 0f;
		}
	}

	public void ItemHandCrafted(ItemType type, int count)
	{
		foreach (UIHotbarItem visibleItem in _visibleItems)
		{
			if (visibleItem.Contained == type)
			{
				UpdateRecentItems();
				return;
			}
		}
		while (_visibleItems.Count >= MaxItemCount)
		{
			Object.Destroy(_visibleItems[0].gameObject);
			_visibleItems.RemoveAt(0);
		}
		UIHotbarItem uIHotbarItem = Object.Instantiate(_itemPrefab, base.transform);
		uIHotbarItem.SetContainedItem(type);
		_visibleItems.Add(uIHotbarItem);
		UpdateRecentItems();
	}

	public void UpdateRecentItems()
	{
		List<ItemType> list = new List<ItemType>();
		float num = 10f;
		foreach (UIHotbarItem visibleItem in _visibleItems)
		{
			visibleItem.UpdateItem();
			list.Add(visibleItem.Contained);
			RectTransform rectTransform = visibleItem.transform as RectTransform;
			rectTransform.anchoredPosition = new Vector2(0f - num, 0f);
			num += rectTransform.sizeDelta.x + 24f;
		}
		GamePlayer.Current.RecentItems = list;
	}
}
