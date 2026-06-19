using Unity.Entities;

namespace PugEntitiesUtil
{
	[InternalBufferCapacity(1)]
	public struct CompanionInstantiatedEntityBuffer : ICleanupBufferElementData, IBufferElementData
	{
		public Entity Value;
	}
}
