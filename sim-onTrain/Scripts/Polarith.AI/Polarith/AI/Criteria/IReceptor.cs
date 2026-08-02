using System.Collections.Generic;

namespace Polarith.AI.Criteria
{
	public interface IReceptor<T>
	{
		IList<int> NeighbourIDs { get; }

		int ID { get; set; }

		T Structure { get; set; }
	}
}
