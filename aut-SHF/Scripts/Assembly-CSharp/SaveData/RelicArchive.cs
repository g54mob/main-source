using System;

namespace SaveData
{
	[Serializable]
	public class RelicArchive : ArchiveData
	{
		public RelicArchive(bool everGet = true, bool isRead = false, bool isPermanent = true)
			: base(everGet: false, isRead: false, isPermanent: false)
		{
		}
	}
}
