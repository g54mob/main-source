using System;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class CollaborativeProjectView : MonoBehaviour
	{
		public Action<CollaborativeProject> OnKickedFromProject;

		public Action<CollaborativeProject> OnCompletedProject;

		public Action<ObjectiveDefinition> OnResearchObjectiveStarted;

		[SerializeField]
		private GameObject _chatContentWindow;

		[SerializeField]
		private ScrollRect _chatScrollRect;

		[SerializeField]
		private DynamicButton _showChatToggle;

		[SerializeField]
		private GameObject _showChatCheckmark;

		[SerializeField]
		private DynamicButton _showEventToggle;

		[SerializeField]
		private GameObject _showEventCheckmark;

		[SerializeField]
		private GameObject _chatMessageItemPrefab;

		[SerializeField]
		private ResearchNetworkView _networkViewer;

		[SerializeField]
		private ResearchNetworkInteractionView _interactionView;

		[SerializeField]
		private CollaborativeVictoryProgressView _victoryProgressView;

		[SerializeField]
		private CollaborativeProjectInviteFriend _inviteFriendView;

		[SerializeField]
		private List<CollaboratorProfileButton> _collaboratorButtons;

		[SerializeField]
		private List<CollaborativeNode.VictoryNodeType> _victoryTypeMapKeys;

		[SerializeField]
		private List<Sprite> _victoryTypeMapValues;

		private readonly Dictionary<CollaborativeNode.VictoryNodeType, Sprite> _victoryTypeMap = new Dictionary<CollaborativeNode.VictoryNodeType, Sprite>();

		private readonly List<CollaborativeProject.ChatMessage> _chatList = new List<CollaborativeProject.ChatMessage>();

		private readonly List<ChatMessageItem> _chatUIItemList = new List<ChatMessageItem>();

		private Metagame _metagame;

		private CollaborativePortfolio _portfolio;

		private CollaborativeResearchMenu _rootMenu;

		private CollaborativeProject _project;

		private InputManager _inputManager;

		private bool _showChatMessages = true;

		private bool _showEventMessages = true;

		private void Start()
		{
			foreach (CollaboratorProfileButton collaboratorButton in _collaboratorButtons)
			{
				collaboratorButton.OnRequestAddPlayer = (Action)Delegate.Combine(collaboratorButton.OnRequestAddPlayer, new Action(OnRequestAddPlayer));
				collaboratorButton.OnRequestKickPlayer = (Action<OnlinePlayerID>)Delegate.Combine(collaboratorButton.OnRequestKickPlayer, new Action<OnlinePlayerID>(OnRequestKickPlayer));
			}
			CollaborativeProjectInviteFriend inviteFriendView = _inviteFriendView;
			inviteFriendView.OnFriendSelected = (Action<OnlinePlayerID>)Delegate.Combine(inviteFriendView.OnFriendSelected, new Action<OnlinePlayerID>(OnFriendSelected));
			CollaborativeProjectInviteFriend inviteFriendView2 = _inviteFriendView;
			inviteFriendView2.OnCancelSelected = (Action)Delegate.Combine(inviteFriendView2.OnCancelSelected, new Action(OnFriendSelectCancel));
			ResearchNetworkView networkViewer = _networkViewer;
			networkViewer.OnNetworkNodeSelected = (Action<CollaborativeNode>)Delegate.Combine(networkViewer.OnNetworkNodeSelected, new Action<CollaborativeNode>(OnResearchNodeSelected));
			ResearchNetworkInteractionView interactionView = _interactionView;
			interactionView.OnNodeSelected = (Action<CollaborativeNode>)Delegate.Combine(interactionView.OnNodeSelected, new Action<CollaborativeNode>(OnResearchNodeStarted));
			ResearchNetworkInteractionView interactionView2 = _interactionView;
			interactionView2.OnNodeDebugCompleted = (Action<CollaborativeNode>)Delegate.Combine(interactionView2.OnNodeDebugCompleted, new Action<CollaborativeNode>(OnResearchNodeDebugCompleted));
			ResearchNetworkInteractionView interactionView3 = _interactionView;
			interactionView3.OnNodeDebugUncompleted = (Action<CollaborativeNode>)Delegate.Combine(interactionView3.OnNodeDebugUncompleted, new Action<CollaborativeNode>(OnResearchNodeDebugUncompleted));
		}

		public void Initialise(Metagame metagame, CollaborativeResearchMenu rootMenu, CollaborativePortfolio portfolio, InputManager inputManager, OnlineMetadataManager metadataManager)
		{
			_victoryTypeMap.Clear();
			for (int i = 0; i != Math.Min(_victoryTypeMapKeys.Count, _victoryTypeMapValues.Count); i++)
			{
				_victoryTypeMap.Add(_victoryTypeMapKeys[i], _victoryTypeMapValues[i]);
			}
			_metagame = metagame;
			_rootMenu = rootMenu;
			_inviteFriendView.Setup(metadataManager);
			_portfolio = portfolio;
			_inputManager = inputManager;
		}

		public void OnEnable()
		{
			CollaborativePortfolio portfolio = _portfolio;
			portfolio.OnLatestDataGathered = (Action)Delegate.Combine(portfolio.OnLatestDataGathered, new Action(OnProjectDataReceived));
			CollaborativePortfolio portfolio2 = _portfolio;
			portfolio2.OnBeginLatestDataGather = (Action)Delegate.Combine(portfolio2.OnBeginLatestDataGather, new Action(OnProjectDataBeginGather));
			_showChatToggle.onPrimaryDown.AddListener(OnShowChatFilterPressed);
			_showEventToggle.onPrimaryDown.AddListener(OnShowEventFilterPressed);
		}

		public void OnDisable()
		{
			CollaborativePortfolio portfolio = _portfolio;
			portfolio.OnLatestDataGathered = (Action)Delegate.Remove(portfolio.OnLatestDataGathered, new Action(OnProjectDataReceived));
			CollaborativePortfolio portfolio2 = _portfolio;
			portfolio2.OnBeginLatestDataGather = (Action)Delegate.Remove(portfolio2.OnBeginLatestDataGather, new Action(OnProjectDataBeginGather));
			_showChatToggle.onPrimaryDown.RemoveListener(OnShowChatFilterPressed);
			_showEventToggle.onPrimaryDown.RemoveListener(OnShowEventFilterPressed);
		}

		public void OnDestroy()
		{
			foreach (CollaboratorProfileButton collaboratorButton in _collaboratorButtons)
			{
				collaboratorButton.OnRequestAddPlayer = (Action)Delegate.Remove(collaboratorButton.OnRequestAddPlayer, new Action(OnRequestAddPlayer));
				collaboratorButton.OnRequestKickPlayer = (Action<OnlinePlayerID>)Delegate.Remove(collaboratorButton.OnRequestKickPlayer, new Action<OnlinePlayerID>(OnRequestKickPlayer));
			}
			CollaborativeProjectInviteFriend inviteFriendView = _inviteFriendView;
			inviteFriendView.OnFriendSelected = (Action<OnlinePlayerID>)Delegate.Remove(inviteFriendView.OnFriendSelected, new Action<OnlinePlayerID>(OnFriendSelected));
			CollaborativeProjectInviteFriend inviteFriendView2 = _inviteFriendView;
			inviteFriendView2.OnCancelSelected = (Action)Delegate.Remove(inviteFriendView2.OnCancelSelected, new Action(OnFriendSelectCancel));
			ResearchNetworkView networkViewer = _networkViewer;
			networkViewer.OnNetworkNodeSelected = (Action<CollaborativeNode>)Delegate.Remove(networkViewer.OnNetworkNodeSelected, new Action<CollaborativeNode>(OnResearchNodeSelected));
			ResearchNetworkInteractionView interactionView = _interactionView;
			interactionView.OnNodeSelected = (Action<CollaborativeNode>)Delegate.Remove(interactionView.OnNodeSelected, new Action<CollaborativeNode>(OnResearchNodeStarted));
			ResearchNetworkInteractionView interactionView2 = _interactionView;
			interactionView2.OnNodeDebugCompleted = (Action<CollaborativeNode>)Delegate.Remove(interactionView2.OnNodeDebugCompleted, new Action<CollaborativeNode>(OnResearchNodeDebugCompleted));
			ResearchNetworkInteractionView interactionView3 = _interactionView;
			interactionView3.OnNodeDebugUncompleted = (Action<CollaborativeNode>)Delegate.Remove(interactionView3.OnNodeDebugUncompleted, new Action<CollaborativeNode>(OnResearchNodeDebugUncompleted));
		}

		public void SetupForProject(Guid? projectId)
		{
			_project = _portfolio.GetProject(projectId.Value);
			_networkViewer.Setup(_project, _inputManager, _project.ResearchNetwork, _interactionView, _project.LocalPlayerData.RandomSeed);
			RefreshNetwork();
			_networkViewer.CentreOnNode(CalculateNodeToCentreOn());
			_portfolio.LogLastView(_project.ProjectID);
			_victoryProgressView.Setup(_project.ResearchNetwork, _networkViewer);
		}

		public void Show()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
			Refresh();
		}

		private void HideInternal()
		{
			Hide();
		}

		public void Hide()
		{
			if (_project != null)
			{
				_portfolio.LogLastView(_project.ProjectID);
			}
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
		}

		public void Refresh()
		{
			if (_project.IsProjectCompleted())
			{
				OnCompletedProject.InvokeSafe(_project);
				HideInternal();
				return;
			}
			if (_project.HasPlayerBeenKicked())
			{
				OnKickedFromProject.InvokeSafe(_project);
				HideInternal();
				return;
			}
			_networkViewer.Refresh();
			_victoryProgressView.Refresh();
			RefreshCollaborators();
			RefreshNetwork();
			RefreshVictoryProgressView();
			RefreshChat();
		}

		private void RefreshCollaborators()
		{
			bool flag = _project.LeaderProjectData.OnlinePlayerID == OnlineManager.GetLocalPlayerID();
			_collaboratorButtons[0].IsLocalPlayerLeader = flag;
			_collaboratorButtons[0].Setup(_project.LeaderProjectData.OnlinePlayerID, _networkViewer, _project.LeaderProjectData);
			int num = 1;
			foreach (OnlinePlayerID key in _project.LeaderProjectData.Collaborators.Keys)
			{
				if (!(key == _project.LeaderProjectData.OnlinePlayerID) && !_project.HasCollaboratorRejectedLatestInvite(key))
				{
					_project.ProjectData.TryGetValue(key, out var value);
					_collaboratorButtons[num].IsLocalPlayerLeader = flag;
					_collaboratorButtons[num].Setup(key, _networkViewer, value);
					_collaboratorButtons[num].gameObject.SetActive(value: true);
					num++;
				}
			}
			for (int i = num; i < _collaboratorButtons.Count; i++)
			{
				if (i < _project.LeaderProjectData.Definition.MaxCollaborators && flag)
				{
					_collaboratorButtons[i].IsLocalPlayerLeader = true;
					_collaboratorButtons[i].Setup(OnlinePlayerID.Nil, _networkViewer, null);
					_collaboratorButtons[i].gameObject.SetActive(value: true);
				}
				else
				{
					_collaboratorButtons[i].IsLocalPlayerLeader = true;
					_collaboratorButtons[i].Setup(OnlinePlayerID.Nil, _networkViewer, null);
					_collaboratorButtons[i].gameObject.SetActive(value: false);
				}
			}
		}

		private void RefreshNetwork()
		{
			_networkViewer.ClearResearchData();
			foreach (KeyValuePair<OnlinePlayerID, CollaborativeProjectDataBase> projectDatum in _project.ProjectData)
			{
				if (projectDatum.Value is CollaborativeProjectData collaborativeProjectData)
				{
					_networkViewer.AddResearchData(projectDatum.Key, collaborativeProjectData.ResearchData);
				}
			}
			_networkViewer.Refresh();
		}

		private void RefreshVictoryProgressView()
		{
			_victoryProgressView.Refresh();
		}

		private void RefreshChat()
		{
			GameObjectUtils.SetActive(_showChatCheckmark, _showChatMessages);
			GameObjectUtils.SetActive(_showEventCheckmark, _showEventMessages);
			_chatList.Clear();
			if (_showChatMessages)
			{
				List<CollaborativeProjectDefinition.NPCChat> stickyChatList = _project.LocalPlayerData.Definition.StickyChatList;
				if (stickyChatList != null)
				{
					foreach (CollaborativeProjectDefinition.NPCChat item6 in stickyChatList)
					{
						CollaborativeProject.ChatMessage item = default(CollaborativeProject.ChatMessage);
						LocalisedString message = item6.Message;
						item.Message = message.Translation;
						message = item6.Name;
						item.Name = message.Translation;
						item.Icon = item6.Icon;
						item.Timestamp = 1u;
						item.Type = CollaborativeProject.ChatMessageType.EventNPCChat;
						_chatList.Add(item);
					}
				}
				foreach (KeyValuePair<OnlinePlayerID, CollaborativeProjectDataBase> projectDatum in _project.ProjectData)
				{
					if (projectDatum.Value is CollaborativeProjectData collaborativeProjectData && !OnlineManager.ShouldHideMessageFromUser(projectDatum.Key))
					{
						_chatList.AddRange(collaborativeProjectData.ChatMessages);
					}
				}
			}
			if (_showEventMessages)
			{
				foreach (KeyValuePair<OnlinePlayerID, uint> inviteRejectionDatum in _project.InviteRejectionData)
				{
					if (!OnlineManager.ShouldHideMessageFromUser(inviteRejectionDatum.Key))
					{
						CollaborativeProject.ChatMessage item2 = new CollaborativeProject.ChatMessage
						{
							Message = ScriptLocalization.Collaborative_GUI_Events.RejectInvite_CS,
							PlayerID = inviteRejectionDatum.Key,
							Timestamp = inviteRejectionDatum.Value,
							Type = CollaborativeProject.ChatMessageType.EventRejectedInvite
						};
						_chatList.Add(item2);
					}
				}
				foreach (KeyValuePair<OnlinePlayerID, CollaborativeProjectDataBase> projectDatum2 in _project.ProjectData)
				{
					if (!(projectDatum2.Value is CollaborativeProjectData collaborativeProjectData2) || OnlineManager.ShouldHideMessageFromUser(projectDatum2.Key))
					{
						continue;
					}
					CollaborativeProject.ChatMessage item3 = new CollaborativeProject.ChatMessage
					{
						Message = ScriptLocalization.Collaborative_GUI_Events.JoinProject_CS,
						PlayerID = projectDatum2.Key,
						Timestamp = collaborativeProjectData2.FirstUpdateTime,
						Type = CollaborativeProject.ChatMessageType.EventAcceptedInvite
					};
					_chatList.Add(item3);
					ResearchNetworkData researchData = collaborativeProjectData2.ResearchData;
					if (researchData == null)
					{
						continue;
					}
					if (researchData.ActiveNode != -1 && _project.ResearchNetwork.GetNode(researchData.ActiveNode) is CollaborativeNode { Definition: { } definition })
					{
						CollaborativeProject.ChatMessage item4 = new CollaborativeProject.ChatMessage
						{
							Message = string.Format(ScriptLocalization.Collaborative_GUI_Events.StartedResearchNode_CS, definition.Objective.NameLocalised.Translation),
							PlayerID = projectDatum2.Key,
							Timestamp = researchData.ActiveNodeTimestamp,
							Type = CollaborativeProject.ChatMessageType.EventStartTask
						};
						_chatList.Add(item4);
					}
					foreach (KeyValuePair<int, uint> completedNodeTimestamp in collaborativeProjectData2.ResearchData.CompletedNodeTimestamps)
					{
						if (_project.ResearchNetwork.GetNode(completedNodeTimestamp.Key) is CollaborativeNode { Definition: { } definition2 })
						{
							CollaborativeProject.ChatMessage item5 = new CollaborativeProject.ChatMessage
							{
								Message = string.Format(ScriptLocalization.Collaborative_GUI_Events.CompletedResearchNode_CS, definition2.Objective.NameLocalised.Translation),
								PlayerID = projectDatum2.Key,
								Timestamp = completedNodeTimestamp.Value,
								Type = CollaborativeProject.ChatMessageType.EventCompletedTask
							};
							_chatList.Add(item5);
						}
					}
				}
			}
			_chatList.Sort((CollaborativeProject.ChatMessage c1, CollaborativeProject.ChatMessage c2) => (int)(c1.Timestamp - c2.Timestamp));
			int num = _chatList.Count - _chatUIItemList.Count;
			for (int num2 = 0; num2 < num; num2++)
			{
				GameObject obj = UnityEngine.Object.Instantiate(_chatMessageItemPrefab);
				ChatMessageItem component = obj.GetComponent<ChatMessageItem>();
				obj.transform.SetParent(_chatContentWindow.transform, worldPositionStays: false);
				_chatUIItemList.Add(component);
			}
			for (int num3 = 0; num3 < _chatUIItemList.Count; num3++)
			{
				ChatMessageItem chatMessageItem = _chatUIItemList[num3];
				if (num3 >= _chatList.Count)
				{
					GameObjectUtils.SetActive(chatMessageItem.gameObject, isActive: false);
					continue;
				}
				GameObjectUtils.SetActive(chatMessageItem.gameObject, isActive: true);
				CollaborativeProject.ChatMessage chatMessage = _chatList[num3];
				chatMessageItem.Setup(chatMessage);
			}
		}

		private void OnClosePressed()
		{
			Hide();
		}

		private void OnRequestKickPlayer(OnlinePlayerID onlinePlayerID)
		{
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(onlinePlayerID);
			string arg = ((playerInfo != null) ? playerInfo.DisplayName : ScriptLocalization.Misc.Unknown_CS);
			_rootMenu.MessageBox.SetupWith2Buttons(string.Format(ScriptLocalization.Collaborative_GUI.KickPlayerWarning_CS, arg), ScriptLocalization.Collaborative_GUI.OK_CS, delegate
			{
				_project.KickPlayer(onlinePlayerID);
				Refresh();
			}, ScriptLocalization.Misc.Cancel_CS, null);
			Refresh();
		}

		private void OnRequestAddPlayer()
		{
			_inviteFriendView.ExclusionList = _project.LeaderProjectData.Collaborators.Keys.ToList();
			_inviteFriendView.gameObject.SetActive(value: true);
		}

		private void OnFriendSelected(OnlinePlayerID onlinePlayerID)
		{
			_inviteFriendView.gameObject.SetActive(value: false);
			_project.InvitePlayer(onlinePlayerID);
			RefreshCollaborators();
		}

		private void OnFriendSelectCancel()
		{
			_inviteFriendView.gameObject.SetActive(value: false);
		}

		private void OnChatMessageRequest(string message)
		{
			if (!message.IsNullOrEmpty())
			{
				_project.BroadcastChatMessage(message);
				_showChatMessages = true;
				RefreshChat();
				_chatScrollRect.verticalNormalizedPosition = 0f;
			}
		}

		private void OnShowChatFilterPressed()
		{
			_showChatMessages = !_showChatMessages;
			RefreshChat();
			_chatScrollRect.verticalNormalizedPosition = 0f;
		}

		private void OnShowEventFilterPressed()
		{
			_showEventMessages = !_showEventMessages;
			RefreshChat();
			_chatScrollRect.verticalNormalizedPosition = 0f;
		}

		private void OnResearchNodeSelected(CollaborativeNode node)
		{
			if (node == null)
			{
				_interactionView.Hide();
				return;
			}
			List<OnlinePlayerID> players = new List<OnlinePlayerID>();
			_project.GetNodeCompletedPlayers(node, ref players);
			List<OnlinePlayerID> players2 = new List<OnlinePlayerID>();
			_project.GetNodeInProgressPlayers(node, ref players2);
			bool nodeIsActive = _project.LocalPlayerData.ResearchData.ActiveNode == node.NodeID;
			_interactionView.Show(node, _networkViewer, players, players2, nodeIsActive);
		}

		private void OnResearchNodeStarted(CollaborativeNode node)
		{
			if (node == null || node.Definition == null)
			{
				return;
			}
			MetagameObjective obj = _portfolio.PortfolioDataController?.PortfolioData?.ActiveObjective;
			ResearchProjectObjective researchProjectObjective = obj as ResearchProjectObjective;
			SuperBugObjective superBugObjective = obj as SuperBugObjective;
			if (researchProjectObjective != null && researchProjectObjective.ProjectID == _project.ProjectID && researchProjectObjective.NodeID == node.NodeID)
			{
				_rootMenu.MessageBox.SetupWith2Buttons(ScriptLocalization.Collaborative_GUI.AbandonObjectiveMessage_CS, ScriptLocalization.Collaborative_GUI.OK_CS, delegate
				{
					_portfolio.AbandonActiveObjective();
					Refresh();
				}, ScriptLocalization.Misc.Cancel_CS, null);
				return;
			}
			Guid projectID = _project.ProjectID;
			int nodeID = node.NodeID;
			if (researchProjectObjective != null && (projectID != researchProjectObjective.ProjectID || researchProjectObjective.NodeID != nodeID))
			{
				_rootMenu.MessageBox.SetupWith2Buttons(string.Format(ScriptLocalization.Collaborative_GUI.ChangeObjectiveCollabWarning1_CS, _project.LocalPlayerData.Definition.Name.Translation, researchProjectObjective.Definition.NameLocalised.Translation), ScriptLocalization.Collaborative_GUI.Start_CS, delegate
				{
					ResearchProjectObjective researchProjectObjective3 = new ResearchProjectObjective(_metagame, node.Definition.Objective, isReplayable: false, projectID, nodeID);
					researchProjectObjective3.Initialise();
					_portfolio.SetActiveObjective(researchProjectObjective3);
					OnResearchObjectiveStarted.InvokeSafe(researchProjectObjective3.Definition);
				}, ScriptLocalization.Misc.Cancel_CS, null);
			}
			else if (superBugObjective != null)
			{
				_rootMenu.MessageBox.SetupWith2Buttons(ScriptLocalization.Collaborative_GUI.ChangeObjectiveCollabWarning2_CS, ScriptLocalization.Collaborative_GUI.Start_CS, delegate
				{
					ResearchProjectObjective researchProjectObjective3 = new ResearchProjectObjective(_metagame, node.Definition.Objective, isReplayable: false, projectID, nodeID);
					researchProjectObjective3.Initialise();
					_portfolio.SetActiveObjective(researchProjectObjective3);
					OnResearchObjectiveStarted.InvokeSafe(researchProjectObjective3.Definition);
				}, ScriptLocalization.Misc.Cancel_CS, null);
			}
			else
			{
				ResearchProjectObjective researchProjectObjective2 = new ResearchProjectObjective(_metagame, node.Definition.Objective, isReplayable: false, projectID, nodeID);
				researchProjectObjective2.Initialise();
				_portfolio.SetActiveObjective(researchProjectObjective2);
				OnResearchObjectiveStarted.InvokeSafe(researchProjectObjective2.Definition);
			}
		}

		private void OnResearchNodeDebugUncompleted(CollaborativeNode node)
		{
			if (node != null)
			{
				_project.DEBUG_UncompleteActiveGoal(node.NodeID);
				Refresh();
			}
		}

		private void OnResearchNodeDebugCompleted(CollaborativeNode node)
		{
			if (node != null)
			{
				_project.DEBUG_CompletedActiveGoal(node.NodeID);
				Refresh();
			}
		}

		private void OnProjectDataBeginGather()
		{
		}

		private void OnProjectDataReceived()
		{
			if (_portfolio != null)
			{
				Refresh();
			}
		}

		private int CalculateNodeToCentreOn()
		{
			if (_metagame.CollaborativePortfolio.ActiveObjective is ResearchProjectObjective researchProjectObjective && researchProjectObjective.ProjectID == _project.ProjectID)
			{
				return researchProjectObjective.NodeID;
			}
			Guid? unseenCompletedProjectId = _metagame.CollaborativeMetagameData.UnseenCompletedProjectId;
			int? unseenCompletedNodeId = _metagame.CollaborativeMetagameData.UnseenCompletedNodeId;
			if (unseenCompletedNodeId.HasValue && unseenCompletedProjectId.HasValue && _project.ProjectID == unseenCompletedProjectId.Value)
			{
				return unseenCompletedNodeId.Value;
			}
			List<int> completableNodesForLocalPlayer = _networkViewer.GetCompletableNodesForLocalPlayer();
			if (completableNodesForLocalPlayer.Count > 0)
			{
				return completableNodesForLocalPlayer[0];
			}
			return 0;
		}
	}
}
