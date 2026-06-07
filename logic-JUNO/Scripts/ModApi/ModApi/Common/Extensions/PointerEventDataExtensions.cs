using ModApi.Input.Events;
using UnityEngine.EventSystems;

namespace ModApi.Common.Extensions
{
	public static class PointerEventDataExtensions
	{
		public static InputButton InputButton(this PointerEventData pointerEventData)
		{
			return (InputButton)pointerEventData.button;
		}

		public static bool IsTouch(this PointerEventData pointerEventData)
		{
			return pointerEventData.pointerId >= 0;
		}

		public static bool IsTouchPrimary(this PointerEventData pointerEventData)
		{
			if (pointerEventData.pointerId >= 0)
			{
				return pointerEventData.button == PointerEventData.InputButton.Left;
			}
			return false;
		}
	}
}
