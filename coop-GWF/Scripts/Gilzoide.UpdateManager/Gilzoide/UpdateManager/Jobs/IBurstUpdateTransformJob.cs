using Gilzoide.UpdateManager.Jobs.Internal;

namespace Gilzoide.UpdateManager.Jobs
{
	public interface IBurstUpdateTransformJob<TBurstJob> : IUpdateTransformJob where TBurstJob : IInternalBurstUpdateTransformJob
	{
	}
}
