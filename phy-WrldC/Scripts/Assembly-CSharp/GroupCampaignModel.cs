using System.Collections.Generic;
using System.Linq;

public class GroupCampaignModel : BaseModel
{
	public class LevelGroupModel
	{
		private static readonly string[] levelGroupNames = new string[4] { "easy", "medium", "hard", "extreme" };

		private List<LevelModel> levelModels;

		public string GroupName { get; private set; }

		public int GroupIndex { get; private set; }

		public bool IsGroupUnlocked => LevelsCompletedGroupsBeforeCount >= LevelsCompletedToUnlock;

		public int LevelsCompletedToUnlock { get; private set; }

		public int LevelsCompletedGroupsBeforeCount { get; set; }

		public int LevelModelsCount => levelModels.Count;

		public LevelGroupModel(int groupIndex, int levelsCompletedToUnlock)
		{
			levelModels = new List<LevelModel>();
			GroupIndex = groupIndex;
			LevelsCompletedToUnlock = levelsCompletedToUnlock;
		}

		public void UpdateGroupName()
		{
			string text;
			string text2;
			if (GroupIndex <= 4)
			{
				text = levelGroupNames[0];
				text2 = (GroupIndex + 1).ToRoman();
			}
			else if (GroupIndex > 4 && GroupIndex <= 9)
			{
				text = levelGroupNames[1];
				text2 = (GroupIndex - 4).ToRoman();
			}
			else if (GroupIndex > 9 && GroupIndex <= 14)
			{
				text = levelGroupNames[2];
				text2 = (GroupIndex - 9).ToRoman();
			}
			else
			{
				text = levelGroupNames[3];
				text2 = (GroupIndex - 14).ToRoman();
			}
			GroupName = LanguagesManager.Instance.GetText("label.text.level.groupname." + text, "Level Group") + " " + text2;
		}

		public int AddLevelModel(LevelModel levelModel)
		{
			levelModels.Add(levelModel);
			return levelModels.Count - 1;
		}

		public int GetLevelModelIndex(LevelModel levelModel)
		{
			if (!levelModels.Contains(levelModel))
			{
				return -1;
			}
			return levelModels.IndexOf(levelModel);
		}

		public LevelModel[] GetAllLevelModels()
		{
			return levelModels.ToArray();
		}

		public int LevelsCompletedCount()
		{
			return levelModels.Count((LevelModel levelModel) => levelModel.IsLevelCompleted);
		}

		public (int total, int both, int gold, int silver) CollectablesPickedUpCount()
		{
			int item = levelModels.Count((LevelModel levelModel) => levelModel.IsThereCollectables);
			int item2 = levelModels.Count((LevelModel levelModel) => levelModel.LevelStatus != null && levelModel.LevelStatus.AllBothCollectables);
			int item3 = levelModels.Count((LevelModel levelModel) => levelModel.LevelStatus != null && levelModel.LevelStatus.AllGoldCollectables);
			int item4 = levelModels.Count((LevelModel levelModel) => levelModel.LevelStatus != null && levelModel.LevelStatus.AllSilverCollectables);
			return (total: item, both: item2, gold: item3, silver: item4);
		}

		public bool IsGroupCompleted()
		{
			return !levelModels.Any((LevelModel levelModel) => !levelModel.IsLevelCompleted);
		}

		public bool IsAllBothPickedUp()
		{
			return !levelModels.Any((LevelModel levelModel) => levelModel.LevelStatus == null || !levelModel.LevelStatus.AllBothCollectables);
		}

		public bool IsAllGoldPickedUp()
		{
			return !levelModels.Any((LevelModel levelModel) => levelModel.LevelStatus == null || !levelModel.LevelStatus.AllGoldCollectables);
		}

		public bool IsAllSilverPickedUp()
		{
			return !levelModels.Any((LevelModel levelModel) => levelModel.LevelStatus == null || !levelModel.LevelStatus.AllSilverCollectables);
		}
	}

	public const string AddLevelModelEvent = "GroupCampaignModel.AddLevelModelEvent";

	public const string NewLevelRecordsEvent = "GroupCampaignModel.NewLevelRecordsEvent";

	public const string SelectLevelModelEvent = "GroupCampaignModel.SelectLevelModelEvent";

	public const string UpdateLevelGroupStatusEvent = "GroupCampaignModel.UpdateLevelGroupStatusEvent";

	public const string UpdateLevelGroupNameEvent = "GroupCampaignModel.UpdateLevelGroupNameEvent";

	private List<LevelGroupModel> levelGroupModels;

	private LevelGroupModel currentLevelGroupModel;

	private readonly int levelsPerGroup = 5;

	private readonly int[] numbersToUnlockGroups = new int[21]
	{
		0, 3, 6, 9, 12, 15, 19, 23, 27, 31,
		35, 40, 45, 50, 55, 60, 66, 72, 78, 84,
		90
	};

	public GroupCampaignModel()
	{
		levelGroupModels = new List<LevelGroupModel>();
		LanguagesManager.Instance.OnLanguageChangedEvent += delegate
		{
			UpdateLevelGroupNames();
		};
	}

	public void AddLevelModel(LevelModel levelModel)
	{
		if (currentLevelGroupModel == null || currentLevelGroupModel.LevelModelsCount >= levelsPerGroup)
		{
			currentLevelGroupModel = new LevelGroupModel(levelGroupModels.Count, numbersToUnlockGroups[levelGroupModels.Count])
			{
				LevelsCompletedGroupsBeforeCount = 0
			};
			levelGroupModels.Add(currentLevelGroupModel);
		}
		int num = currentLevelGroupModel.AddLevelModel(levelModel);
		levelModel.NotifyChangeEvent += delegate(string eventName, object[] data)
		{
			LevelModelChangeHandler(eventName, data);
		};
		NotifyChange("GroupCampaignModel.AddLevelModelEvent", currentLevelGroupModel.GroupIndex, num, levelModel);
	}

	public LevelGroupModel[] GetAllLevelModelGroups()
	{
		return levelGroupModels.ToArray();
	}

	public void UpdateLevelGroupStatus()
	{
		int num = 0;
		for (int i = 0; i < levelGroupModels.Count; i++)
		{
			levelGroupModels[i].LevelsCompletedGroupsBeforeCount = num;
			num += levelGroupModels[i].LevelsCompletedCount();
			int num2 = levelGroupModels[i].LevelsCompletedToUnlock - levelGroupModels[i].LevelsCompletedGroupsBeforeCount;
			NotifyChange("GroupCampaignModel.UpdateLevelGroupStatusEvent", i, num2, levelGroupModels[i].IsGroupCompleted(), levelGroupModels[i].IsAllBothPickedUp(), levelGroupModels[i].IsAllGoldPickedUp(), levelGroupModels[i].IsAllSilverPickedUp());
		}
	}

	public void UpdateLevelGroupNames()
	{
		for (int i = 0; i < levelGroupModels.Count; i++)
		{
			levelGroupModels[i].UpdateGroupName();
			NotifyChange("GroupCampaignModel.UpdateLevelGroupNameEvent", i, levelGroupModels[i].GroupName);
		}
	}

	public void SelectNextLevel()
	{
		LevelModel levelModel = levelGroupModels[0].GetAllLevelModels()[0];
		LevelModel levelModel2 = levelModel;
		bool flag = true;
		for (int i = 0; i < levelGroupModels.Count; i++)
		{
			if (levelGroupModels[i].IsGroupCompleted())
			{
				continue;
			}
			LevelModel[] allLevelModels = levelGroupModels[i].GetAllLevelModels();
			for (int j = 0; j < allLevelModels.Length; j++)
			{
				if (allLevelModels[j].IsLevelCompleted)
				{
					flag = true;
					continue;
				}
				if (flag)
				{
					levelModel = ((!levelGroupModels[i].IsGroupUnlocked) ? levelModel2 : allLevelModels[j]);
					flag = false;
				}
				if (levelGroupModels[i].IsGroupUnlocked)
				{
					levelModel2 = allLevelModels[j];
				}
			}
		}
		var (num, num2) = GetLevelAndGroupIndexes(levelModel);
		NotifyChange("GroupCampaignModel.SelectLevelModelEvent", num, num2, levelModel);
	}

	public LevelModel GetNextLevelModel(string currentLevelId)
	{
		bool flag = false;
		for (int i = 0; i < levelGroupModels.Count && levelGroupModels[i].IsGroupUnlocked; i++)
		{
			LevelModel[] allLevelModels = levelGroupModels[i].GetAllLevelModels();
			for (int j = 0; j < allLevelModels.Length; j++)
			{
				if (!flag && allLevelModels[j].Id == currentLevelId)
				{
					flag = true;
				}
				else if (flag)
				{
					return allLevelModels[j];
				}
			}
		}
		return null;
	}

	public (int groupIndex, int levelIndex) GetLevelAndGroupIndexes(LevelModel levelModel)
	{
		for (int i = 0; i < levelGroupModels.Count; i++)
		{
			int levelModelIndex = levelGroupModels[i].GetLevelModelIndex(levelModel);
			if (levelModelIndex >= 0)
			{
				return (groupIndex: i, levelIndex: levelModelIndex);
			}
		}
		return (groupIndex: -1, levelIndex: -1);
	}

	public (string groupName, int linearLevelNumber) GetLevelGroupInfos(LevelModel levelModel)
	{
		for (int i = 0; i < levelGroupModels.Count; i++)
		{
			int levelModelIndex = levelGroupModels[i].GetLevelModelIndex(levelModel);
			if (levelModelIndex >= 0)
			{
				return (groupName: levelGroupModels[i].GroupName, linearLevelNumber: i * levelsPerGroup + (levelModelIndex + 1));
			}
		}
		return (groupName: "", linearLevelNumber: -1);
	}

	public string GetGroupNameJustUnlocked()
	{
		for (int i = 1; i < levelGroupModels.Count; i++)
		{
			if (levelGroupModels[i].LevelsCompletedToUnlock - levelGroupModels[i].LevelsCompletedGroupsBeforeCount == 0)
			{
				return levelGroupModels[i].GroupName;
			}
		}
		return null;
	}

	public int GetLevelCompletedCountFromGroup(LevelModel levelModel)
	{
		for (int i = 0; i < levelGroupModels.Count; i++)
		{
			if (levelGroupModels[i].GetLevelModelIndex(levelModel) >= 0)
			{
				return levelGroupModels[i].LevelsCompletedCount();
			}
		}
		return -1;
	}

	public (int levelsCompleted, int levelsTotal) GetLevelsCompletedAndTotal()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < levelGroupModels.Count; i++)
		{
			num += levelGroupModels[i].LevelsCompletedCount();
			num2 += levelGroupModels[i].LevelModelsCount;
		}
		return (levelsCompleted: num, levelsTotal: num2);
	}

	public (int total, int both, int gold, int silver) GetLevelsCollectablesCount()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < levelGroupModels.Count; i++)
		{
			(int total, int both, int gold, int silver) tuple = levelGroupModels[i].CollectablesPickedUpCount();
			int item = tuple.total;
			int item2 = tuple.both;
			int item3 = tuple.gold;
			int item4 = tuple.silver;
			num += item;
			num2 += item2;
			num3 += item3;
			num4 += item4;
		}
		return (total: num, both: num2, gold: num3, silver: num4);
	}

	public (int difficultGroupIndex, bool isAllCompleted, bool isAllSilver, bool isAllGold, bool isAllBoth) GetDifficultGroupInfos(LevelModel levelModel)
	{
		int item = GetLevelAndGroupIndexes(levelModel).groupIndex;
		if (item < 0)
		{
			return (difficultGroupIndex: -1, isAllCompleted: false, isAllSilver: false, isAllGold: false, isAllBoth: false);
		}
		int num = item / 5;
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		bool flag4 = true;
		for (int i = 0; i < 5; i++)
		{
			flag = flag && levelGroupModels[num * 5 + i].IsGroupCompleted();
		}
		for (int j = 0; j < 5; j++)
		{
			flag2 = flag2 && levelGroupModels[num * 5 + j].IsAllSilverPickedUp();
		}
		for (int k = 0; k < 5; k++)
		{
			flag3 = flag3 && levelGroupModels[num * 5 + k].IsAllGoldPickedUp();
		}
		for (int l = 0; l < 5; l++)
		{
			flag4 = flag4 && levelGroupModels[num * 5 + l].IsAllBothPickedUp();
		}
		return (difficultGroupIndex: num, isAllCompleted: flag, isAllSilver: flag2, isAllGold: flag3, isAllBoth: flag4);
	}

	public (bool isAllCompleted, bool isAllSilver, bool isAllGold, bool isAllBoth) GetCampaignCompletenessInfos()
	{
		bool item = true;
		bool item2 = true;
		bool item3 = true;
		bool item4 = true;
		foreach (LevelGroupModel levelGroupModel in levelGroupModels)
		{
			if (!levelGroupModel.IsGroupCompleted())
			{
				item = false;
				item2 = false;
				item3 = false;
				item4 = false;
				break;
			}
			if (!levelGroupModel.IsAllSilverPickedUp())
			{
				item2 = false;
			}
			if (!levelGroupModel.IsAllGoldPickedUp())
			{
				item3 = false;
			}
			if (!levelGroupModel.IsAllBothPickedUp())
			{
				item4 = false;
			}
		}
		return (isAllCompleted: item, isAllSilver: item2, isAllGold: item3, isAllBoth: item4);
	}

	private void LevelModelChangeHandler(string eventName, object[] data)
	{
		if (eventName == "LevelModel.NewLevelRecordsEvent")
		{
			LevelModel levelModel = data[0] as LevelModel;
			UpdateLevelGroupStatus();
			var (num, num2) = GetLevelAndGroupIndexes(levelModel);
			NotifyChange("GroupCampaignModel.NewLevelRecordsEvent", num, num2, levelModel);
		}
	}

	public void UpdateGroupAndLevelStatus()
	{
		foreach (LevelGroupModel levelGroupModel in levelGroupModels)
		{
			LevelModel[] allLevelModels = levelGroupModel.GetAllLevelModels();
			foreach (LevelModel levelModel in allLevelModels)
			{
				var (num, num2) = GetLevelAndGroupIndexes(levelModel);
				NotifyChange("GroupCampaignModel.NewLevelRecordsEvent", num, num2, levelModel);
			}
		}
		UpdateLevelGroupStatus();
	}
}
