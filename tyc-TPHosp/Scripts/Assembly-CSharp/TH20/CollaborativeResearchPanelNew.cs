using System;
using System.Collections.Generic;
using FullInspector;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class CollaborativeResearchPanelNew : CollaborativeResearchPanel
	{
		[SerializeField]
		private GameObject _inviteItemPrefab;

		[SerializeField]
		private GameObject _newProjectItemPrefab;

		[SerializeField]
		private TMP_Text _invitesTitle;

		[SerializeField]
		private GameObject _invitesPanel;

		[SerializeField]
		private TMP_Text _newProjectTitle;

		[SerializeField]
		private GameObject _newProjectsPanel;

		[SerializeField]
		private TMP_Text _projectTitleText;

		[SerializeField]
		private TMP_Text _projectLeaderText;

		[SerializeField]
		private TMP_Text _projectDescriptionText;

		[SerializeField]
		private TMP_Text _projectRewardsText;

		[SerializeField]
		private GameObject _projectWarningGameObject;

		[SerializeField]
		private GameObject _projectCollaboratorsParentObject;

		[SerializeField]
		private PlayerAvatar[] _projectCollaboratorsList;

		[SerializeField]
		private ObjectiveRewardItem[] _projectRewardItems;

		[SerializeField]
		private DynamicButton _acceptButton;

		[SerializeField]
		private DynamicButton _rejectButton;

		[SerializeField]
		private DynamicButton _startProjectButton;

		private ButtonAnimator _startProjectButtonAnimator;

		private readonly List<CollaborationNewItem> _newProjectItems = new List<CollaborationNewItem>();

		private readonly List<CollaborationInviteItem> _inviteItems = new List<CollaborationInviteItem>();

		private CollaborativeProjectDefinition _selectedCreateNewItem;

		private Guid? _selectedInviteProjectId;

		public Action<CollaborativeProjectDefinition> OnNewProjectSelected;

		public Action<Guid?> OnJoinProjectSelected;

		private CollaborativeResearchMenu _rootMenu;

		private bool _previousShowInvites;

		private void Awake()
		{
			_startProjectButtonAnimator = _startProjectButton.GetComponent<ButtonAnimator>();
		}

		protected override void OnEnable()
		{
			_acceptButton.onPrimaryDown.AddListener(OnAcceptPressed);
			_rejectButton.onPrimaryDown.AddListener(OnRejectPressed);
			_startProjectButton.onPrimaryDown.AddListener(OnStartProjectPressed);
		}

		protected override void OnDisable()
		{
			_acceptButton.onPrimaryDown.RemoveListener(OnAcceptPressed);
			_rejectButton.onPrimaryDown.RemoveListener(OnRejectPressed);
			_startProjectButton.onPrimaryDown.RemoveListener(OnStartProjectPressed);
		}

		public override void Hide()
		{
			foreach (CollaborativeProjectData item in Portfolio.ProjectsInvitedTo)
			{
				Portfolio.LogLastView(item.ProjectID);
			}
			base.Hide();
		}

		public void Initialise(CollaborativePortfolio portfolio, CollaborativeResearchMenu rootMenu)
		{
			Initialise(portfolio);
			_rootMenu = rootMenu;
		}

		public override void SetupForProject(Guid? projectId)
		{
			base.SetupForProject(projectId);
			if (_rootMenu.ShowInvites != _previousShowInvites)
			{
				_selectedCreateNewItem = null;
				_selectedInviteProjectId = null;
			}
			_previousShowInvites = _rootMenu.ShowInvites;
		}

		public override void OnGetLatestCompleted()
		{
			Refresh();
		}

		public override void Show()
		{
			Refresh();
			base.Show();
		}

		private void Refresh()
		{
			RefreshInviteItems();
			RefreshNewProjectItems();
			RefreshHighlight();
			RefreshDescription();
		}

		private void RefreshNewProjectItems()
		{
			if (_rootMenu.ShowInvites)
			{
				return;
			}
			for (int i = 0; i < _inviteItems.Count; i++)
			{
				GameObjectUtils.SetActive(_inviteItems[i].gameObject, isActive: false);
			}
			GameObjectUtils.SetActive(_newProjectTitle.gameObject, isActive: true);
			GameObjectUtils.SetActive(_invitesTitle.gameObject, isActive: false);
			int num = Portfolio.CollaborativeProjectList.Projects.Count - _newProjectItems.Count;
			for (int j = 0; j < num; j++)
			{
				GameObject obj = UnityEngine.Object.Instantiate(_newProjectItemPrefab);
				CollaborationNewItem component = obj.GetComponent<CollaborationNewItem>();
				component.OnItemSelected = (Action<CollaborationNewItem>)Delegate.Combine(component.OnItemSelected, new Action<CollaborationNewItem>(OnCreateNewProjectSelected));
				component.Initialise(Portfolio);
				obj.transform.SetParent(_newProjectsPanel.transform, worldPositionStays: false);
				_newProjectItems.Add(component);
			}
			for (int k = 0; k < _newProjectItems.Count; k++)
			{
				CollaborationNewItem collaborationNewItem = _newProjectItems[k];
				if (k >= Portfolio.CollaborativeProjectList.Projects.Count)
				{
					collaborationNewItem.gameObject.SetActive(value: false);
					continue;
				}
				CollaborativeProjectDefinition instance = Portfolio.CollaborativeProjectList.Projects[k].Instance;
				if (!CheckProjectPrerequisites(instance))
				{
					collaborationNewItem.gameObject.SetActive(value: false);
					continue;
				}
				collaborationNewItem.ProjectDefinition = instance;
				collaborationNewItem.gameObject.SetActive(value: true);
			}
		}

		private void RefreshInviteItems()
		{
			if (!_rootMenu.ShowInvites)
			{
				return;
			}
			if (_selectedInviteProjectId.HasValue && Portfolio.GetInviteData(_selectedInviteProjectId.Value) == null)
			{
				_selectedInviteProjectId = null;
			}
			for (int i = 0; i < _newProjectItems.Count; i++)
			{
				GameObjectUtils.SetActive(_newProjectItems[i].gameObject, isActive: false);
			}
			GameObjectUtils.SetActive(_newProjectTitle.gameObject, isActive: false);
			GameObjectUtils.SetActive(_invitesTitle.gameObject, isActive: true);
			int num = Portfolio.ProjectsInvitedTo.Count - _inviteItems.Count;
			for (int j = 0; j < num; j++)
			{
				GameObject obj = UnityEngine.Object.Instantiate(_inviteItemPrefab);
				CollaborationInviteItem component = obj.GetComponent<CollaborationInviteItem>();
				component.OnItemSelected = (Action<CollaborationInviteItem>)Delegate.Combine(component.OnItemSelected, new Action<CollaborationInviteItem>(OnInviteItemSelected));
				component.Initialise(Portfolio);
				obj.transform.SetParent(_invitesPanel.transform, worldPositionStays: false);
				_inviteItems.Add(component);
			}
			for (int k = 0; k < _inviteItems.Count; k++)
			{
				CollaborationInviteItem collaborationInviteItem = _inviteItems[k];
				if (k >= Portfolio.ProjectsInvitedTo.Count)
				{
					collaborationInviteItem.gameObject.SetActive(value: false);
					continue;
				}
				CollaborativeProjectData collaborativeProjectData = Portfolio.ProjectsInvitedTo[k];
				if (Portfolio.GetProject(collaborativeProjectData.ProjectID) != null)
				{
					collaborationInviteItem.gameObject.SetActive(value: false);
					continue;
				}
				collaborationInviteItem.ProjectData = collaborativeProjectData;
				collaborationInviteItem.gameObject.SetActive(value: true);
				uint lastViewTimestamp = Portfolio.GetLastViewTimestamp(collaborationInviteItem.ProjectData.ProjectID);
				collaborationInviteItem.ProjectData.InviteTimestamps.TryGetValue(OnlineManager.GetLocalPlayerID(), out var value);
				collaborationInviteItem.AlertImage.gameObject.SetActive(lastViewTimestamp < value);
			}
		}

		private void RefreshHighlight()
		{
			for (int i = 0; i < _newProjectItems.Count; i++)
			{
				CollaborationNewItem collaborationNewItem = _newProjectItems[i];
				if (!(collaborationNewItem == null))
				{
					collaborationNewItem.ButtonState = ((collaborationNewItem.ProjectDefinition == _selectedCreateNewItem) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
				}
			}
			for (int j = 0; j < _inviteItems.Count; j++)
			{
				CollaborationInviteItem collaborationInviteItem = _inviteItems[j];
				if (collaborationInviteItem?.ProjectData != null)
				{
					Guid projectID = collaborationInviteItem.ProjectData.ProjectID;
					Guid? selectedInviteProjectId = _selectedInviteProjectId;
					collaborationInviteItem.ButtonState = ((projectID == selectedInviteProjectId) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
				}
			}
		}

		private void RefreshDescription()
		{
			CollaborativeProjectDefinition collaborativeProjectDefinition = _selectedCreateNewItem;
			CollaborativeProjectData collaborativeProjectData = null;
			if (collaborativeProjectDefinition == null && _selectedInviteProjectId.HasValue)
			{
				collaborativeProjectData = Portfolio.GetInviteData(_selectedInviteProjectId.Value);
				if (collaborativeProjectData != null)
				{
					collaborativeProjectDefinition = collaborativeProjectData.Definition;
				}
			}
			if (collaborativeProjectDefinition == null)
			{
				_projectTitleText.text = string.Empty;
				_projectLeaderText.text = string.Empty;
				_projectDescriptionText.text = string.Empty;
				GameObjectUtils.SetActive(_projectRewardsText.gameObject, isActive: false);
				GameObjectUtils.SetActive(_acceptButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_rejectButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_startProjectButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_projectWarningGameObject, isActive: false);
				GameObjectUtils.SetActive(_projectCollaboratorsParentObject, isActive: false);
				RefreshProjectRewardItems(null);
				return;
			}
			_projectTitleText.text = collaborativeProjectDefinition.Name.Translation;
			GameObjectUtils.SetActive(_projectRewardsText.gameObject, isActive: true);
			_projectDescriptionText.text = collaborativeProjectDefinition.Description.Translation;
			RefreshCollaboratorAvatars();
			RefreshProjectRewardItems(collaborativeProjectDefinition);
			OnlinePlayerInfo onlinePlayerInfo = ((collaborativeProjectData != null) ? OnlineManager.GetPlayerInfo(collaborativeProjectData.LeaderOnlinePlayerID) : null);
			if (Portfolio.PortfolioDataController != null && Portfolio.PortfolioDataController.GetProjectDataCount() >= CollaborativePortfolioDataController.MaxCollaborativeProjects)
			{
				GameObjectUtils.SetActive(_projectWarningGameObject, isActive: true);
				GameObjectUtils.SetActive(_acceptButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_rejectButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_startProjectButton.gameObject, isActive: false);
				_projectLeaderText.text = ((collaborativeProjectData != null) ? $"Leader: {onlinePlayerInfo.DisplayName}" : string.Empty);
				return;
			}
			GameObjectUtils.SetActive(_projectWarningGameObject, isActive: false);
			if (collaborativeProjectData != null)
			{
				_projectLeaderText.text = $"Leader: {onlinePlayerInfo.DisplayName}";
				GameObjectUtils.SetActive(_acceptButton.gameObject, isActive: true);
				GameObjectUtils.SetActive(_rejectButton.gameObject, isActive: true);
				GameObjectUtils.SetActive(_startProjectButton.gameObject, isActive: false);
			}
			else
			{
				_projectLeaderText.text = string.Empty;
				GameObjectUtils.SetActive(_acceptButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_rejectButton.gameObject, isActive: false);
				GameObjectUtils.SetActive(_startProjectButton.gameObject, isActive: true);
				bool flag = Portfolio.PortfolioDataController != null && !Portfolio.PortfolioDataController.IsUploading;
				_startProjectButtonAnimator.CurrentState = ((!flag) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
		}

		private bool CheckProjectPrerequisites(CollaborativeProjectDefinition definition)
		{
			if (definition == null)
			{
				return true;
			}
			if (definition.IsDebugProject)
			{
				return false;
			}
			if (Portfolio.IsDebugUnlock)
			{
				return true;
			}
			if (Portfolio.IsResearchProjectTypeCompleted(definition))
			{
				return true;
			}
			foreach (SharedInstance<CollaborativeProjectDefinition> projectPrerequisite in definition.ProjectPrerequisites)
			{
				if (projectPrerequisite.IsNull())
				{
					return false;
				}
				if (!Portfolio.IsResearchProjectTypeCompleted(projectPrerequisite.Instance))
				{
					return false;
				}
			}
			return true;
		}

		private void RefreshCollaboratorAvatars()
		{
			if (!_selectedInviteProjectId.HasValue)
			{
				GameObjectUtils.SetActive(_projectCollaboratorsParentObject, isActive: false);
				return;
			}
			CollaborativeProjectData inviteData = Portfolio.GetInviteData(_selectedInviteProjectId.Value);
			if (inviteData == null)
			{
				GameObjectUtils.SetActive(_projectCollaboratorsParentObject, isActive: false);
				return;
			}
			GameObjectUtils.SetActive(_projectCollaboratorsParentObject, isActive: true);
			int num = 0;
			foreach (KeyValuePair<OnlinePlayerID, Guid> collaborator in inviteData.Collaborators)
			{
				if (num >= _projectCollaboratorsList.Length)
				{
					break;
				}
				_projectCollaboratorsList[num].PlayerID = collaborator.Key;
				GameObjectUtils.SetActive(_projectCollaboratorsList[num].gameObject, isActive: true);
				num++;
			}
			for (int i = num; i < _projectCollaboratorsList.Length; i++)
			{
				_projectCollaboratorsList[i].PlayerID = OnlinePlayerID.Nil;
				GameObjectUtils.SetActive(_projectCollaboratorsList[i].gameObject, isActive: false);
			}
		}

		private void RefreshProjectRewardItems(CollaborativeProjectDefinition definition)
		{
			if (definition == null)
			{
				for (int i = 0; i < _projectRewardItems.Length; i++)
				{
					GameObjectUtils.SetActive(_projectRewardItems[i].gameObject, isActive: false);
				}
				return;
			}
			for (int j = 0; j < _projectRewardItems.Length; j++)
			{
				if (j >= definition.CompletionRewards.Length)
				{
					GameObjectUtils.SetActive(_projectRewardItems[j].gameObject, isActive: false);
					continue;
				}
				_projectRewardItems[j].Setup(definition.CompletionRewards[j]);
				GameObjectUtils.SetActive(_projectRewardItems[j].gameObject, isActive: true);
			}
		}

		private void OnCreateNewProjectSelected(CollaborationNewItem createNewItem)
		{
			if (!(createNewItem == null))
			{
				_selectedCreateNewItem = createNewItem.ProjectDefinition;
				_selectedInviteProjectId = null;
				RefreshHighlight();
				RefreshDescription();
			}
		}

		private void OnInviteItemSelected(CollaborationInviteItem inviteItem)
		{
			if (!(inviteItem == null))
			{
				_selectedCreateNewItem = null;
				_selectedInviteProjectId = inviteItem.ProjectData.ProjectID;
				Portfolio.LogLastView(inviteItem.ProjectData.ProjectID);
				RefreshHighlight();
				RefreshDescription();
			}
		}

		private void OnAcceptPressed()
		{
			if (_selectedInviteProjectId.HasValue)
			{
				OnJoinProjectSelected.InvokeSafe(_selectedInviteProjectId.Value);
				Portfolio.RequestGatherData();
				_selectedInviteProjectId = null;
			}
		}

		private void OnRejectPressed()
		{
			if (_selectedInviteProjectId.HasValue)
			{
				Portfolio.RemoveInvite(_selectedInviteProjectId.Value);
				_selectedInviteProjectId = null;
				Refresh();
			}
		}

		private void OnStartProjectPressed()
		{
			if (_selectedCreateNewItem != null)
			{
				OnNewProjectSelected.InvokeSafe(_selectedCreateNewItem);
			}
		}
	}
}
