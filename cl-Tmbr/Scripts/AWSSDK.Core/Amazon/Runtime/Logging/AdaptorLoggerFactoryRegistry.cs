using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Logging
{
	public static class AdaptorLoggerFactoryRegistry
	{
		public static void RegisterAdaptorLoggerFactory(IAdaptorLoggerFactory factory)
		{
			Logger.RegisterAdaptorLoggerFactory(factory);
		}

		public static void DeregisterAdaptorLoggerFactory(string factoryName)
		{
			Logger.DeregisterAdaptorLoggerFactory(factoryName);
		}
	}
}
