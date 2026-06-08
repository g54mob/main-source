using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveFiles
{
	public class SaveFileMeta
	{
		public string saveId;

		public string uniqueId;

		public string createdId;

		public DateTime timestamp;

		public string displayName;

		public string version;

		public bool isDebug;

		public string playerName;

		public int playerXP;

		public int playerLevel;

		public int totalStars;

		public int gearPoints = 20000;

		public string leftItemId;

		public string leftItemData;

		public string rightItemId;

		public string rightItemData;

		public bool bigHead;

		public bool hasQuestStone;

		public string progressData;

		public bool encrypted;

		public bool IsNew()
		{
			return displayName == null;
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("save_id", saveId);
			SlimJson.AddProperty("uId", uniqueId);
			if (createdId != null)
			{
				SlimJson.AddProperty("cId", createdId);
			}
			SlimJson.AddProperty("timestamp", timestamp);
			SlimJson.AddProperty("display_name", displayName);
			SlimJson.AddProperty("version", version);
			SlimJson.AddProperty("is_debug", isDebug);
			SlimJson.AddProperty("player_name", playerName);
			SlimJson.AddProperty("player_xp", playerXP);
			SlimJson.AddProperty("player_level", playerLevel);
			SlimJson.AddProperty("total_stars", totalStars);
			SlimJson.AddProperty("gearPoints", gearPoints);
			SlimJson.AddProperty("left_item_id", leftItemId);
			SlimJson.AddProperty("left_item_data", leftItemData);
			SlimJson.AddProperty("right_item_id", rightItemId);
			SlimJson.AddProperty("right_item_data", rightItemData);
			SlimJson.AddProperty("big_head", bigHead);
			SlimJson.AddProperty("hqs", hasQuestStone);
			SlimJson.AddProperty("progress_data", progressData);
			SlimJson.AddProperty("encrypted", encrypted);
			return SlimJson.EndSerialization();
		}

		public void FromString(string sjson)
		{
			saveId = SlimJson.Parse(sjson, "save_id");
			uniqueId = SlimJson.Parse(sjson, "uId");
			createdId = SlimJson.Parse(sjson, "cId");
			timestamp = SlimJson.ParseDateTime(sjson, "timestamp");
			displayName = SlimJson.Parse(sjson, "display_name");
			version = SlimJson.Parse(sjson, "version");
			isDebug = SlimJson.ParseBool(sjson, "is_debug");
			playerName = SlimJson.Parse(sjson, "player_name", "simple one");
			playerXP = SlimJson.ParseInt(sjson, "player_xp");
			playerLevel = SlimJson.ParseInt(sjson, "player_level");
			totalStars = SlimJson.ParseInt(sjson, "total_stars");
			gearPoints = SlimJson.ParseInt(sjson, "gearPoints");
			leftItemId = SlimJson.Parse(sjson, "left_item_id");
			leftItemData = SlimJson.Parse(sjson, "left_item_data");
			rightItemId = SlimJson.Parse(sjson, "right_item_id");
			rightItemData = SlimJson.Parse(sjson, "right_item_data");
			bigHead = SlimJson.ParseBool(sjson, "big_head");
			hasQuestStone = SlimJson.ParseBool(sjson, "hqs");
			progressData = SlimJson.Parse(sjson, "progress_data");
			encrypted = SlimJson.ParseBool(sjson, "encrypted");
		}
	}

	private Dictionary<string, SaveFileMeta> saveFilesDict = new Dictionary<string, SaveFileMeta>();

	private List<SaveFileMeta> saveFiles = new List<SaveFileMeta>();

	private static SaveFiles _singleton;

	public bool isLoading;

	public AStorage storage { get; set; }

	public static SaveFiles singleton
	{
		get
		{
			if (_singleton == null)
			{
				_singleton = new SaveFiles();
			}
			return _singleton;
		}
	}

	public static string deviceId { get; private set; }

	private SaveFiles()
	{
		_singleton = this;
	}

	public void Init()
	{
		int lastSaveId = GetLastSaveId();
		string text = null;
		for (int i = 0; i <= lastSaveId; i++)
		{
			SaveFileMeta saveFileMeta = ReadFile(i.ToString());
			if (saveFileMeta != null)
			{
				AddSaveFile(saveFileMeta);
				if (text == null)
				{
					text = saveFileMeta.createdId;
				}
			}
		}
		InitDeviceId(text);
	}

	public void SyncDeviceIdToSaveFiles()
	{
		for (int i = 0; i < saveFiles.Count; i++)
		{
			SaveFileMeta saveFileMeta = saveFiles[i];
			if (saveFileMeta != null)
			{
				saveFileMeta.createdId = deviceId;
			}
		}
	}

	public bool IsSynchedDeviceId()
	{
		if (GameSave.activeSaveFile != null)
		{
			return GameSave.activeSaveFile.createdId == deviceId;
		}
		return false;
	}

	private static void InitDeviceId(string idFromStorage)
	{
		if (deviceId == null)
		{
			if (PlayerPrefs.HasKey("_deviceId"))
			{
				deviceId = PlayerPrefs.GetString("_deviceId");
				return;
			}
			if (idFromStorage != null)
			{
				deviceId = idFromStorage;
				return;
			}
			deviceId = CodeRedemptionScreen.GenerateNewUserCode();
			PlayerPrefs.SetString("_deviceId", deviceId);
			PlayerPrefs.Save();
		}
	}

	public SaveFileMeta ReadFile(string saveId)
	{
		string key = "save_file_" + saveId;
		if (!storage.HasKey(key))
		{
			return null;
		}
		string sjson = storage.GetString(key);
		SaveFileMeta saveFileMeta = new SaveFileMeta();
		saveFileMeta.FromString(sjson);
		return saveFileMeta;
	}

	public void WriteFile(SaveFileMeta saveFile)
	{
		string key = "save_file_" + saveFile.saveId;
		if (saveFile.createdId == null)
		{
			saveFile.createdId = deviceId;
		}
		string value = saveFile.ToString();
		storage.SetString(key, value);
	}

	public SaveFileMeta SaveCurrentState(string name, string uniqueId = null, bool isDebugFile = false)
	{
		SlimJson.BeginSerialization();
		SlimJson.identationEnabled = false;
		string text = Features.VERSION.ToString();
		SlimJson.AddProperty("version", text);
		SlimJson.AddProperty("rng", Utils.random.Next());
		SlimJson.AddProperty("hero_settings", HeroSettings.Serialize());
		SlimJson.AddProperty("progress_flags", ProgressFlags.Serialize());
		SlimJson.AddProperty("quest_data", QuestController.singleton.Serialize());
		SlimJson.AddProperty("inventory_data", Inventory.Singleton.Serialize());
		SlimJson.AddProperty("cosmetics", CosmeticController.singleton.Serialize());
		SlimJson.AddProperty("treasure_factory", TreasureFactory.singleton.Serialize());
		SlimJson.AddProperty("ui_state", UISaveState.Serialize());
		SlimJson.AddProperty("shop_states", ShopController.singleton.SerializeShopStates());
		SlimJson.AddProperty("crypt_intro", UndeadCryptIntro.Serialize());
		SlimJson.AddProperty("xp", XPController.singleton.Serialize());
		SlimJson.AddProperty("ouroboros", OuroborosWeapon.Serialize());
		SlimJson.AddProperty("utility_belt", UtilityBeltKeyShortcuts.singleton.Serialize());
		SlimJson.AddProperty("craft_book", CraftBookScreen.singleton.Serialize());
		SlimJson.AddProperty("achievements", AchievementController.singleton.Serialize());
		SlimJson.AddProperty("mutator", MoondialScreen.singleton.Serialize());
		SlimJson.AddProperty("events", EventController.singleton.Serialize());
		SlimJson.AddProperty("custom_quests", CustomQuestsController.Singleton.Serialize());
		SlimJson.AddProperty("weekly_quest", WeeklyQuestsController.singleton.Serialize());
		SlimJson.AddProperty("goals", GoalController.singleton.Serialize());
		SlimJson.AddProperty("subs", SubscriptionController.singleton.Serialize());
		SlimJson.AddProperty("prom", PromotionsController.singleton.Serialize());
		SlimJson.AddProperty("leaderboards", LeaderboardController.singleton.Serialize());
		SlimJson.AddProperty("mind_stone", MindStoneController.singleton.Serialize());
		SlimJson.identationEnabled = true;
		string plainText = SlimJson.EndSerialization();
		SaveFileMeta saveFileMeta = new SaveFileMeta();
		saveFileMeta.saveId = GetNewSaveId().ToString();
		saveFileMeta.timestamp = DateTime.Now;
		saveFileMeta.version = text;
		saveFileMeta.isDebug = isDebugFile;
		saveFileMeta.playerName = (HeroSettings.isNameSet ? HeroSettings.name : "New Story");
		saveFileMeta.playerXP = XPController.singleton.currentXP;
		saveFileMeta.playerLevel = XPController.singleton.currentLevel;
		saveFileMeta.totalStars = QuestController.singleton.GetTotalStars();
		saveFileMeta.gearPoints = Inventory.Singleton.GetTotalGearPoints();
		Hero hero = GameStates.Singleton.hero;
		if (hero.LeftHand != null)
		{
			saveFileMeta.leftItemId = hero.LeftHand.id;
			saveFileMeta.leftItemData = hero.LeftHand.SerializeData(includeNameTag: false);
		}
		if (hero.RightHand != null)
		{
			saveFileMeta.rightItemId = hero.RightHand.id;
			saveFileMeta.rightItemData = hero.RightHand.SerializeData(includeNameTag: false);
		}
		saveFileMeta.bigHead = HeroSettings.bigHeadEnabled;
		saveFileMeta.hasQuestStone = Inventory.Singleton.HasItemById("quest_stone");
		saveFileMeta.progressData = StringCipher.Encrypt(plainText, "peekabeyoufoundme");
		saveFileMeta.encrypted = true;
		if (string.IsNullOrEmpty(name))
		{
			saveFileMeta.displayName = "Untitled " + saveFileMeta.saveId;
		}
		else
		{
			saveFileMeta.displayName = name;
		}
		if (string.IsNullOrEmpty(uniqueId))
		{
			uniqueId = CodeRedemptionScreen.GenerateNewUserCode();
		}
		saveFileMeta.uniqueId = uniqueId;
		AddSaveFile(saveFileMeta);
		WriteFile(saveFileMeta);
		return saveFileMeta;
	}

	private void AddSaveFile(SaveFileMeta saveFile)
	{
		if (saveFilesDict.ContainsKey(saveFile.saveId))
		{
			Utils.LogError("Cannot add save file with id " + saveFile.saveId + " because another save file with that id is already in memory. dump: " + saveFile.ToString());
			return;
		}
		saveFilesDict.Add(saveFile.saveId, saveFile);
		saveFiles.Add(saveFile);
	}

	public bool LoadSaveFile(string saveId)
	{
		if (saveFilesDict.ContainsKey(saveId))
		{
			SaveFileMeta saveFile = saveFilesDict[saveId];
			LoadSaveFile(saveFile);
			return true;
		}
		Utils.LogError("There is no save file with id " + saveId);
		return false;
	}

	public void LoadSaveFile(SaveFileMeta saveFile)
	{
		isLoading = true;
		if (saveFile.encrypted)
		{
			LoadSaveFileSJson(StringCipher.Decrypt(saveFile.progressData, "peekabeyoufoundme"));
		}
		else
		{
			LoadSaveFileSJson(saveFile.progressData);
		}
		isLoading = false;
	}

	public void LoadSaveFileSJson(string sjson)
	{
		Features.PREV_VERSION = Version.FromString(SlimJson.Parse(sjson, "version"));
		if (Features.PREV_VERSION > Features.VERSION)
		{
			Version pREV_VERSION = Features.PREV_VERSION;
			string text = pREV_VERSION.ToString();
			pREV_VERSION = Features.VERSION;
			Utils.LogError("Loading save file with version " + text + ", which is greater than current version " + pREV_VERSION.ToString());
		}
		else if (Features.VERSION > Features.PREV_VERSION)
		{
			Version pREV_VERSION = Features.PREV_VERSION;
			string text2 = pREV_VERSION.ToString();
			pREV_VERSION = Features.VERSION;
			Utils.Log("Upgrading save file from version " + text2 + " to version " + pREV_VERSION.ToString());
		}
		Utils.random = new System.Random(SlimJson.ParseInt(sjson, "rng"));
		ProgressFlags.Parse(SlimJson.Parse(sjson, "progress_flags"));
		HeroSettings.Parse(SlimJson.Parse(sjson, "hero_settings"));
		QuestController.singleton.Parse(SlimJson.Parse(sjson, "quest_data"));
		Inventory.Singleton.Parse(SlimJson.Parse(sjson, "inventory_data"));
		CosmeticController.singleton.Parse(SlimJson.Parse(sjson, "cosmetics"));
		TreasureFactory.singleton.Parse(SlimJson.Parse(sjson, "treasure_factory"));
		UISaveState.Parse(SlimJson.Parse(sjson, "ui_state"));
		ShopController.singleton.ParseShopStates(SlimJson.Parse(sjson, "shop_states"));
		UndeadCryptIntro.Parse(SlimJson.Parse(sjson, "crypt_intro"));
		XPController.singleton.Parse(SlimJson.Parse(sjson, "xp"));
		StarStoneWeapon.Parse(SlimJson.Parse(sjson, "star_stone"));
		OuroborosWeapon.Parse(SlimJson.Parse(sjson, "ouroboros"));
		UtilityBeltKeyShortcuts.singleton.Parse(SlimJson.Parse(sjson, "utility_belt"));
		CraftBookScreen.singleton.Parse(SlimJson.Parse(sjson, "craft_book"));
		AchievementController.singleton.Parse(SlimJson.Parse(sjson, "achievements"));
		MoondialScreen.singleton.Parse(SlimJson.Parse(sjson, "mutator"));
		EventController.singleton.Parse(SlimJson.Parse(sjson, "events"));
		MindStoneController.singleton.Parse(SlimJson.Parse(sjson, "mind_stone"));
		CustomQuestsController.Singleton.Parse(SlimJson.Parse(sjson, "custom_quests"));
		WeeklyQuestsController.singleton.Parse(SlimJson.Parse(sjson, "weekly_quest"));
		GoalController.singleton.Parse(SlimJson.Parse(sjson, "goals"));
		SubscriptionController.singleton.Parse(SlimJson.Parse(sjson, "subs"));
		PromotionsController.singleton.Parse(SlimJson.Parse(sjson, "prom"));
		LeaderboardController.singleton.Parse(SlimJson.Parse(sjson, "leaderboards"));
		QuestExceptions.AfterProgressLoaded();
		GeneralPatches.AfterProgressLoaded();
		ItemAbilityPatch.AfterProgressLoaded();
		GameStates.Singleton.hero.UpdateHitpoints();
	}

	public void ClearActiveMemory()
	{
		ProgressFlags.ClearProgress();
		HeroSettings.ClearProgress();
		QuestController.singleton.ClearProgress();
		Inventory.Singleton.ClearProgress();
		CosmeticController.singleton.ClearProgress();
		TreasureFactory.singleton.ClearProgress();
		UISaveState.ClearProgress();
		ShopController.singleton.ClearProgress();
		UndeadCryptIntro.ClearProgress();
		XPController.singleton.ClearProgress();
		StarStoneWeapon.ClearProgress();
		OuroborosWeapon.ClearProgress();
		UtilityBeltKeyShortcuts.singleton.ClearProgress();
		CraftBookScreen.singleton.ClearProgress();
		AchievementController.singleton.ClearProgress();
		MoondialScreen.singleton.ClearProgress();
		EventController.singleton.ClearProgress();
		CustomQuestsController.Singleton.ClearProgress();
		WeeklyQuestsController.singleton.ClearProgress();
		GoalController.singleton.ClearProgress();
		SubscriptionController.singleton.ClearProgress();
		PromotionsController.singleton.ClearProgress();
		LeaderboardController.singleton.ClearProgress();
		MindStoneController.singleton.ClearProgress();
	}

	public bool HasSaveFileWithId(string saveId)
	{
		return saveFilesDict.ContainsKey(saveId);
	}

	public SaveFileMeta GetSaveFileWithId(string saveId)
	{
		if (saveFilesDict.ContainsKey(saveId))
		{
			return saveFilesDict[saveId];
		}
		Utils.LogWarning("GetSaveFileWithId() could not find a Save File with id " + saveId);
		return null;
	}

	public void Delete(string saveId)
	{
		if (!saveFilesDict.ContainsKey(saveId))
		{
			return;
		}
		SaveFileMeta item = saveFilesDict[saveId];
		saveFilesDict.Remove(saveId);
		saveFiles.Remove(item);
		storage.DeleteKey("save_file_" + saveId);
		int num = Utils.ParseInt(saveId);
		if (num == GetLastSaveId())
		{
			string key;
			do
			{
				num--;
				key = "save_file_" + num;
			}
			while (!storage.HasKey(key) && num >= 0);
			storage.SetInt("save_file_last_id", num);
		}
	}

	public void DeleteAllSaves()
	{
		saveFilesDict.Clear();
		saveFiles.Clear();
	}

	public bool LoadSaveFileWithName(string fileName)
	{
		SaveFileMeta saveFileWithName = GetSaveFileWithName(fileName);
		if (saveFileWithName != null)
		{
			LoadSaveFile(saveFileWithName);
			return true;
		}
		Utils.LogWarning("LoadSaveFileWithName() could not load a Save File with name " + fileName);
		return false;
	}

	public bool HasSaveFileWithName(string fileName)
	{
		for (int i = 0; i < saveFiles.Count; i++)
		{
			if (saveFiles[i].displayName == fileName)
			{
				return true;
			}
		}
		return false;
	}

	public SaveFileMeta GetSaveFileWithName(string fileName)
	{
		for (int i = 0; i < saveFiles.Count; i++)
		{
			if (saveFiles[i].displayName == fileName)
			{
				return saveFiles[i];
			}
		}
		Utils.LogWarning("GetSaveFileWithName() could not find a Save File with name " + fileName);
		return null;
	}

	public void DeleteSaveFileWithName(string fileName)
	{
		SaveFileMeta saveFileWithName = GetSaveFileWithName(fileName);
		if (saveFileWithName != null)
		{
			Delete(saveFileWithName.saveId);
		}
		else
		{
			Utils.LogWarning("DeleteSaveFileWithName() could not delete a Save File with name " + fileName);
		}
	}

	public void MoveUp(SaveFileMeta saveFile)
	{
		int num = saveFiles.IndexOf(saveFile);
		if (num > 0)
		{
			SaveFileMeta saveFileMeta = saveFiles[num - 1];
			saveFiles.Remove(saveFile);
			saveFiles.Insert(num - 1, saveFile);
			string saveId = saveFile.saveId;
			string saveId2 = saveFileMeta.saveId;
			saveFilesDict[saveId] = saveFileMeta;
			saveFilesDict[saveId2] = saveFile;
			saveFile.saveId = saveId2;
			saveFileMeta.saveId = saveId;
			WriteFile(saveFile);
			WriteFile(saveFileMeta);
		}
	}

	public void MoveDown(SaveFileMeta saveFile)
	{
		int num = saveFiles.IndexOf(saveFile);
		if (num >= 0 && num < saveFiles.Count - 1)
		{
			SaveFileMeta saveFileMeta = saveFiles[num + 1];
			saveFiles.Remove(saveFile);
			saveFiles.Insert(num + 1, saveFile);
			string saveId = saveFile.saveId;
			string saveId2 = saveFileMeta.saveId;
			saveFilesDict[saveId] = saveFileMeta;
			saveFilesDict[saveId2] = saveFile;
			saveFile.saveId = saveId2;
			saveFileMeta.saveId = saveId;
			WriteFile(saveFile);
			WriteFile(saveFileMeta);
		}
	}

	public List<SaveFileMeta> GetDirectory()
	{
		return saveFiles;
	}

	public List<SaveFileMeta> GetSorted()
	{
		List<SaveFileMeta> list = new List<SaveFileMeta>();
		for (int i = 0; i < saveFiles.Count; i++)
		{
			SaveFileMeta saveFileMeta = saveFiles[i];
			if (!saveFileMeta.isDebug)
			{
				list.Add(saveFileMeta);
			}
		}
		list.Sort((SaveFileMeta fileA, SaveFileMeta fileB) => (!(fileA.timestamp >= fileB.timestamp)) ? 1 : (-1));
		return list;
	}

	private int GetNewSaveId()
	{
		int num = storage.GetInt("save_file_last_id", -1);
		num++;
		storage.SetInt("save_file_last_id", num);
		return num;
	}

	public int GetLastSaveId()
	{
		return storage.GetInt("save_file_last_id", -1);
	}
}
