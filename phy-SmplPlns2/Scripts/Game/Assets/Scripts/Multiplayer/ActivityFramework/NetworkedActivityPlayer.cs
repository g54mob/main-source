using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using FishNet.Connection;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	public class NetworkedActivityPlayer
	{
		private List<NetworkedActivityScore> _scores;

		public NetworkedActivityScript Activity { get; private set; }

		public bool IsAI => Player.NetworkPlayer.IsNPC;

		public int LeaderboardPlaceNumber { get; set; }

		public string Name => Player?.Name ?? $"Player {PlayerId}";

		public NetworkConnection Owner => Player?.NetworkPlayer?.Owner;

		public FlightScenePlayer Player { get; private set; }

		public int PlayerId { get; private set; }

		public IReadOnlyList<NetworkedActivityScore> Scores => _scores;

		public NetworkedActivityPlayerState State { get; private set; }

		public NetworkedActivityTeam Team { get; private set; }

		public event EventHandler<NetworkedActivityPlayerStateChangedEventArgs> StateChanged;

		public event EventHandler<NetworkedActivityPlayerTeamEventArgs> TeamChanged;

		public NetworkedActivityPlayer(int playerId)
		{
			PlayerId = playerId;
			_scores = new List<NetworkedActivityScore>();
		}

		public NetworkedActivityPlayer(FlightScenePlayer player)
		{
			Player = player;
			PlayerId = player.NetworkPlayer.PlayerId;
			_scores = new List<NetworkedActivityScore>();
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

		public void OnActivityJoined(NetworkedActivityScript activity)
		{
			Activity = activity;
			Player.OnNetworkedActivityJoined(activity);
		}

		public void OnActivityLeft()
		{
			Activity = null;
			Player.OnNetworkedActivityLeft();
		}

		public void OnPlayerLoaded(FlightScenePlayer player)
		{
			if (Player != null)
			{
				throw new InvalidOperationException(string.Format("Unable to set the player for the {0} with id '{1}' because the player has already been set.", "NetworkedActivityPlayer", PlayerId));
			}
			Player = player;
		}

		public void OnStateChanged(NetworkedActivityPlayerState state)
		{
			NetworkedActivityPlayerState state2 = State;
			State = state;
			this.StateChanged?.Invoke(this, new NetworkedActivityPlayerStateChangedEventArgs(Activity, this, state2, state));
		}

		public void OnTeamChanged(NetworkedActivityTeam team)
		{
			Team = team;
			this.TeamChanged?.Invoke(this, new NetworkedActivityPlayerTeamEventArgs(Activity, this, team));
		}

		public void RegisterScore(NetworkedActivityScore score)
		{
			foreach (NetworkedActivityScore score2 in _scores)
			{
				if (score2.Id == score.Id)
				{
					throw new InvalidOperationException("A score with id '" + score.Id + "' has already been registered with player '" + Name + "'");
				}
			}
			_scores.Add(score);
		}

		public void SerializeRead(Reader reader, bool skipId)
		{
			if (!skipId)
			{
				PlayerId = reader.ReadInt32();
			}
		}

		public void SerializeWrite(Writer writer, bool skipId)
		{
			if (!skipId)
			{
				writer.Write(PlayerId);
			}
		}
	}
}
