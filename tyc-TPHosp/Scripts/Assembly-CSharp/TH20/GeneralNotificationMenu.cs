using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GeneralNotificationMenu : MenuBase
	{
		public enum Category
		{
			LevelObjectives = 0,
			Online = 1
		}

		[SerializeField]
		private bool _display;

		[SerializeField]
		private Category _currentCategory;

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		[SerializeField]
		private GameObject _collaborativePortfolioAlertIcon;

		[InspectorMargin(8)]
		[InspectorHeader("Lists")]
		[SerializeField]
		private LevelObjectivesList _levelObjectivesList;

		[SerializeField]
		private OnlineObjectivesTab _onlineObjectivesTab;

		[SerializeField]
		private int _noObjectivesListPaddingY = 6;

		[InspectorMargin(8)]
		[InspectorHeader("Buttons")]
		[SerializeField]
		private ButtonAnimator _objectivesToggleButton;

		[SerializeField]
		private ButtonAnimator _onlineToggleButton;

		[SerializeField]
		private ButtonAnimator _collaborativePortfolioButton;

		[InspectorMargin(8)]
		[InspectorHeader("Button Images")]
		[SerializeField]
		private Image _onlineButtonImage;

		[SerializeField]
		private Sprite _onlineButtonIcon;

		[SerializeField]
		private Sprite _onlineButtonDisabledIcon;

		[InspectorMargin(8)]
		[InspectorHeader("Count Transform")]
		[SerializeField]
		private UnseenNotificationsIcon _notificationsObjectives;

		[SerializeField]
		private UnseenNotificationsIcon _notificationsOnline;

		[InspectorMargin(8)]
		[InspectorHeader("Tutorials")]
		[SerializeField]
		private GameObject _objectivesTabTutorialGameObject;

		[SerializeField]
		private GameObject _subGoalTutorialGameObject;

		[InspectorMargin(8)]
		[InspectorHeader("Tooltips")]
		[SerializeField]
		private TooltipSpawner _tooltipChallenges;

		[SerializeField]
		private ElectricityMenu _electricityMenu;

		[SerializeField]
		private EmergencyChallengeMenu _emergencyChallengeMenu;

		private Level _level;

		private InputManager _inputManager;

		private float _tutorialTimeRemaining;

		private bool _tutorialShowArrow;

		private bool _cachedWasDisplaying;

		public EmergencyChallengeMenu EmergencyChallengeMenu => _emergencyChallengeMenu;

		public void Setup(Level level, App app, ObjectiveEvents objectiveEvents, InputManager inputManager)
		{
			_level = level;
			_inputManager = inputManager;
			bool flag = OnlineManager.IsConnected() && OnlineManager.IsInitializedAndLoggedOn();
			if (_electricityMenu != null)
			{
				_electricityMenu.Initialise(level.HUD);
				_electricityMenu.SetVisible(visible: false);
			}
			if (_emergencyChallengeMenu != null)
			{
				_emergencyChallengeMenu.Initialise(level.HUD);
				_emergencyChallengeMenu.SetVisible(visible: false);
			}
			if (_objectivesToggleButton != null)
			{
				_objectivesToggleButton.Button.onPrimaryDown.AddListener(OnObjectivesToggleButtonClick);
			}
			if (_onlineToggleButton != null)
			{
				_onlineToggleButton.Button.onPrimaryDown.AddListener(OnOnlineToggleButtonClick);
				_onlineToggleButton.CurrentState = ((!flag) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
			if (_collaborativePortfolioButton != null)
			{
				GameObjectUtils.SetActive(_collaborativePortfolioButton.gameObject, app.GameMode is GameModeCareer && app.UserProfile.IsCollaborativeProjectsUnlocked);
				_collaborativePortfolioButton.Button.onPrimaryDown.AddListener(OnCollaborativePortfolioClicked);
				_onlineToggleButton.CurrentState = ((!flag || !app.UserProfile.IsCollaborativeProjectsUnlocked) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
			if (_levelObjectivesList != null)
			{
				_levelObjectivesList.Setup(level.LevelScriptManager, objectiveEvents, level.Metagame, _level);
			}
			if (_onlineObjectivesTab != null)
			{
				_onlineObjectivesTab.Setup(level, app);
			}
			ObjectiveEvents objectiveEvents2 = _level.ObjectiveEvents;
			objectiveEvents2.OnObjectiveDiscovered = (Action<Objective>)Delegate.Combine(objectiveEvents2.OnObjectiveDiscovered, new Action<Objective>(OnObjectiveDiscovered));
			ObjectiveEvents objectiveEvents3 = _level.ObjectiveEvents;
			objectiveEvents3.OnNewOnlineDataReceived = (Action<OnlineChallengeObjective, OnlinePlayerID>)Delegate.Combine(objectiveEvents3.OnNewOnlineDataReceived, new Action<OnlineChallengeObjective, OnlinePlayerID>(OnNewOnlineDataReceived));
			ObjectiveEvents objectiveEvents4 = _level.ObjectiveEvents;
			objectiveEvents4.OnActiveOnlineChallengeChanged = (Action)Delegate.Combine(objectiveEvents4.OnActiveOnlineChallengeChanged, new Action(OnActiveOnlineChallengeChanged));
			ObjectiveEvents objectiveEvents5 = _level.ObjectiveEvents;
			objectiveEvents5.OnFriendDataUpdated = (Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>)Delegate.Combine(objectiveEvents5.OnFriendDataUpdated, new Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>(OnFriendDataUpdated));
			ObjectiveEvents objectiveEvents6 = _level.ObjectiveEvents;
			objectiveEvents6.OnOnlineChallengeNotificationsViewed = (Action<OnlineChallengeObjective>)Delegate.Combine(objectiveEvents6.OnOnlineChallengeNotificationsViewed, new Action<OnlineChallengeObjective>(OnOnlineChallengeNotificationsViewed));
			if (_collaborativePortfolioAlertIcon != null)
			{
				if (_level.Metagame.CollaborativePortfolio.AsyncOperationHandler != null)
				{
					CollaborativeAsyncOperationHandler asyncOperationHandler = _level.Metagame.CollaborativePortfolio.AsyncOperationHandler;
					asyncOperationHandler.OnAsyncOperationFinished = (Action<CollaborativeAsyncOperation>)Delegate.Combine(asyncOperationHandler.OnAsyncOperationFinished, new Action<CollaborativeAsyncOperation>(OnCollaborativeAsyncOperationFinished));
				}
				CollaborativeMetagameData collaborativeMetagameData = _level.Metagame.CollaborativeMetagameData;
				collaborativeMetagameData.OnLastViewTimeUpdated = (Action)Delegate.Combine(collaborativeMetagameData.OnLastViewTimeUpdated, new Action(UpdateAlertIcon));
				CollaborativePortfolio collaborativePortfolio = _level.Metagame.CollaborativePortfolio;
				collaborativePortfolio.OnLatestDataGathered = (Action)Delegate.Combine(collaborativePortfolio.OnLatestDataGathered, new Action(UpdateAlertIcon));
				SuperBugProjectManager superBugManager = _level.Metagame.SuperBugManager;
				superBugManager.OnProjectViewed = (Action)Delegate.Combine(superBugManager.OnProjectViewed, new Action(UpdateAlertIcon));
				SuperBugProjectManager superBugManager2 = _level.Metagame.SuperBugManager;
				superBugManager2.OnCompletionDataReceived = (Action)Delegate.Combine(superBugManager2.OnCompletionDataReceived, new Action(UpdateAlertIcon));
				UpdateAlertIcon();
			}
			_tooltipChallenges.SetDataProvider(OnShowOnlineTooltip);
			_inputManager.AddGraphicRayCaster(_graphicRaycaster);
			HideCategory(Category.LevelObjectives);
			HideCategory(Category.Online);
			ShowCategory(_currentCategory);
			_display = true;
			RefreshActiveButtonBackground();
			RefreshObjectivesNotifications();
			RefreshOnlineNotificationsCount();
		}

		private void OnEnable()
		{
			if (_collaborativePortfolioAlertIcon != null)
			{
				UpdateAlertIcon();
			}
		}

		public void ToggleMode(Category newCategory)
		{
			if (_currentCategory == newCategory)
			{
				if (_display)
				{
					HideCategory(newCategory);
					_display = false;
				}
				else
				{
					ShowCategory(newCategory);
					_display = true;
				}
			}
			else
			{
				HideCategory(_currentCategory);
				ShowCategory(newCategory);
				_display = true;
			}
			_currentCategory = newCategory;
			RefreshActiveButtonBackground();
		}

		private void HideCategory(Category category)
		{
			switch (category)
			{
			case Category.LevelObjectives:
				SetObjectivesListActive(bActive: false);
				break;
			case Category.Online:
				_onlineObjectivesTab.gameObject.SetActive(value: false);
				break;
			}
		}

		private void ShowCategory(Category category, bool hideInspector = true)
		{
			switch (category)
			{
			case Category.LevelObjectives:
				SetObjectivesListActive(bActive: true);
				break;
			case Category.Online:
				_onlineObjectivesTab.gameObject.SetActive(value: true);
				break;
			}
			if (hideInspector)
			{
				InspectorMenu inspectorMenu = _level.HUD.FindMenu<InspectorMenu>(includeInactive: false);
				if (inspectorMenu != null)
				{
					inspectorMenu.CloseAndRestoreGeneralNotifications(bDoRestoreNotificationsMenu: false);
				}
			}
		}

		private void SetObjectivesListActive(bool bActive)
		{
			_levelObjectivesList.gameObject.SetActive(bActive);
			DynamicLayoutGroup component = GetComponent<DynamicLayoutGroup>();
			if (component != null)
			{
				component.padding.bottom = ((!bActive) ? _noObjectivesListPaddingY : 0);
				component.SetDirty();
			}
		}

		public void SuspendMenu()
		{
			HideCategory(Category.LevelObjectives);
			HideCategory(Category.Online);
			_cachedWasDisplaying = _display;
			_display = false;
			RefreshActiveButtonBackground();
		}

		public void RestoreMenu()
		{
			if (_cachedWasDisplaying)
			{
				ShowCategory(_currentCategory, hideInspector: false);
				_display = true;
			}
			RefreshActiveButtonBackground();
		}

		private void RefreshActiveButtonBackground()
		{
			bool flag = OnlineManager.IsConnected() && OnlineManager.IsInitializedAndLoggedOn();
			int numDiscoveredOnlineChallenges = _level.LevelScriptManager.GetNumDiscoveredOnlineChallenges();
			if (_display)
			{
				switch (_currentCategory)
				{
				case Category.LevelObjectives:
					_objectivesToggleButton.CurrentState = ButtonAnimator.State.Selected;
					_onlineToggleButton.CurrentState = ((!flag || numDiscoveredOnlineChallenges <= 0) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
					_onlineButtonImage.overrideSprite = ((numDiscoveredOnlineChallenges > 0) ? _onlineButtonIcon : _onlineButtonDisabledIcon);
					break;
				case Category.Online:
					_objectivesToggleButton.CurrentState = ButtonAnimator.State.Selectable;
					_onlineToggleButton.CurrentState = ((flag && numDiscoveredOnlineChallenges > 0) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Unselectable);
					_onlineButtonImage.overrideSprite = ((numDiscoveredOnlineChallenges > 0) ? _onlineButtonIcon : _onlineButtonDisabledIcon);
					break;
				}
			}
			else
			{
				_objectivesToggleButton.CurrentState = ButtonAnimator.State.Selectable;
				_onlineToggleButton.CurrentState = ((!flag || numDiscoveredOnlineChallenges <= 0) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				_onlineButtonImage.overrideSprite = ((numDiscoveredOnlineChallenges > 0) ? _onlineButtonIcon : _onlineButtonDisabledIcon);
			}
		}

		private void RefreshObjectivesNotifications()
		{
			if (_emergencyChallengeMenu.isActiveAndEnabled)
			{
				_emergencyChallengeMenu.RefreshNotificationIcon();
			}
			if (!(_notificationsObjectives == null))
			{
				if (_currentCategory == Category.LevelObjectives && _display)
				{
					_notificationsObjectives.UnseenNotifications = 0;
				}
				else
				{
					_notificationsObjectives.UnseenNotifications = _levelObjectivesList.NumVisibleObjectiveItems;
				}
			}
		}

		protected override void Update()
		{
			UpdateTutorial();
			RefreshObjectivesNotifications();
			_levelObjectivesList.Update();
			base.Update();
		}

		private void OnObjectivesToggleButtonClick()
		{
			ToggleMode(Category.LevelObjectives);
		}

		private void OnOnlineToggleButtonClick()
		{
			ToggleMode(Category.Online);
		}

		private void OnShowOnlineTooltip(Tooltip tooltip)
		{
			if (OnlineManager.IsConnected())
			{
				tooltip.Text = string.Format(ScriptLocalization.Menu_GeneralNotification.Challenges_CS, ScriptLocalization.Online.Status_Online_CS);
				return;
			}
			string arg = $"{ScriptLocalization.Online.Status_Offline_CS} - {(OnlineManager.APIDisabled ? ScriptLocalization.Online.Status_OfflineReason_CantFindSteam_CS : ScriptLocalization.TRC_Network.ConnectionLost)}";
			tooltip.Text = string.Format(ScriptLocalization.Menu_GeneralNotification.Challenges_CS, arg);
		}

		private void OnCollaborativePortfolioClicked()
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				CollaborativeResearchMenu collaborativeResearchMenu = _level.HUD.FindMenu<CollaborativeResearchMenu>();
				if (collaborativeResearchMenu == null)
				{
					collaborativeResearchMenu = _level.HUD.CreateMenu<CollaborativeResearchMenu>();
				}
				collaborativeResearchMenu.Initialise(_level.App);
			}
		}

		private void OnCollaborativeAsyncOperationFinished(CollaborativeAsyncOperation asyncOperation)
		{
			if (asyncOperation is CollaborativeAsyncOperationGatherData)
			{
				UpdateAlertIcon();
			}
		}

		private void UpdateAlertIcon()
		{
			if (!(_collaborativePortfolioAlertIcon == null) && _level?.Metagame?.CollaborativePortfolio != null)
			{
				if (!OnlineManager.IsInitializedAndLoggedOn())
				{
					_collaborativePortfolioAlertIcon.SetActive(value: false);
				}
				else
				{
					_collaborativePortfolioAlertIcon.SetActive(_level.Metagame.CollaborativePortfolio.HasPortfolioGotNewData());
				}
			}
		}

		private void OnNewOnlineDataReceived(OnlineChallengeObjective onlineObjective, OnlinePlayerID onlinePlayerID)
		{
			RefreshOnlineNotificationsCount();
		}

		private void OnActiveOnlineChallengeChanged()
		{
			RefreshOnlineNotificationsCount();
		}

		private void RefreshOnlineNotificationsCount()
		{
			int num = 0;
			foreach (OnlineChallengeObjective onlineChallenge in _level.LevelScriptManager.OnlineChallenges)
			{
				num += onlineChallenge.GetNumUnseenNotifications();
			}
			_notificationsOnline.UnseenNotifications = num;
		}

		public void ShowLevelObjectiveTutorial(float duration, bool bShowArrow = true)
		{
			_tutorialTimeRemaining = duration;
			_tutorialShowArrow = bShowArrow;
		}

		private void UpdateTutorial()
		{
			if (_tutorialTimeRemaining <= 0f)
			{
				GameObjectUtils.SetActive(_objectivesTabTutorialGameObject, isActive: false);
				GameObjectUtils.SetActive(_subGoalTutorialGameObject, isActive: false);
				return;
			}
			_tutorialTimeRemaining -= Time.unscaledDeltaTime;
			InspectorMenu inspectorMenu = _level.HUD.FindMenu<InspectorMenu>();
			if (inspectorMenu != null && inspectorMenu.IsOpen)
			{
				GameObjectUtils.SetActive(_objectivesTabTutorialGameObject, isActive: false);
				GameObjectUtils.SetActive(_subGoalTutorialGameObject, isActive: false);
				return;
			}
			ObjectiveSubGoal mostImportantUnfinishedSubgoal = _levelObjectivesList.GetMostImportantUnfinishedSubgoal();
			if (mostImportantUnfinishedSubgoal == null)
			{
				GameObjectUtils.SetActive(_objectivesTabTutorialGameObject, isActive: false);
				GameObjectUtils.SetActive(_subGoalTutorialGameObject, isActive: false);
				return;
			}
			if (!_display || _currentCategory != Category.LevelObjectives)
			{
				GameObjectUtils.SetActive(_objectivesTabTutorialGameObject, isActive: true);
				GameObjectUtils.SetActive(_subGoalTutorialGameObject, isActive: false);
				return;
			}
			RectTransform transformOfSubGoalMenuItem = _levelObjectivesList.GetTransformOfSubGoalMenuItem(mostImportantUnfinishedSubgoal);
			if (transformOfSubGoalMenuItem == null || !transformOfSubGoalMenuItem.gameObject.activeInHierarchy)
			{
				GameObjectUtils.SetActive(_objectivesTabTutorialGameObject, isActive: false);
				GameObjectUtils.SetActive(_subGoalTutorialGameObject, isActive: false);
				return;
			}
			GameObjectUtils.SetActive(_objectivesTabTutorialGameObject, isActive: false);
			GameObjectUtils.SetActive(_subGoalTutorialGameObject, isActive: true);
			_subGoalTutorialGameObject.transform.position = transformOfSubGoalMenuItem.position;
			CirclesAndArrowsAnimator component = _subGoalTutorialGameObject.GetComponent<CirclesAndArrowsAnimator>();
			if (component != null)
			{
				component.SetShowArrows(_tutorialShowArrow);
			}
		}

		private void OnObjectiveDiscovered(Objective objective)
		{
			RefreshActiveButtonBackground();
		}

		private void OnFriendDataUpdated(OnlineChallengeObjective objective, OnlinePlayerID onlinePlayerID, OnlineChallengeData data)
		{
			RefreshOnlineNotificationsCount();
		}

		private void OnOnlineChallengeNotificationsViewed(OnlineChallengeObjective objective)
		{
			RefreshOnlineNotificationsCount();
		}

		public void OnDestroy()
		{
			if (_inputManager != null)
			{
				_inputManager.RemoveGraphicRayCaster(_graphicRaycaster);
			}
			_tooltipChallenges.SetDataProvider(null);
			ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
			objectiveEvents.OnObjectiveDiscovered = (Action<Objective>)Delegate.Remove(objectiveEvents.OnObjectiveDiscovered, new Action<Objective>(OnObjectiveDiscovered));
			ObjectiveEvents objectiveEvents2 = _level.ObjectiveEvents;
			objectiveEvents2.OnNewOnlineDataReceived = (Action<OnlineChallengeObjective, OnlinePlayerID>)Delegate.Remove(objectiveEvents2.OnNewOnlineDataReceived, new Action<OnlineChallengeObjective, OnlinePlayerID>(OnNewOnlineDataReceived));
			ObjectiveEvents objectiveEvents3 = _level.ObjectiveEvents;
			objectiveEvents3.OnActiveOnlineChallengeChanged = (Action)Delegate.Remove(objectiveEvents3.OnActiveOnlineChallengeChanged, new Action(OnActiveOnlineChallengeChanged));
			ObjectiveEvents objectiveEvents4 = _level.ObjectiveEvents;
			objectiveEvents4.OnFriendDataUpdated = (Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>)Delegate.Remove(objectiveEvents4.OnFriendDataUpdated, new Action<OnlineChallengeObjective, OnlinePlayerID, OnlineChallengeData>(OnFriendDataUpdated));
			ObjectiveEvents objectiveEvents5 = _level.ObjectiveEvents;
			objectiveEvents5.OnOnlineChallengeNotificationsViewed = (Action<OnlineChallengeObjective>)Delegate.Remove(objectiveEvents5.OnOnlineChallengeNotificationsViewed, new Action<OnlineChallengeObjective>(OnOnlineChallengeNotificationsViewed));
			if (_levelObjectivesList != null)
			{
				_levelObjectivesList.Destroy();
			}
			if (_onlineObjectivesTab != null)
			{
				_onlineObjectivesTab.Destroy();
			}
			if (_collaborativePortfolioAlertIcon != null)
			{
				if (_level.Metagame.CollaborativePortfolio.AsyncOperationHandler != null)
				{
					CollaborativeAsyncOperationHandler asyncOperationHandler = _level.Metagame.CollaborativePortfolio.AsyncOperationHandler;
					asyncOperationHandler.OnAsyncOperationFinished = (Action<CollaborativeAsyncOperation>)Delegate.Remove(asyncOperationHandler.OnAsyncOperationFinished, new Action<CollaborativeAsyncOperation>(OnCollaborativeAsyncOperationFinished));
				}
				CollaborativeMetagameData collaborativeMetagameData = _level.Metagame.CollaborativeMetagameData;
				collaborativeMetagameData.OnLastViewTimeUpdated = (Action)Delegate.Remove(collaborativeMetagameData.OnLastViewTimeUpdated, new Action(UpdateAlertIcon));
				CollaborativePortfolio collaborativePortfolio = _level.Metagame.CollaborativePortfolio;
				collaborativePortfolio.OnLatestDataGathered = (Action)Delegate.Remove(collaborativePortfolio.OnLatestDataGathered, new Action(UpdateAlertIcon));
				SuperBugProjectManager superBugManager = _level.Metagame.SuperBugManager;
				superBugManager.OnProjectViewed = (Action)Delegate.Remove(superBugManager.OnProjectViewed, new Action(UpdateAlertIcon));
				SuperBugProjectManager superBugManager2 = _level.Metagame.SuperBugManager;
				superBugManager2.OnCompletionDataReceived = (Action)Delegate.Remove(superBugManager2.OnCompletionDataReceived, new Action(UpdateAlertIcon));
			}
		}
	}
}
