using System;
using UnityEngine;

namespace R3
{
	public static class UnityProviderInitializer
	{
		static UnityProviderInitializer()
		{
			SetDefaultObservableSystem();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		public static void SetDefaultObservableSystem()
		{
			SetDefaultObservableSystem(delegate(Exception ex)
			{
				Debug.LogException(ex);
			});
		}

		public static void SetDefaultObservableSystem(Action<Exception> unhandledExceptionHandler)
		{
			ObservableSystem.RegisterUnhandledExceptionHandler(unhandledExceptionHandler);
			ObservableSystem.DefaultTimeProvider = UnityTimeProvider.Update;
			ObservableSystem.DefaultFrameProvider = UnityFrameProvider.Update;
		}
	}
}
