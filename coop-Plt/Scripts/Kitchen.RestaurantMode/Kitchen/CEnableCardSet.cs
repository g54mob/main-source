using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CEnableCardSet : IComponentData
	{
		public UnlockGroup Group;

		public CardType Type;
	}
}
