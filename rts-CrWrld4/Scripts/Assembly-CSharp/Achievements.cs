using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class Achievements : MonoBehaviour
{
	public enum Achievement
	{
		ACH_0 = 0,
		ACH_1 = 1,
		ACH_2 = 2,
		ACH_3 = 3,
		ACH_4 = 4,
		ACH_5 = 5,
		ACH_6 = 6,
		ACH_7 = 7,
		ACH_8 = 8,
		ACH_9 = 9,
		ACH_10 = 10,
		ACH_11 = 11,
		ACH_12 = 12,
		ACH_13 = 13,
		ACH_14 = 14,
		ACH_15 = 15,
		ACH_16 = 16,
		ACH_17 = 17,
		ACH_18 = 18,
		ACH_19 = 19,
		ACH_20 = 20,
		ACH_21 = 21,
		ACH_22 = 22,
		ACH_23 = 23,
		ACH_24 = 24,
		ACH_25 = 25,
		ACH_26 = 26,
		ACH_27 = 27,
		ACH_28 = 28
	}

	public class AchievementRecord
	{
		public Achievement achievementID;

		public string name;

		public string description;

		public string linkedStat;

		public int linkedStatVal;

		public bool achieved;

		public AchievementRecord()
		{
		}

		public AchievementRecord(Achievement achievement, string name, string desc, bool achieved, string linkedStat, int linkedStatVal)
		{
		}

		public void ReadData(Tag tag)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public class Stat
	{
		public string name;

		public string desc;

		public int val;

		public Stat()
		{
		}

		public Stat(string name, string desc, int val)
		{
		}

		public void ReadData(Tag tag)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public AchievementBadge achievementBadge;

	public Sprite[] achievementSprites;

	public Sprite[] achievementBWSprites;

	public static Achievements instance;

	private bool dirty;

	public Dictionary<Achievement, AchievementRecord> achievements;

	public Dictionary<string, Stat> stats;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void UnlockAchievement(Achievement a, bool suppressBadge = false)
	{
	}

	public void UnlockAchievement(Achievement a, bool suppressBadge, bool suppressSteam)
	{
	}

	public void ShowAchievementProgress(Achievement a)
	{
	}

	public void ShowAchievementProgress(Achievement a, bool suppressSteam)
	{
	}

	public AchievementRecord GetAchievementRecord(Achievement val)
	{
		return null;
	}

	private void CheckLinkedAchievements()
	{
	}

	public void SetStat(string stat, int amt)
	{
	}

	public int AddToStat(string stat, int amt = 1)
	{
		return 0;
	}

	public Stat GetStat(string stat)
	{
		return null;
	}

	public void ReadData(Tag tag)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}
}
