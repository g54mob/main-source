using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyBox
{
	public static class MyUI
	{
		public static void SetCanvasState(CanvasGroup canvas, bool setOn)
		{
			canvas.alpha = (setOn ? 1 : 0);
			canvas.interactable = setOn;
			canvas.blocksRaycasts = setOn;
		}

		public static void SetState(this CanvasGroup canvas, bool isOn)
		{
			SetCanvasState(canvas, isOn);
		}

		public static void SetWidth(this RectTransform transform, float width)
		{
			transform.sizeDelta = transform.sizeDelta.SetX(width);
		}

		public static void SetHeight(this RectTransform transform, float height)
		{
			transform.sizeDelta = transform.sizeDelta.SetY(height);
		}

		public static void SetPositionX(this RectTransform transform, float x)
		{
			transform.anchoredPosition = transform.anchoredPosition.SetX(x);
		}

		public static void SetPositionY(this RectTransform transform, float y)
		{
			transform.anchoredPosition = transform.anchoredPosition.SetY(y);
		}

		public static void OffsetPositionX(this RectTransform transform, float x)
		{
			transform.anchoredPosition = transform.anchoredPosition.OffsetX(x);
		}

		public static void OffsetPositionY(this RectTransform transform, float y)
		{
			transform.anchoredPosition = transform.anchoredPosition.OffsetY(y);
		}

		public static EventTrigger.Entry OnEventSubscribe(this EventTrigger trigger, EventTriggerType eventType, Action<BaseEventData> callback)
		{
			EventTrigger.Entry entry = new EventTrigger.Entry();
			entry.eventID = eventType;
			entry.callback = new EventTrigger.TriggerEvent();
			entry.callback.AddListener(callback.Invoke);
			trigger.triggers.Add(entry);
			return entry;
		}

		public static void OnEventUnsubscribe(this EventTrigger trigger, EventTrigger.Entry entry)
		{
			trigger.triggers.Add(entry);
		}

		public static RectTransform ShiftAnchor(this RectTransform source, Vector2 delta)
		{
			source.anchorMin += delta;
			source.anchorMax += delta;
			return source;
		}

		public static RectTransform ShiftAnchor(this RectTransform source, float x, float y)
		{
			return source.ShiftAnchor(new Vector2(x, y));
		}

		public static Vector2 GetAnchorCenter(this RectTransform source)
		{
			return (source.anchorMin + source.anchorMax) / 2f;
		}

		public static Vector2 GetAnchorDelta(this RectTransform source)
		{
			return source.anchorMax - source.anchorMin;
		}
	}
}
