using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class CraftingSelectorFilterCategoryUI : ItemSlotsUIContainer, IScrollable
{
	private const string ITEM_CATEGORY_TERM = "ItemCategory/";

	public Vector2Int size = Vector2Int.one;

	public CraftingSelectorFilterCategory filter;

	public PugText categoryText;

	public bool mustHaveAnyActiveCategory;

	[SerializeField]
	[FormerlySerializedAs("pullSubCategoriesFrom")]
	private CraftingSelectorFilterCategoryUI subCategoryOf;

	[SerializeField]
	private List<ObjectIDCategory> categories = new List<ObjectIDCategory>();

	private List<ObjectIDCategory> _allCategories = new List<ObjectIDCategory>();

	private List<ObjectIDCategory> _categories = new List<ObjectIDCategory>();

	private float _currentScroll;

	private int _prevStartIndex;

	private int _prevSelectedIndex;

	public override int MAX_ROWS => size.y;

	public override int MAX_COLUMNS => size.x;

	public override UIScrollWindow uiScrollWindow => GetComponent<UIScrollWindow>();

	private CraftingSelectorFilterCategory ParentFilter => subCategoryOf.filter;

	public bool IsSubCategory()
	{
		return subCategoryOf != null;
	}

	protected override void Awake()
	{
		itemSlots = new List<SlotUIBase>(MAX_ROWS * MAX_COLUMNS);
		for (int i = 0; i < MAX_ROWS * MAX_COLUMNS; i++)
		{
			SlotUIBase slotUIBase = UnityEngine.Object.Instantiate(itemSlotPrefab, itemSlotsRoot.transform);
			itemSlots.Add(slotUIBase);
			slotUIBase.gameObject.SetActive(value: false);
		}
	}

	private void Start()
	{
		foreach (ObjectIDCategory category in categories)
		{
			_allCategories.Add(category);
		}
		UpdateCategories();
	}

	private void OnEnable()
	{
		if (IsSubCategory())
		{
			CraftingSelectorFilterCategory parentFilter = ParentFilter;
			parentFilter.OnFilterUpdated = (Action)Delegate.Combine(parentFilter.OnFilterUpdated, new Action(UpdateCategories));
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		if (IsSubCategory())
		{
			CraftingSelectorFilterCategory parentFilter = ParentFilter;
			parentFilter.OnFilterUpdated = (Action)Delegate.Remove(parentFilter.OnFilterUpdated, new Action(UpdateCategories));
		}
	}

	public void UpdateContainingElements(float scroll)
	{
		_currentScroll = scroll;
		int num = math.max(0, ((int)math.floor(_currentScroll / spread) - 1) * MAX_COLUMNS);
		int num2 = math.max(0, ((int)math.floor(_currentScroll / spread) + MAX_ROWS) * MAX_COLUMNS);
		float num3 = spread * (float)(num / MAX_COLUMNS);
		float sideStartPosition = GetSideStartPosition(MAX_COLUMNS);
		float num4 = 0f;
		int num5 = 0;
		int num6 = -1;
		if (Manager.ui.currentSelectedUIElement is CraftingSelectorFilterCategorySlot craftingSelectorFilterCategorySlot)
		{
			num6 = craftingSelectorFilterCategorySlot.visibleSlotIndex;
		}
		for (int i = 0; i < itemSlots.Count; i++)
		{
			int num7 = num + i;
			if (num7 >= num2 || num7 >= _categories.Count)
			{
				itemSlots[i].gameObject.SetActive(value: false);
				continue;
			}
			CraftingSelectorFilterCategorySlot obj = itemSlots[i] as CraftingSelectorFilterCategorySlot;
			obj.SetCategory(_categories[num7], this, num5);
			int num8 = i % MAX_COLUMNS;
			int num9 = i / MAX_COLUMNS;
			obj.transform.localPosition = new Vector3(sideStartPosition + (float)num8 * spread, num4 - (float)num9 * spread - num3, 0f);
			obj.gameObject.SetActive(value: true);
			num5++;
		}
		base.visibleRows = num5;
		base.visibleColumns = 1;
		if (_prevStartIndex != num)
		{
			_prevStartIndex = num;
			if (num6 != -1 && (!Manager.input.SystemPrefersKeyboardAndMouse() || !Manager.input.SystemIsUsingMouse()))
			{
				for (int j = 0; j < itemSlots.Count; j++)
				{
					if (itemSlots[j].visibleSlotIndex == _prevSelectedIndex)
					{
						Manager.ui.DeselectAnySelectedUIElement();
						itemSlots[j].Select();
						Manager.ui.mouse.PlaceMousePositionOnSelectedUIElementWhenControlledByJoystick();
						break;
					}
				}
			}
		}
		if (mustHaveAnyActiveCategory && filter.Category == null && categories.Count > 0 && itemSlots.Count > 0)
		{
			filter.Category = ((CraftingSelectorFilterCategorySlot)itemSlots[0]).Category;
			if (categoryText != null && filter.Category != null)
			{
				categoryText.Render("ItemCategory/" + filter.Category.name);
			}
		}
		_prevSelectedIndex = num6;
	}

	public void OnSlotClicked(CraftingSelectorFilterCategorySlot slot)
	{
		if (slot == null)
		{
			return;
		}
		ObjectIDCategory category = slot.Category;
		if (mustHaveAnyActiveCategory && filter.Category == category)
		{
			return;
		}
		filter.Category = ((filter.Category == category) ? null : category);
		if (categoryText != null)
		{
			if (filter.Category != null)
			{
				categoryText.Render("ItemCategory/" + filter.Category.name);
			}
			else if (ParentFilter.Category != null)
			{
				categoryText.Render("ItemCategory/" + ParentFilter.Category.name);
			}
		}
	}

	public bool IsBottomElementSelected()
	{
		if (Manager.ui.currentSelectedUIElement == null)
		{
			return false;
		}
		int indexOfElement = GetIndexOfElement(Manager.ui.currentSelectedUIElement);
		if (indexOfElement == -1)
		{
			return false;
		}
		return indexOfElement + MAX_COLUMNS >= _categories.Count;
	}

	public bool IsTopElementSelected()
	{
		if (Manager.ui.currentSelectedUIElement == null)
		{
			return false;
		}
		int indexOfElement = GetIndexOfElement(Manager.ui.currentSelectedUIElement);
		if (indexOfElement == -1)
		{
			return false;
		}
		return indexOfElement < MAX_COLUMNS;
	}

	private void UpdateCategories()
	{
		_categories.Clear();
		if (!IsSubCategory())
		{
			_categories.AddRange(_allCategories);
		}
		else if (ParentFilter != null && ParentFilter.Category != null)
		{
			foreach (ObjectIDCategory allCategory in _allCategories)
			{
				if (allCategory.ParentCategory == ParentFilter.Category)
				{
					_categories.Add(allCategory);
				}
			}
		}
		if (filter.Category != null && !_categories.Contains(filter.Category))
		{
			filter.Category = null;
		}
	}

	private int GetIndexOfElement(UIelement element)
	{
		for (int i = 0; i < itemSlots.Count && itemSlots[i].gameObject.activeSelf; i++)
		{
			if (itemSlots[i] == element)
			{
				return i;
			}
		}
		return -1;
	}

	public float GetCurrentWindowHeight()
	{
		return (float)_categories.Count * spread;
	}

	private float GetSideStartPosition(int size)
	{
		return (0f - (float)(size - 1) / 2f) * spread;
	}
}
