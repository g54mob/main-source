using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ProgressionManager : MonoBehaviour
{
	[SerializeField]
	private byte level = 1;

	[SerializeField]
	private byte maxLevel = 100;

	[SerializeField]
	private AnimationCurve levelExperienceCurve;

	[SerializeField]
	private float xpMultiplier = 1f;

	[SerializeField]
	private int totalExperiencePoints;

	private int requiredXP;

	[SerializeField]
	private int totalMaxExperiencePoints = 10000;

	[SerializeField]
	private int currentExperiencePoints;

	[SerializeField]
	private ExperienceStat[] validExperienceStats;

	[SerializeField]
	private UnlockOption[] unlockOptions;

	[SerializeField]
	private static UnityEvent<int> OnLevelUp = new UnityEvent<int>();

	private List<IProgression> unlockables = new List<IProgression>();

	private int unlockableCount;

	[SerializeField]
	private int demo_maxlvl = 5;

	public static UnityEvent<int, int> OnLevelUpProgress = new UnityEvent<int, int>();

	private bool loadFromSaveFile;

	private static ProgressionManager instance;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
	}

	private void Start()
	{
		if (!loadFromSaveFile)
		{
			level = 1;
		}
		CalculatedRequiredLevelXP();
	}

	private void UpdateExperienceStat(string statName, int amount)
	{
		ExperienceStat experienceStat = validExperienceStats.First((ExperienceStat x) => x.name.ToLower().Contains(statName.ToLower()));
		if (experienceStat != null)
		{
			experienceStat.value += amount;
		}
	}

	private void ResetAllExperienceStats()
	{
		ExperienceStat[] array = validExperienceStats;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].value = 0;
		}
	}

	[ContextMenu("CalculateRequiredXP")]
	private void CalculatedRequiredLevelXP()
	{
		int num = 0;
		num = totalMaxExperiencePoints;
		requiredXP = (int)Mathf.Lerp(0f, num, levelExperienceCurve.Evaluate(Mathf.InverseLerp(0f, (int)maxLevel, (int)level)));
	}

	public static bool ReachedDemoLevel()
	{
		return instance.level >= instance.demo_maxlvl;
	}

	public static int GetDemoMax()
	{
		return instance.demo_maxlvl;
	}

	public static bool ReachedMaxLevel()
	{
		return instance.level > instance.maxLevel;
	}

	public static int GetMaxLevel()
	{
		return instance.maxLevel;
	}

	public static void SetCurrentExperience(int experience)
	{
		instance.currentExperiencePoints = experience;
	}

	public static void SetExperienceStats(ExperienceStat[] experienceStats)
	{
		instance.validExperienceStats = experienceStats;
	}

	public static ExperienceStat[] GetExperienceStats()
	{
		return instance.validExperienceStats;
	}

	public static int GetStockedXP()
	{
		return instance.totalExperiencePoints;
	}

	public static int GetCurrentXP()
	{
		return instance.currentExperiencePoints;
	}

	public static int GetRequiredXP()
	{
		return instance.requiredXP;
	}

	public static float GetProgressionAmount()
	{
		return Mathf.InverseLerp(0f, instance.requiredXP, instance.currentExperiencePoints);
	}

	public static int GetStatValue(int index)
	{
		return instance.validExperienceStats[index].value;
	}

	public static void GainXP(string statName, int amount)
	{
		instance.UpdateExperienceStat(statName, amount);
	}

	public static bool EvaluateLevelUP()
	{
		if (ReachedDemoLevel())
		{
			return false;
		}
		if (ReachedMaxLevel())
		{
			OnLevelUpProgress.Invoke(0, 0);
			instance.ResetAllExperienceStats();
			return false;
		}
		bool result = false;
		int num = instance.currentExperiencePoints;
		instance.totalExperiencePoints = 0;
		ExperienceStat[] array = instance.validExperienceStats;
		foreach (ExperienceStat experienceStat in array)
		{
			instance.totalExperiencePoints += Mathf.RoundToInt((float)experienceStat.gainedXP * instance.xpMultiplier);
		}
		num += instance.totalExperiencePoints;
		int num2 = 0;
		while (num > GetRequiredXP())
		{
			num -= instance.requiredXP;
			LevelUp();
			num2++;
			result = true;
		}
		instance.currentExperiencePoints = num;
		OnLevelUpProgress.Invoke(num2, num);
		instance.ResetAllExperienceStats();
		return result;
	}

	public static void ListenOnLevelUp(UnityAction<int> action)
	{
		OnLevelUp.AddListener(action);
	}

	public static void LoadCurrentLevel(int level)
	{
		instance.level = (byte)level;
		instance.loadFromSaveFile = true;
		OnLevelUp.Invoke(level);
	}

	public static int GetCurrentLevel()
	{
		return instance.level;
	}

	public static void Register(IProgression unlockable)
	{
		if (!(instance == null))
		{
			instance.unlockables.Add(unlockable);
			instance.unlockableCount++;
		}
	}

	public static void Unregister(IProgression unlockable)
	{
		instance.unlockables.Remove(unlockable);
	}

	[ContextMenu("Level Up")]
	private void LevelOneUp()
	{
		LevelUp();
	}

	public static void LevelUp()
	{
		instance.level++;
		instance.CheckShopItemUnlocks();
		OnLevelUp.Invoke(instance.level);
		instance.CalculatedRequiredLevelXP();
	}

	private void CheckShopItemUnlocks()
	{
		if (!IsUnlocked("ShopItem"))
		{
			ShopOptionsLibrary shopOptionsLibrary = Resources.Load<ShopOptionsLibrary>("Libraries/Shop Option Libs/AllShopOptions");
			if (shopOptionsLibrary == null)
			{
				Debug.Log("Shop Option Library could not be loaded! - Progression Manager");
			}
			else if (shopOptionsLibrary.shopOptions.FirstOrDefault((ShopOption x) => x.unlockLevel == instance.level) != null)
			{
				Unlock("ShopItem", instance.level);
			}
		}
	}

	public static void Unlock(string optionName, int level)
	{
		instance.unlockOptions.First((UnlockOption x) => x.name.ToLower().Contains(optionName.ToLower()))?.Unlock(level);
	}

	public static bool IsUnlocked(string optionName)
	{
		return instance.unlockOptions.First((UnlockOption x) => x.name.ToLower().Contains(optionName.ToLower()))?.IsUnlocked() ?? false;
	}

	public static UnlockOption[] GetUnlocks()
	{
		return instance.unlockOptions;
	}

	public static void ResetUnlocks()
	{
		for (int i = 0; i < instance.unlockOptions.Length; i++)
		{
			instance.unlockOptions[i].Reset();
		}
	}
}
