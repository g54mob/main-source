using System;

namespace Data.Save
{
	[Serializable]
	public class PlayerGameData
	{
		public bool TutorialDone;

		public bool IntroScreenShown;

		public float EnemyLoyalty;

		public float LoyaltyIncrement;

		public int WorldSeed;
	}
}
