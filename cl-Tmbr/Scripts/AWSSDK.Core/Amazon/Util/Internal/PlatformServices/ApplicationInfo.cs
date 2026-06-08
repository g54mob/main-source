using System;

namespace Amazon.Util.Internal.PlatformServices
{
	public class ApplicationInfo : IApplicationInfo
	{
		public string AppTitle
		{
			get
			{
				throw new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the AWSSDK.Core NuGet package from your main application project in order to reference the platform-specific implementation.");
			}
		}

		public string AppVersionName
		{
			get
			{
				throw new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the AWSSDK.Core NuGet package from your main application project in order to reference the platform-specific implementation.");
			}
		}

		public string AppVersionCode
		{
			get
			{
				throw new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the AWSSDK.Core NuGet package from your main application project in order to reference the platform-specific implementation.");
			}
		}

		public string PackageName
		{
			get
			{
				throw new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the AWSSDK.Core NuGet package from your main application project in order to reference the platform-specific implementation.");
			}
		}
	}
}
