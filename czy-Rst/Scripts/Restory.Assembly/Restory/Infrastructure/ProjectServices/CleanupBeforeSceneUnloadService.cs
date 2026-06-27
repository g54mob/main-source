using System.Collections.Generic;
using RSG;

namespace Restory.Infrastructure.ProjectServices
{
	public class CleanupBeforeSceneUnloadService
	{
		private readonly HashSet<ICleanupBeforeSceneUnload> cleaners = new HashSet<ICleanupBeforeSceneUnload>();

		public void RegisterCleanupService(ICleanupBeforeSceneUnload service)
		{
			if (service != null)
			{
				cleaners.Add(service);
			}
		}

		public void UnregisterCleanupService(ICleanupBeforeSceneUnload service)
		{
			if (service != null)
			{
				cleaners.Remove(service);
			}
		}

		public IPromise PerformCleanup()
		{
			List<IPromise> list = new List<IPromise>();
			foreach (ICleanupBeforeSceneUnload cleaner in cleaners)
			{
				if (cleaner != null)
				{
					list.Add(cleaner.CleanupPromise());
				}
			}
			return Promise.All(list);
		}
	}
}
