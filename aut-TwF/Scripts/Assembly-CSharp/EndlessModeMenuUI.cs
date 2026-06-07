using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class EndlessModeMenuUI : HUDMenu, ISavable
{
	private LTMainMenuHUD ltMainMenuHud;

	[Header("Endless mode")]
	[SerializeField]
	private GameMode endlessGameMode;

	[SerializeField]
	private LevelData[] levelDatas;

	[Header("LevelUI Prefabs")]
	[SerializeField]
	private GameObject levelUIPrefabs;

	[SerializeField]
	private GameObject lockedLevelUIPrefab;

	[SerializeField]
	private GameObject comingSoonLevelUIPrefab;

	[Header("References")]
	[SerializeField]
	private Transform LevelUIsContainer;

	[SerializeField]
	private GameObject previousLevelsButton;

	[SerializeField]
	private GameObject nextLevelsButton;

	[SerializeField]
	private SpinnerSelector difficultySelector;

	[SerializeField]
	private TooltipComponent_text difficultyTooltip;

	[SerializeField]
	private SpinnerSelector mapSizeSelector;

	[SerializeField]
	private SpinnerSelector buildDuringPauseSelector;

	[SerializeField]
	private GameObject savedGameContainer;

	[SerializeField]
	private TextMeshProUGUI saveGameLevelNameText;

	[SerializeField]
	private TextMeshProUGUI savedGameDayTimeText;

	private int currentLevelPage;

	[Savable("currentDifficultyIdx", true, false)]
	private int currentDifficultyIdx = 1;

	[Savable("currentMapSizeIdx", true, false)]
	private int currentMapSizeIdx = 2;

	[Savable("buildDuringPauseIdx", true, false)]
	private int currentBuildDuringPauseIdx;

	private bool isStartingGame;

	public int CurrentDifficultyIdx
	{
		get
		{
			return currentDifficultyIdx;
		}
		private set
		{
			currentDifficultyIdx = value;
			SaveSystem.instance.SaveData();
		}
	}

	public int CurrentMapSizeIdx
	{
		get
		{
			return currentMapSizeIdx;
		}
		private set
		{
			currentMapSizeIdx = value;
			if (base.gameObject.activeSelf)
			{
				EndlessModeLevelUI[] componentsInChildren = LevelUIsContainer.GetComponentsInChildren<EndlessModeLevelUI>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].UpdateScore(GetMapSizeByIdx(CurrentMapSizeIdx));
				}
			}
			SaveSystem.instance.SaveData();
		}
	}

	public int CurrentBuildDuringPauseIdx
	{
		get
		{
			return currentBuildDuringPauseIdx;
		}
		private set
		{
			currentBuildDuringPauseIdx = value;
			SaveSystem.instance.SaveData();
		}
	}

	protected override void Start()
	{
		base.Start();
		ltMainMenuHud = base.Hud as LTMainMenuHUD;
	}

	private void OnEnable()
	{
		previousLevelsButton.SetActive(value: false);
		nextLevelsButton.SetActive(value: false);
		SetupDifficultySelector();
		SetupMapSizeSelector();
		SetupBuildDuringPauseSelector();
		SetupSavedGame();
		SetupLevels(0);
		currentLevelPage = 0;
		base.Hud.BlurBackground(enable: true);
	}

	private void OnDisable()
	{
		difficultySelector.onValueChanged -= OnDifficultyChanged;
		mapSizeSelector.onValueChanged -= OnMapSizeChanged;
		buildDuringPauseSelector.onValueChanged -= OnBuildDuringPauseChanged;
	}

	public override bool BackButtonPressed()
	{
		if (!isStartingGame && base.BackButtonPressed())
		{
			OnBackButtonPressed();
			return true;
		}
		return false;
	}

	private void SetupDifficultySelector()
	{
		string[] options = new string[3]
		{
			MatchSettings.GetDifficultyName(MatchSettings.EMatchDifficulty.Easy),
			MatchSettings.GetDifficultyName(MatchSettings.EMatchDifficulty.Medium),
			MatchSettings.GetDifficultyName(MatchSettings.EMatchDifficulty.Hard)
		};
		difficultySelector.SetOptions(options);
		difficultySelector.SetValue(CurrentDifficultyIdx);
		difficultySelector.onValueChanged += OnDifficultyChanged;
		UpdateDifficultyTooltip();
	}

	private void UpdateDifficultyTooltip()
	{
		float enemyLifeMultiplier = MatchSettings.GetEnemyLifeMultiplier(GetDifficultyByIdx(CurrentDifficultyIdx));
		enemyLifeMultiplier = Mathf.RoundToInt(enemyLifeMultiplier * 100f);
		difficultyTooltip.TooltipText = string.Format(LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_difficulty_tooltip").Entry.GetLocalizedString(), enemyLifeMultiplier);
	}

	private void SetupMapSizeSelector()
	{
		string[] options = new string[5]
		{
			MatchSettings.GetMapSizeName(EMapSize.XS),
			MatchSettings.GetMapSizeName(EMapSize.S),
			MatchSettings.GetMapSizeName(EMapSize.M),
			MatchSettings.GetMapSizeName(EMapSize.L),
			MatchSettings.GetMapSizeName(EMapSize.XL)
		};
		mapSizeSelector.SetOptions(options);
		mapSizeSelector.SetValue(CurrentMapSizeIdx);
		mapSizeSelector.onValueChanged += OnMapSizeChanged;
	}

	private void SetupBuildDuringPauseSelector()
	{
		string[] options = new string[2]
		{
			LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_no", null, FallbackBehavior.UseProjectSettings),
			LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_yes", null, FallbackBehavior.UseProjectSettings)
		};
		buildDuringPauseSelector.SetOptions(options);
		buildDuringPauseSelector.SetValue(CurrentBuildDuringPauseIdx);
		buildDuringPauseSelector.onValueChanged += OnBuildDuringPauseChanged;
	}

	private void SetupSavedGame()
	{
		if (!SaveSystem.instance.ExistsSavedGame())
		{
			savedGameContainer.SetActive(value: false);
			return;
		}
		Dictionary<string, object> savedGameMetadata = SaveSystem.instance.SavedGameMetadata;
		if (savedGameMetadata != null)
		{
			EMatchMode eMatchMode = EMatchMode.Endless;
			if (savedGameMetadata.ContainsKey("matchMode"))
			{
				eMatchMode = (EMatchMode)savedGameMetadata["matchMode"];
			}
			if (eMatchMode != EMatchMode.Endless)
			{
				savedGameContainer.SetActive(value: false);
				return;
			}
			savedGameContainer.SetActive(value: true);
			string levelDataId = savedGameMetadata["levelDataId"] as string;
			LevelData levelData = LTFunctionLibrary.GetLevelsProgressionManager().LevelProgressionInfos.First((LevelsProgressionManager.FLevelProgressionInfo x) => x.LevelData.Id == levelDataId).LevelData;
			int mapGeneratorVersion = levelData.MapGeneratorVersion;
			int num = (int)savedGameMetadata["mapGeneratorVersion"];
			int num2 = (int)savedGameMetadata["currentCycle"];
			if (num < mapGeneratorVersion)
			{
				int num3 = 0;
				num3 = ((num2 != 0) ? Mathf.CeilToInt((float)(levelData.MoneyPerWave * (num2 + 1)) * 1.5f) : Mathf.CeilToInt((float)levelData.MoneyPerWave * 0.5f));
				LTFunctionLibrary.GetPlayerUpgradesManager().AddMoney(num3);
				string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_NewGameMenu", "UI_NewGameMenu_modalWindow_invalidSavedGameVersion_body", new object[1] { num3 });
				string localizedString2 = LocalizationSettings.StringDatabase.GetLocalizedString("UI_Common", "UI_Common_ok", null, FallbackBehavior.UseProjectSettings);
				base.Hud.ShowModalWindowOneButton(localizedString, "", null, null, localizedString2);
				SaveSystem.instance.DeleteSavedGame();
				SaveSystem.instance.SaveData();
				savedGameContainer.SetActive(value: false);
			}
			else
			{
				saveGameLevelNameText.text = levelData.DisplayName.GetLocalizedString();
				float num4 = (float)(double)savedGameMetadata["currentTime"];
				string localizedString3 = LocalizationSettings.StringDatabase.GetLocalizedString("UI_NewGameMenu", "UI_NewGameMenu_savedGame_day", new object[1] { num2 + 1 });
				localizedString3 = localizedString3 + " - " + FunctionLibrary.MillisecondsToHourMinuteSeconds((int)num4 * 1000);
				savedGameDayTimeText.text = localizedString3;
			}
		}
		else
		{
			saveGameLevelNameText.text = "?";
			savedGameDayTimeText.text = "-";
		}
	}

	private void SetupLevels(int page)
	{
		LevelUIsContainer.DeleteAllChildren();
		int num = 3;
		LevelsProgressionManager.FLevelProgressionInfo[] array = new LevelsProgressionManager.FLevelProgressionInfo[levelDatas.Length];
		for (int i = 0; i < levelDatas.Length; i++)
		{
			array[i] = LTFunctionLibrary.GetLevelsProgressionManager().GetLevelProgressionInfoByID(levelDatas[i].Id);
		}
		for (int j = page * num; j < (page + 1) * num; j++)
		{
			if (j < array.Length)
			{
				if (LTFunctionLibrary.GetLevelsProgressionManager().IsLevelUnlocked(array[j].LevelData.Id))
				{
					EndlessModeLevelUI component = UnityEngine.Object.Instantiate(levelUIPrefabs, LevelUIsContainer).GetComponent<EndlessModeLevelUI>();
					component.SetLevel(array[j]);
					component.UpdateScore(GetMapSizeByIdx(CurrentMapSizeIdx));
					component.onButtonPressed += OnLevelButtonPressed;
				}
				else
				{
					GameObject obj = UnityEngine.Object.Instantiate(lockedLevelUIPrefab, LevelUIsContainer);
					obj.GetComponent<NewGameLevelUI_locked>().SetThumbnail(array[j].LevelData.Thumbnail);
					obj.GetComponent<AutoTransformRebuild>().RebuildTransform();
				}
			}
			else
			{
				UnityEngine.Object.Instantiate(comingSoonLevelUIPrefab, LevelUIsContainer);
			}
		}
		previousLevelsButton.SetActive(page != 0);
		nextLevelsButton.SetActive((page + 1) * num - 1 < array.Length);
	}

	private MatchSettings.EMatchDifficulty GetDifficultyByIdx(int idx)
	{
		return idx switch
		{
			0 => MatchSettings.EMatchDifficulty.Easy, 
			1 => MatchSettings.EMatchDifficulty.Medium, 
			2 => MatchSettings.EMatchDifficulty.Hard, 
			_ => MatchSettings.EMatchDifficulty.Medium, 
		};
	}

	private EMapSize GetMapSizeByIdx(int idx)
	{
		return idx switch
		{
			0 => EMapSize.XS, 
			1 => EMapSize.S, 
			2 => EMapSize.M, 
			3 => EMapSize.L, 
			4 => EMapSize.XL, 
			_ => EMapSize.M, 
		};
	}

	private bool GetBuildDuringPauseByIdx(int idx)
	{
		return idx == 1;
	}

	private void OnDifficultyChanged(int difficulty)
	{
		CurrentDifficultyIdx = difficulty;
		UpdateDifficultyTooltip();
	}

	private void OnMapSizeChanged(int mapSize)
	{
		CurrentMapSizeIdx = mapSize;
	}

	private void OnBuildDuringPauseChanged(int buildDuringPause)
	{
		CurrentBuildDuringPauseIdx = buildDuringPause;
	}

	private void OnLevelButtonPressed(LevelData data)
	{
		OnStartGameButtonPressed(data);
	}

	public void OnNextLevelsButton()
	{
		currentLevelPage++;
		SetupLevels(currentLevelPage);
	}

	public void OnPreviousLevelsButton()
	{
		currentLevelPage--;
		SetupLevels(currentLevelPage);
	}

	public void OnStartGameButtonPressed(LevelData levelData)
	{
		if (SaveSystem.instance.ExistsSavedGame())
		{
			string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_NewGameMenu", "UI_NewGameMenu_modalWindow_pendingSavedGame_body", null, FallbackBehavior.UseProjectSettings);
			Action yesAction = delegate
			{
				SaveSystem.instance.DeleteSavedGame();
				OnStartGameButtonPressed(levelData);
			};
			base.Hud.ShowModalWindowTwoButtons(localizedString, "", null, yesAction, null);
		}
		else
		{
			MatchInfo.instance.CurrentLevelData = levelData;
			MatchInfo.instance.CurrentMatchMode = EMatchMode.Endless;
			MatchInfo.instance.CurrentGameMode = endlessGameMode;
			MatchInfo.instance.CurrentMatchSettings.MatchDifficulty = GetDifficultyByIdx(CurrentDifficultyIdx);
			MatchInfo.instance.CurrentMatchSettings.MapSize = GetMapSizeByIdx(currentMapSizeIdx);
			MatchInfo.instance.CurrentMatchSettings.BuildDuringPause = GetBuildDuringPauseByIdx(CurrentBuildDuringPauseIdx);
			StartGame(3);
		}
	}

	public void OnLoadGameButtonPressed()
	{
		if (SaveSystem.instance.ExistsSavedGame())
		{
			SaveSystem.instance.LoadSavedGameData();
			MatchInfo.instance.CurrentLevelData = null;
			MatchInfo.instance.CurrentMatchMode = EMatchMode.Endless;
			StartGame(3);
		}
	}

	public void OnDeleteSavedGameButtonPressed()
	{
		string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_NewGameMenu", "UI_NewGameMenu_modalWindow_deleteSavedGame_body", null, FallbackBehavior.UseProjectSettings);
		Action yesAction = delegate
		{
			SaveSystem.instance.DeleteSavedGame();
			savedGameContainer.SetActive(value: false);
		};
		ltMainMenuHud.ShowModalWindowTwoButtons(localizedString, "", null, yesAction, null);
	}

	private void StartGame(int levelToLoadIdx)
	{
		float time = 2f;
		isStartingGame = true;
		float startingVolume = AudioSystem.Instance.GetCurrentMixerVolumePercentage(AudioSystem.EAudioMixerGroup.Master);
		base.Hud.FadeInOut.FadeIn(time, delegate(float timePercentage)
		{
			AudioSystem.Instance.SetMixerVolume(startingVolume - startingVolume * timePercentage, AudioSystem.EAudioMixerGroup.Master);
		}, delegate
		{
			LoadingScreenController.sceneToLoadIdx = levelToLoadIdx;
			SceneManager.LoadScene(1, LoadSceneMode.Single);
		});
	}

	public void OnBackButtonPressed()
	{
		ltMainMenuHud.ShowMainMenuUI();
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		OnDifficultyChanged(1);
		difficultySelector.SetValue(1);
		OnMapSizeChanged(2);
		mapSizeSelector.SetValue(2);
		if (hasLoadedSomething)
		{
			if (data.ContainsKey("currentDifficultyIdx"))
			{
				OnDifficultyChanged((int)data["currentDifficultyIdx"]);
				difficultySelector.SetValue(CurrentDifficultyIdx);
			}
			if (data.ContainsKey("currentMapSizeIdx"))
			{
				OnMapSizeChanged((int)data["currentMapSizeIdx"]);
				mapSizeSelector.SetValue(currentMapSizeIdx);
			}
			if (data.ContainsKey("buildDuringPauseIdx"))
			{
				OnBuildDuringPauseChanged((int)data["buildDuringPauseIdx"]);
				buildDuringPauseSelector.SetValue(currentBuildDuringPauseIdx);
			}
		}
	}
}
