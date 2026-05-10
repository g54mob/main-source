using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelsProgressionManager : MonoBehaviour, ISavable
{
	[Serializable]
	public class FLevelProgressionInfo : ISavable
	{
		[SerializeField]
		private LevelData levelData;

		[SerializeField]
		private LevelData unlockedBy;

		[SerializeField]
		[Savable("Victories", true, false)]
		private int victories;

		[Savable("HasPlayedLevel", true, false)]
		private bool hasPlayedLevel;

		[Savable("BossRevealed", true, false)]
		private bool bossRevealed;

		[Savable("BossDefeated", true, false)]
		private bool bossDefeated;

		[SerializeField]
		[Savable("CompletedInExpertMode", true, false)]
		private bool completedInExpertMode;

		[Savable("BossDefeatedInExpertMode", true, false)]
		private bool bossDefeatedInExpertMode;

		[SerializeField]
		private bool forceUnlocked;

		[SerializeField]
		private bool forceBossDefeated;

		public LevelData LevelData => levelData;

		public LevelData UnlockedBy => unlockedBy;

		public int Victories
		{
			get
			{
				return victories;
			}
			set
			{
				victories = value;
			}
		}

		public bool Completed => Victories > 0;

		public bool HasPlayedLevel
		{
			get
			{
				return hasPlayedLevel;
			}
			set
			{
				hasPlayedLevel = value;
			}
		}

		public bool ForceUnlocked => forceUnlocked;

		public bool ForceBossDefeated => forceBossDefeated;

		public bool BossRevealed
		{
			get
			{
				if (!bossRevealed)
				{
					return ForceBossDefeated;
				}
				return true;
			}
			set
			{
				bossRevealed = value;
			}
		}

		public bool BossDefeated
		{
			get
			{
				if (!bossDefeated)
				{
					return ForceBossDefeated;
				}
				return true;
			}
			set
			{
				bossDefeated = value;
			}
		}

		public bool BossDefeatedInExpertMode
		{
			get
			{
				return bossDefeatedInExpertMode;
			}
			set
			{
				bossDefeatedInExpertMode = value;
			}
		}

		public bool CompletedInExpertMode
		{
			get
			{
				return completedInExpertMode;
			}
			set
			{
				completedInExpertMode = value;
			}
		}

		public void OnPreLoad()
		{
		}

		public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
		{
		}

		public void OnSave()
		{
		}
	}

	public static LevelsProgressionManager instance;

	[SerializeField]
	[Savable("LevelProgressionInfos", true, false)]
	private FLevelProgressionInfo[] levelProgressionInfos;

	public FLevelProgressionInfo[] LevelProgressionInfos => levelProgressionInfos;

	public event Action<FLevelProgressionInfo> OnCompleteLevel;

	public event Action<EnemyData> OnDefeatBoss;

	public event Action OnDataLoaded;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		LTFunctionLibrary.GetPlayerUpgradesManager().onPlayerUpgradesRefunded += OnUpgradesRefunded;
		SaveSystem.instance.onProfileDataDeleted += OnProfileDataDeleted;
	}

	public bool IsLevelComplete(string levelID)
	{
		return GetLevelProgressionInfoByID(levelID).Completed;
	}

	public void CompleteLevel(string levelID, bool expertMode)
	{
		GetLevelProgressionInfoByID(levelID).Victories++;
		if (expertMode)
		{
			GetLevelProgressionInfoByID(levelID).CompletedInExpertMode = true;
		}
		this.OnCompleteLevel?.Invoke(GetLevelProgressionInfoByID(levelID));
		SaveSystem.instance.SaveData();
	}

	public bool HasPlayedLevel(string levelID)
	{
		return GetLevelProgressionInfoByID(levelID).HasPlayedLevel;
	}

	public void SetLevelPlayed(string levelID)
	{
		GetLevelProgressionInfoByID(levelID).HasPlayedLevel = true;
		SaveSystem.instance.SaveData();
	}

	public void RevealBoss(string levelID)
	{
		FLevelProgressionInfo levelProgressionInfoByID = GetLevelProgressionInfoByID(levelID);
		if (levelProgressionInfoByID != null)
		{
			levelProgressionInfoByID.BossRevealed = true;
			SaveSystem.instance.SaveData();
		}
	}

	public void CompleteBoss(string levelID, EnemyData bossData, bool expertMode)
	{
		if (!GetLevelProgressionInfoByID(levelID).BossDefeated)
		{
			GetLevelProgressionInfoByID(levelID).BossDefeated = true;
			GiveBossReward(levelID);
			SaveSystem.instance.SaveData();
			this.OnDefeatBoss?.Invoke(bossData);
		}
		if (expertMode)
		{
			GetLevelProgressionInfoByID(levelID).BossDefeatedInExpertMode = true;
			SaveSystem.instance.SaveData();
		}
	}

	public bool IsBossDefeated(string levelID)
	{
		return GetLevelProgressionInfoByID(levelID).BossDefeated;
	}

	private void GiveBossReward(string levelID)
	{
		foreach (BossReward bossReward in GetLevelProgressionInfoByID(levelID).LevelData.BossRewards)
		{
			bossReward.GiveBossReward();
		}
	}

	private void GiveAllBossRewards()
	{
		FLevelProgressionInfo[] array = levelProgressionInfos;
		foreach (FLevelProgressionInfo fLevelProgressionInfo in array)
		{
			if (fLevelProgressionInfo.BossDefeated)
			{
				GiveBossReward(fLevelProgressionInfo.LevelData.Id);
			}
		}
	}

	public int GetLevelVictories(string levelID)
	{
		return GetLevelProgressionInfoByID(levelID).Victories;
	}

	private FLevelProgressionInfo GetLevelProgressionInfoByID(string levelID)
	{
		return LevelProgressionInfos.First((FLevelProgressionInfo x) => x.LevelData.Id == levelID);
	}

	public bool IsLevelUnlocked(string levelID)
	{
		FLevelProgressionInfo levelProgressionInfoByID = GetLevelProgressionInfoByID(levelID);
		if (levelProgressionInfoByID.ForceUnlocked)
		{
			return true;
		}
		if (!(levelProgressionInfoByID.UnlockedBy == null))
		{
			return GetLevelProgressionInfoByID(levelProgressionInfoByID.UnlockedBy.Id).Completed;
		}
		return true;
	}

	public bool IsLevelCompletedInExpertMode(string levelID)
	{
		return GetLevelProgressionInfoByID(levelID).CompletedInExpertMode;
	}

	public bool IsBossDefeatedInExpertMode(string levelID)
	{
		return GetLevelProgressionInfoByID(levelID).BossDefeatedInExpertMode;
	}

	private void OnUpgradesRefunded()
	{
		GiveAllBossRewards();
	}

	private void OnProfileDataDeleted(SaveProfile deletedProfile, bool isSelectedProfile)
	{
		if (isSelectedProfile)
		{
			FLevelProgressionInfo[] array = levelProgressionInfos;
			foreach (FLevelProgressionInfo obj in array)
			{
				obj.Victories = 0;
				obj.CompletedInExpertMode = false;
				obj.BossDefeated = false;
				obj.BossDefeatedInExpertMode = false;
				obj.BossRevealed = false;
			}
		}
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
		OnProfileDataDeleted(null, isSelectedProfile: true);
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (hasLoadedSomething)
		{
			GiveAllBossRewards();
			this.OnDataLoaded?.Invoke();
		}
		else
		{
			OnProfileDataDeleted(null, isSelectedProfile: true);
		}
	}
}
