using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.Events;

namespace UIScripts.UIReferences
{
	public class EnumDropdown<TType> where TType : Enum, IConvertible
	{
		[SerializeField]
		private SettingDropdownReference SettingDropdownRef;

		private readonly Regex match = new Regex("\\s+");

		public string name;

		public string helperText;

		public TType defaultValue;

		public TType val;

		public bool initialized;

		private readonly UnityEvent<TType> onValueChange = new UnityEvent<TType>();

		public void InitUIElement(SettingDropdownReference dropdownRef, UnityAction<TType> toCallOnChange = null)
		{
			SettingDropdownRef = dropdownRef;
			val = defaultValue;
			if (SettingDropdownRef.settingName != null)
			{
				SettingDropdownRef.settingName.text = name;
			}
			TooltipTrigger component = SettingDropdownRef.settingName.gameObject.GetComponent<TooltipTrigger>();
			if (component != null)
			{
				component.UpdateText(name, helperText);
			}
			if (SettingDropdownRef.dropdown != null)
			{
				SettingDropdownRef.dropdown.ClearOptions();
				List<string> list = Enum.GetNames(typeof(TType)).ToList();
				List<string> newList = new List<string>();
				list.ForEach(delegate(string s)
				{
					newList.Add(AddSpacesToSentence(s));
				});
				SettingDropdownRef.dropdown.AddOptions(newList);
				SettingDropdownRef.dropdown.onValueChanged.AddListener(SetEnumInt);
				if (toCallOnChange != null)
				{
					onValueChange.AddListener(toCallOnChange);
				}
				dropdownRef.dropdown.value = (int)(object)defaultValue;
			}
			initialized = true;
		}

		private void SetEnumInt(int val)
		{
			string value = RemoveSpaces(SettingDropdownRef.dropdown.options[val].text);
			this.val = (TType)Enum.Parse(typeof(TType), value);
			onValueChange.Invoke(this.val);
		}

		private string AddSpacesToSentence(string text, bool preserveAcronyms = true)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(text.Length * 2);
			stringBuilder.Append(text[0]);
			for (int i = 1; i < text.Length; i++)
			{
				if (char.IsUpper(text[i]) && ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) || (preserveAcronyms && char.IsUpper(text[i - 1]) && i < text.Length - 1 && !char.IsUpper(text[i + 1]))))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(text[i]);
			}
			return stringBuilder.ToString();
		}

		private string RemoveSpaces(string text)
		{
			return match.Replace(text, "");
		}
	}
}
