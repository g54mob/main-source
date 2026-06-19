using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(CraftingSelectorData))]
public class CraftingSelectorUI : ItemSlotsUIContainer, IScrollable
{
	public Vector2Int size = Vector2Int.one;

	private CraftingSelectorData _data;

	private float _currentScroll;

	private int _prevStartIndex;

	private int _prevSelectedIndex;

	public override bool isShowing => base.gameObject.activeInHierarchy;

	public override int MAX_ROWS => size.y;

	public override int MAX_COLUMNS => size.x;

	public override UIScrollWindow uiScrollWindow => GetComponent<UIScrollWindow>();

	protected override void Awake()
	{
		if (!(itemSlotPrefab is CraftingSelectorSlot))
		{
			Debug.LogError("All slots in crafting selector has to be CraftingSelectorSlot");
			base.enabled = false;
		}
		else
		{
			_data = GetComponent<CraftingSelectorData>();
			base.Awake();
			base.gameObject.SetActive(value: false);
		}
	}

	public override void ShowContainerUI()
	{
		base.ShowContainerUI();
		base.gameObject.SetActive(value: true);
		UpdateList();
		_data.OnRecipesUpdate += UpdateList;
	}

	public override void HideContainerUI()
	{
		base.HideContainerUI();
		if (base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			_data.OnRecipesUpdate -= UpdateList;
		}
	}

	public void UpdateContainingElements(float scroll)
	{
		_currentScroll = scroll;
		UpdateList();
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
		return indexOfElement >= _data.CurrentObjects.Count - _data.CurrentObjects.Count % MAX_COLUMNS;
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

	private int GetIndexOfElement(UIelement element)
	{
		for (int i = 0; i < itemSlots.Count && itemSlots[i].gameObject.activeSelf; i++)
		{
			if (itemSlots[i] == element)
			{
				return _data.CurrentObjects[i].Index;
			}
		}
		return -1;
	}

	public float GetCurrentWindowHeight()
	{
		if (itemSlots.Count > MAX_COLUMNS)
		{
			return math.abs(itemSlots[0].transform.localPosition.y - itemSlots[MAX_COLUMNS].transform.localPosition.y) * (float)((_data.CurrentObjects.Count - 1) / MAX_COLUMNS + 1);
		}
		return 0f;
	}

	public void UpdateList()
	{
		List<CraftingSelectorData.RecipeSlot> currentObjects = _data.CurrentObjects;
		int num = math.max(0, ((int)math.floor(_currentScroll / spread) - 1) * MAX_COLUMNS);
		int num2 = math.max(0, ((int)math.floor(_currentScroll / spread) + MAX_ROWS) * MAX_COLUMNS);
		float num3 = spread * (float)(num / MAX_COLUMNS);
		float sideStartPosition = GetSideStartPosition(MAX_COLUMNS);
		float num4 = 0f;
		int prevSelectedIndex = -1;
		if (Manager.ui.currentSelectedUIElement is CraftingSelectorSlot craftingSelectorSlot)
		{
			prevSelectedIndex = craftingSelectorSlot.visibleSlotIndex;
		}
		for (int i = 0; i < itemSlots.Count; i++)
		{
			int num5 = num + i;
			if (num5 >= num2 || num5 >= currentObjects.Count)
			{
				itemSlots[i].gameObject.SetActive(value: false);
				continue;
			}
			CraftingSelectorSlot obj = itemSlots[i] as CraftingSelectorSlot;
			obj.visibleSlotIndex = i;
			obj.SetObjectData(currentObjects[num5].ObjectData, this);
			int num6 = i % MAX_COLUMNS;
			int num7 = i / MAX_COLUMNS;
			obj.transform.localPosition = new Vector3(sideStartPosition + (float)num6 * spread, num4 - (float)num7 * spread - num3, 0f);
			obj.gameObject.SetActive(value: true);
		}
		if (_prevStartIndex != num)
		{
			_prevStartIndex = num;
			if (Manager.ui.currentSelectedUIElement is CraftingSelectorSlot && (!Manager.input.SystemPrefersKeyboardAndMouse() || !Manager.input.SystemIsUsingMouse()))
			{
				for (int j = 0; j < itemSlots.Count; j++)
				{
					if (itemSlots[j].visibleSlotIndex == _prevSelectedIndex)
					{
						Manager.ui.DeselectAnySelectedUIElement();
						itemSlots[j].Select();
						Manager.ui.mouse.PlaceMousePositionOnSelectedUIElementWhenControlledByJoystick();
					}
				}
			}
		}
		_prevSelectedIndex = prevSelectedIndex;
	}

	private float GetSideStartPosition(int size)
	{
		return (0f - (float)(size - 1) / 2f) * spread;
	}
}
