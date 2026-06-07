using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct ActiveSessionInfoInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_SessionName;

		private IntPtr m_LocalUserId;

		private OnlineSessionState m_State;

		private IntPtr m_SessionDetails;

		public string SessionName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ProductUserId LocalUserId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public OnlineSessionState State
		{
			get
			{
				return default(OnlineSessionState);
			}
			set
			{
			}
		}

		public SessionDetailsInfo SessionDetails
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(ActiveSessionInfo other)
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
