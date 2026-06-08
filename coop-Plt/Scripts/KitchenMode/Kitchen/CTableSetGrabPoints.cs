using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(8)]
	public struct CTableSetGrabPoints : IBufferElementData
	{
		public Entity Entity;

		public static implicit operator Entity(CTableSetGrabPoints x)
		{
			return x.Entity;
		}

		public static implicit operator CTableSetGrabPoints(Entity x)
		{
			return new CTableSetGrabPoints
			{
				Entity = x
			};
		}
	}
}
