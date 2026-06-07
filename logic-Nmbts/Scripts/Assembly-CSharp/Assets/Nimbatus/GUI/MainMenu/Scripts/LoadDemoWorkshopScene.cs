using System.Collections;
using Assets.Nimbatus.GUI.DroneSelection.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class LoadDemoWorkshopScene : MonoBehaviour
	{
		public void OnClick()
		{
			MainMenuNavigator.Instance.NavigateTowards(EMainMenuPage.Loading);
			StartCoroutine(LoadGameScene());
		}

		public IEnumerator LoadGameScene()
		{
			yield return new WaitForSeconds(0.5f);
			SaveManager.StartEmptyGame(EGameMode.Demo);
			float startTime = Time.time;
			while (!SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DronesLoaded && Time.time - startTime < 10f)
			{
				yield return true;
			}
			DroneSelectionManager.HideLaunchButton = true;
			DroneSelectionManager.HideBackButton = false;
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDroneIndex = 0;
			NimbatusSceneManager.SetReturnScene("DroneHangarScene", SceneManager.GetActiveScene().name);
			NimbatusSceneManager.LoadScene("DroneHangarScene");
		}
	}
}
