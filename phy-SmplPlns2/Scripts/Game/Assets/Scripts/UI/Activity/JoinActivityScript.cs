using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.UI.Panels;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using Cysharp.Threading.Tasks;
using Jundroo.Common.DataTypes;
using Jundroo.Common.Utils;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Activity
{
	public class JoinActivityScript : WidgetScript
	{
		private class PlayerRow
		{
			public TextWidget CraftName { get; }

			public int PlayerId { get; }

			public TextWidget PlayerName { get; }

			public ImageWidget PlayerStatus { get; }

			public Widget RootWidget { get; }

			public PlayerRow(int playerId, Widget rootWidget, TextWidget playerName, TextWidget craftName, ImageWidget playerStatus)
			{
				PlayerId = playerId;
				RootWidget = rootWidget;
				PlayerName = playerName;
				CraftName = craftName;
				PlayerStatus = playerStatus;
			}
		}

		private class TeamListPanel
		{
			public enum JoinStateType
			{
				NotJoined = 0,
				Joined = 1,
				Ready = 2
			}

			private Widget _teamButtons;

			public TextWidget HeaderText { get; }

			public List<PlayerRow> PlayerRows { get; }

			public Widget PlayerRowsRootWidget { get; }

			public Widget RootWidget { get; }

			public NetworkedActivityTeam Team { get; }

			public TeamListPanel(NetworkedActivityTeam team, Widget rootWidget)
			{
				Team = team;
				RootWidget = rootWidget;
				PlayerRows = new List<PlayerRow>();
				HeaderText = rootWidget?.FindWidget<TextWidget>("team-list-header-text");
				if (HeaderText == null)
				{
					Debug.LogError("Unable to find the team list header text widget for team '" + team.Name + "'");
				}
				PlayerRowsRootWidget = rootWidget?.FindWidget("player-rows");
				if (PlayerRowsRootWidget == null)
				{
					Debug.LogError("Unable to find the player rows root widget for team '" + team.Name + "'");
				}
				_teamButtons = rootWidget?.FindWidget("team-buttons");
			}

			public PlayerRow CreatePlayerRow(int playerId)
			{
				Widget widget = RootWidget.Context.CreateWidgetFromTemplate("player-row", PlayerRowsRootWidget);
				TextWidget playerName = widget.FindWidget<TextWidget>("player-name");
				TextWidget craftName = widget.FindWidget<TextWidget>("craft-name");
				ImageWidget playerStatus = widget.FindWidget<ImageWidget>("player-status");
				PlayerRow playerRow = new PlayerRow(playerId, widget, playerName, craftName, playerStatus);
				PlayerRows.Add(playerRow);
				return playerRow;
			}

			public PlayerRow GetPlayerRow(int playerId)
			{
				for (int i = 0; i < PlayerRows.Count; i++)
				{
					if (PlayerRows[i].PlayerId == playerId)
					{
						return PlayerRows[i];
					}
				}
				return null;
			}

			public void SetBusyState(bool busy)
			{
				_teamButtons.EnableClass("busy", busy);
			}

			public void SetState(JoinStateType joinState)
			{
				_teamButtons.EnableClass("player-not-joined", joinState == JoinStateType.NotJoined);
				_teamButtons.EnableClass("player-joined", joinState == JoinStateType.Joined);
				_teamButtons.EnableClass("player-ready", joinState == JoinStateType.Ready);
			}
		}

		private ActivitySettingsScript _activitySettings;

		private ActivityUIScript _activityUI;

		private bool _enteredInFlightDesignerSubscribed;

		private Widget _joinActivityRootWidget;

		private Widget _startNowButton;

		private EnumDictionary<NetworkedActivityTeamIds, TeamListPanel> _teamListPanels;

		public NetworkedActivityScript Activity => _activityUI.Activity;

		public void Initialize(ActivityUIScript activityUI)
		{
			_activityUI = activityUI;
			_activitySettings = FlightSceneScript.Instance.FlightUI.Flyouts.ActivitySettings.Widget.GetComponentInChildren<ActivitySettingsScript>();
			_activitySettings.SetActivitySettings(Activity.Data.Settings, Activity.IsActivityHost ? ActivitySettingsScript.ActivitySettingsVisibility.HostLobby : ActivitySettingsScript.ActivitySettingsVisibility.ClientLobby);
			_joinActivityRootWidget.FindWidget<TextWidget>("activity-name").Text = Activity.Data.DisplayName;
			UpdateActivitySubtitle();
			_joinActivityRootWidget.FindWidget<ImageWidget>("activity-icon").SetStyle("sprite", "Sprites/Activity/" + activityUI.Activity.Data.Icon);
			_startNowButton = _joinActivityRootWidget.FindWidget("start-now-button");
			_teamListPanels = new EnumDictionary<NetworkedActivityTeamIds, TeamListPanel>();
			InitializeTeamListPanel(NetworkedActivityTeamIds.Team1);
			InitializeTeamListPanel(NetworkedActivityTeamIds.Team2);
			RefreshPanel(NetworkedActivityTeamIds.Team1);
			RefreshPanel(NetworkedActivityTeamIds.Team2);
			Activity.Data.Settings.SettingValueChanged += OnActivitySettingChanged;
			Activity.TeamJoined += OnPlayerJoinedTeam;
			Activity.TeamLeft += OnPlayerLeftTeam;
			Activity.PlayerStateChanged += OnPlayerStateChanged;
			Activity.PlayerEnteredAircraft += OnPlayerEnteredAircraft;
			Activity.PlayerExitedAircraft += OnPlayerExitedAircraft;
		}

		public void OnActivityStarted()
		{
			base.Widget.SetVisible(visible: false);
			CloseSettingsFlyout();
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_joinActivityRootWidget = base.Widget.FindWidget("join-activity");
		}

		protected virtual void OnDestroy()
		{
			CloseSettingsFlyout();
			_activitySettings.ReleaseActivitySettings();
			Activity.Data.Settings.SettingValueChanged -= OnActivitySettingChanged;
			Activity.TeamJoined -= OnPlayerJoinedTeam;
			Activity.TeamLeft -= OnPlayerLeftTeam;
			Activity.PlayerStateChanged -= OnPlayerStateChanged;
			Activity.PlayerEnteredAircraft -= OnPlayerEnteredAircraft;
			Activity.PlayerExitedAircraft -= OnPlayerExitedAircraft;
			if (_enteredInFlightDesignerSubscribed)
			{
				if (Activity.LocalPlayer != null)
				{
					_enteredInFlightDesignerSubscribed = false;
					Activity.LocalPlayer.Player.EnteredInFlightDesigner -= OnPlayerEnteredInFlightDesigner;
				}
				else
				{
					Debug.LogError("Unable to unsubscribe to EnteredInFlightDesigner");
				}
			}
		}

		private void AutoStartIfReady()
		{
			if (Activity.IsActivityHost && (int)Activity.State < 3 && Activity.Players.All((NetworkedActivityPlayer x) => x.State == NetworkedActivityPlayerState.Ready))
			{
				Debug.Log($"All {Activity.Players.Count} players ready. Starting activity '{Activity.Data.DisplayName}'");
				_activityUI.StartActivity();
			}
		}

		private async UniTask ChangeLocalPlayerState(NetworkedActivityPlayerState state)
		{
			NetworkedActivityScript.AsyncResult asyncResult = await Activity.ChangePlayerState(Activity.LocalPlayer, state);
			if (!asyncResult.IsSuccess)
			{
				Debug.LogError("An error occurred attempting to change the local player's state: " + (asyncResult.Message ?? string.Empty));
			}
		}

		private void CloseSettingsFlyout()
		{
			IFlightFlyouts flyouts = FlightSceneScript.Instance.FlightUI.Flyouts;
			if (flyouts.Selected == flyouts.ActivitySettings)
			{
				flyouts.Selected = null;
			}
		}

		private void InitializeTeamListPanel(NetworkedActivityTeamIds teamId)
		{
			Widget widget = _joinActivityRootWidget.FindWidget($"team-list-panel-{teamId}");
			if (widget == null)
			{
				Debug.LogError($"Unable to find the team list panel widget for team '{teamId}'");
			}
			if (!Activity.JoinableTeams.HasFlag(teamId))
			{
				widget?.Hide();
			}
			NetworkedActivityTeam team = Activity.GetTeam(teamId);
			if (team == null)
			{
				Debug.LogError($"Unable to find the team '{teamId}'");
			}
			_teamListPanels[teamId] = new TeamListPanel(team, widget);
		}

		private void OnActivitySettingChanged(object sender, NetworkedActivitySettingValueChangedEventArgs<object> e)
		{
			UpdateActivitySubtitle();
		}

		private void OnAddAIPlayer(Widget widget)
		{
			NetworkedActivityTeamIds teamId = EnumUtility<NetworkedActivityTeamIds>.Parse(widget.Data);
			NetworkedActivityTeam team = Activity.GetTeam(teamId);
			FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
			Debug.Log("Player '" + localPlayer.Name + "' is adding an AI player to team '" + team.Name + "'");
		}

		private void OnChangeAIPlayerCraftClicked(Widget widget)
		{
			IFlightFlyouts flyouts = FlightSceneScript.Instance.FlightUI.Flyouts;
			flyouts.Selected = flyouts.ChangeCraft;
		}

		private void OnCloseButtonClicked(Widget widget)
		{
			Action exitActivity = delegate
			{
				FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
				if (localPlayer.NetworkedActivity != null)
				{
					localPlayer.NetworkedActivity.LeaveActivity(localPlayer);
				}
				FlightSceneScript.Instance.FlightUI.ActivityManagerUI.CloseCurrentActivityUI();
			};
			if (Activity.IsActivityHost)
			{
				Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, "Are you sure you want to cancel this activity?").OkayClicked += delegate(MessageDialogScript d)
				{
					d.Close();
					exitActivity();
				};
			}
			else
			{
				exitActivity();
			}
		}

		private async void OnJoinButtonClicked(Widget widget)
		{
			if (!(Activity == null))
			{
				NetworkedActivityScript activity = Activity;
				if ((object)activity == null || (int)activity.State < 5)
				{
					NetworkedActivityTeamIds teamId = EnumUtility<NetworkedActivityTeamIds>.Parse(widget.Data);
					NetworkedActivityTeam team = Activity.GetTeam(teamId);
					FlightScenePlayer player = FlightSceneScript.Instance.LocalPlayer;
					_ = _teamListPanels[teamId];
					if (team.IsPlayerOnTeam(player))
					{
						if (player.NetworkedActivity != null)
						{
							if (!player.NetworkedActivity.IsActivityHost)
							{
								player.NetworkedActivity.LeaveActivity(player);
							}
							else
							{
								FlightSceneScript.Instance.FlightUI.ShowMessage("You're the host, so you can't un-join. Click the exit activity to cancel this activity.");
							}
						}
						return;
					}
					try
					{
						SetAllTeamPanelsBusyState(busy: true);
						if (Activity.LocalPlayer != null)
						{
							await ChangeLocalPlayerState(NetworkedActivityPlayerState.NotReady);
						}
						NetworkedActivityScript.AsyncResult asyncResult = await Activity.JoinTeam(player, teamId);
						if (asyncResult.IsSuccess)
						{
							Debug.Log("Joined '" + team.Name + "' Team");
						}
						else
						{
							Game.Instance.UserInterface.CreateMessageDialog(asyncResult.Message, "Failed to Join Team");
						}
						return;
					}
					finally
					{
						SetAllTeamPanelsBusyState(busy: false);
					}
				}
			}
			Game.Instance.UserInterface.CreateMessageDialog("Activity has already ended", "Unable to Join Activity");
		}

		private void OnPlayerEnteredAircraft(object sender, NetworkedActivityPlayerAircraftEventArgs e)
		{
			NetworkedActivityTeam team = e.Player.Team;
			if (team != null)
			{
				RefreshPanel(team.Id);
			}
		}

		private async void OnPlayerEnteredInFlightDesigner(object sender, FlightScenePlayerEventArgs e)
		{
			await ChangeLocalPlayerState(NetworkedActivityPlayerState.NotReady);
		}

		private void OnPlayerExitedAircraft(object sender, NetworkedActivityPlayerAircraftEventArgs e)
		{
			NetworkedActivityTeam team = e.Player.Team;
			if (team != null)
			{
				RefreshPanel(team.Id);
			}
		}

		private void OnPlayerJoinedTeam(object sender, NetworkedActivityPlayerTeamEventArgs e)
		{
			RefreshPanel(e.Team.Id);
		}

		private void OnPlayerLeftTeam(object sender, NetworkedActivityPlayerTeamEventArgs e)
		{
			RefreshPanel(e.Team.Id);
			AutoStartIfReady();
			if (_enteredInFlightDesignerSubscribed && e.Player == Activity.LocalPlayer)
			{
				_enteredInFlightDesignerSubscribed = false;
				Activity.LocalPlayer.Player.EnteredInFlightDesigner -= OnPlayerEnteredInFlightDesigner;
			}
		}

		private void OnPlayerStateChanged(object sender, NetworkedActivityPlayerStateChangedEventArgs e)
		{
			NetworkedActivityTeam team = e.Player.Team;
			if (team != null)
			{
				RefreshPanel(team.Id);
				AutoStartIfReady();
			}
		}

		private async void OnReadyButtonClicked(Widget widget)
		{
			NetworkedActivityTeamIds teamId = EnumUtility<NetworkedActivityTeamIds>.Parse(widget.Data);
			NetworkedActivityTeam team = Activity.GetTeam(teamId);
			FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
			_ = _teamListPanels[teamId];
			if (!team.IsPlayerOnTeam(localPlayer))
			{
				return;
			}
			try
			{
				SetAllTeamPanelsBusyState(busy: true);
				NetworkedActivityPlayerState? networkedActivityPlayerState = null;
				if ((int)Activity.LocalPlayer.State < 2)
				{
					networkedActivityPlayerState = NetworkedActivityPlayerState.Ready;
				}
				else if (Activity.LocalPlayer.State == NetworkedActivityPlayerState.Ready)
				{
					networkedActivityPlayerState = NetworkedActivityPlayerState.NotReady;
				}
				if (networkedActivityPlayerState.HasValue)
				{
					await ChangeLocalPlayerState(networkedActivityPlayerState.Value);
				}
				RefreshPanel(teamId);
			}
			finally
			{
				SetAllTeamPanelsBusyState(busy: false);
			}
			if (!_enteredInFlightDesignerSubscribed)
			{
				_enteredInFlightDesignerSubscribed = true;
				Activity.LocalPlayer.Player.EnteredInFlightDesigner += OnPlayerEnteredInFlightDesigner;
			}
		}

		private void OnSettingsButtonClicked(Widget widget)
		{
			IFlightFlyouts flyouts = FlightSceneScript.Instance.FlightUI.Flyouts;
			if (flyouts.Selected != flyouts.ActivitySettings)
			{
				flyouts.Selected = flyouts.ActivitySettings;
			}
			else
			{
				flyouts.Selected = null;
			}
		}

		private void OnStartNowButtonClicked(Widget widget)
		{
			Activity.StartActivity();
		}

		private void RefreshPanel(NetworkedActivityTeamIds teamId)
		{
			TeamListPanel teamListPanel = _teamListPanels[teamId];
			NetworkedActivityTeam team = Activity.GetTeam(teamId);
			teamListPanel.HeaderText.Text = (string.IsNullOrEmpty(team.Name) ? $"{team.Players.Count} players" : $"Team {team.Name} ({team.Players.Count} players)");
			for (int num = teamListPanel.PlayerRows.Count - 1; num >= 0; num--)
			{
				PlayerRow playerRow = teamListPanel.PlayerRows[num];
				if (!team.IsPlayerOnTeam(playerRow.PlayerId))
				{
					playerRow.RootWidget.Destroy();
					teamListPanel.PlayerRows.Remove(playerRow);
				}
			}
			for (int i = 0; i < team.Players.Count; i++)
			{
				NetworkedActivityPlayer networkedActivityPlayer = team.Players[i];
				PlayerRow playerRow2 = teamListPanel.GetPlayerRow(networkedActivityPlayer.PlayerId);
				if (playerRow2 == null)
				{
					playerRow2 = teamListPanel.CreatePlayerRow(networkedActivityPlayer.PlayerId);
				}
				playerRow2.PlayerName.Text = networkedActivityPlayer.Player.Name;
				playerRow2.CraftName.Text = networkedActivityPlayer.Player.Aircraft?.Aircraft.Name ?? string.Empty;
				playerRow2.PlayerStatus.SetVisible((int)networkedActivityPlayer.State >= 2);
			}
			NetworkedActivityPlayer localPlayer = Activity.LocalPlayer;
			bool flag = false;
			if (localPlayer?.Team == team)
			{
				if ((int)localPlayer.State >= 2)
				{
					teamListPanel.SetState(TeamListPanel.JoinStateType.Ready);
					flag = Activity.IsActivityHost && Activity.Players.Count > 1;
				}
				else
				{
					teamListPanel.SetState(TeamListPanel.JoinStateType.Joined);
				}
			}
			else
			{
				teamListPanel.SetState(TeamListPanel.JoinStateType.NotJoined);
			}
			if (flag)
			{
				_startNowButton.Show();
			}
			else
			{
				_startNowButton.Hide();
			}
		}

		private void SetAllTeamPanelsBusyState(bool busy)
		{
			foreach (TeamListPanel value in _teamListPanels.Values)
			{
				value?.SetBusyState(busy);
			}
		}

		private void UpdateActivitySubtitle()
		{
			TextWidget textWidget = _joinActivityRootWidget.FindWidget<TextWidget>("activity-subtitle");
			string subtitle = Activity.Subtitle;
			if (!string.IsNullOrEmpty(subtitle))
			{
				textWidget.Visible = true;
				textWidget.Text = subtitle;
			}
			else
			{
				textWidget.Visible = false;
				textWidget.Text = string.Empty;
			}
		}
	}
}
