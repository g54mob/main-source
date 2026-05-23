using System;
using DG.Tweening;
using Data.Quests;
using Data.Quests.QuestData;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events;
using Events.Analytics;
using Logic.Factory;
using NaughtyAttributes;
using Presentation.Locators;
using UnityEngine;

namespace Logic.Quests
{
	public class QuestManager : MonoBehaviour
	{
		[SerializeField]
		private QuestsDatabaseSO _tutorialQuestDatabase;

		[SerializeField]
		private QuestsDatabaseSO _skipTutorialQuestDatabase;

		[SerializeField]
		private QuestsDatabaseSO _creativeModeQuestDatabase;

		[SerializeField]
		private QuestsDatabaseSO _tutorialDemoQuestDatabase;

		[SerializeField]
		private QuestsDatabaseSO _skipTutorialDemoQuestDatabase;

		[SerializeField]
		private QuestManagerLocator _questManagerLocator;

		[SerializeField]
		private float _delayQuestStart = 1.2f;

		[SerializeField]
		private ShowTutorialSO _showTutorialSO;

		[SerializeField]
		private ZenModeVariableSO _zenModeSO;

		[SerializeField]
		private SaveInfoPersistentSO _saveInfoPersistentSO;

		[Header("Resetting quest data")]
		[SerializeField]
		private HologramsQuestData _hologramsQuestData;

		[SerializeField]
		private BaseEvent _hideNarrationDialogEvent;

		[SerializeField]
		private FactoryLoader _factoryLoader;

		[Header("Analytics")]
		[SerializeField]
		private AnalyticsProgressionEvent _analyticsProgressionEvent;

		[SerializeField]
		private AnalyticsProgressionTimedEvent _analyticsProgressionTimedEvent;

		[Header("Debug")]
		[SerializeField]
		private int _customStartQuestLine;

		private int _currentQuestIndex;

		private QuestController _currentQuestController;

		private bool _allQuestsCompleted;

		private bool _shouldAutoCompleteAll;

		private int _shouldAutoCompleteNextAmount;

		private QuestsDatabaseSO _currentQuestDatabase;

		public int CurrentQuestIndex => _currentQuestIndex;

		public QuestController CurrentQuestController => _currentQuestController;

		public event Action AllQuestsCompleted = delegate
		{
		};

		public event Action<QuestSO> QuestStarted = delegate
		{
		};

		public event Action<QuestSO> QuestCompleted = delegate
		{
		};

		public event Action OnQuestReset = delegate
		{
		};

		public event Action<SubQuestSO, int> OnSubQuestComplete = delegate
		{
		};

		public event Action<SubQuestSO, int> OnSubQuestStarted = delegate
		{
		};

		private void Awake()
		{
			_questManagerLocator.QuestManager = this;
		}

		private void OnDestroy()
		{
			_questManagerLocator.QuestManager = null;
		}

		public void Reset(bool completeCurrentQuest = true)
		{
			_hideNarrationDialogEvent.Fire();
			_allQuestsCompleted = false;
			ResetCurrentQuest(completeCurrentQuest);
			this.OnQuestReset();
			_hologramsQuestData.Reset();
		}

		private void ResetCurrentQuest(bool complete = true)
		{
			if (_currentQuestController != null)
			{
				_currentQuestController.Reset(complete);
				_currentQuestController.OnQuestComplete -= HandleQuestComplete;
				_currentQuestController.OnSubQuestStarted -= HandleOnSubQuestStarted;
				_currentQuestController.OnSubQuestComplete -= HandleOnSubQuestComplete;
				_currentQuestController = null;
			}
		}

		public void SetQuestIndex(int currentIndex, bool showTutorial)
		{
			_showTutorialSO.SetValue(showTutorial);
			_currentQuestIndex = currentIndex;
		}

		public void StartQuest()
		{
			StartQuestLineFromIndex(_currentQuestIndex);
		}

		private void StartQuestLineFromIndex(int currentIndex = 0)
		{
			_currentQuestIndex = currentIndex;
			StartQuestLineFromIndexInternal();
		}

		private void StartQuestLineFromIndexInternal()
		{
			Reset();
			SetCurrentQuestDatabase();
			StartNextQuest();
		}

		private void SetCurrentQuestDatabase()
		{
			if (_zenModeSO.Value)
			{
				_currentQuestDatabase = _creativeModeQuestDatabase;
			}
			else if (_showTutorialSO.Value)
			{
				_currentQuestDatabase = _tutorialDemoQuestDatabase;
			}
			else
			{
				_currentQuestDatabase = _skipTutorialDemoQuestDatabase;
			}
		}

		private void StartNextQuest()
		{
			if (_currentQuestIndex >= _currentQuestDatabase.Count)
			{
				if (!_allQuestsCompleted)
				{
					this.AllQuestsCompleted();
					_shouldAutoCompleteAll = false;
					_allQuestsCompleted = true;
					_currentQuestController = null;
				}
				return;
			}
			QuestSO quest = _currentQuestDatabase[_currentQuestIndex];
			_currentQuestController = new QuestController(quest, GetShouldAutoComplete, SetShouldAutoCompleteRemainingSubQuests, _analyticsProgressionEvent, _analyticsProgressionTimedEvent);
			_currentQuestController.OnQuestComplete += HandleQuestComplete;
			_currentQuestController.OnSubQuestStarted += HandleOnSubQuestStarted;
			_currentQuestController.OnSubQuestComplete += HandleOnSubQuestComplete;
			if (_shouldAutoCompleteAll)
			{
				_currentQuestController.StartQuest();
				return;
			}
			float delay = ((_currentQuestIndex == 0) ? 0f : _delayQuestStart);
			DOTween.Sequence().SetDelay(delay).OnComplete(delegate
			{
				this.QuestStarted(quest);
				_currentQuestController.StartQuest();
			});
		}

		private void HandleOnSubQuestStarted(SubQuestSO subQuest, int index)
		{
			this.OnSubQuestStarted(subQuest, index);
		}

		private void HandleOnSubQuestComplete(SubQuestSO subQuest, int index)
		{
			this.OnSubQuestComplete(subQuest, index);
		}

		private void HandleQuestComplete(QuestSO completedQuest)
		{
			_currentQuestController.OnQuestComplete -= HandleQuestComplete;
			_currentQuestController.OnSubQuestStarted -= HandleOnSubQuestStarted;
			_currentQuestController.OnSubQuestComplete -= HandleOnSubQuestComplete;
			_currentQuestIndex++;
			this.QuestCompleted(completedQuest);
			StartNextQuest();
		}

		private void Update()
		{
			if (_currentQuestController != null && _currentQuestController.QuestStarted && !_allQuestsCompleted)
			{
				_currentQuestController.UpdateQuest();
			}
		}

		public void ForceCompleteQuestsUntil(int questIndex)
		{
			for (int i = _currentQuestIndex; i < questIndex; i++)
			{
				foreach (SubQuestSO orderedSubQuest in _currentQuestDatabase[i].OrderedSubQuests)
				{
					orderedSubQuest.OnStart();
				}
				foreach (SubQuestSO nonOrderedSubQuest in _currentQuestDatabase[i].NonOrderedSubQuests)
				{
					nonOrderedSubQuest.OnStart();
				}
				foreach (SubQuestSO orderedSubQuest2 in _currentQuestDatabase[i].OrderedSubQuests)
				{
					orderedSubQuest2.OnUpdate();
				}
				foreach (SubQuestSO nonOrderedSubQuest2 in _currentQuestDatabase[i].NonOrderedSubQuests)
				{
					nonOrderedSubQuest2.OnUpdate();
				}
				foreach (SubQuestSO orderedSubQuest3 in _currentQuestDatabase[i].OrderedSubQuests)
				{
					orderedSubQuest3.OnComplete();
				}
				foreach (SubQuestSO nonOrderedSubQuest3 in _currentQuestDatabase[i].NonOrderedSubQuests)
				{
					nonOrderedSubQuest3.OnComplete();
				}
			}
		}

		private bool GetShouldAutoComplete()
		{
			_shouldAutoCompleteNextAmount = Mathf.Max(0, _shouldAutoCompleteNextAmount);
			if (!_shouldAutoCompleteAll)
			{
				return _shouldAutoCompleteNextAmount-- > 0;
			}
			return true;
		}

		public void SetShouldAutoCompleteAll()
		{
			_shouldAutoCompleteAll = true;
		}

		public void SetShouldAutoCompleteOnce()
		{
			_shouldAutoCompleteNextAmount = 1;
		}

		public void SetShouldAutoCompleteRemainingSubQuests()
		{
			_shouldAutoCompleteNextAmount = ((_currentQuestController != null) ? _currentQuestController.RemainingActiveSubQuestAmount : 0);
		}

		[Button("Custom Start Quest", EButtonEnableMode.Always)]
		public void CustomStartQuest()
		{
			ForceCompleteQuestsUntil(_customStartQuestLine);
			StartQuestLineFromIndex(_customStartQuestLine);
		}
	}
}
