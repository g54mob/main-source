using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.GameOver
{
	public class GameOverButton : MonoBehaviour
	{
		public UILabel Label;

		public UIToggle TransferDronesToggle;

		public void Start()
		{
			if (RuntimeGlobals.GameMode == EGameMode.Creative)
			{
				Label.text = LocalizationManager.GetTranslation("MainMenu/DeleteSave");
			}
			else if (RuntimeGlobals.GameMode == EGameMode.Campaign)
			{
				Label.text = LocalizationManager.GetTranslation("MainMenu/StartNewGame");
			}
			TransferDronesToggle.gameObject.SetActive(RuntimeGlobals.GameModeSettings.HasPartUnlocking);
		}

		public void OnClick()
		{
			if (TransferDronesToggle.value)
			{
				SaveManager.ExportDronesToGlobalList();
			}
			if (RuntimeGlobals.GameMode == EGameMode.Creative)
			{
				SaveManager.ResetAndDeleteCurrentSave();
			}
			NimbatusSceneManager.LoadScene("MainMenuScene");
		}
	}
}
