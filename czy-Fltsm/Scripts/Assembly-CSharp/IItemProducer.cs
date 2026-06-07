using System.Collections.Generic;

public interface IItemProducer
{
	Buildable Buildable { get; }

	List<ItemProperties> ProducedItems { get; }

	ResourceProvider ExportResourceProvider { get; }

	int GetItemsInProductionCount(ItemProperties itemProperties);
}
