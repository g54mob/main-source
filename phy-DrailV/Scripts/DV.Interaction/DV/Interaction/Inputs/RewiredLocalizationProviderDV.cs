using System.Collections.Generic;
using DV.Localization;
using DV.Utils;
using Rewired;
using Rewired.Interfaces;
using UnityEngine;

namespace DV.Interaction.Inputs
{
	[ExecuteBefore(typeof(DefaultOrder))]
	public class RewiredLocalizationProviderDV : MonoBehaviour, ILocalizedStringProvider
	{
		private static Dictionary<string, string> ControlLocalizationKeys = new Dictionary<string, string>
		{
			{ "controller/mouse/left_button", "keycode/mouse0" },
			{ "controller/mouse/right_button", "keycode/mouse1" },
			{ "controller/mouse/middle_button", "keycode/mouse2" },
			{ "controller/keyboard/left_control", "keycode/leftcontrol" },
			{ "controller/keyboard/left_alt", "keycode/leftalt" },
			{ "controller/keyboard/left_shift", "keycode/leftshift" },
			{ "controller/keyboard/keypad_plus", "keycode/keypadplus" },
			{ "controller/keyboard/keypad_minus", "keycode/keypadminus" },
			{ "controller/keyboard/keypad_divide", "keycode/keypaddivide" },
			{ "controller/keyboard/keypad_multiply", "keycode/keypadmultiply" },
			{ "controller/keyboard/keypad_enter", "keycode/keypadenter" },
			{ "controller/keyboard/space", "keycode/space" }
		};

		private void Awake()
		{
			ReInput.localization.localizedStringProvider = this;
		}

		public bool TryGetLocalizedString(string key, out string result)
		{
			if (key.StartsWith("controller/"))
			{
				if (ControlLocalizationKeys.TryGetValue(key, out var value))
				{
					result = LocalizationAPI.L(value);
					return true;
				}
				result = "";
				return false;
			}
			result = LocalizationAPI.L(key);
			bool num = result.Equals("[ MISSING TRANSLATION ]");
			if (num)
			{
				Debug.LogError("Did not find localization for " + key + "!");
			}
			return !num;
		}
	}
}
