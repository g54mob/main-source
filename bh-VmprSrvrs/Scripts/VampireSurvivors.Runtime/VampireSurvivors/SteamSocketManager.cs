using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Steamworks;
using Steamworks.Data;

namespace VampireSurvivors
{
	public class SteamSocketManager : ISocketManager
	{
		private SocketManager _steamSocketManager;

		private int _expectedPeers;

		private bool _isGameReady;

		public HashSet<Connection> Connected => null;

		public event Action OnSessionReady
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

		public event Action<Connection, ConnectionInfo> OnPeerDisconnected
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

		public event Action<Connection, IntPtr, int> OnMessageReceived
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

		public SteamSocketManager(int expectedPeers)
		{
		}

		public string Open()
		{
			return null;
		}

		public void Update()
		{
		}

		public void Close()
		{
		}

		public void OnConnecting(Connection connection, ConnectionInfo info)
		{
		}

		public void OnConnected(Connection connection, ConnectionInfo info)
		{
		}

		public void OnDisconnected(Connection connection, ConnectionInfo info)
		{
		}

		public void OnMessage(Connection connection, NetIdentity identity, IntPtr data, int size, long messageNum, long recvTime, int channel)
		{
		}
	}
}
