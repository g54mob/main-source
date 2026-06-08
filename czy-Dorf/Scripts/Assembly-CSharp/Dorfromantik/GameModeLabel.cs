using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dorfromantik
{
	public class GameModeLabel : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI gameModeLabel;

		[SerializeField]
		private TextMeshProUGUI configStringLabel;

		[SerializeField]
		private GameObject highscoreContainer;

		[SerializeField]
		private GameObject leaderboardContainer;

		[SerializeField]
		private GameObject configStringContainer;

		[SerializeField]
		private List<GameMode> gameModes;

		[SerializeField]
		private SceneLoader sceneLoader;

		[SerializeField]
		private CustomModeConfiguration customModeConfiguration;

		[SerializeField]
		private SettingsRouter settingsRouter;

		private Dictionary<GameModeId, GameMode> gameModeById = new Dictionary<GameModeId, GameMode>();

		private void Awake()
		{
			foreach (GameMode gameMode in gameModes)
			{
				gameModeById.Add(gameMode.id, gameMode);
			}
			LocalizationManager.Instance.OnLanguageChanged += UpdateUiFromLanguageChanged;
			customModeConfiguration.OnUpdated += UpdateUi;
		}

		private void Start()
		{
			sceneLoader.OnSceneLoaded += UpdateUiFromSceneLoaded;
			if ((bool)OverwritingSingleton<IngameUi>.Instance)
			{
				UpdateUi();
			}
		}

		private void UpdateUiFromLanguageChanged()
		{
			UpdateUi();
		}

		private void UpdateUiFromSceneLoaded(Scene obj)
		{
			UpdateUi();
		}

		private void UpdateUi()
		{
			GameMode gameMode = (OverwritingSingleton<GameSession>.Instance ? OverwritingSingleton<GameSession>.Instance.GameMode : gameModeById[(GameModeId)PlayerPrefsAccessor.GetInt("LastPlayedGameMode", 0)]);
			highscoreContainer.SetActive(gameMode.hasLeaderboard);
			leaderboardContainer.SetActive(gameMode.hasLeaderboard && settingsRouter.defaultSettings.leaderboardsEnabled);
			configStringContainer.SetActive(gameMode.usesCustomConfiguration && gameMode.showsConfigString);
			string text = LocalizationManager.Instance.GetLocalizedValue(gameMode.localizationKey, useFallbackText: true);
			if (gameMode.configType == CustomConfigType.Monthly)
			{
				text += $" | {customModeConfiguration.year:0000}/{customModeConfiguration.month:00}";
			}
			if (gameMode.configType == CustomConfigType.Custom)
			{
				configStringLabel.text = customModeConfiguration.GetDisplayConfigString();
			}
			if ((bool)OverwritingSingleton<GameSession>.Instance)
			{
				text += OverwritingSingleton<GameSession>.Instance.GameMode.gameModeIconRichTextSuffix;
			}
			gameModeLabel.text = text;
		}

		private void OnDestroy()
		{
			if ((bool)LocalizationManager.Instance)
			{
				LocalizationManager.Instance.OnLanguageChanged -= UpdateUiFromLanguageChanged;
			}
			sceneLoader.OnSceneLoaded -= UpdateUiFromSceneLoaded;
			customModeConfiguration.OnUpdated -= UpdateUi;
		}
	}
}
