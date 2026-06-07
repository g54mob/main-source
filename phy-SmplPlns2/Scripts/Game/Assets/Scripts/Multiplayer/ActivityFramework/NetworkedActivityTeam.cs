using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	public class NetworkedActivityTeam
	{
		private List<NetworkedActivityPlayer> _players;

		private List<NetworkedActivityScore> _scores;

		private List<StartLocationData> _startLocations;

		public NetworkedActivityScript Activity { get; }

		public NetworkedActivityTeamIds Id { get; }

		public bool IsPlayerJoinable { get; }

		public string Name { get; }

		public IReadOnlyList<NetworkedActivityPlayer> Players => _players;

		public ushort PlayerTeamId { get; private set; }

		public IReadOnlyList<NetworkedActivityScore> Scores => _scores;

		public IReadOnlyList<StartLocationData> StartLocations => _startLocations;

		public NetworkedActivityTeamType TeamType { get; }

		public event EventHandler<NetworkedActivityPlayerTeamEventArgs> PlayerJoined;

		public event EventHandler<NetworkedActivityPlayerTeamEventArgs> PlayerLeft;

		public NetworkedActivityTeam(NetworkedActivityScript activity, NetworkedActivityTeamIds id, NetworkedActivityTeamType type, ushort playerTeamId, string name, bool isPlayerJoinable, IEnumerable<StartLocationData> startLocations)
		{
			Activity = activity;
			Id = id;
			TeamType = type;
			PlayerTeamId = (ushort)((type == NetworkedActivityTeamType.Default) ? playerTeamId : 0);
			Name = name;
			IsPlayerJoinable = isPlayerJoinable;
			_players = new List<NetworkedActivityPlayer>();
			_startLocations = new List<StartLocationData>(startLocations);
			_scores = new List<NetworkedActivityScore>();
		}

		public void AddPlayer(NetworkedActivityPlayer player)
		{
			_players.Add(player);
			NetworkPlayerScript networkPlayer = player.Player.NetworkPlayer;
			if (networkPlayer.IsServerStarted)
			{
				if (TeamType == NetworkedActivityTeamType.Default)
				{
					networkPlayer.ChangeTeam(PlayerTeamId);
				}
				else
				{
					ushort nextTeamId = Game.Instance.NetworkGameManager.TeamManager.GetNextTeamId(null);
					networkPlayer.ChangeTeam(nextTeamId);
					AggressionLevel aggressionLevel = TeamType switch
					{
						NetworkedActivityTeamType.TeamPerPlayerFriendly => AggressionLevel.Friendly, 
						NetworkedActivityTeamType.TeamPerPlayerHostile => AggressionLevel.Hostile, 
						_ => AggressionLevel.Neutral, 
					};
					TeamAggressionManager teamAggressionManager = FlightSceneScript.Instance.TeamAggressionManager;
					foreach (NetworkedActivityPlayer player2 in Players)
					{
						teamAggressionManager.SetAggressionLevel(nextTeamId, player2.Player.TeamId, aggressionLevel);
					}
				}
			}
			player.OnTeamChanged(this);
			try
			{
				this.PlayerJoined?.Invoke(this, new NetworkedActivityPlayerTeamEventArgs(Activity, player, this));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public NetworkedActivityPlayer GetPlayer(NetworkedActivityPlayer player)
		{
			return GetPlayer(player.PlayerId);
		}

		public NetworkedActivityPlayer GetPlayer(FlightScenePlayer player)
		{
			return GetPlayer(player.NetworkPlayer.PlayerId);
		}

		public NetworkedActivityPlayer GetPlayer(int playerId)
		{
			for (int i = 0; i < _players.Count; i++)
			{
				if (_players[i].PlayerId == playerId)
				{
					return _players[i];
				}
			}
			return null;
		}

		public NetworkedActivityScore GetScore()
		{
			return _scores.FirstOrDefault();
		}

		public NetworkedActivityScore GetScore(string id)
		{
			foreach (NetworkedActivityScore score in _scores)
			{
				if (score.Id == id)
				{
					return score;
				}
			}
			return null;
		}

		public bool IsPlayerOnTeam(NetworkedActivityPlayer player)
		{
			return GetPlayer(player) != null;
		}

		public bool IsPlayerOnTeam(FlightScenePlayer player)
		{
			return GetPlayer(player) != null;
		}

		public bool IsPlayerOnTeam(int playerId)
		{
			return GetPlayer(playerId) != null;
		}

		public void RegisterScore(NetworkedActivityScore score)
		{
			foreach (NetworkedActivityScore score2 in _scores)
			{
				if (score2.Id == score.Id)
				{
					throw new InvalidOperationException("A score with id '" + score.Id + "' has already been registered with team '" + Name + "'");
				}
			}
			_scores.Add(score);
		}

		public void RemovePlayer(NetworkedActivityPlayer player)
		{
			_players.Remove(player);
			NetworkPlayerScript networkPlayer = player.Player.NetworkPlayer;
			if (networkPlayer.IsServerStarted)
			{
				networkPlayer.ChangeTeam(null);
			}
			player.OnTeamChanged(null);
			try
			{
				this.PlayerLeft?.Invoke(this, new NetworkedActivityPlayerTeamEventArgs(Activity, player, this));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
