using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Controls
{
	public class ListControl<TItem> : WidgetControl
	{
		private class PooledListItemWidget<T>
		{
			public Widget DeleteButton { get; set; }

			public ListItem<T> ListItem { get; set; }

			public Widget OverlayUI { get; set; }

			public Widget RenameButton { get; set; }

			public Widget Widget { get; set; }

			public void DestroyOverlayUI()
			{
				if (OverlayUI != null)
				{
					InputWidget inputWidget = OverlayUI.FindWidget<InputWidget>("input");
					if (inputWidget != null)
					{
						inputWidget.Input.onSubmit.RemoveAllListeners();
					}
					OverlayUI.Destroy();
					OverlayUI = null;
				}
			}
		}

		private Widget _container;

		private List<ListItem<TItem>> _filteredItems = new List<ListItem<TItem>>();

		private float _itemHeight;

		private string _listItemTemplate;

		private List<PooledListItemWidget<TItem>> _listItemWidgetPool = new List<PooledListItemWidget<TItem>>();

		private bool _refresh;

		private List<ListItem<TItem>> _refreshItems = new List<ListItem<TItem>>();

		private ScrollViewWidget _scrollView;

		private string _searchFilter;

		private List<ListItem<TItem>> _selectedItems;

		private Dictionary<int, PooledListItemWidget<TItem>> _viewableItems = new Dictionary<int, PooledListItemWidget<TItem>>();

		public Action<Widget, ListItem<TItem>> CreateListItem { get; set; }

		public Action<ListItem<TItem>> DeleteListItem { get; set; }

		public Action<ListItem<TItem>> DeselectListItem { get; set; }

		public bool EnableMultiSelect { get; set; }

		public Func<ListItem<TItem>, string, bool> FilterListItem { get; set; }

		public Action<List<ListItem<TItem>>, string> FinalizeFilteredListItems { get; set; }

		public Action<ListItem<TItem>, bool> HoverListItem { get; set; }

		public ObservableCollection<ListItem<TItem>> Items { get; private set; } = new ObservableCollection<ListItem<TItem>>();

		public Action<ListItem<TItem>, Widget, string> ListItemAction { get; set; }

		public Func<ListItem<TItem>, string, bool> RenameListItem { get; set; }

		public string SearchFilter
		{
			get
			{
				return _searchFilter;
			}
			set
			{
				if (_searchFilter != value)
				{
					_searchFilter = value;
					_refresh = true;
				}
			}
		}

		public ListItem<TItem> SelectedItem
		{
			get
			{
				return _selectedItems.FirstOrDefault();
			}
			set
			{
				SelectItem(value);
			}
		}

		public IReadOnlyList<ListItem<TItem>> SelectedItems => _selectedItems;

		public Action<ListItem<TItem>> SelectListItem { get; set; }

		public ListControl(ScrollViewWidget scrollView, string listItemTemplate = "list-item")
			: base(scrollView)
		{
			_scrollView = scrollView;
			_listItemTemplate = listItemTemplate;
			_container = base.Widget.Widgets.FirstOrDefault();
			if (_container == null)
			{
				throw new Exception("ListControl must have an Empty child.");
			}
			_selectedItems = new List<ListItem<TItem>>();
			for (int i = 0; i < 10; i++)
			{
				CreatePooledListItem();
			}
			_itemHeight = _listItemWidgetPool.First().Widget.Height ?? 50f;
			Items.CollectionChanged += OnItemsChanged;
			FilterListItem = (ListItem<TItem> listItem, string searchFilter) => string.IsNullOrEmpty(searchFilter) || listItem.Name.Contains(searchFilter, StringComparison.OrdinalIgnoreCase);
		}

		public void DeselectAllItems()
		{
			foreach (ListItem<TItem> selectedItem in _selectedItems)
			{
				UpdateSelectedStateOfPooledListItemWidget(_listItemWidgetPool.FirstOrDefault((PooledListItemWidget<TItem> x) => x.ListItem == selectedItem), selected: false);
				DeselectListItem?.Invoke(selectedItem);
			}
			_selectedItems.Clear();
		}

		public void DeselectItem(ListItem<TItem> item)
		{
			if (_selectedItems.Contains(item))
			{
				_selectedItems.Remove(item);
				UpdateSelectedStateOfPooledListItemWidget(_listItemWidgetPool.FirstOrDefault((PooledListItemWidget<TItem> x) => x.ListItem == item), selected: false);
				DeselectListItem?.Invoke(item);
			}
		}

		public void Refresh()
		{
			_refresh = false;
			for (int num = _selectedItems.Count - 1; num >= 0; num--)
			{
				if (!Items.Contains(_selectedItems[num]))
				{
					DeselectItem(_selectedItems[num]);
				}
			}
			_refreshItems.Clear();
			string searchFilter = SearchFilter?.Trim() ?? string.Empty;
			_filteredItems.Clear();
			FilterItems(searchFilter, _filteredItems);
			foreach (PooledListItemWidget<TItem> item in _listItemWidgetPool)
			{
				ReturnListItemToPool(item);
			}
			_viewableItems.Clear();
		}

		public void RefreshItem(ListItem<TItem> listItem)
		{
			if (!_refreshItems.Contains(listItem))
			{
				_refreshItems.Add(listItem);
			}
		}

		public void ScrollToListItem(ListItem<TItem> listItem)
		{
			int num = _filteredItems.IndexOf(listItem);
			if (num < 0)
			{
				return;
			}
			float num2 = (float)_filteredItems.Count * _itemHeight;
			float height = _scrollView.ScrollRect.viewport.rect.height;
			float num3 = Mathf.Max(0f, num2 - height);
			float num4 = (1f - _scrollView.ScrollRect.verticalNormalizedPosition) * num3;
			float num5 = (float)num * _itemHeight;
			float num6 = num5 + _itemHeight;
			float num7 = num4;
			if (num5 < num4)
			{
				num7 = num5;
			}
			else
			{
				if (!(num6 > num4 + height))
				{
					return;
				}
				num7 = num6 - height;
			}
			num7 = Mathf.Clamp(num7, 0f, num3);
			float normalizedPosition = ((num3 > 0f) ? (1f - num7 / num3) : 1f);
			_scrollView.StartCoroutine(ScrollToPositionDelayed(normalizedPosition));
		}

		public void SelectItem(ListItem<TItem> item)
		{
			if (!EnableMultiSelect)
			{
				DeselectAllItems();
				foreach (PooledListItemWidget<TItem> item2 in _listItemWidgetPool)
				{
					item2.DestroyOverlayUI();
				}
			}
			if (item != null && !_selectedItems.Contains(item))
			{
				_selectedItems.Add(item);
				UpdateSelectedStateOfPooledListItemWidget(_listItemWidgetPool.FirstOrDefault((PooledListItemWidget<TItem> x) => x.ListItem == item), selected: true);
				SelectListItem?.Invoke(item);
			}
		}

		public override void Update()
		{
			base.Update();
			if (_refresh)
			{
				Refresh();
			}
			else
			{
				foreach (ListItem<TItem> listItem in _refreshItems)
				{
					PooledListItemWidget<TItem> pooledListItemWidget = _listItemWidgetPool.FirstOrDefault((PooledListItemWidget<TItem> x) => x.ListItem == listItem);
					if (pooledListItemWidget != null)
					{
						CreateListItem(pooledListItemWidget.Widget, listItem);
					}
				}
				_refreshItems.Clear();
			}
			UpdateView();
		}

		protected virtual void FilterItems(string searchFilter, List<ListItem<TItem>> filteredItems)
		{
			string[] array = searchFilter.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (ListItem<TItem> item in Items)
			{
				bool flag = true;
				string[] array2 = array;
				foreach (string arg in array2)
				{
					if (!FilterListItem(item, arg))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					filteredItems.Add(item);
				}
			}
			FinalizeFilteredListItems?.Invoke(filteredItems, searchFilter);
		}

		protected virtual void OnDeleteButtonClicked(Widget widget)
		{
			PooledListItemWidget<TItem> pooledItem = GetPooledItemFromChildWidget(widget);
			if (pooledItem != null)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, "Confirm that you wish to delete '" + pooledItem.ListItem.Name + "'");
				messageDialogScript.UseDangerButtonStyle = true;
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					DeleteListItem(pooledItem.ListItem);
					Items.Remove(pooledItem.ListItem);
					ReturnListItemToPool(pooledItem);
				};
			}
		}

		protected virtual void OnListItemAction(Widget widget, string action)
		{
			PooledListItemWidget<TItem> pooledItemFromChildWidget = GetPooledItemFromChildWidget(widget);
			if (pooledItemFromChildWidget != null)
			{
				ListItemAction?.Invoke(pooledItemFromChildWidget.ListItem, pooledItemFromChildWidget.Widget, action);
			}
		}

		protected virtual void OnRenameAcceptButtonClicked(Widget widget)
		{
			PooledListItemWidget<TItem> pooledItemFromChildWidget = GetPooledItemFromChildWidget(widget);
			if (pooledItemFromChildWidget.OverlayUI != null)
			{
				InputWidget inputWidget = pooledItemFromChildWidget.OverlayUI.FindWidget<InputWidget>("input");
				OnRenameInputSubmit(inputWidget.Text, pooledItemFromChildWidget);
			}
		}

		protected virtual void OnRenameButtonClicked(Widget widget)
		{
			foreach (PooledListItemWidget<TItem> item in _listItemWidgetPool)
			{
				item.DestroyOverlayUI();
			}
			PooledListItemWidget<TItem> pooledItem = GetPooledItemFromChildWidget(widget);
			pooledItem.OverlayUI = widget.Context.CreateWidgetFromTemplate("list-item-rename-ui", pooledItem.Widget);
			InputWidget inputWidget = pooledItem.OverlayUI.FindWidget<InputWidget>("input");
			inputWidget.Text = pooledItem.ListItem.Name;
			inputWidget.Input.Select();
			inputWidget.Input.onSubmit.AddListener(delegate(string s)
			{
				OnRenameInputSubmit(s, pooledItem);
			});
		}

		protected virtual void OnRenameCancelButtonClicked(Widget widget)
		{
			GetPooledItemFromChildWidget(widget).DestroyOverlayUI();
		}

		private static void UpdateSelectedStateOfPooledListItemWidget(PooledListItemWidget<TItem> pooledListItemWidget, bool selected)
		{
			if (pooledListItemWidget != null)
			{
				pooledListItemWidget.Widget.EnableClass("list-item-selected", selected);
				pooledListItemWidget.DeleteButton?.SetVisible(pooledListItemWidget.ListItem.CanDelete);
				pooledListItemWidget.RenameButton?.SetVisible(pooledListItemWidget.ListItem.CanRename);
			}
		}

		private PooledListItemWidget<TItem> CreatePooledListItem()
		{
			Widget widget = base.Widget.Context.CreateWidgetFromTemplate(_listItemTemplate, _container);
			widget.Clicked += OnItemClicked;
			widget.PointerEnter += OnItemPointerEnter;
			widget.PointerExit += OnItemPointerExit;
			PooledListItemWidget<TItem> pooledListItemWidget = new PooledListItemWidget<TItem>();
			pooledListItemWidget.Widget = widget;
			pooledListItemWidget.DeleteButton = pooledListItemWidget.Widget.FindWidget("delete-button");
			pooledListItemWidget.RenameButton = pooledListItemWidget.Widget.FindWidget("rename-button");
			_listItemWidgetPool.Add(pooledListItemWidget);
			pooledListItemWidget.Widget.Visible = false;
			return pooledListItemWidget;
		}

		private PooledListItemWidget<TItem> GetListItemFromPool()
		{
			foreach (PooledListItemWidget<TItem> item in _listItemWidgetPool)
			{
				if (item.ListItem == null)
				{
					item.Widget.Visible = true;
					item.DestroyOverlayUI();
					return item;
				}
			}
			return CreatePooledListItem();
		}

		private PooledListItemWidget<TItem> GetPooledItemFromChildWidget(Widget widget)
		{
			Widget listItemWidget = widget.FindParentWidgetByClass("list-item");
			if (listItemWidget != null)
			{
				PooledListItemWidget<TItem> pooledListItemWidget = _listItemWidgetPool.FirstOrDefault((PooledListItemWidget<TItem> x) => x.Widget == listItemWidget);
				if (pooledListItemWidget != null)
				{
					return pooledListItemWidget;
				}
			}
			return null;
		}

		private void OnItemClicked(Widget widget)
		{
			PooledListItemWidget<TItem> pooledListItemWidget = _listItemWidgetPool.FirstOrDefault((PooledListItemWidget<TItem> x) => x.Widget == widget);
			if (!_selectedItems.Contains(pooledListItemWidget.ListItem))
			{
				SelectItem(pooledListItemWidget.ListItem);
			}
			else
			{
				DeselectItem(pooledListItemWidget.ListItem);
			}
		}

		private void OnItemPointerEnter(Widget widget)
		{
			PooledListItemWidget<TItem> pooledListItemWidget = _listItemWidgetPool.FirstOrDefault((PooledListItemWidget<TItem> x) => x.Widget == widget);
			if (pooledListItemWidget != null)
			{
				HoverListItem?.Invoke(pooledListItemWidget.ListItem, arg2: true);
			}
		}

		private void OnItemPointerExit(Widget widget)
		{
			PooledListItemWidget<TItem> pooledListItemWidget = _listItemWidgetPool.FirstOrDefault((PooledListItemWidget<TItem> x) => x.Widget == widget);
			if (pooledListItemWidget != null)
			{
				HoverListItem?.Invoke(pooledListItemWidget.ListItem, arg2: false);
			}
		}

		private void OnItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			_refresh = true;
		}

		private void OnRenameInputSubmit(string text, PooledListItemWidget<TItem> pooledItem)
		{
			text = text.Trim();
			if (text == pooledItem.ListItem.Name || RenameListItem(pooledItem.ListItem, text))
			{
				pooledItem.DestroyOverlayUI();
				RefreshItem(pooledItem.ListItem);
			}
			else
			{
				pooledItem.OverlayUI.FindWidget<InputWidget>("input").Input.Select();
			}
		}

		private void ReturnListItemToPool(PooledListItemWidget<TItem> pooledListItem)
		{
			if (pooledListItem.Widget.HoverClass != null)
			{
				pooledListItem.Widget.RemoveClass(pooledListItem.Widget.HoverClass);
			}
			pooledListItem.Widget.Visible = false;
			pooledListItem.ListItem = null;
		}

		private IEnumerator ScrollToPositionDelayed(float normalizedPosition)
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			_scrollView.ScrollRect.verticalNormalizedPosition = normalizedPosition;
		}

		private void UpdateView()
		{
			_container.Height = (float)_filteredItems.Count * _itemHeight;
			float value = _container.Height.Value;
			float height = _scrollView.ScrollRect.viewport.rect.height;
			float num = (1f - _scrollView.ScrollRect.verticalNormalizedPosition) * (value - height);
			int num2 = 1;
			int num3 = Mathf.FloorToInt(num / _itemHeight) - num2;
			int num4 = Mathf.Min(_filteredItems.Count, Mathf.CeilToInt((num + height) / _itemHeight)) + num2;
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, PooledListItemWidget<TItem>> viewableItem in _viewableItems)
			{
				int key = viewableItem.Key;
				if (key < num3 || key >= num4)
				{
					ReturnListItemToPool(viewableItem.Value);
					list.Add(key);
				}
			}
			foreach (int item in list)
			{
				_viewableItems.Remove(item);
			}
			for (int i = num3; i < num4; i++)
			{
				if (i >= 0 && i < _filteredItems.Count && !_viewableItems.ContainsKey(i))
				{
					PooledListItemWidget<TItem> listItemFromPool = GetListItemFromPool();
					listItemFromPool.ListItem = _filteredItems[i];
					CreateListItem(listItemFromPool.Widget, listItemFromPool.ListItem);
					listItemFromPool.Widget.Visible = true;
					RectTransform rect = listItemFromPool.Widget.Rect;
					Vector2 anchoredPosition = rect.anchoredPosition;
					anchoredPosition.y = (float)(-i) * _itemHeight;
					rect.anchoredPosition = anchoredPosition;
					_viewableItems[i] = listItemFromPool;
					UpdateSelectedStateOfPooledListItemWidget(listItemFromPool, _selectedItems.Contains(listItemFromPool.ListItem));
				}
			}
		}
	}
}
