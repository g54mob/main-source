namespace Amazon.Runtime.Internal
{
	public interface IDefaultConfigurationProvider
	{
		IDefaultConfiguration GetDefaultConfiguration(RegionEndpoint clientRegion, DefaultConfigurationMode? requestedConfigurationMode = null);
	}
}
