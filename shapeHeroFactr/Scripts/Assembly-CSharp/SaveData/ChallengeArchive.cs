using System;

namespace SaveData
{
	[Serializable]
	public class ChallengeArchive : ArchiveData
	{
		public ChallengeArchive(bool everGet = true, bool isRead = false, bool isPermanent = true)
			: base(everGet: false, isRead: false, isPermanent: false)
		{
		}
	}
}
