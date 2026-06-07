using TMPro;
using UnityEngine;

namespace ModularOptions
{
	[RequireComponent(typeof(TMP_Dropdown))]
	public abstract class DropdownOption : OptionBase<int, IntDropdown>
	{
		protected TMP_Dropdown dropdown;

		public override int Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		protected void OnValueChange(int _value)
		{
		}
	}
}
