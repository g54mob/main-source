using System.Collections.Generic;
using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public abstract class SettingDropdownLocalized<T> : SettingDropdown<T>
	{
		[SerializeField]
		private SerializableDictionary<T, LocalizedString> _dropdownOptions = new SerializableDictionary<T, LocalizedString>();

		protected override void OnAwake()
		{
			base.OnAwake();
			_dropdown.ClearOptions();
			int num = 0;
			foreach (KeyValuePair<T, LocalizedString> dropdownOption in _dropdownOptions)
			{
				dropdownOption.Deconstruct(out var key, out var value);
				T key2 = key;
				TMP_Dropdown.OptionData item = new TMP_Dropdown.OptionData(value.GetLocalizedString());
				_ids.Add(key2, num++);
				_options.Add(item);
			}
			_dropdown.AddOptions(_options);
		}
	}
}
