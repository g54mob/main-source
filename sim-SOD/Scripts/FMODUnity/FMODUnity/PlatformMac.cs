using System.Collections.Generic;

namespace FMODUnity
{
	public class PlatformMac : Platform
	{
		private static List<CodecChannelCount> staticCodecChannels;

		public override string DisplayName => null;

		public override List<CodecChannelCount> DefaultCodecChannels => null;

		static PlatformMac()
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
