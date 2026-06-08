namespace Platforms.PlatformDebugConfigurations
{
	public static class DebugConfig
	{
		public static bool IsUsed => PlatformSettings.IsDebugBuild;

		public static GenericDebugConfig Generic
		{
			get
			{
				if (!(PlatformDebugConfiguration.Default == null))
				{
					return PlatformDebugConfiguration.Default.Generic;
				}
				return default(GenericDebugConfig);
			}
		}

		public static SwitchFailureFlags Switch
		{
			get
			{
				if (!IsUsed)
				{
					return default(SwitchFailureFlags);
				}
				if (!(PlatformDebugConfiguration.Default == null))
				{
					return PlatformDebugConfiguration.Default.Switch;
				}
				return default(SwitchFailureFlags);
			}
		}
	}
}
