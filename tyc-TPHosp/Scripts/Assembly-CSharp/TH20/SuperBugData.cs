#define LOG_LEVEL_VERBOSE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class SuperBugData
	{
		private readonly Dictionary<int, Coroutine> _uploadScoreCoroutines = new Dictionary<int, Coroutine>();

		public readonly Dictionary<int, int> NodeCompletionData = new Dictionary<int, int>();

		public readonly Dictionary<int, bool> NodeCompletedByLocalPlayer = new Dictionary<int, bool>();

		private int _numCompletedNodes;

		public bool IsDebug { get; private set; }

		public SuperBugDefinition Definition { get; private set; }

		public int Version
		{
			get
			{
				if (Definition == null)
				{
					return -1;
				}
				return Definition.Version;
			}
		}

		public int NumCompletedNodes => _numCompletedNodes;

		public SuperBugData(SuperBugDefinition definition, bool isDebug = false)
		{
			Definition = definition;
			IsDebug = isDebug;
		}

		public void UpdateDefinition(SuperBugDefinition newDefinition)
		{
			if (newDefinition != null && newDefinition.Version > Version)
			{
				Logging.Info("RB: Updating Super Bug Project from definition version {0} to {1}", Version, newDefinition.Version);
				Definition = newDefinition;
			}
		}

		public bool IsCompleted()
		{
			foreach (SuperBugNode item in Definition.GatherVictoryNodes())
			{
				if (!item.IsCompleted)
				{
					return false;
				}
			}
			return true;
		}

		public void OnSuperBugObjectiveComplete(int superBugID, int nodeID, Objective.CompletionType completionType)
		{
			if (completionType != Objective.CompletionType.Successful)
			{
				return;
			}
			if (Definition.SuperBugID == superBugID)
			{
				if (NodeCompletionData.TryGetValue(nodeID, out var value))
				{
					NodeCompletionData[nodeID] = value + 1;
				}
				NodeCompletedByLocalPlayer[nodeID] = true;
			}
			if (Definition == null || superBugID != Definition.SuperBugID)
			{
				return;
			}
			_numCompletedNodes = 0;
			foreach (KeyValuePair<int, int> nodeCompletionDatum in NodeCompletionData)
			{
				if (Definition.Network[nodeCompletionDatum.Key].IsCompleted)
				{
					_numCompletedNodes++;
				}
			}
			if (!_uploadScoreCoroutines.ContainsKey(nodeID))
			{
				_uploadScoreCoroutines[nodeID] = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(UploadCompletion(nodeID));
			}
		}

		private IEnumerator UploadCompletion(int nodeID)
		{
			string leaderboardName = string.Format("{0}{1}", IsDebug ? "SuperBugNode_Debug_" : "SuperBugNode_", nodeID);
			new SuperBugLeaderboard(leaderboardName);
			yield return LeaderboardHelperWrapper.Instance.FindOrCreateLeaderboard(leaderboardName);
			CreateOrFindResult createOrFindResult = LeaderboardHelperWrapper.Instance.GetCreateOrFindResult();
			if (createOrFindResult.found)
			{
				SuperBugLeaderboard leaderboard = createOrFindResult.leaderboard;
				yield return LeaderboardHelperWrapper.Instance.UploadEntry(leaderboard);
				UploadEntryResult uploadResult = LeaderboardHelperWrapper.Instance.GetUploadResult();
				Logging.Info("Uploading Superbug Leaderboard {0}, {1}", leaderboardName, uploadResult.success ? "Succeeded" : "Failed");
				_uploadScoreCoroutines.Remove(nodeID);
			}
			else
			{
				Logging.Warning(LogChannels.Online, "Couldn't upload score to Global Project leaderboard {0} - leaderboard was not found!", leaderboardName);
				_uploadScoreCoroutines.Remove(nodeID);
			}
		}
	}
}
