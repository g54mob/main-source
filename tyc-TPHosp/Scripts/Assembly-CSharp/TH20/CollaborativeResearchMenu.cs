#define LOG_LEVEL_VERBOSE
using System;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class CollaborativeResearchMenu : AnimatedMenuBase, IPauseTimeMenu
	{
		[SerializeField]
		private CollaborativeResearchTabs _tabs;

		[SerializeField]
		private CollaborativeResearchPanelNew _panelNew;

		[SerializeField]
		private CollaborativeResearchPanelProject _panelProject;

		[SerializeField]
		private CollaborativeResearchPanelGlobal _panelGlobal;

		[SerializeField]
		private CollaborativeResearchMessageBox _messageBox;

		[SerializeField]
		private CollaborativeResearchTutorialBox _tutorialBox;

		[SerializeField]
		private GameObject _noDataPanel;

		[SerializeField]
		private GameObject _errorResponseDialog;

		[SerializeField]
		private TMP_Text _errorResponseText;

		[SerializeField]
		private DynamicButton _errorRetryButton;

		[SerializeField]
		private GameObject _gatheringDataPanel;

		[SerializeField]
		private GameObject _gatheringDataSpinner;

		[SerializeField]
		private GameObject _gatheringDataGlobalPanel;

		[SerializeField]
		private DynamicButton _debugModeButton;

		[SerializeField]
		private Sprite _debugModeActiveSprite;

		[SerializeField]
		private Sprite _debugModeInactiveSprite;

		[SerializeField]
		private DynamicButton _deleteDataButton;

		[SerializeField]
		private string _deleteDataTitleLoc;

		[SerializeField]
		private string _deleteDataBodyLoc;

		[SerializeField]
		private string _deleteDataCompleteLoc;

		[SerializeField]
		private TextMeshProUGUI _chatToggleButtonLabel;

		private CollaborativeResearchPanel _currentPanel;

		private App _app;

		private CollaborativePortfolio _portfolio;

		private SuperBugProjectManager _superBugManager;

		private int? _previousSuperBugId;

		private int? _selectedSuperBugId;

		private Guid? _previousProjectId;

		private Guid? _selectedProjectId;

		private bool _showInvites;

		private const float kGetLatestInterval = 300f;

		private float _getLatestTimer = 300f;

		private bool _isGetLatestTimerActive = true;

		private bool _areTabsInitialised;

		private bool _delegatesInitialised;

		public CollaborativeMetagameData CollaborativeLocalData => _app?.Metagame?.CollaborativeMetagameData;

		public CollaborativeResearchMessageBox MessageBox => _messageBox;

		public CollaborativeResearchTutorialBox TutorialBox => _tutorialBox;

		public int? SelectedSuperBugId => _selectedSuperBugId;

		public Guid? SelectedProjectId => _selectedProjectId;

		public bool ShowInvites => _showInvites;

		public void Initialise(App app)
		{
			_app = app;
			_portfolio = app.CollaborativePortfolio;
			_superBugManager = app.SuperBugManager;
			_previousProjectId = null;
			_previousSuperBugId = null;
			_tutorialBox.Initialise(app);
			string chat = ScriptLocalization.Collaborative_GUI.Chat;
			_chatToggleButtonLabel.SetText(chat);
			CollaborativeMetagameData collaborativeMetagameData = _app?.Metagame?.CollaborativeMetagameData;
			if (collaborativeMetagameData != null)
			{
				if (collaborativeMetagameData.UnseenCompletedProjectId.HasValue)
				{
					_selectedProjectId = collaborativeMetagameData.UnseenCompletedProjectId;
					_selectedSuperBugId = null;
				}
				else if (collaborativeMetagameData.UnseenCompletedSuperBugId.HasValue)
				{
					_selectedProjectId = null;
					_selectedSuperBugId = collaborativeMetagameData.UnseenCompletedSuperBugId;
				}
				else
				{
					MetagameObjective metagameObjective = _portfolio.PortfolioDataController?.PortfolioData?.ActiveObjective;
					if (metagameObjective != null)
					{
						ResearchProjectObjective researchProjectObjective = metagameObjective as ResearchProjectObjective;
						SuperBugObjective superBugObjective = metagameObjective as SuperBugObjective;
						if (researchProjectObjective != null)
						{
							_selectedProjectId = researchProjectObjective.ProjectID;
							_selectedSuperBugId = null;
						}
						if (superBugObjective != null)
						{
							_selectedProjectId = null;
							_selectedSuperBugId = superBugObjective.SuperBugID;
						}
					}
					else
					{
						_selectedProjectId = null;
						_selectedSuperBugId = null;
					}
				}
				if (!collaborativeMetagameData.HasSeenTutorial(CollaborativeMetagameData.TutorialType.CollaborativePortfolioTutorial))
				{
					_tutorialBox.Show(CollaborativeMetagameData.TutorialType.CollaborativePortfolioTutorial);
				}
			}
			GameObjectUtils.SetActive(_panelNew.gameObject, isActive: false);
			GameObjectUtils.SetActive(_panelProject.gameObject, isActive: false);
			GameObjectUtils.SetActive(_panelGlobal.gameObject, isActive: false);
			GameObjectUtils.SetActive(_tabs.gameObject, isActive: false);
			GameObjectUtils.SetActive(_gatheringDataPanel, isActive: false);
			GameObjectUtils.SetActive(_noDataPanel.gameObject, isActive: true);
			GameObjectUtils.SetActive(_errorResponseDialog, isActive: false);
			GameObjectUtils.SetActive(_messageBox.gameObject, isActive: false);
			GameObjectUtils.SetActive(_debugModeButton.gameObject, isActive: false);
			if (!_delegatesInitialised)
			{
				SuperBugProjectManager superBugManager = _superBugManager;
				superBugManager.OnSuperBugManagerInitialised = (Action)Delegate.Combine(superBugManager.OnSuperBugManagerInitialised, new Action(OnSuperBugManagerInitialised));
				SuperBugProjectManager superBugManager2 = _superBugManager;
				superBugManager2.OnCompletionDataReceived = (Action)Delegate.Combine(superBugManager2.OnCompletionDataReceived, new Action(OnSuperBugCompletionDataReceived));
				_errorRetryButton.onPrimaryDown.AddListener(OnErrorRetryPressed);
				if (_portfolio != null)
				{
					CollaborativePortfolio portfolio = _portfolio;
					portfolio.OnPortfolioInitialised = (Action)Delegate.Combine(portfolio.OnPortfolioInitialised, new Action(OnPortfolioInitialised));
					CollaborativePortfolio portfolio2 = _portfolio;
					portfolio2.OnPortfolioInitialisationFailed = (Action<EOnlineResult>)Delegate.Combine(portfolio2.OnPortfolioInitialisationFailed, new Action<EOnlineResult>(OnPortfolioInitialisationFailed));
				}
				_delegatesInitialised = true;
			}
			if (_portfolio != null && _portfolio.HasData && _superBugManager.IsInitialised)
			{
				InitialiseTabsAndPanels();
				if (!_portfolio.IsGatheringLatestData)
				{
					Refresh();
				}
			}
		}

		private void OnDestroy()
		{
			if (_delegatesInitialised)
			{
				SuperBugProjectManager superBugManager = _superBugManager;
				superBugManager.OnSuperBugManagerInitialised = (Action)Delegate.Remove(superBugManager.OnSuperBugManagerInitialised, new Action(OnSuperBugManagerInitialised));
				SuperBugProjectManager superBugManager2 = _superBugManager;
				superBugManager2.OnCompletionDataReceived = (Action)Delegate.Remove(superBugManager2.OnCompletionDataReceived, new Action(OnSuperBugCompletionDataReceived));
				_errorRetryButton.onPrimaryDown.RemoveListener(OnErrorRetryPressed);
				if (_portfolio != null)
				{
					CollaborativePortfolio portfolio = _portfolio;
					portfolio.OnPortfolioInitialised = (Action)Delegate.Remove(portfolio.OnPortfolioInitialised, new Action(OnPortfolioInitialised));
					CollaborativePortfolio portfolio2 = _portfolio;
					portfolio2.OnPortfolioInitialisationFailed = (Action<EOnlineResult>)Delegate.Remove(portfolio2.OnPortfolioInitialisationFailed, new Action<EOnlineResult>(OnPortfolioInitialisationFailed));
					_portfolio.DoesPeriodicGetLatest = true;
					CollaborativePortfolio portfolio3 = _portfolio;
					portfolio3.OnPortfolioInvitesUpdated = (Action)Delegate.Remove(portfolio3.OnPortfolioInvitesUpdated, new Action(Refresh));
					if (_portfolio.PortfolioDataController != null)
					{
						CollaborativePortfolioDataController portfolioDataController = _portfolio.PortfolioDataController;
						portfolioDataController.OnProjectInteractionCompleted = (Action)Delegate.Remove(portfolioDataController.OnProjectInteractionCompleted, new Action(OnProjectInteractionCompletedCallback));
					}
				}
				_delegatesInitialised = false;
			}
			if (_areTabsInitialised)
			{
				CollaborativeAsyncOperationHandler asyncOperationHandler = _portfolio.AsyncOperationHandler;
				asyncOperationHandler.OnAsyncOperationStarted = (Action<CollaborativeAsyncOperation>)Delegate.Remove(asyncOperationHandler.OnAsyncOperationStarted, new Action<CollaborativeAsyncOperation>(OnAsyncOperationStarted));
				CollaborativeAsyncOperationHandler asyncOperationHandler2 = _portfolio.AsyncOperationHandler;
				asyncOperationHandler2.OnAsyncOperationFinished = (Action<CollaborativeAsyncOperation>)Delegate.Remove(asyncOperationHandler2.OnAsyncOperationFinished, new Action<CollaborativeAsyncOperation>(OnAsyncOperationFinished));
				CollaborativeResearchTabs tabs = _tabs;
				tabs.OnTabSelected = (Action<Guid?>)Delegate.Remove(tabs.OnTabSelected, new Action<Guid?>(OnTabSelected));
				CollaborativeResearchTabs tabs2 = _tabs;
				tabs2.OnTabAbandonSelected = (Action<Guid?>)Delegate.Remove(tabs2.OnTabAbandonSelected, new Action<Guid?>(OnTabAbandonSelected));
				CollaborativeResearchTabs tabs3 = _tabs;
				tabs3.OnSuperBugTabSelected = (Action<int>)Delegate.Remove(tabs3.OnSuperBugTabSelected, new Action<int>(OnTabSuperBugSelected));
				CollaborativeResearchTabs tabs4 = _tabs;
				tabs4.OnInvitesTabSelected = (Action)Delegate.Remove(tabs4.OnInvitesTabSelected, new Action(OnTabInvitesSelected));
				CollaborativeResearchPanelNew panelNew = _panelNew;
				panelNew.OnNewProjectSelected = (Action<CollaborativeProjectDefinition>)Delegate.Remove(panelNew.OnNewProjectSelected, new Action<CollaborativeProjectDefinition>(OnNewProjectSelected));
				CollaborativeResearchPanelNew panelNew2 = _panelNew;
				panelNew2.OnJoinProjectSelected = (Action<Guid?>)Delegate.Remove(panelNew2.OnJoinProjectSelected, new Action<Guid?>(OnJoinProjectSelected));
				CollaborativeResearchPanelGlobal panelGlobal = _panelGlobal;
				panelGlobal.OnSuperBugObjectiveStarted = (Action<ObjectiveDefinition>)Delegate.Remove(panelGlobal.OnSuperBugObjectiveStarted, new Action<ObjectiveDefinition>(OnSuperBugObjectiveStarted));
				CollaborativeResearchPanelProject panelProject = _panelProject;
				panelProject.OnAbandonKickedPressed = (Action<Guid?>)Delegate.Remove(panelProject.OnAbandonKickedPressed, new Action<Guid?>(OnTabAbandonSelected));
				CollaborativeResearchPanelProject panelProject2 = _panelProject;
				panelProject2.OnCollectRewardPressed = (Action<Guid?>)Delegate.Remove(panelProject2.OnCollectRewardPressed, new Action<Guid?>(OnProjectRewardCollected));
				CollaborativeResearchPanelProject panelProject3 = _panelProject;
				panelProject3.OnResearchObjectiveStarted = (Action<ObjectiveDefinition>)Delegate.Remove(panelProject3.OnResearchObjectiveStarted, new Action<ObjectiveDefinition>(OnResearchObjectiveStarted));
				if ((bool)_deleteDataButton)
				{
					_deleteDataButton.onPrimaryDown.RemoveListener(OnDeleteDataPressed);
				}
			}
			_areTabsInitialised = false;
		}

		private void InitialiseTabsAndPanels(bool gatherAfterInitialise = false)
		{
			if (!_areTabsInitialised)
			{
				CollaborativeAsyncOperationHandler asyncOperationHandler = _portfolio.AsyncOperationHandler;
				asyncOperationHandler.OnAsyncOperationStarted = (Action<CollaborativeAsyncOperation>)Delegate.Combine(asyncOperationHandler.OnAsyncOperationStarted, new Action<CollaborativeAsyncOperation>(OnAsyncOperationStarted));
				CollaborativeAsyncOperationHandler asyncOperationHandler2 = _portfolio.AsyncOperationHandler;
				asyncOperationHandler2.OnAsyncOperationFinished = (Action<CollaborativeAsyncOperation>)Delegate.Combine(asyncOperationHandler2.OnAsyncOperationFinished, new Action<CollaborativeAsyncOperation>(OnAsyncOperationFinished));
				_portfolio.DoesPeriodicGetLatest = false;
				CollaborativePortfolio portfolio = _portfolio;
				portfolio.OnPortfolioInvitesUpdated = (Action)Delegate.Combine(portfolio.OnPortfolioInvitesUpdated, new Action(Refresh));
				if (_portfolio.PortfolioDataController != null)
				{
					CollaborativePortfolioDataController portfolioDataController = _portfolio.PortfolioDataController;
					portfolioDataController.OnProjectInteractionCompleted = (Action)Delegate.Combine(portfolioDataController.OnProjectInteractionCompleted, new Action(OnProjectInteractionCompletedCallback));
				}
				CollaborativeResearchPanelNew panelNew = _panelNew;
				panelNew.OnNewProjectSelected = (Action<CollaborativeProjectDefinition>)Delegate.Combine(panelNew.OnNewProjectSelected, new Action<CollaborativeProjectDefinition>(OnNewProjectSelected));
				CollaborativeResearchPanelNew panelNew2 = _panelNew;
				panelNew2.OnJoinProjectSelected = (Action<Guid?>)Delegate.Combine(panelNew2.OnJoinProjectSelected, new Action<Guid?>(OnJoinProjectSelected));
				_panelNew.Initialise(_portfolio, this);
				CollaborativeResearchPanelProject panelProject = _panelProject;
				panelProject.OnAbandonKickedPressed = (Action<Guid?>)Delegate.Combine(panelProject.OnAbandonKickedPressed, new Action<Guid?>(OnTabAbandonSelected));
				CollaborativeResearchPanelProject panelProject2 = _panelProject;
				panelProject2.OnCollectRewardPressed = (Action<Guid?>)Delegate.Combine(panelProject2.OnCollectRewardPressed, new Action<Guid?>(OnProjectRewardCollected));
				CollaborativeResearchPanelProject panelProject3 = _panelProject;
				panelProject3.OnResearchObjectiveStarted = (Action<ObjectiveDefinition>)Delegate.Combine(panelProject3.OnResearchObjectiveStarted, new Action<ObjectiveDefinition>(OnResearchObjectiveStarted));
				_panelProject.Initialise(this, _app.Metagame, _portfolio, _app.InputManager, _app.Metagame.OnlineMetadataManager);
				CollaborativeResearchPanelGlobal panelGlobal = _panelGlobal;
				panelGlobal.OnSuperBugObjectiveStarted = (Action<ObjectiveDefinition>)Delegate.Combine(panelGlobal.OnSuperBugObjectiveStarted, new Action<ObjectiveDefinition>(OnSuperBugObjectiveStarted));
				_panelGlobal.Initialise(this, _app.Metagame, _portfolio, _superBugManager);
				CollaborativeResearchTabs tabs = _tabs;
				tabs.OnTabSelected = (Action<Guid?>)Delegate.Combine(tabs.OnTabSelected, new Action<Guid?>(OnTabSelected));
				CollaborativeResearchTabs tabs2 = _tabs;
				tabs2.OnTabAbandonSelected = (Action<Guid?>)Delegate.Combine(tabs2.OnTabAbandonSelected, new Action<Guid?>(OnTabAbandonSelected));
				CollaborativeResearchTabs tabs3 = _tabs;
				tabs3.OnSuperBugTabSelected = (Action<int>)Delegate.Combine(tabs3.OnSuperBugTabSelected, new Action<int>(OnTabSuperBugSelected));
				CollaborativeResearchTabs tabs4 = _tabs;
				tabs4.OnInvitesTabSelected = (Action)Delegate.Combine(tabs4.OnInvitesTabSelected, new Action(OnTabInvitesSelected));
				_tabs.Initialise(_portfolio, _superBugManager, this);
				if ((bool)_deleteDataButton)
				{
					_deleteDataButton.onPrimaryDown.AddListener(OnDeleteDataPressed);
				}
				_areTabsInitialised = true;
			}
			if (gatherAfterInitialise)
			{
				_portfolio.RequestGatherData();
				ResetGatherDataTimer();
			}
			ResearchProjectObjective researchProjectObjective = _portfolio?.PortfolioDataController?.PortfolioData?.ActiveObjective as ResearchProjectObjective;
			SuperBugObjective superBugObjective = _portfolio?.PortfolioDataController?.PortfolioData?.ActiveObjective as SuperBugObjective;
			if (researchProjectObjective != null)
			{
				_selectedSuperBugId = null;
				_selectedProjectId = researchProjectObjective.ProjectID;
			}
			else if (superBugObjective != null)
			{
				_selectedSuperBugId = superBugObjective.SuperBugID;
				_selectedProjectId = null;
			}
			Refresh();
		}

		private void OfflineUpdate()
		{
			if (!_messageBox.gameObject.activeSelf)
			{
				string message = (OnlineManager.APIDisabled ? ScriptLocalization.Online.Status_OfflineReason_CantFindSteam_CS : ScriptLocalization.TRC_Network.ConnectionLost);
				_messageBox.SetupWith1Button(message, ScriptLocalization.Collaborative_GUI.OK_CS, delegate
				{
					CloseMenu();
				});
			}
		}

		protected override void Update()
		{
			base.Update();
			if (!OnlineManager.IsInitializedAndLoggedOn() || !OnlineManager.IsConnected())
			{
				OfflineUpdate();
			}
			else if (_portfolio != null)
			{
				if (_isGetLatestTimerActive)
				{
					_getLatestTimer -= Time.unscaledDeltaTime;
					if (_getLatestTimer <= 0f)
					{
						_portfolio.RequestGatherData();
						_isGetLatestTimerActive = false;
					}
				}
				bool isActive = _portfolio.AsyncOperationHandler.ContainsOperationType<CollaborativeAsyncOperationGatherData>();
				GameObjectUtils.SetActive(_gatheringDataSpinner, isActive);
				GameObjectUtils.SetActive(_gatheringDataGlobalPanel, !_superBugManager.IsProjectUpToDate);
			}
			else
			{
				Logging.Info("Initialise was never called, plugged in internet cable mid play?");
			}
		}

		private void Refresh()
		{
			if (_portfolio != null && _portfolio.HasData)
			{
				if (_tabs != null)
				{
					GameObjectUtils.SetActive(_tabs.gameObject, isActive: true);
				}
				if (_noDataPanel != null)
				{
					GameObjectUtils.SetActive(_noDataPanel.gameObject, isActive: false);
				}
				RefreshTabs();
				RefreshPanel();
			}
		}

		private void RefreshTabs()
		{
			_tabs.Refresh();
		}

		private void RefreshPanel()
		{
			Guid? selectedProjectId = _selectedProjectId;
			Guid? previousProjectId = _previousProjectId;
			if (selectedProjectId.HasValue != previousProjectId.HasValue || (selectedProjectId.HasValue && selectedProjectId.GetValueOrDefault() != previousProjectId.GetValueOrDefault()) || _selectedSuperBugId != _previousSuperBugId || _currentPanel == null || _currentPanel is CollaborativeResearchPanelNew)
			{
				_previousProjectId = _selectedProjectId;
				_previousSuperBugId = _selectedSuperBugId;
				if (_selectedSuperBugId.HasValue && _superBugManager?.Data?.Definition != null)
				{
					ShowGlobalPanel();
				}
				else if (!_selectedProjectId.HasValue)
				{
					if (!ShowCreateNewPanel())
					{
						_selectedProjectId = _portfolio.ActiveProjectSlots[0].ProjectID;
						RefreshPanel();
					}
				}
				else if (!ShowProjectPanel(_selectedProjectId.Value) && !ShowCreateNewPanel() && !ShowProjectPanel(_portfolio.ActiveProjectSlots[0].ProjectID))
				{
					Logging.Error("RB: Error trying to show first tab as default!  And the first project ProjectId could not be found!");
				}
			}
			else if (_currentPanel != null)
			{
				_currentPanel.OnGetLatestCompleted();
			}
		}

		private void OnProjectInteractionCompletedCallback()
		{
			Refresh();
		}

		private bool ShowProjectPanel(Guid projectId)
		{
			if (_portfolio.AsyncOperationHandler.ContainsOperationType<CollaborativeAsyncOperationGatherData>())
			{
				ShowPanel(null);
				GameObjectUtils.SetActive(_gatheringDataPanel, isActive: true);
				return true;
			}
			GameObjectUtils.SetActive(_gatheringDataPanel, isActive: false);
			if (_portfolio.GetProject(projectId) == null)
			{
				return false;
			}
			_panelProject.SetupForProject(projectId);
			ShowPanel(_panelProject);
			return true;
		}

		private bool ShowGlobalPanel()
		{
			if (!_selectedSuperBugId.HasValue || _superBugManager.DownloadedProjectDefinition == null || _superBugManager?.Data?.Definition == null || _superBugManager.Data.Definition.SuperBugID != _selectedSuperBugId.Value)
			{
				return false;
			}
			if (!_superBugManager.IsProjectUpToDate)
			{
				ShowPanel(null);
				GameObjectUtils.SetActive(_gatheringDataPanel, isActive: true);
				return true;
			}
			GameObjectUtils.SetActive(_gatheringDataPanel, isActive: false);
			_panelGlobal.SetupForProject(null);
			ShowPanel(_panelGlobal);
			return true;
		}

		private bool ShowCreateNewPanel()
		{
			_panelNew.SetupForProject(null);
			ShowPanel(_panelNew);
			GameObjectUtils.SetActive(_gatheringDataPanel, isActive: false);
			return true;
		}

		private void ShowPanel(CollaborativeResearchPanel panel)
		{
			if (_currentPanel == panel)
			{
				if (_currentPanel != null)
				{
					_currentPanel.OnGetLatestCompleted();
				}
				return;
			}
			if (_currentPanel != null)
			{
				_currentPanel.Hide();
			}
			_currentPanel = panel;
			if (_currentPanel != null)
			{
				_currentPanel.Show();
			}
		}

		private void OnTabSelected(Guid? projectId)
		{
			SelectProject(projectId);
		}

		private void OnTabAbandonSelected(Guid? projectId)
		{
			if (!projectId.HasValue)
			{
				return;
			}
			CollaborativeProject project = _portfolio.GetProject(projectId.Value);
			if (project == null)
			{
				return;
			}
			if (project.LeaderOnlinePlayerID == OnlineManager.GetLocalPlayerID())
			{
				_messageBox.SetupWith2Buttons(ScriptLocalization.Collaborative_GUI.AbandonProjectWarningLeader_CS, ScriptLocalization.Collaborative_GUI.Abandon_CS, delegate
				{
					_portfolio.RequestAbandonProject(projectId.Value);
				}, ScriptLocalization.Misc.Cancel_CS, null);
			}
			else
			{
				_messageBox.SetupWith2Buttons(ScriptLocalization.Collaborative_GUI.AbandonProjectWarning_CS, ScriptLocalization.Collaborative_GUI.Abandon_CS, delegate
				{
					_portfolio.RequestAbandonProject(projectId.Value);
				}, ScriptLocalization.Misc.Cancel_CS, null);
			}
		}

		private void OnTabSuperBugSelected(int superBugId)
		{
			_selectedProjectId = null;
			if (_selectedSuperBugId != superBugId)
			{
				_selectedSuperBugId = superBugId;
				Refresh();
			}
		}

		private void OnTabInvitesSelected()
		{
			_showInvites = true;
			_selectedProjectId = null;
			_selectedSuperBugId = null;
			Refresh();
		}

		private void ResetGatherDataTimer()
		{
			_getLatestTimer = 300f;
			_isGetLatestTimerActive = true;
		}

		private void OnSuperBugManagerInitialised()
		{
			if (_portfolio != null && _portfolio.HasData && _superBugManager.IsInitialised)
			{
				InitialiseTabsAndPanels(gatherAfterInitialise: true);
			}
		}

		private void OnSuperBugCompletionDataReceived()
		{
			Refresh();
		}

		private void OnNewSuperBugDownloaded(SuperBugDefinition superBugDefinition)
		{
			Refresh();
		}

		private void OnPortfolioInitialised()
		{
			if (_portfolio != null && _portfolio.HasData && _superBugManager.IsInitialised)
			{
				InitialiseTabsAndPanels(gatherAfterInitialise: true);
			}
		}

		private void OnPortfolioInitialisationFailed(EOnlineResult result)
		{
			if (!_portfolio.HasData && result == EOnlineResult.EOnlineResultTimedOut)
			{
				_errorResponseText.text = "Your connection has timed out and we were unable to retrieve you collaborative portfolio.";
				GameObjectUtils.SetActive(_errorResponseDialog, isActive: true);
			}
		}

		private void OnErrorRetryPressed()
		{
			GameObjectUtils.SetActive(_errorResponseDialog, isActive: false);
			_portfolio.RequestGatherData();
		}

		private void OnNewProjectSelected(CollaborativeProjectDefinition projectDefinition)
		{
			if (projectDefinition != null)
			{
				_portfolio.RequestCreateNewProject(projectDefinition);
			}
		}

		private void OnJoinProjectSelected(Guid? projectId)
		{
			if (projectId.HasValue)
			{
				_portfolio.RequestJoinProject(projectId.Value);
			}
		}

		private void OnProjectRewardCollected(Guid? projectId)
		{
			if (!projectId.HasValue)
			{
				return;
			}
			CollaborativeProject project = _portfolio.GetProject(projectId.Value);
			if (project != null)
			{
				if (_portfolio.PortfolioDataController != null)
				{
					_portfolio.PortfolioDataController.AddCompletedProjectToList(project);
				}
				CollaborativeProjectDefinition collaborativeProjectDefinition = project.LocalPlayerData?.Definition;
				if (collaborativeProjectDefinition != null)
				{
					RewardUtils.GiveAllRewards(collaborativeProjectDefinition.CompletionRewards, _app.Metagame);
				}
				_portfolio.RequestAbandonProject(projectId.Value);
			}
		}

		private void OnResearchObjectiveStarted(ObjectiveDefinition definition)
		{
			CloseMenu();
		}

		private void OnSuperBugObjectiveStarted(ObjectiveDefinition definition)
		{
			CloseMenu();
		}

		private void OnAsyncOperationStarted(CollaborativeAsyncOperation asyncOperation)
		{
			_tabs.CheckOperationLockStatus();
		}

		private void OnAsyncOperationFinished(CollaborativeAsyncOperation asyncOperation)
		{
			if (asyncOperation is CollaborativeAsyncOperationGatherData)
			{
				Refresh();
				ResetGatherDataTimer();
			}
			else if (asyncOperation is CollaborativeAsyncOperationCreateProject collaborativeAsyncOperationCreateProject)
			{
				SelectProject(collaborativeAsyncOperationCreateProject.CreatedProjectId);
				_tabs.CheckOperationLockStatus();
			}
			else if (asyncOperation is CollaborativeAsyncOperationJoinProject collaborativeAsyncOperationJoinProject)
			{
				SelectProject(collaborativeAsyncOperationJoinProject.ProjectId);
				_tabs.CheckOperationLockStatus();
			}
			else if (asyncOperation is CollaborativeAsyncOperationAbandonProject)
			{
				SelectProject(null);
				_tabs.CheckOperationLockStatus();
			}
		}

		private void SelectProject(Guid? projectId)
		{
			bool flag = _selectedSuperBugId.HasValue;
			if (_showInvites)
			{
				flag = true;
			}
			_showInvites = false;
			_selectedSuperBugId = null;
			if (projectId.HasValue)
			{
				_selectedProjectId = null;
				for (int i = 0; i < _portfolio.ActiveProjectSlots.Count; i++)
				{
					if (_portfolio.ActiveProjectSlots[i]?.ProjectID == projectId.Value)
					{
						_selectedProjectId = projectId.Value;
						flag = true;
						break;
					}
				}
			}
			else if (_selectedProjectId.HasValue)
			{
				_selectedProjectId = null;
				flag = true;
			}
			else
			{
				RefreshTabs();
			}
			if (flag)
			{
				MessageBox.Kill();
				Refresh();
			}
		}

		private void RefreshDebugButton()
		{
			GameObjectUtils.SetActive(_debugModeButton.gameObject, isActive: false);
		}

		private void OnDebugModePressed()
		{
		}

		private void DeleteCollaborativeData()
		{
			if (_portfolio.DeleteCollaborativeProjectFiles(OnDataDeletionComplete) && _deleteDataButton != null)
			{
				_deleteDataButton.interactable = false;
			}
		}

		private void OnDeleteDataPressed()
		{
			_app.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
			_app.MessageBox.ShowAsYesNo(LocalizationManager.GetTranslation(_deleteDataTitleLoc), LocalizationManager.GetTranslation(_deleteDataBodyLoc), ScriptLocalization.Misc.Continue_CS, ScriptLocalization.Misc.Cancel_CS, DeleteCollaborativeData);
			_app.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: false);
		}

		private void OnDataDeletionComplete(BaseOnlineDataFile file)
		{
			_app.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
			_app.MessageBox.Show("", LocalizationManager.GetTranslation(_deleteDataCompleteLoc), ScriptLocalization.Misc.Continue_CS);
			_app.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: false);
			if (_deleteDataButton != null)
			{
				_deleteDataButton.interactable = true;
			}
		}
	}
}
