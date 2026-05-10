using System;
using System.Net;

namespace ExitGames.Client.Photon
{
	public abstract class IPhotonSocket
	{
		protected internal PeerBase peerBase;

		protected readonly ConnectionProtocol Protocol;

		public bool PollReceive;

		public string ConnectAddress;

		protected IPhotonPeerListener Listener => null;

		protected internal int MTU => 0;

		public PhotonSocketState State { get; protected set; }

		public int SocketErrorCode { get; protected set; }

		public bool Connected => false;

		public string ServerAddress { get; protected set; }

		public string ProxyServerAddress { get; protected set; }

		public static string ServerIpAddress { get; protected set; }

		public int ServerPort { get; protected set; }

		public bool AddressResolvedAsIpv6 { get; protected internal set; }

		public string UrlProtocol { get; protected set; }

		public string UrlPath { get; protected set; }

		protected internal string SerializationProtocol => null;

		public IPhotonSocket(PeerBase peerBase)
		{
		}

		public virtual bool Connect()
		{
			return false;
		}

		public abstract bool Disconnect();

		public abstract PhotonSocketError Send(byte[] data, int length);

		public abstract PhotonSocketError Receive(out byte[] data);

		public void HandleReceivedDatagram(byte[] inBuffer, int length, bool willBeReused)
		{
		}

		public bool ReportDebugOfLevel(DebugLevel levelOfMessage)
		{
			return false;
		}

		public void EnqueueDebugReturn(DebugLevel debugLevel, string message)
		{
		}

		protected internal void HandleException(StatusCode statusCode)
		{
		}

		protected internal bool TryParseAddress(string url, out string host, out ushort port, out string scheme, out string absolutePath)
		{
			host = null;
			port = default(ushort);
			scheme = null;
			absolutePath = null;
			return false;
		}

		private bool IpAddressTryParse(string strIP, out IPAddress address)
		{
			address = null;
			return false;
		}

		protected internal IPAddress[] GetIpAddresses(string hostname)
		{
			return null;
		}

		private int AddressSortComparer(IPAddress x, IPAddress y)
		{
			return 0;
		}

		[Obsolete("Use GetIpAddresses instead.")]
		protected internal static IPAddress GetIpAddress(string address)
		{
			return null;
		}
	}
}
