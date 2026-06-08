using System.Collections.Generic;
using Dorfromantik;
using Dorfromantik.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInitializer : MonoBehaviour
{
	[SerializeField]
	private RewardLibrary rewardLibrary;

	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private UiScalingManager uiScalingManager;

	[SerializeField]
	private SaveFileManager saveFileManager;

	[SerializeField]
	private SaveGameLoadingInitiator saveGameLoadingInitiator;

	[SerializeField]
	private BuildInfo buildInfo;

	[SerializeField]
	private CustomModePresetManager presetManager;

	[SerializeField]
	private List<GameMode> gameModes;

	[SerializeField]
	private GameMode tutorialMode;

	private List<Scene> currentlyLoadedScenes;

	[SerializeField]
	private bool debug_skipLoadingScene;

	private Dictionary<GameModeId, GameMode> gameModeById = new Dictionary<GameModeId, GameMode>();

	private void Awake()
	{
		SuccessStatus successStatus = rewardLibrary.Setup();
		SuccessStatus successStatus2 = sessionQuestManager.Setup();
		foreach (GameMode gameMode2 in gameModes)
		{
			gameModeById.Add(gameMode2.id, gameMode2);
		}
		Debug.Log($"rewardsLoaded? {successStatus} - challengesLoaded? {successStatus2}");
		SetupRewardsOrSessionQuestsFromEachOther(successStatus, successStatus2);
		settingsRouter.SetupAwake();
		saveFileManager.Setup();
		if (buildInfo.usedPlugin != PluginType.None)
		{
			sceneLoader.LoadSceneAsync(buildInfo.pluginBuildIndex, LoadSceneMode.Additive);
		}
		if (OverwritingSingleton<IngameUi>.Instance == null && !debug_skipLoadingScene)
		{
			if (PlayerPrefsAccessor.GetInt("TutorialPlayed", 0) == 0)
			{
				Debug.Log("Tutorial not yet played -> load tutorial");
				sceneLoader.LoadSceneAsync(tutorialMode.sceneName, LoadSceneMode.Additive);
			}
			else
			{
				GameMode gameMode = gameModeById[(GameModeId)PlayerPrefsAccessor.GetInt("LastPlayedGameMode", 0)];
				Debug.Log($"last played mode: {gameMode} -> load");
				sceneLoader.LoadSceneAsync(gameMode.sceneName, LoadSceneMode.Additive);
			}
		}
		uiScalingManager.Initialize();
	}

	private void SetupRewardsOrSessionQuestsFromEachOther(SuccessStatus rewardsLoaded, SuccessStatus challengesLoaded)
	{
		sessionQuestManager.SetupFromLoadedRewards(rewardLibrary.allRewards);
		rewardLibrary.SetupFromLoadedChallenges(sessionQuestManager.sessionQuests);
	}

	private void Start()
	{
		settingsRouter.SetupStart();
	}
}
