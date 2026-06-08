using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(8)]
	public struct CAvailableFranchises : IBufferElementData
	{
		public Entity Franchise;
	}
}
