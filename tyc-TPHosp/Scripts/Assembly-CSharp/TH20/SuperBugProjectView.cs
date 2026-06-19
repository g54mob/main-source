using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class SuperBugProjectView : MonoBehaviour
	{
		public Action<ObjectiveDefinition> OnSuperBugObjectiveStarted;

		[SerializeField]
		private SuperBugNetworkView _networkViewer;

		[SerializeField]
		private ResearchNetworkInteractionView _interactionView;

		[SerializeField]
		private TMP_Text _projectDetailsText;

		[SerializeField]
		private GameObject _daysRemainingObject;

		[SerializeField]
		private TMP_Text _daysRemainingText;

		[SerializeField]
		private TMP_Text _yourContributionText;

		[SerializeField]
		private SuperBugRewardCollectionItem[] _rewardCollectionItems;

		[SerializeField]
		private PlayerAvatar _playerAvatar;

		[SerializeField]
		private SuperBugCompleteBanner _completionBanner;

		private CollaborativeResearchMenu _rootMenu;

		private SuperBugProjectManager _superBugManager;

		private CollaborativePortfolio _collaborativePortfolio;

		private Metagame _metagame;

		private void Start()
		{
			SuperBugNetworkView networkViewer = _networkViewer;
			networkViewer.OnNetworkNodeSelected = (Action<CollaborativeNode>)Delegate.Combine(networkViewer.OnNetworkNodeSelected, new Action<CollaborativeNode>(OnResearchNodeSelected));
			ResearchNetworkInteractionView interactionView = _interactionView;
			interactionView.OnNodeSelected = (Action<CollaborativeNode>)Delegate.Combine(interactionView.OnNodeSelected, new Action<CollaborativeNode>(OnResearchNodeStarted));
			ResearchNetworkInteractionView interactionView2 = _interactionView;
			interactionView2.OnNodeDebugCompleted = (Action<CollaborativeNode>)Delegate.Combine(interactionView2.OnNodeDebugCompleted, new Action<CollaborativeNode>(OnResearchNodeDebugCompleted));
			ResearchNetworkInteractionView interactionView3 = _interactionView;
			interactionView3.OnNodeDebugUncompleted = (Action<CollaborativeNode>)Delegate.Combine(interactionView3.OnNodeDebugUncompleted, new Action<CollaborativeNode>(OnResearchNodeDebugUncompleted));
		}

		public void OnDestroy()
		{
			SuperBugNetworkView networkViewer = _networkViewer;
			networkViewer.OnNetworkNodeSelected = (Action<CollaborativeNode>)Delegate.Remove(networkViewer.OnNetworkNodeSelected, new Action<CollaborativeNode>(OnResearchNodeSelected));
			ResearchNetworkInteractionView interactionView = _interactionView;
			interactionView.OnNodeSelected = (Action<CollaborativeNode>)Delegate.Remove(interactionView.OnNodeSelected, new Action<CollaborativeNode>(OnResearchNodeStarted));
			ResearchNetworkInteractionView interactionView2 = _interactionView;
			interactionView2.OnNodeDebugCompleted = (Action<CollaborativeNode>)Delegate.Remove(interactionView2.OnNodeDebugCompleted, new Action<CollaborativeNode>(OnResearchNodeDebugCompleted));
			ResearchNetworkInteractionView interactionView3 = _interactionView;
			interactionView3.OnNodeDebugUncompleted = (Action<CollaborativeNode>)Delegate.Remove(interactionView3.OnNodeDebugUncompleted, new Action<CollaborativeNode>(OnResearchNodeDebugUncompleted));
		}

		public void Initialise(CollaborativeResearchMenu rootMenu, Metagame metagame, SuperBugProjectManager superBugManager, CollaborativePortfolio portfolio)
		{
			_rootMenu = rootMenu;
			_metagame = metagame;
			_superBugManager = superBugManager;
			_collaborativePortfolio = portfolio;
		}

		public void SetupForProject()
		{
			_networkViewer.Setup(_superBugManager.Data, _collaborativePortfolio, _interactionView);
			_networkViewer.CentreOnNode(CalculateNodeToCentreOn());
			_projectDetailsText.text = _superBugManager.DownloadedProjectDefinition.Description.Translation;
		}

		public void Show()
		{
			base.gameObject.SetActive(value: true);
			_superBugManager.LogProjectView();
			Refresh();
		}

		public void Hide()
		{
			base.gameObject.SetActive(value: false);
			_superBugManager.LogProjectView();
		}

		public void Refresh()
		{
			_networkViewer.Refresh();
			uint expiryTimeStamp = _superBugManager.Data.Definition.ExpiryTimeStamp;
			if (expiryTimeStamp == 0)
			{
				GameObjectUtils.SetActive(_daysRemainingObject, isActive: false);
			}
			else
			{
				int serverTime = (int)OnlineManager.GetServerTime();
				uint num = (uint)Mathf.Max((float)(expiryTimeStamp - serverTime) / 86400f + 1f, 0f);
				if (num == 0)
				{
					_daysRemainingText.text = ScriptLocalization.Collaborative_GUI.ClaimRewardNow_CS;
				}
				else
				{
					_daysRemainingText.text = string.Format(ScriptLocalization.Collaborative_GUI.DaysRemaining_CS, num);
				}
				GameObjectUtils.SetActive(_daysRemainingObject, isActive: true);
			}
			_playerAvatar.PlayerID = OnlineManager.GetLocalPlayerID();
			_yourContributionText.text = string.Format(ScriptLocalization.Collaborative_GUI.YourContributionLong_CS, _superBugManager.Data.NodeCompletedByLocalPlayer.Count);
			_completionBanner.SetIsCompleted(_superBugManager.Data.IsCompleted());
			List<SuperBugNode> list = _superBugManager.Data.Definition.GatherVictoryNodes();
			int i = 0;
			foreach (SuperBugNode item in list)
			{
				if (i >= _rewardCollectionItems.Length)
				{
					break;
				}
				GameObjectUtils.SetActive(_rewardCollectionItems[i].gameObject, isActive: true);
				_rewardCollectionItems[i].Setup(_metagame, item, _networkViewer);
				i++;
			}
			for (; i < _rewardCollectionItems.Length; i++)
			{
				GameObjectUtils.SetActive(_rewardCollectionItems[i].gameObject, isActive: false);
			}
		}

		private void OnResearchNodeSelected(ResearchNetwork.Node node)
		{
			SuperBugNode superBugNode = (SuperBugNode)node;
			if (superBugNode == null)
			{
				_interactionView.Hide();
				return;
			}
			bool nodeIsActive = _collaborativePortfolio.ActiveObjective is SuperBugObjective superBugObjective && superBugObjective.NodeID == node.NodeID;
			_interactionView.Show(superBugNode, _networkViewer, null, null, nodeIsActive);
		}

		private void OnResearchNodeStarted(ResearchNetwork.Node node)
		{
			SuperBugNode superBugNode = (SuperBugNode)node;
			if (superBugNode == null)
			{
				return;
			}
			ResearchProjectObjective researchProjectObjective = _collaborativePortfolio.ActiveObjective as ResearchProjectObjective;
			if (_collaborativePortfolio.ActiveObjective is SuperBugObjective superBugObjective && superBugObjective.NodeID == superBugNode.NodeID)
			{
				_rootMenu.MessageBox.SetupWith2Buttons(ScriptLocalization.Collaborative_GUI.AbandonObjectiveMessage_CS, ScriptLocalization.Collaborative_GUI.OK_CS, delegate
				{
					_collaborativePortfolio.AbandonActiveObjective();
					Refresh();
				}, ScriptLocalization.Misc.Cancel_CS, null);
			}
			else if (researchProjectObjective != null)
			{
				_rootMenu.MessageBox.SetupWith2Buttons(ScriptLocalization.Collaborative_GUI.ChangeObjectiveGlobal_CS, ScriptLocalization.Collaborative_GUI.Start_CS, delegate
				{
					SuperBugObjective superBugObjective3 = new SuperBugObjective(_metagame, superBugNode.Definition.Objective, isReplayable: false, _superBugManager.DownloadedProjectDefinition.SuperBugID, node.NodeID);
					superBugObjective3.Initialise();
					_collaborativePortfolio.SetActiveObjective(superBugObjective3);
					OnSuperBugObjectiveStarted.InvokeSafe(superBugObjective3.Definition);
					Refresh();
				}, ScriptLocalization.Misc.Cancel_CS, null);
			}
			else
			{
				SuperBugObjective superBugObjective2 = new SuperBugObjective(_metagame, superBugNode.Definition.Objective, isReplayable: false, _superBugManager.DownloadedProjectDefinition.SuperBugID, node.NodeID);
				superBugObjective2.Initialise();
				_collaborativePortfolio.SetActiveObjective(superBugObjective2);
				OnSuperBugObjectiveStarted.InvokeSafe(superBugObjective2.Definition);
			}
			Refresh();
		}

		private int CalculateNodeToCentreOn()
		{
			int num = ((_metagame.SuperBugManager.DownloadedProjectDefinition != null) ? _metagame.SuperBugManager.DownloadedProjectDefinition.SuperBugID : 0);
			if (_metagame.CollaborativePortfolio.ActiveObjective is SuperBugObjective superBugObjective && superBugObjective.SuperBugID == num)
			{
				return superBugObjective.NodeID;
			}
			int? unseenCompletedNodeId = _metagame.CollaborativeMetagameData.UnseenCompletedNodeId;
			int? unseenCompletedSuperBugId = _metagame.CollaborativeMetagameData.UnseenCompletedSuperBugId;
			if (unseenCompletedNodeId.HasValue && unseenCompletedSuperBugId.HasValue && num == unseenCompletedSuperBugId)
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

		private void OnResearchNodeDebugCompleted(ResearchNetwork.Node node)
		{
			if (node != null)
			{
				_metagame.App.SuperBugManager.OnSuperBugObjectiveComplete(_superBugManager.DownloadedProjectDefinition.SuperBugID, node.NodeID, Objective.CompletionType.Successful);
			}
		}

		private void OnResearchNodeDebugUncompleted(ResearchNetwork.Node node)
		{
		}
	}
}
