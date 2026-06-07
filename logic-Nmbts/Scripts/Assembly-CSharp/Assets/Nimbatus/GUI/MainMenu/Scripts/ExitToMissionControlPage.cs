using System.Collections;
using Assets.Nimbatus.GUI.MissionControl.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class ExitToMissionControlPage : MonoBehaviour
	{
		public EMissionControlPage PageToLoad;

		public EMissionControlPage PageToLoadDemo;

		public void OnClick()
		{
			StartCoroutine(Exit());
		}

		private IEnumerator Exit()
		{
			NimbatusSceneManager.LoadingProgress = 0;
			RuntimeGlobals.IsGameLoading = true;
			RuntimeGlobals.FreezeGame = false;
			RuntimeGlobals.FreezeEnemies = false;
			RuntimeGlobals.IsMovementBlocked = false;
			RuntimeGlobals.TimeScale = 1f;
			RuntimeGlobals.IsGamePaused = false;
			yield return true;
			if (RuntimeGlobals.DemoMode)
			{
				MissionControlNavigator.PageToLoad = PageToLoadDemo;
			}
			else
			{
				MissionControlNavigator.PageToLoad = PageToLoad;
			}
			NimbatusSceneManager.LoadScene("MissionControlScene");
		}
	}
}
