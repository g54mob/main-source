using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.Scenes.Events;
using Jundroo.DevConsole;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class TeamManager
	{
		private Dictionary<ushort, (NetworkedActivityScript Activity, NetworkedActivityTeamIds ActivityTeamId)> _activityTeamIds;

		private NetworkGameManager _networkGameManager;

		public TeamManager(NetworkGameManager networkGameManager)
		{
			_networkGameManager = networkGameManager;
			_activityTeamIds = new Dictionary<ushort, (NetworkedActivityScript, NetworkedActivityTeamIds)>();
			Game.Instance.SceneManager.SceneUnloaded += OnSceneUnloaded;
			DevConsoleApi.RegisterCommand("LogTeamData", delegate
			{
				LogAllData();
				FlightSceneScript.Instance?.TeamAggressionManager?.LogAllData();
			});
		}

		public ushort GetNextTeamId(NetworkPlayerScript player)
		{
			if (!_networkGameManager.IsServer)
			{
				throw new InvalidOperationException("Only the server can get new team IDs for assignment.");
			}
			int num = int.MaxValue;
			ushort result = 11;
			ushort teamId;
			for (teamId = 11; teamId <= 99; teamId++)
			{
				if (!_activityTeamIds.ContainsKey(teamId))
				{
					int num2 = _networkGameManager.Players.Where((NetworkPlayerScript x) => (player == null || x != player) && x.TeamId == teamId).Count();
					if (num2 < num)
					{
						num = num2;
						result = teamId;
					}
				}
			}
			return result;
		}

		public void LogAllData()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Team Manager Data");
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("Activity Team IDs:");
			stringBuilder.AppendLine(string.Format("{0,7}  {1,-16}  {2}", "Team Id", "Activity Team Id", "Activity Name"));
			foreach (KeyValuePair<ushort, (NetworkedActivityScript, NetworkedActivityTeamIds)> activityTeamId in _activityTeamIds)
			{
				stringBuilder.AppendLine(string.Format("{0,7}  {1,-16}  {2} {3}", activityTeamId.Key, activityTeamId.Value.Item2, activityTeamId.Value.Item1?.Data?.DisplayName, (activityTeamId.Value.Item1 == null) ? "(Activity is Dead)" : string.Empty));
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine("Player Teams:");
			List<(string, ushort)> list = new List<(string, ushort)>();
			foreach (NetworkPlayerScript player in _networkGameManager.Players)
			{
				list.Add((player.Name, player.TeamId));
			}
			list.Sort(((string Name, ushort TeamId) a, (string Name, ushort TeamId) b) => a.TeamId.CompareTo(b.TeamId));
			int totalWidth = list.Max<(string, ushort)>(((string Name, ushort TeamId) x) => x.Name.Length);
			foreach (var item in list)
			{
				stringBuilder.AppendLine($"{item.Item1.PadLeft(totalWidth, ' ')} {item.Item2,-4}");
			}
			stringBuilder.AppendLine();
			stringBuilder.AppendLine();
			Debug.Log(stringBuilder.ToString());
		}

		public void ReleaseActivityTeamId(ushort teamId)
		{
			if (!_networkGameManager.IsServer)
			{
				throw new InvalidOperationException("Only the server can release activity team IDs.");
			}
			_activityTeamIds.Remove(teamId);
		}

		public ushort RequestActivityTeamId(NetworkedActivityScript activity, NetworkedActivityTeamIds activityTeamId)
		{
			if (!_networkGameManager.IsServer)
			{
				throw new InvalidOperationException("Only the server can request activity team IDs.");
			}
			ushort nextTeamId = GetNextTeamId(null);
			_activityTeamIds.Add(nextTeamId, (activity, activityTeamId));
			return nextTeamId;
		}

		private void OnSceneUnloaded(object sender, SceneEventArgs e)
		{
			if (e.Scene == "Terrain" && _activityTeamIds.Count > 0)
			{
				Debug.LogError("The team manager's activity team ids were not empty after unloading the flight scene.");
				_activityTeamIds.Clear();
			}
		}
	}
}
