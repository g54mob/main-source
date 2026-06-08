using System;

namespace Amazon.Util.Internal.PlatformServices
{
	public class ApplicationSettings : IApplicationSettings
	{
		public void SetValue(string key, string value, ApplicationSettingsMode mode)
		{
			throw new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the AWSSDK.Core NuGet package from your main application project in order to reference the platform-specific implementation.");
		}

		public string GetValue(string key, ApplicationSettingsMode mode)
		{
			throw new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the AWSSDK.Core NuGet package from your main application project in order to reference the platform-specific implementation.");
		}

		public void RemoveValue(string key, ApplicationSettingsMode mode)
		{
			throw new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the AWSSDK.Core NuGet package from your main application project in order to reference the platform-specific implementation.");
		}
	}
}
