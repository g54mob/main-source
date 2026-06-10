using System;
using FMOD;

namespace FMODUnity
{
	public class PlatformAppleTV : Platform
	{
		public override string DisplayName => null;

		static PlatformAppleTV()
		{
		}

		public override void DeclareRuntimePlatforms(Settings settings)
		{
		}

		public override void LoadPlugins(FMOD.System coreSystem, Action<RESULT, string> reportResult)
		{
		}
	}
}
