namespace FMODUnity
{
	public class PlatformWebGL : Platform
	{
		public override string DisplayName => null;

		static PlatformWebGL()
		{
		}

		public override void DeclareRuntimePlatforms(Settings settings)
		{
		}

		public override string GetPluginPath(string pluginName)
		{
			return null;
		}
	}
}
