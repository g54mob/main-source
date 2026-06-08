using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CLetterBlueprint : IComponentData
	{
		public int BlueprintID;

		public int ApplianceID;

		public int Price;

		public ShoppingTags OriginalTags;
	}
}
