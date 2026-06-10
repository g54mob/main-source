namespace FMODUnity
{
	public class PlatformAndroid : Platform
	{
		public override string DisplayName => null;

		static PlatformAndroid()
		{
		}

		public override void DeclareRuntimePlatforms(Settings settings)
		{
		}

		public override string GetBankFolder()
		{
			return null;
		}

		public static string StaticGetBankFolder()
		{
			return null;
		}

		public override string GetPluginPath(string pluginName)
		{
			return null;
		}

		public static string StaticGetPluginPath(string pluginName)
		{
			return null;
		}
	}
}
