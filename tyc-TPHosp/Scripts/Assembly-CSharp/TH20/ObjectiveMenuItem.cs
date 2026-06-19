using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ObjectiveMenuItem : ObjectiveMenuItemBase
	{
		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private DynamicButton _dismissButton;

		[SerializeField]
		private TooltipSpawner _dismissTooltip;

		[SerializeField]
		private GameObject _subGoalItemPrefab;

		[SerializeField]
		private Gradient _subGoalCompleteColor;

		[SerializeField]
		private Gradient _subGoalIncompleteColor;

		[SerializeField]
		private GameObject _timeLimitBar;

		[SerializeField]
		private ProgressBarMaskable _timeLimitBarImage;

		[SerializeField]
		private TMP_Text _timeLimitText;

		[SerializeField]
		private GameObject _hiScoreBar;

		[SerializeField]
		private TMP_Text _hiScoreText;

		private int _displayedDaysElapsed = -1;

		private int _displayedTimeLimit = -1;

		private Dictionary<ObjectiveSubGoal, ObjectiveSubGoalItem> _objectiveSubGoalItems = new Dictionary<ObjectiveSubGoal, ObjectiveSubGoalItem>();

		public override void Initialise(Level level, Objective objective)
		{
			base.Initialise(level, objective);
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			_dismissButton.onPrimaryDown.AddListener(OnDismissPressed);
			_dismissTooltip.SetDataProvider(AbandonTooltipDataProvider);
			foreach (ObjectiveSubGoal subGoal in _objective.SubGoals)
			{
				AddSubGoal(subGoal);
			}
			Refresh();
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

		private void OnDestroy()
		{
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
		}

		private void Refresh()
		{
			if (_objective == null)
			{
				return;
			}
			ObjectiveDefinition definition = _objective.Definition;
			bool flag = !_objective.IsReplayable || _objective.State == Objective.ObjectiveState.Active;
			_titleText.text = _objective.GetTitleText();
			_titleText.gameObject.SetActive(!definition.NameLocalised.ToString().IsNullOrEmpty());
			_dismissButton.gameObject.SetActive(_objective.CanDismiss());
			_displayedDaysElapsed = -1;
			_displayedTimeLimit = -1;
			_timeLimitBar.gameObject.SetActive(definition.IsTimed && flag);
			if (definition.IsTimed)
			{
				UpdateTimeLimit();
			}
			_hiScoreBar.gameObject.SetActive(definition.IsHiScore && flag);
			if (definition.IsHiScore)
			{
				UpdateHiScore();
			}
			foreach (KeyValuePair<ObjectiveSubGoal, ObjectiveSubGoalItem> objectiveSubGoalItem in _objectiveSubGoalItems)
			{
				objectiveSubGoalItem.Value.gameObject.SetActive(flag);
			}
		}

		private void AddSubGoal(ObjectiveSubGoal objectiveSubGoal)
		{
			if (_subGoalItemPrefab != null && objectiveSubGoal.Definition.DisplayOnHUD)
			{
				GameObject obj = Object.Instantiate(_subGoalItemPrefab);
				obj.transform.SetParent(base.transform, worldPositionStays: false);
				ObjectiveSubGoalItem component = obj.GetComponent<ObjectiveSubGoalItem>();
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
				Object.Destroy(objectiveSubGoalItem.Value);
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
			base.OnObjectiveCompleted(completionType);
			Refresh();
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

		public override RectTransform GetSubGoalTransform(ObjectiveSubGoal subGoal)
		{
			if (!_objectiveSubGoalItems.TryGetValue(subGoal, out var value))
			{
				return null;
			}
			return value.transform as RectTransform;
		}

		public override LevelObjectiveSubGoal GetMostImportantUnfinishedSubGoal(int subGoalObjectiveDepth = 0)
		{
			if (subGoalObjectiveDepth == 0)
			{
				foreach (KeyValuePair<ObjectiveSubGoal, ObjectiveSubGoalItem> objectiveSubGoalItem in _objectiveSubGoalItems)
				{
					if (objectiveSubGoalItem.Key is LevelObjectiveSubGoal levelObjectiveSubGoal && !levelObjectiveSubGoal.Completed() && !levelObjectiveSubGoal.Failed())
					{
						return levelObjectiveSubGoal;
					}
				}
			}
			return null;
		}

		private void Update()
		{
			if (_objective.Definition.IsTimed)
			{
				UpdateTimeLimit();
			}
			if (_objective.Definition.IsHiScore)
			{
				UpdateHiScore();
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

		private void UpdateHiScore()
		{
			if (_hiScoreText != null)
			{
				_hiScoreText.text = string.Format("{0}{2}{1}", ScriptLocalization.Misc.Score_CS, _objective.CurrentHiScore, ScriptLocalization.Misc.ColonSeparator_CS);
			}
		}

		private void OnDismissPressed()
		{
			_objective.Abandon();
		}
	}
}
