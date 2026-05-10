using System.Collections.Generic;
using CTS.Core;
using CTS.ScriptableSettings;
using TMPro;
using UnityEngine;

namespace CTS
{
	public abstract class SettingDropdown<T> : CTSBehaviour
	{
		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		protected TMP_Dropdown _dropdown;

		[SerializeField]
		private SettingObject<T> _setting;

		protected Bictionary<T, int> _ids = new Bictionary<T, int>();

		protected List<TMP_Dropdown.OptionData> _options = new List<TMP_Dropdown.OptionData>();

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_dropdown.onValueChanged.AddListener(OnDropdownChanged);
			_setting.ValueChanged += OnSettingChanged;
			OnSettingChanged(_setting.GetValue());
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_dropdown.onValueChanged.RemoveListener(OnDropdownChanged);
			_setting.ValueChanged -= OnSettingChanged;
		}

		private void OnSettingChanged(T newValue)
		{
			if (_ids.TryGet(newValue, out var value))
			{
				_dropdown.value = value;
			}
			else
			{
				_dropdown.captionText.text = _setting.GetCurrentValueName();
			}
		}

		private void OnDropdownChanged(int index)
		{
			_setting.SetValue(_ids[index]);
		}
	}
}
