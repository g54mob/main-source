using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ResearchNetworkDebugMenu : MenuBase
	{
		[SerializeField]
		private Button _collaborativeRefreshButton;

		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private ResearchNetworkView _networkView;

		[SerializeField]
		private SuperBugNetworkView _superBugView;

		[SerializeField]
		private ResearchNetworkInteractionView _interactionView;

		[SerializeField]
		private SuperBugCreatorPanel _creatorPanel;

		[SerializeField]
		private Button _collaborativeLeftButton;

		[SerializeField]
		private Button _collaborativeRightButton;

		[SerializeField]
		private Text _collaborativeProjectLabel;

		[SerializeField]
		private List<CollaborativeNode.VictoryNodeType> _victoryTypeMapKeys;

		[SerializeField]
		private List<Sprite> _victoryTypeMapValues;

		private readonly Dictionary<CollaborativeNode.VictoryNodeType, Sprite> _victoryTypeMap = new Dictionary<CollaborativeNode.VictoryNodeType, Sprite>();

		private App _app;

		private int _collabProjIndex;

		private void Start()
		{
			ResearchNetworkView networkView = _networkView;
			networkView.OnNetworkNodeSelected = (Action<CollaborativeNode>)Delegate.Combine(networkView.OnNetworkNodeSelected, new Action<CollaborativeNode>(OnNetworkNodeSelected));
			SuperBugNetworkView superBugView = _superBugView;
			superBugView.OnNetworkNodeSelected = (Action<CollaborativeNode>)Delegate.Combine(superBugView.OnNetworkNodeSelected, new Action<CollaborativeNode>(OnNetworkNodeSelected));
			_collaborativeRefreshButton.onClick.AddListener(OnSetupCollaborative);
			_closeButton.onClick.AddListener(CloseMenu);
			_collaborativeLeftButton.onClick.AddListener(OnCollaborativeProjectLeftPressed);
			_collaborativeRightButton.onClick.AddListener(OnCollaborativeProjectRightPressed);
			SuperBugCreatorPanel creatorPanel = _creatorPanel;
			creatorPanel.OnOpenedProject = (Action<SuperBugDefinition>)Delegate.Combine(creatorPanel.OnOpenedProject, new Action<SuperBugDefinition>(OnOpenedProject));
		}

		public void Setup(App app)
		{
			_app = app;
			_collabProjIndex = 0;
			_victoryTypeMap.Clear();
			for (int i = 0; i != Math.Min(_victoryTypeMapKeys.Count, _victoryTypeMapValues.Count); i++)
			{
				_victoryTypeMap.Add(_victoryTypeMapKeys[i], _victoryTypeMapValues[i]);
			}
			_creatorPanel.Initialise(app, _superBugView, _interactionView);
			RefreshCollaborativeDetails();
		}

		public override void Destroy()
		{
			ResearchNetworkView networkView = _networkView;
			networkView.OnNetworkNodeSelected = (Action<CollaborativeNode>)Delegate.Remove(networkView.OnNetworkNodeSelected, new Action<CollaborativeNode>(OnNetworkNodeSelected));
			SuperBugNetworkView superBugView = _superBugView;
			superBugView.OnNetworkNodeSelected = (Action<CollaborativeNode>)Delegate.Remove(superBugView.OnNetworkNodeSelected, new Action<CollaborativeNode>(OnNetworkNodeSelected));
			_collaborativeRefreshButton.onClick.RemoveListener(OnSetupCollaborative);
			_closeButton.onClick.RemoveListener(CloseMenu);
			_collaborativeLeftButton.onClick.RemoveListener(OnCollaborativeProjectLeftPressed);
			_collaborativeRightButton.onClick.RemoveListener(OnCollaborativeProjectRightPressed);
			SuperBugCreatorPanel creatorPanel = _creatorPanel;
			creatorPanel.OnOpenedProject = (Action<SuperBugDefinition>)Delegate.Remove(creatorPanel.OnOpenedProject, new Action<SuperBugDefinition>(OnOpenedProject));
		}

		private void OnSetupSuperBug(SuperBugDefinition definition)
		{
			if (definition != null)
			{
				OnNetworkNodeSelected(null);
				_superBugView.gameObject.SetActive(value: true);
				_superBugView.Setup(definition, _app.CollaborativePortfolio, _interactionView);
			}
		}

		private void OnSetupCollaborative()
		{
			if (_app.CollaborativeProjectList != null)
			{
				OnNetworkNodeSelected(null);
				CollaborativeProjectDefinition instance = _app.CollaborativeProjectList.Projects[_collabProjIndex].Instance;
				if (instance != null)
				{
					_superBugView.gameObject.SetActive(value: false);
					int hashCode = Guid.NewGuid().GetHashCode();
					int version;
					ResearchNetwork network = ResearchNetworkUtils.GetLatestNetworkGenerator(instance, out version).GenerateNetwork(hashCode);
					_networkView.gameObject.SetActive(value: true);
					_networkView.Setup(null, _app.MetagameMap.InputManager, network, _interactionView, hashCode, showAllNodes: true);
				}
			}
		}

		private void OnNetworkNodeSelected(CollaborativeNode node)
		{
			if (node != null && !(node is SuperBugNode))
			{
				_interactionView.Show(node, _networkView, new List<OnlinePlayerID>(), new List<OnlinePlayerID>(), nodeIsActive: false);
			}
		}

		private void OnCollaborativeProjectRightPressed()
		{
			_collabProjIndex = (_collabProjIndex + 1) % _app.CollaborativeProjectList.Projects.Count;
			RefreshCollaborativeDetails();
		}

		private void OnCollaborativeProjectLeftPressed()
		{
			_collabProjIndex--;
			if (_collabProjIndex < 0)
			{
				_collabProjIndex += _app.CollaborativeProjectList.Projects.Count;
			}
			RefreshCollaborativeDetails();
		}

		private void RefreshCollaborativeDetails()
		{
			CollaborativeProjectDefinition instance = _app.CollaborativeProjectList.Projects[_collabProjIndex].Instance;
			if (instance == null)
			{
				_collaborativeProjectLabel.text = "NULL - ERROR!";
			}
			else
			{
				_collaborativeProjectLabel.text = instance.Name.Translation;
			}
		}

		private void OnOpenedProject(SuperBugDefinition definition)
		{
		}
	}
}
