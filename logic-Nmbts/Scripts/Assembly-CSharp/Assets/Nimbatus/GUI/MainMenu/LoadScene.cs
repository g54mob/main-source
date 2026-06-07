using Assets.Nimbatus.GUI.MainMenu.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu
{
	public class LoadScene : MonoBehaviour
	{
		public string SceneName;

		public void OnClick()
		{
			if (DragAndDropHelper.DraggedItem != null)
			{
				return;
			}
			if (RuntimeGlobals.RunningMode == ERunningMode.Menu)
			{
				MainMenuNavigator mainMenuNavigator = Object.FindObjectOfType<MainMenuNavigator>();
				if (mainMenuNavigator != null)
				{
					mainMenuNavigator.NavigateTowards(EMainMenuPage.None);
					Invoke("OnTweenFinished", 0.5f);
				}
				else
				{
					OnTweenFinished();
				}
			}
			else
			{
				OnTweenFinished();
			}
		}

		public void OnTweenFinished()
		{
			NimbatusSceneManager.LoadScene(SceneName);
		}
	}
}
