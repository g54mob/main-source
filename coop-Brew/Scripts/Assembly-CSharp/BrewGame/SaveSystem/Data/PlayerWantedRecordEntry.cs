using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class PlayerWantedRecordEntry
	{
		public string steamId;

		public int wantedStatus;

		public int wantedLevel;

		public long expirationTimestamp;

		public float lastOffenseLocationX;

		public float lastOffenseLocationY;

		public float lastOffenseLocationZ;

		public long lastOffenseTimestamp;
	}
}
