using SafeTypes;
using UnityEngine;

public class XPController : MonoBehaviour
{
	public const int MAX_LEVEL = 60;

	public int addXpPerLevel = 45;

	public int[] specificXpPerLevel;

	private SafeInt _currentLevel;

	private SafeInt _currentXP;

	public int currentLevel
	{
		get
		{
			return _currentLevel.GetValue();
		}
		set
		{
			_currentLevel = new SafeInt(value);
		}
	}

	public int currentXP
	{
		get
		{
			return _currentXP.GetValue();
		}
		set
		{
			_currentXP = new SafeInt(value);
		}
	}

	public int nextXpThreshold
	{
		get
		{
			if (currentLevel < specificXpPerLevel.Length)
			{
				return specificXpPerLevel[currentLevel];
			}
			return ((specificXpPerLevel.Length != 0) ? specificXpPerLevel[specificXpPerLevel.Length - 1] : 0) + addXpPerLevel * (currentLevel - specificXpPerLevel.Length + 1);
		}
	}

	public bool isMaxLevel => currentLevel >= 60;

	public static XPController singleton { get; private set; }

	public int AddXP(int amount)
	{
		if (currentLevel >= 60)
		{
			amount = 0;
			currentXP = 0;
			currentLevel = 60;
		}
		else
		{
			if (EventController.singleton.CanPlayerSeeEvents() && EventController.singleton.IsEventActive("3xXP"))
			{
				amount *= 3;
			}
			currentXP += amount;
			if (currentXP >= nextXpThreshold)
			{
				currentXP = 0;
				currentLevel++;
				AnalyticsMacros.LevelUp(currentLevel);
			}
		}
		if (currentLevel >= 60)
		{
			AchievementController.singleton.ReportMaxPlayerLevelReached();
		}
		return amount;
	}

	public bool HasXpStone()
	{
		return Inventory.Singleton.HasItemById("xp_stone");
	}

	public void ChangeLevelNumber(int changeAmount)
	{
		currentLevel += changeAmount;
		currentLevel = Mathf.Clamp(currentLevel, 0, 60);
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("currentLevel", currentLevel);
		SlimJson.AddProperty("currentXP", currentXP);
		return SlimJson.EndSerialization();
	}

	public void Parse(string sjson)
	{
		if (sjson != null)
		{
			currentLevel = SlimJson.ParseInt(sjson, "currentLevel");
			currentXP = SlimJson.ParseInt(sjson, "currentXP");
		}
		else
		{
			ClearProgress();
		}
	}

	public void ClearProgress()
	{
		currentLevel = 0;
		currentXP = 0;
	}

	private void Awake()
	{
		singleton = this;
		_currentLevel = new SafeInt(0);
		_currentXP = new SafeInt(0);
	}
}
