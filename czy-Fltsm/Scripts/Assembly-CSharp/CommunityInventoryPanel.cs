using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class CommunityInventoryPanel : SceneBehaviour, IInventoryView
{
	public enum Mode
	{
		Closed = 0,
		Open = 1
	}

	[Serializable]
	private class Group
	{
		public class Member
		{
			public ItemProperties Properties;

			public int Count;

			public bool Show { get; private set; }

			public void SetCount(int count)
			{
				Count = count;
				Show = count > 0 || (Properties.Tags & Item.Tags.Quest) == 0;
			}
		}

		[EnumFlag(1)]
		public Item.Tags Tag;

		public GridLayoutGroup LayoutGroup;

		private InventoryPanelItemSlot _slotPrefab;

		private readonly List<InventoryPanelItemSlot> _slots = new List<InventoryPanelItemSlot>(32);

		private bool _open;

		private bool _toggled;

		public List<Member> Members { get; } = new List<Member>(32);

		public int ActiveSlotCount { get; private set; }

		public void Initialize(InventoryPanelItemSlot slotPrefab, ItemProperties[] itemPropertiesArray)
		{
			_slotPrefab = slotPrefab;
			_toggled = true;
			foreach (ItemProperties itemProperties in itemPropertiesArray)
			{
				if ((itemProperties.Tags & Tag) != Item.Tags.None)
				{
					Members.Add(new Member
					{
						Properties = itemProperties,
						Count = 0
					});
				}
			}
		}

		public void SetOpen(bool open)
		{
			_open = open;
			UpdateSlots();
		}

		public void SetFiltered(bool toggled)
		{
			_toggled = toggled;
			UpdateSlots();
		}

		public void Update(List<InventoryAuditor.CountedItem> countedItems)
		{
			foreach (InventoryAuditor.CountedItem countedItem in countedItems)
			{
				if ((Tag & countedItem.ItemProperties.Tags) != Item.Tags.None)
				{
					int num = countedItem.ReturnCount(InventoryAuditor.CountType.All);
					if (TryGetMember(countedItem.ItemProperties, out var member))
					{
						member.SetCount(num);
					}
					else if (num > 0)
					{
						AddMember(countedItem);
					}
				}
			}
			UpdateSlots();
		}

		private void UpdateSlots()
		{
			if (Members == null)
			{
				return;
			}
			int count = Members.Count;
			_ = _slots.Count;
			ActiveSlotCount = 0;
			for (int i = 0; i < count; i++)
			{
				Member member = Members[i];
				if (member.Show && _open && _toggled)
				{
					GetSlot(ActiveSlotCount++).Initialize(member.Properties, member.Count);
				}
			}
			while (ActiveSlotCount < _slots.Count)
			{
				_slots[ActiveSlotCount].gameObject.SetActive(value: false);
				ActiveSlotCount++;
			}
		}

		private bool TryGetMember(ItemProperties properties, out Member member)
		{
			int count = Members.Count;
			for (int i = 0; i < count; i++)
			{
				member = Members[i];
				if (member.Properties == properties)
				{
					return true;
				}
			}
			member = null;
			return false;
		}

		private void AddMember(InventoryAuditor.CountedItem countedItem)
		{
			Members.Add(new Member
			{
				Properties = countedItem.ItemProperties,
				Count = countedItem.ReturnCount(InventoryAuditor.CountType.All)
			});
			_slots.Add(UnityEngine.Object.Instantiate(_slotPrefab, LayoutGroup.transform));
		}

		private InventoryPanelItemSlot GetSlot(int index)
		{
			if (index < _slots.Count)
			{
				return _slots[index];
			}
			InventoryPanelItemSlot inventoryPanelItemSlot = UnityEngine.Object.Instantiate(_slotPrefab, LayoutGroup.transform);
			_slots.Add(inventoryPanelItemSlot);
			return inventoryPanelItemSlot;
		}
	}

	[SerializeField]
	private List<InventoryType> _inventories;

	[SerializeField]
	private int _maximumColumnCount = 20;

	[SerializeField]
	private InventoryPanelItemSlot _itemSlotPrefab;

	[SerializeField]
	private Group[] _groups;

	[SerializeField]
	private InventoryCapacityBar[] _capacityBars;

	[SerializeField]
	private bool _openOnStart;

	[SerializeField]
	private OpenCloseButton _openClosebutton;

	[SerializeField]
	private bool _allowsEjectingItems;

	private RectTransform _rootCanvasRectTransform;

	private int _rootCanvasMargin;

	private float _slotWidth;

	private CommunityInventory _inventory;

	private bool _open;

	protected override void Awake()
	{
		base.Awake();
		ItemProperties[] itemProperties = GameSettings.Instance.ItemSettings.ItemProperties;
		Group[] groups = _groups;
		for (int i = 0; i < groups.Length; i++)
		{
			groups[i].Initialize(_itemSlotPrefab, itemProperties);
		}
		InitializeCanvasScaling();
	}

	private void Start()
	{
		if (_openOnStart)
		{
			ToggleMode();
		}
	}

	private void OnEnable()
	{
		if (_inventory == null)
		{
			_inventory = Community.PlayerCommunity.Inventory;
		}
		_inventory.InventoryUpdatedEvent.AddListener(OnInventoryUpdate);
		InventoryCapacityBar[] capacityBars = _capacityBars;
		for (int i = 0; i < capacityBars.Length; i++)
		{
			capacityBars[i].Initialize(_inventory);
		}
		GetComponentInParent<CanvasScaler>(includeInactive: true);
		OnInventoryUpdate();
	}

	private void OnDisable()
	{
		if (_inventory != null)
		{
			_inventory.InventoryUpdatedEvent.RemoveListener(OnInventoryUpdate);
		}
	}

	public void ToggleMode()
	{
		_open = !_open;
		Group[] groups = _groups;
		for (int i = 0; i < groups.Length; i++)
		{
			groups[i].SetOpen(_open);
		}
		UpdateLayout();
		_openClosebutton.SetOpen(_open);
	}

	public void ToggleGroup(Item.Tags tag, bool toggled)
	{
		Group[] groups = _groups;
		foreach (Group obj in groups)
		{
			if (obj.Tag.HasFlag(tag))
			{
				obj.SetFiltered(toggled);
			}
		}
		UpdateLayout();
	}

	private void InitializeCanvasScaling()
	{
		if (_groups.IsNullOrEmpty())
		{
			return;
		}
		GridLayoutGroup layoutGroup = _groups[0].LayoutGroup;
		Vector2 cellSize = layoutGroup.cellSize;
		RectOffset padding = layoutGroup.padding;
		Vector2 spacing = layoutGroup.spacing;
		int num = _groups.Length;
		if (base.transform is RectTransform rt)
		{
			Canvas rootCanvas = rt.GetParentCanvas().rootCanvas;
			if (rootCanvas.TryGetComponent<CanvasScaler>(out var component))
			{
				float num2 = cellSize.x * (float)_maximumColumnCount + (float)((padding.left + padding.right) * num) + (float)_maximumColumnCount / (float)num * spacing.x;
				_rootCanvasRectTransform = rootCanvas.transform as RectTransform;
				_rootCanvasMargin = Mathf.CeilToInt(component.referenceResolution.x - num2);
				_rootCanvasMargin -= _rootCanvasMargin % 4;
				_slotWidth = num2 / (float)_maximumColumnCount;
			}
		}
	}

	private void OnInventoryUpdate()
	{
		List<InventoryAuditor.CountedItem> countedItems = _inventory.ReturnStorageCount(SubInventoryType.Storage, SubInventoryType.Liquid).CountedItems;
		Group[] groups = _groups;
		for (int i = 0; i < groups.Length; i++)
		{
			groups[i].Update(countedItems);
		}
		UpdateLayout();
	}

	private void UpdateLayout()
	{
		int num = ((_rootCanvasRectTransform != null) ? Mathf.FloorToInt((_rootCanvasRectTransform.sizeDelta.x - (float)_rootCanvasMargin) / _slotWidth) : _maximumColumnCount);
		int num2 = 0;
		int num3 = 0;
		Group[] groups = _groups;
		foreach (Group obj in groups)
		{
			num2 += obj.ActiveSlotCount;
		}
		groups = _groups;
		foreach (Group obj2 in groups)
		{
			if (obj2.ActiveSlotCount == 0)
			{
				obj2.LayoutGroup.gameObject.SetActive(value: false);
				continue;
			}
			if (num2 <= num)
			{
				obj2.LayoutGroup.constraintCount = obj2.ActiveSlotCount;
			}
			else
			{
				int num4 = Mathf.RoundToInt((float)obj2.ActiveSlotCount / (float)num2 * (float)num);
				obj2.LayoutGroup.constraintCount = num4;
				num3 += num4;
			}
			obj2.LayoutGroup.gameObject.SetActive(value: true);
		}
	}

	public void ThrowItem(ItemProperties itemProperties)
	{
		if (_allowsEjectingItems)
		{
			UIEvent.Dispatch(UIEvent.Type.EjectItem);
			Item item = _inventory.ReturnItem(itemProperties, SubInventoryType.Storage);
			item?.Inventory.TakeItem(item);
		}
	}
}
