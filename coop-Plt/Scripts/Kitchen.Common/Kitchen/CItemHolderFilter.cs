using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CItemHolderFilter : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public ItemCategory Category;

		public bool AllowAny;

		public bool NoDirectInsertion;

		public bool AllowCategory(ItemCategory item)
		{
			if (AllowAny)
			{
				return true;
			}
			if (Category == ItemCategory.Generic && item == ItemCategory.Generic)
			{
				return true;
			}
			return (item & Category) != 0;
		}
	}
}
