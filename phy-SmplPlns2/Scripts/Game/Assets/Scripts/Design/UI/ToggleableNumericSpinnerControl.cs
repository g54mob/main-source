using System;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI
{
	public class ToggleableNumericSpinnerControl : NumericSpinnerControl
	{
		private bool _isToggled = true;

		public Action<ToggleableNumericSpinnerControl, bool> OnToggleChanged { get; set; }

		public ButtonWidget ToggleButton { get; private set; }

		public bool IsToggled
		{
			get
			{
				return _isToggled;
			}
			set
			{
				SetToggled(value);
			}
		}

		public ToggleableNumericSpinnerControl(Widget widget)
			: base(widget)
		{
			ToggleButton = widget.FindWidget<ButtonWidget>("button-toggle");
			ToggleButton.Clicked += delegate
			{
				IsToggled = !IsToggled;
			};
		}

		public void SetToggled(bool toggled, bool notify = true)
		{
			if (_isToggled != toggled)
			{
				_isToggled = toggled;
				UpdateVisualToggleState();
				if (notify)
				{
					OnToggleChanged?.Invoke(this, toggled);
				}
			}
		}

		private void UpdateVisualToggleState()
		{
			ToggleButton.EnableClass("btn-primary", _isToggled);
			ToggleButton.EnableClass("btn-default", !_isToggled);
		}
	}
}
