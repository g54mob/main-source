using System.Collections.Generic;
using Controllers;
using Kitchen.Modules;
using Kitchen.NetworkSupport;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class PlayerPauseView : LocalMenuView<MenuAction>
	{
		private ControlRebindElement Rebind;

		protected bool HasReleasedTrigger;

		private List<int> TmpDisconnectedPlayers = new List<int>();

		protected override bool LowPriorityInputConsumer => true;

		protected override void SetupMenus()
		{
			if (Rebind == null)
			{
				Rebind = ModuleDirectory.Add<ControlRebindElement>(Container.transform);
				Rebind.Position = new Vector2(-5f, 0f);
			}
			AddMenu(typeof(MainMenu), new MainMenu(ButtonContainer, ModuleList));
			AddMenu(typeof(MultiplayerMenu), new MultiplayerMenu(ButtonContainer, ModuleList));
			AddMenu(typeof(CardListMenu), new CardListMenu(ButtonContainer, ModuleList));
			AddMenu(typeof(RecipeMenu), new RecipeMenu(ButtonContainer, ModuleList));
			AddMenu(typeof(OptionsMenu<MenuAction>), new OptionsMenu<MenuAction>(ButtonContainer, ModuleList));
			AddMenu(typeof(QuitConfirmMenu), new QuitConfirmMenu(ButtonContainer, ModuleList));
			AddMenu(typeof(MultiplayerLoadingMenu), new MultiplayerLoadingMenu(ButtonContainer, ModuleList, typeof(MultiplayerMenu)));
			AddMenu(typeof(DebuggingMainMenu), new DebuggingMainMenu(ButtonContainer, ModuleList));
			AddMenu(typeof(ErrorMenu<MenuAction>), new ErrorMenu<MenuAction>(ButtonContainer, ModuleList));
			SetMenu(typeof(MainMenu));
		}

		public override void Hide()
		{
			IsDismissed = true;
			Container.SetActive(value: false);
			if (InputSourceIdentifier.DefaultInputSource != null)
			{
				InputSourceIdentifier.DefaultInputSource.ReleaseLock(GlobalLock);
			}
			ActivePlayer = 0;
		}

		public override InputConsumerState TakeInput(int player_id, InputState state)
		{
			if (base.HasPlayer)
			{
				InputSourceIdentifier.DefaultInputSource.DisconnectedPlayers(TmpDisconnectedPlayers);
				if (TmpDisconnectedPlayers.Contains(ActivePlayer))
				{
					Hide();
					return InputConsumerState.Terminated;
				}
				if (player_id != ActivePlayer)
				{
					return InputConsumerState.NotConsumed;
				}
				HandleInputState(state);
				if (!IsDismissed)
				{
					return InputConsumerState.Consumed;
				}
				return InputConsumerState.Terminated;
			}
			if (state.MenuTrigger == ButtonState.Pressed)
			{
				CreateForPlayer(player_id);
				SetPlayer(player_id);
				return InputConsumerState.Consumed;
			}
			return InputConsumerState.NotConsumed;
		}

		protected override void SetPlayer(int player)
		{
			base.SetPlayer(player);
			Rebind.Setup(player, display_only: true, show_panel: true);
		}

		protected void HandleInputState(InputState state)
		{
			if (ModuleList.HandleInteraction(state))
			{
				return;
			}
			if (HasReleasedTrigger)
			{
				if (state.MenuCancel == ButtonState.Pressed)
				{
					PerformAction(PauseMenuAction.Back);
				}
				else if (state.IsCancellingMenu)
				{
					PerformAction(PauseMenuAction.CloseMenu);
				}
			}
			else
			{
				HasReleasedTrigger = true;
			}
		}

		protected override void PerformAction(MenuAction action = default(MenuAction))
		{
			switch (action.PauseAction)
			{
			case PauseMenuAction.CloseMenu:
				Hide();
				break;
			case PauseMenuAction.Back:
				GoBack();
				break;
			case PauseMenuAction.DisconnectPlayer:
				InputSourceIdentifier.DefaultInputSource.MakeRequest(ActivePlayer, GameStateRequest.Disconnect);
				Hide();
				break;
			case PauseMenuAction.QuitToLobby:
				InputSourceIdentifier.DefaultInputSource.MakeRequest(ActivePlayer, GameStateRequest.QuitToLobby);
				Hide();
				break;
			case PauseMenuAction.Quit:
				Session.SoftExit();
				break;
			case PauseMenuAction.SwitchToNotNetworked:
				Session.SwitchToLocalOnlySession();
				Hide();
				break;
			case PauseMenuAction.AbandonRestaurant:
				InputSourceIdentifier.DefaultInputSource.MakeRequest(ActivePlayer, GameStateRequest.QuitSection);
				Hide();
				break;
			case PauseMenuAction.OpenInvitePanel:
			{
				if (NetworkHelpers.CurrentNetworkPermissions == NetworkPermissions.Private)
				{
					NetworkHelpers.CurrentNetworkPermissions = NetworkPermissions.InviteOnly;
				}
				NetworkInviteData invite = Session.GetInvite();
				if (invite.AvailableSlots > 0)
				{
					Platform.Current.OpenInviteUI(invite);
				}
				break;
			}
			case PauseMenuAction.OpenInvitePanelDiscord:
				if (!Platform.Current.DiscordEnabled)
				{
					Application.OpenURL(PlatformSettings.DiscordDownloadPage);
					break;
				}
				if (NetworkHelpers.CurrentNetworkPermissions == NetworkPermissions.Private)
				{
					NetworkHelpers.CurrentNetworkPermissions = NetworkPermissions.InviteOnly;
				}
				Platform.Current.OpenDiscordInvite();
				break;
			case PauseMenuAction.PracticeMode:
				InputSourceIdentifier.DefaultInputSource.MakeRequest(ActivePlayer, GameStateRequest.StartPractice);
				Hide();
				break;
			case PauseMenuAction.Redraw:
				Redraw();
				break;
			case PauseMenuAction.StartMultiplayerSession:
				break;
			}
		}
	}
}
