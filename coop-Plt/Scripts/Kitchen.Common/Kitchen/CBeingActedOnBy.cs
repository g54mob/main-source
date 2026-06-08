using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(4)]
	public struct CBeingActedOnBy : IBufferElementData
	{
		public Entity Interactor;

		public bool IsTransferOnly;
	}
}
