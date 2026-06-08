using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Utility
{
	public interface ITaskDependency
	{
		Task<bool> EnsureCompletion(bool force_rerun, CancellationToken token);
	}
}
