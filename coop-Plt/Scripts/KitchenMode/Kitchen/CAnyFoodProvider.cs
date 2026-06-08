using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CAnyFoodProvider : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public float CooldownSeconds;
	}
}
