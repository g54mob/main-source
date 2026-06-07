using System.Collections.Generic;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using Jundroo.Common.DataTypes;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Activity
{
	public class TeamListPanelScript : WidgetScript
	{
		private class PlayerRow
		{
			public TextWidget Place { get; }

			public TextWidget PlayerName { get; }

			public Widget RootWidget { get; }

			public TextWidget Score { get; }

			public PlayerRow(Widget rootWidget, TextWidget name, TextWidget place, TextWidget score)
			{
				RootWidget = rootWidget;
				PlayerName = name;
				Place = place;
				Score = score;
			}

			public void UpdateRow(NetworkedActivityPlayer player, int place, string score)
			{
				PlayerName.Text = player.Player.Name;
				Place.Text = $"#{place + 1}";
				Score.Text = score;
			}
		}

		private class TeamListPanel
		{
			public List<NetworkedActivityPlayer> LastSortedPlayers { get; set; }

			public List<PlayerRow> PlayerRows { get; }

			public Widget PlayerRowsRootWidget { get; }

			public Widget RootWidget { get; }

			public NetworkedActivityTeam Team { get; }

			public TeamListPanel(NetworkedActivityTeam team, Widget rootWidget)
			{
				Team = team;
				RootWidget = rootWidget;
				PlayerRows = new List<PlayerRow>();
				PlayerRowsRootWidget = rootWidget?.FindWidget("player-rows");
				if (PlayerRowsRootWidget == null)
				{
					Debug.LogError("Unable to find the player rows root widget for team '" + team.Name + "'");
				}
			}

			public PlayerRow CreatePlayerRow()
			{
				Widget widget = RootWidget.Context.CreateWidgetFromTemplate("player-row", PlayerRowsRootWidget);
				TextWidget name = widget.FindWidget<TextWidget>("player-name");
				TextWidget place = widget.FindWidget<TextWidget>("place-number");
				TextWidget score = widget.FindWidget<TextWidget>("player-score");
				PlayerRow playerRow = new PlayerRow(widget, name, place, score);
				PlayerRows.Add(playerRow);
				return playerRow;
			}
		}

		private EnumDictionary<NetworkedActivityTeamIds, TeamListPanel> _teamListPanels;

		private bool _updateScores;

		public NetworkedActivityScript Activity { get; private set; }

		private bool ActivityEnded => (int)Activity.State >= 5;

		public void Initialize(NetworkedActivityScript activity)
		{
			Activity = activity;
			Activity.TeamJoined += OnPlayerTeamChanged;
			Activity.TeamLeft += OnPlayerTeamChanged;
			Activity.PlayerScoreChanged += OnPlayerScoreChanged;
			Activity.PlayerStateChanged += OnPlayerStateChanged;
			Activity.TeamScoreChanged += OnTeamScoreChanged;
			_teamListPanels = new EnumDictionary<NetworkedActivityTeamIds, TeamListPanel>();
			InitializeTeamListPanel(NetworkedActivityTeamIds.Team1);
			InitializeTeamListPanel(NetworkedActivityTeamIds.Team2);
			RefreshPanel(NetworkedActivityTeamIds.Team1);
			RefreshPanel(NetworkedActivityTeamIds.Team2);
		}

		protected virtual void OnDestroy()
		{
			Activity.TeamJoined -= OnPlayerTeamChanged;
			Activity.TeamLeft -= OnPlayerTeamChanged;
			Activity.PlayerScoreChanged -= OnPlayerScoreChanged;
			Activity.PlayerStateChanged -= OnPlayerStateChanged;
			Activity.TeamScoreChanged -= OnTeamScoreChanged;
			Activity = null;
		}

		protected virtual void Update()
		{
			if (!(Activity != null) || !_updateScores)
			{
				return;
			}
			_updateScores = false;
			foreach (TeamListPanel value in _teamListPanels.Values)
			{
				if (value != null)
				{
					UpdatePlayerRows(value, value.Team);
				}
			}
		}

		private void InitializeTeamListPanel(NetworkedActivityTeamIds teamId)
		{
			Widget widget = base.Widget.FindWidget($"team-list-panel-{teamId}");
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

		private void OnPlayerScoreChanged(object sender, NetworkedActivityPlayerScoreEventArgs e)
		{
			_updateScores = true;
		}

		private void OnPlayerStateChanged(object sender, NetworkedActivityPlayerStateChangedEventArgs e)
		{
			RefreshPanel(e.Player.Team.Id);
		}

		private void OnPlayerTeamChanged(object sender, NetworkedActivityPlayerTeamEventArgs e)
		{
			RefreshPanel(e.Team.Id);
		}

		private void OnTeamScoreChanged(object sender, NetworkedActivityTeamScoreEventArgs e)
		{
			_updateScores = true;
		}

		private void RefreshPanel(NetworkedActivityTeamIds teamId)
		{
			TeamListPanel panel = _teamListPanels[teamId];
			NetworkedActivityTeam team = Activity.GetTeam(teamId);
			UpdatePlayerRows(panel, team);
		}

		private void UpdatePlayerRows(TeamListPanel panel, NetworkedActivityTeam team)
		{
			List<NetworkedActivityPlayer> list = null;
			if (ActivityEnded && panel.LastSortedPlayers != null)
			{
				list = panel.LastSortedPlayers;
			}
			else
			{
				list = new List<NetworkedActivityPlayer>();
				foreach (NetworkedActivityPlayer player2 in team.Players)
				{
					if ((int)player2.State >= 2)
					{
						list.Add(player2);
					}
				}
			}
			panel.LastSortedPlayers = Activity.SortPlayerListByScore(list);
			for (int i = 0; i < panel.LastSortedPlayers.Count; i++)
			{
				PlayerRow obj = ((panel.PlayerRows.Count > i) ? panel.PlayerRows[i] : panel.CreatePlayerRow());
				panel.PlayerRows[i].RootWidget.Visible = true;
				NetworkedActivityPlayer player = panel.LastSortedPlayers[i];
				obj.UpdateRow(player, i, Activity.GetPlayerScoreString(player));
			}
			for (int j = panel.LastSortedPlayers.Count; j < panel.PlayerRows.Count; j++)
			{
				panel.PlayerRows[j].RootWidget.Visible = false;
			}
		}
	}
}
