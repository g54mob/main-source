using System.Collections.Generic;

public interface IItemContainer
{
	int ItemCount { get; }

	int UniqueItemCount { get; }

	int CurrentItemCount { get; }

	int TotalCapacity { get; }

	bool SupportsCapacity { get; }

	Dictionary<string, int> GetStoredItemCounts();
}
