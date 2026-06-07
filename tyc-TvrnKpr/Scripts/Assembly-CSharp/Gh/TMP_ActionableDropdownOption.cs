using System;
using TMPro;

namespace Gh
{
	public class TMP_ActionableDropdownOption<T> : TMP_Dropdown.OptionData
	{
		private Action<T> _onSelected;

		public T Value { get; private set; }

		public TMP_ActionableDropdownOption(T value, string label, Action<T> onSelected)
		{
		}

		public void OnSelected()
		{
		}
	}
}
