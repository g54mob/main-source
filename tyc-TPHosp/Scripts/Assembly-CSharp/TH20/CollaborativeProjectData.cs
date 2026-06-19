using System;
using System.Collections.Generic;
using FullSerializerSave;

namespace TH20
{
	public class CollaborativeProjectData : CollaborativeProjectDataBase
	{
		[fsProperty("id")]
		public Guid ProjectID;

		[fsProperty("def")]
		public CollaborativeProjectDefinition Definition;

		[fsProperty("sid")]
		public OnlinePlayerID OnlinePlayerID;

		[fsProperty("lid")]
		public OnlinePlayerID LeaderOnlinePlayerID;

		[fsProperty("lut")]
		public uint LastUpdateTime;

		[fsProperty("fut")]
		public uint FirstUpdateTime;

		[fsProperty("rnd")]
		public int RandomSeed;

		[fsProperty("chat")]
		public Queue<CollaborativeProject.ChatMessage> ChatMessages = new Queue<CollaborativeProject.ChatMessage>();

		[fsProperty("net")]
		public ResearchNetworkData ResearchData = new ResearchNetworkData();

		[fsProperty("ver")]
		public int Version;

		[NonSerialized]
		public Action<bool> OnDataChanged;

		[NonSerialized]
		public bool IsDeprecated;

		[fsProperty("col")]
		private Dictionary<OnlinePlayerID, Guid> _collaborators;

		[fsProperty("invT")]
		private readonly Dictionary<OnlinePlayerID, uint> _inviteTimestamps = new Dictionary<OnlinePlayerID, uint>();

		public Dictionary<OnlinePlayerID, Guid> Collaborators => _collaborators;

		public Dictionary<OnlinePlayerID, uint> InviteTimestamps => _inviteTimestamps;

		public bool IsLeaderData()
		{
			return OnlinePlayerID == LeaderOnlinePlayerID;
		}

		public static CollaborativeProjectData CreateAsLeader(CollaborativeProjectDefinition projectDefinition)
		{
			CollaborativeProjectData collaborativeProjectData = new CollaborativeProjectData();
			collaborativeProjectData.ProjectID = Guid.NewGuid();
			collaborativeProjectData.Definition = projectDefinition;
			collaborativeProjectData.OnlinePlayerID = OnlineManager.GetLocalPlayerID();
			collaborativeProjectData.LeaderOnlinePlayerID = collaborativeProjectData.OnlinePlayerID;
			collaborativeProjectData.FirstUpdateTime = OnlineManager.GetServerTime();
			collaborativeProjectData.RandomSeed = collaborativeProjectData.ProjectID.GetHashCode();
			collaborativeProjectData._collaborators = new Dictionary<OnlinePlayerID, Guid>();
			collaborativeProjectData._collaborators.Add(collaborativeProjectData.OnlinePlayerID, Guid.NewGuid());
			return collaborativeProjectData;
		}

		public static CollaborativeProjectData CreateAsGuest(CollaborativeProjectData leaderData)
		{
			return new CollaborativeProjectData
			{
				ProjectID = leaderData.ProjectID,
				Definition = leaderData.Definition,
				OnlinePlayerID = OnlineManager.GetLocalPlayerID(),
				LeaderOnlinePlayerID = leaderData.LeaderOnlinePlayerID,
				FirstUpdateTime = OnlineManager.GetServerTime(),
				RandomSeed = leaderData.RandomSeed,
				Version = leaderData.Version,
				_collaborators = null
			};
		}

		public void AddChatMessage(string message)
		{
			message.Truncate(CollaborativeProject.ChatCharacterLimit);
			while (ChatMessages.Count >= CollaborativeProject.MaxChatMessages)
			{
				ChatMessages.Dequeue();
			}
			CollaborativeProject.ChatMessage item = new CollaborativeProject.ChatMessage
			{
				Timestamp = OnlineManager.GetServerTime(),
				Message = message,
				PlayerID = OnlineManager.GetLocalPlayerID()
			};
			ChatMessages.Enqueue(item);
			OnProjectDataChanged(updateImmediately: false);
		}

		public void AddCompletedResearchNode(int nodeID)
		{
			ResearchData.CompletedNodeTimestamps[nodeID] = OnlineManager.GetServerTime();
			OnProjectDataChanged(updateImmediately: false);
		}

		public void RemoveCompletedResearchNode(int nodeID)
		{
			ResearchData.CompletedNodeTimestamps.Remove(nodeID);
			OnProjectDataChanged(updateImmediately: false);
		}

		public void SetActiveResearchNode(int nodeID)
		{
			ResearchData.ActiveNode = nodeID;
			ResearchData.ActiveNodeTimestamp = OnlineManager.GetServerTime();
			OnProjectDataChanged(updateImmediately: false);
		}

		public void InvitePlayer(OnlinePlayerID steamID)
		{
			if (!_collaborators.ContainsKey(steamID))
			{
				_collaborators[steamID] = Guid.NewGuid();
				_inviteTimestamps[steamID] = OnlineManager.GetServerTime();
				OnProjectDataChanged(updateImmediately: true);
			}
		}

		public void KickPlayer(OnlinePlayerID steamID, bool immediateUpload)
		{
			_collaborators.Remove(steamID);
			_inviteTimestamps.Remove(steamID);
			if (LeaderOnlinePlayerID == OnlineManager.GetLocalPlayerID())
			{
				OnProjectDataChanged(immediateUpload);
			}
		}

		private void OnProjectDataChanged(bool updateImmediately)
		{
			LastUpdateTime = OnlineManager.GetServerTime();
			OnDataChanged.InvokeSafe(updateImmediately);
		}
	}
}
