using System.Collections.Generic;

namespace VoxelBusters.CoreLibrary
{
	public class ApplicationLifecycleObserver : SingletonBehaviour<ApplicationLifecycleObserver>
	{
		[ClearOnReload(/*Could not decode attribute arguments.*/)]
		private List<IApplicationLifecycleListener> m_listeners;

		public static ApplicationLifecycleObserver Initialize()
		{
			return null;
		}

		public void AddListener(IApplicationLifecycleListener listener)
		{
		}

		public void RemoveListener(IApplicationLifecycleListener listener)
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		private void OnApplicationPause(bool pauseStatus)
		{
		}

		private void OnApplicationQuit()
		{
		}
	}
}
