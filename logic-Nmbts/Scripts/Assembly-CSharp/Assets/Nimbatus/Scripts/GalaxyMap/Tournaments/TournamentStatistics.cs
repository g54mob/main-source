using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments
{
	[Serializable]
	public class TournamentStatistics
	{
		public static float CurrentMaxVelocity;

		public static float CurrentMaxAngularVelocity;

		public int NumberOfMatches { get; set; }

		public int Wins { get; set; }

		public int PartAmount { get; set; }

		public float Diameter { get; set; }

		public int TotalLostParts { get; set; }

		public float TotalMatchDuration { get; set; }

		public int TotalDestroyedParts { get; set; }

		public int TotalEnemyParts { get; set; }

		public string DroneName { get; set; }

		public float MaxVelocity { get; set; }

		public float MaxAngularVelocity { get; set; }

		public void Reset()
		{
			NumberOfMatches = 0;
			Wins = 0;
			PartAmount = 0;
			TotalLostParts = 0;
			TotalMatchDuration = 0f;
			TotalEnemyParts = 0;
			DroneName = "";
			TotalDestroyedParts = 0;
			CurrentMaxAngularVelocity = 0f;
			CurrentMaxVelocity = 0f;
			MaxAngularVelocity = 0f;
			MaxVelocity = 0f;
		}

		public void InitDrone(DroneData drone)
		{
			int partAmount = drone.NumberOfParts + 1;
			PartAmount = partAmount;
			Diameter = drone.Diameter;
			DroneName = drone.DroneName;
		}

		public void AddMatch(bool win, DroneData drone, int currentParts, int totalEnemyParts, int currentEnemyParts, float duration)
		{
			totalEnemyParts++;
			int num = (PartAmount = drone.NumberOfParts + 1);
			Diameter = drone.Diameter;
			DroneName = drone.DroneName;
			int num3 = num - currentParts;
			int num4 = totalEnemyParts - currentEnemyParts;
			NumberOfMatches++;
			if (win)
			{
				Wins++;
			}
			TotalLostParts += num3;
			TotalMatchDuration += duration;
			TotalEnemyParts += totalEnemyParts;
			TotalDestroyedParts += num4;
			MaxVelocity = CurrentMaxVelocity;
			MaxAngularVelocity = 57.29578f * CurrentMaxAngularVelocity;
		}
	}
}
