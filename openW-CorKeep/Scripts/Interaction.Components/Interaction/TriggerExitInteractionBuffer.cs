using Unity.Entities;

namespace Interaction
{
	[InternalBufferCapacity(2)]
	public struct TriggerExitInteractionBuffer : IBufferElementData
	{
		public Entity interactorEntity;
	}
}
