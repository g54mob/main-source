#define LOG_LEVEL_VERBOSE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class SuperBugProject : MustCallDestroy
	{
		public SuperBugObjective ActiveObjective;

		public List<int> CompletedNodes = new List<int>();

		public List<CollaborativeNode.VictoryNodeType> CollectedRewards;

		private int _currentVersion;

		[DontSave]
		private Metagame _metagame;

		[DontSave]
		private Dictionary<int, Coroutine> _uploadScoreCoroutines;

		[DontSave]
		public Dictionary<int, int> NodeCompletionData;

		[DontSave]
		public Dictionary<int, bool> NodeCompletedByLocalPlayer;

		private readonly bool _isDebug;

		public SuperBugDefinition Definition { get; private set; }

		public int CurrentVersion => _currentVersion;

		public bool IsDebug => _isDebug;

		public SuperBugProject(Metagame metagame, SuperBugDefinition definition, bool isDebug = false)
		{
			_metagame = metagame;
			Definition = definition;
			_currentVersion = definition.Version;
			_isDebug = isDebug;
			CollectedRewards = new List<CollaborativeNode.VictoryNodeType>();
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				NodeCompletionData = new Dictionary<int, int>();
				NodeCompletedByLocalPlayer = new Dictionary<int, bool>();
				_uploadScoreCoroutines = new Dictionary<int, Coroutine>();
			}
		}

		public void RestoreFromSave(Metagame metagame)
		{
			_metagame = metagame;
			if (CollectedRewards == null)
			{
				CollectedRewards = new List<CollaborativeNode.VictoryNodeType>();
			}
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				NodeCompletionData = new Dictionary<int, int>();
				NodeCompletedByLocalPlayer = new Dictionary<int, bool>();
				_uploadScoreCoroutines = new Dictionary<int, Coroutine>();
			}
		}

		public override void Destroy()
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				foreach (KeyValuePair<int, Coroutine> uploadScoreCoroutine in _uploadScoreCoroutines)
				{
					OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(uploadScoreCoroutine.Value);
				}
			}
			base.Destroy();
		}

		public void UpdateDefinition(SuperBugDefinition definition)
		{
			if (definition != null && definition.Version > _currentVersion)
			{
				Logging.Info("RB: Updating Super Bug Project from definition version {0} to {1}", CurrentVersion, definition.Version);
				Definition = definition;
				_currentVersion = definition.Version;
			}
		}

		public void Update(float timeDelta, float unscaledTimeDelta)
		{
			if (ActiveObjective != null)
			{
				ActiveObjective.Update(timeDelta, unscaledTimeDelta);
			}
		}

		public void SetActiveObjective(int nodeID, ObjectiveDefinition definition)
		{
			if (ActiveObjective != null)
			{
				ActiveObjective.Abandon();
			}
			ActiveObjective = new SuperBugObjective(_metagame, definition, definition.IsTimed, Definition.SuperBugID, nodeID);
			ActiveObjective.Initialise();
			if (!ActiveObjective.IsReplayable)
			{
				ActiveObjective.Start();
			}
		}

		public void ClearActiveObjective()
		{
			if (ActiveObjective != null)
			{
				ActiveObjective.Destroy();
				ActiveObjective = null;
			}
		}

		public void OnObjectiveFinished(int superBugID, int nodeID, Objective.CompletionType completionType)
		{
			if (completionType == Objective.CompletionType.Successful)
			{
				if (Definition.SuperBugID == superBugID)
				{
					CompletedNodes.AddUnique(nodeID);
					if (NodeCompletionData.TryGetValue(nodeID, out var value))
					{
						NodeCompletionData[nodeID] = value + 1;
					}
					NodeCompletedByLocalPlayer[nodeID] = true;
				}
				ClearActiveObjective();
			}
			if (Definition == null || superBugID != Definition.SuperBugID)
			{
				return;
			}
			switch (completionType)
			{
			case Objective.CompletionType.Successful:
				if (!_uploadScoreCoroutines.ContainsKey(nodeID))
				{
					_uploadScoreCoroutines[nodeID] = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(UploadCompletion(nodeID));
				}
				break;
			default:
				if (ActiveObjective.IsReplayable)
				{
					break;
				}
				goto case Objective.CompletionType.Abandoned;
			case Objective.CompletionType.Abandoned:
				ClearActiveObjective();
				break;
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
