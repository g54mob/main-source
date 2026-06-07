#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Data.Quests;
using Events.Analytics;
using GameAnalyticsSDK;
using Utils;

namespace Logic.Quests
{
	public class QuestController
	{
		public const int NON_ORDERED_ID_OFFSET = 512;

		private readonly QuestSO _quest;

		private List<SubQuestSO> _orderedSubQuests;

		private List<SubQuestSO> _nonOrderedSubQuests;

		private SubQuestSO _activeOrderedSubQuest;

		private int _activeOrderedSubQuestIndex;

		private bool _allOrderedSubQuestsComplete;

		private bool _allNonOrderedSubQuestsComplete;

		private readonly Func<bool> _getShouldAutoComplete;

		private int _remainingOrderedSubQuests;

		private int _remainingNonOrderedSubQuests;

		private bool _questStarted;

		private readonly Action _autoCompleteQuest;

		private readonly AnalyticsProgressionEvent _analyticsProgressionEvent;

		private readonly AnalyticsProgressionTimedEvent _analyticsProgressionTimedEvent;

		private Stopwatch _progressionEventTimer;

		public bool QuestStarted => _questStarted;

		public int RemainingActiveSubQuestAmount => _remainingOrderedSubQuests + _remainingNonOrderedSubQuests;

		public int ActiveOrderedSubQuestIndex => _activeOrderedSubQuestIndex;

		public int RemainingOrderedSubQuests => _remainingOrderedSubQuests;

		public string QuestName => _quest.name;

		public List<int> RemainingOrderedSubQuestsIndices
		{
			get
			{
				List<int> list = new List<int>();
				for (int i = 0; i < _nonOrderedSubQuests.Count; i++)
				{
					if (_nonOrderedSubQuests[i] != null)
					{
						list.Add(i);
					}
				}
				return list;
			}
		}

		public event Action<QuestSO> OnQuestComplete = delegate
		{
		};

		public event Action<SubQuestSO, int> OnSubQuestComplete = delegate
		{
		};

		public event Action<SubQuestSO, int> OnSubQuestStarted = delegate
		{
		};

		public QuestController(QuestSO quest, Func<bool> getShouldAutoComplete, Action autoCompleteQuest, AnalyticsProgressionEvent analyticsProgressionEvent, AnalyticsProgressionTimedEvent analyticsProgressionTimedEvent)
		{
			_quest = quest;
			_orderedSubQuests = _quest.OrderedSubQuests;
			_nonOrderedSubQuests = new List<SubQuestSO>(_quest.NonOrderedSubQuests);
			_getShouldAutoComplete = getShouldAutoComplete;
			_autoCompleteQuest = autoCompleteQuest;
			_remainingOrderedSubQuests = _orderedSubQuests.Count;
			_remainingNonOrderedSubQuests = _nonOrderedSubQuests.Count((SubQuestSO sq) => sq != null);
			_analyticsProgressionEvent = analyticsProgressionEvent;
			_analyticsProgressionTimedEvent = analyticsProgressionTimedEvent;
			_progressionEventTimer = new Stopwatch();
			ResetAllValidators();
		}

		private void ResetAllValidators()
		{
			if (_quest == null)
			{
				this.LogError("Quest reference is null!", "ResetAllValidators", 86);
			}
			foreach (SubQuestSO orderedSubQuest in _orderedSubQuests)
			{
				if (orderedSubQuest == null)
				{
					this.LogError("Ordered Subquest missing at " + _quest.name, "ResetAllValidators", 90);
				}
				if (orderedSubQuest.Validator == null)
				{
					this.LogError("Validator missing at " + _quest.name + "/" + orderedSubQuest.name, "ResetAllValidators", 91);
				}
				orderedSubQuest.Validator.Reset();
			}
			foreach (SubQuestSO nonOrderedSubQuest in _nonOrderedSubQuests)
			{
				if (nonOrderedSubQuest == null)
				{
					this.LogError("Nonordered Subquest missing at " + _quest.name, "ResetAllValidators", 98);
				}
				if (nonOrderedSubQuest.Validator == null)
				{
					this.LogError("Validator missing at " + _quest.name + "/" + nonOrderedSubQuest.name, "ResetAllValidators", 99);
				}
				nonOrderedSubQuest.Validator.Reset();
			}
		}

		public void StartQuest()
		{
			_questStarted = true;
			if (_orderedSubQuests.Count((SubQuestSO sq) => sq == null) > 0)
			{
				this.Log("There's an empty ordered subquest", "StartQuest", 114);
			}
			if (_nonOrderedSubQuests.Count((SubQuestSO sq) => sq == null) > 0)
			{
				this.Log("There's an empty non-ordered subquest", "StartQuest", 119);
			}
			StartNextOrderedSubQuest();
			StartNonOrderedSubQuests();
		}

		private void StartNextOrderedSubQuest()
		{
			if (_orderedSubQuests == null || _orderedSubQuests.Count <= 0)
			{
				_activeOrderedSubQuest = null;
				_allOrderedSubQuestsComplete = true;
				return;
			}
			_activeOrderedSubQuest = _orderedSubQuests[_activeOrderedSubQuestIndex];
			_activeOrderedSubQuest.OnStart();
			if (_activeOrderedSubQuest.SendGAEvent)
			{
				if (_activeOrderedSubQuest.TimedEvent)
				{
					StartTimedProgressionEventTimer();
				}
				_analyticsProgressionEvent.Fire((GAProgressionStatus.Start, _quest.name, _activeOrderedSubQuest.LocaKey, "-"));
			}
			this.OnSubQuestStarted(_activeOrderedSubQuest, _activeOrderedSubQuestIndex);
		}

		private void StartTimedProgressionEventTimer()
		{
			_progressionEventTimer.Reset();
			_progressionEventTimer.Start();
		}

		private void StartNonOrderedSubQuests()
		{
			if (_nonOrderedSubQuests == null || _nonOrderedSubQuests.Count <= 0)
			{
				_allNonOrderedSubQuestsComplete = true;
				return;
			}
			for (int i = 0; i < _nonOrderedSubQuests.Count; i++)
			{
				SubQuestSO subQuestSO = _nonOrderedSubQuests[i];
				subQuestSO.OnStart();
				if (_nonOrderedSubQuests[i].SendGAEvent)
				{
					if (_nonOrderedSubQuests[i].TimedEvent)
					{
						StartTimedProgressionEventTimer();
					}
					_analyticsProgressionEvent.Fire((GAProgressionStatus.Start, _quest.name, _nonOrderedSubQuests[i].LocaKey, "-"));
				}
				this.OnSubQuestStarted(subQuestSO, i + 512);
			}
		}

		public void UpdateQuest()
		{
			if (_allOrderedSubQuestsComplete && _allNonOrderedSubQuestsComplete)
			{
				CompleteQuest();
				return;
			}
			UpdateOrderedSubQuests();
			UpdateNonOrderedSubQuests();
		}

		private void UpdateOrderedSubQuests()
		{
			if (_allOrderedSubQuestsComplete)
			{
				return;
			}
			if (_activeOrderedSubQuest.Validator.IsValid() || _getShouldAutoComplete())
			{
				CompleteOrderedSubQuest();
				if (_activeOrderedSubQuestIndex >= _orderedSubQuests.Count)
				{
					_allOrderedSubQuestsComplete = true;
				}
				else
				{
					StartNextOrderedSubQuest();
				}
			}
			else
			{
				_activeOrderedSubQuest.OnUpdate();
			}
		}

		private void UpdateNonOrderedSubQuests()
		{
			if (_allNonOrderedSubQuestsComplete)
			{
				return;
			}
			for (int i = 0; i < _nonOrderedSubQuests.Count; i++)
			{
				SubQuestSO subQuestSO = _nonOrderedSubQuests[i];
				if (subQuestSO == null)
				{
					continue;
				}
				if (subQuestSO.Validator.IsValid() || _getShouldAutoComplete())
				{
					CompleteNonOrderedSubQuest(subQuestSO, i);
					if (subQuestSO.CompletesEntireQuest)
					{
						_autoCompleteQuest();
					}
				}
				else
				{
					subQuestSO.OnUpdate();
				}
			}
			if (_nonOrderedSubQuests.Count((SubQuestSO sq) => sq != null) <= 0)
			{
				_allNonOrderedSubQuestsComplete = true;
			}
		}

		private void CompleteNonOrderedSubQuest(SubQuestSO nonOrderedSubQuest, int index)
		{
			if (nonOrderedSubQuest.SendGAEvent)
			{
				if (nonOrderedSubQuest.TimedEvent)
				{
					_progressionEventTimer.Stop();
					_analyticsProgressionTimedEvent.Fire((GAProgressionStatus.Complete, _quest.name, nonOrderedSubQuest.LocaKey, "-", (int)_progressionEventTimer.Elapsed.TotalSeconds));
				}
				_analyticsProgressionEvent.Fire((GAProgressionStatus.Complete, _quest.name, nonOrderedSubQuest.LocaKey, "-"));
			}
			nonOrderedSubQuest.OnComplete();
			this.OnSubQuestComplete(nonOrderedSubQuest, index + 512);
			_remainingNonOrderedSubQuests--;
			nonOrderedSubQuest.Validator.Reset();
			_nonOrderedSubQuests[index] = null;
		}

		private void CompleteOrderedSubQuest()
		{
			if (_activeOrderedSubQuest.SendGAEvent)
			{
				if (_activeOrderedSubQuest.TimedEvent)
				{
					_progressionEventTimer.Stop();
					_analyticsProgressionTimedEvent.Fire((GAProgressionStatus.Complete, _quest.name, _activeOrderedSubQuest.LocaKey, "-", (int)_progressionEventTimer.Elapsed.TotalSeconds));
				}
				_analyticsProgressionEvent.Fire((GAProgressionStatus.Complete, _quest.name, _activeOrderedSubQuest.LocaKey, "-"));
			}
			_activeOrderedSubQuest.OnComplete();
			this.OnSubQuestComplete(_activeOrderedSubQuest, _activeOrderedSubQuestIndex);
			_activeOrderedSubQuestIndex++;
			_remainingOrderedSubQuests--;
		}

		private void CompleteQuest()
		{
			this.OnQuestComplete(_quest);
		}

		public void Reset(bool complete = true)
		{
			if (complete)
			{
				CompleteRemainingOrderedSubquests();
				CompleteRemainingNonOrderedSubquests();
			}
			_orderedSubQuests = null;
			_nonOrderedSubQuests = null;
		}

		private void CompleteRemainingNonOrderedSubquests()
		{
			foreach (SubQuestSO nonOrderedSubQuest in _nonOrderedSubQuests)
			{
				if (!(nonOrderedSubQuest == null))
				{
					nonOrderedSubQuest.OnComplete();
				}
			}
		}

		private void CompleteRemainingOrderedSubquests()
		{
			for (int i = _activeOrderedSubQuestIndex; i < _orderedSubQuests.Count; i++)
			{
				_orderedSubQuests[i].OnComplete();
			}
		}
	}
}
