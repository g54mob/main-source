using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CProgressionUnlock : IComponentData
	{
		public int ID;

		public bool FromFranchise;

		public CardType Type;

		public bool IsActive
		{
			get
			{
				if (!FromFranchise)
				{
					return Type != CardType.FranchiseTier;
				}
				return true;
			}
		}
	}
}
