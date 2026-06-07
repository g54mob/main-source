using System;

namespace Assets.Nimbatus.Scripts.Leaderboards
{
	[Serializable]
	public class LeaderBoardEntry
	{
		public int Score;

		public string UserName;

		public ulong UserId;

		public byte[] Attachement;

		public int[] ScoreDetails;

		public int Rank;
	}
}
