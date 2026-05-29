using System.Collections.Generic;
using System.Diagnostics;
using ExitGames.Client.Photon;

namespace Photon.Chat
{
	public class ChatPeer : PhotonPeer
	{
		public string NameServerHost;

		private static readonly Dictionary<ConnectionProtocol, int> ProtocolToNameServerPort;

		public ushort NameServerPortOverride;

		public string NameServerAddress => null;

		internal virtual bool IsProtocolSecure => false;

		public ChatPeer(IPhotonPeerListener listener, ConnectionProtocol protocol)
			: base(default(ConnectionProtocol))
		{
		}

		[Conditional("SUPPORTED_UNITY")]
		private void ConfigUnitySockets()
		{
		}

		private string GetNameServerAddress()
		{
			return null;
		}

		public bool AuthenticateOnNameServer(string appId, string appVersion, string region, AuthenticationValues authValues)
		{
			return false;
		}
	}
}
