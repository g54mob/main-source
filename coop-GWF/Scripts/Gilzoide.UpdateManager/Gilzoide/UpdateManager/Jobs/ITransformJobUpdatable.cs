using System;
using Gilzoide.UpdateManager.Jobs.Internal;

namespace Gilzoide.UpdateManager.Jobs
{
	public interface ITransformJobUpdatable<TData> : IInitialTransformJobDataProvider<TData>, IInitialJobDataProvider<TData> where TData : struct, IUpdateTransformJob
	{
	}
	[Obsolete("Use ITransformJobUpdatable<> and implement IBurstUpdateTransformJob<> in job definition instead.")]
	public interface ITransformJobUpdatable<TData, TJob> : ITransformJobUpdatable<TData>, IInitialTransformJobDataProvider<TData>, IInitialJobDataProvider<TData> where TData : struct, IUpdateTransformJob where TJob : struct, IInternalUpdateTransformJob<TData>
	{
	}
}
