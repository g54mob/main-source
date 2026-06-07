using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class CrimeOffenseEntry
	{
		public string offenseType;

		public string suspectSteamId;

		public float locationX;

		public float locationY;

		public float locationZ;

		public long timestamp;

		public float severity;

		public bool isPunished;
	}
}
