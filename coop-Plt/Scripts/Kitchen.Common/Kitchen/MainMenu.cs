using Kitchen.Modules;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class MainMenu : Menu<MenuAction>
	{
		public MainMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			if (GameInfo.CurrentlyAvailableDishes.Count > 0)
			{
				AddSubmenuButton(base.Localisation["MENU_RECIPES"], typeof(RecipeMenu));
			}
			if (GameInfo.AllCurrentCards.Count > 0)
			{
				AddSubmenuButton(base.Localisation["MENU_ACTIVE_CARDS"], typeof(CardListMenu));
			}
			if (GameInfo.CurrentScene == SceneType.Kitchen && GameInfo.IsPreparationTime)
			{
				AddButton(base.Localisation["MENU_PRACTICE_MODE"], delegate
				{
					RequestAction(PauseMenuAction.PracticeMode);
				});
			}
			AddSubmenuButton(base.Localisation["MENU_OPTIONS"], typeof(OptionsMenu<MenuAction>));
			AddButton(base.Localisation["MENU_REMOVE_INPUT"], delegate
			{
				RequestAction(PauseMenuAction.DisconnectPlayer);
			});
			ButtonElement buttonElement = AddSubmenuButton(base.Localisation["MAIN_MENU_ONLINE_PLAY"], typeof(MultiplayerLoadingMenu));
			if (PlatformSettings.IsDemoMode)
			{
				buttonElement.SetSelectable(selectable: false);
			}
			switch (GameInfo.CurrentScene)
			{
			case SceneType.Kitchen:
				AddActionButton(base.Localisation["MENU_ABANDON"], PauseMenuAction.AbandonRestaurant);
				AddActionButton(base.Localisation["MENU_QUIT_TO_LOBBY"], PauseMenuAction.QuitToLobby);
				break;
			case SceneType.Tutorial:
				AddActionButton(base.Localisation["MENU_LEAVE_TUTORIAL"], PauseMenuAction.AbandonRestaurant);
				break;
			case SceneType.Franchise:
				if (PlatformSettings.AllowQuit)
				{
					AddSubmenuButton(base.Localisation["MENU_QUIT"], typeof(QuitConfirmMenu));
				}
				break;
			}
			New<SpacerElement>();
			AddButton(base.Localisation["MENU_CONTINUE"], delegate
			{
				RequestAction(PauseMenuAction.CloseMenu);
			}, 0, 0.75f);
			ModuleList.RefreshFocus();
		}
	}
}
