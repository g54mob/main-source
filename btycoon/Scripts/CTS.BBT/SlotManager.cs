using System;
using System.Collections.Generic;
using CTS.BBT;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
	public Action onReorganised;

	[SerializeField]
	private ButtonSlot slotPrefab;

	[SerializeField]
	private RectTransform parentRect;

	[SerializeField]
	private RectTransform _disableRect;

	private Vector2 _mousePosition;

	private RectTransform _rect;

	private float _buttonHeight = 89f;

	private List<ButtonSlot> _slots = new List<ButtonSlot>();

	private List<Draggable_Button> _buttonList = new List<Draggable_Button>();

	[SerializeField]
	private float _offset = 374.731f;

	[field: SerializeField]
	public bool ReorganiseIfToggleChange { get; private set; }

	public bool MouseInPanel { get; private set; }

	public Canvas Canvas { get; private set; }

	public int ButtonCount => _buttonList.Count;

	public List<Draggable_Button> GetButtonList => _buttonList;

	private void Awake()
	{
		Canvas = GetComponentInParent<Canvas>();
		_rect = GetComponent<RectTransform>();
		_buttonHeight = slotPrefab.GetComponent<RectTransform>().sizeDelta.y;
	}

	private void Update()
	{
		_mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y) / Canvas.scaleFactor;
		MouseInPanel = MouseIsInPanel();
	}

	public void AddDraggableButton(Draggable_Button p_button)
	{
		_slots.Add(UnityEngine.Object.Instantiate(slotPrefab, base.transform));
		p_button.slotManager = this;
		_buttonList.Add(p_button);
		RefreshList(_fixToSlot: true, 0, p_immediat: true);
		RefreshSize(_slots.Count);
	}

	private void RefreshSize(int slotCount)
	{
		_rect.sizeDelta = new Vector2(_rect.sizeDelta.x, _buttonHeight * (float)slotCount);
		parentRect.sizeDelta = new Vector2(parentRect.sizeDelta.x, _buttonHeight * (float)slotCount + (0f - _rect.anchoredPosition.y) / Canvas.scaleFactor);
		_disableRect.sizeDelta = new Vector2(_rect.sizeDelta.x, _buttonHeight * (float)slotCount);
	}

	public void ClearButtons()
	{
		for (int i = 0; i < _buttonList.Count; i++)
		{
			UnityEngine.Object.Destroy(_buttonList[i]);
		}
	}

	public void Reorganise(Draggable_Button _button, int _newPosition, bool _fixToSlot)
	{
		_buttonList.Remove(_button);
		_buttonList.Insert(_newPosition, _button);
		RefreshList(_fixToSlot, _newPosition, p_immediat: false);
		onReorganised?.Invoke();
	}

	public void ReorganiseFromWorker(Priority[] priorityList)
	{
		List<Draggable_Button> list = new List<Draggable_Button>();
		int num = 0;
		for (int i = 0; i < priorityList.Length; i++)
		{
			Priority priority = priorityList[i];
			Draggable_Button draggable_Button = FindButton(priority.category, priority.isEnable);
			if ((object)draggable_Button != null)
			{
				list.Add(draggable_Button);
			}
			if (!priority.isHided)
			{
				num++;
			}
		}
		for (int num2 = list.Count - 1; num2 >= 0; num2--)
		{
			Draggable_Button item = list[num2];
			_buttonList.Remove(item);
			_buttonList.Insert(0, item);
		}
		for (int j = 0; j < _slots.Count; j++)
		{
			if (j < num)
			{
				_slots[j].gameObject.SetActive(value: true);
				_slots[j].SetDD_Button(_buttonList[j], _fixToSlot: true, p_immediat: true);
				_buttonList[j].SlotPosition = j + 1;
			}
			else
			{
				_slots[j].gameObject.SetActive(value: false);
			}
		}
		RefreshSize(num);
	}

	private Draggable_Button FindButton(ChoreCategory p_category, bool p_isEnable)
	{
		foreach (Draggable_Button button in _buttonList)
		{
			if (button.PriorityLabel.Chore == p_category)
			{
				button.PriorityLabel.IsChoreActived = p_isEnable;
				return button;
			}
		}
		return null;
	}

	private void RefreshList(bool _fixToSlot, int _newPosition, bool p_immediat)
	{
		for (int i = 0; i < _slots.Count && i < _buttonList.Count; i++)
		{
			if (!_fixToSlot && _newPosition == i)
			{
				_slots[i].SetDD_Button(_buttonList[i], _fixToSlot: false, p_immediat);
			}
			else
			{
				_slots[i].SetDD_Button(_buttonList[i], _fixToSlot: true, p_immediat);
			}
			_buttonList[i].SlotPosition = i + 1;
		}
	}

	public int GetSlotFromMousePosition()
	{
		Vector2 recalculatePosition = GetRecalculatePosition(parentRect);
		for (int i = 0; i < _slots.Count && i < _buttonList.Count && _slots[i].gameObject.activeSelf; i++)
		{
			if (!_buttonList[i].PriorityLabel.IsChoreActived && ReorganiseIfToggleChange)
			{
				return -1;
			}
			if (_mousePosition.x >= recalculatePosition.x + _rect.anchoredPosition.x && _mousePosition.x <= recalculatePosition.x + _rect.anchoredPosition.x + _rect.sizeDelta.x && _mousePosition.y <= recalculatePosition.y + _rect.anchoredPosition.y && _mousePosition.y >= recalculatePosition.y + _rect.anchoredPosition.y - (float)(i + 1) * _buttonHeight)
			{
				return i;
			}
		}
		return -1;
	}

	private bool MouseIsInPanel()
	{
		Vector2 recalculatePosition = GetRecalculatePosition(parentRect);
		if (_mousePosition.x >= recalculatePosition.x + _rect.anchoredPosition.x && _mousePosition.x <= recalculatePosition.x + _rect.anchoredPosition.x + _rect.sizeDelta.x && _mousePosition.y <= recalculatePosition.y + _rect.anchoredPosition.y)
		{
			return _mousePosition.y >= recalculatePosition.y + _rect.anchoredPosition.y - _rect.sizeDelta.y;
		}
		return false;
	}

	private Vector2 GetRecalculatePosition(RectTransform _rectP)
	{
		if (_rectP == null)
		{
			return Vector2.zero;
		}
		float x = _rectP.anchoredPosition.x - _rectP.pivot.x * _rectP.sizeDelta.x + _rectP.anchorMin.x * Camera.main.pixelRect.width / Canvas.scaleFactor;
		float y = _rectP.anchoredPosition.y + _rectP.anchorMin.y * Camera.main.pixelRect.height / Canvas.scaleFactor + _offset;
		return new Vector2(x, y);
	}
}
