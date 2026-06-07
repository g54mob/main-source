using System;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Controls
{
	public class WidgetControl
	{
		public Func<bool> DetermineVisibility { get; set; }

		public bool Visible
		{
			get
			{
				return Widget.Visible;
			}
			set
			{
				Widget.Visible = value;
			}
		}

		public Widget Widget { get; }

		public WidgetControl(Widget widget)
		{
			if (widget == null)
			{
				throw new ArgumentNullException("widget");
			}
			Widget = widget;
			widget.EventHandler = this;
		}

		public virtual void Update()
		{
		}

		public void UpdateVisibility(bool parentsVisible)
		{
			Visible = parentsVisible && (DetermineVisibility?.Invoke() ?? true);
		}
	}
}
