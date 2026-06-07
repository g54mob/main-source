using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class ExitTutorial : MonoBehaviour
	{
		public void OnClick()
		{
			GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.TerminateTutorial();
			NimbatusSceneManager.LoadScene("MainMenuScene");
		}
	}
}
