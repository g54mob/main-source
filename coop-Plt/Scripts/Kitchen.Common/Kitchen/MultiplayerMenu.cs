using System.Collections.Generic;
using System.Linq;
using Controllers;
using Kitchen.Modules;
using Kitchen.NetworkSupport;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class MultiplayerMenu : BaseGameplayLaunchMenu
	{
		public MultiplayerMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void TearDown()
		{
			ModuleList.Clear();
		}

		public override void Setup(int player_id)
		{
			Redraw();
		}

		protected override void Redraw(bool jump_to_joincode = false, bool jump_to_invite = false)
		{
			Redraw(-1, select_crossplay: false, jump_to_joincode, jump_to_invite);
		}

		private void Redraw(int hide_player_id = -1, bool select_crossplay = false, bool jump_to_joincode = false, bool jump_to_invite = false)
		{
			ModuleList.Clear();
			Session.SwitchToOnlineSession();
			bool flag = Session.NetworkedPlayState.IsOwnGame();
			bool flag2 = false;
			foreach (INetworkService item in NetworkServices.Available)
			{
				flag2 |= item.ShouldConnect;
			}
			if (flag2)
			{
				DrawPlayerList();
				if (flag && PlatformSettings.AllowNonInviteOnlyGames)
				{
					DrawNetworkPermissions();
				}
				DrawInviteUI(jump_to_invite);
				if (flag && base.ShowJoinViaCode)
				{
					AddCopyJoinCodeButton(jump_to_joincode);
				}
				New<SpacerElement>();
				if (base.ShowJoinViaCode)
				{
					DrawJoinCodeUI();
				}
				New<SpacerElement>();
				DrawCrossplayEnable(select_crossplay);
				AddButton(base.Localisation["MENU_DISCONNECT"], delegate
				{
					RequestAction(PauseMenuAction.SwitchToNotNetworked);
				});
			}
			else
			{
				DrawPlayerList();
				DrawJoinCodeUI();
			}
			New<SpacerElement>();
			AddButton(base.Localisation["MENU_BACK_SETTINGS"], delegate
			{
				RequestAction(PauseMenuAction.Back);
			});
		}

		private void DrawCrossplayEnable(bool select_crossplay)
		{
			if (PlatformSettings.NeedsCrossplayOptIn)
			{
				string i = (NetworkServices.HasCrossplayEnabled ? "MENU_DISABLE_PC_CROSSPLAY" : "MENU_ENABLE_PC_CROSSPLAY");
				ButtonElement module = AddButton(base.Localisation[i], delegate
				{
					NetworkServices.HasCrossplayEnabled = !NetworkServices.HasCrossplayEnabled;
					Redraw(-1, select_crossplay: true);
				});
				if (select_crossplay)
				{
					ModuleList.Select(module);
				}
			}
		}

		private void DrawPlayerList(int hide_player_id = -1)
		{
			AddLabel(base.Localisation["MENU_LABEL_PLAYERS"]);
			List<PlayerInfo> source = Players.Main.All();
			foreach (KeyValuePair<SourceIdentifier, InfoManagerPeerDetail> peerDatum in Players.Main.PeerData)
			{
				if (!peerDatum.Value.HasPlayers)
				{
					DrawPeerRow(peerDatum.Value.MainName, peerDatum.Key);
				}
			}
			foreach (PlayerInfo item in source.OrderBy((PlayerInfo p) => p.Index))
			{
				DrawPlayerRow(item);
			}
		}

		protected PlayerRowElement DrawPeerRow(string user_name, SourceIdentifier source_identifier = default(SourceIdentifier))
		{
			return AddPeerRow(user_name, delegate
			{
				if (source_identifier != default(SourceIdentifier) && source_identifier != InputSourceIdentifier.Identifier)
				{
					Session.KickRequests.Add(source_identifier);
				}
				Redraw();
			});
		}

		protected PlayerRowElement DrawPlayerRow(PlayerInfo player)
		{
			string username = (PlatformSettings.OnlyUseSingleNames ? player.Profile.Name : player.Username);
			return AddPlayerRow(username, player, delegate
			{
				if (!player.IsLocalUser)
				{
					Session.KickRequests.Add(player.Identifier);
					InputSourceIdentifier.DefaultInputSource.MakeRequest(player.ID, GameStateRequest.Disconnect);
					Redraw(player.ID);
				}
			}, delegate
			{
				RemoveInput(player.ID);
			});
		}

		protected void RemoveInput(int id)
		{
			InputSourceIdentifier.DefaultInputSource.MakeRequest(id, GameStateRequest.Disconnect);
			ModuleList.Clear();
			Redraw(id);
		}
	}
}
