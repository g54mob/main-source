using System.Collections.Generic;

namespace Factory.Pools
{
	public interface IPoolInspectable
	{
		int AllocatedObjectCount { get; }

		void GetAllElements(List<object> allocated, List<object> free);

		void InspectEntryGrouping(object entryInstance, Dictionary<object, bool> expandedLookup);

		void InspectEntry(object entryInstance);
	}
}
