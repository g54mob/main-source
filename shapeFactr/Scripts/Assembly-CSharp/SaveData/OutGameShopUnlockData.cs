using System;

namespace SaveData
{
	[Serializable]
	public class OutGameShopUnlockData
	{
		public eOutGameShopId id;

		public bool unlock;

		public bool purchase;

		public bool enable;

		public OutGameShopUnlockData(MstOutGameShopEntities entity)
		{
		}
	}
}
