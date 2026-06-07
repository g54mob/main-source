using Gilzoide.UpdateManager.Jobs.Internal;

namespace Gilzoide.UpdateManager.Jobs
{
	public interface IBurstUpdateJob<TBurstJob> : IUpdateJob where TBurstJob : IInternalBurstUpdateJob
	{
	}
}
