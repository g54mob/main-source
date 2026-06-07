using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles
{
	public class StartGameUI : MonoBehaviour
	{
		public StartGameButton StartButton;

		public ToggleModeButton SurvivalButton;

		public ToggleModeButton SandboxButton;

		public ToggleGameModeDifficulty EasyButton;

		public ToggleGameModeDifficulty NormalButton;

		public ToggleGameModeDifficulty HardButton;

		public UIToggle ViewTutorial;

		public UIInput NameInput;

		public UILabel DescriptionLabel;

		public UILabel DifficultyLabel;

		public GameObject CreativeModeParent;

		public GameObject SurvivalModeParent;

		public SaveFileGameSettingsPanel SettingsPanel;

		[HideInInspector]
		public EGameMode SelectedGameMode;

		[HideInInspector]
		public EGameModeDifficulty SelectedDifficulty;

		[HideInInspector]
		public GameModeSettings Settings;

		public void Init()
		{
			SaveManager.Reset();
			Settings = new GameModeSettings();
			SelectedDifficulty = EGameModeDifficulty.Normal;
			SetGameMode(EGameMode.Campaign);
			ViewTutorial.value = !RuntimeGlobals.Settings.SkipCampaignTutorial;
			SettingsPanel.gameObject.SetActive(false);
			StartButton.Init(this);
			SurvivalButton.Init(this);
			SandboxButton.Init(this);
			EasyButton.Init(this);
			NormalButton.Init(this);
			HardButton.Init(this);
			NameInput.defaultText = LocalizationManager.GetTermTranslation("MainMenu/DefaultSaveName");
		}

		public void Update()
		{
			NameInput.defaultText = LocalizationManager.GetTermTranslation("MainMenu/DefaultSaveName");
		}

		public void ShowSettings()
		{
			SettingsPanel.gameObject.SetActive(true);
			SettingsPanel.Init(SelectedGameMode, Settings);
		}

		public void SetGameMode(EGameMode mode)
		{
			SelectedGameMode = mode;
			switch (mode)
			{
			case EGameMode.Campaign:
				CreativeModeParent.SetActive(false);
				SurvivalModeParent.SetActive(true);
				Settings.Init(SelectedGameMode, SelectedDifficulty);
				DescriptionLabel.text = LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("MainMenu/SurvivalDescription");
				DifficultyLabel.text = GameModeSettings.GetDifficultyDetails(SelectedDifficulty);
				break;
			case EGameMode.Creative:
				CreativeModeParent.SetActive(true);
				SurvivalModeParent.SetActive(false);
				Settings.Init(SelectedGameMode, EGameModeDifficulty.Normal);
				DescriptionLabel.text = LabelHelper.LightGrey + LocalizationManager.GetTermTranslation("MainMenu/SandboxDescription");
				DifficultyLabel.text = "";
				break;
			}
		}

		public void SetDifficulty(EGameModeDifficulty difficulty)
		{
			SelectedDifficulty = difficulty;
			SetGameMode(SelectedGameMode);
			Settings.Init(SelectedGameMode, SelectedDifficulty);
		}
	}
}
