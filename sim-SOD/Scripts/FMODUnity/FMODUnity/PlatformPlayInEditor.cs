using System;
using System.Collections.Generic;
using FMOD;

namespace FMODUnity
{
	public class PlatformPlayInEditor : Platform
	{
		private static List<CodecChannelCount> staticCodecChannels;

		public override string DisplayName => null;

		public override bool IsIntrinsic => false;

		public override List<CodecChannelCount> DefaultCodecChannels => null;

		public override void DeclareRuntimePlatforms(Settings settings)
		{
		}

		public override string GetBankFolder()
		{
			return null;
		}

		public override void LoadStaticPlugins(FMOD.System coreSystem, Action<RESULT, string> reportResult)
		{
		}

		public override void InitializeProperties()
		{
		}
	}
}
