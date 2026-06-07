using System;

namespace SaveData
{
	[Serializable]
	public class ResearchArchive : ArchiveData
	{
		public ResearchArchive(bool everGet = true, bool isRead = false, bool isPermanent = true)
			: base(everGet: false, isRead: false, isPermanent: false)
		{
		}
	}
}
