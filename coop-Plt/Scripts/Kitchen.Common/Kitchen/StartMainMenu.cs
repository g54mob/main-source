using Kitchen.Modules;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class StartMainMenu : MainMenuSubmenu
	{
		private const bool UseMainMenuEditorSkip = false;

		public override bool RequiresBackingPanel => false;

		public StartMainMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			ProfileStore.Main.Load();
			AddSubmenuButton(base.Localisation["MAIN_MENU_OFFLINE_PLAY"], typeof(SingleplayerMainMenu));
			AddSubmenuButton(base.Localisation["MAIN_MENU_ONLINE_PLAY"], typeof(MultiplayerLoadingMenu)).SetSelectable(!PlatformSettings.IsDemoMode);
			AddSubmenuButton(base.Localisation["MAIN_MENU_OPTIONS"], typeof(OptionsMenu<MenuAction>));
			if (PlatformSettings.SupportsExternalLinks)
			{
				New<SpacerElement>();
				AddActionButton(base.Localisation["MAIN_MENU_WIKI"], MainMenuAction.Wiki);
				AddActionButton(base.Localisation["MAIN_MENU_DISCORD"], MainMenuAction.Discord);
			}
			if (PlatformSettings.AllowQuit)
			{
				New<SpacerElement>();
				New<SpacerElement>();
				AddActionButton(base.Localisation["MAIN_MENU_QUIT"], MainMenuAction.Quit, ElementStyle.MainMenuBack);
			}
		}
	}
}
