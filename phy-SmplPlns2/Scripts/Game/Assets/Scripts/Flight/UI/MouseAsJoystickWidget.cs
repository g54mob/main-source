using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class MouseAsJoystickWidget : WidgetScript
	{
		private Widget _mousePitch;

		private Widget _mouseRoll;

		private bool _visible;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_mousePitch = widget.FindWidget("mouse-as-joystick-pitch");
			_mouseRoll = widget.FindWidget("mouse-as-joystick-roll");
		}

		public void SetVisibility(bool visible)
		{
			if (_visible != visible)
			{
				_visible = visible;
				Cursor.visible = !visible;
				base.Widget.Visible = visible;
			}
		}

		public void UpdateFromMouse(Vector2 mousePosition, Vector2 mouseAxis)
		{
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(base.Widget.Parent.Rect, mousePosition, null, out var localPoint))
			{
				base.Widget.Rect.localPosition = localPoint;
				RectTransform rect = _mousePitch.Rect;
				Vector2 anchorMin = (_mousePitch.Rect.anchorMax = new Vector2(0.5f, Mathf.InverseLerp(-0.5f, 0.5f, mouseAxis.y)));
				rect.anchorMin = anchorMin;
				RectTransform rect2 = _mouseRoll.Rect;
				anchorMin = (_mouseRoll.Rect.anchorMax = new Vector2(Mathf.InverseLerp(-0.5f, 0.5f, mouseAxis.x), 0.5f));
				rect2.anchorMin = anchorMin;
			}
		}

		protected virtual void OnDisable()
		{
			Cursor.visible = true;
		}

		protected virtual void OnEnable()
		{
			Cursor.visible = !_visible;
		}
	}
}
