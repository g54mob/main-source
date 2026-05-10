using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyBox
{
	public static class MyUI
	{
		public static void SetCanvasState(CanvasGroup canvas, bool setOn)
		{
		}

		public static void SetState(this CanvasGroup canvas, bool isOn)
		{
		}

		public static void SetWidth(this RectTransform transform, float width)
		{
		}

		public static void SetHeight(this RectTransform transform, float height)
		{
		}

		public static void SetPositionX(this RectTransform transform, float x)
		{
		}

		public static void SetPositionY(this RectTransform transform, float y)
		{
		}

		public static void OffsetPositionX(this RectTransform transform, float x)
		{
		}

		public static void OffsetPositionY(this RectTransform transform, float y)
		{
		}

		public static EventTrigger.Entry OnEventSubscribe(this EventTrigger trigger, EventTriggerType eventType, Action<BaseEventData> callback)
		{
			return null;
		}

		public static void OnEventUnsubscribe(this EventTrigger trigger, EventTrigger.Entry entry)
		{
		}

		public static RectTransform ShiftAnchor(this RectTransform source, Vector2 delta)
		{
			return null;
		}

		public static RectTransform ShiftAnchor(this RectTransform source, float x, float y)
		{
			return null;
		}

		public static Vector2 GetAnchorCenter(this RectTransform source)
		{
			return default(Vector2);
		}

		public static Vector2 GetAnchorDelta(this RectTransform source)
		{
			return default(Vector2);
		}
	}
}
