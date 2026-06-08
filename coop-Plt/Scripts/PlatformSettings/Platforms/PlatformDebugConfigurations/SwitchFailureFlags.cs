using System;

namespace Platforms.PlatformDebugConfigurations
{
	[Serializable]
	public struct SwitchFailureFlags
	{
		public bool FailAtNSAEnsureByUserCancellation;

		public bool BlockAtNSAEnsure;
	}
}
