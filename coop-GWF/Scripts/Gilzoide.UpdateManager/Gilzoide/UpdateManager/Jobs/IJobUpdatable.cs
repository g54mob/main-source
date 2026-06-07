using System;
using Gilzoide.UpdateManager.Jobs.Internal;

namespace Gilzoide.UpdateManager.Jobs
{
	public interface IJobUpdatable<TData> : IInitialJobDataProvider<TData> where TData : struct, IUpdateJob
	{
	}
	[Obsolete("Use IJobUpdatable<> and implement IBurstUpdateJob<> in job definition instead.")]
	public interface IJobUpdatable<TData, TJob> : IJobUpdatable<TData>, IInitialJobDataProvider<TData> where TData : struct, IUpdateJob where TJob : struct, IInternalUpdateJob<TData>
	{
	}
}
