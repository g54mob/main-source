using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CGrantsExtraBlueprint : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public int ID;

		public bool IsFree;

		public bool CanBeDuplicated;
	}
}
