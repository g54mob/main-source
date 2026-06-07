using System.Collections;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles
{
	public class StartGameButton : MonoBehaviour
	{
		private StartGameUI _parent;

		public void Init(StartGameUI parent)
		{
			_parent = parent;
		}

		public void OnClick()
		{
			StartCoroutine(LoadGame());
		}

		private IEnumerator LoadGame()
		{
			MainMenuNavigator.Instance.NavigateTowards(EMainMenuPage.Loading, 0.01f);
			yield return new WaitForSeconds(1f);
			string text = _parent.NameInput.value;
			if (string.IsNullOrEmpty(text))
			{
				text = _parent.NameInput.defaultText;
			}
			SaveData saveData = SaveManager.CreateNewSaveGame(text, _parent.SelectedGameMode, _parent.SelectedDifficulty);
			saveData.Settings = _parent.Settings;
			switch (_parent.SelectedGameMode)
			{
			case EGameMode.Campaign:
				saveData.Settings.ViewCampaignTutorial = _parent.ViewTutorial.value;
				if (_parent.ViewTutorial.value)
				{
					RuntimeGlobals.Settings.SkipCampaignTutorial = true;
				}
				SaveManager.SelectedSave = saveData;
				NimbatusSceneManager.LoadScene("CampaignIntroScene");
				break;
			case EGameMode.Creative:
				SaveManager.LoadSaveGame(saveData);
				NimbatusSceneManager.LoadScene("MissionControlScene");
				break;
			}
		}
	}
}
