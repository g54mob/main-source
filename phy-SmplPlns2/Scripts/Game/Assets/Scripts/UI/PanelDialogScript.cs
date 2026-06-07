using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI
{
	public abstract class PanelDialogScript : DialogScript
	{
		private Widget _header;

		private TextWidget _headerText;

		public Widget Panel { get; private set; }

		public string Title
		{
			get
			{
				return _headerText.Text;
			}
			set
			{
				_headerText.Text = value;
				_header.Visible = !string.IsNullOrEmpty(value);
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			Panel = widget.FindWidget("panel");
			_header = widget.FindWidget("header");
			_headerText = _header.FindWidget<TextWidget>("header-text");
			Panel.Visible = false;
			_header.Visible = !string.IsNullOrEmpty(_headerText.Text);
		}

		protected override void DestroyDialog()
		{
			Panel.Hide(delegate
			{
				base.Widget.Destroy();
			}, force: true);
		}

		protected override void Start()
		{
			Panel.Show();
		}
	}
}
