using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CModifyBlueprintStoreAfterDuration : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool PerformUpgrade;

		public bool PerformCopy;

		public bool MakeFree;
	}
}
