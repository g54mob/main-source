using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 56)]
	internal struct CreateSessionModificationOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_SessionName;

		private IntPtr m_BucketId;

		private uint m_MaxPlayers;

		private IntPtr m_LocalUserId;

		private int m_PresenceEnabled;

		private IntPtr m_SessionId;

		public string SessionName
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

		public uint MaxPlayers
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

		public string SessionId
		{
			set
			{
			}
		}

		public void Set(CreateSessionModificationOptions other)
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
