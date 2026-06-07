using System.Collections.Generic;

namespace Ludiq
{
	public interface IGraphDebugData
	{
		IEnumerable<IGraphElementDebugData> elementsData { get; }

		IGraphElementDebugData GetOrCreateElementData(IGraphElementWithDebugData element);

		IGraphDebugData GetOrCreateChildGraphData(IGraphParentElement element);
	}
}
