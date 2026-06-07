using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine;

namespace Jundroo.Juicy.Widgets
{
	public class RowWidget : Widget
	{
		[SerializeField]
		private RectTransform _container;

		public float CellPadding { get; set; }

		public int NumColumns { get; set; } = 12;

		public RectOffset Padding { get; set; } = new RectOffset();

		protected override AttributeSet AttributeSet => RowAttributes.Set;

		public override void AddWidget(Widget widget)
		{
			base.AddWidget(widget);
			SetDirtyFlag(DirtyFlags.UpdateLayout);
		}

		protected override void UpdateLayout()
		{
			base.UpdateLayout();
			int num = 0;
			_container.offsetMin = new Vector2((0f - CellPadding) / 2f, 0f);
			_container.offsetMax = new Vector2(CellPadding / 2f, 0f);
			foreach (Widget widget in base.Widgets)
			{
				if (widget.ColumnSpan > 0)
				{
					num = ((widget.ColumnStart < 0) ? (num + widget.ColumnOffset) : widget.ColumnStart);
					int num2 = num + widget.ColumnSpan;
					widget.Rect.anchorMin = new Vector2((float)num / (float)NumColumns, 0f);
					widget.Rect.anchorMax = new Vector2((float)num2 / (float)NumColumns, 1f);
					widget.Margin = new RectOffset((int)(CellPadding / 2f + (float)widget.ColumnPadding.left), (int)(CellPadding / 2f + (float)widget.ColumnPadding.right), Padding.top + widget.ColumnPadding.top, Padding.bottom + widget.ColumnPadding.bottom);
					num = num2;
				}
			}
		}
	}
}
