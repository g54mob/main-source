using System.Xml.Linq;
using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets
{
	public class ScrollViewWidget : Widget
	{
		public ScrollRect ScrollRect { get; private set; }

		protected override AttributeSet AttributeSet => WidgetAttributes.Set;

		public override void AddWidget(Widget widget)
		{
			base.AddWidget(widget);
			ScrollRect.content = widget.Rect;
		}

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
			ScrollRect = GetComponent<ScrollRect>();
		}

		public void ScrollToWidget(Widget widget, float offset = 0f)
		{
			float num = ScrollRect.content.rect.height - ScrollRect.viewport.rect.height;
			float num2 = 0f - widget.Rect.localPosition.y - widget.Rect.rect.height * (1f - widget.Rect.pivot.y) + offset;
			float verticalNormalizedPosition = Mathf.Clamp01(1f - num2 / num);
			ScrollRect.verticalNormalizedPosition = verticalNormalizedPosition;
		}
	}
}
