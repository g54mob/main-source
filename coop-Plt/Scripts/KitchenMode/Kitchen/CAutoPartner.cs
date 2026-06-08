using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CAutoPartner : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public PartnerType Type;

		public Entity Target;

		public int GroupID;
	}
}
