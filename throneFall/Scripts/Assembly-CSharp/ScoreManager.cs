using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour, DayNightCycle.IDaytimeSensitive, ISaveLoad
{
	private static ScoreManager instance;

	private EnemySpawner enemySpawner;

	[Min(0f)]
	public int baseScorePerNight = 100;

	[Min(0f)]
	public int protectionScorePerNight = 200;

	[Min(0f)]
	public int timeScorePerNight = 200;

	[Min(0f)]
	public float timebonusMultiplier = 1f;

	[Min(0f)]
	public float timeBonusMinTime = 10f;

	[Min(0f)]
	public float timeBonusMaxTime = 120f;

	[Min(0f)]
	public float protectionScoreMultiplier = 1f;

	[Range(1f, 2f)]
	public float scoreExponent = 2f;

	public float noRetryScoreMultiplier = 1.1f;

	public float noRetryScoreMultiplierInMiniModes = 1.01f;

	private int currentScore;

	private List<TagManager.ETag> buildingTags = new List<TagManager.ETag>(new TagManager.ETag[2]
	{
		TagManager.ETag.Building,
		TagManager.ETag.PlayerOwned
	});

	[HideInInspector]
	public UnityEvent<int, int, float, int> OnNightScoreAdd = new UnityEvent<int, int, float, int>();

	private bool tauntTheTiger;

	private bool tauntTheTurtle;

	private bool tauntTheFalcon;

	private bool tauntTheRat;

	private float scoreMultiplyerFromPerks;

	public float victoryGoldBonusMultiplyer = 10f;

	public static ScoreManager Instance => instance;

	public int CurrentScore => currentScore;

	public int VictoryGoldBonus => Mathf.CeilToInt((float)PlayerInteraction.instance.TrueBalance * victoryGoldBonusMultiplyer);

	public int VictoryMutatorBonus
	{
		get
		{
			float num = 1f;
			foreach (Equippable item in PerkManager.instance.CurrentlyEquipped)
			{
				if (item.GetType() == typeof(EquippableMutation))
				{
					num *= ((EquippableMutation)item).scoreMultiplyerOnWin;
				}
			}
			return Mathf.CeilToInt((float)(currentScore + VictoryGoldBonus) * (num - 1f));
		}
	}

	public int DefeatNoRetryBonus
	{
		get
		{
			if (MatchSaveLoadHandler.CurrentSave != null && MatchSaveLoadHandler.CurrentSave.hadRestarts)
			{
				return 0;
			}
			if (LevelProgressManager.instance.GetLevelInfoFromCurrentSceneName().contribution == LevelInfo.ProgressionContribution.Stars)
			{
				return Mathf.CeilToInt((float)currentScore * (noRetryScoreMultiplierInMiniModes - 1f));
			}
			return Mathf.CeilToInt((float)currentScore * (noRetryScoreMultiplier - 1f));
		}
	}

	public int VictoryNoRetryBonus
	{
		get
		{
			if (MatchSaveLoadHandler.CurrentSave != null && MatchSaveLoadHandler.CurrentSave.hadRestarts)
			{
				return 0;
			}
			if (LevelProgressManager.instance.GetLevelInfoFromCurrentSceneName().contribution == LevelInfo.ProgressionContribution.Stars)
			{
				return Mathf.CeilToInt((float)(currentScore + VictoryGoldBonus + VictoryMutatorBonus) * (noRetryScoreMultiplierInMiniModes - 1f));
			}
			return Mathf.CeilToInt((float)(currentScore + VictoryGoldBonus + VictoryMutatorBonus) * (noRetryScoreMultiplier - 1f));
		}
	}

	public int MaxScorePerNight => Mathf.RoundToInt((float)(baseScorePerNight + protectionScorePerNight + timeScorePerNight) * scoreMultiplyerFromPerks);

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
		MatchSaveLoadHandler.TryLoadValue(guid, "currentScore", ref currentScore);
		if (!EnemySpawner.instance || EnemySpawner.instance.WaveCount >= 2)
		{
			MatchSaveLoadHandler.CurrentSave.hadRestarts = true;
		}
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, "currentScore", currentScore);
	}

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one Scoremanger in Scene. Old Scoremanager destroyed.");
			Object.Destroy(instance);
		}
		instance = this;
	}

	private void Start()
	{
		enemySpawner = EnemySpawner.instance;
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		scoreMultiplyerFromPerks = 1f;
	}

	public void CalculateEndOfNightScore()
	{
		int num = Mathf.RoundToInt((float)baseScorePerNight * scoreMultiplyerFromPerks);
		int num2 = num;
		float currentNightLength = DayNightCycle.Instance.CurrentNightLength;
		float lastSpawnPeriodDuration = enemySpawner.LastSpawnPeriodDuration;
		int num3 = Mathf.RoundToInt(Mathf.Pow(Mathf.InverseLerp(timeBonusMaxTime + lastSpawnPeriodDuration, timeBonusMinTime + lastSpawnPeriodDuration, currentNightLength), scoreExponent) * (float)timeScorePerNight * scoreMultiplyerFromPerks);
		num2 += num3;
		List<TaggedObject> list = new List<TaggedObject>();
		TagManager.instance.FindAllTaggedObjectsWithTags(list, buildingTags, null);
		int num4 = 0;
		foreach (TaggedObject item in list)
		{
			BuildingInteractor componentInChildren = item.transform.parent.GetComponentInChildren<BuildingInteractor>(includeInactive: true);
			if ((bool)componentInChildren && componentInChildren.KnockedOutTonight)
			{
				num4++;
			}
		}
		float num5 = 1f - Mathf.InverseLerp(0f, list.Count, num4);
		float arg = num5;
		num5 = Mathf.Pow(num5, scoreExponent);
		int num6 = Mathf.RoundToInt((float)protectionScorePerNight * num5 * scoreMultiplyerFromPerks);
		num2 += num6;
		currentScore += num2;
		OnNightScoreAdd.Invoke(num, num3, arg, num6);
		LevelData levelDataForActiveScene = LevelProgressManager.instance.GetLevelDataForActiveScene();
		levelDataForActiveScene.highscore = currentScore;
		levelDataForActiveScene.dayToDayScore.Add(currentScore);
	}

	public void OnDusk()
	{
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
		CalculateEndOfNightScore();
	}

	public void AddDebugPoints(int amount)
	{
		currentScore += amount;
	}

	public void OnDuskEarly()
	{
	}
}
