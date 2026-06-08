using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CRemovesShopBlueprint : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int Count;

		public static CRemovesShopBlueprint One => new CRemovesShopBlueprint
		{
			Count = 1
		};

		public CRemovesShopBlueprint(int c)
		{
			Count = c;
		}
	}
}
