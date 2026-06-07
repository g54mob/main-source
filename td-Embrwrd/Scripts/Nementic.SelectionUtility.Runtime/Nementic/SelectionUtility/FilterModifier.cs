using System.Collections.Generic;

namespace Nementic.SelectionUtility
{
	public delegate IEnumerable<DataFilter> FilterModifier(List<DataFilter> defaultFilters);
}
