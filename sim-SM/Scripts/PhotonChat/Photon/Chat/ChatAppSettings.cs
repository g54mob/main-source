using System;
using ExitGames.Client.Photon;

namespace Photon.Chat
{
	[Serializable]
	public class ChatAppSettings
	{
		public string AppIdChat;

		public string AppVersion;

		public string FixedRegion;

		public string Server;

		public ushort Port;

		public string ProxyServer;

		public ConnectionProtocol Protocol;

		public bool EnableProtocolFallback;

		public DebugLevel NetworkLogging;

		public bool IsDefaultNameServer => false;
	}
}
