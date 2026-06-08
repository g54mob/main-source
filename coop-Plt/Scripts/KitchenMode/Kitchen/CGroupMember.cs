using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(4)]
	public struct CGroupMember : IBufferElementData
	{
		public Entity Customer;

		public static implicit operator CGroupMember(Entity t)
		{
			return new CGroupMember
			{
				Customer = t
			};
		}

		public static implicit operator Entity(CGroupMember h)
		{
			return h.Customer;
		}
	}
}
