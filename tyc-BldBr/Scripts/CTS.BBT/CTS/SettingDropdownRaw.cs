using System.Collections.Generic;
using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public abstract class SettingDropdownRaw<T> : SettingDropdown<T>
	{
		[SerializeField]
		private SerializableDictionary<T, string> _dropdownOptions = new SerializableDictionary<T, string>();

		protected override void OnAwake()
		{
			base.OnAwake();
			_dropdown.ClearOptions();
			int num = 0;
			foreach (KeyValuePair<T, string> dropdownOption in _dropdownOptions)
			{
				dropdownOption.Deconstruct(out var key, out var value);
				T key2 = key;
				TMP_Dropdown.OptionData item = new TMP_Dropdown.OptionData(value);
				_ids.Add(key2, num++);
				_options.Add(item);
			}
			_dropdown.AddOptions(_options);
		}
	}
}
