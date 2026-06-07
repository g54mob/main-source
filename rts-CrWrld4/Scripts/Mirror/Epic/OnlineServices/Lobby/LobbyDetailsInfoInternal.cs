using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct LobbyDetailsInfoInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LobbyId;

		private IntPtr m_LobbyOwnerUserId;

		private LobbyPermissionLevel m_PermissionLevel;

		private uint m_AvailableSlots;

		private uint m_MaxMembers;

		private int m_AllowInvites;

		private IntPtr m_BucketId;

		public string LobbyId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ProductUserId LobbyOwnerUserId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LobbyPermissionLevel PermissionLevel
		{
			get
			{
				return default(LobbyPermissionLevel);
			}
			set
			{
			}
		}

		public uint AvailableSlots
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint MaxMembers
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public bool AllowInvites
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string BucketId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(LobbyDetailsInfo other)
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
