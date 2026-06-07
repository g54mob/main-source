using System;

namespace ModApi.Ui.Inspector
{
	public class ToggleModel : ValueModel<bool>
	{
		private Action<bool> _action;

		private Func<bool> _valueGetter;

		public string Label { get; set; }

		public ToggleModel(string label, Func<bool> valueGetter, Action<bool> valueSetter, string tooltip = null)
			: base(valueGetter, valueSetter)
		{
			Label = label;
			base.Tooltip = tooltip;
		}
	}
}
