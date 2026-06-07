using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public class TutorialRaceGoal : MonoBehaviour
	{
		private void Update()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
			if (GenericTutorialLogic.Instance is TutorialRaceLogic)
			{
				TutorialRaceLogic tutorialRaceLogic = (TutorialRaceLogic)GenericTutorialLogic.Instance;
				if (other.gameObject == tutorialRaceLogic.NimbatusPlayer.Drone.RootDronePart.gameObject)
				{
					tutorialRaceLogic.SetToFinished();
				}
			}
		}
	}
}
