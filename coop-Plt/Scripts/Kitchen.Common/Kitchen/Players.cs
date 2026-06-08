using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Kitchen.NetworkSupport;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class Players
	{
		public static Players Main;

		private Dictionary<int, PlayerInfo> PlayerData = new Dictionary<int, PlayerInfo>();

		private Dictionary<int, ProfileIdentifier> RemovedInputProfiles = new Dictionary<int, ProfileIdentifier>();

		public Dictionary<SourceIdentifier, InfoManagerPeerDetail> PeerData = new Dictionary<SourceIdentifier, InfoManagerPeerDetail>();

		private List<int> _PlayerIteration = new List<int>();

		private List<int> _RemovedPlayers = new List<int>();

		public IEnumerable<PlatformUser> LocalUsers => from p in PlayerData
			where p.Value.IsLocalUser && !p.Value.IsJoining
			select InputSourceIdentifier.Default.GetPlatformUser(p.Value.ID);

		public event Action OnPlayerInfoChanged = delegate
		{
		};

		public event Action<int> OnBroadcastLocalPlayerChange = delegate
		{
		};

		public Players()
		{
			ProfileStore.Main.OnProfileChanged += OnProfileChanged;
		}

		private void OnProfileChanged(ProfileIdentifier identifier)
		{
			_PlayerIteration.Clear();
			foreach (KeyValuePair<int, PlayerInfo> playerDatum in PlayerData)
			{
				_PlayerIteration.Add(playerDatum.Key);
			}
			foreach (int item in _PlayerIteration)
			{
				if (PlayerData[item].Profile.Identifier == identifier)
				{
					ReloadLocalProfile(item);
				}
			}
		}

		public List<PlayerInfo> All()
		{
			return PlayerData.Values.ToList();
		}

		public bool Has(int player_id)
		{
			return PlayerData.ContainsKey(player_id);
		}

		public bool TryGetActiveProfile(int player_id, out ProfileIdentifier identifier)
		{
			identifier = default(ProfileIdentifier);
			if (PlayerData.TryGetValue(player_id, out var value))
			{
				identifier = value.Profile.Identifier;
				return true;
			}
			return false;
		}

		public PlayerInfo Get(int player_id)
		{
			if (PlayerData.TryGetValue(player_id, out var value))
			{
				return value;
			}
			return PlayerInfo.Default(player_id);
		}

		public void ApplyBindings(int player_id)
		{
			PlayerInfo value = Get(player_id);
			bool flag = !value.IsJoining;
			if (!value.HasAppliedBindings && flag)
			{
				value.HasAppliedBindings = true;
				PlayerData[player_id] = value;
				ProfileStore.Main.ApplyBindings(player_id, value.Profile.Identifier);
			}
		}

		public void AddLocalPlayer(int player_id, ProfileIdentifier profile = default(ProfileIdentifier))
		{
			if (PlayerData.ContainsKey(player_id))
			{
				Debug.LogWarning($"Tried to add a player who already exists {player_id}");
				return;
			}
			PlayerInfo value = PlayerInfo.Default(player_id);
			PlayerData.Add(player_id, value);
			ProfileIdentifier value2;
			if (profile != default(ProfileIdentifier))
			{
				SetActiveProfile(player_id, profile);
			}
			else if (RemovedInputProfiles.TryGetValue(player_id, out value2) && ProfileStore.Main.AvailableProfiles().Contains(value2))
			{
				SetActiveProfile(player_id, value2);
			}
			this.OnBroadcastLocalPlayerChange(player_id);
		}

		public void RemoveLocalPlayer(int player_id)
		{
			if (PlayerData.ContainsKey(player_id))
			{
				RemovedInputProfiles[player_id] = PlayerData[player_id].Profile.Identifier;
				PlayerData.Remove(player_id);
			}
		}

		public void SetActiveProfile(int player_id, ProfileIdentifier identifier)
		{
			if (!PlayerData.TryGetValue(player_id, out var value))
			{
				Debug.LogWarning($"Tried to set profile of non-existent user {player_id}");
				return;
			}
			value.Profile.Identifier = identifier;
			value.HasAppliedBindings = false;
			PlayerData[player_id] = value;
			ReloadLocalProfile(player_id);
		}

		public void ReloadLocalProfile(int player_id)
		{
			if (PlayerData.TryGetValue(player_id, out var value) && value.IsLocalUser && ProfileStore.Main.TryGetProfile(value.Profile.Identifier, out var profile))
			{
				value.Profile = profile;
				value.HasAppliedBindings = false;
				PlayerData[player_id] = value;
				this.OnBroadcastLocalPlayerChange(player_id);
			}
		}

		public void ReceiveRemoteUpdate(List<PlayerInfo> player_infos)
		{
			_RemovedPlayers.Clear();
			foreach (KeyValuePair<int, PlayerInfo> player in PlayerData)
			{
				if (!player_infos.Any((PlayerInfo p) => p.ID == player.Key))
				{
					_RemovedPlayers.Add(player.Key);
				}
			}
			foreach (int removedPlayer in _RemovedPlayers)
			{
				if (PlayerData.TryGetValue(removedPlayer, out var value) && value.IsLocalUser)
				{
					value.RemovedByRemote();
					PlayerData[removedPlayer] = value;
					ProfileStore.Main.ApplyBindings(removedPlayer, (ProfileIdentifier)"");
				}
				EventLog.Session.Report(SessionEvent.PlayerBeingRemoved, $"{removedPlayer}/{value.Name}: local={value.IsLocalUser}, {player_infos.Count()}");
				PlayerData.Remove(removedPlayer);
			}
			foreach (PlayerInfo player_info in player_infos)
			{
				ReceiveRemoteUpdate(player_info.ID, player_info);
			}
			this.OnPlayerInfoChanged();
		}

		private void ReceiveRemoteUpdate(int player_id, PlayerInfo info)
		{
			if (info.IsLocalUser)
			{
				if (PlayerData.TryGetValue(player_id, out var value))
				{
					value.UpdateFromRemote(info);
					PlayerData[player_id] = value;
				}
				else
				{
					Debug.LogWarning($"Received a server Players update for a local user {player_id} ({info.Name}) who is not present");
				}
			}
			else
			{
				PlayerData[player_id] = info;
			}
		}
	}
}
