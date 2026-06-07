using System.Collections;
using System.Collections.Generic;

namespace Mystery.Graphing
{
	public interface ILineGraph : IPlottableGraph, IEnumerable<ILineGraphPoint>, IEnumerable, ICollection
	{
	}
}
