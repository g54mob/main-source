using System;
using System.Collections.Generic;

namespace ModApi.Ui.Inspector
{
	public class DropdownModel : ItemModel, IValueChanged
	{
		public class DropdownOption
		{
			public string DisplayName { get; set; }

			public string Value { get; set; }

			public DropdownOption(string displayName, string value)
			{
				DisplayName = displayName;
				Value = value;
			}
		}

		private Action<string> _action;

		private Func<string> _valueGetter;

		public ElementAlignment Alignment { get; set; }

		public string Label { get; set; }

		public List<DropdownOption> Options { get; private set; }

		public string Value => _valueGetter();

		public event ValueChangedDelegate ValueChangedByUserInput;

		public DropdownModel(string label, IEnumerable<string> options = null)
			: this(label, null, null, options)
		{
		}

		public DropdownModel(string label, Func<string> valueGetter, Action<string> action, IEnumerable<string> options = null)
		{
			InitializeCallbacks(valueGetter, action);
			_action = action;
			_valueGetter = valueGetter;
			Label = label;
			Options = new List<DropdownOption>();
			if (options == null)
			{
				return;
			}
			foreach (string option in options)
			{
				Options.Add(new DropdownOption(option, option));
			}
		}

		public void OnChanged(string value)
		{
			_action(value);
			this.ValueChangedByUserInput?.Invoke(this, Label, finished: true);
		}

		protected void InitializeCallbacks(Func<string> valueGetter, Action<string> action)
		{
			_valueGetter = valueGetter;
			_action = action;
		}
	}
}
