using System.Collections.Generic;
using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public class AccessibilityMenu<T> : Menu<T>
	{
		public AccessibilityMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			AddLabel(base.Localisation["SETTING_NIGHTFADE"]);
			AddBoolOption(Pref.AccessibilityEnableNightFade);
			AddLabel(base.Localisation["SETTING_COLOUR_BLIND"]);
			AddInfo(base.Localisation["SETTING_COLOUR_BLIND_DESCRIPTION"]);
			AddBoolOption(Pref.AccessibilityColourBlindMode);
			AddLabel(base.Localisation["SETTING_WEATHER"]);
			AddInfo(base.Localisation["SETTING_WEATHER_DESCRIPTION"]);
			AddBoolOption(Pref.AccessibilityWeatherVisible, new List<string>
			{
				base.Localisation["SETTING_WEATHER_OFF"],
				base.Localisation["SETTING_WEATHER_ON"]
			});
			New<SpacerElement>();
			New<SpacerElement>();
			AddButton(base.Localisation["MENU_BACK_SETTINGS"], delegate
			{
				RequestPreviousMenu();
			});
		}
	}
}
