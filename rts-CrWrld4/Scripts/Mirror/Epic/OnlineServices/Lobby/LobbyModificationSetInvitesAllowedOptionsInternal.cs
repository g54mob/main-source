using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct LobbyModificationSetInvitesAllowedOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private int m_InvitesAllowed;

		public bool InvitesAllowed
		{
			set
			{
			}
		}

		public void Set(LobbyModificationSetInvitesAllowedOptions other)
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
