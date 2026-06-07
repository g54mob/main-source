using System;
using UnityEngine.EventSystems;

public static class EventTriggerExtensions
{
	public static EventTrigger.Entry AddListener(this EventTrigger trigger, EventTriggerType type, Action<BaseEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddPointerListener(this EventTrigger trigger, EventTriggerType type, Action<PointerEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddAxisListener(this EventTrigger trigger, EventTriggerType type, Action<AxisEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddListener<T>(this EventTrigger trigger, EventTriggerType type, Action<T> action) where T : BaseEventData
	{
		return null;
	}

	public static bool RemoveListener(this EventTrigger trigger, EventTrigger.Entry entry)
	{
		return false;
	}

	public static EventTrigger.Entry AddPointerClickListener(this EventTrigger trigger, Action<PointerEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddPointerDownListener(this EventTrigger trigger, Action<PointerEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddPointerUpListener(this EventTrigger trigger, Action<PointerEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddPointerEnterListener(this EventTrigger trigger, Action<PointerEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddPointerExitListener(this EventTrigger trigger, Action<PointerEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddBeginDragListener(this EventTrigger trigger, Action<PointerEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddDragListener(this EventTrigger trigger, Action<PointerEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddEndDragListener(this EventTrigger trigger, Action<PointerEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddDropListener(this EventTrigger trigger, Action<PointerEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddScrollListener(this EventTrigger trigger, Action<PointerEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddInitializePotentialDragListener(this EventTrigger trigger, Action<PointerEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddUpdateSelectedListener(this EventTrigger trigger, Action<BaseEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddSelectListener(this EventTrigger trigger, Action<BaseEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddDeselectListener(this EventTrigger trigger, Action<BaseEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddSubmitListener(this EventTrigger trigger, Action<BaseEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddCancelListener(this EventTrigger trigger, Action<BaseEventData> action)
	{
		return null;
	}

	public static EventTrigger.Entry AddMoveListener(this EventTrigger trigger, Action<AxisEventData> action)
	{
		return null;
	}
}
