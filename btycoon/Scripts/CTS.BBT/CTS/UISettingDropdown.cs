using System.Collections.Generic;
using CTS.Core.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public abstract class UISettingDropdown<T> : UISetting<T>
	{
		[SerializeField]
		private TMP_Dropdown _dropdown;

		[SerializeField]
		private TMP_Text _valueText;

		[SerializeField]
		private Transform _templateAnchorPoint;

		protected readonly List<T> _values = new List<T>();

		private List<TMP_Dropdown.OptionData> _optionList = new List<TMP_Dropdown.OptionData>();

		protected override void OnAwake()
		{
			base.OnAwake();
			_dropdown.onValueChanged.AddListener(OnValueChanged);
			_setting.ValueChanged += OnSettingValueChanged;
			OnSettingValueChanged(_setting);
			_dropdown.template.SetParent(base.transform.parent, worldPositionStays: true);
		}

		public void RepaintTemplate()
		{
			_dropdown.template.position = _templateAnchorPoint.position;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			LocalizationSettings.SelectedLocaleChanged += OnLocalizationChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			LocalizationSettings.SelectedLocaleChanged -= OnLocalizationChanged;
		}

		private void OnLocalizationChanged(Locale obj)
		{
			for (int i = 0; i < _values.Count; i++)
			{
				_dropdown.options[i].text = ToString(_values[i]);
			}
		}

		public void AddValue(T value)
		{
			if (!_values.Contains(value))
			{
				_optionList.Clear();
				TMP_Dropdown.OptionData item = new TMP_Dropdown.OptionData
				{
					text = ToString(value)
				};
				_optionList.Add(item);
				_dropdown.AddOptions(_optionList);
				_values.Add(value);
			}
		}

		private void OnSettingValueChanged(T obj)
		{
			_valueText.text = ToString(obj);
			int num = IndexOf(obj);
			if (num.IsCorrectArrayIndex(_values))
			{
				_dropdown.value = num;
			}
		}

		private void OnValueChanged(int index)
		{
			if (!index.IsCorrectArrayIndex(_values))
			{
				index = 0;
			}
			_setting.SetValue(_values[index]);
		}

		protected abstract string ToString(T obj);

		protected abstract int IndexOf(T obj);
	}
}
