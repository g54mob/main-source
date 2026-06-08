using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
	private bool DEBUG_VERBOSE;

	public TextAsset ftueQuestsFile;

	public TextAsset workstationQuestsFile;

	public TextAsset[] additionalQuestFiles;

	private List<Data.Quest> quests;

	private Dictionary<string, Data.Quest> questsDict;

	private List<Data.QuestGroup> questGroups;

	private Dictionary<string, Data.QuestGroup> questGroupDict = new Dictionary<string, Data.QuestGroup>();

	private List<Data.Quest> availableQuests = new List<Data.Quest>();

	private List<Data.Quest> availableWorkstationQuests = new List<Data.Quest>();

	private HashSet<string> availableWorkstationQuestIds = new HashSet<string>();

	private Dictionary<string, int> starDifficultyDict = new Dictionary<string, int>();

	private List<string> aspiringStarDifficultyIds = new List<string>();

	private List<int> aspiringStarDifficulties = new List<int>();

	private List<string> hasSeenQuestIds = new List<string>();

	private List<string> hasPlayedQuestIds = new List<string>();

	private List<string> hasCompletedQuestIds = new List<string>();

	private static QuestController _singleton;

	public List<Data.Quest> AllQuestData => quests;

	public List<Data.QuestGroup> QuestGroups => questGroups;

	public Dictionary<string, Data.QuestGroup> QuestGroupDict => questGroupDict;

	public List<Data.Quest> AvailableQuests => availableQuests;

	public List<Data.Quest> AvailableWorkstationQuests => availableWorkstationQuests;

	public List<string> AspiringStarDifficultyIds => aspiringStarDifficultyIds;

	public List<int> AspiringStarDifficulties => aspiringStarDifficulties;

	public string pendingIncreaseStarForQuestId { get; set; }

	public int pendingIncreaseStarDifficultyForQuest { get; set; }

	public static QuestController singleton => _singleton;

	public event Action<List<Data.Quest>> OnQuestsLoaded;

	public event Action<Data.Quest, bool> OnQuestCompleted;

	public void ClearProgress()
	{
		availableQuests.Clear();
		availableWorkstationQuests.Clear();
		availableWorkstationQuestIds.Clear();
		starDifficultyDict.Clear();
		aspiringStarDifficultyIds.Clear();
		aspiringStarDifficulties.Clear();
		pendingIncreaseStarForQuestId = null;
		pendingIncreaseStarDifficultyForQuest = 0;
		hasSeenQuestIds.Clear();
		hasPlayedQuestIds.Clear();
		hasCompletedQuestIds.Clear();
		OfflineFarmController.singleton.ClearProgress();
	}

	public bool QuestExists(string questId)
	{
		return questsDict.ContainsKey(questId);
	}

	public Data.Quest GetQuestById(string questId)
	{
		if (questsDict.ContainsKey(questId))
		{
			return questsDict[questId];
		}
		if (availableWorkstationQuestIds.Contains(questId))
		{
			return availableWorkstationQuests.Find((Data.Quest q) => q.id == questId);
		}
		Utils.LogWarning("Couldn't find quest " + questId);
		return null;
	}

	public bool HasQuestByIdAndDifficulty(string questId, int difficulty)
	{
		Data.Quest quest = GetQuestById(questId);
		if (quest != null)
		{
			while (quest.level < difficulty && quest.sequelNext != null)
			{
				quest = quest.sequelNext;
			}
			if (quest.level == difficulty)
			{
				return true;
			}
		}
		return false;
	}

	public Data.Quest GetQuestByIdAndDifficulty(string questId, int difficulty)
	{
		Data.Quest quest = GetQuestById(questId);
		if (quest != null)
		{
			while (quest.level < difficulty && quest.sequelNext != null)
			{
				quest = quest.sequelNext;
			}
			if (quest.level == difficulty)
			{
				return quest;
			}
			Utils.LogWarning("Couldn't find quest " + questId + " with difficulty " + difficulty);
		}
		return null;
	}

	public Data.QuestGroup GetQuestGroupById(string questGroupId)
	{
		if (questGroupDict.ContainsKey(questGroupId))
		{
			return questGroupDict[questGroupId];
		}
		return null;
	}

	public int GetStarDifficultyForQuest(string questId)
	{
		if (starDifficultyDict.ContainsKey(questId))
		{
			return starDifficultyDict[questId];
		}
		return 0;
	}

	public void SetStarDifficultyForQuest(int difficulty, string questId)
	{
		if (starDifficultyDict.ContainsKey(questId))
		{
			starDifficultyDict[questId] = difficulty;
		}
		else
		{
			starDifficultyDict.Add(questId, difficulty);
		}
	}

	public void LimitStarDifficultiesForAllQuests()
	{
		int num = 15;
		List<string> list = new List<string>(starDifficultyDict.Keys);
		for (int i = 0; i < list.Count; i++)
		{
			string key = list[i];
			if (starDifficultyDict[key] > num)
			{
				starDifficultyDict[key] = num;
			}
		}
	}

	public int GetAspiringStarDifficulty(string questId)
	{
		int num = aspiringStarDifficultyIds.IndexOf(questId);
		if (num >= 0)
		{
			return aspiringStarDifficulties[num];
		}
		return 0;
	}

	public void SetAspiringStarDifficulty(string questId, int difficulty)
	{
		int num = aspiringStarDifficultyIds.IndexOf(questId);
		if (num >= 0)
		{
			aspiringStarDifficulties[num] = Mathf.Max(aspiringStarDifficulties[num], difficulty);
			return;
		}
		aspiringStarDifficultyIds.Add(questId);
		aspiringStarDifficulties.Add(difficulty);
	}

	public void RemoveAspiringStarDifficulty(string questId)
	{
		int num = aspiringStarDifficultyIds.IndexOf(questId);
		if (num >= 0)
		{
			aspiringStarDifficultyIds.RemoveAt(num);
			aspiringStarDifficulties.RemoveAt(num);
		}
	}

	public bool HasAspiringStarDifficulties()
	{
		return aspiringStarDifficulties.Count > 0;
	}

	public void TryToUnlock(string questId)
	{
		Data.QuestGroup questGroupById = GetQuestGroupById(questId);
		if (questGroupById == null)
		{
			Data.Quest questById = GetQuestById(questId);
			if (questById == null)
			{
				Utils.LogError("Tried to unlock quest " + questId + " but it was not found.");
			}
			else
			{
				TryToUnlock(questById);
			}
			return;
		}
		for (int i = 0; i < questGroupById.grouped_quest_ids.Length; i++)
		{
			string text = questGroupById.grouped_quest_ids[i];
			Data.Quest questById2 = GetQuestById(text);
			if (questById2 == null)
			{
				Utils.LogError("Tried to unlock quest " + text + " from quest group " + questId + " but it was not found.");
			}
			else
			{
				TryToUnlock(questById2);
			}
		}
	}

	public void TryToUnlock(Data.Quest quest)
	{
		if (IsAvailable(quest) || (quest.oneShot && HasCompleted(quest)))
		{
			return;
		}
		int num = 0;
		while (quest.requiredQuests != null && num < quest.requiredQuests.Length)
		{
			if (!HasCompleted(quest.requiredQuests[num]))
			{
				return;
			}
			num++;
		}
		int num2 = 0;
		while (quest.requiredFlags != null && num2 < quest.requiredFlags.Length)
		{
			if (!ProgressFlags.GetFlag(quest.requiredFlags[num2]))
			{
				return;
			}
			num2++;
		}
		int num3 = 0;
		while (quest.requiredItems != null && num3 < quest.requiredItems.Length)
		{
			if (!Inventory.Singleton.HasItemById(quest.requiredItems[num3]))
			{
				return;
			}
			num3++;
		}
		MakeAvailable(quest);
	}

	public bool IsAvailable(string questId)
	{
		for (int i = 0; i < availableQuests.Count; i++)
		{
			if (availableQuests[i].id == questId)
			{
				return true;
			}
		}
		if (IsAvailableWorkstation(questId))
		{
			return true;
		}
		if (questGroupDict.ContainsKey(questId))
		{
			Utils.LogWarning("QuestController::IsAvailable(string) is being called with value " + questId + " which corresponds to a quest GROUP, not a proper quest. This may cause problems.");
		}
		return false;
	}

	public bool IsAvailableWorkstation(string questId)
	{
		return availableWorkstationQuestIds.Contains(questId);
	}

	public bool IsAvailable(Data.Quest quest)
	{
		if (!availableQuests.Contains(quest))
		{
			return availableWorkstationQuests.Contains(quest);
		}
		return true;
	}

	public void MakeAvailable(string questId)
	{
		if (!QuestExceptions.CanMakeAvailable(questId))
		{
			Utils.LogWarning("Did not make quest " + questId + " available due to a quest exception.");
			return;
		}
		Data.QuestGroup questGroupById = GetQuestGroupById(questId);
		if (questGroupById == null)
		{
			Data.Quest questById = GetQuestById(questId);
			if (questById == null)
			{
				Utils.LogError("Tried to make quest " + questId + " available but it was not found.");
			}
			else
			{
				MakeAvailable(questById);
			}
			return;
		}
		for (int i = 0; i < questGroupById.grouped_quest_ids.Length; i++)
		{
			string text = questGroupById.grouped_quest_ids[i];
			Data.Quest questById2 = GetQuestById(text);
			if (questById2 == null)
			{
				Utils.LogError("Tried to make quest " + text + " from quest group " + questId + " available but it was not found.");
			}
			else
			{
				MakeAvailable(questById2);
			}
		}
	}

	public void MakeAvailable(Data.Quest quest)
	{
		if (quest == null)
		{
			Utils.LogError("Tried to make quest available but it was null.");
		}
		else if (IsAvailable(quest))
		{
			Utils.LogWarning("Tried to make quest " + quest.id + " available but.. it's already available.");
		}
		else if (quest.workstation)
		{
			SortInsert(availableWorkstationQuests, quest);
			availableWorkstationQuestIds.Add(quest.id);
		}
		else
		{
			SortInsert(availableQuests, quest);
		}
		if (quest != null && quest.markAsSeen)
		{
			MarkAsSeen(quest.id);
		}
		if (quest != null && !quest.showNewIndicator)
		{
			MarkAsPlayed(quest.id);
		}
	}

	private void SortInsert(List<Data.Quest> questList, Data.Quest questToInsert)
	{
		for (int i = 0; i < questList.Count; i++)
		{
			if (questToInsert.sort >= questList[i].sort)
			{
				questList.Insert(i, questToInsert);
				return;
			}
		}
		questList.Add(questToInsert);
	}

	public void MakeUnavailable(string questId)
	{
		Data.QuestGroup questGroupById = GetQuestGroupById(questId);
		if (questGroupById == null)
		{
			Data.Quest questById = GetQuestById(questId);
			if (questById == null)
			{
				Utils.LogError("Tried to make quest " + questId + " un-available but it was not found.");
			}
			else
			{
				MakeUnavailable(questById);
			}
			return;
		}
		for (int i = 0; i < questGroupById.grouped_quest_ids.Length; i++)
		{
			string text = questGroupById.grouped_quest_ids[i];
			Data.Quest questById2 = GetQuestById(text);
			if (questById2 == null)
			{
				Utils.LogError("Tried to make quest " + text + " from quest group " + questId + " un-available but it was not found.");
			}
			else
			{
				MakeUnavailable(questById2);
			}
		}
	}

	public void MakeUnavailable(Data.Quest quest)
	{
		availableQuests.Remove(quest);
		availableWorkstationQuests.Remove(quest);
		availableWorkstationQuestIds.Remove(quest.id);
	}

	public bool HasSeen(string questId)
	{
		return hasSeenQuestIds.Contains(questId);
	}

	public void MarkAsSeen(string questId)
	{
		if (!hasSeenQuestIds.Contains(questId))
		{
			hasSeenQuestIds.Add(questId);
		}
	}

	public void MarkAsUnseen(string questId)
	{
		hasSeenQuestIds.Remove(questId);
	}

	public bool HasPlayed(string questId)
	{
		return hasPlayedQuestIds.Contains(questId);
	}

	public void MarkAsPlayed(string questId)
	{
		if (!hasPlayedQuestIds.Contains(questId))
		{
			hasPlayedQuestIds.Add(questId);
		}
	}

	public void MarkAsUnplayed(string questId)
	{
		hasPlayedQuestIds.Remove(questId);
	}

	public bool HasCompleted(string questId)
	{
		return hasCompletedQuestIds.Contains(questId);
	}

	public bool HasCompleted(Data.Quest quest)
	{
		if (quest.level > 0)
		{
			return hasCompletedQuestIds.Contains(quest.id + quest.level);
		}
		return hasCompletedQuestIds.Contains(quest.id);
	}

	public bool HasCompletedAtDifficulty(string questId, int difficulty)
	{
		if (difficulty > 0)
		{
			return hasCompletedQuestIds.Contains(questId + difficulty);
		}
		return hasCompletedQuestIds.Contains(questId);
	}

	public void MarkAsCompleted(Data.Quest quest)
	{
		if (!HasCompleted(quest))
		{
			string text = quest.id;
			if (quest.level > 0)
			{
				text += quest.level;
			}
			hasCompletedQuestIds.Add(text);
		}
	}

	public void MarkAsIncomplete(string questId)
	{
		hasCompletedQuestIds.Remove(questId);
	}

	public int GetAvailableQuestIndex(string questId)
	{
		for (int i = 0; i < availableQuests.Count; i++)
		{
			if (availableQuests[i].id == questId)
			{
				return i;
			}
		}
		return -1;
	}

	public void SetAvailableQuestIndex(string questId, int index)
	{
		Data.Quest quest = null;
		for (int i = 0; i < availableQuests.Count; i++)
		{
			if (availableQuests[i].id == questId)
			{
				if (i == index)
				{
					return;
				}
				quest = availableQuests[i];
				break;
			}
		}
		if (quest != null)
		{
			availableQuests.Remove(quest);
			if (index >= availableQuests.Count)
			{
				availableQuests.Add(quest);
			}
			else
			{
				availableQuests.Insert(index, quest);
			}
		}
	}

	public bool PlayerHasSufficientResourcesToPlay(Data.Quest quest)
	{
		if (quest.costs == null)
		{
			return true;
		}
		for (int i = 0; i < quest.costs.Length; i++)
		{
			if (InventoryResources.singleton.GetResourceOfType(quest.costs[i].resource) < quest.costs[i].amount)
			{
				return false;
			}
		}
		return true;
	}

	public List<Data.Cost> GetInsufficientResources(Data.Quest quest)
	{
		List<Data.Cost> list = null;
		if (quest.costs != null)
		{
			for (int i = 0; i < quest.costs.Length; i++)
			{
				long num = quest.costs[i].amount;
				long resourceOfType = InventoryResources.singleton.GetResourceOfType(quest.costs[i].resource);
				if (num > resourceOfType)
				{
					if (list == null)
					{
						list = new List<Data.Cost>();
					}
					Data.Cost cost = new Data.Cost();
					cost.amount = (int)(num - resourceOfType);
					cost.resource = quest.costs[i].resource;
					list.Add(cost);
				}
			}
		}
		return list;
	}

	public void DeductCostsToPlay(Data.Quest quest)
	{
		if (quest.costs == null)
		{
			return;
		}
		for (int i = 0; i < quest.costs.Length; i++)
		{
			if (quest.costs[i].resource != Data.Resource.None)
			{
				InventoryResources.singleton.RemoveResourceOfType(quest.costs[i].resource, quest.costs[i].amount);
			}
		}
	}

	public void ProcessOnPlay(Data.Quest quest)
	{
		if (quest.id != "waterfall" || GameStates.Singleton.parentQuest == null)
		{
			MarkAsPlayed(quest.id);
		}
		if (quest.timeProgress != null)
		{
			quest.timeProgress.elapsedMilliseconds = 0;
		}
		ProcessFlagChanges(quest.onPlay);
		AnalyticsMacros.QuestStarted(quest.id, quest.level);
	}

	public void ProcessOnLeave(Data.Quest quest)
	{
		ProcessFlagChanges(quest.onLeave);
	}

	public void ProcessOnDeath(Data.Quest quest)
	{
		ProcessFlagChanges(quest.onDeath);
	}

	public void ProcessOnComplete(Data.Quest quest)
	{
		MarkAsCompleted(quest);
		ProcessFlagChanges(quest.onComplete);
	}

	public void FireOnComplete(Data.Quest quest, bool firstCompletion)
	{
		this.OnQuestCompleted?.Invoke(quest, firstCompletion);
	}

	public void ProcessFlagChanges(Data.FlagChanges flagChanges)
	{
		if (flagChanges != null)
		{
			int num = 0;
			while (flagChanges.setFlags != null && num < flagChanges.setFlags.Length)
			{
				ProgressFlags.SetFlag(flagChanges.setFlags[num]);
				num++;
			}
			int num2 = 0;
			while (flagChanges.unsetFlags != null && num2 < flagChanges.unsetFlags.Length)
			{
				ProgressFlags.SetFlag(flagChanges.unsetFlags[num2], value: false);
				num2++;
			}
			int num3 = 0;
			while (flagChanges.enableQuests != null && num3 < flagChanges.enableQuests.Length)
			{
				TryToUnlock(flagChanges.enableQuests[num3]);
				num3++;
			}
			int num4 = 0;
			while (flagChanges.disableQuests != null && num4 < flagChanges.disableQuests.Length)
			{
				MakeUnavailable(flagChanges.disableQuests[num4]);
				num4++;
			}
		}
	}

	public void GrantRewards(Data.Quest quest)
	{
		if (quest.rewards == null)
		{
			return;
		}
		for (int i = 0; i < quest.rewards.Length; i++)
		{
			Data.Cost cost = quest.rewards[i];
			if (!ProgressFlags.EvaluateRequiredAndBlockedBy(cost.requiresFlag, cost.blockedByFlag))
			{
				continue;
			}
			if (cost.resource != Data.Resource.None)
			{
				InventoryResources.singleton.AddResourceOfType(cost.resource, cost.amount);
			}
			if (cost.itemId == null)
			{
				continue;
			}
			Item item = Inventory.Singleton.MakeReward(cost.itemId, cost.level);
			if (item != null)
			{
				int count = Mathf.Max(1, cost.amount);
				item = Inventory.Singleton.AddItem(item, count);
				Weapon weapon = item as Weapon;
				if (weapon != null && weapon.autoEquip)
				{
					GameStates.Singleton.hero.Equip(weapon);
				}
			}
		}
	}

	public int GetTotalStars()
	{
		int num = 0;
		for (int i = 0; i < availableQuests.Count; i++)
		{
			Data.Quest quest = availableQuests[i];
			num += GetStarDifficultyForQuest(quest.id);
		}
		return num;
	}

	private void Start()
	{
		LoadQuests();
		if (this.OnQuestsLoaded != null)
		{
			this.OnQuestsLoaded(quests);
		}
	}

	public void AddQuests(Data.Quest[] questDataArray)
	{
		foreach (Data.Quest quest in questDataArray)
		{
			AddQuest(quest);
			if (quest.procGenLevel <= 0 || quest.procGenLevel <= quest.level)
			{
				continue;
			}
			int num = 0;
			for (int j = quest.level + 1; j <= quest.procGenLevel; j++)
			{
				Data.Quest quest2 = new Data.Quest();
				quest2.CopyUnsetValuesFrom(quest);
				quest2.level = j;
				if (quest2.sections != null)
				{
					for (int k = 0; k < quest2.sections.Length; k++)
					{
						Data.QuestSection questSection = quest2.sections[k];
						if (questSection.fixedEncounters != null)
						{
							for (int l = 0; l < questSection.fixedEncounters.Length; l++)
							{
								Data.Encounter encounter = questSection.fixedEncounters[l];
								if (encounter.level == quest.level)
								{
									encounter.level = j;
								}
							}
						}
						if (questSection.procGen != null && questSection.procGen.maxLevel == quest.level)
						{
							questSection.procGen.maxLevel = j;
							num += j;
							if (questSection.procGen.pointsPerLevel >= 0)
							{
								questSection.procGen.points += questSection.procGen.pointsPerLevel * (j - quest.level);
							}
							else
							{
								questSection.procGen.points += num;
							}
						}
					}
				}
				AddQuest(quest2);
			}
		}
	}

	private void AddQuest(Data.Quest quest)
	{
		if (quest.sequel != null)
		{
			quest.sequelRoot = GetQuestById(quest.sequel);
			if (quest.sequelRoot == null)
			{
				Utils.LogError("Quest is a sequel with id " + quest.sequel + ", but the root quest was not found.");
			}
			else
			{
				GetQuestByIdAndDifficulty(quest.sequel, quest.level - 1).sequelNext = quest;
				Data.Trigger[] triggers = quest.triggers;
				quest.CopyUnsetValuesFrom(quest.sequelRoot);
				quest.triggers = triggers;
			}
		}
		quests.Add(quest);
		if (quest.id != null && !questsDict.ContainsKey(quest.id))
		{
			questsDict.Add(quest.id, quest);
		}
		QuestExceptions.AfterQuestDataLoaded(quest);
	}

	public void AddQuestGroups(Data.QuestGroup[] questGroupArray)
	{
		if (questGroupArray == null)
		{
			return;
		}
		foreach (Data.QuestGroup questGroup in questGroupArray)
		{
			if (questGroup.id != null && questGroup.id != "" && questGroup.grouped_quest_ids != null)
			{
				questGroups.Add(questGroup);
				questGroupDict.Add(questGroup.id, questGroup);
			}
		}
	}

	private void LoadQuests()
	{
		quests = new List<Data.Quest>();
		questsDict = new Dictionary<string, Data.Quest>();
		questGroups = new List<Data.QuestGroup>();
		if (DEBUG_VERBOSE)
		{
			Utils.Log("Quest Data: " + ftueQuestsFile.text);
		}
		Data.QuestCollection questCollection = Data.QuestCollection.FromString(ftueQuestsFile.text);
		if (questCollection.quests == null)
		{
			ExceptionHandlingUI.Report("Failed to load ftue quests.");
		}
		if (DEBUG_VERBOSE)
		{
			Utils.Log("Workstation Data: " + workstationQuestsFile.text);
		}
		Data.QuestCollection questCollection2 = Data.QuestCollection.FromString(workstationQuestsFile.text);
		if (questCollection2.quests == null)
		{
			ExceptionHandlingUI.Report("Failed to load workstation quests.");
		}
		for (int i = 0; i < additionalQuestFiles.Length; i++)
		{
			if (additionalQuestFiles[i] != null)
			{
				LoadQuestFile(additionalQuestFiles[i].text);
			}
		}
		AddQuests(questCollection.quests);
		AddQuests(questCollection2.quests);
		AddQuestGroups(questCollection.questGroups);
		AddQuestGroups(questCollection2.questGroups);
		if (DEBUG_VERBOSE)
		{
			for (int j = 0; j < quests.Count; j++)
			{
				Utils.Log("Quest [" + j + "]: \n" + quests[j]);
			}
		}
	}

	private void LoadQuestFile(string questJson)
	{
		Data.QuestCollection questCollection = Data.QuestCollection.FromString(questJson);
		if (questCollection.quests == null)
		{
			ExceptionHandlingUI.Report("Failed to load additional quest " + questJson);
		}
		AddQuests(questCollection.quests);
		AddQuestGroups(questCollection.questGroups);
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		string text = null;
		Data.TimeProgress timeProgress = null;
		List<string> list = new List<string>();
		for (int i = 0; i < availableQuests.Count; i++)
		{
			Data.Quest quest = availableQuests[i];
			list.Add(quest.id);
			if (quest.timeProgress != null && quest.timeProgress.running)
			{
				text = quest.id;
				timeProgress = quest.timeProgress;
			}
		}
		for (int j = 0; j < availableWorkstationQuests.Count; j++)
		{
			Data.Quest quest2 = availableWorkstationQuests[j];
			list.Add(quest2.id);
			if (quest2.timeProgress != null && quest2.timeProgress.running)
			{
				text = quest2.id;
				timeProgress = quest2.timeProgress;
			}
		}
		SlimJson.AddProperty("available", list.ToArray());
		if (text != null)
		{
			SlimJson.AddProperty("time_progress_quest_id", text);
			SlimJson.AddProperty("time_progress", timeProgress.ToString());
		}
		SlimJson.BeginSerialization();
		foreach (KeyValuePair<string, int> item in starDifficultyDict)
		{
			SlimJson.AddProperty(item.Key, item.Value);
		}
		string property = SlimJson.EndSerialization();
		SlimJson.AddProperty("star_levels", property);
		SlimJson.AddProperty("aspiring_star_ids", aspiringStarDifficultyIds.ToArray());
		SlimJson.AddProperty("aspiring_stars", aspiringStarDifficulties.ToArray());
		if (pendingIncreaseStarForQuestId != null)
		{
			SlimJson.AddProperty("pendingStarQuestId", pendingIncreaseStarForQuestId);
			SlimJson.AddProperty("pendingStarValue", pendingIncreaseStarDifficultyForQuest);
		}
		SlimJson.AddProperty("has_seen", hasSeenQuestIds.ToArray());
		SlimJson.AddProperty("has_played", hasPlayedQuestIds.ToArray());
		SlimJson.AddProperty("has_completed", hasCompletedQuestIds.ToArray());
		OfflineFarmController.singleton.Serialize();
		return SlimJson.EndSerialization();
	}

	public void Parse(string sjson)
	{
		CrashReportController.singleton.AddBreadcrumb("1");
		availableQuests.Clear();
		availableWorkstationQuests.Clear();
		availableWorkstationQuestIds.Clear();
		string[] array = SlimJson.ParseArray(sjson, "available");
		for (int num = array.Length - 1; num >= 0; num--)
		{
			string questId = array[num];
			MakeAvailable(questId);
		}
		CrashReportController.singleton.AddBreadcrumb("2");
		string text = SlimJson.Parse(sjson, "time_progress_quest_id");
		if (text != null)
		{
			Data.TimeProgress timeProgress = SlimJson.Parse(sjson, "time_progress", Data.TimeProgress.FromString);
			Data.Quest questById = GetQuestById(text);
			if (questById != null)
			{
				questById.timeProgress = timeProgress;
			}
		}
		CrashReportController.singleton.AddBreadcrumb("3");
		starDifficultyDict.Clear();
		string sjson2 = SlimJson.Parse(sjson, "star_levels");
		foreach (string key in array)
		{
			int num2 = SlimJson.ParseInt(sjson2, key, -1);
			if (num2 >= 0)
			{
				starDifficultyDict.Add(key, num2);
			}
		}
		aspiringStarDifficultyIds.Clear();
		aspiringStarDifficulties.Clear();
		string[] array2 = SlimJson.ParseArray(sjson, "aspiring_star_ids");
		if (array2 != null)
		{
			aspiringStarDifficultyIds.AddRange(array2);
			int[] collection = SlimJson.ParseArray(sjson, "aspiring_stars", Utils.ParseInt);
			aspiringStarDifficulties.AddRange(collection);
		}
		if (aspiringStarDifficultyIds.Count != aspiringStarDifficulties.Count)
		{
			aspiringStarDifficultyIds.Clear();
			aspiringStarDifficulties.Clear();
			ExceptionHandlingUI.Report("Mismatch in Aspiring Star Difficulties. " + SlimJson.Parse(sjson, "aspiring_star_ids") + "; " + SlimJson.Parse(sjson, "aspiring_stars"));
		}
		pendingIncreaseStarForQuestId = SlimJson.Parse(sjson, "pendingStarQuestId");
		pendingIncreaseStarDifficultyForQuest = SlimJson.ParseInt(sjson, "pendingStarValue");
		hasSeenQuestIds.Clear();
		string[] array3 = SlimJson.ParseArray(sjson, "has_seen");
		if (array3 != null)
		{
			hasSeenQuestIds.AddRange(array3);
		}
		hasPlayedQuestIds.Clear();
		string[] collection2 = SlimJson.ParseArray(sjson, "has_played");
		hasPlayedQuestIds.AddRange(collection2);
		hasCompletedQuestIds.Clear();
		string[] collection3 = SlimJson.ParseArray(sjson, "has_completed");
		hasCompletedQuestIds.AddRange(collection3);
		OfflineFarmController.singleton.Parse(sjson);
	}

	private void Awake()
	{
		_singleton = this;
	}
}
