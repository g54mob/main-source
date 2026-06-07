using System;
using System.Runtime.CompilerServices;
using Steamworks;
using Steamworks.Data;

namespace VampireSurvivors
{
	public class SteamConnectionManager : IConnectionManager
	{
		private bool _isConnectionReady;

		private SteamId _hostSteamId;

		private ConnectionManager _steamRelayConnection;

		public Connection Connection => default(Connection);

		public event Action<ConnectionInfo> OnHostDisconnected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<IntPtr, int> OnMessageReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<string> P2PActivationFailed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public SteamConnectionManager(SteamId hostSteamId)
		{
		}

		public void Open()
		{
		}

		public void Close()
		{
		}

		public void Receive()
		{
		}

		public void OnConnecting(ConnectionInfo info)
		{
		}

		public void OnConnected(ConnectionInfo info)
		{
		}

		public void OnDisconnected(ConnectionInfo info)
		{
		}

		public void OnMessage(IntPtr data, int size, long messageNum, long recvTime, int channel)
		{
		}
	}
}
