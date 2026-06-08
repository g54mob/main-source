using Unity.Entities;

namespace Kitchen
{
	public struct CPersistentItemStorageLocation : IComponentData
	{
		public PersistentStorageType Type;
	}
}
