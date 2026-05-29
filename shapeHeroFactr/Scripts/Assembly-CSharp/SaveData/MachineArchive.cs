using System;

namespace SaveData
{
	[Serializable]
	public class MachineArchive : ArchiveData
	{
		public MachineArchive(bool everGet = true, bool isRead = false, bool isPermanent = true)
			: base(everGet: false, isRead: false, isPermanent: false)
		{
		}
	}
}
