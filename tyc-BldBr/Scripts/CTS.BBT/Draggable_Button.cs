using System;
using CTS;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable_Button : MonoBehaviour, IDragHandler, IEventSystemHandler, IDropHandler, IPointerUpHandler, IPointerDownHandler
{
	public Action<int> onSlotPositionChanged;

	[HideInInspector]
	public SlotManager slotManager;

	private bool onDrag;

	private int currentDragIdx;

	private int _slotPosition;

	public RectTransform dragRectTransform { get; private set; }

	public PriorityLabel PriorityLabel { get; private set; }

	public bool ManuallyDraggable { get; set; } = true;

	public int SlotPosition
	{
		get
		{
			return _slotPosition;
		}
		set
		{
			_slotPosition = value;
			onSlotPositionChanged?.Invoke(_slotPosition);
		}
	}

	private void Awake()
	{
		dragRectTransform = GetComponent<RectTransform>();
		PriorityLabel = GetComponent<PriorityLabel>();
	}

	private void Update()
	{
		if (onDrag)
		{
			int slotFromMousePosition = slotManager.GetSlotFromMousePosition();
			if (slotFromMousePosition != -1)
			{
				currentDragIdx = slotFromMousePosition;
			}
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (!ManuallyDraggable && slotManager.ReorganiseIfToggleChange)
		{
			return;
		}
		if (slotManager.MouseInPanel)
		{
			dragRectTransform.anchoredPosition += eventData.delta / slotManager.Canvas.scaleFactor;
			int slotFromMousePosition = slotManager.GetSlotFromMousePosition();
			if (slotFromMousePosition != -1)
			{
				slotManager.Reorganise(this, slotFromMousePosition, _fixToSlot: false);
			}
			dragRectTransform.SetAsLastSibling();
			onDrag = true;
		}
		else
		{
			ForceDrop();
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (ManuallyDraggable || !slotManager.ReorganiseIfToggleChange)
		{
			ForceDrop();
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		onDrag = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (ManuallyDraggable || !slotManager.ReorganiseIfToggleChange)
		{
			ForceDrop();
		}
	}

	private void ForceDrop()
	{
		slotManager.Reorganise(this, currentDragIdx, _fixToSlot: true);
		onDrag = false;
	}

	public void SendToBack()
	{
		if (slotManager.ReorganiseIfToggleChange)
		{
			slotManager.Reorganise(this, slotManager.ButtonCount - 1, _fixToSlot: true);
		}
	}

	public void SendTo(int p_position)
	{
		if (slotManager.ReorganiseIfToggleChange)
		{
			slotManager.Reorganise(this, p_position, _fixToSlot: true);
		}
	}
}
