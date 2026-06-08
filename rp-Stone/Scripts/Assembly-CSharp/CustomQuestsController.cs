using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Stonescript;
using Stonescript.Compiler;
using Stonescript.Runtime;
using UnityEngine;

public class CustomQuestsController : MonoBehaviour
{
	public enum FTUEStep
	{
		UnlockBasicQuests = 0,
		CompleteFirstBasicQuest = 1,
		CompleteFirstEpicQuest = 2,
		CompleteSecondEpicQuest = 3,
		FtueDone = 4
	}

	[Serializable]
	private class PlayerQuestRecord
	{
		public string questId;

		public bool unlocked;

		public int completedCount;

		public long cooldownTimestamp;

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("questId", questId);
			if (unlocked)
			{
				SlimJson.AddProperty("unlocked", unlocked);
			}
			if (completedCount > 0)
			{
				SlimJson.AddProperty("completed", completedCount);
			}
			if (cooldownTimestamp > 0)
			{
				SlimJson.AddProperty("cooldown", cooldownTimestamp);
			}
			return SlimJson.EndSerialization();
		}

		public static PlayerQuestRecord FromSjson(string sjson)
		{
			return new PlayerQuestRecord
			{
				questId = SlimJson.Parse(sjson, "questId"),
				unlocked = SlimJson.ParseBool(sjson, "unlocked"),
				completedCount = SlimJson.ParseInt(sjson, "completed"),
				cooldownTimestamp = SlimJson.ParseLong(sjson, "cooldown", 0L)
			};
		}
	}

	[SerializeField]
	private int questCounter;

	[SerializeField]
	private int completedQuestsCount;

	[SerializeField]
	private List<Data.CustomQuest> questDefinitions;

	private Dictionary<string, Data.CustomQuest> questDefinitionsById = new Dictionary<string, Data.CustomQuest>();

	[SerializeField]
	private List<Data.CustomQuestInstance> activeQuests = new List<Data.CustomQuestInstance>();

	private List<Data.CustomQuest> epicQuestsEnabled = new List<Data.CustomQuest>();

	private List<string> epicQuestsRevealed = new List<string>();

	[SerializeField]
	private List<string> startingQuests = new List<string>();

	public DateTime nextSpawnDate = DateTime.Now;

	private bool epicSpawnPending;

	public int questSpawnRate = 28800;

	public readonly int MAX_CONCURRENT_BASIC_QUESTS = 3;

	private Machine stonescript;

	private MindStoneGameModel gameModel;

	private HashSet<Data.CustomQuest> questBuildsInProgress = new HashSet<Data.CustomQuest>();

	private static Regex locMatchRegex = new Regex("([a-z_]+)=([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

	public int defaultCooldown = 86400;

	private bool dirtyNextEpicToUnlockId = true;

	private string nextEpicToUnlockId;

	private List<object> callbackParams = new List<object>();

	private StonescriptArray callbackParamList1 = new StonescriptArray();

	private SSLevel curLevel;

	private Stopwatch stopwatch = new Stopwatch();

	private int frameTime = -1;

	private bool initialized;

	private static CustomQuestsController instance = null;

	private Dictionary<string, PlayerQuestRecord> questRecords = new Dictionary<string, PlayerQuestRecord>();

	public List<Data.CustomQuest> QuestDefinitions => questDefinitions;

	public List<Data.CustomQuestInstance> ActiveQuests => activeQuests;

	public FTUEStep ftueStep { get; set; }

	public List<Data.CustomQuest> EpicQuestsUnlocked
	{
		get
		{
			List<Data.CustomQuest> list = new List<Data.CustomQuest>();
			foreach (KeyValuePair<string, PlayerQuestRecord> questRecord in questRecords)
			{
				string key = questRecord.Key;
				Data.CustomQuest questDefinitionById = GetQuestDefinitionById(key);
				if (questDefinitionById != null && !questDefinitionById.IsBasic && questRecord.Value.unlocked)
				{
					list.Add(questDefinitionById);
				}
			}
			return list;
		}
	}

	public int EpicQuestsCompletedCount
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<string, PlayerQuestRecord> questRecord in questRecords)
			{
				if (questRecord.Value.completedCount > 0)
				{
					string key = questRecord.Key;
					Data.CustomQuest questDefinitionById = GetQuestDefinitionById(key);
					if (questDefinitionById != null && !questDefinitionById.IsBasic)
					{
						num++;
					}
				}
			}
			return num;
		}
	}

	public int EpicQuestsTotal => epicQuestsEnabled.Count;

	public List<Data.CustomQuestInstance> EpicQuestsActive => activeQuests.FindAll((Data.CustomQuestInstance q) => !q.IsBasic && q.started);

	public int EpicQuestsActiveCount
	{
		get
		{
			int num = 0;
			foreach (Data.CustomQuestInstance activeQuest in activeQuests)
			{
				if (!activeQuest.def.IsBasic && activeQuest.started)
				{
					num++;
				}
			}
			return num;
		}
	}

	public DateTime lastBasicQuestDate { get; private set; }

	public Machine Machine => stonescript;

	public CustomQuestsScreen customQuestsScreen { get; set; }

	public bool HasQueststoneUnlocked => Inventory.Singleton.HasItemById("quest_stone");

	public static CustomQuestsController Singleton => instance;

	public event Action<Data.CustomQuestInstance> OnQuestStarted;

	public event Action<Data.CustomQuestInstance, int> OnQuestProgress;

	public event Action<Data.CustomQuestInstance> OnQuestCompleted;

	public Data.CustomQuest GetQuestDefinitionById(string questId)
	{
		if (questDefinitionsById.ContainsKey(questId))
		{
			return questDefinitionsById[questId];
		}
		return null;
	}

	public bool IsEpicRevealed(string questId)
	{
		return epicQuestsRevealed.Contains(questId);
	}

	public bool IsEpicCompleted(string questId)
	{
		return GetCompletedCount(questId) > 0;
	}

	public bool IsActive(string questId)
	{
		return activeQuests.Find((Data.CustomQuestInstance q) => q.customQuestId == questId) != null;
	}

	public int GetCompletedCount(string questId)
	{
		if (questRecords.ContainsKey(questId))
		{
			return questRecords[questId].completedCount;
		}
		return 0;
	}

	public string GetNextSpawnTimeRemainingString()
	{
		int num = (int)(nextSpawnDate - DateTime.Now).TotalSeconds;
		if (num < 0)
		{
			num = 0;
		}
		return Utils.FormatTimeCasual(num);
	}

	public void HandleScreenUpdateContents()
	{
		DateTime now = DateTime.Now;
		now = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
		if (!(now > lastBasicQuestDate))
		{
			return;
		}
		int num = 0;
		foreach (Data.CustomQuestInstance activeQuest in activeQuests)
		{
			if (activeQuest.def.IsBasic)
			{
				num++;
			}
		}
		int num2 = 4;
		while (num < MAX_CONCURRENT_BASIC_QUESTS && now > lastBasicQuestDate && num2 > 0)
		{
			GenerateRandomBasicQuest();
			num++;
			lastBasicQuestDate += new TimeSpan(1, 0, 0, 0);
			num2--;
		}
		lastBasicQuestDate = now;
	}

	private void TrySpawnQuests()
	{
		if (!HasQueststoneUnlocked)
		{
			return;
		}
		if (questCounter == 0)
		{
			activeQuests.Clear();
			foreach (string startingQuest in startingQuests)
			{
				Data.CustomQuest questDefinitionById = GetQuestDefinitionById(startingQuest);
				CreateQuest(questDefinitionById, questDefinitionById.IsBasic);
			}
		}
		if (epicSpawnPending && questBuildsInProgress.Count == 0 && DateTime.Now >= nextSpawnDate && GenerateEpic())
		{
			epicSpawnPending = false;
		}
	}

	private void OnCompileComplete(Data.CustomQuest questDef, Data.CustomQuestInstance quest, SSCustomQuest ssQuest, Executable executable, List<Exception> exceptions, Action<SSCustomQuest, List<Exception>> onComplete)
	{
		if (executable != null)
		{
			ssQuest.executable = executable;
			if (quest.data != null)
			{
				ssQuest.SetVariables(quest.data);
			}
			onComplete?.Invoke(ssQuest, exceptions);
		}
		else
		{
			if (exceptions != null)
			{
				foreach (Exception exception in exceptions)
				{
					DiagnosticsUI.singleton.AddStonescriptError(exception.Message);
					UnityEngine.Debug.LogException(exception);
				}
			}
			onComplete?.Invoke(null, exceptions);
		}
		Utils.LogIfEditor("Custom quest " + questDef.scriptName + " compilation complete!");
		questBuildsInProgress.Remove(quest.def);
	}

	public bool IsQuestLoading(Data.CustomQuest questDef)
	{
		return questBuildsInProgress.Contains(questDef);
	}

	private void LoadProgram(Data.CustomQuest questDef, Data.CustomQuestInstance quest, Action<SSCustomQuest, List<Exception>> onComplete = null)
	{
		string scriptName = questDef.scriptName;
		Script script = stonescript.GetScript(scriptName);
		SSCustomQuest ssQuest = new SSCustomQuest(quest, this);
		ssQuest.ObjectType = scriptName;
		if (script == null)
		{
			script = new Script();
			script.name = scriptName;
			script.Source = (Resources.Load("CustomQuests/" + scriptName) as TextAsset).text;
			Utils.LogIfEditor("Building custom quest " + scriptName + "...");
			questBuildsInProgress.Add(questDef);
			stonescript.CompileAsync(script, ssQuest, delegate(Executable executable2, List<Exception> exceptions)
			{
				OnCompileComplete(questDef, quest, ssQuest, executable2, exceptions, onComplete);
			});
		}
		else
		{
			Executable executable = stonescript.New(script, ssQuest);
			OnCompileComplete(questDef, quest, ssQuest, executable, null, onComplete);
		}
	}

	public void AbandonQuest(Data.CustomQuestInstance quest)
	{
		string varId = "OnQuestAbandoned";
		if (quest.ssQuest != null && quest.ssQuest.IsVariable(varId))
		{
			IFunction function = quest.ssQuest.GetFunction(varId);
			if (function != null)
			{
				quest.ssQuest.executable.Execute(function);
			}
		}
		UnlockQuest(quest.def);
		activeQuests.Remove(quest);
	}

	public string GetQuestRestriction(Data.CustomQuest questDef)
	{
		try
		{
			string questLocationRequirement = GetQuestLocationRequirement(questDef);
			if (questLocationRequirement != null)
			{
				return questLocationRequirement;
			}
			if (IsOnCooldown(questDef))
			{
				string arg = Utils.FormatTimeCasual((int)(GetQuestPlayableDate(questDef) - DateTime.UtcNow).TotalSeconds);
				return string.Format(Te.xt("tid_quest_cooldown"), arg);
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
			return "An error occurred";
		}
		return null;
	}

	private string GetQuestLocationRequirement(Data.CustomQuest questDef)
	{
		if (questDef.locReqs == null || questDef.locReqs.Length == 0)
		{
			return null;
		}
		string[] locReqs = questDef.locReqs;
		foreach (string text in locReqs)
		{
			string questId = text;
			int result = 0;
			Match match = locMatchRegex.Match(text);
			if (match.Success)
			{
				questId = match.Groups[1].Value;
				int.TryParse(match.Groups[2].Value, out result);
			}
			if (!QuestController.singleton.IsAvailable(questId) || QuestController.singleton.GetStarDifficultyForQuest(questId) < result)
			{
				Data.Quest questByIdAndDifficulty = QuestController.singleton.GetQuestByIdAndDifficulty(questId, result);
				string arg = "";
				if (result == 1)
				{
					arg = "☆";
				}
				else if (result == 2)
				{
					arg = "☆☆";
				}
				else if (result == 3)
				{
					arg = "☆☆☆";
				}
				else if (result >= 4)
				{
					arg = "☆" + result + "☆";
				}
				string arg2 = Te.xt(questByIdAndDifficulty.name);
				if (result > 0)
				{
					arg2 = ((!(Te.id == "ZH-CN") && !(Te.id == "JP")) ? $"{arg2} {arg}" : $"{arg2}{arg}");
				}
				return string.Format(Te.xt("tid_quest_requires"), arg2);
			}
		}
		return null;
	}

	public void SetCooldown(Data.CustomQuestInstance quest, int cooldown = -1)
	{
		PlayerQuestRecord orCreatePlayerQuestRecord = GetOrCreatePlayerQuestRecord(quest.def.id);
		if (cooldown < 0)
		{
			cooldown = defaultCooldown;
		}
		long num = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
		num += cooldown;
		orCreatePlayerQuestRecord.cooldownTimestamp = num;
	}

	public bool IsOnCooldown(Data.CustomQuest questDef)
	{
		if (!questRecords.ContainsKey(questDef.id) || questRecords[questDef.id].cooldownTimestamp <= 0)
		{
			return false;
		}
		return DateTimeOffset.FromUnixTimeSeconds(questRecords[questDef.id].cooldownTimestamp).DateTime > DateTime.UtcNow;
	}

	public DateTime GetQuestPlayableDate(Data.CustomQuest questDef)
	{
		if (!questRecords.ContainsKey(questDef.id) || questRecords[questDef.id].cooldownTimestamp <= 0)
		{
			return DateTime.UtcNow;
		}
		return DateTimeOffset.FromUnixTimeSeconds(questRecords[questDef.id].cooldownTimestamp).DateTime;
	}

	public void ReplayQuest(Data.CustomQuest questDef)
	{
		foreach (Data.CustomQuestInstance item in activeQuests.FindAll((Data.CustomQuestInstance q) => !q.IsBasic))
		{
			if (!questRecords.ContainsKey(item.def.id))
			{
				GetOrCreatePlayerQuestRecord(item.def.id);
			}
			activeQuests.Remove(item);
		}
		CreateQuest(questDef);
	}

	private bool GenerateEpic(Data.CustomQuest questDef = null)
	{
		if (questDef == null)
		{
			string nextEpicToUnlock = GetNextEpicToUnlock();
			if (nextEpicToUnlock != null)
			{
				questDef = GetQuestDefinitionById(nextEpicToUnlock);
			}
		}
		if (questDef == null)
		{
			return false;
		}
		CreateQuest(questDef, startQuest: false);
		return true;
	}

	public void GenerateRandomBasicQuest()
	{
		int i = 0;
		Data.CustomQuest questDef = SelectRandomBasicQuest();
		for (; i < 12; i++)
		{
			if (activeQuests.Find((Data.CustomQuestInstance q) => q.customQuestId == questDef.id) == null)
			{
				break;
			}
			questDef = SelectRandomBasicQuest();
		}
		if (questDef != null)
		{
			CreateQuest(questDef, questDef.IsBasic);
			customQuestsScreen.MarkDirty();
		}
	}

	public void GenerateAllBasicQuests()
	{
	}

	public void ClearAllBasicQuests()
	{
	}

	public void SkipLegendUnlockDelay()
	{
	}

	public void CreateQuest(Data.CustomQuest questDef, bool startQuest = true)
	{
		if (!questDef.isEnabled)
		{
			Utils.LogWarningIfEditor("Playing quest " + questDef.id + " that still has isEnabled = false.");
		}
		Data.CustomQuestInstance quest = new Data.CustomQuestInstance();
		quest.instanceId = questCounter++;
		quest.customQuestId = questDef.id;
		quest.def = questDef;
		SetStatus(quest, questDef.intro);
		CreateReward(quest);
		LoadProgram(questDef, quest, delegate(SSCustomQuest ssQuest, List<Exception> exceptions)
		{
			OnQuestReady(quest, ssQuest, exceptions, startQuest);
		});
	}

	public string GetNextEpicToUnlock()
	{
		if (dirtyNextEpicToUnlockId)
		{
			dirtyNextEpicToUnlockId = false;
			nextEpicToUnlockId = null;
			List<Data.CustomQuest> list = new List<Data.CustomQuest>();
			List<string> list2 = new List<string>();
			foreach (KeyValuePair<string, PlayerQuestRecord> questRecord in questRecords)
			{
				string questId = questRecord.Value.questId;
				Data.CustomQuest questDefinitionById = GetQuestDefinitionById(questId);
				if (questDefinitionById != null && !questDefinitionById.IsBasic)
				{
					list.Add(questDefinitionById);
					list2.Add(questId);
				}
			}
			foreach (Data.CustomQuest item in list)
			{
				if (item.unlockQuests == null)
				{
					continue;
				}
				string[] unlockQuests = item.unlockQuests;
				foreach (string text in unlockQuests)
				{
					if (!list2.Contains(text))
					{
						Data.CustomQuest questDefinitionById2 = GetQuestDefinitionById(text);
						if (questDefinitionById2.isEnabled && questDefinitionById2.IsReleased())
						{
							nextEpicToUnlockId = text;
							return nextEpicToUnlockId;
						}
					}
				}
			}
		}
		return nextEpicToUnlockId;
	}

	private void OnQuestReady(Data.CustomQuestInstance quest, SSCustomQuest ssQuest, List<Exception> exceptions, bool startQuest)
	{
		quest.ssQuest = ssQuest;
		if (quest.ssQuest == null)
		{
			if (exceptions.Count > 0)
			{
				CustomQuestsRowAdvanced rowForQuest = customQuestsScreen.GetRowForQuest(quest.def);
				if (rowForQuest != null)
				{
					rowForQuest.SetError(exceptions[0].Message);
				}
			}
			return;
		}
		Data.CustomQuest def = quest.def;
		quest.ssQuest.executable.Execute();
		if (startQuest && def.init != null)
		{
			StonescriptObject stonescriptObject = new StonescriptObject("data");
			if (def.data != null)
			{
				foreach (KeyValuePair<string, object> datum in def.data)
				{
					object obj = datum.Value;
					if (obj is IEnumerable<object>)
					{
						StonescriptArray stonescriptArray = new StonescriptArray("array");
						stonescriptArray.AddRange(obj as IEnumerable<object>);
						obj = stonescriptArray;
					}
					stonescriptObject.DeclareVariable(datum.Key, obj);
				}
			}
			quest.ssQuest.executable.Execute(def.init, new List<object> { stonescriptObject });
		}
		quest.loaded = true;
		if (!quest.IsBasic)
		{
			UnlockQuest(quest.def);
		}
		if (startQuest)
		{
			if (quest.IsBasic && activeQuests.Count > 0 && quest.customQuestId == "quest_1")
			{
				activeQuests.Insert(0, quest);
			}
			else if (quest.IsBasic && activeQuests.Count > 0 && quest.customQuestId == "quest_2")
			{
				activeQuests.Insert(1, quest);
			}
			else
			{
				activeQuests.Add(quest);
			}
			StartQuest(quest);
		}
		UpdateBadge();
		customQuestsScreen.MarkDirty();
	}

	public void StartQuest(Data.CustomQuestInstance quest)
	{
		if (!quest.started)
		{
			AnalyticsMacros.EpicQuestStarted(quest.customQuestId);
			quest.started = true;
			quest.ssQuest.executable.Execute("OnQuestStart");
			this.OnQuestStarted?.Invoke(quest);
		}
	}

	public void UnlockQuest(Data.CustomQuest questDef)
	{
		if (!questRecords.ContainsKey(questDef.id) || !questRecords[questDef.id].unlocked)
		{
			GetOrCreatePlayerQuestRecord(questDef.id).unlocked = true;
			dirtyNextEpicToUnlockId = true;
			customQuestsScreen.MarkDirty();
		}
	}

	private Data.CustomQuest SelectRandomBasicQuest()
	{
		List<Data.CustomQuest> list = questDefinitions.FindAll((Data.CustomQuest qd) => qd.autoGen);
		int num = 0;
		foreach (Data.CustomQuest item in list)
		{
			num += item.weight;
		}
		int num2 = UnityEngine.Random.Range(0, num);
		int num3 = 0;
		Data.CustomQuest result = null;
		foreach (Data.CustomQuest item2 in list)
		{
			num3 += item2.weight;
			if (num3 > num2)
			{
				result = item2;
				break;
			}
		}
		return result;
	}

	public void UpdateBadge()
	{
		QuestStoneNavButton questStoneButton = GameStates.Singleton.navBar.questStoneButton;
		if (ftueStep == FTUEStep.UnlockBasicQuests)
		{
			questStoneButton.SetState(QuestStoneNavButton.State.UnlockAvailable);
			return;
		}
		if (EpicQuestsUnlocked.FindAll((Data.CustomQuest q) => !epicQuestsRevealed.Contains(q.id)).Count > 0)
		{
			questStoneButton.SetState(QuestStoneNavButton.State.UnlockAvailable);
			return;
		}
		Data.WeeklyQuest activeQuest = WeeklyQuestsController.singleton.activeQuest;
		if (activeQuest != null && (activeQuest.completed || !activeQuest.hasSeen))
		{
			questStoneButton.SetState(QuestStoneNavButton.State.KiTreasureAvailable);
			return;
		}
		if (activeQuests.FindAll((Data.CustomQuestInstance q) => q.completed && !q.rewardClaimed).Count > 0 || ReferralController.singleton.HasTreasureToCollect() || EventController.singleton.GetPendingRewardsEventController() != null)
		{
			questStoneButton.SetState(QuestStoneNavButton.State.RewardAvailable);
			return;
		}
		BaseEventController2 activeEventController = EventController.singleton.GetActiveEventController();
		if (activeEventController != null && activeEventController.HasObjectivesToClaim())
		{
			questStoneButton.SetState(QuestStoneNavButton.State.RewardAvailable);
		}
		else
		{
			questStoneButton.SetState(QuestStoneNavButton.State.Idle);
		}
	}

	public bool Complete(Data.CustomQuestInstance quest)
	{
		if (quest.completed)
		{
			return true;
		}
		if (!activeQuests.Contains(quest))
		{
			return false;
		}
		AnalyticsMacros.EpicQuestCompleted(quest.customQuestId);
		quest.completed = true;
		completedQuestsCount++;
		GetOrCreatePlayerQuestRecord(quest.def.id).completedCount++;
		if (quest.reward == null)
		{
			ClaimReward(quest);
		}
		CustomQuestsRowAdvanced rowForQuest = customQuestsScreen.GetRowForQuest(quest);
		if ((bool)rowForQuest)
		{
			rowForQuest.Close();
		}
		customQuestsScreen.MarkDirty();
		UpdateBadge();
		this.OnQuestCompleted?.Invoke(quest);
		if (EpicQuestsCompletedCount == EpicQuestsTotal)
		{
			AchievementController.singleton.ReportAllEpicQuestsCompleted();
		}
		return true;
	}

	public void UpdateProgress(Data.CustomQuestInstance quest, int progress, int target, int? prevProgress = null)
	{
		int num = (prevProgress.HasValue ? prevProgress.Value : quest.progress);
		quest.target = target;
		quest.progress = Mathf.Min(progress, target);
		if (progress == target)
		{
			SfxController.singleton.Play("level_up");
			if (quest.IsBasic)
			{
				AnalyticsMacros.DailyQuestComplete();
			}
		}
		if (activeQuests.Contains(quest) && !quest.completed)
		{
			if (progress > 0 && progress != num)
			{
				this.OnQuestProgress?.Invoke(quest, num);
			}
			customQuestsScreen.MarkDirty();
		}
	}

	public void SetStatus(Data.CustomQuestInstance quest, string status)
	{
		if (status != null && status.StartsWith("tid_"))
		{
			status = Te.xt(status);
		}
		quest.status = status;
		if (quest.IsBasic || quest.loaded)
		{
			customQuestsScreen.MarkDirty();
		}
	}

	public void SetProgressTitle(Data.CustomQuestInstance quest, string title)
	{
		if (title.StartsWith("tid_"))
		{
			title = Te.xt(title);
		}
		quest.progressTitle = title;
	}

	public void SetSeen(Data.CustomQuestInstance quest, bool seen = true)
	{
		quest.seen = seen;
		if (!seen)
		{
			GameStates.Singleton.navBar.questStoneButton.SetState(QuestStoneNavButton.State.RewardAvailable);
		}
	}

	public void SetEpicRevealed(string questId)
	{
		if (!epicQuestsRevealed.Contains(questId))
		{
			epicQuestsRevealed.Add(questId);
		}
	}

	private void HandleCharacterDamaged(Character c, Damage damage)
	{
		bool flag = false;
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnUnitDamaged";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (!flag)
					{
						StonescriptObject ssObject = c.ssObject;
						SSNativeObject item = new SSNativeObject(damage);
						callbackParams.Clear();
						callbackParams.Add(ssObject);
						callbackParams.Add(item);
						flag = true;
					}
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	private void HandleCharacterDied(Character c, Character.DeathReason reason, Damage damage)
	{
		bool flag = false;
		StonescriptObject stonescriptObject = null;
		SSNativeObject item = null;
		string text = null;
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnUnitKilled";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (!flag)
					{
						text = reason.ToString();
						stonescriptObject = new StonescriptObject("enemy");
						stonescriptObject.DeclareVariable("name", c.displayName);
						stonescriptObject.DeclareVariable("reason", text);
						stonescriptObject.DeclareVariable("element", c.GetElement().ToString());
						stonescriptObject.DeclareVariable("isEnemy", c is Enemy);
						if (damage != null)
						{
							item = new SSNativeObject(damage);
						}
						flag = true;
					}
					callbackParams.Clear();
					if (function.ParameterNames.Count == 1)
					{
						callbackParams.Add(stonescriptObject);
					}
					else if (function.ParameterNames.Count == 3)
					{
						callbackParams.Add(c.ssObject);
						callbackParams.Add(text);
						callbackParams.Add(item);
					}
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	private void HandleResourceHarvested(Data.Resource resourceType, int amount)
	{
		callbackParams.Clear();
		callbackParams.Add(resourceType.ToString());
		callbackParams.Add(amount);
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnResourceHarvested";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	private void HandleSkullGameWon()
	{
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnSkullGameWon";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	private void HandlePotionConsumed(Potion potion)
	{
		callbackParams.Clear();
		callbackParams.Add(potion.type.ToString());
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnPotionConsumed";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	private void HandleQuestCompleted(Data.Quest questCompleted, bool firstCompletion)
	{
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnQuestCompleted";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					callbackParams.Clear();
					callbackParams.Add(questCompleted.ssObject);
					if (function.ParameterNames.Count == 2)
					{
						callbackParams.Add(firstCompletion);
					}
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	private void HandleItemGained(Item item, int amount)
	{
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnItemGained";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (callbackParams.Count == 0)
					{
						callbackParams.Add(item.ssObject);
						callbackParams.Add(amount);
					}
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	private void HandleTreasureOpened(string itemId, string groupId, List<Item> rewards, List<int> itemCounts)
	{
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnTreasureOpened";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (callbackParams.Count == 0)
					{
						callbackParams.Add(itemId);
						callbackParams.Add(groupId);
						StonescriptArray ssRewards = new StonescriptArray(rewards.Count);
						rewards.ForEach(delegate(Item item)
						{
							ssRewards.Add(item.ssObject);
						});
						callbackParams.Add(ssRewards);
						StonescriptArray ssCounts = new StonescriptArray(rewards.Count);
						itemCounts.ForEach(delegate(int value)
						{
							ssCounts.Add(value);
						});
						callbackParams.Add(ssCounts);
					}
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	private void HandleLocStart(Data.Quest q)
	{
		curLevel = new SSLevel(GameStates.Singleton.level, q.ssObject);
		curLevel.stonescript = stonescript;
		curLevel.gameModel = gameModel;
		callbackParams.Clear();
		callbackParams.Add(q.ssObject);
		callbackParams.Add(curLevel);
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			if (customQuestInstance.ssQuest != null)
			{
				customQuestInstance.ssQuest.Level = curLevel;
				string varId = "OnLocStart";
				if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
				{
					IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
					if (function != null)
					{
						customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
					}
				}
			}
		}
	}

	private void HandleNextSection(Level level, int sectionIndex, List<Character> spawnedCharacters)
	{
		callbackParams.Clear();
		callbackParams.Add(curLevel);
		callbackParams.Add(null);
		callbackParams.Add(sectionIndex);
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnNextSection";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	private void HandleQuestEnd()
	{
		CustomQuestsUi.Singleton.ClearNPCDialogs();
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnLocEnd";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	public void HandleQuestButtonPressed(DialogButton button)
	{
		CustomQuestsRow customQuestsRow = button as CustomQuestsRow;
		if (customQuestsRow == null || customQuestsRow.quest == null)
		{
			return;
		}
		callbackParams.Clear();
		Data.CustomQuestInstance quest = customQuestsRow.quest;
		string varId = "OnQuestRowPressed";
		if (quest.ssQuest != null && quest.ssQuest.IsVariable(varId))
		{
			IFunction function = quest.ssQuest.GetFunction(varId);
			if (function != null)
			{
				quest.ssQuest.executable.Execute(function, callbackParams);
			}
		}
	}

	public Data.Quest HandlePreLoc(Data.Quest questData)
	{
		SSNativeObject<Data.Quest> sSNativeObject = questData.ssObject;
		callbackParams.Clear();
		callbackParams.Add(sSNativeObject);
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnPreLoc";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					object obj = customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
					if (obj != null)
					{
						if (!(obj is SSNativeObject<Data.Quest>))
						{
							throw new StonescriptRuntimeException("OnPreLoc returned an invalid object");
						}
						sSNativeObject = obj as SSNativeObject<Data.Quest>;
					}
				}
			}
		}
		if (sSNativeObject == null)
		{
			return questData;
		}
		return sSNativeObject.Source;
	}

	public void HandlePreCauldronBrew(Potion.Type type)
	{
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnPreBrew";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (callbackParams.Count == 0)
					{
						callbackParams.Add(type.ToString());
					}
					object obj = customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
					if (obj is bool && !(bool)obj)
					{
						CauldronScreen.singleton.brewInterrupted = true;
					}
				}
			}
		}
	}

	public void HandlePreAnvilFuse(Item itemA, Item itemB, int itemBCount)
	{
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnPreAnvil";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (callbackParams.Count == 0)
					{
						callbackParams.Add(itemA.ssObject);
						callbackParams.Add(itemB.ssObject);
						callbackParams.Add(itemBCount);
					}
					object obj = customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
					if (obj is bool && !(bool)obj)
					{
						AnvilScreen.singleton.craftInterrupted = true;
					}
				}
			}
		}
	}

	private void HandleAnvilFuse(ItemFactory.Result result)
	{
		callbackParams.Clear();
		callbackParams.Add(result.resultingItem.displayName);
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnAnvilFuse";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	public void HandlePreFissure(Item item, int count)
	{
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnPreFissure";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (callbackParams.Count == 0)
					{
						callbackParams.Add(item.ssObject);
						callbackParams.Add(count);
					}
					object obj = customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
					if (obj is bool && !(bool)obj)
					{
						FissureStoneScreen.singleton.craftInterrupted = true;
					}
				}
			}
		}
	}

	public void HandleFissure(ItemFactory.Result fissureResult, int count)
	{
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnFissure";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (callbackParams.Count == 0)
					{
						callbackParamList1.Clear();
						callbackParamList1.Add(fissureResult.itemA.ssObject);
						callbackParamList1.Add(fissureResult.itemB.ssObject);
						callbackParams.Add(fissureResult.resultingItem.ssObject);
						callbackParams.Add(count);
						callbackParams.Add(callbackParamList1);
					}
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	public void HandlePreUnmakeItem(Item item, int count)
	{
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnPreUnmakeItem";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (callbackParams.Count == 0)
					{
						callbackParams.Add(item.ssObject);
						callbackParams.Add(count);
					}
					object obj = customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
					if (obj is bool && !(bool)obj)
					{
						FissureStoneScreen.singleton.craftInterrupted = true;
					}
				}
			}
		}
	}

	public void HandleUnmakeItem(Item item, int count, int kiValue)
	{
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnUnmakeItem";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (callbackParams.Count == 0)
					{
						callbackParams.Add(item.ssObject);
						callbackParams.Add(count);
						callbackParams.Add(kiValue);
					}
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
				}
			}
		}
	}

	public void HandlePreTriskelionFuse(Item primaryItem, Item boostItemA, Item boostItemB, Item boostItemC)
	{
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnPreTriskelion";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (callbackParams.Count == 0)
					{
						callbackParams.Add(primaryItem.ssObject);
						callbackParams.Add(boostItemA.ssObject);
						callbackParams.Add(boostItemB.ssObject);
						callbackParams.Add(boostItemC.ssObject);
					}
					object obj = customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
					if (obj is bool && !(bool)obj)
					{
						TriskelionScreen.singleton.craftInterrupted = true;
					}
				}
			}
		}
	}

	public void HandlePreMoondialMutate(Item item)
	{
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnPreMutate";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (callbackParams.Count == 0)
					{
						callbackParams.Add(item.ssObject);
					}
					object obj = customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
					if (obj is bool && !(bool)obj)
					{
						MoondialScreen.singleton.craftInterrupted = true;
					}
				}
			}
		}
	}

	public void HandleTic()
	{
		callbackParams.Clear();
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OnTic";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					stopwatch.Restart();
					customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
					stopwatch.Stop();
					frameTime = (int)stopwatch.ElapsedMilliseconds;
					if (DevicePerformanceGUI.singleton != null)
					{
						DevicePerformanceGUI.singleton.AddStonescriptMilliseconds(frameTime);
					}
				}
			}
		}
	}

	public int OverrideLocationDifficulty(Data.Quest questData, int difficulty)
	{
		callbackParams.Clear();
		bool flag = false;
		for (int num = activeQuests.Count - 1; num >= 0; num--)
		{
			Data.CustomQuestInstance customQuestInstance = activeQuests[num];
			string varId = "OverrideLocDifficulty";
			if (customQuestInstance.ssQuest != null && customQuestInstance.ssQuest.IsVariable(varId))
			{
				IFunction function = customQuestInstance.ssQuest.GetFunction(varId);
				if (function != null)
				{
					if (!flag)
					{
						callbackParams.Add(questData.ssObject);
						callbackParams.Add(difficulty);
						flag = true;
					}
					object obj = customQuestInstance.ssQuest.executable.Execute(function, callbackParams);
					if (obj is int)
					{
						return (int)obj;
					}
				}
			}
		}
		return difficulty;
	}

	private object FindObject(List<object> parameters, InvocationContext ctx)
	{
		string text = parameters[0] as string;
		GameObject gameObject = GameObject.Find(text);
		if (gameObject == null)
		{
			return null;
		}
		SSScriptableObject component = gameObject.GetComponent<SSScriptableObject>();
		if (component == null)
		{
			UnityEngine.Debug.LogWarning("Find was able to find object \"" + text + "\" but it is not a scriptable object.");
			return null;
		}
		return component.Target;
	}

	private void InitStonescript()
	{
		gameModel = new MindStoneGameModel();
		gameModel.bindToMindstone = false;
		gameModel.drawWhilePaused = true;
		gameModel.SetInputProvider(MindStoneController.singleton.GetComponent<MindstoneInputProvider>());
		stonescript = new Machine();
		stonescript.Compiler.compileImports = false;
		stonescript.CreateComponent("Custom Quests");
		Machine machine = stonescript;
		machine.OnError = (Action<Exception>)Delegate.Combine(machine.OnError, (Action<Exception>)delegate(Exception ex)
		{
			string message = " " + ex.Message + " ";
			GameplayActionMessages.SetMessage(message, ColorConstants.red);
			DiagnosticsUI.singleton.AddStonescriptError(message);
			UnityEngine.Debug.LogException(ex);
		});
		stonescript.MAX_EXECUTION_TIME = -1;
		StonescriptGlobals.RegisterAll(stonescript, gameModel);
		stonescript.RegisterFunction("Find", FindObject);
		stonescript.RegisterFunction("debug.Log", StonescriptGlobals.Debug_Log);
		stonescript.RegisterFunction("debug.LogWarning", StonescriptGlobals.Debug_LogWarning);
		stonescript.RegisterFunction("ItemData.NameForElement", (List<object> parameters, InvocationContext ctx) => Te.xt(ItemData.ReplacementTidForElement(ItemData.ParseElement(parameters[0] as string))));
		stonescript.RegisterGlobal("decoration", new SSDecorationStatic());
		stonescript.RegisterGlobal("neutral", new SSNeutralStatic());
		stonescript.RegisterGlobal("sprite", new SSSpriteStatic());
		stonescript.RegisterGlobal("loadout", new SSLoadoutStatic());
		stonescript.RegisterGlobal("Item", new SSItemStatic());
		stonescript.RegisterGlobal("Pickups", new SSPickupStatic());
		stonescript.RegisterGlobal("Particle", new SSParticleStatic());
		SSScriptableObject component = GameStates.Singleton.customQuestsUi.GetComponent<SSScriptableObject>();
		stonescript.RegisterGlobal("questUi", component.Target);
	}

	public void ClearProgress()
	{
		ftueStep = FTUEStep.UnlockBasicQuests;
		epicQuestsRevealed.Clear();
		activeQuests.Clear();
		questCounter = 0;
		completedQuestsCount = 0;
		questRecords.Clear();
		nextSpawnDate = DateTime.Now;
		epicSpawnPending = false;
		dirtyNextEpicToUnlockId = true;
		lastBasicQuestDate = DateTime.Now;
		lastBasicQuestDate = new DateTime(lastBasicQuestDate.Year, lastBasicQuestDate.Month, lastBasicQuestDate.Day, 0, 0, 0);
		ReferralController.singleton.ClearProgress();
	}

	private void TryInitialize()
	{
		if (initialized)
		{
			return;
		}
		customQuestsScreen = GameStates.Singleton.customQuestsScreen;
		string text = (Resources.Load("CustomQuests/custom_quests") as TextAsset).text;
		questDefinitions = new List<Data.CustomQuest>(SlimJson.ParseArray(text, "custom_quests", Data.CustomQuest.FromString));
		foreach (Data.CustomQuest questDefinition in questDefinitions)
		{
			questDefinitionsById.Add(questDefinition.id, questDefinition);
			if (!questDefinition.IsBasic && questDefinition.isEnabled && questDefinition.IsReleased())
			{
				epicQuestsEnabled.Add(questDefinition);
			}
		}
		startingQuests = new List<string>(SlimJson.ParseArray(text, "starting_quests"));
		Character.OnCharacterTookDamage += HandleCharacterDamaged;
		Character.OnCharacterDied += HandleCharacterDied;
		InventoryResources.singleton.OnResourceAdded += HandleResourceHarvested;
		UndeadCryptIntro.OnSkullGameWon += HandleSkullGameWon;
		Potion.OnPotionActivated = (Action<Potion>)Delegate.Combine(Potion.OnPotionActivated, new Action<Potion>(HandlePotionConsumed));
		QuestController.singleton.OnQuestCompleted += HandleQuestCompleted;
		Inventory.Singleton.OnItemGained += HandleItemGained;
		TreasureItem.OnTreasureOpened += HandleTreasureOpened;
		GameStates.OnQuestStarting += HandleLocStart;
		Level.OnNextSection += HandleNextSection;
		GameStates singleton = GameStates.Singleton;
		singleton.OnEndQuest = (Action)Delegate.Combine(singleton.OnEndQuest, new Action(HandleQuestEnd));
		FissureStoneScreen singleton2 = FissureStoneScreen.singleton;
		singleton2.OnPreFissure = (Action<Item, int>)Delegate.Combine(singleton2.OnPreFissure, new Action<Item, int>(HandlePreFissure));
		FissureStoneScreen singleton3 = FissureStoneScreen.singleton;
		singleton3.OnFissure = (Action<ItemFactory.Result, int>)Delegate.Combine(singleton3.OnFissure, new Action<ItemFactory.Result, int>(HandleFissure));
		FissureStoneScreen singleton4 = FissureStoneScreen.singleton;
		singleton4.OnPreUnmake = (Action<Item, int>)Delegate.Combine(singleton4.OnPreUnmake, new Action<Item, int>(HandlePreUnmakeItem));
		FissureStoneScreen singleton5 = FissureStoneScreen.singleton;
		singleton5.OnUnmake = (Action<Item, int, int>)Delegate.Combine(singleton5.OnUnmake, new Action<Item, int, int>(HandleUnmakeItem));
		TriskelionScreen singleton6 = TriskelionScreen.singleton;
		singleton6.OnPreFuse = (Action<Item, Item, Item, Item>)Delegate.Combine(singleton6.OnPreFuse, new Action<Item, Item, Item, Item>(HandlePreTriskelionFuse));
		MoondialScreen singleton7 = MoondialScreen.singleton;
		singleton7.OnPreMutate = (Action<Item>)Delegate.Combine(singleton7.OnPreMutate, new Action<Item>(HandlePreMoondialMutate));
		InitStonescript();
		initialized = true;
	}

	public void ConnectToAnvilScreen()
	{
		AnvilScreen singleton = AnvilScreen.singleton;
		singleton.OnPreFuse = (Action<Item, Item, int>)Delegate.Combine(singleton.OnPreFuse, new Action<Item, Item, int>(HandlePreAnvilFuse));
		AnvilScreen.singleton.OnFuse += HandleAnvilFuse;
	}

	public void ConnectToCauldronScreen()
	{
		CauldronScreen singleton = CauldronScreen.singleton;
		singleton.OnPreBrew = (Action<Potion.Type>)Delegate.Combine(singleton.OnPreBrew, new Action<Potion.Type>(HandlePreCauldronBrew));
	}

	private void Start()
	{
		TryInitialize();
	}

	public void UpdateTic()
	{
		if (base.enabled && HasQueststoneUnlocked)
		{
			TrySpawnQuests();
			gameModel.HandleSimulationTic();
			if (curLevel != null)
			{
				curLevel.UpdateTic();
			}
			HandleTic();
			gameModel.ExecuteResults(stonescript.Results);
		}
	}

	private void Update()
	{
		if (!HasQueststoneUnlocked)
		{
			return;
		}
		if (QuickCheats.SkipAheadKeyPressed())
		{
			foreach (Data.CustomQuestInstance activeQuest in activeQuests)
			{
				activeQuest.ssQuest?.executable.Execute("OnSkipAhead", null, null, gracefulFail: true);
			}
		}
		foreach (Data.CustomQuestInstance activeQuest2 in activeQuests)
		{
			activeQuest2.ssQuest?.Update();
		}
	}

	private void Awake()
	{
		instance = this;
	}

	private void CreateReward(Data.CustomQuestInstance quest)
	{
		if (quest.reward == null)
		{
			if (quest.def.rewardTreasure != null && quest.def.rewardTreasure.treasureId != null)
			{
				Data.TreasureDrop rewardTreasure = quest.def.rewardTreasure;
				List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
				quest.reward = TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", rewardTreasure.treasureId, possibleElements);
			}
			else if (quest.def.rewardResource != null)
			{
				quest.reward = UnityEngine.Object.Instantiate(Resources.Load<TreasureItem>(quest.def.rewardResource));
			}
		}
	}

	public TreasureItem ClaimReward(Data.CustomQuestInstance quest)
	{
		if (quest.rewardClaimed)
		{
			return null;
		}
		TreasureItem result = GrantReward(quest);
		quest.rewardClaimed = true;
		if (activeQuests.Contains(quest))
		{
			activeQuests.Remove(quest);
			customQuestsScreen.MarkDirty();
			if (ftueStep == FTUEStep.CompleteFirstBasicQuest)
			{
				ftueStep = FTUEStep.CompleteFirstEpicQuest;
				Data.CustomQuest questDefinitionById = GetQuestDefinitionById("epic_croaked");
				GenerateEpic(questDefinitionById);
			}
			else if (!quest.IsBasic)
			{
				if (ftueStep == FTUEStep.CompleteFirstEpicQuest)
				{
					ftueStep = FTUEStep.CompleteSecondEpicQuest;
					nextSpawnDate = DateTime.Now + new TimeSpan(0, 10, 0);
				}
				else if (ftueStep == FTUEStep.CompleteSecondEpicQuest)
				{
					ftueStep = FTUEStep.FtueDone;
					nextSpawnDate = DateTime.Now + new TimeSpan(1, 0, 0);
				}
				else if (nextSpawnDate <= DateTime.Now)
				{
					nextSpawnDate = DateTime.Now + new TimeSpan(0, 0, questSpawnRate);
				}
				NotificationMacros.LegendQuestUnlock(nextSpawnDate);
				epicSpawnPending = true;
				dirtyNextEpicToUnlockId = true;
			}
			return result;
		}
		return null;
	}

	public void ClearEpicCooldown()
	{
		nextSpawnDate = DateTime.Now;
		foreach (KeyValuePair<string, PlayerQuestRecord> questRecord in questRecords)
		{
			questRecord.Value.cooldownTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
		}
	}

	private TreasureItem GrantReward(Data.CustomQuestInstance quest)
	{
		if (quest.reward != null)
		{
			Inventory.Singleton.AddItem(quest.reward);
			return quest.reward;
		}
		return null;
	}

	private PlayerQuestRecord GetOrCreatePlayerQuestRecord(string questId)
	{
		if (questRecords.ContainsKey(questId))
		{
			return questRecords[questId];
		}
		PlayerQuestRecord playerQuestRecord = new PlayerQuestRecord();
		playerQuestRecord.questId = questId;
		questRecords[questId] = playerQuestRecord;
		return playerQuestRecord;
	}

	public string Serialize()
	{
		if (!base.enabled)
		{
			return null;
		}
		foreach (Data.CustomQuestInstance activeQuest in activeQuests)
		{
			if (activeQuest.ssQuest != null)
			{
				activeQuest.data = activeQuest.ssQuest.GetVariables();
			}
		}
		List<PlayerQuestRecord> list = new List<PlayerQuestRecord>(questRecords.Values);
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("ftueStep", ftueStep.ToString());
		SlimJson.AddProperty("revealed", epicQuestsRevealed.ToArray());
		SlimJson.AddProperty("active", activeQuests.ToArray());
		SlimJson.AddProperty("counter", questCounter);
		if (list.Count > 0)
		{
			SlimJson.AddProperty("records", list.ToArray());
		}
		SlimJson.AddProperty("completedCount", completedQuestsCount);
		SlimJson.AddProperty("nextSpawnDate", nextSpawnDate);
		SlimJson.AddProperty("epicSpawnPending", epicSpawnPending);
		SlimJson.AddProperty("basicQuestDate", lastBasicQuestDate);
		ReferralController.singleton.Serialize();
		return SlimJson.EndSerialization();
	}

	private static DateTime DateTimeFromString(string s)
	{
		return DateTime.Parse(s);
	}

	public void Parse(string sjson)
	{
		if (!base.enabled)
		{
			return;
		}
		ClearProgress();
		gameModel.Storage = MindStoneController.singleton.GetOrCreateStonescriptStorage();
		gameModel.Storage.Load();
		stonescript.Storage = SaveFiles.singleton.storage;
		if (string.IsNullOrWhiteSpace(sjson))
		{
			return;
		}
		try
		{
			ftueStep = SlimJson.ParseEnum<FTUEStep>(sjson, "ftueStep");
			string[] array = SlimJson.ParseArray(sjson, "revealed");
			if (array != null)
			{
				epicQuestsRevealed.AddRange(array);
			}
			Data.CustomQuestInstance[] array2 = SlimJson.ParseArray(sjson, "active", Data.CustomQuestInstance.FromString);
			if (array2 != null)
			{
				activeQuests.AddRange(array2);
			}
			questCounter = SlimJson.ParseInt(sjson, "counter");
			completedQuestsCount = SlimJson.ParseInt(sjson, "completedCount");
			questRecords.Clear();
			PlayerQuestRecord[] array3 = SlimJson.ParseArray(sjson, "records", PlayerQuestRecord.FromSjson);
			if (array3 != null)
			{
				PlayerQuestRecord[] array4 = array3;
				foreach (PlayerQuestRecord playerQuestRecord in array4)
				{
					questRecords[playerQuestRecord.questId] = playerQuestRecord;
				}
			}
			nextSpawnDate = SlimJson.ParseDateTime(sjson, "nextSpawnDate");
			epicSpawnPending = SlimJson.ParseBool(sjson, "epicSpawnPending");
			lastBasicQuestDate = SlimJson.ParseDateTime(sjson, "basicQuestDate");
			for (int num = activeQuests.Count - 1; num >= 0; num--)
			{
				Data.CustomQuestInstance quest = activeQuests[num];
				Data.CustomQuest customQuest = questDefinitions.Find((Data.CustomQuest qd) => qd.id == quest.customQuestId);
				if (customQuest == null)
				{
					UnityEngine.Debug.LogWarning("Unable to find custom quest \"" + quest.customQuestId + "\"");
					activeQuests.RemoveAt(num);
				}
				else
				{
					quest.def = customQuest;
					LoadProgram(customQuest, quest, delegate(SSCustomQuest ssQuest, List<Exception> exceptions)
					{
						OnQuestReady(quest, ssQuest, exceptions, startQuest: false);
					});
					CreateReward(quest);
				}
			}
			ReferralController.singleton.Parse(sjson);
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
			UnityEngine.Debug.LogError("Failed to load custom quests!");
		}
	}
}
