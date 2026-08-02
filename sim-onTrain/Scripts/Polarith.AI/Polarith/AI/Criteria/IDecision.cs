using System.Collections.Generic;

namespace Polarith.AI.Criteria
{
	public interface IDecision<TValue, TStructure>
	{
		IList<TValue> Values { get; }

		int Index { get; set; }

		TStructure Structure { get; set; }
	}
}
