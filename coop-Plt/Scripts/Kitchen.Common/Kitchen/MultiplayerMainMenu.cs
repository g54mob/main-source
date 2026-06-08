using Kitchen.Modules;
using Kitchen.NetworkSupport;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class MultiplayerMainMenu : BaseGameplayLaunchMenu
	{
		protected override bool ShowCopyJoinCode => false;

		public MultiplayerMainMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			base.Setup(player_id);
			SetupProfileOption();
			if (!PlatformSettings.UseAdvancedProfilesMode && !PlatformSettings.AllowNonInviteOnlyGames && !base.ShowJoinViaCode)
			{
				NetworkHelpers.CurrentNetworkPermissions = NetworkPermissions.Open;
				AutoStart(player_id, use_networking: true);
				return;
			}
			NetworkHelpers.CurrentNetworkPermissions = NetworkPermissions.Private;
			if (PlatformSettings.UseAdvancedProfilesMode)
			{
				AddProfileSelector();
			}
			if (PlatformSettings.AllowNonInviteOnlyGames)
			{
				DrawNetworkPermissions();
			}
			if (PlatformSettings.AllowJoinCodes)
			{
				DrawJoinCodeUI();
			}
			DrawHostUI();
			AddActionButton(base.Localisation["MAIN_MENU_BACK"], MainMenuAction.Back, ElementStyle.MainMenuBack);
		}

		private void DrawProfileUI()
		{
			AddProfileSelector();
		}

		private void DrawHostUI()
		{
			DrawStartButton(MainMenuAction.StartMultiplayer);
		}
	}
}
