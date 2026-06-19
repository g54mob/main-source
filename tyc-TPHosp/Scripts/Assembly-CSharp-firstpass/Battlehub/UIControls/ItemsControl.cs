using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Battlehub.UIControls
{
	public class ItemsControl : ItemsControl<ItemDataBindingArgs>
	{
	}
	public class ItemsControl<TDataBindingArgs> : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDropHandler where TDataBindingArgs : ItemDataBindingArgs, new()
	{
		private enum ScrollDir
		{
			None = 0,
			Up = 1,
			Down = 2,
			Left = 3,
			Right = 4
		}

		public KeyCode MultiselectKey = KeyCode.LeftControl;

		public KeyCode RangeselectKey = KeyCode.LeftShift;

		public KeyCode RemoveKey = KeyCode.Delete;

		private bool m_prevCanDrag;

		public bool CanDrag = true;

		private bool m_isDropInProgress;

		[SerializeField]
		private GameObject ItemContainerPrefab;

		public Transform Panel;

		private float m_width;

		private Canvas m_canvas;

		public Camera Camera;

		public float ScrollSpeed = 100f;

		private ScrollDir m_scrollDir;

		private ScrollRect m_scrollRect;

		private List<ItemContainer> m_itemContainers;

		private ItemDropMarker m_dropMarker;

		private ItemContainer m_dropTarget;

		private ItemContainer[] m_dragItems;

		private IList<object> m_items;

		private bool m_selectionLocked;

		private List<object> m_selectedItems;

		private ItemContainer m_selectedItem;

		private int m_selectedIndex = -1;

		public bool IsDropInProgress => m_isDropInProgress;

		protected ItemDropMarker DropMarker => m_dropMarker;

		public IEnumerable Items
		{
			get
			{
				return m_items;
			}
			set
			{
				m_items = value.OfType<object>().ToList();
				DataBind();
			}
		}

		public int ItemsCount
		{
			get
			{
				if (m_items == null)
				{
					return 0;
				}
				return m_items.Count;
			}
		}

		public int SelectedItemsCount
		{
			get
			{
				if (m_selectedItems == null)
				{
					return 0;
				}
				return m_selectedItems.Count;
			}
		}

		public IEnumerable SelectedItems
		{
			get
			{
				return m_selectedItems;
			}
			set
			{
				if (m_selectionLocked)
				{
					return;
				}
				m_selectionLocked = true;
				IList selectedItems = m_selectedItems;
				if (value != null)
				{
					m_selectedItems = value.OfType<object>().ToList();
					for (int num = m_selectedItems.Count - 1; num >= 0; num--)
					{
						object obj = m_selectedItems[num];
						ItemContainer itemContainer = GetItemContainer(obj);
						if (itemContainer == null)
						{
							m_selectedItems.Remove(obj);
						}
						else
						{
							itemContainer.IsSelected = true;
						}
					}
					if (m_selectedItems.Count == 0)
					{
						m_selectedItem = null;
						m_selectedIndex = -1;
					}
					else
					{
						m_selectedItem = GetItemContainer(m_selectedItems[0]);
						m_selectedIndex = IndexOf(m_selectedItem.Item);
					}
				}
				else
				{
					m_selectedItems = null;
					m_selectedItem = null;
					m_selectedIndex = -1;
				}
				List<object> list = new List<object>();
				if (selectedItems != null)
				{
					if (m_selectedItems != null)
					{
						for (int i = 0; i < selectedItems.Count; i++)
						{
							object obj2 = selectedItems[i];
							if (!m_selectedItems.Contains(obj2))
							{
								list.Add(obj2);
								GetItemContainer(obj2).IsSelected = false;
							}
						}
					}
					else
					{
						list.AddRange(selectedItems.OfType<object>());
					}
				}
				if (this.SelectionChanged != null)
				{
					object[] newItems = ((m_selectedItems == null) ? new object[0] : m_selectedItems.ToArray());
					this.SelectionChanged(this, new SelectionChangedEventArgs(list.ToArray(), newItems));
				}
				m_selectionLocked = false;
			}
		}

		public object SelectedItem
		{
			get
			{
				if (m_selectedItem == null)
				{
					return null;
				}
				return m_selectedItem.Item;
			}
			set
			{
				SelectedIndex = IndexOf(value);
			}
		}

		public int SelectedIndex
		{
			get
			{
				if (m_selectedItem == null)
				{
					return -1;
				}
				return m_selectedIndex;
			}
			set
			{
				if (m_selectedIndex == value)
				{
					return;
				}
				ItemContainer selectedItem = m_selectedItem;
				if (selectedItem != null)
				{
					selectedItem.IsSelected = false;
				}
				m_selectedIndex = value;
				object obj = null;
				if (m_selectedIndex >= 0 && m_selectedIndex < m_items.Count)
				{
					obj = m_items[m_selectedIndex];
					m_selectedItem = GetItemContainer(obj);
					if (m_selectedItem != null)
					{
						m_selectedItem.IsSelected = true;
					}
				}
				object[] array = ((obj == null) ? new object[0] : new object[1] { obj });
				object[] array2 = ((m_selectedItems == null) ? new object[0] : m_selectedItems.Except(array).ToArray());
				foreach (object obj2 in array2)
				{
					GetItemContainer(obj2).IsSelected = false;
				}
				m_selectedItems = array.ToList();
				if (this.SelectionChanged != null)
				{
					this.SelectionChanged(this, new SelectionChangedEventArgs(array2, array));
				}
			}
		}

		public event EventHandler<ItemDragArgs> ItemBeginDrag;

		public event EventHandler<ItemDropArgs> ItemDrop;

		public event EventHandler<ItemDragArgs> ItemEndDrag;

		public event EventHandler<TDataBindingArgs> ItemDataBinding;

		public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

		public event EventHandler<ItemsRemovedArgs> ItemsRemoved;

		protected void RemoveItemAt(int index)
		{
			m_items.RemoveAt(index);
		}

		protected void RemoveItemContainerAt(int index)
		{
			m_itemContainers.RemoveAt(index);
		}

		protected void InsertItem(int index, object value)
		{
			m_items.Insert(index, value);
		}

		protected void InsertItemContainerAt(int index, ItemContainer container)
		{
			m_itemContainers.Insert(index, container);
		}

		public int IndexOf(object obj)
		{
			if (m_items == null)
			{
				return -1;
			}
			if (obj == null)
			{
				return -1;
			}
			return m_items.IndexOf(obj);
		}

		public ItemContainer GetItemContainer(object obj)
		{
			return m_itemContainers.Where((ItemContainer ic) => ic.Item == obj).FirstOrDefault();
		}

		public ItemContainer LastItemContainer()
		{
			if (m_itemContainers == null || m_itemContainers.Count == 0)
			{
				return null;
			}
			return m_itemContainers[m_itemContainers.Count - 1];
		}

		public ItemContainer GetItemContainer(int siblingIndex)
		{
			if (siblingIndex < 0 || siblingIndex >= m_itemContainers.Count)
			{
				return null;
			}
			return m_itemContainers[siblingIndex];
		}

		public ItemContainer Add(object item)
		{
			if (m_items == null)
			{
				m_items = new List<object>();
				m_itemContainers = new List<ItemContainer>();
			}
			return Insert(m_items.Count, item);
		}

		public ItemContainer Insert(int index, object item)
		{
			if (m_items == null)
			{
				m_items = new List<object>();
				m_itemContainers = new List<ItemContainer>();
			}
			object obj = m_items.ElementAtOrDefault(index);
			ItemContainer itemContainer = GetItemContainer(obj);
			int siblingIndex = ((!(itemContainer != null)) ? m_itemContainers.Count : m_itemContainers.IndexOf(itemContainer));
			m_items.Insert(index, item);
			itemContainer = InstantiateItemContainer(siblingIndex);
			if (itemContainer != null)
			{
				itemContainer.Item = item;
				DataBindItem(item, itemContainer);
			}
			return itemContainer;
		}

		public void Remove(object item)
		{
			if (item != null && m_items != null && m_items.Contains(item))
			{
				DestroyItem(item);
			}
		}

		public void RemoveAt(int index)
		{
			if (m_items != null)
			{
				if (index >= m_items.Count || index < 0)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				Remove(m_items[index]);
			}
		}

		private void Awake()
		{
			if (Panel == null)
			{
				Panel = base.transform;
			}
			m_itemContainers = GetComponentsInChildren<ItemContainer>().ToList();
			m_dropMarker = GetComponentInChildren<ItemDropMarker>(includeInactive: true);
			m_scrollRect = GetComponent<ScrollRect>();
			if (Camera == null)
			{
				Camera = Camera.main;
			}
			m_prevCanDrag = CanDrag;
			OnCanDragChanged();
			AwakeOverride();
		}

		private void Start()
		{
			m_canvas = GetComponentInParent<Canvas>();
			StartOverride();
		}

		private void Update()
		{
			if (m_scrollDir != ScrollDir.None)
			{
				float num = m_scrollRect.content.rect.height - m_scrollRect.viewport.rect.height;
				float num2 = 0f;
				if (num > 0f)
				{
					num2 = ScrollSpeed / 10f * (1f / num);
				}
				float num3 = m_scrollRect.content.rect.width - m_scrollRect.viewport.rect.width;
				float num4 = 0f;
				if (num3 > 0f)
				{
					num4 = ScrollSpeed / 10f * (1f / num3);
				}
				if (m_scrollDir == ScrollDir.Up)
				{
					m_scrollRect.verticalNormalizedPosition += num2;
					if (m_scrollRect.verticalNormalizedPosition > 1f)
					{
						m_scrollRect.verticalNormalizedPosition = 1f;
						m_scrollDir = ScrollDir.None;
					}
				}
				else if (m_scrollDir == ScrollDir.Down)
				{
					m_scrollRect.verticalNormalizedPosition -= num2;
					if (m_scrollRect.verticalNormalizedPosition < 0f)
					{
						m_scrollRect.verticalNormalizedPosition = 0f;
						m_scrollDir = ScrollDir.None;
					}
				}
				else if (m_scrollDir == ScrollDir.Left)
				{
					m_scrollRect.horizontalNormalizedPosition -= num4;
					if (m_scrollRect.horizontalNormalizedPosition < 0f)
					{
						m_scrollRect.horizontalNormalizedPosition = 0f;
						m_scrollDir = ScrollDir.None;
					}
				}
				if (m_scrollDir == ScrollDir.Right)
				{
					m_scrollRect.horizontalNormalizedPosition += num4;
					if (m_scrollRect.horizontalNormalizedPosition > 1f)
					{
						m_scrollRect.horizontalNormalizedPosition = 1f;
						m_scrollDir = ScrollDir.None;
					}
				}
			}
			if (Input.GetKeyDown(RemoveKey))
			{
				DestroySelectedItems();
			}
			if (m_scrollRect.viewport.rect.width != m_width)
			{
				m_width = m_scrollRect.viewport.rect.width;
				if (m_itemContainers != null)
				{
					for (int i = 0; i < m_itemContainers.Count; i++)
					{
						ItemContainer itemContainer = m_itemContainers[i];
						if (itemContainer != null)
						{
							itemContainer.LayoutElement.minWidth = m_width;
						}
					}
				}
			}
			if (m_prevCanDrag != CanDrag)
			{
				OnCanDragChanged();
				m_prevCanDrag = CanDrag;
			}
			UpdateOverride();
		}

		private void OnEnable()
		{
			ItemContainer.Selected += OnItemSelected;
			ItemContainer.Unselected += OnItemUnselected;
			ItemContainer.PointerUp += OnItemPointerUp;
			ItemContainer.PointerDown += OnItemPointerDown;
			ItemContainer.PointerEnter += OnPointerEnter;
			ItemContainer.PointerExit += OnPointerExit;
			ItemContainer.BeginDrag += OnItemBeginDrag;
			ItemContainer.Drag += OnItemDrag;
			ItemContainer.Drop += OnItemDrop;
			ItemContainer.EndDrag += OnItemEndDrag;
			OnEnableOverride();
		}

		private void OnDisable()
		{
			ItemContainer.Selected -= OnItemSelected;
			ItemContainer.Unselected -= OnItemUnselected;
			ItemContainer.PointerUp -= OnItemPointerUp;
			ItemContainer.PointerDown -= OnItemPointerDown;
			ItemContainer.PointerEnter -= OnPointerEnter;
			ItemContainer.PointerExit -= OnPointerExit;
			ItemContainer.BeginDrag -= OnItemBeginDrag;
			ItemContainer.Drag -= OnItemDrag;
			ItemContainer.Drop -= OnItemDrop;
			ItemContainer.EndDrag -= OnItemEndDrag;
			OnDisableOverride();
		}

		protected virtual void AwakeOverride()
		{
		}

		protected virtual void StartOverride()
		{
		}

		protected virtual void UpdateOverride()
		{
		}

		protected virtual void OnEnableOverride()
		{
		}

		protected virtual void OnDisableOverride()
		{
		}

		private void OnCanDragChanged()
		{
			for (int i = 0; i < m_itemContainers.Count; i++)
			{
				ItemContainer itemContainer = m_itemContainers[i];
				if (itemContainer != null)
				{
					itemContainer.CanDrag = CanDrag;
				}
			}
		}

		protected bool CanHandleEvent(object sender)
		{
			ItemContainer itemContainer = sender as ItemContainer;
			if (!itemContainer)
			{
				return false;
			}
			return itemContainer.transform.IsChildOf(Panel);
		}

		private void OnItemSelected(object sender, EventArgs e)
		{
			if (!m_selectionLocked && CanHandleEvent(sender))
			{
				if (Input.GetKey(MultiselectKey))
				{
					IList list = ((m_selectedItems != null) ? m_selectedItems.ToList() : new List<object>());
					list.Add(((ItemContainer)sender).Item);
					SelectedItems = list;
				}
				else if (Input.GetKey(RangeselectKey))
				{
					SelectRange((ItemContainer)sender);
				}
				else
				{
					SelectedIndex = IndexOf(((ItemContainer)sender).Item);
				}
			}
		}

		private void SelectRange(ItemContainer itemContainer)
		{
			if (m_selectedItems != null && m_selectedItems.Count > 0)
			{
				List<object> list = new List<object>();
				int num = IndexOf(m_selectedItems[0]);
				object item = itemContainer.Item;
				int num2 = IndexOf(item);
				int num3 = Mathf.Min(num, num2);
				int num4 = Math.Max(num, num2);
				list.Add(m_selectedItems[0]);
				for (int i = num3; i < num; i++)
				{
					list.Add(m_items[i]);
				}
				for (int j = num + 1; j <= num4; j++)
				{
					list.Add(m_items[j]);
				}
				SelectedItems = list;
			}
			else
			{
				SelectedIndex = IndexOf(itemContainer.Item);
			}
		}

		private void OnItemUnselected(object sender, EventArgs e)
		{
			if (!m_selectionLocked && CanHandleEvent(sender))
			{
				IList list = ((m_selectedItems != null) ? m_selectedItems.ToList() : new List<object>());
				list.Remove(((ItemContainer)sender).Item);
				SelectedItems = list;
			}
		}

		private void OnItemPointerDown(ItemContainer sender, PointerEventData e)
		{
			if (CanHandleEvent(sender))
			{
				if (Input.GetKey(RangeselectKey))
				{
					SelectRange(sender);
				}
				else if (Input.GetKey(MultiselectKey))
				{
					sender.IsSelected = !sender.IsSelected;
				}
				else
				{
					sender.IsSelected = true;
				}
			}
		}

		private void OnItemPointerUp(ItemContainer sender, PointerEventData e)
		{
			if (CanHandleEvent(sender) && m_dragItems == null && !Input.GetKey(MultiselectKey) && !Input.GetKey(RangeselectKey) && m_selectedItems != null && m_selectedItems.Count > 1)
			{
				SelectedItem = sender.Item;
			}
		}

		private void OnPointerEnter(ItemContainer sender, PointerEventData eventData)
		{
			if (CanHandleEvent(sender))
			{
				m_dropTarget = sender;
				if (m_dragItems != null && m_scrollDir == ScrollDir.None)
				{
					m_dropMarker.SetTraget(m_dropTarget);
				}
			}
		}

		private void OnPointerExit(ItemContainer sender, PointerEventData eventData)
		{
			if (CanHandleEvent(sender))
			{
				m_dropTarget = null;
				if (m_dragItems != null)
				{
					m_dropMarker.SetTraget(null);
				}
			}
		}

		private void OnItemBeginDrag(ItemContainer sender, PointerEventData eventData)
		{
			eventData.Reset();
			if (!CanHandleEvent(sender))
			{
				return;
			}
			if (m_dropTarget != null)
			{
				m_dropMarker.SetTraget(m_dropTarget);
				m_dropMarker.SetPosition(eventData.position);
			}
			m_dragItems = GetDragItems();
			if (this.ItemBeginDrag != null)
			{
				this.ItemBeginDrag(this, new ItemDragArgs(m_dragItems.Select((ItemContainer di) => di.Item).ToArray()));
			}
		}

		private void OnItemDrag(ItemContainer sender, PointerEventData eventData)
		{
			if (!CanHandleEvent(sender))
			{
				return;
			}
			if (m_dropTarget != null)
			{
				m_dropMarker.SetPosition(eventData.position);
			}
			float height = m_scrollRect.viewport.rect.height;
			float width = m_scrollRect.viewport.rect.width;
			Camera cam = null;
			if (m_canvas.renderMode == RenderMode.WorldSpace)
			{
				cam = Camera;
			}
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(m_scrollRect.viewport, eventData.position, cam, out var localPoint))
			{
				if (localPoint.y >= 0f)
				{
					m_scrollDir = ScrollDir.Up;
					m_dropMarker.SetTraget(null);
				}
				else if (localPoint.y < 0f - height)
				{
					m_scrollDir = ScrollDir.Down;
					m_dropMarker.SetTraget(null);
				}
				else if (localPoint.x <= 0f)
				{
					m_scrollDir = ScrollDir.Left;
				}
				else if (localPoint.x >= width)
				{
					m_scrollDir = ScrollDir.Right;
				}
				else
				{
					m_scrollDir = ScrollDir.None;
				}
			}
		}

		private void OnItemDrop(ItemContainer sender, PointerEventData eventData)
		{
			if (!CanHandleEvent(sender))
			{
				return;
			}
			m_isDropInProgress = true;
			try
			{
				if (CanDrop(m_dragItems, m_dropTarget))
				{
					Drop(m_dragItems, m_dropTarget, m_dropMarker.Action);
					if (this.ItemDrop != null)
					{
						this.ItemDrop(this, new ItemDropArgs(m_dragItems.Select((ItemContainer di) => di.Item).ToArray(), m_dropTarget.Item, m_dropMarker.Action, isExternal: false));
					}
				}
				RaiseEndDrag();
			}
			finally
			{
				m_isDropInProgress = false;
			}
		}

		private void OnItemEndDrag(ItemContainer sender, PointerEventData eventData)
		{
			if (CanHandleEvent(sender))
			{
				RaiseEndDrag();
			}
		}

		private void RaiseEndDrag()
		{
			if (m_dragItems == null)
			{
				return;
			}
			if (this.ItemEndDrag != null)
			{
				this.ItemEndDrag(this, new ItemDragArgs(m_dragItems.Select((ItemContainer di) => di.Item).ToArray()));
			}
			m_dropMarker.SetTraget(null);
			m_dragItems = null;
			m_scrollDir = ScrollDir.None;
		}

		void IDropHandler.OnDrop(PointerEventData eventData)
		{
			if (m_dragItems == null)
			{
				GameObject pointerDrag = eventData.pointerDrag;
				if (!(pointerDrag != null))
				{
					return;
				}
				ItemContainer component = pointerDrag.GetComponent<ItemContainer>();
				if (component != null && component.Item != null)
				{
					object item = component.Item;
					if (this.ItemDrop != null)
					{
						this.ItemDrop(this, new ItemDropArgs(new object[1] { item }, null, ItemDropAction.SetLastChild, isExternal: true));
					}
				}
				return;
			}
			if (m_itemContainers != null && m_itemContainers.Count > 0)
			{
				m_dropTarget = m_itemContainers.Last();
				m_dropMarker.Action = ItemDropAction.SetNextSibling;
			}
			m_isDropInProgress = true;
			try
			{
				if (CanDrop(m_dragItems, m_dropTarget))
				{
					if (this.ItemDrop != null)
					{
						this.ItemDrop(this, new ItemDropArgs(m_dragItems.Select((ItemContainer di) => di.Item).ToArray(), m_dropTarget.Item, m_dropMarker.Action, isExternal: false));
					}
					Drop(m_dragItems, m_dropTarget, m_dropMarker.Action);
				}
				m_dropMarker.SetTraget(null);
				m_dragItems = null;
			}
			finally
			{
				m_isDropInProgress = false;
			}
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			SelectedIndex = -1;
		}

		protected virtual bool CanDrop(ItemContainer[] dragItems, ItemContainer dropTarget)
		{
			if (dropTarget == null)
			{
				return true;
			}
			if (dragItems == null)
			{
				return false;
			}
			if (dragItems.Contains(dropTarget.Item))
			{
				return false;
			}
			return true;
		}

		protected ItemContainer[] GetDragItems()
		{
			ItemContainer[] array = new ItemContainer[m_selectedItems.Count];
			if (m_selectedItems != null)
			{
				for (int i = 0; i < m_selectedItems.Count; i++)
				{
					array[i] = GetItemContainer(m_selectedItems[i]);
				}
			}
			return array.OrderBy((ItemContainer di) => di.transform.GetSiblingIndex()).ToArray();
		}

		protected virtual void DropItemAfter(ItemContainer dropTarget, ItemContainer dragItem)
		{
			int num = IndexOf(dragItem.Item);
			int num2 = IndexOf(dropTarget.Item);
			RemoveItemAt(num);
			if (num < num2)
			{
				num2--;
			}
			InsertItem(num2 + 1, dragItem.Item);
			int num3 = dropTarget.transform.GetSiblingIndex();
			int siblingIndex = dragItem.transform.GetSiblingIndex();
			RemoveItemContainerAt(siblingIndex);
			if (siblingIndex > num3)
			{
				num3++;
			}
			dragItem.transform.SetSiblingIndex(num3);
			InsertItemContainerAt(num3, dragItem);
		}

		protected virtual void DropItemBefore(ItemContainer dropTarget, ItemContainer dragItem)
		{
			int num = IndexOf(dragItem.Item);
			int num2 = IndexOf(dropTarget.Item);
			RemoveItemAt(num);
			if (num < num2)
			{
				num2--;
			}
			InsertItem(num2, dragItem.Item);
			int num3 = dropTarget.transform.GetSiblingIndex();
			int siblingIndex = dragItem.transform.GetSiblingIndex();
			RemoveItemContainerAt(siblingIndex);
			if (siblingIndex < num3)
			{
				num3--;
			}
			dragItem.transform.SetSiblingIndex(num3);
			InsertItemContainerAt(num3, dragItem);
		}

		protected virtual void Drop(ItemContainer[] dragItems, ItemContainer dropTarget, ItemDropAction action)
		{
			switch (action)
			{
			case ItemDropAction.SetPrevSibling:
				foreach (ItemContainer dragItem2 in dragItems)
				{
					DropItemBefore(dropTarget, dragItem2);
				}
				break;
			case ItemDropAction.SetNextSibling:
				foreach (ItemContainer dragItem in dragItems)
				{
					DropItemAfter(dropTarget, dragItem);
				}
				break;
			}
			UpdateSelectedItemIndex();
		}

		protected void UpdateSelectedItemIndex()
		{
			m_selectedIndex = IndexOf(SelectedItem);
		}

		protected virtual void DataBind()
		{
			m_itemContainers = GetComponentsInChildren<ItemContainer>().ToList();
			if (m_items == null)
			{
				for (int i = 0; i < m_itemContainers.Count; i++)
				{
					UnityEngine.Object.Destroy(m_itemContainers[i].gameObject);
				}
			}
			else
			{
				int num = m_items.Count - m_itemContainers.Count;
				if (num > 0)
				{
					for (int j = 0; j < num; j++)
					{
						InstantiateItemContainer(m_itemContainers.Count);
					}
				}
				else
				{
					int num2 = m_itemContainers.Count + num;
					for (int num3 = m_itemContainers.Count - 1; num3 >= num2; num3--)
					{
						DestroyItemContainer(num3);
					}
				}
			}
			for (int k = 0; k < m_items.Count; k++)
			{
				object item = m_items[k];
				ItemContainer itemContainer = m_itemContainers[k];
				itemContainer.CanDrag = CanDrag;
				if (itemContainer != null)
				{
					itemContainer.Item = item;
					DataBindItem(item, itemContainer);
				}
			}
		}

		protected virtual void DataBindItem(object item, ItemContainer itemContainer)
		{
			RaiseItemDataBinding(new TDataBindingArgs
			{
				Item = item,
				ItemPresenter = itemContainer.gameObject
			});
		}

		protected void RaiseItemDataBinding(TDataBindingArgs args)
		{
			if (this.ItemDataBinding != null)
			{
				this.ItemDataBinding(this, args);
			}
		}

		protected ItemContainer InstantiateItemContainer(int siblingIndex)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(ItemContainerPrefab);
			gameObject.name = "ItemContainer";
			gameObject.transform.SetParent(Panel, worldPositionStays: false);
			gameObject.transform.SetSiblingIndex(siblingIndex);
			ItemContainer itemContainer = InstantiateItemContainerOverride(gameObject);
			itemContainer.CanDrag = CanDrag;
			itemContainer.LayoutElement.minWidth = m_width;
			m_itemContainers.Insert(siblingIndex, itemContainer);
			return itemContainer;
		}

		protected void DestroyItemContainer(int siblingIndex)
		{
			if (m_itemContainers != null && siblingIndex >= 0 && siblingIndex < m_itemContainers.Count)
			{
				UnityEngine.Object.DestroyImmediate(m_itemContainers[siblingIndex].gameObject);
				m_itemContainers.RemoveAt(siblingIndex);
			}
		}

		protected virtual ItemContainer InstantiateItemContainerOverride(GameObject container)
		{
			ItemContainer itemContainer = container.GetComponent<ItemContainer>();
			if (itemContainer == null)
			{
				itemContainer = container.AddComponent<ItemContainer>();
			}
			return itemContainer;
		}

		private void DestroySelectedItems()
		{
			if (m_selectedItems == null)
			{
				return;
			}
			object[] array = m_selectedItems.ToArray();
			if (array.Length != 0)
			{
				SelectedItems = null;
				foreach (object item in array)
				{
					DestroyItem(item);
				}
				if (this.ItemsRemoved != null)
				{
					this.ItemsRemoved(this, new ItemsRemovedArgs(array));
				}
			}
		}

		protected virtual void DestroyItem(object item)
		{
			if (m_selectedItems != null && m_selectedItems.Contains(item))
			{
				m_selectedItems.Remove(item);
				if (m_selectedItems.Count == 0)
				{
					m_selectedItem = null;
					m_selectedIndex = -1;
				}
				else
				{
					m_selectedItem = GetItemContainer(m_selectedItems[0]);
					m_selectedIndex = IndexOf(m_selectedItem.Item);
				}
			}
			ItemContainer itemContainer = GetItemContainer(item);
			if (itemContainer != null)
			{
				int siblingIndex = itemContainer.transform.GetSiblingIndex();
				DestroyItemContainer(siblingIndex);
				m_items.Remove(item);
			}
		}
	}
}
