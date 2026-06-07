using UnityEngine;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class WidgetPositionConstraint : MonoBehaviour
	{
		private Canvas _canvas;

		private Widget _widget;

		protected virtual void Start()
		{
			_canvas = GetRootCanvas();
			_widget = GetComponent<Widget>();
		}

		protected virtual void Update()
		{
			if (_widget.PositionConstraint == Widget.WidgetPositionConstraintType.Screen)
			{
				EnsureFullyVisible();
			}
		}

		private void EnsureFullyVisible()
		{
			RectTransform rect = _widget.Rect;
			if (!(rect == null) && !(_canvas == null))
			{
				Vector3[] array = new Vector3[4];
				rect.GetWorldCorners(array);
				Vector2 size = _canvas.pixelRect.size;
				float num = 0f;
				float num2 = 0f;
				Vector2 size2 = _widget.Rect.rect.size;
				if (array[0].x < 0f || size2.x * _canvas.scaleFactor > size.x)
				{
					num = 0f - Mathf.Min(0f, array[0].x);
				}
				else if (array[2].x > size.x)
				{
					num = size.x - array[2].x;
				}
				if (array[0].y < 0f || size2.y * _canvas.scaleFactor > size.y)
				{
					num2 = 0f - Mathf.Min(0f, array[0].y);
				}
				else if (array[2].y > size.y)
				{
					num2 = size.y - array[2].y;
				}
				if (num != 0f || num2 != 0f)
				{
					Vector2 anchoredPosition = rect.anchoredPosition;
					anchoredPosition.x += num;
					anchoredPosition.y += num2;
					rect.anchoredPosition = anchoredPosition;
				}
			}
		}

		private Canvas GetRootCanvas()
		{
			Canvas canvas = GetComponentInParent<Canvas>();
			Canvas component;
			while (canvas?.transform?.parent != null && canvas.transform.parent.TryGetComponent<Canvas>(out component))
			{
				canvas = component;
			}
			return canvas;
		}
	}
}
