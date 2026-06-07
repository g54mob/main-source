using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Assets.Scripts.Flight.Combat.Teams.Attributes;
using Assets.Scripts.Flight.Combat.Teams.Events;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.Events;
using Assets.Scripts.Multiplayer.Extensions;
using FishNet.Connection;
using FishNet.Serializing;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat.Teams
{
	public class TeamAggressionManager : MonoBehaviour
	{
		private Dictionary<int, AggressionLevel> _aggressionLevels;

		private HashSet<int> _allAggressionLevelChanges;

		private Dictionary<int, AggressionLevel> _defaultAggressionLevels;

		private FlightSceneScript _flightScene;

		private FlightSceneNetworkScript _flightSceneNetwork;

		private bool? _isServer;

		private HashSet<int> _lockedAggressionLevels;

		[SerializeField]
		private bool _loggingEnabled;

		private List<(int RelationshipId, AggressionLevel AggressionLevel)> _pendingAggressionLevelChanges;

		private List<(ushort RangeId, ushort RangeMin, ushort RangeMax)> _teamRanges;

		public event EventHandler<AggressionLevelChangedEventArgs> AggressionLevelChanged;

		public static TeamAggressionManager Create(FlightSceneNetworkScript flightSceneNetwork)
		{
			TeamAggressionManager teamAggressionManager = new GameObject("TeamAggressionManager").AddComponent<TeamAggressionManager>();
			teamAggressionManager.transform.SetParent(flightSceneNetwork.transform);
			try
			{
				teamAggressionManager.Initialize(flightSceneNetwork);
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred initializing the team aggression manager");
				Debug.LogException(exception);
			}
			return teamAggressionManager;
		}

		public AggressionLevel GetAggressionLevel(ushort teamId1, ushort teamId2)
		{
			if (teamId1 == teamId2)
			{
				return AggressionLevel.Friendly;
			}
			int relationshipId = GetRelationshipId(teamId1, teamId2);
			if (_aggressionLevels.TryGetValue(relationshipId, out var value))
			{
				return value;
			}
			int? teamRangeRelationshipId = GetTeamRangeRelationshipId(teamId1, teamId2);
			if (teamRangeRelationshipId.HasValue && _aggressionLevels.TryGetValue(teamRangeRelationshipId.Value, out value))
			{
				return value;
			}
			return AggressionLevel.Neutral;
		}

		public ushort? GetTeamRangeId(ushort teamId)
		{
			foreach (var teamRange in _teamRanges)
			{
				if (teamRange.RangeMin <= teamId && teamId <= teamRange.RangeMax)
				{
					return teamRange.RangeId;
				}
			}
			return null;
		}

		public void LogAllData()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Team Relationship Data");
			stringBuilder.AppendLine(string.Format("{0,25}  {1,-25}  {2,-6}  {3,-8}  {4,-8}  {5,-8}", "Team Id 1", "Team Id 2", "Locked", "Current", "Default", "Effective"));
			foreach (int item in (from x in _aggressionLevels.Keys.Concat(_defaultAggressionLevels.Keys).Distinct()
				orderby x
				select x).ToList())
			{
				(ushort, ushort) teamIdsFromRelationshipId = GetTeamIdsFromRelationshipId(item);
				bool flag = _lockedAggressionLevels.Contains(item);
				AggressionLevel value;
				AggressionLevel? aggressionLevel = (_aggressionLevels.TryGetValue(item, out value) ? new AggressionLevel?(value) : ((AggressionLevel?)null));
				AggressionLevel value2;
				AggressionLevel? aggressionLevel2 = (_defaultAggressionLevels.TryGetValue(item, out value2) ? new AggressionLevel?(value2) : ((AggressionLevel?)null));
				AggressionLevel aggressionLevel3 = GetAggressionLevel(teamIdsFromRelationshipId.Item1, teamIdsFromRelationshipId.Item2);
				stringBuilder.AppendLine($"{(TeamId)teamIdsFromRelationshipId.Item1,25}  {(TeamId)teamIdsFromRelationshipId.Item2,-25}  {flag,-6}  {aggressionLevel,-8}  {aggressionLevel2,-8}  {aggressionLevel3,-8}");
			}
			if (_pendingAggressionLevelChanges.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("Pending Changes");
				foreach (var pendingAggressionLevelChange in _pendingAggressionLevelChanges)
				{
					(ushort, ushort) teamIdsFromRelationshipId2 = GetTeamIdsFromRelationshipId(pendingAggressionLevelChange.RelationshipId);
					stringBuilder.AppendLine($"{(TeamId)teamIdsFromRelationshipId2.Item1,25}  {(TeamId)teamIdsFromRelationshipId2.Item2,-25}  {pendingAggressionLevelChange.AggressionLevel}");
				}
			}
			if (_allAggressionLevelChanges.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("All Changes");
				foreach (int allAggressionLevelChange in _allAggressionLevelChanges)
				{
					(ushort, ushort) teamIdsFromRelationshipId3 = GetTeamIdsFromRelationshipId(allAggressionLevelChange);
					stringBuilder.AppendLine($"{(TeamId)teamIdsFromRelationshipId3.Item1,25}  {(TeamId)teamIdsFromRelationshipId3.Item2,-25}");
				}
			}
			if (_teamRanges.Count > 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("Team Ranges");
				foreach (var teamRange in _teamRanges)
				{
					stringBuilder.AppendLine($"{teamRange.RangeId}:  {teamRange.RangeMin} -> {teamRange.RangeMax}");
				}
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine();
			Debug.Log(stringBuilder);
		}

		public void ResetAggressionLevels(ushort teamId, ushort? teamRangeId)
		{
			List<int> value;
			using (CollectionPool<List<int>, int>.Get(out value))
			{
				foreach (int allAggressionLevelChange in _allAggressionLevelChanges)
				{
					value.Add(allAggressionLevelChange);
				}
				foreach (var pendingAggressionLevelChange in _pendingAggressionLevelChanges)
				{
					if (!value.Contains(pendingAggressionLevelChange.RelationshipId))
					{
						value.Add(pendingAggressionLevelChange.RelationshipId);
					}
				}
				foreach (int item in value)
				{
					ushort? otherTeam = GetOtherTeam(item, teamId);
					if (otherTeam.HasValue && (!teamRangeId.HasValue || teamRangeId == GetTeamRangeId(otherTeam.Value)))
					{
						AggressionLevel value2;
						AggressionLevel aggressionLevel = (_defaultAggressionLevels.TryGetValue(item, out value2) ? value2 : AggressionLevel.Unknown);
						_pendingAggressionLevelChanges.Add((item, aggressionLevel));
						if (_loggingEnabled)
						{
							Debug.Log($"Aggression Level Reset: {(TeamId)teamId} <--> {(TeamId)otherTeam.Value}:  {aggressionLevel}");
						}
					}
				}
			}
		}

		public void ResetAggressionLevelsIfTeamContainsNoPlayers(ushort teamId)
		{
			if (_flightScene.AllPlayers.All((FlightScenePlayer p) => p.TeamId != teamId))
			{
				ResetAggressionLevels(teamId, null);
			}
		}

		public void ResetAggressionLevelsWithPlayerTeams(ushort playerTeamId)
		{
			if (GetTeamRangeId(playerTeamId) == 10)
			{
				ResetAggressionLevels(playerTeamId, 10);
			}
		}

		public void SetAggressionLevel(ushort teamId1, ushort teamId2, AggressionLevel aggressionLevel)
		{
			if (teamId1 == teamId2)
			{
				return;
			}
			int relationshipId = GetRelationshipId(teamId1, teamId2);
			AggressionLevel value;
			AggressionLevel aggressionLevel2 = (_aggressionLevels.TryGetValue(relationshipId, out value) ? value : AggressionLevel.Unknown);
			if (aggressionLevel2 == aggressionLevel)
			{
				return;
			}
			for (int num = _pendingAggressionLevelChanges.Count - 1; num >= 0; num--)
			{
				if (_pendingAggressionLevelChanges[num].RelationshipId == relationshipId)
				{
					if (_pendingAggressionLevelChanges[num].AggressionLevel != aggressionLevel)
					{
						break;
					}
					return;
				}
			}
			if (_lockedAggressionLevels.Contains(relationshipId))
			{
				return;
			}
			int? teamRangeRelationshipId = GetTeamRangeRelationshipId(teamId1, teamId2);
			if (!teamRangeRelationshipId.HasValue || !_lockedAggressionLevels.Contains(teamRangeRelationshipId.Value))
			{
				_pendingAggressionLevelChanges.Add((relationshipId, aggressionLevel));
				if (_loggingEnabled)
				{
					Debug.Log($"Aggression Level Change Pending: {(TeamId)teamId1} <--> {(TeamId)teamId2}:  {aggressionLevel2} --> {aggressionLevel}");
				}
			}
		}

		protected virtual void OnDestroy()
		{
			if ((object)_flightSceneNetwork.TimeManager != null)
			{
				_flightSceneNetwork.TimeManager.OnPostTick -= OnPostTick;
			}
			_flightSceneNetwork.SpawnServer -= OnSpawnServer;
			_flightSceneNetwork.ClientStarted -= OnClientStarted;
			_flightScene.PlayerUnloaded -= OnPlayerUnloaded;
			_flightSceneNetwork.UnsubscribeFromServerRpc(FlightSceneServerRpcType.TeamAggressionManager_Sync, OnSyncServerRpc);
			_flightSceneNetwork.UnsubscribeFromClientRpc(FlightSceneClientRpcType.TeamAggressionManager_Sync, OnSyncClientRpc);
		}

		private ushort? GetOtherTeam(int relationshipId, ushort teamId)
		{
			(ushort, ushort) teamIdsFromRelationshipId = GetTeamIdsFromRelationshipId(relationshipId);
			if (teamIdsFromRelationshipId.Item1 == teamId)
			{
				return teamIdsFromRelationshipId.Item2;
			}
			if (teamIdsFromRelationshipId.Item2 == teamId)
			{
				return teamIdsFromRelationshipId.Item1;
			}
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetRelationshipId(ushort teamId1, ushort teamId2)
		{
			if (teamId1 > teamId2)
			{
				return (teamId2 << 16) | teamId1;
			}
			return (teamId1 << 16) | teamId2;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private (ushort TeamId1, ushort TeamId2) GetTeamIdsFromRelationshipId(int relationshipId)
		{
			return (TeamId1: (ushort)(relationshipId >> 16), TeamId2: (ushort)(relationshipId & 0xFFFF));
		}

		private int? GetTeamRangeRelationshipId(ushort teamId1, ushort teamId2)
		{
			ushort? teamRangeId = GetTeamRangeId(teamId1);
			ushort? teamRangeId2 = GetTeamRangeId(teamId2);
			if (teamRangeId.HasValue || teamRangeId2.HasValue)
			{
				return GetRelationshipId(teamRangeId ?? teamId1, teamRangeId2 ?? teamId2);
			}
			return null;
		}

		private void Initialize(FlightSceneNetworkScript flightSceneNetwork)
		{
			_flightSceneNetwork = flightSceneNetwork;
			_flightSceneNetwork.SpawnServer += OnSpawnServer;
			_flightSceneNetwork.ClientStarted += OnClientStarted;
			_flightSceneNetwork.SubscribeToServerRpc(FlightSceneServerRpcType.TeamAggressionManager_Sync, OnSyncServerRpc);
			_flightSceneNetwork.SubscribeToClientRpc(FlightSceneClientRpcType.TeamAggressionManager_Sync, OnSyncClientRpc);
			_flightScene = FlightSceneScript.Instance;
			_flightScene.PlayerUnloaded += OnPlayerUnloaded;
			_pendingAggressionLevelChanges = new List<(int, AggressionLevel)>();
			_teamRanges = new List<(ushort, ushort, ushort)>();
			_allAggressionLevelChanges = new HashSet<int>();
			_lockedAggressionLevels = new HashSet<int>();
			_defaultAggressionLevels = new Dictionary<int, AggressionLevel>();
			InitializeDefaultAggressionLevels();
			_aggressionLevels = _defaultAggressionLevels.ToDictionary((KeyValuePair<int, AggressionLevel> x) => x.Key, (KeyValuePair<int, AggressionLevel> x) => x.Value);
			AggressionLevelChanged += delegate(object s, AggressionLevelChangedEventArgs e)
			{
				if (_loggingEnabled)
				{
					Debug.Log($"Aggression Level Changed: {(TeamId)e.TeamId1} <--> {(TeamId)e.TeamId2}:  {e.PreviousAggressionLevel} --> {e.NewAggressionLevel}");
				}
			};
		}

		private void InitializeDefaultAggressionLevels()
		{
			foreach (FieldInfo field in EnumUtility<TeamId>.Fields)
			{
				ushort num = (ushort)field.GetValue(null);
				foreach (DefaultAggressionLevelAttribute customAttribute2 in field.GetCustomAttributes<DefaultAggressionLevelAttribute>())
				{
					ushort teamId = (ushort)customAttribute2.TeamId;
					int relationshipId = GetRelationshipId(num, teamId);
					_defaultAggressionLevels[relationshipId] = customAttribute2.AggressionLevel;
					if (customAttribute2.Locked)
					{
						_lockedAggressionLevels.Add(relationshipId);
					}
				}
				TeamRangeAttribute customAttribute = field.GetCustomAttribute<TeamRangeAttribute>();
				if (customAttribute != null)
				{
					_teamRanges.Add((num, (ushort)customAttribute.StartRange, (ushort)customAttribute.EndRange));
				}
			}
		}

		private void OnClientStarted()
		{
			_isServer = _flightSceneNetwork.IsServerStarted;
			_flightSceneNetwork.TimeManager.OnPostTick += OnPostTick;
		}

		private void OnPlayerUnloaded(object sender, FlightScenePlayerEventArgs e)
		{
			if (_flightSceneNetwork.IsServerStarted && e.Player.NetworkedActivity == null)
			{
				ResetAggressionLevels(e.Player.TeamId, null);
			}
		}

		private void OnPostTick()
		{
			if (!_isServer.HasValue || _pendingAggressionLevelChanges.Count == 0)
			{
				return;
			}
			using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = _flightSceneNetwork.GetPooledWriter();
			WriteSyncData(pooledWriterDisposableWrapper, _pendingAggressionLevelChanges);
			ArraySegment<byte> data = pooledWriterDisposableWrapper.GetData();
			if (_isServer.Value)
			{
				_flightSceneNetwork.SendObserversRpc(FlightSceneClientRpcType.TeamAggressionManager_Sync, data, excludeOwner: false);
			}
			else
			{
				_flightSceneNetwork.SendServerRpc(FlightSceneServerRpcType.TeamAggressionManager_Sync, data);
			}
			_pendingAggressionLevelChanges.Clear();
		}

		private void OnSpawnServer(object sender, NetworkConnectionEventArgs e)
		{
			List<(int, AggressionLevel)> list = new List<(int, AggressionLevel)>(_allAggressionLevelChanges.Count);
			foreach (int allAggressionLevelChange in _allAggressionLevelChanges)
			{
				AggressionLevel value3;
				if (_aggressionLevels.TryGetValue(allAggressionLevelChange, out var value))
				{
					if (_defaultAggressionLevels.TryGetValue(allAggressionLevelChange, out var value2))
					{
						if (value != value2)
						{
							list.Add((allAggressionLevelChange, value));
						}
					}
					else
					{
						list.Add((allAggressionLevelChange, value));
					}
				}
				else if (_defaultAggressionLevels.TryGetValue(allAggressionLevelChange, out value3))
				{
					list.Add((allAggressionLevelChange, AggressionLevel.Unknown));
				}
			}
			using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = _flightSceneNetwork.GetPooledWriter();
			WriteSyncData(pooledWriterDisposableWrapper, list);
			_flightSceneNetwork.SendTargetRpc(FlightSceneClientRpcType.TeamAggressionManager_Sync, pooledWriterDisposableWrapper.GetData(), e.NetworkConnection);
		}

		private void OnSyncClientRpc(ArraySegment<byte> data)
		{
			using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = _flightSceneNetwork.GetPooledReader(data);
			ushort num = pooledReaderDisposableWrapper.Reader.ReadUInt16();
			for (int i = 0; i < num; i++)
			{
				int relationshipId = pooledReaderDisposableWrapper.Reader.ReadInt32();
				AggressionLevel aggressionLevel = pooledReaderDisposableWrapper.Reader.ReadEnum<AggressionLevel>();
				UpdateAggressionLevel(relationshipId, aggressionLevel);
			}
		}

		private void OnSyncServerRpc(ArraySegment<byte> data, NetworkConnection sender)
		{
			using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = _flightSceneNetwork.GetPooledReader(data);
			ushort num = pooledReaderDisposableWrapper.Reader.ReadUInt16();
			for (int i = 0; i < num; i++)
			{
				int item = pooledReaderDisposableWrapper.Reader.ReadInt32();
				AggressionLevel item2 = pooledReaderDisposableWrapper.Reader.ReadEnum<AggressionLevel>();
				_pendingAggressionLevelChanges.Add((item, item2));
			}
		}

		private void UpdateAggressionLevel(int relationshipId, AggressionLevel aggressionLevel)
		{
			if ((_aggressionLevels.TryGetValue(relationshipId, out var value) ? value : AggressionLevel.Unknown) == aggressionLevel)
			{
				return;
			}
			(ushort, ushort) teamIdsFromRelationshipId = GetTeamIdsFromRelationshipId(relationshipId);
			AggressionLevel aggressionLevel2 = GetAggressionLevel(teamIdsFromRelationshipId.Item1, teamIdsFromRelationshipId.Item2);
			if (aggressionLevel == AggressionLevel.Unknown)
			{
				_aggressionLevels.Remove(relationshipId);
			}
			else
			{
				_aggressionLevels[relationshipId] = aggressionLevel;
			}
			if ((_defaultAggressionLevels.TryGetValue(relationshipId, out var value2) ? value2 : AggressionLevel.Unknown) == aggressionLevel)
			{
				_allAggressionLevelChanges.Remove(relationshipId);
			}
			else
			{
				_allAggressionLevelChanges.Add(relationshipId);
			}
			try
			{
				AggressionLevel aggressionLevel3 = GetAggressionLevel(teamIdsFromRelationshipId.Item1, teamIdsFromRelationshipId.Item2);
				this.AggressionLevelChanged?.Invoke(this, new AggressionLevelChangedEventArgs(aggressionLevel3, aggressionLevel2, teamIdsFromRelationshipId.Item1, teamIdsFromRelationshipId.Item2));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void WriteSyncData(PooledWriter writer, IList<(int RelationshipId, AggressionLevel AggressionLevel)> data)
		{
			writer.WriteUInt16((ushort)data.Count);
			foreach (var datum in data)
			{
				writer.WriteInt32(datum.RelationshipId);
				writer.WriteEnum(datum.AggressionLevel);
			}
		}
	}
}
