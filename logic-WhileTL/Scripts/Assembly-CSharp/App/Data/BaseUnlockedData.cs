using System.Collections.Generic;

namespace App.Data
{
	public abstract class BaseUnlockedData : BaseKeyData
	{
		public string ReqUnlock;

		public int Locked;

		public List<UnlockGroup> ReqUnlockGroups = new List<UnlockGroup>();

		public bool VisibleToPlayer;

		public void ParseReqQuests()
		{
			ReqUnlockGroups = Logic.ParseReqGroups(ReqUnlock);
		}
	}
}
