using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Controls
{
	public class ButtonControl : WidgetControl
	{
		private TextWidget _labelText;

		public ButtonWidget Button { get; private set; }

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

		public TextWidget ValueText { get; private set; }

		public ButtonControl(Widget widget)
			: base(widget)
		{
			_labelText = widget.FindWidget<TextWidget>("label-text");
			Button = widget.FindWidget<ButtonWidget>("button");
			ValueText = Button.FindWidget<TextWidget>("value-text");
		}
	}
}
