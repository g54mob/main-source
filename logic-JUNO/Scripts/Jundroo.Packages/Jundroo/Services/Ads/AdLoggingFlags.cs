using System;

namespace Jundroo.Services.Ads
{
	[Flags]
	public enum AdLoggingFlags
	{
		Default = 0,
		LogAdEvents = 1,
		LogAdLoads = 2
	}
}
