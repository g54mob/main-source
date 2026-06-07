using System;

namespace SaveData
{
	[Serializable]
	public class EnemyArchive : ArchiveData
	{
		public bool isEliminated;

		public EnemyArchive(bool everGet = true, bool isRead = false, bool isPermanent = true, bool isEliminated = false)
			: base(everGet: false, isRead: false, isPermanent: false)
		{
		}
	}
}
