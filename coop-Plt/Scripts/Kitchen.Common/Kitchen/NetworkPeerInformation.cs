using Kitchen.NetworkSupport;

namespace Kitchen
{
	public struct NetworkPeerInformation
	{
		public string Name;

		public ConnectionType Connection;

		public INetworkTarget Target;
	}
}
