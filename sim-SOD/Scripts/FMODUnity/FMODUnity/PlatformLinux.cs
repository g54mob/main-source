using System.Collections.Generic;

namespace FMODUnity
{
	public class PlatformLinux : Platform
	{
		private static List<CodecChannelCount> staticCodecChannels;

		public override string DisplayName => null;

		public override List<CodecChannelCount> DefaultCodecChannels => null;

		static PlatformLinux()
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
