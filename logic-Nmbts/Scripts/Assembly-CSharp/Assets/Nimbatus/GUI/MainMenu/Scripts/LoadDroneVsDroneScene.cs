using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class LoadDroneVsDroneScene : MonoBehaviour
	{
		public void OnClick()
		{
			MainMenuNavigator.Instance.NavigateTowards(EMainMenuPage.Loading);
			Invoke("LoadGameScene", 0.5f);
		}

		public void LoadGameScene()
		{
			SaveManager.StartEmptyGame(EGameMode.Competitive);
			NimbatusSceneManager.LoadScene("CompetitiveModeScene");
		}
	}
}
