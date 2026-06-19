using System;
using System.Collections.Generic;
using FullSerializerSave;

namespace TH20
{
	public class CollaborativePortfolioData : OnlineManager.IOnlineSerializable
	{
		[fsProperty("sid")]
		public readonly OnlinePlayerID OnlinePlayerID;

		[fsProperty("data")]
		public readonly List<CollaborativeProjectData> ProjectDataList = new List<CollaborativeProjectData>();

		[fsProperty("vic")]
		public List<Guid> CompletedProjectsList = new List<Guid>();

		[fsProperty("rej")]
		public readonly Dictionary<Guid, uint> RejectedInvites = new Dictionary<Guid, uint>();

		[fsProperty("mo")]
		public MetagameObjective ActiveObjective;

		[fsProperty("c")]
		public List<CollaborativeProjectDefinition> CompletedProjectDefinitions = new List<CollaborativeProjectDefinition>();

		[fsProperty("sbrr")]
		public SuperBugRewardRecord SuperBugRewardRecord = new SuperBugRewardRecord();

		[fsProperty("nc")]
		public int NodesCompleted;

		public CollaborativePortfolioData()
		{
			OnlinePlayerID = OnlineManager.GetLocalPlayerID();
		}

		public void PrepareForUpload()
		{
		}

		public void RestoreAfterDownload()
		{
			if (OnlinePlayerID != OnlineManager.GetLocalPlayerID() && ActiveObjective != null)
			{
				ActiveObjective.Destroy();
				ActiveObjective = null;
			}
			if (ActiveObjective != null && ActiveObjective.Definition == null)
			{
				ActiveObjective.Destroy();
				ActiveObjective = null;
			}
		}

		public bool AddProjectCompleteTag(Guid projectId)
		{
			if (IsProjectCompleted(projectId))
			{
				return false;
			}
			CompletedProjectsList.Add(projectId);
			if (CompletedProjectsList.Count >= 50)
			{
				CompletedProjectsList.RemoveAt(0);
			}
			return true;
		}

		public bool IsProjectCompleted(Guid projectId)
		{
			for (int i = 0; i < CompletedProjectsList.Count; i++)
			{
				if (CompletedProjectsList[i] == projectId)
				{
					return true;
				}
			}
			return false;
		}

		public CollaborativeProjectData GetProjectData(Guid projectId)
		{
			for (int i = 0; i < ProjectDataList.Count; i++)
			{
				if (ProjectDataList[i].ProjectID == projectId)
				{
					return ProjectDataList[i];
				}
			}
			return null;
		}
	}
}
