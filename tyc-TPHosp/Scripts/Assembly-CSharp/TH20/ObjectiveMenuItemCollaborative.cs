using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ObjectiveMenuItemCollaborative : ObjectiveMenuItemBase
	{
		[SerializeField]
		private GameObject _subGoalItemPrefab;

		[SerializeField]
		private TMP_Text _objectiveTitle;

		[SerializeField]
		private DynamicButton _startReplayButton;

		[SerializeField]
		private TMP_Text _startReplayButtonText;

		[SerializeField]
		private DynamicButton _dismissButton;

		[SerializeField]
		private TooltipSpawner _dismissTooltip;

		[SerializeField]
		private Image _researchIcon;

		[SerializeField]
		private Image _superBugIcon;

		[SerializeField]
		private GameObject _isKickedBanner;

		[SerializeField]
		private GameObject _timeLimitBar;

		[SerializeField]
		private ProgressBarMaskable _timeLimitBarImage;

		[SerializeField]
		private TMP_Text _timeLimitText;

		[SerializeField]
		private GameObject _subGoalPanel;

		[SerializeField]
		private Gradient _subGoalCompleteColor;

		[SerializeField]
		private Gradient _subGoalIncompleteColor;

		[SerializeField]
		private string _completeSoundEventTag;

		[SerializeField]
		private TMP_Text _projectStatusText;

		private int _displayedDaysElapsed = -1;

		private int _displayedTimeLimit = -1;

		private Dictionary<ObjectiveSubGoal, ObjectiveSubGoalItem> _objectiveSubGoalItems = new Dictionary<ObjectiveSubGoal, ObjectiveSubGoalItem>();

		private GameObject _completionEffectInstance;

		public override void Initialise(Level level, Objective objective)
		{
			base.Initialise(level, objective);
			bool isActive = objective is ResearchProjectObjective;
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			_dismissButton.onPrimaryDown.AddListener(OnDismissPressed);
			_dismissTooltip.SetDataProvider(AbandonTooltipDataProvider);
			_startReplayButton.onPrimaryDown.AddListener(OnReplayPressed);
			GameObjectUtils.SetActive(_researchIcon.gameObject, isActive);
			_superBugIcon.gameObject.SetActive(objective is SuperBugObjective);
			foreach (ObjectiveSubGoal subGoal in _objective.SubGoals)
			{
				AddSubGoal(subGoal);
			}
			Refresh();
		}

		protected override void OnDisable()
		{
		}

		private void OnDestroy()
		{
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			if (_completionEffectInstance != null)
			{
				Object.Destroy(_completionEffectInstance);
				_completionEffectInstance = null;
			}
		}

		private void Update()
		{
			if (_objective.Definition.IsTimed)
			{
				UpdateTimeLimit();
			}
		}

		private void UpdateTimeLimit()
		{
			int timeLength = _objective.Definition.TimeLength;
			int daysElapsed = _objective.DaysElapsed;
			float num = (float)daysElapsed / (float)timeLength;
			if (_timeLimitText != null && (_displayedDaysElapsed != daysElapsed || _displayedTimeLimit != timeLength))
			{
				_displayedDaysElapsed = daysElapsed;
				_displayedTimeLimit = timeLength;
				_timeLimitText.text = $"{daysElapsed} / {GameStringUtils.GetDaysString(timeLength)}";
			}
			if (_timeLimitBar != null && _timeLimitBarImage != null)
			{
				_timeLimitBarImage.SetProgressSmooth(1f - num);
			}
		}

		private void Refresh()
		{
			ObjectiveDefinition definition = _objective.Definition;
			ResearchProjectObjective researchProjectObjective = _objective as ResearchProjectObjective;
			SuperBugObjective superBugObjective = _objective as SuperBugObjective;
			if (researchProjectObjective != null)
			{
				CollaborativeProject project = researchProjectObjective.Metagame.App.CollaborativePortfolio.GetProject(researchProjectObjective.ProjectID);
				if (project != null)
				{
					GameObjectUtils.SetActive(_projectStatusText.gameObject, isActive: true);
					_objectiveTitle.text = project.LocalPlayerData.Definition.Name.Translation;
					_projectStatusText.text = definition.NameLocalised.Translation;
					_projectStatusText.color = Color.white;
					if (project.IsProjectCompleted())
					{
						_projectStatusText.text = ScriptLocalization.Collaborative_GUI.Completed_CS;
						_projectStatusText.color = Color.green;
					}
					else if (project.HasPlayerBeenKicked())
					{
						_projectStatusText.text = LocalizationManager.GetTranslation("Menu/GeneralNotification/Kicked");
						_projectStatusText.color = Color.red;
					}
				}
			}
			else if (superBugObjective != null)
			{
				_projectStatusText.color = Color.white;
				if (superBugObjective.Metagame.App.SuperBugManager.DownloadedProjectDefinition == null)
				{
					GameObjectUtils.SetActive(_projectStatusText.gameObject, isActive: false);
				}
				else if (superBugObjective.SuperBugID != superBugObjective.Metagame.App.SuperBugManager.DownloadedProjectDefinition.SuperBugID)
				{
					string translation = LocalizationManager.GetTranslation("Frontend/Superbug_General_Name");
					string translation2 = LocalizationManager.GetTranslation("Collaborative/GlobalProjectExpired_CS");
					_objectiveTitle.text = translation;
					_projectStatusText.text = translation2;
					GameObjectUtils.SetActive(_projectStatusText.gameObject, isActive: true);
				}
				else
				{
					_objectiveTitle.text = superBugObjective.Metagame.App.SuperBugManager.DownloadedProjectDefinition.Name.Translation;
					GameObjectUtils.SetActive(_projectStatusText.gameObject, isActive: false);
				}
			}
			else
			{
				GameObjectUtils.SetActive(_projectStatusText.gameObject, isActive: false);
			}
			bool flag = _objective.State == Objective.ObjectiveState.Active;
			_displayedDaysElapsed = -1;
			_displayedTimeLimit = -1;
			_timeLimitBar.gameObject.SetActive(definition.IsTimed && flag);
			if (definition.IsTimed)
			{
				UpdateTimeLimit();
			}
			_subGoalPanel.SetActive(flag);
			if (_objective.State != Objective.ObjectiveState.Finished)
			{
				_startReplayButtonText.text = ScriptLocalization.Misc.Start_CS;
				GameObjectUtils.SetActive(_dismissButton.gameObject, _objective.CanDismiss());
			}
			else
			{
				switch (_objective.CompletionResult)
				{
				case Objective.CompletionType.Incomplete:
				case Objective.CompletionType.Abandoned:
				case Objective.CompletionType.Failed:
				case Objective.CompletionType.Invalid:
					GameObjectUtils.SetActive(_dismissButton.gameObject, _objective.CanDismiss());
					if (_objective.Definition.IsTimed)
					{
						_startReplayButtonText.text = ScriptLocalization.Collaborative.Failed_Restart_CS;
					}
					else
					{
						_startReplayButtonText.text = ScriptLocalization.Collaborative.Complete_ViewProject_CS;
					}
					break;
				case Objective.CompletionType.Successful:
					GameObjectUtils.SetActive(_dismissButton.gameObject, isActive: false);
					_startReplayButtonText.text = ScriptLocalization.Collaborative.Complete_ViewProject_CS;
					break;
				}
			}
			_startReplayButton.gameObject.SetActive(!flag);
		}

		private void AddSubGoal(ObjectiveSubGoal objectiveSubGoal)
		{
			if (_subGoalItemPrefab != null && objectiveSubGoal.Definition.DisplayOnHUD)
			{
				ObjectiveSubGoalItem component = Object.Instantiate(_subGoalItemPrefab, _subGoalPanel.transform, worldPositionStays: false).GetComponent<ObjectiveSubGoalItem>();
				component.Setup(_level);
				_objectiveSubGoalItems.Add(objectiveSubGoal, component);
				UpdateSubGoal(objectiveSubGoal);
			}
		}

		public override void UpdateSubGoal(ObjectiveSubGoal objectiveSubGoal)
		{
			if (_objectiveSubGoalItems.ContainsKey(objectiveSubGoal))
			{
				ObjectiveSubGoalItem objectiveSubGoalItem = _objectiveSubGoalItems[objectiveSubGoal];
				objectiveSubGoalItem.UpdateFrom(objectiveSubGoal);
				ProgressBarMaskable componentInChildren = objectiveSubGoalItem.GetComponentInChildren<ProgressBarMaskable>();
				if (componentInChildren != null)
				{
					componentInChildren.BarGradient = (objectiveSubGoal.Completed() ? _subGoalCompleteColor : _subGoalIncompleteColor);
				}
			}
		}

		public override void OnObjectiveStarted()
		{
			base.OnObjectiveStarted();
			Refresh();
		}

		public override void OnObjectiveRestarting()
		{
			base.OnObjectiveRestarting();
			foreach (KeyValuePair<ObjectiveSubGoal, ObjectiveSubGoalItem> objectiveSubGoalItem in _objectiveSubGoalItems)
			{
				Object.Destroy(objectiveSubGoalItem.Value.gameObject);
			}
			_objectiveSubGoalItems.Clear();
			foreach (ObjectiveSubGoal subGoal in _objective.SubGoals)
			{
				AddSubGoal(subGoal);
			}
			Refresh();
		}

		public override void OnObjectiveCompleted(Objective.CompletionType completionType)
		{
			switch (completionType)
			{
			case Objective.CompletionType.Abandoned:
				return;
			case Objective.CompletionType.Successful:
				if (base.isActiveAndEnabled)
				{
					_completeEffectCoroutine = StartCoroutine(PlayCompleteEffect(completionType));
				}
				break;
			}
			Refresh();
		}

		public override void OnObjectiveKickStateChanged()
		{
			base.OnObjectiveKickStateChanged();
			if (_objective is ResearchProjectObjective researchProjectObjective)
			{
				_isKickedBanner.gameObject.SetActive(researchProjectObjective.IsKicked);
			}
		}

		private void AbandonTooltipDataProvider(Tooltip tooltip)
		{
			string text = LocalizationManager.GetTranslation("Misc/ButtonAbandonChallenge");
			string rewardsHUDString = _objective.GetRewardsHUDString(Objective.CompletionType.Abandoned);
			if (!rewardsHUDString.IsNullOrEmpty())
			{
				text = text + "\n\n" + rewardsHUDString;
			}
			tooltip.Text = text;
		}

		public override RectTransform GetSubGoalTransform(ObjectiveSubGoal subGoal)
		{
			if (!_objectiveSubGoalItems.TryGetValue(subGoal, out var value))
			{
				return null;
			}
			return value.transform as RectTransform;
		}

		public void OnLocalize()
		{
			foreach (ObjectiveSubGoal subGoal in _objective.SubGoals)
			{
				if (_objectiveSubGoalItems.ContainsKey(subGoal))
				{
					_objectiveSubGoalItems[subGoal].UpdateLocalizedElementsFrom(subGoal);
				}
			}
			Refresh();
		}

		private void OnDismissPressed()
		{
			_objective.Abandon();
		}

		private void OnReplayPressed()
		{
			if (_objective.State == Objective.ObjectiveState.Unstarted)
			{
				_objective.Start();
			}
			else
			{
				if (_objective.State != Objective.ObjectiveState.Finished)
				{
					return;
				}
				switch (_objective.CompletionResult)
				{
				case Objective.CompletionType.Abandoned:
					_objective.ReadyToDestroy();
					break;
				case Objective.CompletionType.Incomplete:
				case Objective.CompletionType.Failed:
				case Objective.CompletionType.Invalid:
					if (_objective.Definition.IsTimed)
					{
						_objective.Restart();
					}
					else
					{
						_objective.ReadyToDestroy();
					}
					break;
				case Objective.CompletionType.Successful:
					_objective.ReadyToDestroy();
					ShowCollaborativePortfolio();
					break;
				}
			}
		}

		private void ShowCollaborativePortfolio()
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

		private IEnumerator PlayCompleteEffect(Objective.CompletionType completionType)
		{
			GameObject gameObject = ((completionType == Objective.CompletionType.Successful) ? _completeEffectPrefab : null);
			if (gameObject != null)
			{
				if (_completionEffectInstance != null)
				{
					Object.Destroy(_completionEffectInstance);
					_completionEffectInstance = null;
				}
				_completionEffectInstance = Object.Instantiate(gameObject, _completeEffectParent);
				_completionEffectInstance.transform.SetAsLastSibling();
				if (!_completeSoundEventTag.IsNullOrEmpty())
				{
					AudioManager.Instance.Play(_completeSoundEventTag);
				}
				yield return new WaitForSecondsRealtime(_completeEffectTime);
			}
		}
	}
}
