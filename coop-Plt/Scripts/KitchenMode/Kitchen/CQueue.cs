using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(4)]
	public struct CQueue : IBufferElementData
	{
		public Entity Member;
	}
}
