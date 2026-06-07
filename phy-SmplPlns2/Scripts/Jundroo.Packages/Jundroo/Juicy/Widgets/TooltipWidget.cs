using System.Xml.Linq;
using Jundroo.Juicy.Widgets.Serialization;
using TMPro;
using UnityEngine;

namespace Jundroo.Juicy.Widgets
{
	public class TooltipWidget : LayoutWidget
	{
		private Canvas _canvas;

		public float Distance { get; set; } = 10f;

		public float TooltipDuration { get; set; } = 5f;

		protected override AttributeSet AttributeSet => TooltipAttributes.Set;

		public void ConfigureForWidget(Widget widget)
		{
			SetText(widget.Tooltip);
			Vector2 pivot = new Vector2(0.5f, 0.5f);
			Vector2 zero = Vector2.zero;
			switch (widget.TooltipPosition)
			{
			case TooltipPosition.Above:
				pivot = new Vector2(0.5f, 0f);
				zero.x = widget.Rect.rect.center.x;
				zero.y = widget.Rect.rect.yMax + Distance;
				break;
			case TooltipPosition.Below:
				pivot = new Vector2(0.5f, 1f);
				zero.x = widget.Rect.rect.center.x;
				zero.y = widget.Rect.rect.yMin - Distance;
				break;
			case TooltipPosition.Left:
				pivot = new Vector2(1f, 0.5f);
				zero.x = widget.Rect.rect.xMin - Distance;
				zero.y = widget.Rect.rect.center.y;
				break;
			case TooltipPosition.Right:
				pivot = new Vector2(0f, 0.5f);
				zero.x = widget.Rect.rect.xMax + Distance;
				zero.y = widget.Rect.rect.center.y;
				break;
			}
			base.Rect.pivot = pivot;
			Vector3 position = widget.Rect.TransformPoint(zero);
			base.Rect.position = position;
			if (base.Animation.ShowAnimation != null && widget.TooltipDelay.HasValue)
			{
				base.Animation.ShowAnimation.Delay = widget.TooltipDelay.Value;
			}
		}

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
		}

		public void SetText(string tooltip)
		{
			TextMeshProUGUI componentInChildren = GetComponentInChildren<TextMeshProUGUI>();
			tooltip = tooltip.Replace("\\n", "\n");
			componentInChildren.text = base.Context.TooltipService?.ProcessTooltipText(tooltip) ?? tooltip;
		}
	}
}
