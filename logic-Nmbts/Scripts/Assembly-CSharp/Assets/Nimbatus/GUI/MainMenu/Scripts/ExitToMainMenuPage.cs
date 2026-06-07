using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class ExitToMainMenuPage : MonoBehaviour
	{
		public TweenPosition CheckTween;

		public EMainMenuPage PageToLoad;

		public KeyCode Keybinding;

		public void OnClick()
		{
			RuntimeGlobals.IsGameOver = false;
			RuntimeGlobals.IsGamePaused = false;
			SaveManager.StoreSaveGame(false, true);
			MainMenuNavigator.PageToLoad = PageToLoad;
			NimbatusSceneManager.LoadScene("MainMenuScene");
		}

		public void Update()
		{
			if (Keybinding != KeyCode.None && Input.GetKeyDown(KeyCode.Escape) && CheckTween != null && (CheckTween.value - CheckTween.to).magnitude < 0.1f)
			{
				OnClick();
			}
		}
	}
}
