using System;

namespace R3
{
	public static class ObservableSystem
	{
		private static IServiceProvider? serviceProvider;

		private static Func<IServiceProvider>? serviceProviderFactory;

		private static TimeProvider defaultTimeProvider = TimeProvider.System;

		private static FrameProvider defaultFrameProvider = new NotSupportedFrameProvider();

		private static Action<Exception> unhandledException = DefaultUnhandledExceptionHandler;

		public static TimeProvider DefaultTimeProvider
		{
			get
			{
				IServiceProvider serviceProvider = ObservableSystem.serviceProvider;
				if (serviceProviderFactory != null)
				{
					serviceProvider = serviceProviderFactory();
				}
				if (serviceProvider != null)
				{
					object service = serviceProvider.GetService(typeof(TimeProvider));
					if (service != null)
					{
						return (TimeProvider)service;
					}
				}
				return defaultTimeProvider;
			}
			set
			{
				defaultTimeProvider = value;
			}
		}

		public static FrameProvider DefaultFrameProvider
		{
			get
			{
				IServiceProvider serviceProvider = ObservableSystem.serviceProvider;
				if (serviceProviderFactory != null)
				{
					serviceProvider = serviceProviderFactory();
				}
				if (serviceProvider != null)
				{
					object service = serviceProvider.GetService(typeof(FrameProvider));
					if (service != null)
					{
						return (FrameProvider)service;
					}
				}
				return defaultFrameProvider;
			}
			set
			{
				defaultFrameProvider = value;
			}
		}

		public static void RegisterServiceProvider(IServiceProvider? serviceProvider)
		{
			ObservableSystem.serviceProvider = serviceProvider;
			serviceProviderFactory = null;
		}

		public static void RegisterServiceProvider(Func<IServiceProvider> serviceProviderFactory)
		{
			serviceProvider = null;
			ObservableSystem.serviceProviderFactory = serviceProviderFactory;
		}

		public static void RegisterUnhandledExceptionHandler(Action<Exception> unhandledExceptionHandler)
		{
			unhandledException = unhandledExceptionHandler;
		}

		public static Action<Exception> GetUnhandledExceptionHandler()
		{
			return unhandledException;
		}

		private static void DefaultUnhandledExceptionHandler(Exception exception)
		{
			Console.WriteLine("R3 UnhandleException: " + exception.ToString());
		}
	}
}
