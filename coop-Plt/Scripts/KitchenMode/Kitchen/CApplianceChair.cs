using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CApplianceChair : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool IsInUse;

		public Entity Occupant;
	}
}
