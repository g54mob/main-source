using Helpers.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.CommonElements
{
	[RequireComponent(typeof(ScrollRect))]
	public abstract class BaseScrollRectAutoPosition : MonoBehaviour
	{
		[SerializeField]
		protected bool horizontal;

		[SerializeField]
		protected bool vertical = true;

		[SerializeField]
		protected float scrollPadding;

		[SerializeField]
		protected ScrollRect scrollRect;

		public void ForceSetPositionToTarget(RectTransform element)
		{
			UpdatePosition(element);
		}

		protected virtual void UpdatePosition(RectTransform element)
		{
			if (horizontal)
			{
				UpdateHorizontalPosition(element);
			}
			if (vertical)
			{
				UpdateVerticalPosition(element);
			}
		}

		protected virtual void UpdateHorizontalPosition(RectTransform element)
		{
			Rect rect = scrollRect.viewport.rect;
			Rect rect2 = element.rect.Transform(element).InverseTransform(scrollRect.viewport);
			float num = rect2.xMax + scrollPadding - rect.xMax;
			float num2 = rect.xMin - (rect2.xMin - scrollPadding);
			if (num < 0f)
			{
				num = 0f;
			}
			if (num2 < 0f)
			{
				num2 = 0f;
			}
			float num3 = ((num > 0f) ? num : (0f - num2));
			if (num3 != 0f)
			{
				float num4 = scrollRect.content.rect.Transform(scrollRect.content).InverseTransform(scrollRect.viewport).width - rect.width;
				float num5 = 1f / num4;
				scrollRect.horizontalNormalizedPosition += num3 * num5;
			}
		}

		protected virtual void UpdateVerticalPosition(RectTransform element)
		{
			Rect rect = scrollRect.viewport.rect;
			Rect rect2 = element.rect.Transform(element).InverseTransform(scrollRect.viewport);
			float num = rect2.yMax + scrollPadding - rect.yMax;
			float num2 = rect.yMin - (rect2.yMin - scrollPadding);
			if (num < 0f)
			{
				num = 0f;
			}
			if (num2 < 0f)
			{
				num2 = 0f;
			}
			float num3 = ((num > 0f) ? num : (0f - num2));
			if (num3 != 0f)
			{
				float num4 = scrollRect.content.rect.Transform(scrollRect.content).InverseTransform(scrollRect.viewport).height - rect.height;
				float num5 = 1f / num4;
				scrollRect.verticalNormalizedPosition += num3 * num5;
			}
		}
	}
}
