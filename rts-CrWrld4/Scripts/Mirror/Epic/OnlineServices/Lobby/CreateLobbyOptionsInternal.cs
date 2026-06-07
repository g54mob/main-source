using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct CreateLobbyOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private uint m_MaxLobbyMembers;

		private LobbyPermissionLevel m_PermissionLevel;

		private int m_PresenceEnabled;

		private int m_AllowInvites;

		private IntPtr m_BucketId;

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public uint MaxLobbyMembers
		{
			set
			{
			}
		}

		public LobbyPermissionLevel PermissionLevel
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

		public bool AllowInvites
		{
			set
			{
			}
		}

		public string BucketId
		{
			set
			{
			}
		}

		public void Set(CreateLobbyOptions other)
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
