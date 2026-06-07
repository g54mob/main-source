using System.Collections.Generic;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.UI;
using FishNet;
using FishNet.Managing.Server;
using Jundroo.Juicy.Widgets;
using Jundroo.SocialPlatforms;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class PlayerListScript : FlightPanelScript
	{
		private List<PlayerListRowScript> _rows = new List<PlayerListRowScript>();

		private PlayerListRowScript _selectedRow;

		public PlayerListRowScript SelectedRow
		{
			get
			{
				return _selectedRow;
			}
			set
			{
				if (_selectedRow != value)
				{
					if (_selectedRow != null)
					{
						_selectedRow.SetSelected(selected: false);
					}
					_selectedRow = value;
					if (_selectedRow != null)
					{
						_selectedRow.SetSelected(selected: true);
					}
					UpdateButtonStates();
				}
			}
		}

		public override void InitializeFlightPanel(FlightUIScript flightUI)
		{
			base.InitializeFlightPanel(flightUI);
			base.Flyout.Opened += delegate
			{
				Refresh(rebuild: true);
			};
			FlightSceneScript.Instance.PlayerLoaded += OnPlayerLoaded;
			FlightSceneScript.Instance.PlayerUnloaded += OnPlayerUnloaded;
			UpdateButtonStates();
			if (!Game.Instance.NetworkGameManager.NetworkManager.IsServerStarted)
			{
				base.Widget.ExecuteOnWidgetsOfClass("server-only", delegate(Widget w)
				{
					w.Visible = false;
				});
			}
		}

		public void Refresh(bool rebuild = false)
		{
			if (base.Flyout.IsOpen && rebuild)
			{
				RebuildList();
			}
		}

		protected virtual void OnDestroy()
		{
			FlightSceneScript.Instance.PlayerLoaded -= OnPlayerLoaded;
			FlightSceneScript.Instance.PlayerUnloaded -= OnPlayerUnloaded;
		}

		private void OnCopyPlayerClicked(Widget widget)
		{
			NetworkPlayerScript networkPlayerScript = SelectedRow?.Player?.NetworkPlayer;
			INetworkAircraft networkAircraft = SelectedRow?.Player?.Aircraft?.NetworkAircraft;
			if (networkPlayerScript != null && networkAircraft?.CraftXml != null)
			{
				if (networkPlayerScript.AllowCopyCraftXml)
				{
					Game.Instance.CraftDatabase.SaveCraft("__editor__.xml", networkAircraft.CraftXml, backupPreviousFile: false, updateXmlVersion: false);
					FlightSceneScript.Instance.LocalPlayer.NetworkPlayer.CraftId = "__editor__.xml";
					FlightSceneScript.Instance.FlightUI.RestartHere();
				}
				else
				{
					Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, "This player is not allowing other players to copy their craft right now.");
				}
			}
		}

		private void OnInviteFriendsClicked(Widget widget)
		{
			if (!SocialExt.IsSteam)
			{
				Game.Instance.UserInterface.CreateMessageDialog("The game must be running through Steam to invite Steam friends to this game.", "Steam Required");
				Debug.LogError("The game must be running through Steam to invite Steam friends to this game.");
			}
			else if ((Game.Instance.NetworkGameManager?.SteamLobbyManager?.LobbyId).GetValueOrDefault() == 0L)
			{
				Game.Instance.UserInterface.CreateMessageDialog("Unable to invite Steam friends to the game. Steam multiplayer lobby not found.", "Lobby Not Found");
				Debug.LogError("Unable to invite Steam friends to the game. Steam multiplayer lobby not found.");
			}
			else
			{
				Game.Instance.NetworkGameManager?.SteamLobbyManager?.OpenInviteFriendsDialog();
			}
		}

		private void OnJoinPlayerClicked(Widget widget)
		{
			NetworkedActivityScript networkedActivityScript = SelectedRow?.Player.NetworkedActivity;
			NetworkedActivityScript networkedActivity = FlightSceneScript.Instance.LocalPlayer.NetworkedActivity;
			if (networkedActivity == null)
			{
				if (networkedActivityScript != null)
				{
					base.FlightUI.ActivityManagerUI.LateJoinActivity(networkedActivityScript);
				}
				else
				{
					base.FlightUI.ShowMessage("The selected player is not currently participating in any activity");
				}
			}
			else if (networkedActivityScript == networkedActivity)
			{
				base.FlightUI.ShowMessage("You are already participating in this activity");
			}
			else
			{
				base.FlightUI.ShowMessage("Please leave your current activity before joining a new one");
			}
		}

		private void OnKickPlayerClicked(Widget widget)
		{
			NetworkPlayerScript networkPlayer = SelectedRow?.Player?.NetworkPlayer;
			if (networkPlayer != null)
			{
				string name = networkPlayer.Name;
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.ThreeButtons);
				messageDialogScript.MessageText = "Are you sure you want to kick '" + name + "' from the game?  This will also kick any NPCs or aircraft spawned by their local client.";
				messageDialogScript.UseDangerButtonStyle = true;
				messageDialogScript.OkayButtonText = "Ban";
				messageDialogScript.MiddleButtonText = "Kick";
				messageDialogScript.CancelButtonText = "No";
				messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					Game.Instance.NetworkGameManager.SteamLobbyManager?.OnPlayerBanned(networkPlayer.SteamId, networkPlayer.Name);
					InstanceFinder.ServerManager.Kick(networkPlayer.OwnerId, KickReason.Unset);
					base.FlightUI.ShowMessage("'" + name + "' was banned from the server.");
				};
				messageDialogScript.MiddleClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					Game.Instance.NetworkGameManager.SteamLobbyManager?.OnPlayerKicked(networkPlayer.SteamId);
					InstanceFinder.ServerManager.Kick(networkPlayer.OwnerId, KickReason.Unset);
					base.FlightUI.ShowMessage("'" + name + "' was kicked from the server.");
				};
			}
		}

		private void OnPlayerLoaded(object sender, FlightScenePlayerEventArgs e)
		{
			Refresh(rebuild: true);
		}

		private void OnPlayerUnloaded(object sender, FlightScenePlayerEventArgs e)
		{
			Refresh(rebuild: true);
		}

		private void OnTargetPlayerClicked(Widget widget)
		{
			TargetingSystem targetingSystem = FlightSceneScript.Instance.LocalPlayer?.Aircraft?.TargetingSystem;
			Target target = SelectedRow?.Player?.Aircraft?.Target;
			if (targetingSystem != null && target != null)
			{
				targetingSystem.CurrentTarget = target;
			}
		}

		private void OnTeleportToPlayerClicked(Widget widget)
		{
			if (SelectedRow?.Player != null)
			{
				if (!SelectedRow.Player.NetworkPlayer.InDesigner)
				{
					SnapToPlayerPosition(SelectedRow.Player);
				}
				else
				{
					base.FlightUI.ShowMessage("You cannot teleport to a player in the designer.");
				}
			}
		}

		private void RebuildList()
		{
			FlightScenePlayer flightScenePlayer = SelectedRow?.Player;
			SelectedRow = null;
			foreach (PlayerListRowScript row in _rows)
			{
				row.Widget.Destroy();
			}
			_rows.Clear();
			Widget parent = base.Widget.FindWidget("item-parent");
			foreach (FlightScenePlayer allPlayer in FlightSceneScript.Instance.AllPlayers)
			{
				PlayerListRowScript componentInChildren = base.Widget.Context.CreateWidgetFromTemplate("list-row", parent).GetComponentInChildren<PlayerListRowScript>();
				componentInChildren.InitializeRow(this, allPlayer);
				_rows.Add(componentInChildren);
				if (flightScenePlayer == allPlayer)
				{
					SelectedRow = componentInChildren;
				}
			}
			base.Widget.FindWidget("invite-friends-button")?.SetIndex(-1);
		}

		private void SnapToPlayerPosition(FlightScenePlayer otherPlayer)
		{
			if (otherPlayer != null)
			{
				PositionUtility.TeleportPlayer(otherPlayer.GlobalPosition + Quaternion.Euler(otherPlayer.Rotation) * Vector3.right * 15f, otherPlayer.Rotation, otherPlayer.Velocity);
			}
		}

		private void UpdateButtonStates()
		{
			bool active = _selectedRow != null && _selectedRow.Player != FlightSceneScript.Instance.LocalPlayer;
			base.Widget.ExecuteOnWidgetsOfClass("row-action", delegate(Widget w)
			{
				w.EnableClass("disabled", !active);
			});
		}
	}
}
