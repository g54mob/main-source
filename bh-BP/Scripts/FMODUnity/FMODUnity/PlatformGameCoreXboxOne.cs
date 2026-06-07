using System.Collections.Generic;

namespace FMODUnity
{
	public class PlatformGameCoreXboxOne : Platform
	{
		private static List<ThreadAffinityGroup> StaticThreadAffinities;

		private static List<CodecChannelCount> staticCodecChannels;

		internal override string DisplayName => null;

		internal override List<ThreadAffinityGroup> DefaultThreadAffinities => null;

		internal override List<CodecChannelCount> DefaultCodecChannels => null;

		static PlatformGameCoreXboxOne()
		{
		}

		internal override void DeclareRuntimePlatforms(Settings settings)
		{
		}

		internal override string GetPluginPath(string pluginName)
		{
			return null;
		}
	}
}
