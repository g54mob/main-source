using System.Collections.Generic;

namespace App.Data
{
	public class Checkpoint
	{
		public string KeyName;

		public int StartMoney;

		public string ReqUnlock;

		public string UnlockTasks;

		public string ScrollToTask;

		public List<string> UnlockTasksList = new List<string>();

		public List<UnlockGroup> ReqUnlockGroups = new List<UnlockGroup>();

		public void ParseReqQuests()
		{
			ReqUnlockGroups = Logic.ParseReqGroups(ReqUnlock);
		}

		public void ParseUnlockTasks()
		{
			UnlockTasksList = new List<string>();
			string[] array = UnlockTasks.Split(',');
			foreach (string text in array)
			{
				if (text != "")
				{
					UnlockTasksList.Add(text);
				}
			}
		}
	}
}
