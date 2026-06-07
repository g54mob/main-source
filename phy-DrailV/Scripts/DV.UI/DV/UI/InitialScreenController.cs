using DV.UI.PresetEditors;
using DV.UIFramework;

namespace DV.UI
{
	public class InitialScreenController : AUIController
	{
		[NullCheck]
		public UIMenuController menuController;

		public int startMenuIndex;

		public int launcherMenuIndex;

		public int userProfileMenuIndex;

		[NullCheck]
		public ContinueLoadNewController continueLoadNewController;

		private AMainMenuProvider mainMenuProvider;

		private AUserProfileProvider userProfileProvider;

		private AScenarioProvider scenariosProvider;

		public void SetProvider(AMainMenuProvider mainMenuProvider, AUserProfileProvider userProfileProvider, AScenarioProvider scenariosProvider, bool isVR)
		{
			if (this.mainMenuProvider != null || this.userProfileProvider != null || this.scenariosProvider != null)
			{
				Util.RunOnce(this, "SetProvider");
				return;
			}
			this.mainMenuProvider = mainMenuProvider;
			this.userProfileProvider = userProfileProvider;
			this.scenariosProvider = scenariosProvider;
			continueLoadNewController.SetProvider(userProfileProvider, scenariosProvider, isVR);
		}

		public void SwitchStartScreen()
		{
			if (mainMenuProvider.DefaultMenuIndexOverride.HasValue)
			{
				menuController.SwitchMenu(mainMenuProvider.DefaultMenuIndexOverride.Value);
			}
			else if (!userProfileProvider.HasLastUsedUserProfile)
			{
				menuController.SwitchMenu(userProfileMenuIndex);
			}
			else if (userProfileProvider.HasLastPlayedSessionForAnyGameMode)
			{
				menuController.SwitchMenu(launcherMenuIndex);
			}
			else
			{
				menuController.SwitchMenu(startMenuIndex);
			}
			continueLoadNewController.RefreshInterface();
		}
	}
}
