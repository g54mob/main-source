using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class TrainingDrone
	{
		public DroneData DroneData;

		public int Score;

		public TrainingDrone(DroneData drone, int score)
		{
			DroneData = drone;
			Score = score;
		}
	}
}
