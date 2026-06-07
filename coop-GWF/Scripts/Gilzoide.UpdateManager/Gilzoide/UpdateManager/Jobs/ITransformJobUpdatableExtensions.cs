namespace Gilzoide.UpdateManager.Jobs
{
	public static class ITransformJobUpdatableExtensions
	{
		public static void RegisterInManager<TData>(this ITransformJobUpdatable<TData> updatable) where TData : struct, IUpdateTransformJob
		{
			UpdateTransformJobManager<TData>.Instance.Register(updatable);
		}

		public static void RegisterInManager<TData>(this ITransformJobUpdatable<TData> updatable, bool syncEveryFrame) where TData : struct, IUpdateTransformJob
		{
			UpdateTransformJobManager<TData>.Instance.Register(updatable, syncEveryFrame);
		}

		public static void UnregisterInManager<TData>(this ITransformJobUpdatable<TData> updatable) where TData : struct, IUpdateTransformJob
		{
			UpdateTransformJobManager<TData>.Instance.Unregister(updatable);
		}

		public static void UnregisterSynchronizationInManager<TData>(this ITransformJobUpdatable<TData> updatable) where TData : struct, IUpdateTransformJob
		{
			UpdateTransformJobManager<TData>.Instance.UnregisterSynchronization(updatable);
		}

		public static bool IsRegisteredInManager<TData>(this ITransformJobUpdatable<TData> updatable) where TData : struct, IUpdateTransformJob
		{
			return UpdateTransformJobManager<TData>.Instance.IsRegistered(updatable);
		}

		public static TData GetJobData<TData>(this ITransformJobUpdatable<TData> updatable) where TData : struct, IUpdateTransformJob
		{
			return UpdateTransformJobManager<TData>.Instance.GetData(updatable);
		}

		public static void SynchronizeJobDataOnce<TData>(this ITransformJobUpdatable<TData> updatable) where TData : struct, IUpdateTransformJob
		{
			UpdateTransformJobManager<TData>.Instance.SynchronizeJobDataOnce(updatable);
		}
	}
}
