using System;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Controls
{
	public class ToggleControl : WidgetControl
	{
		private bool _ignoreChanges;

		private TextWidget _labelText;

		private Widget _optionNo;

		private Widget _optionYes;

		public bool IsOn
		{
			get
			{
				return Toggle.IsOn;
			}
			set
			{
				_ignoreChanges = Toggle.IsOn != value;
				Toggle.IsOn = value;
				_ignoreChanges = false;
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

		public ToggleWidget Toggle { get; private set; }

		public event Action<bool> ValueChanged;

		public ToggleControl(Widget widget)
			: base(widget)
		{
			_labelText = widget.FindWidget<TextWidget>("label-text");
			Toggle = widget.FindWidget<ToggleWidget>("toggle-value");
			_optionNo = widget.FindWidget("option-no");
			_optionYes = widget.FindWidget("option-yes");
			_ignoreChanges = true;
			OnValueChanged(Toggle.IsOn);
			_ignoreChanges = false;
			Toggle.ValueChanged += OnValueChanged;
		}

		private void OnValueChanged(bool on)
		{
			_optionYes?.EnableClass("toggle-option-selected", on);
			_optionNo?.EnableClass("toggle-option-selected", !on);
			if (!_ignoreChanges)
			{
				this.ValueChanged?.Invoke(on);
			}
		}
	}
}
