#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TH20.Analytics;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class CollaborativePortfolio : MustCallDestroy
	{
		private const PlatformFeatureSupport.FeatureType _onlineFeatureRequired = PlatformFeatureSupport.FeatureType.CollaborativeProject;

		public Action OnBeginLatestDataGather;

		public Action OnLatestDataGathered;

		public Action OnPortfolioInitialised;

		public Action<EOnlineResult> OnPortfolioInitialisationFailed;

		public Action OnPortfolioInvitesUpdated;

		public List<CollaborativeProject> ActiveProjectSlots;

		public List<CollaborativeProjectData> ProjectsInvitedTo;

		private CollaborativePortfolioDataController _portfolioDataController;

		private CollaborativeAsyncOperationHandler _asyncOperationHandler;

		private FileDownloadHelper _fileDownloadHelper;

		private Coroutine _getLatestDataCoroutine;

		private float _timeTillNextGet;

		private bool _initialised;

		private bool _isUpdatingInvites;

		private Coroutine _getLatestInvitesCoroutine;

		private List<OnlinePlayerID> _blockList = new List<OnlinePlayerID>();

		private List<OnlinePlayerID> _additionalInvites = new List<OnlinePlayerID>();

		private App _app;

		private bool _isDebugUnlock;

		public const string PortfolioFileName = "CollaborativePortfolioData";

		private const float kGetLatestPeriod = 30f;

		public CollaborativePortfolioDataController PortfolioDataController => _portfolioDataController;

		public CollaborativeAsyncOperationHandler AsyncOperationHandler => _asyncOperationHandler;

		public MetagameObjective ActiveObjective
		{
			get
			{
				if (PortfolioDataController == null)
				{
					return null;
				}
				return PortfolioDataController.ActiveObjective;
			}
		}

		public bool HasData => PortfolioDataController != null;

		public bool IsGatheringLatestData => _getLatestDataCoroutine != null;

		public bool DoesPeriodicGetLatest { get; set; }

		public CollaborativeProjectList CollaborativeProjectList { get; private set; }

		public bool IsDebugUnlock => _isDebugUnlock;

		public bool DebugAllNodesDiscovered { get; private set; }

		public bool DebugAllNodesCompleted { get; private set; }

		public CollaborativePortfolio(App app)
		{
			_app = app;
			CollaborativeProjectList = _app.CollaborativeProjectList;
			_initialised = false;
			Initialise();
			OSManager.OnUserChanged = (Action)Delegate.Combine(OSManager.OnUserChanged, new Action(OnUserChanged));
			OnlineManager.RegisterOnServerConnectionChanged(OnServerConnectionChanged);
		}

		private void OnUserChanged()
		{
			Refresh();
		}

		private void OnServerConnectionChanged(bool connectionStatus)
		{
			Refresh();
		}

		public void RestoreFromSave(App app)
		{
			_app = app;
			_initialised = false;
			CollaborativeProjectList = _app.CollaborativeProjectList;
			StopGettingLatest();
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				Initialise();
			}
		}

		public void StopGettingLatest()
		{
			if (_getLatestDataCoroutine != null)
			{
				OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_getLatestDataCoroutine);
				_getLatestDataCoroutine = null;
			}
			if (_isUpdatingInvites)
			{
				if (_getLatestInvitesCoroutine != null)
				{
					OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_getLatestInvitesCoroutine);
					_getLatestInvitesCoroutine = null;
				}
				_isUpdatingInvites = false;
			}
			if (_portfolioDataController != null)
			{
				_portfolioDataController.Destroy();
				_portfolioDataController = null;
			}
			_fileDownloadHelper?.Reset();
		}

		private void Initialise()
		{
			_initialised = true;
			ActiveProjectSlots = new List<CollaborativeProject>();
			ProjectsInvitedTo = new List<CollaborativeProjectData>();
			if (_fileDownloadHelper == null)
			{
				_fileDownloadHelper = new FileDownloadHelper();
			}
			else
			{
				_fileDownloadHelper.Reset();
			}
			Refresh();
			if (_asyncOperationHandler == null)
			{
				_asyncOperationHandler = new CollaborativeAsyncOperationHandler(this);
			}
			ConsoleCommandsDatabase.RegisterCommand("DeleteCollaborativeProjectFiles", "Deletes the remote storage for your collaborative projects", "DeleteCollaborativeProjectFiles", Debug_DeleteCollaborativeProjectFiles);
			ConsoleCommandsDatabase.RegisterCommand("AbandonCollaborativeObjective", "Abandons current collaborative objective if there is one", "AbandonCollaborativeObjective", Debug_AbandonCollaborativeObjectives);
			ConsoleCommandsDatabase.RegisterCommand("UnlockAllCollaborativeProjects", "Unlocks all the collaborative projects", "UnlockAllCollaborativeProjects", Debug_UnlockAllCollaborativeProjects);
			ConsoleCommandsDatabase.RegisterCommand("SaveCollaborativeProjectsLocally", "Saves the current downloaded collaborative project to a file", "SaveCollaborativeProjectsLocally", Debug_SaveCollaborativeProjectsLocally);
			ConsoleCommandsDatabase.RegisterCommand("DownloadCollaborativeData", "Download collaborative data for a steam ID", "DownloadCollaborativeData <SteamID>", Debug_DownloadCollaborativeData);
			ConsoleCommandsDatabase.RegisterCommand("ToggleDebugAllCollaborativeDiscovered", "Shows all nodes in graph as discovered", "ToggleDebugAllCollaborativeDiscovered", Debug_ToggleDebugAllCollaborativeDiscovered);
			ConsoleCommandsDatabase.RegisterCommand("ToggleDebugAllCollaborativeCompleted", "Shows all nodes in graph as completed", "ToggleDebugAllCollaborativeCompleted", Debug_ToggleDebugAllCollaborativeCompleted);
			ConsoleCommandsDatabase.RegisterCommand("ToggleCollaborativeRewards", "Gives all collaborative rewards", "ToggleCollaborativeRewards", Debug_ToggleCollaborativeRewards);
			ConsoleCommandsDatabase.RegisterCommand("BlockPlayerData", "Blocks a player's data from coming in so we can test things", "BlockPlayerData (SteamID)", Debug_BlockPlayerData);
		}

		private void Refresh()
		{
			_timeTillNextGet = 0f;
			if (_asyncOperationHandler != null)
			{
				_asyncOperationHandler.Destroy();
			}
			_asyncOperationHandler = new CollaborativeAsyncOperationHandler(this);
			if (OnlineManager.IsInitializedAndLoggedOn() && OnlineManager.IsConnected() && !IsGatheringLatestData && !_fileDownloadHelper.IsDownloading)
			{
				RequestGatherData();
			}
		}

		public void SetMetagameReference(Metagame metagame)
		{
			if (ActiveObjective != null)
			{
				ActiveObjective.SetMetagame(metagame);
			}
		}

		public override void Destroy()
		{
			if (_initialised)
			{
				if (PortfolioDataController != null)
				{
					PortfolioDataController.Destroy();
				}
				if (_fileDownloadHelper != null)
				{
					_fileDownloadHelper.Destroy();
				}
				if (_asyncOperationHandler != null)
				{
					_asyncOperationHandler.Destroy();
				}
				ConsoleCommandsDatabase.UnRegisterCommand("DeleteCollaborativeProjectFiles");
				ConsoleCommandsDatabase.UnRegisterCommand("AbandonCollaborativeObjective");
				ConsoleCommandsDatabase.UnRegisterCommand("UnlockAllCollaborativeProjects");
				ConsoleCommandsDatabase.UnRegisterCommand("SaveCollaborativeProjectsLocally");
				ConsoleCommandsDatabase.UnRegisterCommand("DownloadCollaborativeData");
				ConsoleCommandsDatabase.UnRegisterCommand("ToggleDebugAllCollaborativeDiscovered");
				ConsoleCommandsDatabase.UnRegisterCommand("ToggleDebugAllCollaborativeCompleted");
				ConsoleCommandsDatabase.UnRegisterCommand("ToggleCollaborativeRewards");
				_initialised = false;
			}
			OSManager.OnUserChanged = (Action)Delegate.Remove(OSManager.OnUserChanged, new Action(OnUserChanged));
			OnlineManager.UnregisterOnServerConnectionChanged(OnServerConnectionChanged);
			base.Destroy();
		}

		public void Update(float timeDelta, float unscaledTimeDelta)
		{
			if (PortfolioDataController != null)
			{
				PortfolioDataController.Update(timeDelta, unscaledTimeDelta);
			}
			if (DoesPeriodicGetLatest && !_asyncOperationHandler.ContainsOperationType<CollaborativeAsyncOperationGatherData>() && !_isUpdatingInvites)
			{
				_timeTillNextGet -= Time.unscaledDeltaTime;
				if (_timeTillNextGet <= 0f)
				{
					_timeTillNextGet = 30f;
					RequestGatherData();
				}
			}
			if (_asyncOperationHandler != null)
			{
				_asyncOperationHandler.Update();
			}
		}

		public CollaborativeProject GetProject(Guid projectID)
		{
			if (!PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				return null;
			}
			for (int i = 0; i < ActiveProjectSlots.Count; i++)
			{
				if (projectID == ActiveProjectSlots[i].ProjectID)
				{
					return ActiveProjectSlots[i];
				}
			}
			return null;
		}

		public CollaborativeProjectData GetInviteData(Guid projectID)
		{
			if (!PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				return null;
			}
			for (int i = 0; i < ProjectsInvitedTo.Count; i++)
			{
				if (ProjectsInvitedTo[i].ProjectID == projectID)
				{
					return ProjectsInvitedTo[i];
				}
			}
			return null;
		}

		public void LogLastView(Guid? projectID)
		{
			if (_app.Metagame != null && PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				_app.Metagame.CollaborativeMetagameData.LogLastView(projectID);
			}
		}

		public bool HasProjectGotNewData(CollaborativeProject project)
		{
			if (_app.Metagame == null || !PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				return false;
			}
			return _app.Metagame.CollaborativeMetagameData.HasProjectGotNewData(project);
		}

		public uint GetLastViewTimestamp(Guid projectID)
		{
			if (_app.Metagame == null || !PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				return 0u;
			}
			return _app.Metagame.CollaborativeMetagameData.GetLastViewTimestamp(projectID);
		}

		public bool HasPortfolioGotNewData()
		{
			if (_app == null)
			{
				Logging.Error("Null _App, RestoreFromSave should been called via OnOnlineStateEstablished ");
				return false;
			}
			if (_app.Metagame == null || !PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				return false;
			}
			return _app.Metagame.CollaborativeMetagameData.HasPortfolioGotNewData();
		}

		public void GatherLatestData()
		{
			if (PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject) && _getLatestDataCoroutine == null)
			{
				_getLatestDataCoroutine = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(GetLatestDataCoroutine());
			}
		}

		public void RequestGatherData()
		{
			if (PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				CollaborativeAsyncOperationGatherData operation = new CollaborativeAsyncOperationGatherData(this);
				_asyncOperationHandler.EnqueueOperation(operation);
			}
		}

		public void RequestUpdateInviteData()
		{
			if (_isUpdatingInvites && _getLatestInvitesCoroutine != null)
			{
				OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_getLatestInvitesCoroutine);
				_getLatestInvitesCoroutine = null;
			}
			_isUpdatingInvites = true;
			_getLatestInvitesCoroutine = OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(UpdateInvites());
		}

		public void RequestCreateNewProject(CollaborativeProjectDefinition projectDefinition)
		{
			if (PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				CollaborativeAsyncOperationCreateProject operation = new CollaborativeAsyncOperationCreateProject(this, projectDefinition);
				_asyncOperationHandler.EnqueueOperation(operation);
			}
		}

		public void RequestJoinProject(Guid projectId)
		{
			if (PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				CollaborativeAsyncOperationJoinProject operation = new CollaborativeAsyncOperationJoinProject(this, projectId);
				_asyncOperationHandler.EnqueueOperation(operation);
			}
		}

		public void RequestAbandonProject(Guid projectId)
		{
			if (PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				CollaborativeAsyncOperationAbandonProject operation = new CollaborativeAsyncOperationAbandonProject(this, projectId);
				_asyncOperationHandler.EnqueueOperation(operation);
			}
		}

		public Guid? CreateCollaborativeProjectInternal(CollaborativeProjectDefinition projectDefinition)
		{
			if (!CanCreateNewCollaborativeProject())
			{
				return null;
			}
			CollaborativeProject collaborativeProject = CollaborativeProject.CreateNewProject(this, projectDefinition);
			ActiveProjectSlots.Add(collaborativeProject);
			PortfolioDataController.AddProjectData(collaborativeProject.LocalPlayerData);
			return collaborativeProject.ProjectID;
		}

		public bool CanCreateNewCollaborativeProject()
		{
			if (!PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				return false;
			}
			if (PortfolioDataController == null || PortfolioDataController.IsUploading)
			{
				return false;
			}
			if (ActiveProjectSlots.Count >= CollaborativePortfolioDataController.MaxCollaborativeProjects)
			{
				return false;
			}
			return true;
		}

		public void AbandonCollaborativeProjectInternal(Guid projectID)
		{
			if (!PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				return;
			}
			for (int i = 0; i < ActiveProjectSlots.Count; i++)
			{
				if (!(ActiveProjectSlots[i].ProjectID != projectID))
				{
					ActiveProjectSlots.RemoveAt(i);
					break;
				}
			}
			if (PortfolioDataController != null)
			{
				RemoveInvite(projectID);
				PortfolioDataController.RemoveProjectData(projectID);
			}
		}

		public void RemoveInvite(Guid projectID)
		{
			if (PortfolioDataController != null)
			{
				PortfolioDataController.ConsumeInvite(projectID);
			}
			CollaborativeProjectData inviteData = GetInviteData(projectID);
			if (inviteData != null)
			{
				ProjectsInvitedTo.Remove(inviteData);
			}
			OnPortfolioInvitesUpdated.InvokeSafe();
		}

		public void JoinCollaborativeProjectInternal(Guid projectId)
		{
			if (!PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				return;
			}
			for (int i = 0; i < ProjectsInvitedTo.Count; i++)
			{
				CollaborativeProjectData collaborativeProjectData = ProjectsInvitedTo[i];
				if (!(collaborativeProjectData.ProjectID != projectId))
				{
					CollaborativeProject collaborativeProject = CollaborativeProject.CreateProjectFromOtherLeaderData(this, collaborativeProjectData);
					ActiveProjectSlots.Add(collaborativeProject);
					PortfolioDataController?.AddProjectData(collaborativeProject.LocalPlayerData);
				}
			}
		}

		public bool IsResearchProjectTypeCompleted(CollaborativeProjectDefinition projectDefinition)
		{
			if (!PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				return false;
			}
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return false;
			}
			if (PortfolioDataController == null)
			{
				return false;
			}
			return PortfolioDataController.IsProjectTypeCompleted(projectDefinition);
		}

		public bool IsSuperBugVictoryAchieved(SuperBugRequirement requirement)
		{
			if (_app.UserProfile.HasSuperBugReward(requirement.SuperBugID, requirement.VictoryType))
			{
				return true;
			}
			if (!PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				return false;
			}
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				return false;
			}
			if (PortfolioDataController == null)
			{
				return false;
			}
			if (requirement == null)
			{
				return true;
			}
			return PortfolioDataController.IsSuperBugVictoryAchieved(requirement.SuperBugID, requirement.VictoryType);
		}

		public void SetActiveObjective(MetagameObjective metagameObjective)
		{
			if (PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				AbandonActiveObjective();
				if (metagameObjective != null && !metagameObjective.Definition.IsTimed)
				{
					metagameObjective.Start();
				}
				PortfolioDataController?.SetActiveObjective(metagameObjective);
			}
		}

		public void AbandonActiveObjective()
		{
			if (PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject))
			{
				PortfolioDataController?.SetActiveObjective(null);
			}
		}

		public void OnActiveObjectiveCompleted(Objective objective, Objective.CompletionType completionType)
		{
			if (!PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject) || PortfolioDataController == null || objective != ActiveObjective)
			{
				return;
			}
			PortfolioDataController.OnActiveObjectiveCompleted(completionType);
			if (objective is ResearchProjectObjective researchProjectObjective)
			{
				CollaborativeProject project = GetProject(researchProjectObjective.ProjectID);
				if (project != null && project.IsProjectCompleted())
				{
					PortfolioDataController.AddCompletedProjectToList(project);
					LogProjectCompleteEventWithAnalytics(project);
				}
			}
			if (completionType == Objective.CompletionType.Successful)
			{
				LogNodeCompleteEventWithAnalytics(objective as MetagameObjective);
			}
		}

		public void OnActiveObjectiveUpdated(bool force = false)
		{
			if (PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject) && PortfolioDataController != null)
			{
				PortfolioDataController.OnActiveObjectiveUpdated(force);
			}
		}

		private IEnumerator GetLatestDataCoroutine()
		{
			if (PortfolioDataController != null && _portfolioDataController.PortfolioData.OnlinePlayerID != OnlineManager.GetLocalPlayerID())
			{
				_portfolioDataController.Destroy();
				_portfolioDataController = null;
			}
			if (_isUpdatingInvites)
			{
				OnlineManager.BehaviourToRunCoroutinesOn.StopCoroutine(_getLatestInvitesCoroutine);
				_fileDownloadHelper?.Reset();
				_getLatestInvitesCoroutine = null;
				_isUpdatingInvites = false;
			}
			if (PortfolioDataController == null)
			{
				yield return InitialiseWithPlayerDataCoroutine();
			}
			yield return GetLatestDataForActiveProjectsCoroutine();
			_getLatestDataCoroutine = null;
		}

		private IEnumerator InitialiseWithPlayerDataCoroutine()
		{
			while (_app.Metagame == null)
			{
				yield return null;
			}
			_ = OnlineManager.DataFiles;
			OnlinePlayerInfo playerInfo = null;
			while (playerInfo == null)
			{
				playerInfo = OnlineManager.GetPlayerInfo(OnlineManager.GetLocalPlayerID());
				yield return null;
			}
			_fileDownloadHelper.Download(OnlineManager.DataFiles.GetFriendDataFile(OnlineFileClass.CollaborativePortfolio, "CollaborativePortfolioData", OnlineManager.GetLocalPlayerID(), createIfNone: true));
			while (_fileDownloadHelper.IsDownloading)
			{
				yield return null;
			}
			yield return new WaitForSecondsRealtime(3f);
			using (List<BaseOnlineDataFile>.Enumerator enumerator = _fileDownloadHelper.FailedDownloadResults.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					BaseOnlineDataFile current = enumerator.Current;
					OnPortfolioInitialisationFailed.InvokeSafe(current.GetLastOnlineResult());
					Logging.Warning("Failed to download local player's collaborative portfolio.");
					yield break;
				}
			}
			foreach (BaseOnlineDataFile successfulDownloadResult in _fileDownloadHelper.SuccessfulDownloadResults)
			{
				Logging.Info("[InitialiseWithPlayerDataCoroutine] handle success");
				if (successfulDownloadResult.GetLastDownloadResult() == DownloadResult.FileNotFound)
				{
					continue;
				}
				CollaborativePortfolioData obj;
				try
				{
					EOnlineResult eOnlineResult = successfulDownloadResult.Deserialize<CollaborativePortfolioData>(out obj);
					if (eOnlineResult != EOnlineResult.EOnlineResultOk)
					{
						OnPortfolioInitialisationFailed.InvokeSafe(eOnlineResult);
						Logging.Warning("RB: Error deserializing the local player's downloaded collaborative portfolio.");
						yield break;
					}
				}
				catch
				{
					OnPortfolioInitialisationFailed.InvokeSafe(EOnlineResult.EOnlineResultFailDeserializingReasonUnknown);
					Logging.Warning("RB: Error deserializing the local player's downloaded collaborative portfolio - for an unknown reason.");
					continue;
				}
				if (obj.OnlinePlayerID != OnlineManager.GetLocalPlayerID())
				{
					continue;
				}
				try
				{
					_portfolioDataController = new CollaborativePortfolioDataController(obj, _app, _app.SuperBugManager, OnlineManager.DataFiles.GetLocalPlayerDataFile(OnlineFileClass.CollaborativePortfolio, "CollaborativePortfolioData", createIfNone: true), _app.AnalyticsManager);
					if (_portfolioDataController == null)
					{
						throw new Exception();
					}
				}
				catch
				{
					OnPortfolioInitialisationFailed.InvokeSafe(EOnlineResult.EOnlineResultFailDeserializingReasonUnknown);
					Logging.Warning(LogChannels.Online, "RB: Error creating CollaborativePortfolioDataController from downloaded data - for an unknown reason.");
					continue;
				}
				for (int num = obj.ProjectDataList.Count - 1; num >= 0; num--)
				{
					if (obj.ProjectDataList[num].OnlinePlayerID != OnlineManager.GetLocalPlayerID())
					{
						obj.ProjectDataList.RemoveAt(num);
					}
				}
				for (int i = 0; i < obj.ProjectDataList.Count; i++)
				{
					CollaborativeProject collaborativeProject = CollaborativeProject.CreateProjectFromLocalPlayerData(this, obj.ProjectDataList[i]);
					if (collaborativeProject != null)
					{
						ActiveProjectSlots.Add(collaborativeProject);
					}
				}
			}
			if (_portfolioDataController == null)
			{
				CollaborativePortfolioData portfolioData = new CollaborativePortfolioData();
				_portfolioDataController = new CollaborativePortfolioDataController(portfolioData, _app, _app.SuperBugManager, OnlineManager.DataFiles.GetLocalPlayerDataFile(OnlineFileClass.CollaborativePortfolio, "CollaborativePortfolioData", createIfNone: true), _app.AnalyticsManager);
			}
			Logging.Info("Successfully created the CollaborativePortfolioDataController.");
			OnPortfolioInitialised.InvokeSafe();
		}

		private IEnumerator UpdateInvites()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				_isUpdatingInvites = false;
				yield break;
			}
			yield return null;
			_fileDownloadHelper.Download(OnlineManager.DataFiles.GatherDataFiles(OnlineFileClass.CollaborativePortfolio, "CollaborativePortfolioData", _additionalInvites, createIfNone: true).Values.ToList());
			while (_fileDownloadHelper.IsDownloading)
			{
				yield return null;
			}
			List<Guid> invitesList = new List<Guid>();
			List<Guid> allProjectsList = new List<Guid>();
			foreach (BaseOnlineDataFile successfulDownloadResult in _fileDownloadHelper.SuccessfulDownloadResults)
			{
				if (successfulDownloadResult.GetLastDownloadResult() == DownloadResult.FileNotFound)
				{
					continue;
				}
				CollaborativePortfolioData data;
				try
				{
					if (successfulDownloadResult.Deserialize<CollaborativePortfolioData>(out data) != EOnlineResult.EOnlineResultOk)
					{
						for (int i = 0; i < ActiveProjectSlots.Count; i++)
						{
							CollaborativeProject collaborativeProject = ActiveProjectSlots[i];
							collaborativeProject?.SetDownloadErrorForPlayerData(collaborativeProject.LeaderOnlinePlayerID);
						}
						continue;
					}
				}
				catch
				{
					for (int j = 0; j < ActiveProjectSlots.Count; j++)
					{
						CollaborativeProject collaborativeProject2 = ActiveProjectSlots[j];
						collaborativeProject2?.SetDownloadErrorForPlayerData(collaborativeProject2.LeaderOnlinePlayerID);
					}
					continue;
				}
				if (data.OnlinePlayerID == OnlineManager.GetLocalPlayerID() || data.OnlinePlayerID != successfulDownloadResult.GetPlayerID())
				{
					continue;
				}
				for (int k = 0; k < ActiveProjectSlots.Count; k++)
				{
					CollaborativeProject collaborativeProject3 = ActiveProjectSlots[k];
					if (collaborativeProject3 != null && data.IsProjectCompleted(collaborativeProject3.ProjectID))
					{
						PortfolioDataController?.PortfolioData.AddProjectCompleteTag(collaborativeProject3.ProjectID);
					}
				}
				foreach (KeyValuePair<Guid, uint> rejectedInvite in data.RejectedInvites)
				{
					CollaborativeProject project = GetProject(rejectedInvite.Key);
					if (project != null)
					{
						uint value = rejectedInvite.Value;
						project.UpdateInviteRejectionList(data.OnlinePlayerID, value);
						if (project.LocalPlayerData == project.LeaderProjectData && project.HasCollaboratorRejectedLatestInvite(data.OnlinePlayerID))
						{
							project.KickPlayer(data.OnlinePlayerID, immediateUpload: false);
						}
					}
				}
				foreach (CollaborativeProjectData projectData in data.ProjectDataList)
				{
					allProjectsList.Add(projectData.ProjectID);
					bool flag = false;
					for (int l = 0; l < ActiveProjectSlots.Count; l++)
					{
						CollaborativeProject collaborativeProject4 = ActiveProjectSlots[l];
						if (collaborativeProject4 != null && !(collaborativeProject4.ProjectID != projectData.ProjectID))
						{
							if (projectData.IsLeaderData())
							{
								flag = true;
								break;
							}
							if (collaborativeProject4.LeaderProjectData != null && collaborativeProject4.LeaderProjectData.Collaborators.ContainsKey(data.OnlinePlayerID))
							{
								collaborativeProject4.UpdateProjectData(projectData);
								flag = true;
								break;
							}
						}
					}
					if (OnlineManager.IsUserBlockingInvites(projectData.LeaderOnlinePlayerID) || flag || !projectData.IsLeaderData() || !projectData.Collaborators.ContainsKey(OnlineManager.GetLocalPlayerID()))
					{
						continue;
					}
					invitesList.Add(projectData.ProjectID);
					if (PortfolioDataController != null && !PortfolioDataController.HasConsumedInvite(projectData))
					{
						List<OnlinePlayerID> ids = projectData.Collaborators.Keys.Where((OnlinePlayerID collaborator) => !OnlineManager.GetPlayerInfoExists(collaborator)).ToList();
						yield return OnlineManager.RequestPlayerInfo(ids);
						ProjectsInvitedTo.Add(projectData);
					}
				}
				data = null;
			}
			if (PortfolioDataController != null)
			{
				List<Guid> list = new List<Guid>();
				foreach (KeyValuePair<Guid, uint> rejectedInvite2 in PortfolioDataController.PortfolioData.RejectedInvites)
				{
					if (!allProjectsList.Contains(rejectedInvite2.Key))
					{
						list.Add(rejectedInvite2.Key);
					}
				}
				PortfolioDataController.ClearInviteRecord(list);
			}
			OnPortfolioInvitesUpdated.InvokeSafe();
			_isUpdatingInvites = false;
		}

		private IEnumerator GetLatestDataForActiveProjectsCoroutine()
		{
			ProjectsInvitedTo.Clear();
			List<OnlinePlayerID> leaderList = new List<OnlinePlayerID>();
			List<OnlinePlayerID> nonFriendList = new List<OnlinePlayerID>();
			for (int i = 0; i < ActiveProjectSlots.Count; i++)
			{
				if (ActiveProjectSlots[i] == null)
				{
					continue;
				}
				foreach (KeyValuePair<OnlinePlayerID, CollaborativeProjectDataBase> projectDatum in ActiveProjectSlots[i].ProjectData)
				{
					if (!(projectDatum.Key == OnlineManager.GetLocalPlayerID()) && projectDatum.Value is CollaborativeProjectData collaborativeProjectData)
					{
						collaborativeProjectData.IsDeprecated = true;
					}
				}
				if (ActiveProjectSlots[i].LeaderOnlinePlayerID != OnlineManager.GetLocalPlayerID())
				{
					leaderList.AddUnique(ActiveProjectSlots[i].LeaderOnlinePlayerID);
				}
				if (ActiveProjectSlots[i].LeaderProjectData == null)
				{
					continue;
				}
				foreach (KeyValuePair<OnlinePlayerID, Guid> collaborator in ActiveProjectSlots[i].LeaderProjectData.Collaborators)
				{
					if (!OnlineManager.GetPlayerInfoExists(collaborator.Key))
					{
						nonFriendList.AddUnique(collaborator.Key);
					}
				}
			}
			List<OnlinePlayerID> ids = leaderList.Where((OnlinePlayerID leader) => !OnlineManager.GetPlayerInfoExists(leader)).ToList();
			yield return OnlineManager.RequestPlayerInfo(ids);
			yield return OnlineManager.RequestPlayerInfo(nonFriendList);
			_fileDownloadHelper.Download(OnlineManager.DataFiles.GatherDataFiles(OnlineFileClass.CollaborativePortfolio, "CollaborativePortfolioData", leaderList, createIfNone: true).Values.ToList());
			while (_fileDownloadHelper.IsDownloading)
			{
				yield return null;
			}
			List<Guid> allProjectsList = new List<Guid>();
			CollaborativePortfolioData data;
			foreach (BaseOnlineDataFile file in _fileDownloadHelper.SuccessfulDownloadResults)
			{
				if (file.GetLastDownloadResult() == DownloadResult.FileNotFound)
				{
					for (int num = 0; num < ActiveProjectSlots.Count; num++)
					{
						CollaborativeProject collaborativeProject = ActiveProjectSlots[num];
						if (collaborativeProject != null && collaborativeProject.LeaderOnlinePlayerID == file.GetPlayerID())
						{
							collaborativeProject.Status = CollaborativeProject.ProjectStatus.LeaderAbandoned;
						}
					}
					continue;
				}
				try
				{
					EOnlineResult eOnlineResult = file.Deserialize<CollaborativePortfolioData>(out data);
					if (eOnlineResult != EOnlineResult.EOnlineResultOk)
					{
						for (int num2 = 0; num2 < ActiveProjectSlots.Count; num2++)
						{
							CollaborativeProject collaborativeProject2 = ActiveProjectSlots[num2];
							if (collaborativeProject2 != null && !(file.GetPlayerID() != collaborativeProject2.LeaderOnlinePlayerID))
							{
								collaborativeProject2.SetDownloadErrorForPlayerData(collaborativeProject2.LeaderOnlinePlayerID);
							}
						}
						if (eOnlineResult != EOnlineResult.EOnlineResultOk)
						{
							continue;
						}
					}
				}
				catch
				{
					for (int num3 = 0; num3 < ActiveProjectSlots.Count; num3++)
					{
						CollaborativeProject collaborativeProject3 = ActiveProjectSlots[num3];
						if (collaborativeProject3 != null && !(file.GetPlayerID() != collaborativeProject3.LeaderOnlinePlayerID))
						{
							collaborativeProject3.SetDownloadErrorForPlayerData(collaborativeProject3.LeaderOnlinePlayerID);
						}
					}
					continue;
				}
				if (data.OnlinePlayerID == OnlineManager.GetLocalPlayerID() || data.OnlinePlayerID != file.GetPlayerID())
				{
					continue;
				}
				for (int i2 = 0; i2 < ActiveProjectSlots.Count; i2++)
				{
					CollaborativeProject collaborativeProject4 = ActiveProjectSlots[i2];
					if (collaborativeProject4 == null || file.GetPlayerID() != collaborativeProject4.LeaderOnlinePlayerID)
					{
						continue;
					}
					if (data.IsProjectCompleted(collaborativeProject4.ProjectID))
					{
						PortfolioDataController?.PortfolioData.AddProjectCompleteTag(collaborativeProject4.ProjectID);
					}
					CollaborativeProjectData collaborativeProjectData2 = data.GetProjectData(collaborativeProject4.ProjectID);
					if (collaborativeProjectData2 != null && collaborativeProjectData2.Collaborators == null)
					{
						Logging.Info("leaderProjectData.Collaborators was null, abandon project");
						collaborativeProjectData2 = null;
					}
					if (collaborativeProjectData2 == null)
					{
						collaborativeProject4.Status = CollaborativeProject.ProjectStatus.LeaderAbandoned;
					}
					else if (!collaborativeProjectData2.Collaborators.ContainsKey(OnlineManager.GetLocalPlayerID()))
					{
						collaborativeProject4.Status = CollaborativeProject.ProjectStatus.Kicked;
					}
					else
					{
						collaborativeProject4.Status = CollaborativeProject.ProjectStatus.Ready;
					}
					if (collaborativeProjectData2?.Collaborators != null && !_blockList.Contains(data.OnlinePlayerID))
					{
						collaborativeProject4.UpdateProjectData(collaborativeProjectData2);
						List<OnlinePlayerID> ids2 = collaborativeProjectData2.Collaborators.Keys.Where((OnlinePlayerID collaborator) => !OnlineManager.GetPlayerInfoExists(collaborator)).ToList();
						yield return OnlineManager.RequestPlayerInfo(ids2);
					}
				}
				data = null;
			}
			List<OnlinePlayerID> list = new List<OnlinePlayerID>();
			for (int num4 = 0; num4 < ActiveProjectSlots.Count; num4++)
			{
				if (ActiveProjectSlots[num4] == null || ActiveProjectSlots[num4].Status != CollaborativeProject.ProjectStatus.Ready)
				{
					continue;
				}
				CollaborativeProjectData leaderProjectData = ActiveProjectSlots[num4].LeaderProjectData;
				if (leaderProjectData == null)
				{
					continue;
				}
				List<OnlinePlayerID> list2 = null;
				foreach (KeyValuePair<OnlinePlayerID, CollaborativeProjectDataBase> projectDatum2 in ActiveProjectSlots[num4].ProjectData)
				{
					if (!leaderProjectData.Collaborators.ContainsKey(projectDatum2.Key))
					{
						if (list2 == null)
						{
							list2 = new List<OnlinePlayerID>();
						}
						list2.Add(projectDatum2.Key);
					}
				}
				if (list2 != null)
				{
					for (int num5 = 0; num5 < list2.Count; num5++)
					{
						ActiveProjectSlots[num5].RemoveProjectData(list2[num5]);
					}
				}
				foreach (OnlinePlayerID key in leaderProjectData.Collaborators.Keys)
				{
					if (key != OnlinePlayerID.Nil)
					{
						list.AddUnique(key);
					}
				}
			}
			list.AddRange(OnlineManager.GetFriendPlayerIDs());
			list = list.Distinct().ToList();
			list.Remove(OnlineManager.GetLocalPlayerID());
			_additionalInvites.Clear();
			_additionalInvites.AddRange(OnlineManager.GetFriendPlayerIDs());
			for (int num6 = 0; num6 < list.Count; num6++)
			{
				if (_additionalInvites.Contains(list[num6]))
				{
					_additionalInvites.Remove(list[num6]);
				}
			}
			_fileDownloadHelper.Download(OnlineManager.DataFiles.GatherDataFiles(OnlineFileClass.CollaborativePortfolio, "CollaborativePortfolioData", list, createIfNone: true).Values.ToList());
			while (_fileDownloadHelper.IsDownloading)
			{
				yield return null;
			}
			List<Guid> invitesList = new List<Guid>();
			foreach (BaseOnlineDataFile file in _fileDownloadHelper.SuccessfulDownloadResults)
			{
				if (file.GetLastDownloadResult() == DownloadResult.FileNotFound)
				{
					continue;
				}
				try
				{
					if (file.Deserialize<CollaborativePortfolioData>(out data) != EOnlineResult.EOnlineResultOk)
					{
						for (int num7 = 0; num7 < ActiveProjectSlots.Count; num7++)
						{
							CollaborativeProject collaborativeProject5 = ActiveProjectSlots[num7];
							collaborativeProject5?.SetDownloadErrorForPlayerData(collaborativeProject5.LeaderOnlinePlayerID);
						}
						continue;
					}
				}
				catch
				{
					for (int num8 = 0; num8 < ActiveProjectSlots.Count; num8++)
					{
						CollaborativeProject collaborativeProject6 = ActiveProjectSlots[num8];
						collaborativeProject6?.SetDownloadErrorForPlayerData(collaborativeProject6.LeaderOnlinePlayerID);
					}
					continue;
				}
				if (data.OnlinePlayerID == OnlineManager.GetLocalPlayerID())
				{
					continue;
				}
				for (int num9 = 0; num9 < ActiveProjectSlots.Count; num9++)
				{
					CollaborativeProject collaborativeProject7 = ActiveProjectSlots[num9];
					if (collaborativeProject7 != null && data.IsProjectCompleted(collaborativeProject7.ProjectID))
					{
						PortfolioDataController?.PortfolioData.AddProjectCompleteTag(collaborativeProject7.ProjectID);
					}
				}
				foreach (KeyValuePair<Guid, uint> rejectedInvite in data.RejectedInvites)
				{
					CollaborativeProject project = GetProject(rejectedInvite.Key);
					if (project != null)
					{
						uint value = rejectedInvite.Value;
						project.UpdateInviteRejectionList(data.OnlinePlayerID, value);
						if (project.LocalPlayerData == project.LeaderProjectData && project.HasCollaboratorRejectedLatestInvite(data.OnlinePlayerID))
						{
							project.KickPlayer(data.OnlinePlayerID, immediateUpload: false);
						}
					}
				}
				foreach (CollaborativeProjectData projectData in data.ProjectDataList)
				{
					if (projectData.OnlinePlayerID != file.GetPlayerID())
					{
						continue;
					}
					allProjectsList.AddUnique(projectData.ProjectID);
					if (_blockList.Contains(data.OnlinePlayerID))
					{
						continue;
					}
					bool flag = false;
					for (int num10 = 0; num10 < ActiveProjectSlots.Count; num10++)
					{
						CollaborativeProject collaborativeProject8 = ActiveProjectSlots[num10];
						if (collaborativeProject8 != null && !(collaborativeProject8.ProjectID != projectData.ProjectID))
						{
							if (projectData.IsLeaderData())
							{
								flag = true;
								break;
							}
							if (collaborativeProject8.LeaderProjectData != null && collaborativeProject8.LeaderProjectData.Collaborators.ContainsKey(data.OnlinePlayerID))
							{
								collaborativeProject8.UpdateProjectData(projectData);
								flag = true;
								break;
							}
						}
					}
					if (OnlineManager.IsUserBlockingInvites(projectData.LeaderOnlinePlayerID) || flag || !projectData.IsLeaderData() || !projectData.Collaborators.ContainsKey(OnlineManager.GetLocalPlayerID()))
					{
						continue;
					}
					invitesList.Add(projectData.ProjectID);
					if (PortfolioDataController != null && !PortfolioDataController.HasConsumedInvite(projectData))
					{
						List<OnlinePlayerID> ids3 = projectData.Collaborators.Keys.Where((OnlinePlayerID collaborator) => !OnlineManager.GetPlayerInfoExists(collaborator)).ToList();
						yield return OnlineManager.RequestPlayerInfo(ids3);
						ProjectsInvitedTo.Add(projectData);
					}
				}
				data = null;
			}
			if (PortfolioDataController == null)
			{
				yield break;
			}
			List<Guid> list3 = new List<Guid>();
			foreach (KeyValuePair<Guid, uint> rejectedInvite2 in PortfolioDataController.PortfolioData.RejectedInvites)
			{
				if (!allProjectsList.Contains(rejectedInvite2.Key))
				{
					list3.Add(rejectedInvite2.Key);
				}
			}
			PortfolioDataController.ClearInviteRecord(list3);
		}

		private void LogNodeCompleteEventWithAnalytics(MetagameObjective objective)
		{
			ResearchProjectObjective researchProjectObjective = objective as ResearchProjectObjective;
			SuperBugObjective superBugObjective = objective as SuperBugObjective;
			if (researchProjectObjective != null)
			{
				CollaborativeProject project = GetProject(researchProjectObjective.ProjectID);
				if (project != null)
				{
					GameEvent gameEvent = new GameEvent(_app.AnalyticsManager.Config.CollaborativeProjectNodeCompletedInfo).AddCollaborativeProjectNodeHeader(project, _app.Metagame.OnlineMetadataManager);
					_app.AnalyticsManager.RecordEvent(gameEvent);
				}
			}
			else if (superBugObjective != null)
			{
				SuperBugDefinition downloadedProjectDefinition = _app.SuperBugManager.DownloadedProjectDefinition;
				if (downloadedProjectDefinition != null)
				{
					GameEvent gameEvent2 = new GameEvent(_app.AnalyticsManager.Config.SuperBugProjectNodeCompletedInfo).AddSuperBugNodeHeader(downloadedProjectDefinition, this);
					_app.AnalyticsManager.RecordEvent(gameEvent2);
				}
			}
		}

		private void LogProjectCompleteEventWithAnalytics(CollaborativeProject project)
		{
			GameEvent gameEvent = new GameEvent(_app.AnalyticsManager.Config.CollaborativeProjectCompletedInfo).AddCollaborativeProjectCompletedHeader(project, _app.Metagame.OnlineMetadataManager);
			_app.AnalyticsManager.RecordEvent(gameEvent);
		}

		public bool DeleteCollaborativeProjectFiles(Action<BaseOnlineDataFile> deleteCompleteCallback)
		{
			BaseOnlineDataFile localPlayerDataFile = OnlineManager.DataFiles.GetLocalPlayerDataFile(OnlineFileClass.CollaborativePortfolio, "CollaborativePortfolioData", createIfNone: true);
			if (localPlayerDataFile == null)
			{
				return false;
			}
			if (deleteCompleteCallback != null)
			{
				localPlayerDataFile.OnFileDeletionCompleted = (Action<BaseOnlineDataFile>)Delegate.Combine(localPlayerDataFile.OnFileDeletionCompleted, deleteCompleteCallback);
			}
			localPlayerDataFile.Delete();
			return true;
		}

		private ConsoleCommandResult Debug_DeleteCollaborativeProjectFiles(string[] args)
		{
			if (!DeleteCollaborativeProjectFiles(null))
			{
				return ConsoleCommandResult.Failed("Couldn't create file!");
			}
			return ConsoleCommandResult.Succeeded("Succeeded.  You should restart for this to process to complete.");
		}

		private ConsoleCommandResult Debug_AbandonCollaborativeObjectives(string[] args)
		{
			AbandonActiveObjective();
			return ConsoleCommandResult.Succeeded("Succeeded.");
		}

		private ConsoleCommandResult Debug_UnlockAllCollaborativeProjects(string[] args)
		{
			_isDebugUnlock = true;
			return ConsoleCommandResult.Succeeded("Succeeded.");
		}

		private ConsoleCommandResult Debug_SaveCollaborativeProjectsLocally(string[] args)
		{
			if (_portfolioDataController == null)
			{
				return ConsoleCommandResult.Failed("Couldn't create file because we haven't yet downloaded the collaborative portfolio from the cloud.  Please try again later!");
			}
			string contents = SteamHelpers.Serialize(_portfolioDataController.PortfolioData);
			File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "collaborative_portfolio.txt"), contents);
			return ConsoleCommandResult.Succeeded("Succeeded.");
		}

		private ConsoleCommandResult Debug_DownloadCollaborativeData(string[] args)
		{
			if (_portfolioDataController == null)
			{
				return ConsoleCommandResult.Failed("Couldn't download file because we haven't yet initialised!");
			}
			if (args.Length != 1)
			{
				return ConsoleCommandResult.Failed("Missing SteamID parameter");
			}
			OnlinePlayerID onlinePlayerID = new OnlinePlayerID(ulong.Parse(args[0]));
			OnlineManager.BehaviourToRunCoroutinesOn.StartCoroutine(Debug_DownloadCollaborativePortfolioData(onlinePlayerID));
			return ConsoleCommandResult.Succeeded("SteamID found. Attempting to download to desktop.");
		}

		private IEnumerator Debug_DownloadCollaborativePortfolioData(OnlinePlayerID onlinePlayerID)
		{
			_fileDownloadHelper.Download(OnlineManager.DataFiles.GetFriendDataFile(OnlineFileClass.CollaborativePortfolio, "CollaborativePortfolioData", onlinePlayerID, createIfNone: true));
			while (_fileDownloadHelper.IsDownloading)
			{
				yield return null;
			}
			foreach (BaseOnlineDataFile successfulDownloadResult in _fileDownloadHelper.SuccessfulDownloadResults)
			{
				try
				{
					if (successfulDownloadResult.Deserialize<CollaborativePortfolioData>(out var obj) == EOnlineResult.EOnlineResultOk)
					{
						string contents = SteamHelpers.Serialize(obj);
						File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"collaborative_portfolio_{onlinePlayerID}.txt"), contents);
					}
				}
				catch
				{
					break;
				}
			}
		}

		private ConsoleCommandResult Debug_ToggleDebugAllCollaborativeDiscovered(string[] args)
		{
			DebugAllNodesDiscovered = !DebugAllNodesDiscovered;
			return ConsoleCommandResult.Succeeded("DebugAllNodesDiscovered = " + DebugAllNodesDiscovered);
		}

		private ConsoleCommandResult Debug_ToggleDebugAllCollaborativeCompleted(string[] args)
		{
			DebugAllNodesCompleted = !DebugAllNodesCompleted;
			return ConsoleCommandResult.Succeeded("DebugAllNodesCompleted = " + DebugAllNodesCompleted);
		}

		private ConsoleCommandResult Debug_ToggleCollaborativeRewards(string[] args)
		{
			_app.Metagame.GiveAllCollaborativeRewards = !_app.Metagame.GiveAllCollaborativeRewards;
			return ConsoleCommandResult.Succeeded("GiveAllCollaborativeRewards = " + _app.Metagame.GiveAllCollaborativeRewards);
		}

		private ConsoleCommandResult Debug_BlockPlayerData(string[] args)
		{
			if (args.Length != 1)
			{
				return ConsoleCommandResult.Failed("Missing SteamID parameter");
			}
			OnlinePlayerID onlinePlayerID = ulong.Parse(args[0]);
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(onlinePlayerID);
			if (_blockList.Contains(onlinePlayerID))
			{
				_blockList.Remove(onlinePlayerID);
				return ConsoleCommandResult.Succeeded($"Removed {playerInfo.DisplayName} from the blocked list.");
			}
			_blockList.Add(onlinePlayerID);
			return ConsoleCommandResult.Succeeded($"Added {playerInfo.DisplayName} from the blocked list.");
		}
	}
}
