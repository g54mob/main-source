using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "LevelData_default", menuName = "Tower Factory/Procedural Generation/Level Data")]
public class LevelData : ScriptableObject
{
	[SerializeField]
	private string id;

	[SerializeField]
	private LocalizedString displayName;

	[SerializeField]
	private Sprite thumbnail;

	[Space]
	[SerializeField]
	private GameObject mapGeneratorPrefab;

	[SerializeField]
	private int mapGeneratorVersion;

	[Space]
	[SerializeField]
	private GameObject levelControllerPrefab;

	[SerializeField]
	private GameObject dayNightCyclePrefab;

	[SerializeField]
	private VolumeProfile postProcessingProfile;

	[SerializeField]
	private LevelSpawners levelSpawners;

	[SerializeField]
	private int crystalsToWin;

	[SerializeField]
	private int moneyPerWave = 1;

	[SerializeField]
	private int moneyFirstVictory = 1;

	[SerializeField]
	private int moneyVictory = 1;

	[Header("Boss")]
	[SerializeField]
	private List<BossReward> bossRewards;

	[SerializeField]
	private LocalizedString bossName;

	[SerializeField]
	private LocalizedString bossDescription;

	[SerializeField]
	private LocalizedString bossHiddenDescription;

	[SerializeField]
	private LocalizedString rewardDescription;

	[SerializeField]
	private LocalizedString rewardHiddenDescription;

	[SerializeField]
	private Sprite rewardImage;

	[SerializeField]
	private GameObject christmasMapGeneratorPrefab;

	[SerializeField]
	private LocalizedString infoMessageTitle;

	[SerializeField]
	private LocalizedString infoMessage;

	[SerializeField]
	private Sprite infoMessageImage;

	[SerializeField]
	private AudioData dayAmbience;

	[SerializeField]
	private AudioData nightAmbience;

	[SerializeField]
	private AudioData dayMusic;

	[SerializeField]
	private AudioData nightMusic;

	public string Id => id;

	public Sprite Thumbnail => thumbnail;

	public LocalizedString DisplayName
	{
		get
		{
			return displayName;
		}
		set
		{
			displayName = value;
		}
	}

	public int MapGeneratorVersion => mapGeneratorVersion;

	public GameObject LevelControllerPrefab => levelControllerPrefab;

	public GameObject DayNightCyclePrefab => dayNightCyclePrefab;

	public VolumeProfile PostProcessingProfile => postProcessingProfile;

	public LevelSpawners LevelSpawners => levelSpawners;

	public int CrystalsToWin => crystalsToWin;

	public int MoneyPerWave => moneyPerWave;

	public int MoneyFirstVictory => moneyFirstVictory;

	public int MoneyVictory => moneyVictory;

	public AudioData DayAmbience
	{
		get
		{
			return dayAmbience;
		}
		set
		{
			dayAmbience = value;
		}
	}

	public AudioData NightAmbience
	{
		get
		{
			return nightAmbience;
		}
		set
		{
			nightAmbience = value;
		}
	}

	public AudioData DayMusic
	{
		get
		{
			return dayMusic;
		}
		set
		{
			dayMusic = value;
		}
	}

	public AudioData NightMusic
	{
		get
		{
			return nightMusic;
		}
		set
		{
			nightMusic = value;
		}
	}

	public List<BossReward> BossRewards => bossRewards;

	public string BossName
	{
		get
		{
			if (bossName.IsEmpty)
			{
				return "";
			}
			return bossName.GetLocalizedString();
		}
	}

	public string BossDescription
	{
		get
		{
			if (bossDescription.IsEmpty)
			{
				return "";
			}
			return bossDescription.GetLocalizedString();
		}
	}

	public string BossHiddenDescription
	{
		get
		{
			if (bossHiddenDescription.IsEmpty)
			{
				return "";
			}
			return bossHiddenDescription.GetLocalizedString();
		}
	}

	public string RewardDescription
	{
		get
		{
			if (rewardDescription.IsEmpty)
			{
				return "";
			}
			return rewardDescription.GetLocalizedString();
		}
	}

	public string RewardHiddenDescription
	{
		get
		{
			if (rewardHiddenDescription.IsEmpty)
			{
				return "";
			}
			return rewardHiddenDescription.GetLocalizedString();
		}
	}

	public Sprite RewardImage => rewardImage;

	public string InfoMessageTitle
	{
		get
		{
			if (infoMessageTitle.IsEmpty)
			{
				return "";
			}
			return infoMessageTitle.GetLocalizedString();
		}
	}

	public string InfoMessage
	{
		get
		{
			if (infoMessage.IsEmpty)
			{
				return "";
			}
			return infoMessage.GetLocalizedString();
		}
	}

	public Sprite InfoMessageImage => infoMessageImage;

	public GameObject MapGeneratorPrefab
	{
		get
		{
			if (!SettingsController.instance.SeasonalContentEnabled)
			{
				return mapGeneratorPrefab;
			}
			switch (LTFunctionLibrary.GetCurrentSeason())
			{
			case LTFunctionLibrary.ESeason.None:
				return mapGeneratorPrefab;
			case LTFunctionLibrary.ESeason.Christmas:
				if ((bool)christmasMapGeneratorPrefab)
				{
					return christmasMapGeneratorPrefab;
				}
				break;
			}
			return mapGeneratorPrefab;
		}
	}

	public int TotalDays()
	{
		return levelSpawners.GetTotalCyclesAmount();
	}
}
