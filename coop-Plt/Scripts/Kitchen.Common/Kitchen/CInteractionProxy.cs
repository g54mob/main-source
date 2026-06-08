using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CInteractionProxy : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public Entity Target;

		public bool IsActive;
	}
}
