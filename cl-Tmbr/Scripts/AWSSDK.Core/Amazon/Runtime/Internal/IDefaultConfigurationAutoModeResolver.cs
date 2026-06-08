using System;

namespace Amazon.Runtime.Internal
{
	public interface IDefaultConfigurationAutoModeResolver
	{
		DefaultConfigurationMode Resolve(RegionEndpoint clientRegion, Func<RegionEndpoint> imdsRegion);
	}
}
