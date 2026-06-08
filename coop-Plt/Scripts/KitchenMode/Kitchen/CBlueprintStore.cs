using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CBlueprintStore : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool InUse;

		public int ApplianceID;

		public int Price;

		public int BlueprintID;

		public bool HasBeenUpgraded;

		public bool HasBeenCopied;

		public bool HasBeenMadeFree;
	}
}
