using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct CopyLobbyDetailsHandleByInviteIdOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_InviteId;

		public string InviteId
		{
			set
			{
			}
		}

		public void Set(CopyLobbyDetailsHandleByInviteIdOptions other)
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
