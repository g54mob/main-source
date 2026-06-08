namespace Amazon.Runtime.Internal
{
	public interface IAmazonSecurityProtocolManager
	{
		bool IsSecurityProtocolSystemDefault();

		void UpdateProtocolsToSupported();
	}
}
