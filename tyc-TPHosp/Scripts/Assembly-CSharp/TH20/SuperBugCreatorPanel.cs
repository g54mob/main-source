#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	public class SuperBugCreatorPanel : MonoBehaviour
	{
		public enum PanelMode
		{
			ModeNone = 0,
			ModeCreate = 1,
			ModeMove = 2,
			ModeHierarchy = 3,
			ModeDetails = 4
		}

		public Action<SuperBugDefinition> OnOpenedProject;

		[SerializeField]
		private ButtonAnimator _createNewButton;

		[SerializeField]
		private ButtonAnimator _openButton;

		[SerializeField]
		private ButtonAnimator _openWWWButton;

		[SerializeField]
		private ButtonAnimator _openWWWDebugButton;

		[SerializeField]
		private ButtonAnimator _saveButton;

		[SerializeField]
		private ButtonAnimator _refreshButton;

		[SerializeField]
		private ButtonAnimator _createButton;

		[SerializeField]
		private ButtonAnimator _moveButton;

		[SerializeField]
		private ButtonAnimator _hierarchyButton;

		[SerializeField]
		private ButtonAnimator _detailsButton;

		[SerializeField]
		private ButtonAnimator _verifyButton;

		[SerializeField]
		private SuperBugCreateNodePanel _createNodePanel;

		[SerializeField]
		private SuperBugDetailsPanel _detailsPanel;

		[SerializeField]
		private SuperBugHierarchyPanel _hierarchyPanel;

		[SerializeField]
		private SuperBugMovePanel _movePanel;

		[SerializeField]
		private Sprite _defaultProjectIcon;

		private PanelMode _mode;

		private SuperBugDefinition _definition;

		private App _app;

		private SuperBugNetworkView _superBugNetworkView;

		private ResearchNetworkInteractionView _interactionView;

		public PanelMode Mode
		{
			get
			{
				return _mode;
			}
			set
			{
				_mode = value;
				Refresh();
			}
		}

		private void Start()
		{
			_createNewButton.Button.onPrimaryDown.AddListener(OnCreateNewPressed);
			_openButton.Button.onPrimaryDown.AddListener(OnOpenPressed);
			_openWWWButton.Button.onPrimaryDown.AddListener(OnOpenWwwPressed);
			_openWWWDebugButton.Button.onPrimaryDown.AddListener(OnOpenWwwDebugPressed);
			_saveButton.Button.onPrimaryDown.AddListener(OnSavePressed);
			_refreshButton.Button.onPrimaryDown.AddListener(OnRefreshPressed);
			_createButton.Button.onPrimaryDown.AddListener(OnCreatePressed);
			_moveButton.Button.onPrimaryDown.AddListener(OnMovePressed);
			_hierarchyButton.Button.onPrimaryDown.AddListener(OnHierarchyPressed);
			_detailsButton.Button.onPrimaryDown.AddListener(OnDetailsPressed);
			_verifyButton.Button.onPrimaryDown.AddListener(OnVerifyPressed);
			SuperBugCreateNodePanel createNodePanel = _createNodePanel;
			createNodePanel.OnDefinitionChanged = (Action)Delegate.Combine(createNodePanel.OnDefinitionChanged, new Action(OnDefinitionChanged));
			SuperBugDetailsPanel detailsPanel = _detailsPanel;
			detailsPanel.OnDefinitionChanged = (Action)Delegate.Combine(detailsPanel.OnDefinitionChanged, new Action(OnDefinitionChanged));
			SuperBugHierarchyPanel hierarchyPanel = _hierarchyPanel;
			hierarchyPanel.OnDefinitionChanged = (Action)Delegate.Combine(hierarchyPanel.OnDefinitionChanged, new Action(OnDefinitionChanged));
			SuperBugMovePanel movePanel = _movePanel;
			movePanel.OnDefinitionChanged = (Action)Delegate.Combine(movePanel.OnDefinitionChanged, new Action(OnDefinitionChanged));
		}

		private void OnDestroy()
		{
			_createNewButton.Button.onPrimaryDown.RemoveListener(OnCreateNewPressed);
			_openButton.Button.onPrimaryDown.RemoveListener(OnOpenPressed);
			_openWWWButton.Button.onPrimaryDown.RemoveListener(OnOpenWwwPressed);
			_openWWWDebugButton.Button.onPrimaryDown.RemoveListener(OnOpenWwwDebugPressed);
			_saveButton.Button.onPrimaryDown.RemoveListener(OnSavePressed);
			_refreshButton.Button.onPrimaryDown.RemoveListener(OnRefreshPressed);
			_createButton.Button.onPrimaryDown.RemoveListener(OnCreatePressed);
			_moveButton.Button.onPrimaryDown.RemoveListener(OnMovePressed);
			_hierarchyButton.Button.onPrimaryDown.RemoveListener(OnHierarchyPressed);
			_detailsButton.Button.onPrimaryDown.RemoveListener(OnDetailsPressed);
			_verifyButton.Button.onPrimaryDown.RemoveListener(OnVerifyPressed);
			SuperBugCreateNodePanel createNodePanel = _createNodePanel;
			createNodePanel.OnDefinitionChanged = (Action)Delegate.Remove(createNodePanel.OnDefinitionChanged, new Action(OnDefinitionChanged));
			SuperBugDetailsPanel detailsPanel = _detailsPanel;
			detailsPanel.OnDefinitionChanged = (Action)Delegate.Remove(detailsPanel.OnDefinitionChanged, new Action(OnDefinitionChanged));
			SuperBugHierarchyPanel hierarchyPanel = _hierarchyPanel;
			hierarchyPanel.OnDefinitionChanged = (Action)Delegate.Remove(hierarchyPanel.OnDefinitionChanged, new Action(OnDefinitionChanged));
			SuperBugMovePanel movePanel = _movePanel;
			movePanel.OnDefinitionChanged = (Action)Delegate.Remove(movePanel.OnDefinitionChanged, new Action(OnDefinitionChanged));
		}

		public void Initialise(App app, SuperBugNetworkView projectView, ResearchNetworkInteractionView interactionView)
		{
			_app = app;
			_interactionView = interactionView;
			_superBugNetworkView = projectView;
			_createNodePanel.Initialise(projectView);
			_detailsPanel.Initialise(projectView);
			_hierarchyPanel.Initialise(projectView);
			_movePanel.Initialise(projectView);
			Refresh();
		}

		private void Refresh()
		{
			RefreshTabButtons();
			RefreshPanel();
			RefreshNetwork();
		}

		private void OnCreateNewPressed()
		{
		}

		private void OnOpenWwwDebugPressed()
		{
		}

		private void OnOpenWwwPressed()
		{
		}

		private void OnOpenPressed()
		{
		}

		private void OnSavePressed()
		{
		}

		private void OnRefreshPressed()
		{
			Refresh();
		}

		private void OnCreatePressed()
		{
			Mode = PanelMode.ModeCreate;
		}

		private void OnMovePressed()
		{
			Mode = PanelMode.ModeMove;
		}

		private void OnHierarchyPressed()
		{
			Mode = PanelMode.ModeHierarchy;
		}

		private void OnDetailsPressed()
		{
			Mode = PanelMode.ModeDetails;
		}

		private void OnVerifyPressed()
		{
			RunNetworkVerification();
		}

		private void RefreshTabButtons()
		{
			if (Mode == PanelMode.ModeNone)
			{
				_createButton.CurrentState = ButtonAnimator.State.Unselectable;
				_moveButton.CurrentState = ButtonAnimator.State.Unselectable;
				_hierarchyButton.CurrentState = ButtonAnimator.State.Unselectable;
				_detailsButton.CurrentState = ButtonAnimator.State.Unselectable;
			}
			else
			{
				_createButton.CurrentState = ((Mode == PanelMode.ModeCreate) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
				_moveButton.CurrentState = ((Mode == PanelMode.ModeMove) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
				_hierarchyButton.CurrentState = ((Mode == PanelMode.ModeHierarchy) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
				_detailsButton.CurrentState = ((Mode == PanelMode.ModeDetails) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			}
		}

		private void RefreshPanel()
		{
			GameObjectUtils.SetActive(_createNodePanel.gameObject, Mode == PanelMode.ModeCreate);
			GameObjectUtils.SetActive(_movePanel.gameObject, Mode == PanelMode.ModeMove);
			GameObjectUtils.SetActive(_hierarchyPanel.gameObject, Mode == PanelMode.ModeHierarchy);
			GameObjectUtils.SetActive(_detailsPanel.gameObject, Mode == PanelMode.ModeDetails);
		}

		private void RefreshNetwork()
		{
			if (_definition != null)
			{
				_superBugNetworkView.Setup(_definition, _app.CollaborativePortfolio, _interactionView);
				_superBugNetworkView.Refresh();
			}
		}

		private void OnDefinitionChanged()
		{
			if (_definition == null)
			{
				Mode = PanelMode.ModeNone;
			}
			Refresh();
		}

		private bool RunNetworkVerification()
		{
			bool result = false;
			List<SuperBugNode> list = _definition.GatherVictoryNodes();
			if (list.Count < 1)
			{
				Logging.Warning(LogChannels.Online, "Verify Warning: Network has no victory nodes!");
				result = true;
			}
			if (list.Count > 5)
			{
				Logging.Warning(LogChannels.Online, "Verify Warning: Network has more than 5 victory nodes! 5 is the maximum!");
				result = true;
			}
			List<SuperBugNode> list2 = new List<SuperBugNode>();
			foreach (SuperBugNode item in _definition.Network)
			{
				if (!item.IsRoot)
				{
					if (item.Parent < 0)
					{
						list2.AddUnique(item);
					}
					else if (item.Parent >= _definition.Network.Count)
					{
						list2.AddUnique(item);
					}
				}
			}
			if (list2.Count > 0)
			{
				Logging.Warning(LogChannels.Online, "Verify Warning: Network has orphaned nodes! Nodes = {0}", BuildStringOfNodeIDs(list2));
				result = true;
			}
			uint serverTime = OnlineManager.GetServerTime();
			if (_definition.ExpiryTimeStamp != 0 && _definition.ExpiryTimeStamp <= serverTime)
			{
				Logging.Warning(LogChannels.Online, "Verify Warning: Expiry time stamp is before NOW. Either set the timestamp to 0 or to a time after now ( Now is {0} )", serverTime);
				result = true;
			}
			List<SuperBugNode> list3 = new List<SuperBugNode>();
			foreach (SuperBugNode item2 in _definition.Network)
			{
				if (!item2.IsRoot && item2.Definition?.Objective == null)
				{
					list3.AddUnique(item2);
				}
			}
			if (list3.Count > 0)
			{
				Logging.Warning(LogChannels.Online, "Verify Warning: Network has nodes without objectives! Nodes = {0}", BuildStringOfNodeIDs(list3));
				result = true;
			}
			List<SuperBugNode> list4 = new List<SuperBugNode>();
			foreach (SuperBugNode item3 in _definition.Network)
			{
				if (!item3.IsRoot && item3.CompletionsRequired <= 0)
				{
					list4.AddUnique(item3);
				}
			}
			if (list4.Count > 0)
			{
				Logging.Warning(LogChannels.Online, "Verify Warning: Network has nodes with completions counts of 0 or less! Nodes = {0}", BuildStringOfNodeIDs(list4));
				result = true;
			}
			List<SuperBugNode> list5 = new List<SuperBugNode>();
			foreach (SuperBugNode item4 in list)
			{
				if (item4.Rewards.Count <= 0)
				{
					list5.AddUnique(item4);
				}
			}
			if (list5.Count > 0)
			{
				Logging.Warning(LogChannels.Online, "Verify Warning: Network has victory nodes without rewards! Nodes = {0}", BuildStringOfNodeIDs(list5));
				result = true;
			}
			List<CollaborativeNode.VictoryNodeType> list6 = (from x in list
				group x by x.VictoryType into x
				where x.Count() > 1
				select x.Key).ToList();
			if (list6.Count > 0)
			{
				Logging.Warning(LogChannels.Online, "Verify Warning: Network has duplicate victory nodes types! Nodes = {0}", BuildStringOfVictoryTypes(list6));
				result = true;
			}
			List<SuperBugNode> list7 = new List<SuperBugNode>();
			foreach (SuperBugNode item5 in _definition.Network)
			{
				if (!item5.IsRoot && !item5.IsVictoryNode && item5.Definition.Icon == null)
				{
					list7.AddUnique(item5);
				}
			}
			if (list7.Count > 0)
			{
				Logging.Warning(LogChannels.Online, "Verify Warning: Network non-victory nodes without icons! Nodes = {0}", BuildStringOfNodeIDs(list7));
				result = true;
			}
			if (_definition.Network.Count > 38)
			{
				Logging.Warning(LogChannels.Online, "Verify Warning: There are {0} nodes in total but you are only allowed {1} (including the root node)", _definition.Network.Count, 38);
				result = true;
			}
			return result;
		}

		private string BuildStringOfNodeIDs(List<SuperBugNode> nodeList)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (SuperBugNode node in nodeList)
			{
				stringBuilder.Append(node.NodeID).Append(",");
			}
			return stringBuilder.ToString();
		}

		private string BuildStringOfVictoryTypes(List<CollaborativeNode.VictoryNodeType> victoryTypeList)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (CollaborativeNode.VictoryNodeType victoryType in victoryTypeList)
			{
				stringBuilder.Append(victoryType).Append(",");
			}
			return stringBuilder.ToString();
		}
	}
}
