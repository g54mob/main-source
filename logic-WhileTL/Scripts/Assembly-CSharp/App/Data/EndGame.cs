using System.Collections.Generic;

namespace App.Data
{
	public class EndGame
	{
		public string Title;

		public int MinTier;

		public int MaxTier;

		public string QuestComplete;

		public string QuestFailed;

		public string StartupNameWasCreated;

		public string Text;

		public int MinMoney;

		public int MaxMoney;

		public string ReqUnlock;

		public List<UnlockGroup> ReqUnlockGroups = new List<UnlockGroup>();

		public void ParseReqQuests()
		{
			ReqUnlockGroups = Logic.ParseReqGroups(ReqUnlock);
		}
	}
}
