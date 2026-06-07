using System;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Controls
{
	public class TextInputControl : WidgetControl
	{
		private TextWidget _labelText;

		public InputWidget InputField { get; private set; }

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

		public Action<string> OnValueChanged { get; set; }

		public string Value
		{
			get
			{
				return InputField.Text;
			}
			set
			{
				InputField.Text = value;
			}
		}

		public decimal ValueAsDecimal
		{
			get
			{
				if (decimal.TryParse(Value, out var result))
				{
					return result;
				}
				return 0m;
			}
			set
			{
				Value = value.ToString();
			}
		}

		public TextInputControl(Widget widget)
			: base(widget)
		{
			_labelText = widget.FindWidget<TextWidget>("label-text");
			InputField = widget.FindWidget<InputWidget>("value-input");
			InputField.Input.onEndEdit.AddListener(OnInputEndEdit);
		}

		public override void Update()
		{
			base.Update();
		}

		private void OnInputEndEdit(string value)
		{
			Value = value;
			OnValueChanged?.Invoke(Value);
		}
	}
}
