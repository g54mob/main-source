using System;

namespace ModApi.Ui.Inspector
{
	public class EnumDropdownModel<T> : DropdownModel where T : struct, IConvertible
	{
		public delegate void ValueChangedHandler(T newVal, T oldVal);

		private T _value;

		public event ValueChangedHandler ValueChanged;

		public EnumDropdownModel(string label, Func<T> getter, string tooltip = null)
			: base(label)
		{
			EnumDropdownModel<T> enumDropdownModel = this;
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an enum type.");
			}
			foreach (T value in Utilities.Enums.GetValues<T>())
			{
				string displayName = Utilities.FormatCodeToDisplayName(Utilities.Enums.GetDisplayName(value));
				base.Options.Add(new DropdownOption(displayName, value.ToString()));
			}
			InitializeCallbacks(() => getter().ToString(), delegate(string x)
			{
				enumDropdownModel.OnValueChanged(Utilities.Enums.Parse<T>(x));
			});
			base.Tooltip = tooltip;
		}

		private void OnValueChanged(T newValue)
		{
			T value = _value;
			_value = newValue;
			this.ValueChanged?.Invoke(newValue, value);
		}
	}
}
