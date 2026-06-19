#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using TH20.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TH20
{
	public class CollaborativeSidebarMenu : MenuBase
	{
		[FormerlySerializedAs("_onlineFeatureRequired")]
		[SerializeField]
		private PlatformFeatureSupport.FeatureType m_featureRequired;

		[SerializeField]
		private GameObject _objectivePanel;

		[SerializeField]
		private GameObject _objectiveMenuItemParent;

		[SerializeField]
		private ButtonAnimator _collaborativePortfolioButton;

		[SerializeField]
		private GameObject _objectiveItemPrefab;

		[SerializeField]
		private GameObject _alertIcon;

		[SerializeField]
		private Image _pingImage;

		private MetagameObjective _objective;

		private ObjectiveMenuItemBase _objectiveMenuItem;

		private MetagameMap _metagameMap;

		private Metagame _metagame;

		private HUD _hud;

		private bool _pingButtonOnEnable;

		private Coroutine _pingCoroutine;

		public PlatformFeatureSupport.FeatureType FeatureRequired => m_featureRequired;

		public void Setup(MetagameMap metagameMap, Metagame metagame)
		{
			_metagameMap = metagameMap;
			_metagame = metagame;
			_hud = metagameMap.HUD;
			GameObjectUtils.SetActive(_objectivePanel, isActive: false);
			if (!OnlineManager.IsConnected() || !OnlineManager.IsInitializedAndLoggedOn() || !PlatformFeatureSupport.IsFeatureSupported(m_featureRequired))
			{
				_collaborativePortfolioButton.CurrentState = ButtonAnimator.State.Unselectable;
				return;
			}
			_collaborativePortfolioButton.CurrentState = ButtonAnimator.State.Selectable;
			CollaborativePortfolio collaborativePortfolio = _metagame.CollaborativePortfolio;
			collaborativePortfolio.OnPortfolioInitialised = (Action)Delegate.Combine(collaborativePortfolio.OnPortfolioInitialised, new Action(OnCollaborativeResearchInitialised));
			CollaborativeAsyncOperationHandler asyncOperationHandler = _metagame.CollaborativePortfolio.AsyncOperationHandler;
			asyncOperationHandler.OnAsyncOperationFinished = (Action<CollaborativeAsyncOperation>)Delegate.Combine(asyncOperationHandler.OnAsyncOperationFinished, new Action<CollaborativeAsyncOperation>(OnAsyncOperationFinished));
			ObjectiveEvents objectiveEvents = _metagame.ObjectiveEvents;
			objectiveEvents.OnObjectiveDiscovered = (Action<Objective>)Delegate.Combine(objectiveEvents.OnObjectiveDiscovered, new Action<Objective>(OnObjectiveDiscovered));
			ObjectiveEvents objectiveEvents2 = _metagame.ObjectiveEvents;
			objectiveEvents2.OnObjectiveStarted = (Action<Objective>)Delegate.Combine(objectiveEvents2.OnObjectiveStarted, new Action<Objective>(OnObjectiveStarted));
			ObjectiveEvents objectiveEvents3 = _metagame.ObjectiveEvents;
			objectiveEvents3.OnSubGoalUpdated = (Action<ObjectiveSubGoal>)Delegate.Combine(objectiveEvents3.OnSubGoalUpdated, new Action<ObjectiveSubGoal>(OnSubGoalUpdated));
			ObjectiveEvents objectiveEvents4 = _metagame.ObjectiveEvents;
			objectiveEvents4.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents4.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			OnCollaborativeResearchInitialised();
		}

		private void OnDestroy()
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				CollaborativePortfolio collaborativePortfolio = _metagame.CollaborativePortfolio;
				collaborativePortfolio.OnPortfolioInitialised = (Action)Delegate.Remove(collaborativePortfolio.OnPortfolioInitialised, new Action(OnCollaborativeResearchInitialised));
				CollaborativeAsyncOperationHandler asyncOperationHandler = _metagame.CollaborativePortfolio.AsyncOperationHandler;
				asyncOperationHandler.OnAsyncOperationFinished = (Action<CollaborativeAsyncOperation>)Delegate.Remove(asyncOperationHandler.OnAsyncOperationFinished, new Action<CollaborativeAsyncOperation>(OnAsyncOperationFinished));
				ObjectiveEvents objectiveEvents = _metagame.ObjectiveEvents;
				objectiveEvents.OnObjectiveDiscovered = (Action<Objective>)Delegate.Remove(objectiveEvents.OnObjectiveDiscovered, new Action<Objective>(OnObjectiveDiscovered));
				ObjectiveEvents objectiveEvents2 = _metagame.ObjectiveEvents;
				objectiveEvents2.OnObjectiveStarted = (Action<Objective>)Delegate.Remove(objectiveEvents2.OnObjectiveStarted, new Action<Objective>(OnObjectiveStarted));
				ObjectiveEvents objectiveEvents3 = _metagame.ObjectiveEvents;
				objectiveEvents3.OnSubGoalUpdated = (Action<ObjectiveSubGoal>)Delegate.Remove(objectiveEvents3.OnSubGoalUpdated, new Action<ObjectiveSubGoal>(OnSubGoalUpdated));
				ObjectiveEvents objectiveEvents4 = _metagame.ObjectiveEvents;
				objectiveEvents4.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents4.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			}
		}

		public override void OpenMenu()
		{
			base.OpenMenu();
			Logging.Info(LogChannels.GUI, "OpenMenu (CollaborativeSidebarMenu)");
			if (_metagame != null)
			{
				UpdateAlertIcon();
			}
		}

		public override void CloseMenu()
		{
			base.CloseMenu();
			Logging.Info(LogChannels.GUI, "CloseMenu (CollaborativeSidebarMenu)");
		}

		protected void OnEnable()
		{
			if (_pingButtonOnEnable)
			{
				if (_pingCoroutine == null)
				{
					_pingCoroutine = StartCoroutine(ShowPing());
				}
				_pingButtonOnEnable = false;
			}
			_collaborativePortfolioButton.Button.onPrimaryDown.AddListener(OnPortfolioPressed);
		}

		private void OnDisable()
		{
			_collaborativePortfolioButton.Button.onPrimaryDown.RemoveListener(OnPortfolioPressed);
			if (_pingCoroutine != null)
			{
				StopCoroutine(_pingCoroutine);
				_pingCoroutine = null;
				GameObjectUtils.SetActive(_pingImage.gameObject, isActive: false);
			}
		}

		private void OnPortfolioPressed()
		{
			if (_hud != null && !_hud.IsFullscreenMenuOpen() && !_hud.IsOptionsMenuOpen)
			{
				ShowCollaborativeMenu();
			}
		}

		private void ShowCollaborativeMenu()
		{
			if (_metagameMap.StateMachine.TopState is MetagameStatePlayer)
			{
				CollaborativeResearchMenu collaborativeResearchMenu = _metagameMap.HUD.FindMenu<CollaborativeResearchMenu>();
				if (collaborativeResearchMenu == null)
				{
					collaborativeResearchMenu = _metagameMap.HUD.CreateMenu<CollaborativeResearchMenu>();
				}
				collaborativeResearchMenu.Initialise(_metagameMap.App);
			}
		}

		private void OnCollaborativeResearchInitialised()
		{
			if (_metagame.CollaborativePortfolio.PortfolioDataController != null)
			{
				CollaborativePortfolioData portfolioData = _metagame.CollaborativePortfolio.PortfolioDataController.PortfolioData;
				if (portfolioData?.ActiveObjective != null)
				{
					OnObjectiveStarted(portfolioData.ActiveObjective);
				}
			}
			UpdateAlertIcon();
		}

		public void UpdateAlertIcon()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn() || _metagame?.CollaborativePortfolio == null || _metagame?.SuperBugManager == null)
			{
				_alertIcon.SetActive(value: false);
			}
			else
			{
				_alertIcon.SetActive(_metagame.CollaborativePortfolio.HasPortfolioGotNewData() || _metagame.CollaborativeMetagameData.HasGlobalProjectChanged());
			}
		}

		private void OnObjectiveDiscovered(Objective objective)
		{
			if ((objective is ResearchProjectObjective || objective is SuperBugObjective) && objective.Definition.IsTimed)
			{
				CreateMenuItem(objective);
			}
		}

		private void OnObjectiveStarted(Objective objective)
		{
			if (!(objective is ResearchProjectObjective) && !(objective is SuperBugObjective))
			{
				return;
			}
			if (objective.Definition.IsTimed)
			{
				if (_objectiveMenuItem != null)
				{
					_objectiveMenuItem.OnObjectiveStarted();
				}
			}
			else
			{
				CreateMenuItem(objective);
			}
		}

		private void OnSubGoalUpdated(ObjectiveSubGoal objectiveSubGoal)
		{
			if (!(_objectiveMenuItem == null) && objectiveSubGoal.GetOwnerObjective() == _objective)
			{
				_objectiveMenuItem.UpdateSubGoal(objectiveSubGoal);
				GameObjectUtils.SetActive(_objectivePanel, isActive: true);
			}
		}

		private void OnObjectiveCompleted(Objective objective, Objective.CompletionType completionType)
		{
			if (!(_objectiveMenuItem == null) && _objective == objective && completionType != Objective.CompletionType.Failed)
			{
				UnityEngine.Object.Destroy(_objectiveMenuItem.gameObject);
				_objectiveMenuItem = null;
				GameObjectUtils.SetActive(_objectivePanel, isActive: false);
			}
		}

		private void OnAsyncOperationFinished(CollaborativeAsyncOperation asyncOperation)
		{
			if (asyncOperation is CollaborativeAsyncOperationGatherData)
			{
				UpdateAlertIcon();
			}
		}

		private void CreateMenuItem(Objective objective)
		{
			if (_objectiveMenuItem != null)
			{
				UnityEngine.Object.Destroy(_objectiveMenuItem.gameObject);
				_objectiveMenuItem = null;
			}
			_objective = objective as MetagameObjective;
			GameObject gameObject = ((!(objective.Definition?.OverrideObjectivePrefab != null)) ? UnityEngine.Object.Instantiate(_objectiveItemPrefab) : UnityEngine.Object.Instantiate(objective.Definition.OverrideObjectivePrefab));
			gameObject.transform.SetParent(_objectiveMenuItemParent.transform, worldPositionStays: false);
			_objectiveMenuItem = gameObject.GetComponent<ObjectiveMenuItemCollaborative>();
			_objectiveMenuItem.Initialise(null, objective);
			GameObjectUtils.SetActive(_objectivePanel, isActive: true);
		}

		public void PingButton()
		{
			if (!base.gameObject.activeInHierarchy)
			{
				_pingButtonOnEnable = true;
			}
			else if (_pingCoroutine == null)
			{
				_pingCoroutine = StartCoroutine(ShowPing());
			}
		}

		private IEnumerator ShowPing()
		{
			GameObjectUtils.SetActive(_pingImage.gameObject, isActive: true);
			_pingImage.fillAmount = 0f;
			yield return null;
			while (true)
			{
				_pingImage.fillAmount += Time.unscaledDeltaTime;
				if (_pingImage.fillAmount >= 1f)
				{
					break;
				}
				yield return null;
			}
			float countdown = 5f;
			while (true)
			{
				countdown -= Time.unscaledDeltaTime;
				if (countdown < 0f)
				{
					break;
				}
				yield return null;
			}
			GameObjectUtils.SetActive(_pingImage.gameObject, isActive: false);
			_pingCoroutine = null;
		}
	}
}
