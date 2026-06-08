using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(12)]
	public struct CRequestWaitingForItem : IBufferElementData
	{
		public MenuPhase Phase;

		public int MemberIndex;
	}
}
