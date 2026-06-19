using System.Collections.Generic;

namespace FMODUnity
{
	public class PlatformGameCoreXboxOne : Platform
	{
		private static List<ThreadAffinityGroup> StaticThreadAffinities;

		private static List<CodecChannelCount> staticCodecChannels;

		internal override string DisplayName => "GameCore - Xbox One";

		internal override List<ThreadAffinityGroup> DefaultThreadAffinities => StaticThreadAffinities;

		internal override List<CodecChannelCount> DefaultCodecChannels => staticCodecChannels;

		static PlatformGameCoreXboxOne()
		{
			StaticThreadAffinities = new List<ThreadAffinityGroup>
			{
				new ThreadAffinityGroup(ThreadAffinity.Core2, default(ThreadType)),
				new ThreadAffinityGroup(ThreadAffinity.Core4, ThreadType.Studio_Update, ThreadType.Studio_Load_Bank, ThreadType.Studio_Load_Sample)
			};
			staticCodecChannels = new List<CodecChannelCount>
			{
				new CodecChannelCount
				{
					format = CodecType.FADPCM,
					channels = 0
				},
				new CodecChannelCount
				{
					format = CodecType.Vorbis,
					channels = 0
				},
				new CodecChannelCount
				{
					format = CodecType.XMA,
					channels = 32
				}
			};
			Settings.AddPlatformTemplate<PlatformGameCoreXboxOne>("b6ec8bd6b9ae9fc4db965aa4fd74cc7c");
		}

		internal override void DeclareRuntimePlatforms(Settings settings)
		{
		}

		internal override string GetPluginPath(string pluginName)
		{
			return $"{GetPluginBasePath()}/{pluginName}.dll";
		}
	}
}
