using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct JoinSessionOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_SessionName;

		private IntPtr m_SessionHandle;

		private IntPtr m_LocalUserId;

		private int m_PresenceEnabled;

		public string SessionName
		{
			set
			{
			}
		}

		public SessionDetails SessionHandle
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

		public void Set(JoinSessionOptions other)
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
