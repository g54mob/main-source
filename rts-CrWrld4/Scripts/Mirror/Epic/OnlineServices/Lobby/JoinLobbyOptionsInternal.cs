using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct JoinLobbyOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LobbyDetailsHandle;

		private IntPtr m_LocalUserId;

		private int m_PresenceEnabled;

		public LobbyDetails LobbyDetailsHandle
		{
			set
			{
			}
		}

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public bool PresenceEnabled
		{
			set
			{
			}
		}

		public void Set(JoinLobbyOptions other)
		{
		}

		public void Set(object other)
		{
		}

		public void Dispose()
		{
		}
	}
}
