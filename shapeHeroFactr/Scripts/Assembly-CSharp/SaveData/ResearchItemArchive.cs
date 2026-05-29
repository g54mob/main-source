using System;

namespace SaveData
{
	[Serializable]
	public class ResearchItemArchive : ArchiveData
	{
		public ResearchItemArchive(bool everGet = true, bool isRead = false, bool isPermanent = true)
			: base(everGet: false, isRead: false, isPermanent: false)
		{
		}
	}
}
