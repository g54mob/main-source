using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct LobbyModificationSetPermissionLevelOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private LobbyPermissionLevel m_PermissionLevel;

		public LobbyPermissionLevel PermissionLevel
		{
			set
			{
			}
		}

		public void Set(LobbyModificationSetPermissionLevelOptions other)
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
