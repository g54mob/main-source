using System;

namespace SaveData
{
	[Serializable]
	public class MasterArchive : ArchiveData
	{
		public MasterArchive(bool everGet = true, bool isRead = false, bool isPermanent = true)
			: base(everGet: false, isRead: false, isPermanent: false)
		{
		}
	}
}
