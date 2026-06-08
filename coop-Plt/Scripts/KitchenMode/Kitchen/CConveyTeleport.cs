using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CConveyTeleport : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public Entity Target;

		public bool HasReceivedTeleport;

		public float CurrentCooldown;

		public float SendCooldown;

		public int GroupID;
	}
}
