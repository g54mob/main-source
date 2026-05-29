using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class QuestChain : CTSBehaviour
	{
		[SerializeField]
		private float _timeToStartChain;

		private static Quest _currentMainQuest;

		private LockToggle _saveLock = new LockToggle();

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private LevelTitle _levelTitle;

		[field: SerializeField]
		[field: MinValue(0)]
		public int StartingQuest { get; private set; }

		[field: SerializeField]
		public List<Quest> Quests { get; private set; }

		[field: SerializeField]
		public List<Quest> StarQuests { get; private set; }

		private bool IsNewGame => GameMode.IsNewGame;

		protected override void OnDisabled()
		{
			_currentMainQuest = null;
			Quest.QuestSucceeded -= OnQuestSucceeded;
		}

		protected override void OnEnabled()
		{
			Quests.AddRange(StarQuests);
			Initialization(IsNewGame);
			Quest.QuestSucceeded += OnQuestSucceeded;
		}

		private void Initialization(bool newGame)
		{
			QuestChainInitialization();
			if (newGame)
			{
				StartCoroutine(StartQuestChainCoroutine());
				return;
			}
			int num = -1;
			for (int i = 0; i < Quests.Count; i++)
			{
				if (Quests[i].GetQuestState() == QuestState.Success)
				{
					num = i;
				}
			}
			for (int j = 0; j < Quests.Count; j++)
			{
				Quest quest = Quests[j];
				switch (QuestLog.GetQuestState(quest.QuestName))
				{
				case QuestState.Unassigned:
					if (j >= num)
					{
						StartQuest(j);
						return;
					}
					break;
				case QuestState.Active:
					if (j >= num)
					{
						_currentMainQuest = quest;
						_currentMainQuest.ResumeQuest();
						return;
					}
					break;
				case QuestState.Success:
					quest.SuccessConfirmation();
					break;
				}
			}
		}

		private void OnQuestSucceeded(Quest questSucceeded)
		{
			if (Quests.Contains(questSucceeded))
			{
				_currentMainQuest = null;
				StartNextQuest(questSucceeded);
			}
		}

		private void StartNextQuest(Quest previousQuest)
		{
			StartCoroutine(NextQuestCoroutine(previousQuest));
		}

		private IEnumerator NextQuestCoroutine(Quest previousQuest)
		{
			if (Quests.Contains(previousQuest))
			{
				yield return previousQuest.QuestPostSuccessCoroutine();
				int num = Quests.IndexOf(previousQuest) + 1;
				if (num < Quests.Count)
				{
					StartQuest(num);
				}
			}
		}

		private IEnumerator StartQuestChainCoroutine()
		{
			_saveLock.Add(CTSSingleton<ProfileManager>.Instance);
			_saveLock.Lock();
			yield return new WaitWhile(() => _levelTitle.IsVisible);
			foreach (Quest quest in Quests)
			{
				quest.ResetQuest();
			}
			yield return Coroutines.WaitForSecondsUnscaled(_timeToStartChain);
			_saveLock.Unlock();
			SkipQuestsTo(StartingQuest);
			StartQuest(StartingQuest);
		}

		protected virtual void QuestChainInitialization()
		{
			foreach (Quest quest in Quests)
			{
				if (quest is DialogueQuest dialogueQuest)
				{
					dialogueQuest.gameObject.SetActive(value: false);
				}
			}
		}

		private void StartQuest(int quest)
		{
			if (Quests.Count > quest)
			{
				_currentMainQuest = Quests[quest];
				_currentMainQuest.StartQuest();
			}
		}

		public void SkipQuestsTo(int questToReach)
		{
			for (int i = 0; i < questToReach; i++)
			{
				Quests[i].SkipQuest();
			}
		}

		public static void ForceSuccessCurrentMainQuest()
		{
			if ((bool)_currentMainQuest && _currentMainQuest.IsActive)
			{
				_currentMainQuest.ForceQuestSuccess();
			}
		}
	}
}
