using System;
using System.Collections;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles
{
	public class LoadSaveButton : MonoBehaviour
	{
		public ErrorPopup Popup;

		private SavefileListUI _parent;

		public UILabel Label;

		public void Init(SavefileListUI parent)
		{
			_parent = parent;
			if (_parent.SelectedSaveFile != null)
			{
				if (SaveManager.IsCompatible(_parent.SelectedSaveFile.Save.SaveGameVersion))
				{
					Label.text = LocalizationManager.GetTermTranslation("MainMenu/LoadSave");
				}
				else
				{
					Label.text = LocalizationManager.GetTermTranslation("MainMenu/NotCompatibleSave");
				}
			}
		}

		public void OnClick()
		{
			if (_parent.SelectedSaveFile != null && SaveManager.IsCompatible(_parent.SelectedSaveFile.Save.SaveGameVersion))
			{
				StartCoroutine(LoadGame());
			}
		}

		private IEnumerator LoadGame()
		{
			MainMenuNavigator.Instance.NavigateTowards(EMainMenuPage.Loading, 0.01f);
			yield return new WaitForSeconds(1f);
			SaveData save = _parent.SelectedSaveFile.Save;
			try
			{
				SaveManager.LoadSaveGame(save);
				if (save.Mode == EGameMode.Campaign && string.IsNullOrEmpty(save.Settings.DronePerkId))
				{
					NimbatusSceneManager.LoadScene("CampaignIntroScene");
				}
				else
				{
					NimbatusSceneManager.LoadScene("MissionControlScene");
				}
			}
			catch (Exception ex)
			{
				MainMenuNavigator.Instance.NavigateTowards(EMainMenuPage.CreateGame, 0.01f);
				Popup.Show(ex.ToString(), OnClick);
			}
		}
	}
}
