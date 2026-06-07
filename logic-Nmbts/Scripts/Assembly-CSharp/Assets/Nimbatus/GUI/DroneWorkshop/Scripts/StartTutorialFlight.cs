using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class StartTutorialFlight : MonoBehaviour
	{
		public void OnClick()
		{
			NimbatusSceneManager.LoadScene(GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.TutorialScene);
		}
	}
}
