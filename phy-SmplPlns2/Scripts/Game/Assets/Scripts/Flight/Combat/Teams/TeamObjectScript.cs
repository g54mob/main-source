using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.Combat.Teams.Events;
using Assets.Scripts.Multiplayer.FlightObjects;
using Assets.Scripts.Multiplayer.FlightObjects.Events;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat.Teams
{
	public class TeamObjectScript : MonoBehaviour
	{
		private NetworkFlightObject _networkFlightObject;

		private TeamAggressionManager _teamAggressionManager;

		[SerializeField]
		private ushort _teamId;

		private ushort? _teamRangeId;

		public ushort TeamId => _teamId;

		public event EventHandler<AggressionLevelsChangedEventArgs> AggressionLevelsChanged;

		public event EventHandler<TeamChangedEventArgs> TeamChanged;

		public void SetAggressionLevelForAllPlayers(AggressionLevel aggressionLevel)
		{
			foreach (FlightScenePlayer allPlayer in FlightSceneScript.Instance.AllPlayers)
			{
				SetAggressionLevelForTeam(allPlayer.TeamId, AggressionLevel.Unknown);
			}
			SetAggressionLevelForTeam(10, aggressionLevel);
		}

		public void SetAggressionLevelForPlayer(int playerId, AggressionLevel aggressionLevel)
		{
			FlightScenePlayer player = FlightSceneScript.Instance.GetPlayer(playerId);
			if (player == null)
			{
				Debug.LogError($"Unable to find the player with id '{playerId}' when setting the aggression level for team '{_teamId}'");
			}
			else
			{
				SetAggressionLevelForTeam(player.TeamId, aggressionLevel);
			}
		}

		public void SetAggressionLevelForTeam(ushort teamId, AggressionLevel aggressionLevel)
		{
			_teamAggressionManager.SetAggressionLevel(_teamId, teamId, aggressionLevel);
		}

		protected virtual void Awake()
		{
			_networkFlightObject = GetComponentInParent<NetworkFlightObject>();
			if (_networkFlightObject != null)
			{
				_networkFlightObject.LocalClientInitialized += OnLocalClientInitialized;
				UpdateTeamFromNetworkFlightObjectSpawnData();
			}
			_teamAggressionManager = FlightSceneScript.Instance.TeamAggressionManager;
			if (_teamAggressionManager != null)
			{
				_teamAggressionManager.AggressionLevelChanged += OnAggressionLevelChanged;
			}
		}

		protected virtual void OnDestroy()
		{
			if (_networkFlightObject != null)
			{
				_networkFlightObject.LocalClientInitialized -= OnLocalClientInitialized;
			}
			if (_teamAggressionManager != null)
			{
				_teamAggressionManager.AggressionLevelChanged -= OnAggressionLevelChanged;
			}
		}

		private void OnAggressionLevelChanged(object sender, AggressionLevelChangedEventArgs e)
		{
			if (_teamId == e.TeamId1 || _teamRangeId == e.TeamId1 || _teamId == e.TeamId2 || _teamRangeId == e.TeamId2)
			{
				this.AggressionLevelsChanged?.Invoke(this, new AggressionLevelsChangedEventArgs());
			}
		}

		private void OnLocalClientInitialized(object sender, NetworkFlightObjectEventArgs e)
		{
			UpdateTeamFromNetworkFlightObjectSpawnData();
		}

		private void UpdateTeamFromNetworkFlightObjectSpawnData()
		{
			if (_networkFlightObject == null)
			{
				return;
			}
			IReadOnlyDictionary<string, string> spawnData = _networkFlightObject.SpawnData;
			if (spawnData == null || !spawnData.TryGetValue("TeamId", out var value))
			{
				return;
			}
			if (!ushort.TryParse(value, out var result))
			{
				Debug.LogError("Unable to parse the team id from the network flight object's spawn data: " + value);
				return;
			}
			ushort teamId = _teamId;
			if (teamId != result)
			{
				_teamId = result;
				_teamRangeId = _teamAggressionManager.GetTeamRangeId(result);
				this.TeamChanged?.Invoke(this, new TeamChangedEventArgs(teamId, result));
				this.AggressionLevelsChanged?.Invoke(this, new AggressionLevelsChangedEventArgs());
			}
		}
	}
}
