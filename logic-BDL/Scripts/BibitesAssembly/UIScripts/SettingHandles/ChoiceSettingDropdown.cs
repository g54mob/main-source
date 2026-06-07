using System;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using SettingScripts;
using TMPro;
using UIScripts.SettingHandles.References;

namespace UIScripts.SettingHandles
{
	public class ChoiceSettingDropdown<TSetting, TType> : SettingDropdown<TSetting, TType> where TSetting : EnumSetting<TType> where TType : struct, Enum
	{
		private bool hasChoices;

		private bool labelCheated;

		protected override void PopulateList()
		{
			settingDropdownRef.dropdown.ClearOptions();
			hasChoices = setting.hasChoices;
			if (!hasChoices)
			{
				List<string> list = Enum.GetNames(typeof(TType)).ToList();
				List<string> newList = new List<string>();
				list.ForEach(delegate(string s)
				{
					newList.Add(SettingDropdown<TSetting, TType>.AddSpacesToSentence(s));
				});
				settingDropdownRef.dropdown.AddOptions(newList);
				return;
			}
			List<string> list2 = new List<string>();
			foreach (SettingChoice<TType> choice in setting.choices.choices)
			{
				list2.Add(choice.label);
			}
			settingDropdownRef.dropdown.AddOptions(list2);
			settingDropdownRef.onItemHovered = OnItemHovered;
		}

		private void OnItemHovered(int i, bool hovering)
		{
			if (hovering)
			{
				SettingChoice<TType> settingChoice = setting.choices[i];
				TooltipSystem.Show(setting.Name + ": " + settingChoice.label, settingChoice.tooltipText);
			}
			else
			{
				TooltipSystem.Hide();
			}
		}

		protected override void SetValueOfSetting(int val)
		{
			TType value;
			if (hasChoices)
			{
				value = setting.choices[val].val;
			}
			else
			{
				string value2 = RemoveSpaces(settingDropdownRef.dropdown.options[val].text);
				value = (TType)Enum.Parse(typeof(TType), value2);
			}
			SetValue(value);
		}

		public override void UpdateUIElement()
		{
			if (hasChoices)
			{
				int num = setting.choices.IndexOfValue(setting.val);
				if (num >= 0)
				{
					settingDropdownRef.dropdown.value = num;
					return;
				}
				settingDropdownRef.dropdown.captionText.text = SettingDropdown<TSetting, TType>.AddSpacesToSentence(setting.val.ToString());
				labelCheated = true;
				return;
			}
			string name = SettingDropdown<TSetting, TType>.AddSpacesToSentence(setting.val.ToString());
			settingDropdownRef.dropdown.value = settingDropdownRef.dropdown.options.FindIndex((TMP_Dropdown.OptionData o) => o.text == name);
			if (labelCheated)
			{
				settingDropdownRef.dropdown.RefreshShownValue();
				labelCheated = false;
			}
		}

		public ChoiceSettingDropdown(TSetting _setting, SettingDropdownReference reference)
			: base(_setting, reference)
		{
		}

		public ChoiceSettingDropdown(TSetting _setting)
			: base(_setting)
		{
		}

		public ChoiceSettingDropdown()
		{
		}
	}
}
