using UnityEngine;
using UnityEngine.UI;

namespace FractureField
{
	public static class ScrollRectExtensions
	{
		public enum ScrollRectContentPosition
		{
			Top = 0,
			Middle = 1
		}

		public static void ScrollToTop(this ScrollRect scrollRect)
		{
		}

		public static void ScrollToBottom(this ScrollRect scrollRect)
		{
		}

		public static void ScrollTo(this ScrollRect scrollRect, RectTransform targetRect, ScrollRectContentPosition contentPosition = ScrollRectContentPosition.Top, float offset = 0f)
		{
		}
	}
}
