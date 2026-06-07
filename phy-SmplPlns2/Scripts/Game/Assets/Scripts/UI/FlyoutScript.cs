using System;
using Jundroo.Common.DataTypes;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI
{
	public class FlyoutScript : WidgetScript, IFlyout
	{
		private Widget _titleText;

		public static bool SkipAnimations { get; set; }

		public string Id => base.Widget.Id;

		public bool IsClosing { get; private set; }

		public bool IsOpen => base.Widget.Visible;

		public string Title
		{
			get
			{
				return _titleText.GetStyle("text");
			}
			set
			{
				_titleText.SetStyle("text", value);
			}
		}

		public float Width => base.Widget.Width.GetValueOrDefault();

		Widget IFlyout.Widget => base.Widget;

		public event FlyoutDelegate Closed;

		public event FlyoutDelegate HeaderClicked;

		public event FlyoutDelegate Opened;

		public static IDisposable TemporarilySkipAnimations()
		{
			SkipAnimations = true;
			return new DisposableAction(delegate
			{
				SkipAnimations = false;
			});
		}

		public void Close()
		{
			IsClosing = true;
			base.Widget.Hide(null, force: false, SkipAnimations);
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			widget.Shown += OnWidgetShown;
			widget.Hidden += OnWidgetHidden;
			_titleText = widget.FindWidget("flyout-title-text");
		}

		public void Show(bool show)
		{
			if (show)
			{
				IsClosing = false;
				base.Widget.Show(force: true, SkipAnimations);
			}
			else
			{
				IsClosing = true;
				base.Widget.Hide(null, force: true, SkipAnimations);
			}
		}

		private void OnDismissClicked(Widget widget)
		{
			Close();
		}

		private void OnHeaderClicked(Widget widget)
		{
			if (this.HeaderClicked != null)
			{
				this.HeaderClicked?.Invoke(this);
			}
			else
			{
				Close();
			}
		}

		private void OnWidgetHidden(Widget widget)
		{
			this.Closed?.Invoke(this);
			IsClosing = false;
		}

		private void OnWidgetShown(Widget widget)
		{
			this.Opened?.Invoke(this);
		}
	}
}
