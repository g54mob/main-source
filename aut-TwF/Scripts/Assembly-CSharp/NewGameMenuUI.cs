using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameMenuUI : HUDMenu, ISavable
{
	private LTMainMenuHUD ltMainMenuHud;

	[Header("LevelUI Prefabs")]
	[SerializeField]
	private GameObject levelUIPrefabs;

	[SerializeField]
	private GameObject lockedLevelUIPrefab;

	[SerializeField]
	private GameObject comingSoonLevelUIPrefab;

	[Space]
	[SerializeField]
	private LevelData[] levelDatas;

	[Header("References")]
	[SerializeField]
	private Transform LevelUIsContainer;

	[SerializeField]
	private GameObject previousLevelsButton;

	[SerializeField]
	private GameObject nextLevelsButton;

	[SerializeField]
	private Image gameModeImage;

	[SerializeField]
	private TextMeshProUGUI gameModeName;

	[SerializeField]
	private SpinnerSelector difficultySelector;

	[SerializeField]
	private GameObject difficultyLockIcon;

	[SerializeField]
	private TooltipComponent_text difficultyTooltip;

	[SerializeField]
	private GameObject savedGameContainer;

	[SerializeField]
	private TextMeshProUGUI saveGameLevelNameText;

	[SerializeField]
	private TextMeshProUGUI savedGameDayTimeText;

	private int currentLevelPage;

	[Savable("hasPlayedTutorial", true, false)]
	private bool hasPlayedTutorial;

	[Savable("currentDifficultyIdx", true, false)]
	private int currentDifficultyIdx = 1;

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

	protected override void Start()
	{
		base.Start();
		ltMainMenuHud = base.Hud as LTMainMenuHUD;
	}

	private void OnEnable()
	{
		previousLevelsButton.SetActive(value: false);
		nextLevelsButton.SetActive(value: false);
		SetupGameMode();
		SetupDifficultySelector();
		SetupSavedGame();
		SetupLevels(0);
		currentLevelPage = 0;
		base.Hud.BlurBackground(enable: true);
	}

	private void OnDisable()
	{
		difficultySelector.onValueChanged -= OnDifficultyChanged;
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

	private void SetupGameMode()
	{
		if (MatchInfo.instance.CurrentGameMode.Id == "endless")
		{
			MatchInfo.instance.SetGameModeById("classic");
		}
		gameModeImage.sprite = MatchInfo.instance.CurrentGameMode.Icon;
		gameModeName.text = MatchInfo.instance.CurrentGameMode.DisplayName.GetLocalizedString();
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
		if (MatchInfo.instance.CurrentGameMode.Id == "expert")
		{
			difficultySelector.SetValue(2);
			difficultySelector.ShowArrows(show: false);
			difficultyLockIcon.SetActive(value: true);
		}
		else
		{
			difficultySelector.ShowArrows(show: true);
			difficultyLockIcon.SetActive(value: false);
		}
		UpdateDifficultyTooltip();
	}

	private void UpdateDifficultyTooltip()
	{
		float enemyLifeMultiplier = MatchSettings.GetEnemyLifeMultiplier(GetDifficultyByIdx(CurrentDifficultyIdx));
		enemyLifeMultiplier = Mathf.RoundToInt(enemyLifeMultiplier * 100f);
		difficultyTooltip.TooltipText = string.Format(LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_difficulty_tooltip").Entry.GetLocalizedString(), enemyLifeMultiplier);
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
			EMatchMode eMatchMode = EMatchMode.Campaign;
			if (savedGameMetadata.ContainsKey("matchMode"))
			{
				eMatchMode = (EMatchMode)savedGameMetadata["matchMode"];
			}
			if (eMatchMode != EMatchMode.Campaign)
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
			SaveSystem.instance.DeleteSavedGame();
			SaveSystem.instance.SaveData();
			savedGameContainer.SetActive(value: false);
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
					NewGameLevelUI component = UnityEngine.Object.Instantiate(levelUIPrefabs, LevelUIsContainer).GetComponent<NewGameLevelUI>();
					component.SetLevel(array[j]);
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

	private void OnDifficultyChanged(int difficulty)
	{
		CurrentDifficultyIdx = difficulty;
		UpdateDifficultyTooltip();
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
		else if (!hasPlayedTutorial)
		{
			hasPlayedTutorial = true;
			SaveSystem.instance.SaveData();
			string localizedString2 = LocalizationSettings.StringDatabase.GetTableEntry("UI_NewGameMenu", "UI_NewGameMenu_modalWindow_playTutorial_message_01").Entry.GetLocalizedString();
			Action yesAction2 = delegate
			{
				OnTutorialButtonPressed();
			};
			Action noAction = delegate
			{
				OnStartGameButtonPressed(levelData);
			};
			base.Hud.ShowModalWindowTwoButtons(localizedString2, "", null, yesAction2, noAction);
		}
		else
		{
			MatchInfo.instance.CurrentLevelData = levelData;
			MatchInfo.instance.CurrentMatchMode = EMatchMode.Campaign;
			MatchInfo.instance.CurrentMatchSettings.MatchDifficulty = GetDifficultyByIdx(CurrentDifficultyIdx);
			MatchInfo.instance.CurrentMatchSettings.MapSize = EMapSize.M;
			StartGame(3);
		}
	}

	public void OnChangeGameModeButtonPressed()
	{
		ltMainMenuHud.ShowGameModeMenuUI();
	}

	public void OnTutorialButtonPressed()
	{
		if (SaveSystem.instance.ExistsSavedGame())
		{
			string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_NewGameMenu", "UI_NewGameMenu_modalWindow_pendingSavedGame_body", null, FallbackBehavior.UseProjectSettings);
			Action yesAction = delegate
			{
				SaveSystem.instance.DeleteSavedGame();
				OnTutorialButtonPressed();
			};
			base.Hud.ShowModalWindowTwoButtons(localizedString, "", null, yesAction, null);
		}
		else
		{
			hasPlayedTutorial = true;
			SaveSystem.instance.SaveData();
			MatchInfo.instance.CurrentMatchMode = EMatchMode.Tutorial;
			StartGame(2);
		}
	}

	public void OnLoadGameButtonPressed()
	{
		if (SaveSystem.instance.ExistsSavedGame())
		{
			SaveSystem.instance.LoadSavedGameData();
			MatchInfo.instance.CurrentLevelData = null;
			MatchInfo.instance.CurrentMatchMode = EMatchMode.Campaign;
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
		if (hasLoadedSomething && data.ContainsKey("currentDifficultyIdx"))
		{
			OnDifficultyChanged((int)data["currentDifficultyIdx"]);
			difficultySelector.SetValue(CurrentDifficultyIdx);
		}
		else
		{
			OnDifficultyChanged(1);
			difficultySelector.SetValue(1);
		}
	}
}
