using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race.Versus
{
	public class RaceVersusGoal : MonoBehaviour
	{
		public void OnTriggerEnter(Collider other)
		{
			if (!(BaseRaceManager.Instance != null))
			{
				return;
			}
			RaceVersusManager raceVersusManager = BaseRaceManager.Instance as RaceVersusManager;
			if (raceVersusManager != null)
			{
				if (other.gameObject == raceVersusManager.LeftDrone.RootDronePart.gameObject)
				{
					BaseRaceManager.Instance.FinishRace(raceVersusManager.LeftDrone);
				}
				else if (other.gameObject == raceVersusManager.RightDrone.RootDronePart.gameObject)
				{
					BaseRaceManager.Instance.FinishRace(raceVersusManager.RightDrone);
				}
			}
		}
	}
}
