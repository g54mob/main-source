using System.Collections.Generic;

namespace App.Data
{
	public class Sticker : BaseKeyData
	{
		public string ReqUnlockShow;

		public List<UnlockGroup> ReqUnlockGroups = new List<UnlockGroup>();

		public void ParseReqQuests()
		{
			ReqUnlockGroups = Logic.ParseReqGroups(ReqUnlockShow);
		}
	}
}
