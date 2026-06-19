using System;
using System.Collections.Generic;
using System.Text;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class CollaborativeResearchTabButton : MonoBehaviour
	{
		[SerializeField]
		private GameObject _tabPanel;

		[SerializeField]
		private GameObject _projectPanel;

		[SerializeField]
		private GameObject _projectKickedText;

		[SerializeField]
		private GameObject _projectCompletedText;

		[SerializeField]
		private TMP_Text _projectNameText;

		[SerializeField]
		private GameObject _newPanel;

		[SerializeField]
		private ButtonAnimator _mainButton;

		[SerializeField]
		private DynamicButton _closeButton;

		[SerializeField]
		private GameObject _operationLockPanel;

		[SerializeField]
		private TMP_Text _operationLockMessage;

		[SerializeField]
		private GameObject _globalProjectIcon;

		[SerializeField]
		private GameObject _alertIcon;

		[SerializeField]
		private GameObject _warningIcon;

		[SerializeField]
		private GameObject _leaderIcon;

		[SerializeField]
		private GameObject _activitySpinner;

		[SerializeField]
		private TooltipSpawner _tooltip;

		[SerializeField]
		private TooltipSpawner _warningTooltip;

		public Action<Guid?> OnSelected;

		public Action<int> OnSuperBugSelected;

		public Action<Guid?> OnAbandonSelected;

		private Guid? _projectId;

		private SuperBugDefinition _superBugDefinition;

		private List<OnlinePlayerID> _deprecatedDataList;

		private CollaborativePortfolio _portfolio;

		private CollaborativeResearchMenu _rootMenu;

		private SuperBugProjectManager _superBugManager;

		public Guid? ProjectId => _projectId;

		public SuperBugDefinition SuperBugDefinition => _superBugDefinition;

		public void Initialise(CollaborativeResearchMenu rootMenu, CollaborativePortfolio portfolio, SuperBugProjectManager superBugManager)
		{
			_rootMenu = rootMenu;
			_portfolio = portfolio;
			_superBugManager = superBugManager;
			_tooltip.SetDataProvider(OnTooltip);
			_warningTooltip.SetDataProvider(OnWarningTooltip);
		}

		public void SetupWithSuperBug(SuperBugDefinition definition)
		{
			_projectId = null;
			_superBugDefinition = definition;
			_deprecatedDataList = null;
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
			GameObjectUtils.SetActive(_tabPanel, isActive: true);
			GameObjectUtils.SetActive(_projectPanel, isActive: true);
			GameObjectUtils.SetActive(_newPanel, isActive: false);
			GameObjectUtils.SetActive(_globalProjectIcon, isActive: true);
			GameObjectUtils.SetActive(_leaderIcon, isActive: false);
			GameObjectUtils.SetActive(_projectCompletedText, isActive: false);
			GameObjectUtils.SetActive(_projectKickedText, isActive: false);
			GameObjectUtils.SetActive(_closeButton.gameObject, isActive: false);
			GameObjectUtils.SetActive(_warningIcon, isActive: false);
			if (_projectNameText != null)
			{
				_projectNameText.text = definition.Name.Translation;
			}
			RefreshAlert();
		}

		public void SetupWithProject(CollaborativeProject project)
		{
			CollaborativeProjectDefinition definition = project.LocalPlayerData.Definition;
			_projectId = project.ProjectID;
			_superBugDefinition = null;
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
			GameObjectUtils.SetActive(_projectPanel, isActive: true);
			GameObjectUtils.SetActive(_tabPanel, isActive: false);
			GameObjectUtils.SetActive(_newPanel, isActive: false);
			GameObjectUtils.SetActive(_globalProjectIcon, isActive: false);
			GameObjectUtils.SetActive(_leaderIcon, project.LeaderOnlinePlayerID == OnlineManager.GetLocalPlayerID());
			bool flag = project.HasPlayerBeenKicked();
			bool flag2 = project.IsProjectCompleted();
			GameObjectUtils.SetActive(_projectCompletedText, flag2);
			GameObjectUtils.SetActive(_projectKickedText, flag && !flag2);
			bool isActive = _rootMenu.SelectedProjectId.HasValue && project.ProjectID == _rootMenu.SelectedProjectId.Value;
			GameObjectUtils.SetActive(_closeButton.gameObject, isActive);
			_projectNameText.text = definition.Name.Translation;
			GameObjectUtils.SetActive(_warningIcon, isActive: false);
			RefreshAlert();
		}

		public void SetupWithNew()
		{
			_projectId = null;
			_superBugDefinition = null;
			_deprecatedDataList = null;
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
			GameObjectUtils.SetActive(_tabPanel, isActive: false);
			GameObjectUtils.SetActive(_projectPanel, isActive: false);
			GameObjectUtils.SetActive(_newPanel, isActive: true);
			GameObjectUtils.SetActive(_globalProjectIcon, isActive: false);
			GameObjectUtils.SetActive(_warningIcon, isActive: false);
			GameObjectUtils.SetActive(_leaderIcon, isActive: false);
			RefreshAlert();
		}

		public void SetupAsHidden()
		{
			_projectId = null;
			_superBugDefinition = null;
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
			GameObjectUtils.SetActive(_tabPanel, isActive: false);
			GameObjectUtils.SetActive(_projectPanel, isActive: false);
			GameObjectUtils.SetActive(_newPanel, isActive: false);
			GameObjectUtils.SetActive(_globalProjectIcon, isActive: false);
			GameObjectUtils.SetActive(_warningIcon, isActive: false);
			RefreshAlert();
		}

		public void SetSelectState(bool isSelected)
		{
			_mainButton.CurrentState = (isSelected ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			GameObjectUtils.SetActive(_tabPanel, isSelected);
		}

		private void OnEnable()
		{
			_mainButton.Button.onPrimaryDown.AddListener(OnMainClicked);
			_closeButton.onPrimaryDown.AddListener(OnCloseClicked);
		}

		private void OnDisable()
		{
			_mainButton.Button.onPrimaryDown.RemoveListener(OnMainClicked);
			_closeButton.onPrimaryDown.RemoveListener(OnCloseClicked);
		}

		private void Update()
		{
			if (_portfolio != null && _projectId.HasValue)
			{
				bool isActive = _portfolio.AsyncOperationHandler.ContainsOperationType<CollaborativeAsyncOperationGatherData>();
				GameObjectUtils.SetActive(_activitySpinner, isActive);
			}
			else if (_superBugManager != null && _superBugDefinition != null)
			{
				GameObjectUtils.SetActive(_activitySpinner, !_superBugManager.IsProjectUpToDate);
			}
			else
			{
				GameObjectUtils.SetActive(_activitySpinner, isActive: false);
			}
		}

		private void OnMainClicked()
		{
			if (_superBugDefinition != null)
			{
				OnSuperBugSelected.InvokeSafe(_superBugDefinition.SuperBugID);
			}
			else
			{
				OnSelected.InvokeSafe(_projectId);
			}
		}

		private void OnCloseClicked()
		{
			OnAbandonSelected.InvokeSafe(_projectId);
		}

		private void OnTooltip(Tooltip tooltip)
		{
			TooltipCollaborativeProject tooltipCollaborativeProject = tooltip as TooltipCollaborativeProject;
			if (tooltipCollaborativeProject == null)
			{
				return;
			}
			if (!_projectId.HasValue && _superBugDefinition == null)
			{
				tooltipCollaborativeProject.SetData();
			}
			else if (_projectId.HasValue)
			{
				CollaborativeProject project = _portfolio.GetProject(_projectId.Value);
				if (project != null)
				{
					tooltipCollaborativeProject.SetData(project);
				}
			}
			else if (_superBugDefinition != null)
			{
				tooltipCollaborativeProject.SetData(_superBugDefinition);
			}
		}

		private void OnWarningTooltip(Tooltip tooltip)
		{
			if (_deprecatedDataList == null)
			{
				return;
			}
			StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder();
			foreach (OnlinePlayerID deprecatedData in _deprecatedDataList)
			{
				OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(deprecatedData);
				builder.AppendFormat("{0} has outdated data.", playerInfo.DisplayName).AppendLine();
			}
			tooltip.Text = builder.ToString();
			StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
		}

		public void RefreshAlert()
		{
			if (_projectId.HasValue)
			{
				if (_projectId == _rootMenu.SelectedProjectId)
				{
					GameObjectUtils.SetActive(_alertIcon, isActive: false);
					return;
				}
				CollaborativeProject project = _portfolio.GetProject(_projectId.Value);
				bool isActive = project != null && _portfolio.HasProjectGotNewData(project);
				GameObjectUtils.SetActive(_alertIcon, isActive);
			}
			else if (_superBugDefinition != null)
			{
				GameObjectUtils.SetActive(_alertIcon, _rootMenu.CollaborativeLocalData.HasGlobalProjectChanged());
			}
			else
			{
				GameObjectUtils.SetActive(_alertIcon, isActive: false);
			}
		}

		public void CheckOperationLockStatus(CollaborativeAsyncOperationHandler handler)
		{
			if (!_projectId.HasValue)
			{
				if (handler.ContainsOperationType<CollaborativeAsyncOperationCreateProject>())
				{
					_operationLockMessage.text = ScriptLocalization.Collaborative_GUI.Creating_CS;
					GameObjectUtils.SetActive(_operationLockPanel, isActive: true);
				}
				else
				{
					GameObjectUtils.SetActive(_operationLockPanel, isActive: false);
				}
				return;
			}
			CollaborativeAsyncOperation collaborativeAsyncOperation = handler.FindNextOperationRelatingToProject(_projectId.Value);
			if (collaborativeAsyncOperation == null)
			{
				GameObjectUtils.SetActive(_operationLockPanel, isActive: false);
			}
			else if (collaborativeAsyncOperation is CollaborativeAsyncOperationAbandonProject)
			{
				_operationLockMessage.text = ScriptLocalization.Collaborative_GUI.Abandoning_CS;
				GameObjectUtils.SetActive(_operationLockPanel, isActive: true);
			}
			else if (collaborativeAsyncOperation is CollaborativeAsyncOperationJoinProject)
			{
				_operationLockMessage.text = ScriptLocalization.Collaborative_GUI.Joining_CS;
				GameObjectUtils.SetActive(_operationLockPanel, isActive: true);
			}
		}
	}
}
