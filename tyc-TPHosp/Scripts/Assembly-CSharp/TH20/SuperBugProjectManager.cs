#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using MessagePack;
using UnityConsole;
using UnityEngine;
using UnityEngine.Networking;

namespace TH20
{
	[DontSave]
	public class SuperBugProjectManager : MustCallDestroy
	{
		public Action OnCompletionDataReceived;

		public Action OnProjectViewed;

		public Action OnSuperBugManagerInitialised;

		public Action<SuperBugDefinition> OnNewSuperBugDefinitionDownloaded;

		private Coroutine _getLatestCoroutine;

		private App _app;

		private Dictionary<int, SuperBugLeaderboard> _leaderboardLookup;

		private float _elapsedTime;

		public bool IsInitialised;

		private Queue<int> _currentNodeSearchQueue = new Queue<int>();

		private const float WaitBetweenGetLatest = 300f;

		private bool _isDebug;

		private SuperBugDefinition _downloadedProjectDefinition;

		private const string _globalProjectUrl = "https://cdn.assets.twopointstudios.com/collaborative/global.rdf";

		private SuperBugData _data;

		private SuperBugDefinition _downloadedDebugProjectDefinition;

		private const string _globalProjectDebugUrl = "https://cdn.assets.twopointstudios.com/collaborative/test.rdf";

		private SuperBugData _debugData;

		private const string _globalProjectCompletionListUrl = "https://cdn.assets.twopointstudios.com/collaborative/gpcl.rdf";

		private List<int> _completionList = new List<int>();

		public ErrorCode Error { get; private set; }

		public bool IsProjectUpToDate { get; private set; }

		public bool IsDebug
		{
			get
			{
				return _isDebug;
			}
			set
			{
				_isDebug = value;
				OnDebugModeChanged();
			}
		}

		public SuperBugData Data
		{
			get
			{
				if (!IsDebug)
				{
					return _data;
				}
				return _debugData;
			}
			private set
			{
				if (IsDebug)
				{
					_debugData = value;
				}
				else
				{
					_data = value;
				}
			}
		}

		public SuperBugDefinition DownloadedProjectDefinition
		{
			get
			{
				if (!IsDebug)
				{
					return _downloadedProjectDefinition;
				}
				return _downloadedDebugProjectDefinition;
			}
			private set
			{
				if (IsDebug)
				{
					_downloadedDebugProjectDefinition = value;
				}
				else
				{
					_downloadedProjectDefinition = value;
				}
			}
		}

		private string GlobalProjectUrl
		{
			get
			{
				if (!IsDebug)
				{
					return "https://cdn.assets.twopointstudios.com/collaborative/global.rdf";
				}
				return "https://cdn.assets.twopointstudios.com/collaborative/test.rdf";
			}
		}

		public SuperBugProjectManager(App app)
		{
			_app = app;
			_isDebug = false;
			_leaderboardLookup = new Dictionary<int, SuperBugLeaderboard>();
			Initialise();
		}

		public void RestoreFromSave(App app)
		{
			_app = app;
			_isDebug = false;
			_leaderboardLookup = new Dictionary<int, SuperBugLeaderboard>();
			Initialise();
		}

		public void StopGettingLatest()
		{
			if (_getLatestCoroutine != null)
			{
				OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_getLatestCoroutine);
				_getLatestCoroutine = null;
			}
		}

		public override void Destroy()
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				if (_getLatestCoroutine != null)
				{
					OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_getLatestCoroutine);
					_getLatestCoroutine = null;
				}
				ConsoleCommandsDatabase.UnRegisterCommand("ForceGetGlobalProjectData");
			}
			base.Destroy();
		}

		public void Initialise()
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				if (_getLatestCoroutine != null)
				{
					OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_getLatestCoroutine);
					_getLatestCoroutine = null;
				}
				_leaderboardLookup.Clear();
				IsInitialised = false;
				ForceGetLatest();
				ConsoleCommandsDatabase.RegisterCommand("ForceGetGlobalProjectData", "Forces a download of the superbug project data", "ForceGetGlobalProjectData", Debug_ForceGetGlobalProjectData);
			}
		}

		public void Update(float timeDelta, float unscaledTimeDelta)
		{
			if (IsInitialised && _getLatestCoroutine == null)
			{
				_elapsedTime += Time.unscaledDeltaTime;
				if (_elapsedTime > 300f)
				{
					_getLatestCoroutine = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(GetLatestScores());
				}
			}
		}

		public void ForceGetLatest()
		{
			if (_getLatestCoroutine == null)
			{
				_getLatestCoroutine = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(GetLatestScores());
			}
		}

		private void OnDebugModeChanged()
		{
			Initialise();
		}

		public void LogProjectView()
		{
			if (_app?.Metagame?.CollaborativeMetagameData != null)
			{
				_app.Metagame.CollaborativeMetagameData.LogLastGlobalView();
				OnProjectViewed.InvokeSafe();
			}
		}

		private IEnumerator GetLatestScores()
		{
			_elapsedTime = 0f;
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				yield break;
			}
			UnityWebRequest completedProjectsWww = UnityWebRequest.Get("https://cdn.assets.twopointstudios.com/collaborative/gpcl.rdf");
			yield return completedProjectsWww.SendWebRequest();
			ProcessCompletedProjectDownloadResults(completedProjectsWww);
			UnityWebRequest www = UnityWebRequest.Get(GlobalProjectUrl);
			yield return www.SendWebRequest();
			ProcessDownloadResults(www);
			if (DownloadedProjectDefinition == null)
			{
				Logging.Info("[GetLatestScores] DownloadedProjectDefinition was null");
				if (!IsInitialised)
				{
					IsInitialised = true;
					IsProjectUpToDate = true;
					OnSuperBugManagerInitialised.InvokeSafe();
				}
				yield break;
			}
			Logging.Info("[GetLatestScores] has processed download results");
			yield return null;
			IsProjectUpToDate = false;
			if (!IsInitialised)
			{
				Logging.Info("[GetLatestScores] started to init");
				string leaderboardNodePrefix = (Data.IsDebug ? "SuperBugNode_Debug_" : "SuperBugNode_");
				for (int i = 0; i < Data.Definition.Network.Count; i++)
				{
					yield return LeaderboardHelperWrapper.Instance.FindOrCreateLeaderboard(leaderboardNodePrefix + i);
					CreateOrFindResult createOrFindResult = LeaderboardHelperWrapper.Instance.GetCreateOrFindResult();
					if (!createOrFindResult.found)
					{
						_leaderboardLookup[i] = new SuperBugLeaderboard(leaderboardNodePrefix);
					}
					else
					{
						_leaderboardLookup[i] = createOrFindResult.leaderboard;
					}
				}
				IsInitialised = true;
				OnSuperBugManagerInitialised.InvokeSafe();
			}
			_currentNodeSearchQueue.Clear();
			_currentNodeSearchQueue.Enqueue(0);
			while (_currentNodeSearchQueue.Count > 0)
			{
				int i = _currentNodeSearchQueue.Dequeue();
				SuperBugNode superBugNode = Data.Definition.Network[i];
				int score = 0;
				if (Data.NodeCompletionData.TryGetValue(i, out score) && score >= superBugNode.CompletionsRequired)
				{
					List<int> children = Data.Definition.Network[i].Children;
					for (int j = 0; j < children.Count; j++)
					{
						_currentNodeSearchQueue.Enqueue(children[j]);
					}
					continue;
				}
				SuperBugLeaderboard leaderboardItem = _leaderboardLookup[i];
				yield return LeaderboardHelperWrapper.Instance.GetEntryCount(leaderboardItem);
				score = LeaderboardHelperWrapper.Instance.GetEntryCountResult().count + superBugNode.ProgressBoost;
				if (Data.NodeCompletionData.TryGetValue(i, out var value))
				{
					score = Mathf.Max(score, value);
				}
				Data.NodeCompletionData[i] = score;
				yield return LeaderboardHelperWrapper.Instance.DownloadLeaderboardEntryForLocalUser(leaderboardItem);
				if (LeaderboardHelperWrapper.Instance.GetDownloadEntryResult().hasEntry)
				{
					Data.NodeCompletedByLocalPlayer[i] = true;
				}
				if (score >= superBugNode.CompletionsRequired)
				{
					List<int> children2 = Data.Definition.Network[i].Children;
					for (int k = 0; k < children2.Count; k++)
					{
						_currentNodeSearchQueue.Enqueue(children2[k]);
					}
				}
			}
			IsProjectUpToDate = true;
			OnCompletionDataReceived.InvokeSafe();
			_getLatestCoroutine = null;
		}

		private void ProcessCompletedProjectDownloadResults(UnityWebRequest wwwRequest)
		{
			if (wwwRequest == null || !wwwRequest.error.IsNullOrEmpty())
			{
				return;
			}
			_completionList.Clear();
			string[] array = wwwRequest.downloadHandler.text.Split('\n');
			for (int i = 0; i < array.Length; i++)
			{
				if (int.TryParse(array[i], out var result))
				{
					_completionList.Add(result);
				}
			}
			CollaborativePortfolioData collaborativePortfolioData = _app?.CollaborativePortfolio?.PortfolioDataController?.PortfolioData;
			if (collaborativePortfolioData != null && collaborativePortfolioData.ActiveObjective is SuperBugObjective superBugObjective && _completionList.Contains(superBugObjective.SuperBugID))
			{
				_app.CollaborativePortfolio.PortfolioDataController.SetActiveObjective(null);
			}
		}

		private void ProcessDownloadResults(UnityWebRequest wwwRequest)
		{
			Error = ErrorCode.NoError;
			SuperBugOnlineInfo superBugOnlineInfo = null;
			if (wwwRequest != null && superBugOnlineInfo == null)
			{
				if (wwwRequest.error.IsNullOrEmpty())
				{
					try
					{
						superBugOnlineInfo = MessagePackSerializer.Deserialize<SuperBugOnlineInfo>(wwwRequest.downloadHandler.data);
					}
					catch (Exception)
					{
						Error = ErrorCode.FileDoesNotDeserialize;
						superBugOnlineInfo = null;
						Logging.Warning("[GetLatestScores] RB: We could not deserialize the global project file from the www request.");
					}
				}
				else if (wwwRequest.error.Contains("404 Not Found"))
				{
					Error = ErrorCode.FileNotFound;
					Logging.Info("[GetLatestScores] RB: Checked for Global Project.  We can't find one.  This is fine if we haven't got one set in the cloud.");
				}
				else
				{
					Error = ErrorCode.FileWWWRequestError;
					Logging.Warning("[GetLatestScores] RB: We received an error from the www request.  Here's the message - " + wwwRequest.error);
				}
			}
			if (superBugOnlineInfo == null || Error == ErrorCode.FileDoesNotDeserialize || Error == ErrorCode.FileNotFound || Error == ErrorCode.FileWWWRequestError)
			{
				DownloadedProjectDefinition = null;
				return;
			}
			SuperBugDefinition superBugDefinition = SuperBugDefinition.Create(superBugOnlineInfo, _app);
			if (superBugDefinition == null)
			{
				Error = ErrorCode.NoError;
				return;
			}
			if (_completionList.Contains(superBugDefinition.SuperBugID))
			{
				Error = ErrorCode.NoError;
				return;
			}
			DownloadedProjectDefinition = superBugDefinition;
			if (DownloadedProjectDefinition != null && (Data?.Definition == null || superBugOnlineInfo.SuperBugID != Data?.Definition?.SuperBugID))
			{
				Data = new SuperBugData(DownloadedProjectDefinition, IsDebug);
				Initialise();
				OnNewSuperBugDefinitionDownloaded.InvokeSafe(DownloadedProjectDefinition);
			}
			else if (Data != null)
			{
				Data.UpdateDefinition(DownloadedProjectDefinition);
				OnNewSuperBugDefinitionDownloaded.InvokeSafe(DownloadedProjectDefinition);
			}
			Error = ErrorCode.NoError;
		}

		public void OnSuperBugObjectiveComplete(int superBugID, int nodeID, Objective.CompletionType completionType)
		{
			if (Data != null)
			{
				Data.OnSuperBugObjectiveComplete(superBugID, nodeID, completionType);
			}
		}

		public bool IsProjectFinished(int superBugId)
		{
			return _completionList.Contains(superBugId);
		}

		private ConsoleCommandResult Debug_ForceGetGlobalProjectData(string[] args)
		{
			ForceGetLatest();
			return ConsoleCommandResult.Succeeded();
		}
	}
}
