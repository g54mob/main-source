using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class QuestTrackerManager : CTSSingleton<QuestTrackerManager>
	{
		[SerializeField]
		private CanvasGroupController _canvasGroupController;

		private List<Quest> _trackedQuest = new List<Quest>();

		public Quest CurrentlySelectedQuest { get; private set; }

		public bool IsTrackingQuest => CurrentlySelectedQuest != null;

		public static event Action<Quest> TrackingQuest;

		public static event Action<Quest> UntrackingQuest;

		public static event Action<Quest> CurrentQuestChanged;

		protected override void OnDisabled()
		{
			Quest.QuestStarted -= TrackQuest;
			Quest.QuestResumed -= OnQuestResumed;
			Quest.QuestEntryUpdated -= OnQuestEntryUpdated;
			Quest.QuestSucceeded -= OnQuestSuccess;
			Quest.QuestFailed -= UntrackQuest;
		}

		protected override void OnEnabled()
		{
			Quest.QuestStarted += TrackQuest;
			Quest.QuestResumed += OnQuestResumed;
			Quest.QuestEntryUpdated += OnQuestEntryUpdated;
			Quest.QuestSucceeded += OnQuestSuccess;
			Quest.QuestFailed += UntrackQuest;
		}

		private void OnQuestResumed(Quest quest)
		{
			if (!_trackedQuest.Contains(quest))
			{
				_trackedQuest.Add(quest);
			}
			QuestTrackerManager.TrackingQuest?.Invoke(quest);
			UpdateTrackerVisibility();
		}

		private void QuestUpdated(Quest quest)
		{
			SelectQuest(quest);
		}

		private void OnQuestEntryUpdated(Quest quest, int entry)
		{
		}

		private void OnQuestSuccess(Quest quest)
		{
			UntrackQuest(quest);
		}

		private void UntrackQuest(Quest quest)
		{
			QuestTrackerManager.UntrackingQuest?.Invoke(quest);
			_trackedQuest.Remove(quest);
			if (quest == CurrentlySelectedQuest && _trackedQuest.Count > 0)
			{
				SelectQuest(_trackedQuest[0]);
			}
			UpdateTrackerVisibility();
		}

		private void TrackQuest(Quest quest)
		{
			if (!_trackedQuest.Contains(quest) && quest.QuestState == QuestState.Active)
			{
				_trackedQuest.Add(quest);
				QuestTrackerManager.TrackingQuest?.Invoke(quest);
				UpdateTrackerVisibility();
				SelectQuest(quest);
			}
		}

		private void SelectQuest(Quest quest)
		{
			if (_trackedQuest.Contains(quest) && !(CurrentlySelectedQuest == quest))
			{
				CurrentlySelectedQuest = quest;
				QuestTrackerManager.CurrentQuestChanged?.Invoke(CurrentlySelectedQuest);
			}
		}

		public static void SelectTrackedQuestToShow(Quest quest)
		{
			CTSSingleton<QuestTrackerManager>.Instance.SelectQuest(quest);
		}

		public void UpdateTrackerVisibility()
		{
			if ((bool)_canvasGroupController)
			{
				_canvasGroupController.ShowCanvasGroup(_trackedQuest.Count > 0);
			}
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
