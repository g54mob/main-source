#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class CollaborativeProject
	{
		public enum ProjectStatus
		{
			Initialising = 0,
			LeaderAbandoned = 1,
			Kicked = 2,
			Ready = 3
		}

		public enum ChatMessageType
		{
			Chat = 0,
			EventStartTask = 1,
			EventCompletedTask = 2,
			EventCompletedVictoryTask = 3,
			EventRejectedInvite = 4,
			EventAcceptedInvite = 5,
			EventNPCChat = 6
		}

		public struct ChatMessage
		{
			public uint Timestamp;

			public string Message;

			public OnlinePlayerID PlayerID;

			public string Name;

			public Sprite Icon;

			[NonSerialized]
			public ChatMessageType Type;
		}

		public Guid ProjectID;

		public OnlinePlayerID LeaderOnlinePlayerID;

		public static readonly int ChatCharacterLimit = 140;

		public static readonly int MaxChatMessages = 12;

		[NonSerialized]
		public CollaborativePortfolio Portfolio;

		[NonSerialized]
		public CollaborativeProjectData LeaderProjectData;

		[NonSerialized]
		public CollaborativeProjectData LocalPlayerData;

		[NonSerialized]
		public Dictionary<OnlinePlayerID, CollaborativeProjectDataBase> ProjectData;

		[NonSerialized]
		public Dictionary<OnlinePlayerID, uint> InviteRejectionData;

		[NonSerialized]
		public ResearchNetwork ResearchNetwork;

		[NonSerialized]
		public uint LastUpdateTime;

		[NonSerialized]
		public ProjectStatus Status;

		public static CollaborativeProject CreateNewProject(CollaborativePortfolio portfolio, CollaborativeProjectDefinition projectDefinition)
		{
			int version;
			ResearchNetworkGenerator latestNetworkGenerator = ResearchNetworkUtils.GetLatestNetworkGenerator(projectDefinition, out version);
			if (latestNetworkGenerator == null)
			{
				return null;
			}
			CollaborativeProjectData collaborativeProjectData = CollaborativeProjectData.CreateAsLeader(projectDefinition);
			collaborativeProjectData.Version = version;
			return new CollaborativeProject
			{
				ProjectID = collaborativeProjectData.ProjectID,
				LeaderOnlinePlayerID = collaborativeProjectData.LeaderOnlinePlayerID,
				LeaderProjectData = collaborativeProjectData,
				LocalPlayerData = collaborativeProjectData,
				ProjectData = { [collaborativeProjectData.LeaderOnlinePlayerID] = collaborativeProjectData },
				ResearchNetwork = latestNetworkGenerator.GenerateNetwork(collaborativeProjectData.RandomSeed),
				Portfolio = portfolio,
				Status = ProjectStatus.Initialising
			};
		}

		public static CollaborativeProject CreateProjectFromOtherLeaderData(CollaborativePortfolio portfolio, CollaborativeProjectData projectData)
		{
			if (projectData == null)
			{
				return null;
			}
			ResearchNetworkGenerator networkGenerator = ResearchNetworkUtils.GetNetworkGenerator(projectData.Definition, projectData.Version);
			if (networkGenerator == null)
			{
				return null;
			}
			CollaborativeProject obj = new CollaborativeProject
			{
				ProjectID = projectData.ProjectID,
				LeaderOnlinePlayerID = projectData.LeaderOnlinePlayerID,
				LeaderProjectData = projectData,
				ProjectData = { [projectData.OnlinePlayerID] = projectData }
			};
			CollaborativeProjectData value = (obj.LocalPlayerData = CollaborativeProjectData.CreateAsGuest(projectData));
			obj.ProjectData[OnlineManager.GetLocalPlayerID()] = value;
			obj.ResearchNetwork = networkGenerator.GenerateNetwork(projectData.RandomSeed);
			obj.Portfolio = portfolio;
			obj.Status = ProjectStatus.Initialising;
			return obj;
		}

		public static CollaborativeProject CreateProjectFromLocalPlayerData(CollaborativePortfolio portfolio, CollaborativeProjectData projectData)
		{
			if (projectData == null)
			{
				return null;
			}
			if (projectData.OnlinePlayerID != OnlineManager.GetLocalPlayerID())
			{
				return null;
			}
			ResearchNetworkGenerator networkGenerator = ResearchNetworkUtils.GetNetworkGenerator(projectData.Definition, projectData.Version);
			if (networkGenerator == null)
			{
				return null;
			}
			return new CollaborativeProject
			{
				ProjectID = projectData.ProjectID,
				LeaderOnlinePlayerID = projectData.LeaderOnlinePlayerID,
				LocalPlayerData = projectData,
				ProjectData = { [projectData.OnlinePlayerID] = projectData },
				LeaderProjectData = ((projectData.LeaderOnlinePlayerID == projectData.OnlinePlayerID) ? projectData : null),
				ResearchNetwork = networkGenerator.GenerateNetwork(projectData.RandomSeed),
				Portfolio = portfolio,
				Status = ProjectStatus.Initialising
			};
		}

		private CollaborativeProject()
		{
			ProjectData = new Dictionary<OnlinePlayerID, CollaborativeProjectDataBase>();
			InviteRejectionData = new Dictionary<OnlinePlayerID, uint>();
		}

		public CollaborativeProjectData GetProjectData(OnlinePlayerID playerID, out bool didDownloadFail)
		{
			didDownloadFail = false;
			if (!ProjectData.TryGetValue(playerID, out var value))
			{
				return null;
			}
			didDownloadFail = value is CollaborativeProjectDataFailedToDownload;
			return value as CollaborativeProjectData;
		}

		public void UpdateProjectData(CollaborativeProjectData projectData)
		{
			if (projectData.OnlinePlayerID == OnlineManager.GetLocalPlayerID())
			{
				LocalPlayerData = projectData;
			}
			if (projectData.LeaderOnlinePlayerID == projectData.OnlinePlayerID)
			{
				LeaderProjectData = projectData;
				LeaderOnlinePlayerID = projectData.LeaderOnlinePlayerID;
			}
			projectData.IsDeprecated = false;
			LastUpdateTime = Math.Max(LastUpdateTime, projectData.LastUpdateTime);
			ProjectData[projectData.OnlinePlayerID] = projectData;
		}

		public void RemoveProjectData(OnlinePlayerID playerID)
		{
			if (ProjectData.ContainsKey(playerID))
			{
				OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(playerID);
				ProjectData.Remove(playerID);
				Logging.Info(LogChannels.Online, "Collaborative Project - Removing Project Data for {0}", (playerInfo != null) ? playerInfo.DisplayName : "non existant player");
			}
		}

		public void UpdateInviteRejectionList(OnlinePlayerID onlinePlayerID, uint timeStamp)
		{
			if (timeStamp == 0)
			{
				InviteRejectionData.Remove(onlinePlayerID);
			}
			else
			{
				InviteRejectionData[onlinePlayerID] = timeStamp;
			}
		}

		public bool HasCollaboratorRejectedLatestInvite(OnlinePlayerID onlinePlayerID)
		{
			if (!InviteRejectionData.TryGetValue(onlinePlayerID, out var value))
			{
				return false;
			}
			if (!LeaderProjectData.InviteTimestamps.TryGetValue(onlinePlayerID, out var value2))
			{
				return false;
			}
			return value > value2;
		}

		public void KickPlayer(OnlinePlayerID onlinePlayerID, bool immediateUpload = true)
		{
			LeaderProjectData.KickPlayer(onlinePlayerID, immediateUpload);
			ProjectData.Remove(onlinePlayerID);
		}

		public void InvitePlayer(OnlinePlayerID onlinePlayerID)
		{
			LeaderProjectData.InvitePlayer(onlinePlayerID);
		}

		public void BroadcastChatMessage(string message)
		{
			LocalPlayerData.AddChatMessage(message);
		}

		public bool HasPlayerBeenKicked()
		{
			if (Status != ProjectStatus.LeaderAbandoned)
			{
				return Status == ProjectStatus.Kicked;
			}
			return true;
		}

		public List<OnlinePlayerID> GetPlayersWithDeprecatedData()
		{
			List<OnlinePlayerID> list = null;
			foreach (KeyValuePair<OnlinePlayerID, CollaborativeProjectDataBase> projectDatum in ProjectData)
			{
				if (!(projectDatum.Key == OnlineManager.GetLocalPlayerID()) && projectDatum.Value is CollaborativeProjectData collaborativeProjectData && collaborativeProjectData.IsDeprecated)
				{
					if (list == null)
					{
						list = new List<OnlinePlayerID>();
					}
					list.Add(projectDatum.Key);
				}
			}
			return list;
		}

		public void DEBUG_CompletedActiveGoal(int nodeID)
		{
			LocalPlayerData.AddCompletedResearchNode(nodeID);
		}

		public void DEBUG_UncompleteActiveGoal(int nodeID)
		{
			LocalPlayerData.RemoveCompletedResearchNode(nodeID);
		}

		public bool IsProjectCompleted()
		{
			if (Portfolio.PortfolioDataController != null && Portfolio.PortfolioDataController.PortfolioData.IsProjectCompleted(ProjectID))
			{
				return true;
			}
			List<CollaborativeNode> list = ResearchNetworkUtils.FindVictoryNodes(ResearchNetwork);
			if (list == null)
			{
				return true;
			}
			foreach (CollaborativeNode item in list)
			{
				if (!ResearchNetworkUtils.IsNodeCompleted(item, this))
				{
					return false;
				}
			}
			return true;
		}

		public void GetNodeCompletedPlayers(CollaborativeNode node, ref List<OnlinePlayerID> players)
		{
			foreach (KeyValuePair<OnlinePlayerID, CollaborativeProjectDataBase> projectDatum in ProjectData)
			{
				if (projectDatum.Value is CollaborativeProjectData collaborativeProjectData && collaborativeProjectData.ResearchData.CompletedNodeTimestamps.ContainsKey(node.NodeID))
				{
					players.Add(projectDatum.Key);
				}
			}
		}

		public int GetNodeCompletedPlayersCount(CollaborativeNode node)
		{
			int num = 0;
			foreach (KeyValuePair<OnlinePlayerID, CollaborativeProjectDataBase> projectDatum in ProjectData)
			{
				if (projectDatum.Value is CollaborativeProjectData collaborativeProjectData && collaborativeProjectData.ResearchData.CompletedNodeTimestamps.ContainsKey(node.NodeID))
				{
					num++;
				}
			}
			return num;
		}

		public void GetNodeInProgressPlayers(CollaborativeNode node, ref List<OnlinePlayerID> players)
		{
			foreach (KeyValuePair<OnlinePlayerID, CollaborativeProjectDataBase> projectDatum in ProjectData)
			{
				if (projectDatum.Value is CollaborativeProjectData collaborativeProjectData && collaborativeProjectData.ResearchData.ActiveNode == node.NodeID)
				{
					players.Add(projectDatum.Key);
				}
			}
		}

		public int GetNodeInProgressPlayersCount(CollaborativeNode node)
		{
			int num = 0;
			foreach (KeyValuePair<OnlinePlayerID, CollaborativeProjectDataBase> projectDatum in ProjectData)
			{
				if (projectDatum.Value is CollaborativeProjectData collaborativeProjectData && collaborativeProjectData.ResearchData.ActiveNode == node.NodeID)
				{
					num++;
				}
			}
			return num;
		}

		public void SetDownloadErrorForPlayerData(OnlinePlayerID playerID)
		{
			if (!ProjectData.ContainsKey(playerID))
			{
				ProjectData[playerID] = new CollaborativeProjectDataFailedToDownload();
			}
		}
	}
}
