using System;

namespace SaveData
{
	[Serializable]
	public class FeatureArchive : ArchiveData
	{
		public FeatureArchive(bool everGet = true, bool isRead = false, bool isPermanent = true)
			: base(everGet: false, isRead: false, isPermanent: false)
		{
		}
	}
}
