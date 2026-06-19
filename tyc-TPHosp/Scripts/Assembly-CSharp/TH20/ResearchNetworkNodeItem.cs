using System;
using System.Collections.Generic;
using System.Text;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ResearchNetworkNodeItem : MonoBehaviour
	{
		public enum VisualState
		{
			Hidden = 0,
			Discovered = 1,
			InProgressFriend = 2,
			InProgressLocal = 3,
			CompletedLocal = 4,
			Completed = 5
		}

		[SerializeField]
		private Image _nodeBackground;

		[SerializeField]
		private Image _nodeIcon;

		[SerializeField]
		private Image _nodeRootIcon;

		[SerializeField]
		private Image _nodeRadialProgress;

		[SerializeField]
		private Image _nodeActiveImage;

		[SerializeField]
		private Image _nodeCompletedIcon;

		[SerializeField]
		private GameObject _rootNodeGameObject;

		[SerializeField]
		private GameObject _isTimedObject;

		[SerializeField]
		private GameObject _nodeRadialProgressObject;

		[SerializeField]
		private GameObject _requiredTextObject;

		[SerializeField]
		private CanvasGroup _requiredTextCanvasGroup;

		[SerializeField]
		private TMP_Text _requiredText;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private GameObject _victoryIconGameObject;

		[SerializeField]
		private Image _victoryIcon;

		[SerializeField]
		private GameObject _deadEndGameObject;

		[SerializeField]
		private GameObject _undiscoveredNodeGameObject;

		[SerializeField]
		private GameObject _connectorPrefab;

		[SerializeField]
		private Sprite _unselectedBackgroundSprite;

		[SerializeField]
		private Sprite _selectedBackgroundSprite;

		[SerializeField]
		private TooltipSpawner _tooltip;

		[SerializeField]
		private GameObject _avatarsGameObject;

		[SerializeField]
		private PlayerAvatar[] _avatars;

		[SerializeField]
		private Animator _animator;

		[NonSerialized]
		public Action<CollaborativeNode> OnClicked;

		private CollaborativeProject _project;

		private IResearchNetworkState _networkState;

		private ResearchNetworkConnectorItem _connectorItem;

		public CollaborativeNode Node { get; private set; }

		private bool IsRootNode
		{
			get
			{
				if (Node != null)
				{
					return Node.IsRoot;
				}
				return false;
			}
		}

		private void Start()
		{
			_button.onPrimaryDown.AddListener(OnPressed);
			_tooltip.SetDataProvider(OnTooltip);
		}

		private void OnDisable()
		{
			if (_connectorItem != null)
			{
				GameObjectUtils.SetActive(_connectorItem.gameObject, isActive: false);
			}
		}

		private void OnDestroy()
		{
			_button.onPrimaryDown.RemoveListener(OnPressed);
			_tooltip.SetDataProvider(null);
			if (_connectorItem != null)
			{
				UnityEngine.Object.Destroy(_connectorItem);
				_connectorItem = null;
			}
		}

		public void Initialise(CollaborativeProject project, IResearchNetworkState networkState, Transform connectorParentObject)
		{
			_project = project;
			_networkState = networkState;
			PlayerAvatar[] avatars = _avatars;
			for (int i = 0; i < avatars.Length; i++)
			{
				avatars[i].SetupForCollaboratorTooltip(networkState, null);
			}
			if (_connectorItem == null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(_connectorPrefab, connectorParentObject.transform, worldPositionStays: false);
				_connectorItem = gameObject.GetComponent<ResearchNetworkConnectorItem>();
			}
		}

		public void RefreshSelectedState()
		{
			_nodeBackground.overrideSprite = ((_networkState.GetSelectedNodeID() == Node.NodeID) ? _selectedBackgroundSprite : _unselectedBackgroundSprite);
		}

		public void Refresh(bool isInProgress)
		{
			GameObjectUtils.SetActive(_nodeActiveImage.gameObject, isInProgress);
			RefreshSelectedState();
			RefreshVisualState();
		}

		private void RefreshVisualState()
		{
			if (Node == null)
			{
				_animator.SetInteger("State", 0);
				return;
			}
			if (IsRootNode)
			{
				_animator.SetInteger("State", 1);
				return;
			}
			_connectorItem.Refresh();
			_nodeRadialProgress.fillAmount = (float)Node.NumCompletions / (float)Node.CompletionsRequired;
			RefreshAvatarPictures();
			VisualState value = VisualState.Hidden;
			switch (Node.Status)
			{
			case CollaborativeNode.State.Hidden:
				_button.enabled = false;
				value = VisualState.Hidden;
				break;
			case CollaborativeNode.State.Discovered:
			case CollaborativeNode.State.Debug:
			{
				_button.enabled = true;
				List<OnlinePlayerID> playerAttemptingNode = _networkState.GetPlayerAttemptingNode(Node.NodeID);
				value = ((!_networkState.IsNodeCompletedByLocalPlayer(Node.NodeID)) ? ((!_networkState.IsLocalPlayerAttemptingNode(Node.NodeID)) ? ((playerAttemptingNode == null || playerAttemptingNode.Count <= 0) ? VisualState.Discovered : VisualState.InProgressFriend) : VisualState.InProgressLocal) : VisualState.CompletedLocal);
				break;
			}
			case CollaborativeNode.State.Completed:
				_button.enabled = true;
				value = VisualState.Completed;
				break;
			}
			_animator.SetInteger("State", (int)value);
		}

		private void RefreshAvatarPictures()
		{
			if (_project == null)
			{
				for (int i = 0; i < _avatars.Length; i++)
				{
					GameObjectUtils.SetActive(_avatars[i].gameObject, isActive: false);
				}
				return;
			}
			List<OnlinePlayerID> players = new List<OnlinePlayerID>();
			_project.GetNodeInProgressPlayers(Node, ref players);
			for (int j = 0; j < _avatars.Length; j++)
			{
				if (j >= players.Count)
				{
					GameObjectUtils.SetActive(_avatars[j].gameObject, isActive: false);
					continue;
				}
				_avatars[j].PlayerID = players[j];
				GameObjectUtils.SetActive(_avatars[j].gameObject, isActive: true);
			}
		}

		public void Setup(CollaborativeNode node, IResearchNetworkState networkState)
		{
			Node = node;
			if (Node == null || IsRootNode)
			{
				_button.enabled = false;
				_nodeIcon.overrideSprite = null;
				_nodeRootIcon.overrideSprite = _networkState?.GetRootNodeSprite();
				_victoryIcon.overrideSprite = null;
				GameObjectUtils.SetActive(_nodeIcon.gameObject, isActive: false);
				GameObjectUtils.SetActive(_rootNodeGameObject, isActive: true);
				GameObjectUtils.SetActive(_victoryIconGameObject, isActive: false);
				GameObjectUtils.SetActive(_nodeRadialProgressObject, isActive: false);
				GameObjectUtils.SetActive(_requiredTextObject.gameObject, isActive: false);
				GameObjectUtils.SetActive(_isTimedObject, isActive: false);
				GameObjectUtils.SetActive(_nodeCompletedIcon.gameObject, isActive: false);
				GameObjectUtils.SetActive(_victoryIconGameObject, isActive: false);
				GameObjectUtils.SetActive(_deadEndGameObject, isActive: false);
				GameObjectUtils.SetActive(_undiscoveredNodeGameObject, isActive: false);
				GameObjectUtils.SetActive(_avatarsGameObject, isActive: false);
				GameObjectUtils.SetActive(_connectorItem.gameObject, isActive: false);
			}
			else
			{
				_button.enabled = true;
				_nodeIcon.overrideSprite = node.Definition.Icon;
				_nodeRootIcon.overrideSprite = null;
				_victoryIcon.overrideSprite = networkState.GetVictoryNodeSprite(node.NodeID);
				_requiredText.text = node.Definition.CompletionsRequired.ToString();
				GameObjectUtils.SetActive(_nodeIcon.gameObject, isActive: true);
				GameObjectUtils.SetActive(_rootNodeGameObject, isActive: false);
				GameObjectUtils.SetActive(_victoryIconGameObject, node.IsVictoryNode);
				GameObjectUtils.SetActive(_nodeRadialProgressObject, isActive: true);
				GameObjectUtils.SetActive(_requiredTextObject.gameObject, isActive: true);
				GameObjectUtils.SetActive(_isTimedObject, node.Definition.Objective != null && node.Definition.Objective.IsTimed);
				GameObjectUtils.SetActive(_nodeCompletedIcon.gameObject, isActive: true);
				GameObjectUtils.SetActive(_deadEndGameObject, node.Children.Count <= 0 && !node.IsVictoryNode && node.Status != CollaborativeNode.State.Debug);
				GameObjectUtils.SetActive(_undiscoveredNodeGameObject, ShouldShowUndiscoveredNode());
				GameObjectUtils.SetActive(_avatarsGameObject, isActive: true);
				GameObjectUtils.SetActive(_connectorItem.gameObject, isActive: true);
			}
		}

		public void SetupConnectors(IResearchNetworkState networkState)
		{
			if (Node == null || IsRootNode)
			{
				return;
			}
			ResearchNetwork.Node parentNode = networkState.GetParentNode(Node.NodeID);
			if (parentNode != null)
			{
				ResearchNetworkNodeItem nodeUIItem = networkState.GetNodeUIItem(parentNode.NodeID);
				if (nodeUIItem != null)
				{
					GameObjectUtils.SetActive(_connectorItem.gameObject, isActive: true);
					_connectorItem.Setup(networkState, nodeUIItem, this);
				}
				else
				{
					GameObjectUtils.SetActive(_connectorItem.gameObject, isActive: false);
				}
			}
			else
			{
				GameObjectUtils.SetActive(_connectorItem.gameObject, isActive: false);
			}
		}

		private void OnPressed()
		{
			OnClicked.InvokeSafe(Node);
		}

		public bool IsCompleted()
		{
			return Node.Status == CollaborativeNode.State.Completed;
		}

		private void OnTooltip(Tooltip tooltip)
		{
			ObjectiveDefinition objectiveDefinition = Node?.Definition?.Objective;
			if (objectiveDefinition != null && (Node.Status == CollaborativeNode.State.Discovered || Node.Status == CollaborativeNode.State.Completed || Node.Status == CollaborativeNode.State.Debug))
			{
				bool num = _networkState.IsNodeCompleted(Node.NodeID);
				bool flag = _networkState.IsNodeCompletedByLocalPlayer(Node.NodeID);
				bool flag2 = _project != null && _project.LocalPlayerData.ResearchData.ActiveNode == Node.NodeID;
				int numNodeCompletions = _networkState.GetNumNodeCompletions(Node.NodeID);
				StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder();
				builder.AppendFormat("<b>{0}</b>", objectiveDefinition.NameLocalised.Translation).AppendLine();
				if (num)
				{
					builder.AppendFormat("<size=85%>{0}</size>", ScriptLocalization.Collaborative_GUI.Completed_CS).AppendLine();
				}
				else
				{
					string translation = LocalizationManager.GetTranslation("Collaborative/PlayersCompleted_Node_Tooltip");
					builder.AppendFormat(translation, numNodeCompletions, Node.CompletionsRequired).AppendLine();
				}
				if (flag)
				{
					builder.AppendFormat("<color=#1fdd1f>{0}</color>", ScriptLocalization.Collaborative.Tooltip_CompletedThis_CS).AppendLine();
				}
				else if (flag2)
				{
					builder.AppendLine(ScriptLocalization.Tooltip.ResearchNetwork_InProgress_CS);
				}
				tooltip.Text = builder.ToString();
				StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
			}
		}

		private bool ShouldShowUndiscoveredNode()
		{
			if (Node.Status == CollaborativeNode.State.Debug)
			{
				return false;
			}
			List<ResearchNetwork.Node> childList = new List<ResearchNetwork.Node>();
			_networkState.GetAllNodeChildren(Node.NodeID, ref childList);
			for (int i = 0; i < childList.Count; i++)
			{
				if (!(childList[i] is CollaborativeNode collaborativeNode))
				{
					return false;
				}
				if (collaborativeNode.Status != CollaborativeNode.State.Hidden)
				{
					return false;
				}
			}
			return true;
		}
	}
}
