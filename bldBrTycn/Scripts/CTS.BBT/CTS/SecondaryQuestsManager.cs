using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class SecondaryQuestsManager : QuestsManager, ILockable
	{
		private List<string> _availableSecondaryQuests = new List<string>();

		private List<string> _refusedSecondaryQuests = new List<string>();

		private List<string> _acceptedSecondaryQuests = new List<string>();

		private Dictionary<AssetRef<MapInfoSO>, float> _timers = new Dictionary<AssetRef<MapInfoSO>, float>();

		private Dictionary<string, float> _failTimers = new Dictionary<string, float>();

		public bool IsLocked => ObjectLock.IsLocked();

		[field: SerializeField]
		public SecondaryQuestsManagerData Data { get; private set; }

		private MapInfoSO CurrentLevel => CTSSingleton<GameMode>.Instance.LevelInfo;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public static event Action<Quest, float, float> FailTimerStarted;

		public static event Action<Quest, float, float> FailCountdownUpdated;

		public static event Action<Quest> FailTimerOver;

		protected override void OnDisabled()
		{
			base.OnDisabled();
			SecondaryQuest.SecondaryQuestStarting -= OnSecondaryQuestStarting;
			SecondaryQuest.SecondaryQuestResumed -= OnSecondaryQuestResumed;
			SecondaryQuest.SecondaryQuestRefused -= OnSecondaryQuestRefused;
			SecondaryQuest.SecondaryQuestSuccess -= OnSecondaryQuestSuccess;
			SecondaryQuest.SecondaryQuestFinished -= OnSecondaryQuestFinished;
			CareerProfile.LevelUnlocked -= OnLevelUnlocked;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			SecondaryQuest.SecondaryQuestStarting += OnSecondaryQuestStarting;
			SecondaryQuest.SecondaryQuestResumed += OnSecondaryQuestResumed;
			SecondaryQuest.SecondaryQuestRefused += OnSecondaryQuestRefused;
			SecondaryQuest.SecondaryQuestSuccess += OnSecondaryQuestSuccess;
			SecondaryQuest.SecondaryQuestFinished += OnSecondaryQuestFinished;
			CareerProfile.LevelUnlocked += OnLevelUnlocked;
			SetupQuestsLists();
		}

		private void OnLevelUnlocked(CareerProfile profile, MapInfoSO levelUnlocked)
		{
			AddQuestsToSystem();
			if ((bool)CTSSingleton<GameMode>.Instance && (bool)CurrentLevel && !_timers.ContainsKey(CurrentLevel))
			{
				RestartTimer(CurrentLevel, Data.TimeBeforeFirstSecondaryQuests.RandomInRange());
			}
		}

		private void AddQuestsToSystem()
		{
			CareerProfile careerProfile = CTSSingleton<ProfileManager>.Instance.CurrentProfile as CareerProfile;
			foreach (Quest quest in base.Quests)
			{
				if (quest is SecondaryQuest secondaryQuest && !QuestInSystem(secondaryQuest) && (!secondaryQuest.UnlockingLevel || careerProfile == null || !careerProfile.IsLevelLocked(secondaryQuest.UnlockingLevel)))
				{
					_availableSecondaryQuests.Add(secondaryQuest.QuestName);
				}
			}
		}

		private void SetupQuestsLists()
		{
			if (!CheckQuestsAndReuseIfNeeded())
			{
				if (base.Quests.Count == 0)
				{
					Debug.Log("No Secondary Quests");
				}
				else
				{
					AddQuestsToSystem();
				}
			}
		}

		protected override void OnSceneQuit()
		{
			base.OnSceneQuit();
			StopAllCoroutines();
		}

		protected override void OnSceneLoaded(MapInfoSO mapInfoSO)
		{
			base.OnSceneLoaded(mapInfoSO);
		}

		protected override void OnNewGame()
		{
			base.OnNewGame();
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is FreemodeProfile)
			{
				AddQuestsToSystem();
			}
			RestartTimer(CurrentLevel, Data.TimeBeforeFirstSecondaryQuests.RandomInRange());
		}

		protected override void ResetQuest(Quest quest)
		{
			base.ResetQuest(quest);
			_failTimers.Remove(quest.QuestName);
			_acceptedSecondaryQuests.Remove(quest.QuestName);
			_availableSecondaryQuests.Insert(0, quest.QuestName);
		}

		protected override void ResumeActiveQuests()
		{
			base.ResumeActiveQuests();
			if (!Data.UnauthorizedLevels.Contains(CurrentLevel) && !_reservedQuests.ContainsValue(CurrentLevel))
			{
				ContinueTimer(CurrentLevel);
			}
		}

		private void OnSecondaryQuestResumed(SecondaryQuest quest)
		{
			StartFailTimer(quest);
		}

		private void ContinueTimer(MapInfoSO level)
		{
			StopAllCoroutines();
			StartCoroutine(TimerRoutine(level, _timers.ContainsKey(level) ? _timers[level] : Data.TimeRangeBetweenSecondaryQuests.RandomInRange()));
		}

		private void RestartTimer(MapInfoSO level, float timerDuration)
		{
			StopAllCoroutines();
			StartCoroutine(TimerRoutine(level, timerDuration));
		}

		private IEnumerator TimerRoutine(MapInfoSO level, float timerDuration)
		{
			if (Data.UnauthorizedLevels.Contains(level) || !CheckQuestsAndReuseIfNeeded())
			{
				yield break;
			}
			_timers[level] = timerDuration;
			while (true)
			{
				if (!IsLocked)
				{
					if (_reservedQuests.ContainsValue(CurrentLevel))
					{
						break;
					}
					_timers[CurrentLevel] -= Time.unscaledDeltaTime;
					if (Time.timeScale > 0f && _timers[CurrentLevel] <= 0f)
					{
						TryOfferSecondaryQuest();
					}
					yield return null;
				}
			}
		}

		private void TryOfferSecondaryQuest()
		{
			if (TryGetQuestToOffer(out var quest))
			{
				StopAllCoroutines();
				StartCoroutine(SecondaryQuestOfferRoutine(quest));
			}
		}

		private bool TryGetQuestToOffer(out Quest quest)
		{
			quest = null;
			if (Data.UnauthorizedLevels.Contains(CurrentLevel))
			{
				return false;
			}
			if (!CheckQuestsAndReuseIfNeeded())
			{
				return false;
			}
			switch (Data.SelectionStyle)
			{
			case SecondaryQuestsManagerData.ESelectionStyle.InOrder:
				if (!TryGetQuestByName(_availableSecondaryQuests[0], out quest))
				{
					return false;
				}
				break;
			case SecondaryQuestsManagerData.ESelectionStyle.Random:
				if (!TryGetQuestByName(_availableSecondaryQuests.GetRandom(), out quest))
				{
					return false;
				}
				break;
			}
			return true;
		}

		private bool CheckQuestsAndReuseIfNeeded()
		{
			if (_availableSecondaryQuests.Count > 0)
			{
				return true;
			}
			if (Data.ReuseStyle.HasFlagNonAlloc(SecondaryQuestsManagerData.EReuseStyle.Refused))
			{
				TryReuseRefusedQuests();
			}
			if (Data.ReuseStyle.HasFlagNonAlloc(SecondaryQuestsManagerData.EReuseStyle.Accepted))
			{
				TryReuseAcceptedQuests();
			}
			return _availableSecondaryQuests.Count > 0;
		}

		private bool TryReuseQuestsFromList(List<string> questsToReuse)
		{
			if (questsToReuse.Count == 0)
			{
				return false;
			}
			_availableSecondaryQuests.InsertRange(0, questsToReuse);
			questsToReuse.Clear();
			return true;
		}

		private bool TryReuseRefusedQuests()
		{
			return TryReuseQuestsFromList(_refusedSecondaryQuests);
		}

		private bool TryReuseAcceptedQuests()
		{
			return TryReuseQuestsFromList(_acceptedSecondaryQuests);
		}

		private IEnumerator SecondaryQuestOfferRoutine(Quest quest)
		{
			while (DialogueManager.isConversationActive)
			{
				yield return null;
			}
			OfferSecondaryQuest(quest);
		}

		private void OfferSecondaryQuest(Quest quest)
		{
			if (quest is SecondaryQuest secondaryQuest && !DialogueManager.isConversationActive && _availableSecondaryQuests.Contains(secondaryQuest.QuestName))
			{
				_availableSecondaryQuests.Remove(secondaryQuest.QuestName);
				secondaryQuest.ResetQuest();
				secondaryQuest.OfferQuest();
			}
		}

		private void OnSecondaryQuestRefused(SecondaryQuest quest)
		{
			_refusedSecondaryQuests.Add(quest.QuestName);
			RestartTimer(CurrentLevel, Data.TimeRangeBetweenSecondaryQuests.RandomInRange());
		}

		private void OnSecondaryQuestStarting(SecondaryQuest quest)
		{
			_acceptedSecondaryQuests.Add(quest.QuestName);
			SetCurrentLevel(quest, CTSSingleton<GameMode>.Instance.LevelInfo);
			StartFailTimer(quest);
		}

		private void StartFailTimer(SecondaryQuest quest)
		{
			StopAllCoroutines();
			StartCoroutine(FailTimerRoutine(quest.QuestName, Data.FailTimerDuration));
		}

		private IEnumerator FailTimerRoutine(string questName, float baseTimerDuration)
		{
			if (!TryGetQuestByName(questName, out var quest))
			{
				yield break;
			}
			if (!_failTimers.ContainsKey(questName))
			{
				_failTimers[questName] = baseTimerDuration;
			}
			SecondaryQuestsManager.FailTimerStarted?.Invoke(quest, _failTimers[questName], baseTimerDuration);
			while (_failTimers[questName] > 0f)
			{
				_failTimers[questName] -= Time.deltaTime;
				SecondaryQuestsManager.FailCountdownUpdated?.Invoke(quest, _failTimers[questName], baseTimerDuration);
				if (_failTimers[questName] <= 0f)
				{
					quest.FailQuest();
				}
				yield return null;
			}
		}

		public override void SetCurrentLevel(Quest quest, MapInfoSO level)
		{
			if (!Data.UnauthorizedLevels.Contains(level))
			{
				base.SetCurrentLevel(quest, level);
				if (!_timers.ContainsKey(level))
				{
					_timers.Add(level, Data.TimeBeforeFirstSecondaryQuests.RandomInRange());
				}
			}
		}

		private void OnSecondaryQuestSuccess(SecondaryQuest quest)
		{
			StopAllCoroutines();
		}

		private void OnSecondaryQuestFinished(SecondaryQuest quest)
		{
			SetCurrentLevel(quest, null);
			SecondaryQuestsManager.FailTimerOver?.Invoke(quest);
			_failTimers.Remove(quest.QuestName);
			RestartTimer(CurrentLevel, Data.TimeRangeBetweenSecondaryQuests.RandomInRange());
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}

		public override void Clear()
		{
			base.Clear();
			_timers.Clear();
			_failTimers.Clear();
			_availableSecondaryQuests.Clear();
			_refusedSecondaryQuests.Clear();
			_acceptedSecondaryQuests.Clear();
		}

		private bool QuestInSystem(Quest quest)
		{
			if (!_availableSecondaryQuests.Contains(quest.QuestName) && !_acceptedSecondaryQuests.Contains(quest.QuestName) && !_refusedSecondaryQuests.Contains(quest.QuestName))
			{
				return _reservedQuests.ContainsKey(quest.QuestName);
			}
			return true;
		}

		[Button(null, EButtonEnableMode.Always)]
		private void DebugTryOfferSecondaryQuest()
		{
			if (!Data.UnauthorizedLevels.Contains(CurrentLevel) && !_reservedQuests.ContainsValue(CurrentLevel))
			{
				_timers[CurrentLevel] = 0f;
				TryOfferSecondaryQuest();
			}
		}
	}
}
