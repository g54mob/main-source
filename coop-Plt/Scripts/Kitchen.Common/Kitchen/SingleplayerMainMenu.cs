using Kitchen.Modules;
using Kitchen.NetworkSupport;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class SingleplayerMainMenu : BaseGameplayLaunchMenu
	{
		public SingleplayerMainMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			base.Setup(player_id);
			SetupProfileOption();
			NetworkHelpers.CurrentNetworkPermissions = NetworkPermissions.Private;
			if (PlatformSettings.UseAdvancedProfilesMode)
			{
				AddProfileSelector();
				DrawStartButton(MainMenuAction.StartSingleplayer);
				New<SpacerElement>();
				New<SpacerElement>();
				AddActionButton(base.Localisation["MAIN_MENU_BACK"], MainMenuAction.Back, ElementStyle.MainMenuBack);
			}
			else
			{
				AutoStart(player_id, use_networking: false);
			}
		}
	}
}
