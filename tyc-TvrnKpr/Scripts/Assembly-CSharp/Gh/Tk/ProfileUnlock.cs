using System;

namespace Gh.Tk
{
	[Serializable]
	public class ProfileUnlock
	{
		public string key;

		public UnlockType unlockType;

		public DateTime unlockedTimeStamp;

		protected ProfileUnlock()
		{
		}

		public ProfileUnlock(string key, UnlockType unlockType)
		{
		}
	}
}
