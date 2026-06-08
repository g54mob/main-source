using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(4)]
	public struct CItemStored : IBufferElementData
	{
		public Entity StoredItem;

		public static implicit operator CItemStored(Entity e)
		{
			return new CItemStored
			{
				StoredItem = e
			};
		}

		public static implicit operator Entity(CItemStored h)
		{
			return h.StoredItem;
		}
	}
}
