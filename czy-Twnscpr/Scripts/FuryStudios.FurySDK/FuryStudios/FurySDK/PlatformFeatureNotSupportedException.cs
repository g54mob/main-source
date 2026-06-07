using System;

namespace FuryStudios.FurySDK
{
	public class PlatformFeatureNotSupportedException : Exception
	{
		private readonly PlatformFeature unsupportedFeature;

		public override string Message => null;

		public PlatformFeatureNotSupportedException(PlatformFeature feature)
		{
		}
	}
}
