using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIComplexList : MonoBehaviour, IScrollHandler, IEventSystemHandler
{
	public float Padding = 2f;

	public float ScrollSpeed = 32f;

	public bool MultiSelect;

	public bool CanDeselect = true;

	public bool CanSelectHidden;

	public ComplexListItem ItemPrefab;

	public RectTransform ContentPanel;

	public Scrollbar Scroll;

	[NonSerialized]
	private List<ComplexListItem> _listItems = new List<ComplexListItem>();

	[NonSerialized]
	private List<ComplexListItem> _listItemPool = new List<ComplexListItem>();

	[NonSerialized]
	private HashSet<ComplexListItem> _unusedItems = new HashSet<ComplexListItem>();

	[NonSerialized]
	private HashSet<object> _selectedItems = new HashSet<object>();

	[NonSerialized]
	private HashSet<object> _hiddenItems = new HashSet<object>();

	[NonSerialized]
	private Dictionary<object, ComplexListItem> _activeMap = new Dictionary<object, ComplexListItem>();

	[NonSerialized]
	private List<object> _items = new List<object>();

	[NonSerialized]
	private bool _isDirty;

	[NonSerialized]
	private Vector2 _lastSize;

	[NonSerialized]
	private int _sizeUpdate;

	[NonSerialized]
	private float _lastHeight;

	public event EventHandler<ComplexListItem> OnInitContent;

	public IEnumerable<T> GetSelected<T>() where T : class
	{
		foreach (object selectedItem in _selectedItems)
		{
			yield return selectedItem as T;
		}
	}

	public IEnumerable<T> GetVisible<T>() where T : class
	{
		foreach (object item in _items)
		{
			if (!GetHidden(item))
			{
				yield return item as T;
			}
		}
	}

	public void SetHidden(object item, bool hidden)
	{
		if (hidden)
		{
			if (_hiddenItems.Add(item))
			{
				if (!CanSelectHidden && GetSelected(item))
				{
					SetSelected(item, false);
				}
				SetDirty();
			}
		}
		else if (_hiddenItems.Remove(item))
		{
			SetDirty();
		}
	}

	public bool GetHidden(object item)
	{
		return _hiddenItems.Contains(item);
	}

	public void SetSelected(object item, bool selected)
	{
		ComplexListItem value3;
		if (selected)
		{
			if (!CanSelectHidden && GetHidden(item))
			{
				return;
			}
			if (!MultiSelect)
			{
				foreach (object selectedItem in _selectedItems)
				{
					ComplexListItem value;
					if (_activeMap.TryGetValue(selectedItem, out value))
					{
						value.SetSelectedUI(false);
					}
				}
				_selectedItems.Clear();
			}
			ComplexListItem value2;
			if (_selectedItems.Add(item) && _activeMap.TryGetValue(item, out value2))
			{
				value2.RefreshSelected();
			}
		}
		else if (_selectedItems.Remove(item) && _activeMap.TryGetValue(item, out value3))
		{
			value3.RefreshSelected();
		}
	}

	public bool GetSelected(object item)
	{
		return _selectedItems.Contains(item);
	}

	public void SetDirty()
	{
		_isDirty = true;
	}

	public void Init<T>(IEnumerable<T> items, object selected = null) where T : class
	{
		Reset();
		_items.AddRange(items.Cast<object>());
		if (selected != null)
		{
			_selectedItems.Add(selected);
		}
		Refresh();
		if (selected != null)
		{
			ScrollTo(selected);
		}
	}

	private void Reset()
	{
		_items.Clear();
		_selectedItems.Clear();
		_hiddenItems.Clear();
		_listItems.ForEach(delegate(ComplexListItem x)
		{
			x.InUse = false;
			x.gameObject.SetActive(false);
		});
		_listItemPool.Clear();
		_listItemPool.AddRange(_listItems);
		_activeMap.Clear();
	}

	public float GetActualScrollValue()
	{
		if (Scroll.size >= 1f)
		{
			return 0f;
		}
		float num = Padding;
		float width = ContentPanel.rect.width;
		float height = ContentPanel.rect.height;
		for (int i = 0; i < _items.Count; i++)
		{
			object obj = _items[i];
			if (!GetHidden(obj))
			{
				num += _listItems[0].GetHeight(obj, width) + Padding;
			}
		}
		return Scroll.value * (num - height);
	}

	public void ScrollTo(float pixel)
	{
		if (Scroll.size >= 1f)
		{
			return;
		}
		float num = Padding;
		float width = ContentPanel.rect.width;
		float height = ContentPanel.rect.height;
		for (int i = 0; i < _items.Count; i++)
		{
			object obj = _items[i];
			if (!GetHidden(obj))
			{
				num += _listItems[0].GetHeight(obj, width) + Padding;
			}
		}
		Scroll.value = pixel / (num - height);
	}

	public void ScrollTo(object item)
	{
		if (GetHidden(item) || !(_lastHeight > 0f))
		{
			return;
		}
		float num = 0f;
		float width = ContentPanel.rect.width;
		for (int i = 0; i < _items.Count; i++)
		{
			object obj = _items[i];
			if (obj == item)
			{
				break;
			}
			if (!GetHidden(obj))
			{
				num += _listItems[0].GetHeight(obj, width) + Padding;
			}
		}
		Scroll.value = num / _lastHeight;
	}

	public void Refresh()
	{
		if (_listItems.Count == 0)
		{
			_listItemPool.Add(CreateItem());
		}
		if (!CanDeselect && _selectedItems.Count == 0)
		{
			for (int i = 0; i < _items.Count; i++)
			{
				if (!GetHidden(_items[i]))
				{
					ComplexListItem value;
					if (_activeMap.TryGetValue(_items[0], out value))
					{
						ToggleSelected(value);
					}
					else
					{
						_selectedItems.Add(_items[0]);
					}
					break;
				}
			}
		}
		float num = Padding;
		float width = ContentPanel.rect.width;
		float height = ContentPanel.rect.height;
		for (int j = 0; j < _items.Count; j++)
		{
			object obj = _items[j];
			if (!GetHidden(obj))
			{
				num += _listItems[0].GetHeight(obj, width) + Padding;
			}
		}
		_lastHeight = num - height;
		Scroll.size = ((num > 0f) ? (height / num) : 1f);
		float num2 = Scroll.value * (num - height);
		float num3 = num2 + height;
		float num4 = Padding;
		_unusedItems.AddRange(_listItems.Where((ComplexListItem x) => x.InUse));
		int num5 = -1;
		float num6 = 0f;
		for (int num7 = 0; num7 < _items.Count; num7++)
		{
			object obj2 = _items[num7];
			if (GetHidden(obj2))
			{
				continue;
			}
			float height2 = _listItems[0].GetHeight(obj2, width);
			float num8 = num4 + height2 + Padding;
			if (num4 >= num2 || num8 - Padding > num2)
			{
				if (num5 < 0)
				{
					num5 = num7;
					num6 = num4;
				}
				ComplexListItem value2;
				if (_activeMap.TryGetValue(obj2, out value2))
				{
					value2.Self.anchoredPosition = new Vector2(0f, 0f - (num4 - num2));
					value2.Self.sizeDelta = new Vector2(0f, height2);
					_unusedItems.Remove(value2);
				}
			}
			num4 = num8;
			if (num4 >= num3)
			{
				break;
			}
		}
		foreach (ComplexListItem unusedItem in _unusedItems)
		{
			unusedItem.InUse = false;
			unusedItem.gameObject.SetActive(false);
			_activeMap.Remove(unusedItem.Content);
			_listItemPool.Add(unusedItem);
		}
		_unusedItems.Clear();
		if (num5 < 0)
		{
			return;
		}
		num4 = num6;
		for (int num9 = num5; num9 < _items.Count; num9++)
		{
			object obj3 = _items[num9];
			if (GetHidden(obj3))
			{
				continue;
			}
			float height3 = _listItems[0].GetHeight(obj3, width);
			float num10 = num4 + height3 + Padding;
			if ((num4 >= num2 || num10 - Padding > num2) && !_activeMap.ContainsKey(obj3))
			{
				ComplexListItem item = GetItem();
				_activeMap[obj3] = item;
				EventHandler<ComplexListItem> eventHandler = this.OnInitContent;
				if (eventHandler != null)
				{
					eventHandler(this, item);
				}
				item.Content = obj3;
				item.Self.anchoredPosition = new Vector2(0f, 0f - (num4 - num2));
				item.Self.sizeDelta = new Vector2(0f, height3);
			}
			num4 = num10;
			if (num4 >= num3)
			{
				break;
			}
		}
	}

	public ComplexListItem GetItem()
	{
		ComplexListItem obj = ((_listItemPool.Count > 0) ? _listItemPool.Pop() : CreateItem());
		obj.InUse = true;
		obj.gameObject.SetActive(true);
		return obj;
	}

	public ComplexListItem CreateItem()
	{
		ComplexListItem complexListItem = UnityEngine.Object.Instantiate(ItemPrefab);
		complexListItem.Init(this);
		complexListItem.transform.SetParent(ContentPanel, false);
		complexListItem.Self.anchorMin = new Vector2(0f, 1f);
		complexListItem.Self.anchorMax = new Vector2(1f, 1f);
		complexListItem.Self.offsetMin = new Vector2(0f, 0f);
		complexListItem.Self.offsetMax = new Vector2(0f, 0f);
		complexListItem.gameObject.SetActive(false);
		_listItems.Add(complexListItem);
		return complexListItem;
	}

	public void ToggleSelected(ComplexListItem item)
	{
		if (GetSelected(item.Content))
		{
			if (CanDeselect || _selectedItems.Count > 1)
			{
				SetSelected(item.Content, false);
			}
		}
		else
		{
			SetSelected(item.Content, true);
		}
	}

	private void Update()
	{
		if (_isDirty)
		{
			_isDirty = false;
			Refresh();
			_sizeUpdate = 0;
		}
		if (_sizeUpdate > 0)
		{
			_sizeUpdate--;
			if (_sizeUpdate == 0)
			{
				Refresh();
			}
		}
		if (_lastSize != ContentPanel.rect.size)
		{
			_lastSize = ContentPanel.rect.size;
			_sizeUpdate = 5;
		}
	}

	public void OnScroll(PointerEventData eventData)
	{
		if (_lastHeight > 0f)
		{
			Scroll.value -= eventData.scrollDelta.y * ScrollSpeed / _lastHeight;
		}
	}
}
