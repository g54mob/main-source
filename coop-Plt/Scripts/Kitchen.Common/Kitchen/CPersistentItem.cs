using Unity.Entities;

namespace Kitchen
{
	public struct CPersistentItem : IComponentData
	{
		public PersistentStorageType Type;

		public int ItemID;
	}
}
