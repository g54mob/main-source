namespace Amazon.Util.Internal.PlatformServices
{
	public class EnvironmentInfo : IEnvironmentInfo
	{
		public string Platform { get; }

		public string PlatformUserAgent { get; }

		public string FrameworkUserAgent { get; }

		public EnvironmentInfo()
		{
			Platform = InternalSDKUtils.DetermineOS();
			PlatformUserAgent = InternalSDKUtils.PlatformUserAgent();
			FrameworkUserAgent = InternalSDKUtils.DetermineFramework();
		}
	}
}
