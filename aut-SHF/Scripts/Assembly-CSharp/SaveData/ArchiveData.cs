using System;

namespace SaveData
{
	[Serializable]
	public abstract class ArchiveData
	{
		public bool everGet;

		public bool isRead;

		public bool unlockPermanent;

		public bool IsCollectionOk => false;

		public ArchiveData(bool everGet = true, bool isRead = false, bool isPermanent = true)
		{
		}

		public void UpdateArchive(bool? everGet = null, bool? isRead = null, bool? isPermanent = null)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
