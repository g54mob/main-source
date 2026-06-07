using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct SessionDetailsSettingsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_BucketId;

		private uint m_NumPublicConnections;

		private int m_AllowJoinInProgress;

		private OnlineSessionPermissionLevel m_PermissionLevel;

		private int m_InvitesAllowed;

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

		public uint NumPublicConnections
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public bool AllowJoinInProgress
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public OnlineSessionPermissionLevel PermissionLevel
		{
			get
			{
				return default(OnlineSessionPermissionLevel);
			}
			set
			{
			}
		}

		public bool InvitesAllowed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void Set(SessionDetailsSettings other)
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
