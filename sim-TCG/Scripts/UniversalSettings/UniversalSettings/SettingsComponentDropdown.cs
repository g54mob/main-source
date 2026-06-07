using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UniversalSettings
{
	[DisallowMultipleComponent]
	public abstract class SettingsComponentDropdown : SettingsComponent
	{
		protected TMP_Dropdown tmpDropdown;

		protected Dropdown legacyDropdown;

		protected bool invertedIndex;

		protected virtual ref int SettingsValue()
		{
			throw new Exception("SettingsValue was not implemented!");
		}

		protected virtual bool AutoApplyValue()
		{
			throw new Exception("AutoApplyValue was not implemented!");
		}

		protected virtual void OnValueChanged(int value)
		{
			SettingsValue() = ProcessValue(value);
			if (AutoApplyValue())
			{
				AutoApply();
			}
			else
			{
				universalSettings.RegisterSettingsChange();
			}
		}

		protected void CreateOptions(List<string> options)
		{
			tmpDropdown?.options.Clear();
			legacyDropdown?.options.Clear();
			foreach (string option in options)
			{
				tmpDropdown?.options.Add(new TMP_Dropdown.OptionData(option));
				legacyDropdown?.options.Add(new Dropdown.OptionData(option));
			}
			tmpDropdown?.SetValueWithoutNotify(0);
			legacyDropdown?.SetValueWithoutNotify(0);
		}

		protected void SetDropdownActive(bool value)
		{
			if ((bool)tmpDropdown)
			{
				tmpDropdown.interactable = value;
			}
			if ((bool)legacyDropdown)
			{
				legacyDropdown.interactable = value;
			}
		}

		internal override void Initialize(UniversalSettingsRunner universalSettings)
		{
			base.Initialize(universalSettings);
			tmpDropdown = GetComponent<TMP_Dropdown>();
			if (tmpDropdown == null)
			{
				legacyDropdown = GetComponent<Dropdown>();
			}
			tmpDropdown?.onValueChanged.AddListener(OnValueChanged);
			legacyDropdown?.onValueChanged.AddListener(OnValueChanged);
			Setup();
		}

		internal override void UpdateComponent(SettingsProfile settings)
		{
			int valueWithoutNotify = ProcessValue(SettingsValue());
			tmpDropdown?.SetValueWithoutNotify(valueWithoutNotify);
			legacyDropdown?.SetValueWithoutNotify(valueWithoutNotify);
			tmpDropdown?.RefreshShownValue();
			legacyDropdown?.RefreshShownValue();
		}

		protected void AddOption(string option)
		{
			tmpDropdown?.options.Add(new TMP_Dropdown.OptionData(option));
			legacyDropdown?.options.Add(new Dropdown.OptionData(option));
		}

		protected void RemoveOption(int index)
		{
			tmpDropdown?.options.RemoveAt(index);
			legacyDropdown?.options.RemoveAt(index);
		}

		protected int GetOptionsCount()
		{
			if ((bool)tmpDropdown)
			{
				return tmpDropdown.options.Count;
			}
			return legacyDropdown.options.Count;
		}

		private int ProcessValue(int value)
		{
			int num = GetOptionsCount() - 1;
			if (invertedIndex)
			{
				return Math.Max(0, num - value);
			}
			return Math.Min(value, num);
		}

		private void OnDestroy()
		{
			if ((bool)tmpDropdown)
			{
				tmpDropdown.onValueChanged.RemoveListener(OnValueChanged);
			}
			if ((bool)legacyDropdown)
			{
				legacyDropdown.onValueChanged.RemoveListener(OnValueChanged);
			}
		}
	}
}
