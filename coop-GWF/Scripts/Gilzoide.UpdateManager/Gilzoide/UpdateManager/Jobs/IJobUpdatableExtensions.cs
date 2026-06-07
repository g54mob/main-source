namespace Gilzoide.UpdateManager.Jobs
{
	public static class IJobUpdatableExtensions
	{
		public static void RegisterInManager<TData>(this IJobUpdatable<TData> updatable) where TData : struct, IUpdateJob
		{
			UpdateJobManager<TData>.Instance.Register(updatable);
		}

		public static void RegisterInManager<TData>(this IJobUpdatable<TData> updatable, bool syncEveryFrame) where TData : struct, IUpdateJob
		{
			UpdateJobManager<TData>.Instance.Register(updatable, syncEveryFrame);
		}

		public static void UnregisterInManager<TData>(this IJobUpdatable<TData> updatable) where TData : struct, IUpdateJob
		{
			UpdateJobManager<TData>.Instance.Unregister(updatable);
		}

		public static void UnregisterSynchronizationInManager<TData>(this IJobUpdatable<TData> updatable) where TData : struct, IUpdateJob
		{
			UpdateJobManager<TData>.Instance.UnregisterSynchronization(updatable);
		}

		public static bool IsRegisteredInManager<TData>(this IJobUpdatable<TData> updatable) where TData : struct, IUpdateJob
		{
			return UpdateJobManager<TData>.Instance.IsRegistered(updatable);
		}

		public static TData GetJobData<TData>(this IJobUpdatable<TData> updatable) where TData : struct, IUpdateJob
		{
			return UpdateJobManager<TData>.Instance.GetData(updatable);
		}

		public static void SynchronizeJobDataOnce<TData>(this IJobUpdatable<TData> updatable) where TData : struct, IUpdateJob
		{
			UpdateJobManager<TData>.Instance.SynchronizeJobDataOnce(updatable);
		}
	}
}
