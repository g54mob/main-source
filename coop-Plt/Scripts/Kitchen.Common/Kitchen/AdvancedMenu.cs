using System.Diagnostics;
using Kitchen.Modules;
using KitchenData;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class AdvancedMenu<T> : Menu<T>
	{
		public AdvancedMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			AddLabel(base.Localisation["SETTING_LIVESPLIT"]);
			AddInfo(base.Localisation["SETTING_LIVESPLIT_DESCRIPTION"]);
			AddBoolOption(Pref.LiveSplitEnabled);
			if (PlatformSettings.SupportsChef && !PlatformSettings.IsDemoMode)
			{
				if (KitchenData.Localisation.CurrentLocale == Locale.English)
				{
					AddLabel(base.Localisation["SETTING_CHEF"]);
					AddInfo(base.Localisation["SETTING_CHEF_DESCRIPTION"]);
				}
				AddButton(base.Localisation["SETTING_LAUNCH_TWITCH"], delegate
				{
					if (System.Diagnostics.Process.GetProcessesByName("Chef.exe").Length == 0)
					{
						System.Diagnostics.Process.Start(Application.dataPath + "/Chef.exe");
					}
				});
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
