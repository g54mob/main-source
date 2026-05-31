using System;
using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class QuestTrackerFailureCountdownUI : CTSBehaviour
	{
		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private TextMeshProUGUI _timerText;

		private Quest _quest;

		protected override void OnDisabled()
		{
			SecondaryQuestsManager.FailTimerStarted -= OnTimerStarted;
			SecondaryQuestsManager.FailCountdownUpdated -= UpdateCountdownValues;
			SecondaryQuestsManager.FailTimerOver -= OnTimerOver;
			QuestTrackerManager.CurrentQuestChanged -= OnCurrentQuestChanged;
		}

		protected override void OnEnabled()
		{
			SecondaryQuestsManager.FailTimerStarted += OnTimerStarted;
			SecondaryQuestsManager.FailCountdownUpdated += UpdateCountdownValues;
			SecondaryQuestsManager.FailTimerOver += OnTimerOver;
			QuestTrackerManager.CurrentQuestChanged += OnCurrentQuestChanged;
			UpdateAlpha();
		}

		private void UpdateAlpha()
		{
			if ((bool)_canvasGroup)
			{
				_canvasGroup.alpha = ((!_quest) ? 0f : ((CTSSingleton<QuestTrackerManager>.Instance.CurrentlySelectedQuest == _quest) ? 1f : 0.25f));
			}
		}

		private void OnCurrentQuestChanged(Quest selectedQuest)
		{
			UpdateAlpha();
		}

		private void OnTimerStarted(Quest quest, float timer, float timerDuration)
		{
			if (!_quest)
			{
				_quest = quest;
				UpdateCountdownValues(quest, timer, timerDuration);
			}
		}

		private void OnTimerOver(Quest quest)
		{
			if (!(_quest != quest))
			{
				_quest = null;
				UpdateAlpha();
			}
		}

		public void UpdateCountdownValues(Quest quest, float currentTimer, float totalDuration)
		{
			if (!(_quest != quest))
			{
				_timerText.text = TimeSpan.FromSeconds(currentTimer).ToString("mm':'ss");
				UpdateAlpha();
			}
		}
	}
}
