using System;

namespace Sentry
{
	[Obsolete("WARNING: This method deliberately causes a crash, and should not be used in a real application.")]
	public enum CrashType
	{
		Managed = 0,
		ManagedBackgroundThread = 1
	}
}
