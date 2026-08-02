using System.Collections.ObjectModel;

namespace Polarith.AI.Criteria
{
	public interface ISolver<T>
	{
		ReadOnlyCollection<int> Solve(IProblem<T> problem);
	}
}
