using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public abstract class QuestsManager : CTSBehaviour
	{
		protected Dictionary<string, AssetRef<MapInfoSO>> _reservedQuests = new Dictionary<string, AssetRef<MapInfoSO>>();

		private bool _initialized;

		[field: SerializeField]
		public List<Quest> Quests { get; private set; } = new List<Quest>();

		public virtual void SetCurrentLevel(Quest quest, MapInfoSO level)
		{
			if (Quests.Contains(quest))
			{
				if ((bool)level)
				{
					_reservedQuests[quest.QuestName] = level;
				}
				else
				{
					_reservedQuests.Remove(quest.QuestName);
				}
			}
		}

		protected override void OnAwake()
		{
			if (Quests.Count == 0)
			{
				Quests = GetComponentsInChildren<Quest>(includeInactive: true).ToList();
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if (!CTSSingleton<GameMode>.TryGetInstance(out var _))
			{
				OnSceneQuit();
			}
			GameMode.SceneLoaded += OnSceneLoaded;
			GameMode.QuitScene += OnSceneQuit;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			GameMode.SceneLoaded -= OnSceneLoaded;
			GameMode.QuitScene -= OnSceneQuit;
		}

		protected virtual void OnSceneQuit()
		{
			foreach (Quest quest in Quests)
			{
				quest.gameObject.SetActive(value: false);
			}
		}

		protected virtual void OnSceneLoaded(MapInfoSO mapInfoSO)
		{
			if (!_initialized)
			{
				_initialized = true;
				foreach (Quest quest in Quests)
				{
					quest.SetupLocalizedStrings();
				}
			}
			if (GameMode.IsNewGame)
			{
				OnNewGame();
			}
			else
			{
				ResumeActiveQuests();
			}
		}

		protected virtual void OnNewGame()
		{
			foreach (Quest quest in Quests)
			{
				if (_reservedQuests.TryGetValue(quest.QuestName, out var value))
				{
					if (value.Asset == CTSSingleton<GameMode>.Instance.LevelInfo && QuestLog.GetQuestState(quest.QuestName) == QuestState.Active)
					{
						ResetQuest(quest);
					}
					else
					{
						quest.gameObject.SetActive(value: false);
					}
				}
				else
				{
					quest.gameObject.SetActive(value: true);
				}
			}
		}

		protected virtual void ResetQuest(Quest quest)
		{
			_reservedQuests.Remove(quest.QuestName);
			quest.ResetQuest();
			quest.gameObject.SetActive(value: true);
		}

		protected virtual void ResumeActiveQuests()
		{
			foreach (Quest quest in Quests)
			{
				if (_reservedQuests.TryGetValue(quest.QuestName, out var value) && value.Asset != CTSSingleton<GameMode>.Instance.LevelInfo)
				{
					quest.gameObject.SetActive(value: false);
					continue;
				}
				quest.gameObject.SetActive(value: true);
				if (QuestLog.GetQuestState(quest.QuestName) == QuestState.Active)
				{
					quest.ResumeQuest();
				}
			}
		}

		public virtual void Clear()
		{
			_reservedQuests.Clear();
		}

		protected bool TryGetQuestByName(string questName, out Quest quest)
		{
			quest = null;
			foreach (Quest quest2 in Quests)
			{
				if (!(quest2.QuestName != questName))
				{
					quest = quest2;
					return true;
				}
			}
			return false;
		}
	}
}
