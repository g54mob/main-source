using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class ObjectiveMenuItemChallengeWaveObjectivesHorde2 : ObjectiveMenuItemBase
	{
		[SerializeField]
		private GameObject _subGoalItemPrefab;

		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _waveText;

		[SerializeField]
		private TMP_Text _infoText;

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

		[SerializeField]
		private float _tutorialCircleDuration = 30f;

		private Dictionary<ObjectiveSubGoal, ObjectiveSubGoalItem> _objectiveSubGoalItems = new Dictionary<ObjectiveSubGoal, ObjectiveSubGoalItem>();

		private GameObject _completionEffectInstance;

		private ChallengeWaveObjectivesHorde _challenge;

		public override void Initialise(Level level, Objective objective)
		{
			base.Initialise(level, objective);
			_challenge = objective as ChallengeWaveObjectivesHorde;
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			ChallengeWaveObjectivesHorde.OnWaveStarted = (Action<int, int>)Delegate.Combine(ChallengeWaveObjectivesHorde.OnWaveStarted, new Action<int, int>(OnWaveStarted));
			ChallengeWaveObjectivesHorde.OnWaveChanged = (Action<int, int>)Delegate.Combine(ChallengeWaveObjectivesHorde.OnWaveChanged, new Action<int, int>(OnWaveChanged));
			ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
			objectiveEvents.OnSubGoalUpdated = (Action<ObjectiveSubGoal>)Delegate.Combine(objectiveEvents.OnSubGoalUpdated, new Action<ObjectiveSubGoal>(OnSubGoalUpdated));
			ObjectiveEvents objectiveEvents2 = _level.ObjectiveEvents;
			objectiveEvents2.OnSubGoalCompleted = (Action<ObjectiveSubGoal>)Delegate.Combine(objectiveEvents2.OnSubGoalCompleted, new Action<ObjectiveSubGoal>(OnSubGoalCompleted));
			if (_challenge.RestoredFromSave && _challenge.ChallengeStatus == Challenge.ChallengeState.InProgress)
			{
				AddSubGoals();
			}
			Refresh();
			UpdateActiveSubGoalObjectiveTutorialCircle();
		}

		public override LevelObjectiveSubGoal GetMostImportantUnfinishedSubGoal(int subGoalObjectiveDepth = 0)
		{
			LevelObjectiveSubGoal result = null;
			if (subGoalObjectiveDepth < 0 && _objective.State == Objective.ObjectiveState.Active)
			{
				Objective activeWaveObjective = _challenge.GetActiveWaveObjective();
				if (activeWaveObjective != null && activeWaveObjective.SubGoals != null)
				{
					foreach (ObjectiveSubGoal subGoal in activeWaveObjective.SubGoals)
					{
						if (!subGoal.Completed())
						{
							result = subGoal as LevelObjectiveSubGoal;
							break;
						}
					}
				}
			}
			return result;
		}

		public override RectTransform GetSubGoalTransform(ObjectiveSubGoal inSubGoal)
		{
			RectTransform result = null;
			if (inSubGoal != null)
			{
				ObjectiveSubGoalItem value = null;
				if (_objectiveSubGoalItems.TryGetValue(inSubGoal, out value))
				{
					result = value.transform as RectTransform;
				}
			}
			return result;
		}

		protected override void OnDisable()
		{
		}

		private void OnDestroy()
		{
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			ChallengeWaveObjectivesHorde.OnWaveStarted = (Action<int, int>)Delegate.Remove(ChallengeWaveObjectivesHorde.OnWaveStarted, new Action<int, int>(OnWaveStarted));
			ChallengeWaveObjectivesHorde.OnWaveChanged = (Action<int, int>)Delegate.Remove(ChallengeWaveObjectivesHorde.OnWaveChanged, new Action<int, int>(OnWaveChanged));
			ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
			objectiveEvents.OnSubGoalUpdated = (Action<ObjectiveSubGoal>)Delegate.Remove(objectiveEvents.OnSubGoalUpdated, new Action<ObjectiveSubGoal>(OnSubGoalUpdated));
			ObjectiveEvents objectiveEvents2 = _level.ObjectiveEvents;
			objectiveEvents2.OnSubGoalCompleted = (Action<ObjectiveSubGoal>)Delegate.Remove(objectiveEvents2.OnSubGoalCompleted, new Action<ObjectiveSubGoal>(OnSubGoalCompleted));
			if (_completionEffectInstance != null)
			{
				UnityEngine.Object.Destroy(_completionEffectInstance);
				_completionEffectInstance = null;
			}
		}

		private void Update()
		{
			Refresh();
		}

		private void AddSubGoals()
		{
			RemoveAllSubGoals();
			Objective activeWaveObjective = _challenge.GetActiveWaveObjective();
			if (activeWaveObjective == null)
			{
				return;
			}
			foreach (ObjectiveSubGoal subGoal in activeWaveObjective.SubGoals)
			{
				AddSubGoal(subGoal);
			}
		}

		private void OnWaveStarted(int waveNum, int waveIndex)
		{
			AddSubGoals();
			UpdateActiveSubGoalObjectiveTutorialCircle();
		}

		private void OnWaveChanged(int waveNum, int waveIndex)
		{
			RemoveAllSubGoals();
			UpdateActiveSubGoalObjectiveTutorialCircle();
		}

		private void OnSubGoalUpdated(ObjectiveSubGoal subGoal)
		{
			UpdateSubGoal(subGoal);
		}

		private void OnSubGoalCompleted(ObjectiveSubGoal subGoal)
		{
			UpdateActiveSubGoalObjectiveTutorialCircle();
		}

		private void Refresh()
		{
			_ = _objective.Definition;
			Objective activeWaveObjective = _challenge.GetActiveWaveObjective();
			bool active = _objective.State == Objective.ObjectiveState.Active && activeWaveObjective != null && activeWaveObjective.SubGoals != null && activeWaveObjective.SubGoals.Count > 0;
			if (_titleText != null)
			{
				_titleText.text = _challenge.GetTitleText();
			}
			if (_waveText != null)
			{
				_waveText.text = ScriptLocalization.Challenges.Horde_ObjectiveMenuWave_CS.Replace("{[WAVE]}", (_challenge.WaveNum + 1).ToString());
			}
			if (_infoText != null)
			{
				string empty = string.Empty;
				if (_challenge.Countdown != 0)
				{
					empty = ScriptLocalization.Challenges.Horde_ObjectiveMenuCountdown_CS;
					LocalisationParams.Set("DAYS", _challenge.Countdown);
					active = false;
				}
				else
				{
					empty = ScriptLocalization.Challenges.WaveObjectivesHorde_ObjectiveMenuProgress_CS;
					empty = LocalisedString.Replace(empty, new SubPair[2]
					{
						new SubPair("{[PROCESSED]}", _challenge.NumProcessed),
						new SubPair("{[REMAIN]}", _challenge.NumRemaining)
					});
				}
				LocalisationParams.Localise(ref empty);
				_infoText.text = empty;
			}
			if (_subGoalPanel != null)
			{
				_subGoalPanel.SetActive(active);
			}
		}

		private void AddSubGoal(ObjectiveSubGoal objectiveSubGoal)
		{
			if (_subGoalItemPrefab != null && objectiveSubGoal.Definition.DisplayOnHUD)
			{
				ObjectiveSubGoalItem component = UnityEngine.Object.Instantiate(_subGoalItemPrefab, _subGoalPanel.transform, worldPositionStays: false).GetComponent<ObjectiveSubGoalItem>();
				component.Setup(_level);
				_objectiveSubGoalItems.Add(objectiveSubGoal, component);
				UpdateSubGoal(objectiveSubGoal);
			}
		}

		private void RemoveAllSubGoals()
		{
			foreach (KeyValuePair<ObjectiveSubGoal, ObjectiveSubGoalItem> objectiveSubGoalItem in _objectiveSubGoalItems)
			{
				objectiveSubGoalItem.Value.gameObject.transform.SetParent(null);
				UnityEngine.Object.Destroy(objectiveSubGoalItem.Value);
			}
			_objectiveSubGoalItems.Clear();
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
			UpdateActiveSubGoalObjectiveTutorialCircle();
		}

		public override void OnObjectiveRestarting()
		{
			base.OnObjectiveRestarting();
			foreach (KeyValuePair<ObjectiveSubGoal, ObjectiveSubGoalItem> objectiveSubGoalItem in _objectiveSubGoalItems)
			{
				UnityEngine.Object.Destroy(objectiveSubGoalItem.Value.gameObject);
			}
			_objectiveSubGoalItems.Clear();
			foreach (ObjectiveSubGoal subGoal in _objective.SubGoals)
			{
				AddSubGoal(subGoal);
			}
			Refresh();
			UpdateActiveSubGoalObjectiveTutorialCircle();
		}

		public override void OnObjectiveCompleted(Objective.CompletionType completionType)
		{
			switch (completionType)
			{
			case Objective.CompletionType.Abandoned:
				return;
			case Objective.CompletionType.Successful:
				_completeEffectCoroutine = StartCoroutine(PlayCompleteEffect(completionType));
				break;
			}
			Refresh();
		}

		public void OnLocalize()
		{
			Objective activeWaveObjective = _challenge.GetActiveWaveObjective();
			if (activeWaveObjective != null && activeWaveObjective.SubGoals != null && activeWaveObjective.SubGoals.Count > 0)
			{
				foreach (ObjectiveSubGoal subGoal in activeWaveObjective.SubGoals)
				{
					if (_objectiveSubGoalItems.ContainsKey(subGoal))
					{
						_objectiveSubGoalItems[subGoal].UpdateLocalizedElementsFrom(subGoal);
					}
				}
			}
			Refresh();
		}

		private IEnumerator PlayCompleteEffect(Objective.CompletionType completionType)
		{
			GameObject gameObject = ((completionType == Objective.CompletionType.Successful) ? _completeEffectPrefab : null);
			if (gameObject != null)
			{
				if (_completionEffectInstance != null)
				{
					UnityEngine.Object.Destroy(_completionEffectInstance);
					_completionEffectInstance = null;
				}
				_completionEffectInstance = UnityEngine.Object.Instantiate(gameObject, _completeEffectParent);
				_completionEffectInstance.transform.SetAsLastSibling();
				if (!_completeSoundEventTag.IsNullOrEmpty())
				{
					AudioManager.Instance.Play(_completeSoundEventTag);
				}
				yield return new WaitForSecondsRealtime(_completeEffectTime);
			}
		}

		private void UpdateActiveSubGoalObjectiveTutorialCircle()
		{
			GeneralNotificationMenu generalNotificationMenu = _level.HUD.FindMenu<GeneralNotificationMenu>(includeInactive: false);
			if (generalNotificationMenu != null)
			{
				float duration = 0f;
				if (GetMostImportantUnfinishedSubGoal(-1) != null)
				{
					duration = _tutorialCircleDuration;
				}
				generalNotificationMenu.ShowLevelObjectiveTutorial(duration, bShowArrow: false);
			}
		}
	}
}
