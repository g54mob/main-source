using System;
using System.Collections.Generic;
using Controllers;
using Kitchen.Modules;
using Kitchen.NetworkSupport;
using KitchenData;
using Platforms;
using Sirenix.Utilities;
using UnityEngine;

namespace Kitchen
{
	public class MultiplayerLoadingMenu : Menu<MenuAction>
	{
		public Type DestinationMenu;

		protected bool IsDrawn;

		protected LabelElement LoadingScreenLabel;

		protected SpinnerElement LoadingScreenSpinner;

		private bool HasFailed;

		protected DateTime StartTime;

		public PlatformUser ActiveUser;

		public HashSet<PlatformUser> Users = new HashSet<PlatformUser>();

		protected HasAvailableNetworkState CanStartHasAvailableNetwork => NetworkServices.HasAvailableNetwork;

		public MultiplayerLoadingMenu(Transform container, ModuleList module_list, Type destination_menu)
			: base(container, module_list)
		{
			DestinationMenu = destination_menu;
		}

		public override void Setup(int player_id)
		{
			StartTime = DateTime.Now;
			foreach (INetworkService item in NetworkServices.Available)
			{
				item.ShouldConnect = true;
			}
			ActiveUser = InputSourceIdentifier.Default.GetPlatformUser(player_id);
			if (!Session.NetworkedPlayState.IsNetworked())
			{
				UpdateUserList();
				Platform.Current.CanUseMultiplayer(Users, force_rerun: true);
			}
			HasFailed = false;
		}

		public override void Update()
		{
			base.Update();
			if (IsDrawn)
			{
				UpdateLoadingScreen();
			}
			else if (DateTime.Now - StartTime > TimeSpan.FromMilliseconds(100.0))
			{
				IsDrawn = true;
				DrawLoadingScreen();
			}
			else
			{
				UpdateLoadingScreen(only_react_on_success: true);
			}
		}

		protected void UpdateUserList()
		{
			Users.Clear();
			Users.AddRange(Players.Main.LocalUsers);
			Users.Add(ActiveUser);
		}

		protected void DrawLoadingScreen()
		{
			ModuleList.Clear();
			LoadingScreenLabel = AddInfoText(GameData.Main.GlobalLocalisation["MENU_CONNECTING"]);
			LoadingScreenSpinner = AddSpinner();
		}

		protected void UpdateLoadingScreen(bool only_react_on_success = false)
		{
			UpdateUserList();
			Platform.MultiplayerAccessResult multiplayerAccessResult = Platform.Current.CanUseMultiplayer(Users);
			if (Session.NetworkedPlayState.IsNetworked())
			{
				multiplayerAccessResult = Platform.MultiplayerAccessResult.Success;
			}
			switch (multiplayerAccessResult)
			{
			case Platform.MultiplayerAccessResult.Checking:
				return;
			case Platform.MultiplayerAccessResult.Success:
				if (CanStartHasAvailableNetwork == HasAvailableNetworkState.NoNetworkServicesAvailable)
				{
					if (!only_react_on_success)
					{
						HasFailed = true;
						RequestErrorDisplay(GameData.Main.GlobalLocalisation["MULTIPLAYER_GENERIC_ERROR"]);
					}
				}
				else if (CanStartHasAvailableNetwork == HasAvailableNetworkState.Success)
				{
					RequestSubMenu(DestinationMenu, skip_stack: false, remove_self_from_stack: true);
				}
				return;
			}
			if (!only_react_on_success)
			{
				HasFailed = true;
				if (multiplayerAccessResult == Platform.MultiplayerAccessResult.PromptedError)
				{
					RequestPreviousMenu();
				}
				else
				{
					RequestErrorDisplay(GameData.Main.GlobalLocalisation["MULTIPLAYER_GENERIC_ERROR"]);
				}
			}
		}
	}
}
