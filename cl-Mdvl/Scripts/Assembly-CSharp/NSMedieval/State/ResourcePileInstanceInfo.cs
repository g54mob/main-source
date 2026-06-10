using NSMedieval.Manager;
using NSMedieval.UI.Utils;

namespace NSMedieval.State
{
	public struct ResourcePileInstanceInfo
	{
		public string LocalizedId { get; }

		public string LocalizedGroup { get; }

		public string StorageId { get; private set; }

		public ResourcePileInstanceInfo(ResourcePileInstance resourcePileInstance)
		{
			LocalizedId = ResourceUtils.GetLocalizedResourcePileName(resourcePileInstance.BlueprintId);
			LocalizedGroup = ResourceUtils.GetSortingGroup(resourcePileInstance.Blueprint);
			StorageId = ResourcePileUtils.GetStorage(resourcePileInstance);
		}

		public void SetStorageId(ResourcePileInstance resourcePileInstance)
		{
			StorageId = ResourcePileUtils.GetStorage(resourcePileInstance);
		}
	}
}
