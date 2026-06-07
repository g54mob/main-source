using System.Collections.Generic;

namespace App.Data
{
	public class Credit
	{
		public string KeyName;

		public int Money;

		public int MoneyBack;

		public float MoneyQuest;

		public float MoneyBackQuest;

		public float MoneyStartup;

		public float MoneyBackStartup;

		public int DaysBack;

		public int DaysBackStartup;

		public int DaysBackQuest;

		public int MinDepth;

		public int MaxDepth;

		public int MinTask;

		public int MaxTask;

		public string ReqUnlock;

		public int CurDepth;

		public List<UnlockGroup> ReqUnlockGroups = new List<UnlockGroup>();

		public void ParseReqQuests()
		{
			ReqUnlockGroups = Logic.ParseReqGroups(ReqUnlock);
		}

		public Credit()
		{
		}

		public Credit(Credit c, int moneyForCredit = 0, bool isTaskQuest = true)
		{
			KeyName = c.KeyName;
			if (isTaskQuest)
			{
				Money = (int)((float)moneyForCredit * c.MoneyQuest);
				MoneyBack = (int)((float)moneyForCredit * c.MoneyBackQuest);
				DaysBack = c.DaysBackQuest;
			}
			else
			{
				Money = (int)((float)moneyForCredit * c.MoneyStartup);
				MoneyBack = (int)((float)moneyForCredit * c.MoneyBackStartup);
				DaysBack = c.DaysBackStartup;
			}
			MinDepth = c.MinDepth;
			MaxDepth = c.MaxDepth;
			CurDepth = c.CurDepth;
		}
	}
}
