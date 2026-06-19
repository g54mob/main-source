#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using TH20.Analytics;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class CollaborativePortfolioDataController : MustCallDestroy
	{
		public Action OnProjectInteractionCompleted;

		public static readonly int MaxCollaborativeProjects = 3;

		private SuperBugProjectManager _superBugManager;

		private readonly BaseOnlineDataFile _uploadFile;

		private AnalyticsManager _analyticsManager;

		private App _app;

		private float _uploadTimer;

		private const float _uploadInterval = 120f;

		private bool _dataChangedWithoutUpload;

		public CollaborativePortfolioData PortfolioData { get; private set; }

		public bool IsUploading
		{
			get
			{
				if (_uploadFile != null)
				{
					return _uploadFile.IsUploading();
				}
				return false;
			}
		}

		public MetagameObjective ActiveObjective
		{
			get
			{
				if (PortfolioData == null)
				{
					return null;
				}
				return PortfolioData.ActiveObjective;
			}
		}

		public CollaborativePortfolioDataController(CollaborativePortfolioData portfolioData, App app, SuperBugProjectManager superBugManager, BaseOnlineDataFile uploadFile, AnalyticsManager analyticsManager)
		{
			PortfolioData = portfolioData;
			_superBugManager = superBugManager;
			_analyticsManager = analyticsManager;
			_app = app;
			_uploadFile = uploadFile;
			BaseOnlineDataFile uploadFile2 = _uploadFile;
			uploadFile2.OnFileUploadCompleted = (Action<BaseOnlineDataFile>)Delegate.Combine(uploadFile2.OnFileUploadCompleted, new Action<BaseOnlineDataFile>(OnFileUploadCompleted));
			BaseOnlineDataFile uploadFile3 = _uploadFile;
			uploadFile3.OnFileUploadFailed = (Action<BaseOnlineDataFile>)Delegate.Combine(uploadFile3.OnFileUploadFailed, new Action<BaseOnlineDataFile>(OnFileUploadFailed));
			for (int i = 0; i < PortfolioData.ProjectDataList.Count; i++)
			{
				CollaborativeProjectData collaborativeProjectData = PortfolioData.ProjectDataList[i];
				collaborativeProjectData.OnDataChanged = (Action<bool>)Delegate.Combine(collaborativeProjectData.OnDataChanged, new Action<bool>(OnProjectDataChanged));
			}
			if (ActiveObjective != null)
			{
				ActiveObjective.RestoreFromSave(app.Metagame);
			}
		}

		public override void Destroy()
		{
			for (int i = 0; i < PortfolioData.ProjectDataList.Count; i++)
			{
				CollaborativeProjectData collaborativeProjectData = PortfolioData.ProjectDataList[i];
				collaborativeProjectData.OnDataChanged = (Action<bool>)Delegate.Remove(collaborativeProjectData.OnDataChanged, new Action<bool>(OnProjectDataChanged));
			}
			if (_uploadFile != null)
			{
				BaseOnlineDataFile uploadFile = _uploadFile;
				uploadFile.OnFileUploadCompleted = (Action<BaseOnlineDataFile>)Delegate.Remove(uploadFile.OnFileUploadCompleted, new Action<BaseOnlineDataFile>(OnFileUploadCompleted));
				BaseOnlineDataFile uploadFile2 = _uploadFile;
				uploadFile2.OnFileUploadFailed = (Action<BaseOnlineDataFile>)Delegate.Remove(uploadFile2.OnFileUploadFailed, new Action<BaseOnlineDataFile>(OnFileUploadFailed));
			}
			if (ActiveObjective != null)
			{
				ActiveObjective.Destroy();
			}
			base.Destroy();
		}

		public void Update(float timeDelta, float unscaledTimeDelta)
		{
			if (_app?.Metagame?.CollaborativePortfolio == null)
			{
				return;
			}
			if (ActiveObjective != null)
			{
				ActiveObjective.Update(timeDelta, unscaledTimeDelta);
			}
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				_uploadTimer += Time.unscaledDeltaTime;
				if (_dataChangedWithoutUpload && _uploadTimer > 120f)
				{
					_uploadTimer = 0f;
					_dataChangedWithoutUpload = false;
					_uploadFile.ForceUpload();
				}
			}
		}

		public void AddProjectData(CollaborativeProjectData projectData)
		{
			if (PortfolioData.ProjectDataList.Count < MaxCollaborativeProjects)
			{
				projectData.OnDataChanged = (Action<bool>)Delegate.Combine(projectData.OnDataChanged, new Action<bool>(OnProjectDataChanged));
				PortfolioData.ProjectDataList.Add(projectData);
				OnProjectDataChanged(forceUpload: true);
			}
		}

		public void RemoveProjectData(Guid projectID)
		{
			for (int i = 0; i < PortfolioData.ProjectDataList.Count; i++)
			{
				if (PortfolioData.ProjectDataList[i].ProjectID == projectID)
				{
					CollaborativeProjectData collaborativeProjectData = PortfolioData.ProjectDataList[i];
					collaborativeProjectData.OnDataChanged = (Action<bool>)Delegate.Remove(collaborativeProjectData.OnDataChanged, new Action<bool>(OnProjectDataChanged));
					PortfolioData.ProjectDataList.RemoveAt(i);
					if (ActiveObjective is ResearchProjectObjective researchProjectObjective && researchProjectObjective.ProjectID == projectID)
					{
						ActiveObjective.Abandon();
					}
					OnProjectDataChanged(forceUpload: true);
					OnProjectInteractionCompleted.InvokeSafe();
					break;
				}
			}
		}

		public int GetProjectDataCount()
		{
			return PortfolioData.ProjectDataList.Count;
		}

		public CollaborativeProjectData GetProjectData(Guid projectID)
		{
			for (int i = 0; i < PortfolioData.ProjectDataList.Count; i++)
			{
				if (PortfolioData.ProjectDataList[i].ProjectID == projectID)
				{
					return PortfolioData.ProjectDataList[i];
				}
			}
			return null;
		}

		public void AddCompletedProjectToList(CollaborativeProject project)
		{
			if (project != null && !(project.ProjectID == Guid.Empty))
			{
				PortfolioData.CompletedProjectDefinitions.AddUnique(project.LocalPlayerData.Definition);
				if (project.LocalPlayerData.Definition.HasAchievementToReward)
				{
					PlatformStatsAndAchievements.TriggerAchievement(project.LocalPlayerData.Definition.AchievementToReward);
				}
				if (PortfolioData.AddProjectCompleteTag(project.ProjectID))
				{
					OnProjectDataChanged(forceUpload: true);
				}
			}
		}

		public bool IsProjectTypeCompleted(CollaborativeProjectDefinition projectDefinition)
		{
			if (PortfolioData?.CompletedProjectDefinitions == null)
			{
				return false;
			}
			return PortfolioData.CompletedProjectDefinitions.Contains(projectDefinition);
		}

		public void AddCompletedSuperBugVictoryNode(int superBugId, CollaborativeNode.VictoryNodeType victoryType)
		{
			if (PortfolioData?.SuperBugRewardRecord != null)
			{
				bool num = PortfolioData.SuperBugRewardRecord.SetReward(superBugId, victoryType);
				_app.UserProfile.SetSuperBugReward(superBugId, victoryType);
				if (num)
				{
					GameEvent gameEvent = new GameEvent(_analyticsManager.Config.SuperBugRewardCollectionInfo).AddParam("super_bug_id", superBugId).AddParam("reward_type", (int)victoryType);
					_analyticsManager.RecordEvent(gameEvent);
				}
				OnProjectDataChanged(forceUpload: false);
			}
		}

		public bool IsSuperBugVictoryAchieved(int superBugId, CollaborativeNode.VictoryNodeType victoryType)
		{
			if (_app.UserProfile.HasSuperBugReward(superBugId, victoryType))
			{
				return true;
			}
			if (PortfolioData?.SuperBugRewardRecord == null)
			{
				return false;
			}
			return PortfolioData.SuperBugRewardRecord.HasReward(superBugId, victoryType);
		}

		public void SetActiveObjective(MetagameObjective objective)
		{
			if (ActiveObjective != null)
			{
				ActiveObjective.Abandon();
				ClearResearchObjective();
			}
			ResearchProjectObjective researchProjectObjective = objective as ResearchProjectObjective;
			SuperBugObjective superBugObjective = objective as SuperBugObjective;
			if (researchProjectObjective != null)
			{
				CollaborativeProjectData projectData = GetProjectData(researchProjectObjective.ProjectID);
				if (projectData != null)
				{
					PortfolioData.ActiveObjective = researchProjectObjective;
					projectData.ResearchData.ActiveNode = researchProjectObjective.NodeID;
					projectData.ResearchData.ActiveNodeTimestamp = OnlineManager.GetServerTime();
				}
				else
				{
					researchProjectObjective.Destroy();
				}
			}
			else if (superBugObjective != null)
			{
				if (_superBugManager?.DownloadedProjectDefinition != null)
				{
					PortfolioData.ActiveObjective = superBugObjective;
				}
				else
				{
					superBugObjective.Destroy();
				}
			}
			OnProjectDataChanged(forceUpload: false);
		}

		private void ClearResearchObjective()
		{
			if (ActiveObjective == null)
			{
				return;
			}
			if (ActiveObjective is ResearchProjectObjective researchProjectObjective)
			{
				CollaborativeProjectData projectData = GetProjectData(researchProjectObjective.ProjectID);
				if (projectData != null)
				{
					projectData.ResearchData.ActiveNode = -1;
					projectData.ResearchData.ActiveNodeTimestamp = 0u;
				}
			}
			ActiveObjective.Destroy();
			PortfolioData.ActiveObjective = null;
			OnProjectDataChanged(forceUpload: false);
		}

		public void OnActiveObjectiveUpdated(bool force = false)
		{
			if (ActiveObjective != null)
			{
				OnProjectDataChanged(force);
			}
		}

		public void OnActiveObjectiveCompleted(Objective.CompletionType completionType)
		{
			if (ActiveObjective == null)
			{
				return;
			}
			if (completionType == Objective.CompletionType.Successful)
			{
				if (ActiveObjective is ResearchProjectObjective researchProjectObjective)
				{
					CollaborativeProjectData projectData = GetProjectData(researchProjectObjective.ProjectID);
					if (projectData?.ResearchData != null)
					{
						projectData.ResearchData.CompletedNodeTimestamps[researchProjectObjective.NodeID] = OnlineManager.GetServerTime();
					}
				}
				PortfolioData.NodesCompleted++;
				PlatformStatsAndAchievements.SetStatValue(Stat.CollaborativeNodesCompleted, PortfolioData.NodesCompleted);
				ClearResearchObjective();
			}
			else if (completionType == Objective.CompletionType.Abandoned || !ActiveObjective.IsReplayable)
			{
				ClearResearchObjective();
			}
			OnProjectDataChanged(forceUpload: true);
		}

		public void ConsumeInvite(Guid projectID)
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				PortfolioData.RejectedInvites[projectID] = OnlineManager.GetServerTime();
				OnProjectDataChanged(forceUpload: true);
			}
		}

		public bool HasConsumedInvite(CollaborativeProjectData projectData)
		{
			if (!projectData.InviteTimestamps.TryGetValue(PortfolioData.OnlinePlayerID, out var value))
			{
				return false;
			}
			return HasConsumedInvite(projectData.ProjectID, value);
		}

		public bool HasConsumedInvite(Guid projectID, uint inviteTimestamp)
		{
			PortfolioData.RejectedInvites.TryGetValue(projectID, out var value);
			return value > inviteTimestamp;
		}

		public void ClearInviteRecord(List<Guid> invitesToRemove)
		{
			if (invitesToRemove.Count <= 0)
			{
				return;
			}
			foreach (Guid item in invitesToRemove)
			{
				PortfolioData.RejectedInvites.Remove(item);
			}
			OnProjectDataChanged(forceUpload: true);
		}

		public void ForceUploadData()
		{
			OnProjectDataChanged(forceUpload: true);
		}

		private void OnProjectDataChanged(bool forceUpload)
		{
			_uploadFile.Serialize(PortfolioData);
			if (forceUpload)
			{
				if (PortfolioData.OnlinePlayerID != OnlineManager.GetLocalPlayerID())
				{
					Logging.Error("Uploading Corrupt File Data");
				}
				foreach (CollaborativeProjectData projectData in PortfolioData.ProjectDataList)
				{
					if (projectData.OnlinePlayerID != OnlineManager.GetLocalPlayerID())
					{
						Logging.Error("Uploading Corrupt Project Data");
					}
				}
				_uploadTimer = 0f;
				_dataChangedWithoutUpload = false;
				_uploadFile.ForceUpload();
			}
			else
			{
				_dataChangedWithoutUpload = true;
			}
		}

		private void OnFileUploadFailed(BaseOnlineDataFile file)
		{
			OnProjectInteractionCompleted.InvokeSafe();
		}

		private void OnFileUploadCompleted(BaseOnlineDataFile file)
		{
			OnProjectInteractionCompleted.InvokeSafe();
		}
	}
}
