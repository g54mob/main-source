using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(4)]
	public struct CAttachments : IBufferElementData
	{
		public Entity Entity;

		public static implicit operator Entity(CAttachments a)
		{
			return a.Entity;
		}

		public static implicit operator CAttachments(Entity a)
		{
			return new CAttachments
			{
				Entity = a
			};
		}
	}
}
