using System;
using System.Collections.Generic;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI
{
	public class HeaderScript : WidgetScript
	{
		public class CollapsedStateChangedEventArgs : EventArgs
		{
			public HeaderScript Header { get; set; }

			public bool IsCollapsed { get; }

			public CollapsedStateChangedEventArgs(HeaderScript header, bool isCollapsed)
			{
				Header = header;
				IsCollapsed = isCollapsed;
			}
		}

		private bool _collapsed;

		private TextWidget _labelText;

		private List<Widget> _widgets = new List<Widget>();

		public bool Collapsed
		{
			get
			{
				return _collapsed;
			}
			set
			{
				if (_collapsed == value)
				{
					return;
				}
				_collapsed = value;
				if (value)
				{
					for (int i = base.Widget.Index + 1; i < base.Widget.Parent.Widgets.Count; i++)
					{
						Widget widget = base.Widget.Parent.Widgets[i];
						if (widget.HasClass("control-header") || widget.HasClass("control-header-break"))
						{
							break;
						}
						AddWidget(widget);
					}
					foreach (Widget widget3 in _widgets)
					{
						widget3.Collapsed = true;
					}
				}
				else
				{
					Widget[] array = _widgets.ToArray();
					foreach (Widget widget2 in array)
					{
						widget2.Collapsed = false;
						RemoveWidget(widget2);
					}
				}
				base.Widget.EnableClass("control-header-collapsed", _collapsed);
				this.CollapsedStateChanged?.Invoke(this, new CollapsedStateChangedEventArgs(this, _collapsed));
			}
		}

		public string LabelText
		{
			get
			{
				return _labelText.Text;
			}
			set
			{
				_labelText.Text = value;
			}
		}

		public bool StartCollapsed { get; set; }

		public event EventHandler<CollapsedStateChangedEventArgs> CollapsedStateChanged;

		public void OnClicked(Widget widget)
		{
			Collapsed = !Collapsed;
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_labelText = widget.FindWidget<TextWidget>("label-text");
		}

		protected void Start()
		{
			if (StartCollapsed)
			{
				Collapsed = true;
			}
		}

		private void AddWidget(Widget widget)
		{
			widget.Destroyed += OnWidgetDestroyed;
			_widgets.Add(widget);
		}

		private void OnWidgetDestroyed(Widget widget)
		{
			RemoveWidget(widget);
		}

		private void RemoveWidget(Widget widget)
		{
			widget.Destroyed -= OnWidgetDestroyed;
			_widgets.Remove(widget);
		}
	}
}
