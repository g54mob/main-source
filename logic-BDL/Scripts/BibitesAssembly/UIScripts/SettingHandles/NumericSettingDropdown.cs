using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ManagementScripts;
using SettingScripts;
using TMPro;
using UIScripts.SettingHandles.References;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public abstract class NumericSettingDropdown<TSetting, TType> : SettingDropdown<TSetting, TType> where TSetting : NumericSetting<TType> where TType : struct
	{
		private readonly Regex details = new Regex(" \\(([^\\)]+)\\)");

		public bool addDetailsToTooltip = true;

		protected override void PopulateList()
		{
			settingDropdownRef.dropdown.ClearOptions();
			List<string> options = new List<string>();
			setting.landmarks.ForEach(delegate(SettingLandmarkValues<TType> l)
			{
				options.Add(l.label);
			});
			settingDropdownRef.dropdown.AddOptions(options);
			settingDropdownRef.onItemHovered = OnItemHovered;
		}

		protected void InitUIElement(SettingDropdownReference dropdownReference, bool addValuesInfoToTooltip)
		{
			addDetailsToTooltip = addValuesInfoToTooltip;
			InitUIElement(dropdownReference);
		}

		private void OnItemHovered(int i, bool hovering)
		{
			if (hovering)
			{
				_ = (float)(dynamic)setting.landmarks[i].value;
				string content = (string.IsNullOrEmpty(setting.landmarks[i].tooltip) ? FormattedValueOfLandmark(setting.landmarks[i]) : setting.landmarks[i].tooltip);
				TooltipSystem.Show(setting.Name + ": " + setting.landmarks[i].label, content);
			}
			else
			{
				TooltipSystem.Hide();
			}
		}

		protected override void SetValueOfSetting(int val)
		{
			string text = settingDropdownRef.dropdown.options[val].text;
			SettingLandmarkValues<TType> settingLandmarkValues = setting.landmarks.FirstOrDefault((SettingLandmarkValues<TType> l) => l.label == text);
			if (settingLandmarkValues != null)
			{
				SetValue(settingLandmarkValues.value);
			}
		}

		public override void UpdateUIElement()
		{
			dynamic newValue = setting.val;
			SettingLandmarkValues<TType> closestLandmark = setting.landmarks.OrderBy((SettingLandmarkValues<TType> l) => Mathf.Abs((dynamic)l.value - newValue)).FirstOrDefault();
			if (closestLandmark != null)
			{
				int valueWithoutNotify = settingDropdownRef.dropdown.options.IndexOf(settingDropdownRef.dropdown.options.First((TMP_Dropdown.OptionData o) => o.text == closestLandmark.label));
				settingDropdownRef.dropdown.SetValueWithoutNotify(valueWithoutNotify);
			}
		}

		protected abstract string FormattedValueOfLandmark(SettingLandmarkValues<TType> landmark);

		public NumericSettingDropdown(TSetting setting)
			: base(setting)
		{
		}
	}
}
