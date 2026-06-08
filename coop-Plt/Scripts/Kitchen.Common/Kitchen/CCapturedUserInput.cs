using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(4)]
	public struct CCapturedUserInput : IBufferElementData
	{
		public Entity User;
	}
}
