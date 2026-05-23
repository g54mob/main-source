using System.Collections.Generic;

public struct ProductionGraphIdLists
{
	public List<int> ProducedResourceIds { get; }

	public List<int> DeliveredResourceIds { get; }

	public ProductionGraphIdLists(List<int> producedResourceIds, List<int> deliveredResourceIds)
	{
		ProducedResourceIds = producedResourceIds ?? new List<int>();
		DeliveredResourceIds = deliveredResourceIds ?? new List<int>();
	}
}
