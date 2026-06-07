using System.Collections.Generic;

namespace App.Data
{
	public class Epoch : BaseKeyData
	{
		public string ReqUnlockShow;

		public string End;

		public string Comics;

		public List<UnlockGroup> ReqUnlockGroups = new List<UnlockGroup>();

		public int MaxTasks;

		public void ParseReqQuests()
		{
			ReqUnlockGroups = Logic.ParseReqGroups(ReqUnlockShow);
		}
	}
}
