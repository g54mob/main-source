using Unity.Entities;

namespace Interaction
{
	[InternalBufferCapacity(2)]
	public struct TriggerUseInteractionBuffer : IBufferElementData
	{
		public Entity interactorEntity;
	}
}
