using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CApplianceDrinkDispenser : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public DrinkType DrinkType;

		public bool IsVisible;
	}
}
