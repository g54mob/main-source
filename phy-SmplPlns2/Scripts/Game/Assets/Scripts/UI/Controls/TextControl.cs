using System;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Controls
{
	public class TextControl : WidgetControl
	{
		private TextWidget _labelText;

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

		public Func<string> LabelTextGetter { get; set; }

		public TextWidget ValueText { get; private set; }

		public Func<string> ValueTextGetter { get; set; }

		public TextControl(Widget widget)
			: base(widget)
		{
			_labelText = widget.FindWidget<TextWidget>("label-text");
			ValueText = widget.FindWidget<TextWidget>("value-text");
		}

		public override void Update()
		{
			base.Update();
			if (ValueTextGetter != null)
			{
				ValueText.Text = ValueTextGetter();
			}
			if (LabelTextGetter != null)
			{
				LabelText = LabelTextGetter();
			}
		}
	}
}
