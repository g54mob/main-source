using System.Collections.Generic;

namespace App.Data
{
	public class MoneyLetter
	{
		public string KeyName;

		public int ChanceScore;

		public int MinMoney;

		public int MaxMoney;

		public int MinQuest;

		public int MaxQuest;

		public int Money;

		public int used;

		public int dayMail;

		public int wasRead;

		public string ReqUnlock;

		public List<UnlockGroup> ReqUnlockGroups = new List<UnlockGroup>();

		public string ReqBlock;

		public int Info;

		public List<UnlockGroup> ReqBlockGroups = new List<UnlockGroup>();

		public void ParseReqQuests()
		{
			ReqUnlockGroups = Logic.ParseReqGroups(ReqUnlock);
		}

		public void ParseBlockQuests()
		{
			ReqBlockGroups = Logic.ParseReqGroups(ReqBlock);
		}
	}
}
