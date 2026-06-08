using System.Collections.Generic;
using Kitchen.Modules;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class GameOptionsMenu<T> : Menu<T>
	{
		public GameOptionsMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			AddLabel(base.Localisation["SETTING_LETTERS_INSIDE"]);
			AddBoolOption(Pref.LettersSpawnInside);
			AddLabel(base.Localisation["SETTING_DESK_AS_PARCEL"]);
			AddBoolOption(Pref.ProvideStartingEnvelopesAsParcels);
			AddLabel(base.Localisation["SETTING_BP_PING"]);
			AddBoolOption(Pref.RequirePingForBlueprintInfo);
			AddLabel(base.Localisation["SETTING_SKIP_RECIPE_POPUPS"]);
			AddBoolOption(Pref.SkipNewRecipePopups);
			Option<bool> option = new Option<bool>(new List<bool> { false, true }, Preferences.Get<bool>(Pref.SeedsAffectEverything), new List<string>
			{
				base.Localisation["SEEDS_ONLY_LAYOUT"],
				base.Localisation["SEEDS_EVERYTHING"]
			});
			option.OnChanged += delegate(object _, bool f)
			{
				Preferences.Set(Pref.SeedsAffectEverything, f);
			};
			AddLabel(base.Localisation["FLOOR_LABEL_SEEDED_RUN"]);
			AddSelect(option);
			AddLabel(base.Localisation["SETTING_ALWAYS_SHOW_RUN_TIMER"]);
			AddBoolOption(Pref.AlwaysShowRunTimer);
			if (PlatformSettings.IsSwitch)
			{
				AddLabel(base.Localisation["SETTING_SWITCH_LEGACY_CONTROLS"]);
				AddBoolOption(Pref.SwitchLegacyControls);
			}
			New<SpacerElement>();
			New<SpacerElement>();
			AddButton(base.Localisation["MENU_BACK_SETTINGS"], delegate
			{
				RequestPreviousMenu();
			});
		}
	}
}
