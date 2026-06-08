using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(8)]
	public struct CTableSetParts : IBufferElementData
	{
		public Entity Entity;

		public static implicit operator Entity(CTableSetParts x)
		{
			return x.Entity;
		}

		public static implicit operator CTableSetParts(Entity x)
		{
			return new CTableSetParts
			{
				Entity = x
			};
		}
	}
}
