using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(16)]
	public struct CEndgameUnlock : IBufferElementData
	{
		public int UnlockID;

		public bool FromFranchise;

		public CardType Type;
	}
}
