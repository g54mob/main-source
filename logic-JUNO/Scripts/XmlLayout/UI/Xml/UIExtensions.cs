using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml
{
	public static class UIExtensions
	{
		public static void SetSelectedValue(this Dropdown dropdown, string value, int attempt = 0)
		{
			Dropdown.OptionData optionData = dropdown.options.FirstOrDefault((Dropdown.OptionData o) => o.text.Equals(value, StringComparison.OrdinalIgnoreCase));
			if (optionData == null && attempt < 3)
			{
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					dropdown.SetSelectedValue(value, ++attempt);
				}, dropdown);
				return;
			}
			if (optionData != null)
			{
				dropdown.value = dropdown.options.IndexOf(optionData);
				dropdown.RefreshShownValue();
				return;
			}
			Debug.Log("Dropdown.SetSelectedValue :: Value '" + value + "' was not found in dropdown '" + dropdown.name + "'.");
		}

		public static void SetSelectedValue(this Dropdown dropdown, int value)
		{
			dropdown.value = value;
			dropdown.RefreshShownValue();
		}

		public static void SetOptions(this Dropdown dropdown, IEnumerable<string> options)
		{
			dropdown.options = options.Select((string s) => new Dropdown.OptionData(s)).ToList();
			dropdown.RefreshShownValue();
		}

		public static void SetOptions(this Dropdown dropdown, params string[] options)
		{
			dropdown.options = options.Select((string s) => new Dropdown.OptionData(s)).ToList();
			dropdown.RefreshShownValue();
		}

		public static ColorBlock SetNormalColor(this ColorBlock colors, Color normalColor)
		{
			ColorBlock result = colors;
			result.normalColor = normalColor;
			return result;
		}
	}
}
